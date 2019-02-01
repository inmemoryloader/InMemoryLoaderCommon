//
// AbstractApplicationBase.cs
//
// Author: Kay Stuckenschmidt
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
using System.Threading.Tasks;
using InMemoryLoader;
using InMemoryLoaderBase;
using log4net;

namespace InMemoryLoaderCommon
{
    public abstract partial class AbstractCommonBase : AbstractLoaderBase
    {

        #region ctor

        private static readonly ILog Log = LogManager.GetLogger(typeof(AbstractCommonBase));

        private CommonComponentLoader CommonComponentLoader;

        public virtual bool SetInMemoryLoaderCommon()
        {
            if (CommonComponentLoader == null)
            {
                CommonComponentLoader = new CommonComponentLoader();
            }

            var isSet = InitCommonComponents(base.AssemblyPath);
            Log.DebugFormat("CommonComponentLoader set: {0}", isSet);
            return isSet;
        }

        public virtual async Task<bool> SetInMemoryLoaderCommonAsync()
        {
            if (CommonComponentLoader == null)
            {
                CommonComponentLoader = new CommonComponentLoader();
            }

            var isSet = await InitCommonComponentsAsync(base.AssemblyPath);
            Log.DebugFormat("CommonComponentLoader set: {0}", isSet);
            return isSet;
        }

        private bool InitCommonComponents(string paramPath)
        {
            if (string.IsNullOrEmpty(AssemblyPath))
            {
                AssemblyPath = paramPath;
            }

            if (CommonComponentLoader == null)
            {
                CommonComponentLoader = new CommonComponentLoader();
            }

            CommonComponentLoader.SetupCommonComponents(AssemblyPath);
            Log.Debug("Init Common Components");

            try
            {
                foreach (var component in CommonComponentLoader.Components)
                {
                    object[] paramArgument = { AbstractComponent.Key };
                    var init = InitComponent(component, paramArgument);
                    Log.DebugFormat("Assembly: {0}, Class: {1}, Is init: {2}", component.Assembly, component.Class, init);
                }
            }
            catch (Exception ex)
            {
                Log.FatalFormat(ex.ToString());
            }
            
            return true;
        }

        private dynamic InitCommonComponentsAsync(string paramPath)
        {
            if (string.IsNullOrEmpty(paramPath)) throw new ArgumentException();
            return Task.Run(() => InitCommonComponents(paramPath));
        }

        #endregion

    }

}