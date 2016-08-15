#region License

// OutPutStream.cs
// Copyright (c) 2016, Subhadeep Niogi
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
// 
// Redistributions of source code must retain the above copyright notice, this list
// of conditions and the following disclaimer.
// 
// Redistributions in binary form must reproduce the above copyright notice, this 
// list of conditions and the following disclaimer in the documentation and/or other
// materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
// IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
// PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE.

#endregion

#region Namespace

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace BoardsGame
{
    /// <summary>
    /// The base class for all output stream type
    /// </summary>
    public abstract class OutPutStream : IOutStream
    {
        /// <summary>
        /// The full path or absolute path of the output file
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Internal String builder to store the data
        /// </summary>
        protected StringBuilder writer;

        /// <summary>
        /// Flag to check if Start method is called to start the streaming
        /// </summary>
        public bool IsStarted { get; set; }

        /// <summary>
        /// Base constructor to initialize the object
        /// </summary>
        /// <param name="name">Output File Path</param>
        public OutPutStream(string name = "")
        {
            this.FileName = name;
            writer = new StringBuilder();
            this.IsStarted = false;
            Initialize();
        }

        /// <summary>
        /// Other initialization tasks seperate from the construction
        /// </summary>
        public virtual void Initialize()
        {
            
        }

        /// <summary>
        /// Signals the Start of the streaming
        /// </summary>
        public virtual void Start()
        {
            this.IsStarted = true;
        }

        /// <summary>
        /// Signals the end of the streaming
        /// </summary>
        public virtual void End()
        {
            this.IsStarted = false;
        }

        /// <summary>
        /// Add Circle to streaming context
        /// </summary>
        /// <param name="cCPoint"></param>
        /// <param name="p"></param>
        public virtual void AddCircle(CCPoint cCPoint, double p)
        {
            if (!this.IsStarted)
                Start();
        }

        /// <summary>
        /// Add Polygon to streaming context
        /// </summary>
        /// <param name="cCPoints"></param>
        public virtual void AddPolygon(CCPoint[] cCPoints)
        {
            if (!this.IsStarted)
                Start();
        }

        /// <summary>
        /// Save the data to file
        /// </summary>
        public virtual void Save()
        {
            if (this.IsStarted) End();
            File.WriteAllText(FileName, writer.ToString());
        }
    }
}
