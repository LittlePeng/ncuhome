using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Ncuhome.Chat.SimpleThreadPool;
using Ncuhome.Chat.Model;
using System.Threading;
using System.Web.Caching;

public partial class _Default : System.Web.UI.Page
{
  

    public  void Insert(string key, object obj, double Minutes)
    {
        Cache cache = new Cache();
        if (obj != null)
        {
            this.Response.Write(cache);
            cache.Remove("dd");
            cache.Insert(key, obj, null, DateTime.Now.AddMinutes(Minutes), Cache.NoSlidingExpiration, CacheItemPriority.High, (a,b,c) => { });
        }
        
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        Insert("dd", "sss", 1);
        
     //  HttpWorkerRequest
    }
    static int msgId = 1;
    protected void Button1_Click(object sender, EventArgs e)
    {
        CometThreadPool.HandleMessage(new ChatMessageModel() {  Id=msgId, Content="dd"});
        msgId++;
    }
}