using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Core;
using System.Web.UI.WebControls;
using System.Web;

namespace Ncuhome.Blog.Controls.Manage
{
    public class AddLog :SkinnedBlogWebControl
    {
        public AddLog()
        {
            SkinFileName = "AddLog.ascx";

            //llj098,20080904
            IsThemed = false;
        }
        
        private int LogId=0;

        private TextBox LogIdTex;
        private TextBox Title;
        private Button Add;
        private Button AddDraft;
        private Button Cansel;
        private TextBox Editor; 
        private string LogTitle;
        private String LogContext;
        private DropDownList LogCategory;
        private TextBox TextBox1;
        private TextBox TextBox2;       //隐藏控件，用来存放临时的logID
        private TextBox CreateTime;
        private CheckBox AllowPsd;
        private CheckBox IsEnReply;
        private CheckBox IsIndexShow;
        private TextBox KeyWords;

        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            KeyWords=(TextBox)Skin.FindControl("KeyWords");
            AllowPsd = (CheckBox)Skin.FindControl("AllowPsd");
            IsEnReply = (CheckBox)Skin.FindControl("IsEnReply");
            IsIndexShow = (CheckBox)Skin.FindControl("IsIndexShow");
            AllowPsd.Attributes.Add("onclick", "AllowPsd()");
            TextBox1 = (TextBox)Skin.FindControl("TextBox1");
            TextBox2 = (TextBox)Skin.FindControl("TextBox2");  //js把logId写入

            CreateTime = (TextBox)Skin.FindControl("CreateTime");
            if (!Page.IsPostBack)
            {
                CreateTime.Text = DateTime.Now.ToString();
            }

            LogIdTex = (TextBox)Skin.FindControl("LogId");//没有用到啊···
            Title = (TextBox)Skin.FindControl("title");
            Add = (Button)Skin.FindControl("Add");
            AddDraft = (Button)Skin.FindControl("AddDraft");
            Cansel = (Button)Skin.FindControl("Cansel");
            Editor = (TextBox)Skin.FindControl("txtContent");
            LogCategory = (DropDownList)Skin.FindControl("LogCategory");
            this.DataBind();
        }

        /// <summary>
        /// myself：将访问权限由public改为private
        /// </summary>
        private override void DataBind()
        {
            Add.Click += new EventHandler(Add_Click);
            AddDraft.Click += new EventHandler(AddDraft_Click);
            Cansel.Click += new EventHandler(Cansel_Click);
            LogCategory.DataBound += new EventHandler(LogCategory_DataBound);
            
            LogCategory.DataSource = BWeblog_Category.SelectByUID(blogContext.BlogUserId);
            LogCategory.DataTextField = "Cate_Name";
            LogCategory.DataValueField = "Cate_Id";
            LogCategory.DataBind();
            LogCategory.DataBound += new EventHandler(LogCategory_DataBound);
            base.DataBind();
        }

        private void LogCategory_DataBound(object sender, EventArgs e)
        {
            ListItem DefaultValue = new ListItem("随笔","1");
            LogCategory.Items.Add(DefaultValue);
            LogCategory.Items.FindByValue("1").Selected = true;
        }

