﻿using SherpaOnnxSharp.Structs;
using SherpaOnnxSharp.DLL;

namespace SherpaOnnxSharp
{
    public class OnlineBase : IDisposable
    {
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                if(_onlineRecognizerResult != IntPtr.Zero)
                {
                    DLL.SherpaOnnx.DestroyOnlineRecognizerResult(_onlineRecognizerResult);
                    _onlineRecognizerResult = IntPtr.Zero;
                }
                if (_onlineStream.impl != IntPtr.Zero)
                {
                    DLL.SherpaOnnx.DestroyOnlineStream(_onlineStream);
                    _onlineStream.impl = IntPtr.Zero;
                }
                if (_onlineRecognizer.impl != IntPtr.Zero)
                {
                    DLL.SherpaOnnx.DestroyOnlineRecognizer(_onlineRecognizer);
                    _onlineRecognizer.impl = IntPtr.Zero;
                }                
                this._disposed = true;
            }
        }

        ~OnlineBase()
        {
            Dispose(this._disposed);
        }

        internal SherpaOnnxOnlineStream _onlineStream;
        internal IntPtr _onlineRecognizerResult;
        internal SherpaOnnxOnlineRecognizer _onlineRecognizer;
        internal bool _disposed = false;
    }
}
