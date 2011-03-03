using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.TcpFileUpload
{
    class HttpHeaderBuffer
    {
        const int headerMaxLength = 8 * 1024;
        const int initHeadSize = 1024;
        private byte[] _header = new byte[initHeadSize];
        private int _start = 0;
        private int _end = 0;

        public int StartPosition { get { return this._start; } }
        public int EndPosition { get { return this._end; } }

        public byte[] buffer { get { return this._header; } }

        public byte this[int position]
        {
            get { return _header[position];}
        }
        public int Length { get { return this._end - this._start; } }

        public void Append(byte[] bt,int offset,int size)
        {
            int emptySize = this._header.Length - this._end;
            if (emptySize < size)
            {

            }

            Array.Copy(bt, offset, this._header, this._end, size);
        }

        private void Realloc(int size)
        { 
        
        }

        public void Clear()
        {
            this._start = 0;
            this._end = 0;
        }
    }
}
