#region License
// ParameterOptions.cs
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
using System.Text;
using System.Threading.Tasks;

namespace BoardsGame
{
    /// <summary>
    /// The list of command line arguments
    /// </summary>
    public class ParameterOptions : IParameterOptions
    {
        /// <summary>
        /// Defines the type of output that the program will produce
        /// Option can be either '-t' or '-type'
        /// </summary>
        [ArgType(new string[] { "-t", "-type" },
                HelpStringResource = "PA_HELP_OUTPUT_TYPE")]
        public string OutputType { get; set; }

        [ArgType(new string[] { "-fo", "-fileoutput" },
                HelpStringResource = "PA_HELP_FILE_PATH")]
        public string FilePath { get; set; }

        [ArgType(new string[] { "-b", "-board" },
                HelpStringResource = "PA_HELP_BOARD",
                IsMandatory = true,
                ErrorStringResource = "PA_BOARD_NAME_EMPTY")]
        public string Board { get; set; }

        [ArgType(new string[] { "-pc", "-center" },
                HelpStringResource = "PA_HELP_CENTER",
                IsMandatory = true,
                ErrorStringResource = "PA_CENTER_EMPTY")]
        public string Center { get; set; }

        [ArgType(new string[] { "-r", "-radius" },
                HelpStringResource = "PA_HELP_RADIUS",
                IsMandatory = true,
                ErrorStringResource = "PA_RADIUS_EMPTY")]
        public string Radius { get; set; }

        [ArgType(new string[] { "-cps", "-circlesperside" },
                HelpStringResource = "PA_HELP_CIRCLES_PER_SIDE")]
        public string CirclesPerSide { get; set; }

        [ArgType(new string[] { "-bb", "-borderbeam" },
                HelpStringResource = "PA_HELP_BORDER")]
        public string BorderBeam { get; set; }

        public ParameterOptions()
        {
            this.OutputType = "svg";
            this.FilePath = Path.Combine(AppConstants.ExeLocation, "Output.svg");
        }
    }
}
