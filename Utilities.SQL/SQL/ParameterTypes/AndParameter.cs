﻿/*
Copyright (c) 2012 <a href="http://www.gutgames.com">James Craig</a>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.*/

#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utilities.SQL.MicroORM.Interfaces;
using Utilities.Reflection.ExtensionMethods;
using Utilities.SQL.Interfaces;
#endregion

namespace Utilities.SQL.ParameterTypes
{
    /// <summary>
    /// Parameter class that ANDs two other parameters together
    /// </summary>
    public class AndParameter : IParameter
    {
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public AndParameter(IParameter Left, IParameter Right)
        {
            this.Left = Left;
            this.Right = Right;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Left parameter
        /// </summary>
        public IParameter Left { get; set; }

        /// <summary>
        /// Right parameter
        /// </summary>
        public IParameter Right { get; set; }

        /// <summary>
        /// Not used
        /// </summary>
        public string ID { get { return ""; } set { } }

        #endregion

        #region Functions

        public void AddParameter(SQLHelper Helper)
        {
            Left.AddParameter(Helper);
            Right.AddParameter(Helper);
        }

        public override string ToString() { return "(" + Left.ToString() + " AND " + Right.ToString() + ")"; }

        #endregion
    }
}