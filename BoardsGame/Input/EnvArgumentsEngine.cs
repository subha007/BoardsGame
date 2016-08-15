#region License
// EnvArgumentsEngine.cs
// Copyright (c) 2016, Subhadeep Niogi
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted provide
// d that the following conditions are met:
// 
// Redistributions of source code must retain the above copyright notice, this list of conditions and the
// following disclaimer.
// 
// Redistributions in binary form must reproduce the above copyright notice, this list of conditions and
// the following disclaimer in the documentation and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED 
// WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
// TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING 
// NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE.
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    public class EnvArgumentsEngine : IArgumentsEngine
    {
        public ParameterOptions Options { get; protected set; }

        public EnvArgumentsEngine(ParameterOptions options)
        {
            this.Options = options;
        }

        public void Parse(string[] args)
        {
            Type type = typeof(ParameterOptions);
            PropertyInfo[] OptionsProperties = type.GetProperties();

            for (int indx = 0; indx < args.Length; ++indx)
            {
                PropertyInfo prop = OptionsProperties.First(pi =>
                {
                    ArgTypeAttribute argAttr = pi.GetCustomAttribute<ArgTypeAttribute>();

                    return (argAttr != null) && (Array.IndexOf(argAttr.Options, args[indx]) > -1);
                });

                if (prop != null)
                {
                    ArgTypeAttribute argAttr = prop.GetCustomAttribute<ArgTypeAttribute>();
                    if (argAttr.IsValueFoundNext)
                    {
                        indx++;
                        if (indx < args.Length)
                            prop.SetValue(this.Options, args[indx].ToString());
                        else
                            throw new ArgumentException(
                                        string.Format(StringResource.PA_VALUE_MISSING, args[indx]));
                    }
                    else
                    {
                        // The property itself should be a boolean
                        if (prop.GetType() == typeof(bool))
                        {
                            prop.SetValue(this.Options, true);
                        }
                    }
                }
                else
                {
                    throw new InvalidDataException(string.Format(StringResource.PA_UNKNOWN_OPTION, args[indx]));
                }
            }

            CheckManadatory(OptionsProperties);
        }

        private void CheckManadatory(PropertyInfo[] OptionsProperties)
        {
            for (int indx = 0; indx < OptionsProperties.Length; ++indx )
            {
                PropertyInfo prop = OptionsProperties[indx];
                ArgTypeAttribute argAttr = prop.GetCustomAttribute<ArgTypeAttribute>();

                if(argAttr.IsMandatory)
                {
                    if(prop.GetValue(this.Options) == null)
                        throw new ArgumentException(argAttr.ErrorStringResource);
                }
            }
        }
    }
}
