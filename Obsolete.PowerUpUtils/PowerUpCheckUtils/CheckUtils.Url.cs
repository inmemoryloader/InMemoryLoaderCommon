﻿//
// CheckUtils.Url.cs
//
// Author: responsive kaysta <me@responsive-kaysta.ch>
//
// Copyright (c) 2017 responsive kaysta
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using InMemoryLoaderBase;
using System.Net;

namespace PowerUpCheckUtils
{
    /// <summary>
    /// Check utils.
    /// </summary>
    public partial class CheckUtils : AbstractComponent
    {
        /// <summary>
        /// Determines whether this instance is URL valid the specified parmURL.
        /// </summary>
        /// <returns><c>true</c> if this instance is URL valid the specified parmURL; otherwise, <c>false</c>.</returns>
        /// <param name="parmUrl">Parm UR.</param>
        public bool IsUrlValid(string parmUrl)
        {
            try
            {
                var reqFp = WebRequest.Create(parmUrl);
                var rspFp = (HttpWebResponse)reqFp.GetResponse();

                if (rspFp.StatusCode != HttpStatusCode.OK)
                    return false;
                
                rspFp.Close();
                return true;
            }
            catch (Exception ex)
            {
                if (Log.IsDebugEnabled)
                    Log.FatalFormat("{0}", ex);
                
                return false;
            }
        }

    }

}