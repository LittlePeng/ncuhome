using System;
using System.Web;
using System.Web.UI;
using System.IO;

namespace Ncuhome.Blog.Core
{
    /// <summary>
    ///  博客统一的PageBase，用于通用性的处理等问题。
    ///  llj098,20090423
    /// </summary>
    public class DefaultPageBase :Page
    {

        protected override void Render(HtmlTextWriter writer)
        {
            ///这里主要是冲洗了form 标签的 action
            ///因为url重写之后，action还是原来的地址
            ///这里做了处理。llj098,20090423
            if (writer is System.Web.UI.Html32TextWriter)
            {
                writer = new FormFixerHtml32TextWriter(writer.InnerWriter);
            }
            else
            {
                writer = new FormFixerHtmlTextWriter(writer.InnerWriter);
            }
            base.Render(writer);
        }

    }


    internal class FormFixerHtml32TextWriter : System.Web.UI.Html32TextWriter
    {
        private string _url; // 假的URL
        internal FormFixerHtml32TextWriter(TextWriter writer)
            : base(writer)
        {
            _url = HttpContext.Current.Request.RawUrl;
        }
        public override void WriteAttribute(string name, string value, bool encode)
        {
            if (_url != null && string.Compare(name, "action", true) == 0)
            {
                value = _url;
            }
            base.WriteAttribute(name, value, encode);
        }
    }

    internal class FormFixerHtmlTextWriter : System.Web.UI.HtmlTextWriter
    {
        private string _url;
        internal FormFixerHtmlTextWriter(TextWriter writer)
            : base(writer)
        {
            _url = HttpContext.Current.Request.RawUrl;
        }
        public override void WriteAttribute(string name, string value, bool encode)
        {
            if (_url != null && string.Compare(name, "action", true) == 0)
            {
                value = _url;
            }
            base.WriteAttribute(name, value, encode);
        }
    }
}


