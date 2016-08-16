#region License

// Abalone2DBoardGame.cs
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
using System.Text;
using System.Threading.Tasks;

#endregion

namespace BoardsGame
{
    /// <summary>
    /// Abalone is a board game designed by Michel Lalet and Laurent Lévi in 1987. 
    /// There are multiple variations of Abalone where maximum six players can play
    /// together.
    /// <seealso cref="http://www.gamerz.net/pbmserv/abalone.html"/>
    /// <para>
    /// <h2>Object of the game</h2>
    /// On a hexagonal board (radius 5) two to six players have armies of marbles. 
    /// Players take turns "pushing" 1, 2 or 3 linearly connected marbles, attempting to 
    /// push their opponents' marbles off the board. First player to push 6 of their 
    /// opponent's marbles off the board wins. In the 3+ player version, the 6 marbles 
    /// may be any combination of 6 opponents' marbles.
    /// </para>
    /// <para>
    /// <h2>Initial board layout</h2>
    /// This is the standard two player layout.
    ///        o o o o o
    ///       o o o o o o
    ///      . . o o o . .
    ///     . . . . . . . .
    ///    . . . . . . . . .
    ///     . . . . . . . .
    ///      . . x x x . .
    ///       x x x x x x
    ///        x x x x x
    /// </para>
    /// <para>
    /// <h2>Movement</h2>
    /// You may move a group of 1, 2, or 3 adjacent marbles of your color (a group of 3 
    /// marbles must be in a straight line) one space in any one of the six possible directions.
    /// </para>
    /// </summary>
    public class Abalone2DBoardGame : BoardGame2D
    {
    }
}
