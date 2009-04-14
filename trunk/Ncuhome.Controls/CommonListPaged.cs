using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ncuhome.Blog.Controls
{
    public class RepeaterPaged : System.Web.UI.WebControls.Repeater
    {
        public RepeaterPaged()
        {

        }
        private string _PageLocation;
        /// <summary>
        /// 分页码的显示地方
        /// Top 顶端
        /// End 底端
        /// TopandEnd 上面下面都有
        /// </summary>
        [DefaultValue("End")]
        public string PageLocation
        {
            get { return _PageLocation; }
            set { this._PageLocation = value; }
        }
        private string _UrlFormat;
        /// <summary>
        /// 地址 example"more.aspx?id=1&"
        /// </summary>
        public string UrlFormat
        {
            get { return _UrlFormat; }
            set { _UrlFormat = value; }
        }
        private long _Count;
        /// <summary>
        /// 总数
        /// </summary>
        public long Count
        {
            get { return _Count; }
            set { _Count = value; }
        }
        private long _Length;
        /// <summary>
        /// 每页显示条数
        /// </summary>
        public long Length
        {
            get { return _Length; }
            set { _Length = value; }
        }


        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            int PageIndex = 1;
            if (string.IsNullOrEmpty(Context.Request.QueryString["PageIndex"]))
            {
                PageIndex = 1;
            }
            else
            {
                try
                {
                    PageIndex = Convert.ToInt32(Context.Request.QueryString["PageIndex"].ToString());
                }
                catch
                {
                    PageIndex = 1;
                }
            }
            int PageCount = 1;
            if (this.Count % this.Length == 0L)
                PageCount = Convert.ToInt32(this.Count / this.Length);
            else
                PageCount = Convert.ToInt32(this.Count / this.Length) + 1;


            string PageStr = GetPaged(this.UrlFormat, PageIndex, PageCount);
            if (this.PageLocation == "Top")
            {
                writer.Write(PageStr);
                base.Render(writer);
            }
            else if (this.PageLocation == "End")
            {
                base.Render(writer);
                writer.Write(PageStr);
            }
            else if (this.PageLocation == "TopandEnd")
            {
                writer.Write(PageStr);
                base.Render(writer);
                writer.Write(PageStr);
            }
            else
            {
                base.Render(writer);
                writer.Write(PageStr);
            }

        }

        private static string GetPaged(string _UrlFormat, int _PageIndex, int _PageCount)
        {

            int pageCount = _PageCount;//总的页数
            int page = _PageIndex;//当前页号
            string UrlFormat = _UrlFormat + "PageIndex=";//url地址

            StringBuilder HtmlString = new StringBuilder();
            #region 分页功能

            HtmlString.Append("");//添加css连接
            if (pageCount > 0)
            {
                HtmlString.Append("<div class=\"page\">");
                HtmlString.Append("<ul>");
                HtmlString.Append("<li class=\"long\"><a href=" + UrlFormat + "1>首页</a></li>");
                if (page > 1)
                {
                    HtmlString.Append("<li  class=\"long\"><a href='" + UrlFormat + "" + Convert.ToString(page - 1) + "'>上一页</a></li>");
                }
                int i = 1;
                if (pageCount <= 10)
                {
                    for (; i <= pageCount; i++)
                    {
                        if (i == page)
                        {
                            HtmlString.Append("<li><font color=red><strong>" + i.ToString() + "</strong></font></li>");
                        }
                        else
                        {
                            HtmlString.Append("<li><a href=" + UrlFormat + "" + i.ToString() + ">" + i.ToString() + "</a></li>");
                        }
                    }
                }
                else
                {
                    if (page <= 3)
                    {
                        for (; i <= 5; i++)
                        {
                            if (i == page)
                            {
                                HtmlString.Append("<li><font color=red><strong>" + i.ToString() + "</strong></font></li>");
                            }
                            else
                            {
                                HtmlString.Append("<li><a href=" + UrlFormat + "" + i.ToString() + ">" + i.ToString() + "</a></li>");
                            }
                        }
                        HtmlString.Append("<li>...</li>");
                        for (i = pageCount - 2; i <= pageCount; i++)
                        {
                            if (i == page)
                            {
                                HtmlString.Append("<li><font color=red><strong>" + i.ToString() + "</strong></font></li>");
                            }
                            else
                            {
                                HtmlString.Append("<li><a href=" + UrlFormat + "" + i.ToString() + ">" + i.ToString() + "</a></li>");
                            }
                        }
                    }
                    else if (page >= pageCount - 2)
                    {
                        for (; i <= 3; i++)
                        {
                            if (i == page)
                            {
                                HtmlString.Append("<li><font color=red><strong>" + i.ToString() + "</strong></font></li>");
                            }
                            else
                            {
                                HtmlString.Append("<li><a href=" + UrlFormat + "" + i.ToString() + ">" + i.ToString() + "</a></li>");
                            }
                        }
                        HtmlString.Append("<li>...</li>");
                        for (i = pageCount - 4; i <= pageCount; i++)
                        {
                            if (i == page)
                            {
                                HtmlString.Append("<li><font color=red><strong>" + i.ToString() + "</strong></font></li>");
                            }
                            else
                            {
                                HtmlString.Append("<li><a href=" + UrlFormat + "" + i.ToString() + ">" + i.ToString() + "</a></li>");
                            }
                        }
                    }
                    else if (page >= 4 && page <= 5)
                    {
                        for (; i <= page; i++)
                        {
                            HtmlString.Append("<li><a href=" + UrlFormat + "" + i.ToString() + ">" + i.ToString() + "</a></li>");
                        }
                        HtmlString.Append("<li><font color=red><strong>" + i.ToString() + "</strong></font></li>");
                        for (i = page + 1; i < page + 3; i++)
                        {
                            HtmlString.Append("<li><a href=" + UrlFormat + "" + i.ToString() + ">" + i.ToString() + "</a></li>");
                        }
                        HtmlString.Append("<li>...</li>");
                        for (i = pageCount - 2; i <= pageCount; i++)
                        {
                            HtmlString.Append("<li><a href=" + UrlFormat + "" + i.ToString() + ">" + i.ToString() + "</a></li>");
                        }
                    }
                    else if (page >= pageCount - 4 && page <= pageCount - 3)
                    {
                        for (; i <= 3; i++)
                        {
                            HtmlString.Append("<li><a href=" + UrlFormat + "" + i.ToString() + ">" + i.ToString() + "</a></li>");
                        }
                        HtmlString.Append("<li>...</li>");
                        for (i = page - 2; i < page; i++)
                        {
                            HtmlString.Append("<li><a href=" + UrlFormat + "" + i.ToString() + ">" + i.ToString() + "</a></li>");
                        }
                        HtmlString.Append("<li><font color=red><strong>" + page.ToString() + "</strong></font></li>");
                        for (i = page + 1; i <= pageCount; i++)
                        {
                            HtmlString.Append("<li><a href=" + UrlFormat + "" + i.ToString() + ">" + i.ToString() + "</a></li>");
                        }
                    }
                    else
                    {
                        for (; i <= 3; i++)
                        {
                            HtmlString.Append("<li><a href=" + UrlFormat + "" + i.ToString() + ">" + i.ToString() + "</a></li>");
                        }
                        HtmlString.Append("<li>...</li>");
                        for (i = page - 2; i < page; i++)
                        {
                            HtmlString.Append("<li><a href=" + UrlFormat + "" + i.ToString() + ">" + i.ToString() + "</a></li>");
                        }
                        HtmlString.Append("<li><font color=red><strong>" + page.ToString() + "</strong></font></li>");
                        for (i = page + 1; i < page + 3; i++)
                        {
                            HtmlString.Append("<li><a href=" + UrlFormat + "" + i.ToString() + ">" + i.ToString() + "</a></li>");
                        }
                        HtmlString.Append("<li>...</li>");
                        for (i = pageCount - 2; i <= pageCount; i++)
                        {
                            HtmlString.Append("<li><a href=" + UrlFormat + "" + i.ToString() + ">" + i.ToString() + "</a></li>");
                        }
                    }
                }
                if (page < pageCount)
                {
                    HtmlString.Append("<li  class=\"long\"><a href=" + UrlFormat + "" + Convert.ToString(page + 1) + ">下一页</a></li>");
                }
                HtmlString.Append("<li  class=\"long\"><a href=" + UrlFormat + "" + pageCount.ToString() + ">末页</a></li>");
                HtmlString.Append("</ul>");
                HtmlString.Append("</div>");
            }
            #endregion
            return HtmlString.ToString();
        }

    }
}