        private void Cansel_Click(object sender, EventArgs e)
        {
            this.PageRedirct(false,"");
        }

        
        private void AddDraft_Click(object sender, EventArgs e)
        {
            AddDraft.Enabled = false;
            LogTitle = Title.Text;
            LogContext = Editor.Text;

            //myself：尽量不要使用try catch
            bool blHasLogID = int.TryParse(this.TextBox2.Text.Trim(), out LogId);
            if (!blHasLogID)
            {
                LogId = 0;
            }
            //try
            //{
            //    if (TextBox2.Text != "")
            //    {
            //        LogId = Convert.ToInt32(TextBox2.Text);
            //    }
            //}
            //catch { }

            Weblog_Log WL = new Weblog_Log();
            WL.Log_CateId = 0;  //草稿部分类
            WL.Log_CommentCount = 0;
            WL.Log_IsTop = false;
            WL.Log_IsVisible = true;
            WL.Log_ViewCount = 0;
            WL.Log_IP = Globals.IPAddress;
            WL.Log_IsDraft = true;
            WL.Log_LastModiTime = DateTime.Now;
            WL.Log_Title = LogTitle;
            WL.Log_Content = LogContext;
            WL.Log_UserId = blogContext.BlogUserId;
            WL.Log_CreateTime = Convert.ToDateTime( CreateTime.Text.Trim());
            WL.Log_PassWord = "";
            WL.Log_IsPasssword = false; //草稿不设置密码
            WL.Log_KeyWords = KeyWords.Text.Trim();
            if (LogId == 0)
            {
                BWeblog_log.Insert(WL);
            }
            else
            {
                WL.Log_Id = LogId;
                BWeblog_log.Update(WL);
            }
            PageRedirct(true, "操作成功,文章已经保存到草稿箱！");
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Add.Enabled = false;
            LogTitle = Title.Text;
            LogContext = Editor.Text;

            //myself：尽量不要使用try catch
            bool blHasLogID = int.TryParse(this.TextBox2.Text.Trim(), out LogId);
            if (!blHasLogID)
            {
                LogId = 0;
            }

            //try
            //{
            //    if(TextBox2.Text!="")
            //    LogId = Convert.ToInt32(TextBox2.Text);
            //}
            //catch { }

            Weblog_Log WL = new Weblog_Log();
            WL.Log_CateId = Convert.ToInt32(LogCategory.SelectedValue);
            WL.Log_CommentCount = 0;
            WL.Log_IsTop = false;
            WL.Log_IsVisible = true;
            WL.Log_ViewCount = 0;
            WL.Log_IP = Globals.IPAddress;
            WL.Log_IsDraft = false;
            WL.Log_LastModiTime = DateTime.Now;
            WL.Log_Title = LogTitle;
            WL.Log_Content = LogContext;
            WL.Log_UserId = blogContext.BlogUserId;
            WL.Log_CreateTime = Convert.ToDateTime(CreateTime.Text.Trim());
            WL.Log_IsEnRePly = IsEnReply.Checked;
            WL.Log_IsIndexShow = IsIndexShow.Checked;
            if (AllowPsd.Checked == true&&TextBox1.Text.Trim()!="")
            {
                WL.Log_PassWord = TextBox1.Text.Trim();
                WL.Log_IsPasssword = true;
            }
            else
            {
                WL.Log_PassWord = "";
                WL.Log_IsPasssword = false;
            }
            WL.Log_KeyWords = KeyWords.Text.Trim();
            int TxzID = Convert.ToInt32(BWeblog_User.GetByID(blogContext.BlogUserId).User_TxzId);
            int NewsUrlTypeID = -1;
            if (TxzID < 200000)
            {
                NewsUrlTypeID = 3;
            }
            else NewsUrlTypeID = 13;
            Ncuhome.Blog.Core.clubNewsService.NewsService clubNews = new Ncuhome.Blog.Core.clubNewsService.NewsService();
            if (LogId == 0)//添加
            {
                BWeblog_log.Insert(WL);
                try   //peng 20081109  webservice 上要有异常处理
                {
                    clubNews.AddNews(TxzID, -1, WL.Log_Title, WL.Log_Content, NewsUrlTypeID, WL.Log_Id);
                }
                catch
                { }
            }
            else//更新
            {
                WL.Log_Id = LogId;
                BWeblog_log.Update(WL);
                try   //peng 20081109
                {
                    clubNews.AddNews(TxzID, -1, WL.Log_Title, WL.Log_Content, NewsUrlTypeID, WL.Log_Id);
                }
                catch
                { }
            }
            BWeblog_log.SetLogCountByUID(blogContext.BlogUserId);

            DateTime PublishTime = Convert.ToDateTime(CreateTime.Text.Trim());
            if (PublishTime < DateTime.Now)
                PageRedirct(true, "操作成功,文章已经发布！");
            else
                PageRedirct(true, "文章将于" + PublishTime.ToString() + "发布");
          }

        private void PageRedirct(bool Succ,string Str)//成功
        {
            if (IsThemed)
            {
                if (Succ)
                {
                    HttpContext.Current.Response.Write("<script>alert('"+Str+"！');window.location='/" + blogContext.Owner.User_DomainName +"/Manage/logs.aspx';</script>");
                    HttpContext.Current.Response.End();
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.location='/" + blogContext.Owner.User_DomainName + "/Manage/logs.aspx';</script>");
                    HttpContext.Current.Response.End();
                }
            }
            else
            {
                if (Succ)
                {
                    HttpContext.Current.Response.Write("<script>alert('" + Str + "！');window.location='/" + blogContext.Owner.User_DomainName + "/Manage/logs.aspx';</script>");
                    HttpContext.Current.Response.End();
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.location='/" + blogContext.Owner.User_DomainName + "/Manage/logs.aspx';</script>");
                    HttpContext.Current.Response.End();
                }
            }
        }
    }
}
