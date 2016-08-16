#region License

// Matrix2D.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace BoardsGame
{
    /// <summary>
    /// Any list of data in a plane is reresented (identified) as a combination of row
    /// and column. Instead of using a List type data structure e.g., the common class
    /// <see cref="System.Collections.Generic.List"/> we will be using the below class
    /// to store any planar data in the Board game.
    /// The Matrix class below internally implements a jagged array so as to preserve space
    /// wherever necessary
    /// </summary>
    public class Matrix2D<T>
    {
        #region Constants

        /// <summary>
        /// Default row size for Matrix initialization
        /// </summary>
        protected const int ROWS_COUNT_DEFAULT = 1;

        /// <summary>
        /// Default column size for Matrix initialization
        /// </summary>
        protected const int COL_COUNT_DEFAULT = 1;

        #endregion

        #region Properties

        /// <summary>
        /// Get the raw internal jagged array
        /// </summary>
        public List<List<T>> Block { get; protected set; }

        /// <summary>
        /// Get the data structure is a true jagged array or a uniform array
        /// </summary>
        public bool IsJaggedArray { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Basic constructor for initializing only the rows
        /// </summary>
        public Matrix2D(int rows)
        {
            // Initialize rows
            this.SetupRows(rows);
        }

        /// <summary>
        /// Basic constrictor to create object of <see cref="Matrix2D"/>
        /// </summary>
        /// <param name="rows">The number of rows</param>
        /// <param name="cols">The number of columns for every row (For uneven columns use another
        /// constructor)</param>
        public Matrix2D(int rows = ROWS_COUNT_DEFAULT, int cols = COL_COUNT_DEFAULT)
        {
            // Initialize rows
            this.SetupRows(rows);

            // Initialize Columns
            this.SetupColumns(cols);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Create the inner array with the number of rows passed.
        /// This method is used in case one has a truly jagged array. For even rows and columns use
        /// the constructor
        /// </summary>
        /// <param name="rows"></param>
        public void SetupRows(int rows)
        {
            this.IsJaggedArray = true;

            if (rows <= 0) return;

            this.Block = new List<List<T>>(rows);
        }

        /// <summary>
        /// Create the inner jagged array matrix in case the number of columns are equal for all rows
        /// </summary>
        /// <param name="cols">The number of columns for all rows</param>
        public void SetupColumns(int cols)
        {
            this.IsJaggedArray = false;

            if (cols <= 0) return;

            for (int r = 0; r < this.GetRows(); ++r)
            {
                this.Block[r] = new List<T>(cols);
            }
        }

        /// <summary>
        /// Create the inner jagged array for the row. Use this method for true jagged array.
        /// </summary>
        /// <param name="rowIndx">The index of the row to initialize</param>
        /// <param name="cols">The number of columns for the row</param>
        public void SetupColumns(int rowIndx, int cols)
        {
            this.IsJaggedArray = true;

            if (rowIndx <= 0 || cols <= 0) return;

            for (int r = 0; r < this.GetRows(); ++r)
            {
                this.Block[r] = new List<T>(cols);
            }
        }

        /// <summary>
        /// Get the count of rows in the raw array
        /// </summary>
        /// <returns></returns>
        public int GetRows()
        {
            return (this.Block != null) ? this.Block.Count : 0;
        }

        /// <summary>
        /// Get the count of columns in the raw array
        /// </summary>
        /// <param name="rowIndx">The row index for which column count is required</param>
        /// <returns></returns>
        public int GetColumns(int rowIndx)
        {
            return (this.Block != null && rowIndx >= 0 && this.GetRows() > rowIndx) ? this.Block[rowIndx].Count : 0;
        }

        /// <summary>
        /// A method to loop through all the entries in the matrix and apply the manipulation applied
        /// </summary>
        /// <param name="manipulateEach"></param>
        public void LoopAllManipulate(Action<int, int, T> manipulateEach)
        {
            for(int row = 0; row < this.GetRows(); ++row)
            {
                for(int col = 0; col < this.GetColumns(row); ++col)
                {
                    manipulateEach(row, col, this.Block[row][col]);
                }
            }
        }

        /// <summary>
        /// A method to loop through all the entries in the matrix and recreate or re-initialize each cell
        /// </summary>
        /// <param name="manipulateEach"></param>
        public void LoopAllCreate(Func<int, int, T> createOrReInitializeEach)
        {
            for (int row = 0; row < this.GetRows(); ++row)
            {
                for (int col = 0; col < this.GetColumns(row); ++col)
                {
                    this.Block[row][col] = createOrReInitializeEach(row, col);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public T Find(Func<T, bool> findHelper)
        {
            if (this.Block == null) return default(T);

            for (int row = 0; row < this.GetRows(); ++row)
            {
                for (int col = 0; col < this.GetColumns(row); ++col)
                {
                    if(findHelper(this.Block[row][col]) == true)
                        return this.Block[row][col];
                }
            }

            return default(T);
        }

        /// <summary>
        /// Checks the validity of the matrix position object
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool IsValid(Matrix2DPosition pos)
        {
            return !(this.Block == null || this.GetRows() <= pos.Row || pos.Row < 0 ||
                        pos.Column < 0 || this.GetColumns(pos.Row) <= pos.Column);
        }

        /// <summary>
        /// Add the obj at the specified position
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="obj"></param>
        public void Add(Matrix2DPosition pos, T obj)
        {
            if(IsValid(pos))
            {
                this.Block[pos.Row][pos.Column] = obj;
            }
        }

        /// <summary>
        /// Remove the obj at the specified position
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="obj"></param>
        public void Remove(Matrix2DPosition pos)
        {
            if (IsValid(pos))
            {
                this.Block[pos.Row][pos.Column] = default(T);
            }
        }

        /// <summary>
        /// Get the data from the matrix
        /// </summary>
        /// <param name="rowIndx"></param>
        /// <param name="colIndx"></param>
        /// <returns></returns>
        public T GetData(Matrix2DPosition pos)
        {
            return (IsValid(pos)) ? this.Block[pos.Row][pos.Column] : default(T);
        }

        #endregion
    }
}
