using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ncuhome.TcpFileUpload
{
    public  class HttpParser
    {
        int _oldPosition = 0;
        int _bodyStart = 0;
        bool _isHeadParsed=false;
        HttpStreamBuffer _buffer = new HttpStreamBuffer();
        HttpHeader _header = new HttpHeader();

        const int headerMaxLength = 8 * 1024;

        event EventHandler OnHeaderParsed;
        event EventHandler OnParsedError;
        event EventHandler OnParsedCompleted;

        public void Parse(byte[] buffer, int offset, int size)
        {
            this._buffer.Append(buffer, offset, size);

            if (!_isHeadParsed)
            {
                this._isHeadParsed= this.TryParseHeader();
            }
            else
            {
                this.ParseBody();
            }
        }
        
        bool TryParseHeader()
        {
            for (int i = this._oldPosition; i < this._buffer.Length; i++)
            {
                //two CRLF then the body begin
                if (this._buffer[i] == 13
                    && this._buffer[i + 1] == 10
                    && this._buffer[i + 2] == 13
                    && this._buffer[i + 3] == 10)
                {
                    this._bodyStart = i + 4;
                    this.ParseHeader();
                    return true;
                }
            }

            this._oldPosition = this._buffer.Length-4; //避免 CRLF被分开情况
            return false;
        }

        void ParseHeader()
        {
            int headStart = this.ParseStartLine();
            for (int i = headStart; i < this._bodyStart - 1; i++)
            { 
            //    List<char> name=
            //switch (this._buffer[i])
            //    case 
            }
        }

        int ParseStartLine()
        {
            int startLineEnd = 0;
            for (int i = 0; i < this._bodyStart - 1; i++)
            {
                if (this._buffer[i] == 13)
                {
                    startLineEnd = i - 1;
                }
            }



            return 1;
        }

        void ParseBody()
        { 
            
        }
    }
}
