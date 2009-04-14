using System;
using Ncuhome.Blog.Core;
using System.ComponentModel;
using System.Web.UI.HtmlControls;

namespace Ncuhome.Blog.Controls
{
   public class LogList : SkinnedBlogWebControl
    {
        private RepeaterPaged repeater1;
        private string LogTitle;
        private int LogCateId;
        public LogList()
        {
            IsThemed = true;
            SkinFileName = "LogList.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            Page.Title = blogContext.Owner.User_NickName + "- 家园博客";
            HtmlMeta KeyWords = new HtmlMeta();
            KeyWords.Name = "keywords";
            KeyWords.Content = blogContext.Owner.User_NickName +Globals.MateKeyWords;
            Page.Header.Controls.Add(KeyWords);
            HtmlMeta desc = new HtmlMeta();
            desc.Name = "description";
            desc.Content = Globals.MateKeyWords;
            Page.Header.Controls.Add(desc);


            repeater1 = (RepeaterPaged)Skin.FindControl("RepeaterPaged1");
            DataBind();
        }
        public override void DataBind()
        {
            repeater1.Length = 8;
            //if (!NotinIndex)
            //{
            //    repeater1.Count = 8;
            //    repeater1.Length = 8;
            //    repeater1.DataSource = BWeblog_log.GetByBlogUIDPaged(blogContext.BlogUserId, 1, 8);
            //}
            //else
            //{
            //根据关键字来搜索log
            if (Context.Request["logTitle"] != null)
            {
                LogTitle = Convert.ToString(Context.Request["logTitle"]);
                repeater1.UrlFormat = "/Log.aspx?mfiid=" + blogContext.MFiiD.ToString()+"&logTitle="+ LogTitle+ "&";
                repeater1.Count = BView_WeblogLogCategory.GetCountByLogTitleAndUID(LogTitle, blogContext.Owner.User_Id);
                if (blogContext.PageIndex != -1)
                {
                    repeater1.DataSource = BView_WeblogLogCategory.GetByLogTitleAndUIDPaged(LogTitle, blogContext.Owner.User_Id, blogContext.PageIndex, 8);
                }
                else
                {
                    repeater1.DataSource = BView_WeblogLogCategory.GetByLogTitleAndUIDPaged(LogTitle, blogContext.Owner.User_Id, 1, 8);
                }
            }
                //根据文章种类来搜索log
            else if (Context.Request["LogCateId"] != null)
            {
                LogCateId = Convert.ToInt32(Context.Request["LogCateId"]);
                repeater1.UrlFormat = "/log.aspx?mfiid=" + blogContext.MFiiD.ToString() + "&LogCateId=" + LogCateId + "&";
                repeater1.Count = BView_WeblogLogCategory.GetCountByLogCateIDAndUID(LogCateId, blogContext.Owner.User_Id);
                if (blogContext.PageIndex!=-1)
                {
                    repeater1.DataSource = BView_WeblogLogCategory.GetByLogCateIDAndUIDPaged(LogCateId, blogContext.Owner.User_Id, blogContext.PageIndex, 8);
                }
                else
                {
                    repeater1.DataSource = BView_WeblogLogCategory.GetByLogCateIDAndUIDPaged(LogCateId, blogContext.Owner.User_Id, 1, 8);
                }
            }
            else
            {
                //如果没有参数
                if (blogContext.Year != -1 && blogContext.Month != -1)
                {
                    if (blogContext.Day != -1)
                    {
                        repeater1.Count = BView_WeblogLogCategory.GetCountYearAndMonthAndDay(blogContext.BlogUserId, blogContext.Year, blogContext.Month, blogContext.Day);
                        repeater1.UrlFormat = "/Log.aspx?mfiid=" + blogContext.MFiiD.ToString() + "&Month=" + blogContext.Month.ToString() + "&year=" + blogContext.Year.ToString() + "&day=" + blogContext.Day.ToString() + "&";
                        if (blogContext.PageIndex != -1)
                        {
                            repeater1.DataSource = BView_WeblogLogCategory.GetByBlogYearAndMonthAndDayPaged(blogContext.BlogUserId, blogContext.Year, blogContext.Month, blogContext.Day, blogContext.PageIndex, 8);
                        }
                        else
                        {
                            repeater1.DataSource = BView_WeblogLogCategory.GetByBlogYearAndMonthAndDayPaged(blogContext.BlogUserId, blogContext.Year, blogContext.Month, blogContext.Day, 1, 8);
                        }
                    }
                    else
                    {
                        repeater1.Count = BView_WeblogLogCategory.GetCountYearAndMonth(blogContext.BlogUserId, blogContext.Year, blogContext.Month);
                        repeater1.UrlFormat = "/Log.aspx?mfiid=" + blogContext.MFiiD.ToString() + "&Month=" + blogContext.Month.ToString() + "&year=" + blogContext.Year.ToString() + "&";
                        if (blogContext.PageIndex != -1)
                        {
                            repeater1.DataSource = BView_WeblogLogCategory.GetByBlogYearAndMonthPaged(blogContext.BlogUserId, blogContext.Year, blogContext.Month, blogContext.PageIndex, 8);
                        }
                        else
                        {
                            repeater1.DataSource = BView_WeblogLogCategory.GetByBlogYearAndMonthPaged(blogContext.BlogUserId, blogContext.Year, blogContext.Month, 1, 8);
                        }
                    }
                }
                else
                {
                    repeater1.UrlFormat = "/Log.aspx?mfiid=" + blogContext.MFiiD.ToString() + "&";
                    repeater1.Count = BView_WeblogLogCategory.GetBLogCountByUID(blogContext.BlogUserId);
                    if (blogContext.PageIndex != -1)
                    {
                        repeater1.DataSource = BView_WeblogLogCategory.GetByBlogUIDPaged(blogContext.BlogUserId, blogContext.PageIndex, 8);
                    }
                    else
                    {
                        repeater1.DataSource = BView_WeblogLogCategory.GetByBlogUIDPaged(blogContext.BlogUserId, 1, 8);
                    }

                }
            }
            repeater1.DataBind();
            base.DataBind();
            //}
        }
   [DefaultValue(false)]
        public bool NotinIndex
        {
            get;
            set;
        }
       [DefaultValue(false)]
           public bool IsPaged
           {
               get;
               set;
           }
    }
}
