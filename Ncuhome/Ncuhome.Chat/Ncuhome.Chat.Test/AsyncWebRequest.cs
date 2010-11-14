using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Ncuhome.Chat.Test
{
    public class AsyncWebRequest
    {
        public Action<Stream> ResponseCallback;
        public void DoRequestAsync(string url, Action<Stream> action)
        {
            ResponseCallback = action;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.BeginGetResponse(new AsyncCallback(EndGetResponse),request);
        }
        public void EndGetResponse(IAsyncResult result)
        {
            HttpWebRequest request = result.AsyncState as HttpWebRequest;
            HttpWebResponse response = request.EndGetResponse(result) as HttpWebResponse;
            Stream responseStream= response.GetResponseStream();
            if (ResponseCallback != null)
            {
                ResponseCallback(responseStream);
            }
        }
    }
}
