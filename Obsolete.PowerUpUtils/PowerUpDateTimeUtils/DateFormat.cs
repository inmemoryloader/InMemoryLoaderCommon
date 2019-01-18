//
// DateFormat.cs
//
// Author: responsive kaysta
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

namespace PowerUpDateTimeUtils
{
    /// <summary>
    /// Gibt ein Datumsformat an
    /// </summary>
    public enum DateFormat
    {
        /// <summary>
        /// Deutsches Format (wird in den meisten Ländern verwendet)
        /// </summary>
        German,

        /// <summary>
        /// Etwa: dd/MM/yyyy hh:mm:ss tt
        /// </summary>
        English1,

        /// <summary>
        /// Etwa: MM/dd/yyyy h:mm:ss tt
        /// </summary>
        English2,

        /// <summary>
        /// Etwa: dd-MM-yyyy H:mm:ss
        /// </summary>
        Indian1,

        /// <summary>
        /// Etwa: dd-MM-yyyy HH.mm.ss
        /// </summary>
        Indian2,

        /// <summary>
        /// Etwa: yyyy-MM-dd HH:mm:ss
        /// </summary>
        Chinese1,

        /// <summary>
        /// Etwa: yyyy/MM/dd hh:mm:ss tt
        /// </summary>
        Chinese2,

        /// <summary>
        /// Etwa yyyy.MM.dd HH:mm:ss
        /// </summary>
        Hungary,

        /// <summary>
        /// Yakut in Russland. MM.dd.yyyy HH:mm:ss
        /// </summary>
        Yakut,

        /// <summary>
        /// Nicht unterstütztes Format
        /// </summary>
        UnSupportedFormat
    }
}

