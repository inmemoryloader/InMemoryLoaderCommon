//
// AbstractCommonBase.Converter.cs
//
// Author: Kay Stuckenschmidt
//
// Copyright (c) 2019 responsive IT
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

using System.Threading.Tasks;
using InMemoryLoader;
using InMemoryLoaderBase;
using InMemoryLoaderBase.HelperEnum;

namespace InMemoryLoaderCommon
{
    public abstract partial class AbstractCommonBase : AbstractLoaderBase
    {

        #region Strings

        IDynamicClassInfo Strings;
        bool StringsSet;

        private void SetStrings()
        {
            if (Strings == null)
            {
                Strings = ComponentLoader.GetClassReference("Strings");
            }
            StringsSet = true;
        }


        // AbbreviateString
        // ####################################################################################

        public dynamic AbbreviateString(string paramValue, int maxCharCount)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, maxCharCount };
            return ComponentLoader.InvokeMethod(Strings, "Abbreviate", paramArgs);
        }

        public async Task<dynamic> AbbreviateStringAsync(string paramValue, int maxCharCount)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, maxCharCount };
            return await InvokeMethodAsync(Strings, "Abbreviate", paramArgs);
        }


        // CountOccurenceOfString
        // ####################################################################################

        public dynamic CountOccurenceOfString(string paramValue, string paramMatch)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, paramMatch };
            return ComponentLoader.InvokeMethod(Strings, "CountOccurenceOfString", paramArgs);
        }

        public async Task<dynamic> CountOccurenceOfStringAsync(string paramValue, string paramMatch)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, paramMatch };
            return await InvokeMethodAsync(Strings, "CountOccurenceOfString", paramArgs);
        }


        // CutString
        // ####################################################################################

        public dynamic CutString(string paramValue, int paramSize, StringDirection paramDirection)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, paramSize, paramDirection };
            return ComponentLoader.InvokeMethod(Strings, "CutString", paramArgs);
        }

        public async Task<dynamic> CutStringAsync(string paramValue, int paramSize, StringDirection paramDirection)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, paramSize, paramDirection };
            return await InvokeMethodAsync(Strings, "CutString", paramArgs);
        }


        // ExtractNumbers
        // ####################################################################################

        public dynamic ExtractNumbers(string paramValue, bool extractOnlyIntegers)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, extractOnlyIntegers };
            return ComponentLoader.InvokeMethod(Strings, "ExtractNumbers", paramArgs);
        }

        public async Task<dynamic> ExtractNumbersAsync(string paramValue, bool extractOnlyIntegers)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, extractOnlyIntegers };
            return await InvokeMethodAsync(Strings, "ExtractNumbers", paramArgs);
        }


        // GetWords
        // ####################################################################################

        public dynamic GetWords(string paramValue)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue };
            return ComponentLoader.InvokeMethod(Strings, "GetWords", paramArgs);
        }

        public async Task<dynamic> GetWordsAsync(string paramValue)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue };
            return await InvokeMethodAsync(Strings, "GetWords", paramArgs);
        }

        public dynamic GetWords(string paramValue, int paramMinLength)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, paramMinLength };
            return ComponentLoader.InvokeMethod(Strings, "GetWords", paramArgs);
        }

        public async Task<dynamic> GetWordsAsync(string paramValue, int paramMinLength)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { paramValue, paramMinLength };
            return await InvokeMethodAsync(Strings, "GetWords", paramArgs);
        }


        // ReplaceString/Char
        // ####################################################################################

        public dynamic ReplaceString(string source, string find, string replacement, bool ignoreCase, int start, int count)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source, find, replacement, ignoreCase, start, count };
            return ComponentLoader.InvokeMethod(Strings, "ReplaceString", paramArgs);
        }

        public async Task<dynamic> ReplaceStringAsync(string source, string find, string replacement, bool ignoreCase, int start, int count)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source, find, replacement, ignoreCase, start, count };
            return await InvokeMethodAsync(Strings, "ReplaceString", paramArgs);
        }

        public dynamic ReplaceString(string source, string find, string replacement, bool ignoreCase)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source, find, replacement, ignoreCase };
            return ComponentLoader.InvokeMethod(Strings, "ReplaceString", paramArgs);
        }

        public async Task<dynamic> ReplaceStringAsync(string source, string find, string replacement, bool ignoreCase)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source, find, replacement, ignoreCase };
            return await InvokeMethodAsync(Strings, "ReplaceString", paramArgs);
        }

        public dynamic ReplaceString(string source, char ToReplace, char ReplaceWith)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source, ToReplace, ReplaceWith };
            return ComponentLoader.InvokeMethod(Strings, "ReplaceString", paramArgs);
        }

        public async Task<dynamic> ReplaceStringAsync(string source, char ToReplace, char ReplaceWith)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source, ToReplace, ReplaceWith };
            return await InvokeMethodAsync(Strings, "ReplaceString", paramArgs);
        }

        public dynamic ReplaceCharAt(string parmString, int parmPos, char parmChar)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { parmString, parmPos, parmChar };
            return ComponentLoader.InvokeMethod(Strings, "ReplaceCharAt", paramArgs);
        }

        public async Task<dynamic> ReplaceCharAtAsync(string parmString, int parmPos, char parmChar)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { parmString, parmPos, parmChar };
            return await InvokeMethodAsync(Strings, "ReplaceCharAt", paramArgs);
        }


        // SplitString
        // ####################################################################################

        public dynamic SplitString(string source, char split)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source, split };
            return ComponentLoader.InvokeMethod(Strings, "SplitString", paramArgs);
        }

        public async Task<dynamic> SplitStringAsync(string source, char split)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source, split };
            return await InvokeMethodAsync(Strings, "SplitString", paramArgs);
        }


        // WordCount
        // ####################################################################################

        public dynamic WordCount(string source)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source };
            return ComponentLoader.InvokeMethod(Strings, "WordCount", paramArgs);
        }

        public async Task<dynamic> WordCountAsync(string source)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source };
            return await InvokeMethodAsync(Strings, "WordCount", paramArgs);
        }


        // WordCountLatin
        // ####################################################################################

        public dynamic WordCountLatin(string source)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source };
            return ComponentLoader.InvokeMethod(Strings, "WordCountLatin", paramArgs);
        }

        public async Task<dynamic> WordCountLatinAsync(string source)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { source };
            return await InvokeMethodAsync(Strings, "WordCountLatin", paramArgs);
        }


        // WordWrap
        // ####################################################################################

        public dynamic WordWrap(string text, int maxCharWidth)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { text, maxCharWidth };
            return ComponentLoader.InvokeMethod(Strings, "WordWrap", paramArgs);
        }

        public async Task<dynamic> WordWrapAsync(string text, int maxCharWidth)
        {
            if (!StringsSet) SetStrings();
            object[] paramArgs = { text, maxCharWidth };
            return await InvokeMethodAsync(Strings, "WordWrap", paramArgs);
        }


        #endregion

    }

}
