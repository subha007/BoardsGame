#region License

// Program.cs
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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion 

namespace BoardsGame
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// <para>
        /// The main method contains a sequence of events which is made as much generic as possible.
        /// This is a console application Main entry point.
        /// The sequence of events are:
        /// <list type="number">
        /// <listheader>
        /// <term>Main Entry method</term>
        /// <description>The main entry point for the console application which contains a sequence of logic that is as generic as possible.</description>
        /// </listheader>
        /// <item>
        /// <term>Fetch And Parse Arguments</term>
        /// <description>Fetch the environemnt arguments array (and array of strings) passed to the Main method.
        /// Pass it to the <see cref="EnvArgumentsEngine"/> class to parse and process. The <see cref="EnvArgumentsEngine"/> class
        /// uses the default <see cref="ParameterOptions"/> class for the Arguments definitions for this program.
        /// </description>
        /// </item>
        /// <item>
        /// <term>Board Game Factory</term>
        /// <description>After successfull parsing of the arguments into the <see cref="ParameterOptions"/> object, 
        /// the Borad game factory class <see cref="GameBoardFactory"/> creates the board game object <see cref="BoardGame"/>
        /// using the previously initialized <see cref="EnvArgumentsEngine"/>
        /// </description>
        /// </item>
        /// <item>
        /// <term>Output Type Factory</term>
        /// <description>After successfull creation of <see cref="GameBoardFactory"/>, the output type factory <see cref="OutputStreamFactory"/>
        /// is used to create the<see cref="OutPutStream"/> object from the previously initialized <see cref="EnvArgumentsEngine"/> 
        /// </description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        static void Main(string[] args)
        {
            // Initialize the Argument parser engine with the command line arguments object
            EnvArgumentsEngine argEngine = new EnvArgumentsEngine(new ParameterOptions());

            // Call Parse to parse the arguments and store in the object
            argEngine.Parse(args);

            // Create the Game board factory which will be used to generate game board
            GameBoardFactory factory = new GameBoardFactory();

            // Generate the Game board
            BoardGame bGame = factory.GenerateBoard(argEngine);

            // Create the output factory
            OutputStreamFactory factoryOutput = new OutputStreamFactory();

            // Generate the output stream object
            OutPutStream stream = factoryOutput.GenerateStream(argEngine);

            // Generate the output
            bGame.ToOutput(stream);

            // Save to file
            stream.Save();
        }
    }
}
