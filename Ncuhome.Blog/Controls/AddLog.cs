using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Core;
using System.Web.UI.WebControls;
using System.Web;

namespace Ncuhome.Blog.Controls
{
    public class AddLog :SkinnedBlogWebControl
    {
        public AddLog()
        {
            //if (!blogContext.IsManager)
            //    Context.Response.End();
            SkinFileName = "AddLog.ascx";
            IsThemed = true;
        }
       
        private TextBox LogIdTex;
        private TextBox Title;
        private TextBox CateName;
        private Button AddCategory;
        private Button Add;
        private Button AddDraft;
        private Button Cansel;
        private LionSky.WebControls.WebHtmlEditor Editor;
        private int LogId=0;
        private string LogTitle;
        private String LogContext;
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            LogIdTex = (TextBox)Skin.FindControl("LogId");
            Title = (TextBox)Skin.FindControl("title");
            CateName = (TextBox)Skin.FindControl("Cate_Name");
            Add = (Button)Skin.FindControl("Add");
            AddDraft = (Button)Skin.FindControl("AddDraft");
            Cansel = (Button)Skin.FindControl("Cansel");
            AddCategory = (Button)Skin.FindControl("AddCategory");
            Editor = (LionSky.WebControls.WebHtmlEditor)Skin.FindControl("WebHtmlEditor1");

            if(blogContext.Action!=null&& blogContext.Action.ToLower()=="edit")
            if ((!Page.IsPostBack)&&(blogContext.LogId!=-1))
            {
                Add.Text = "发表修改";
                CDES1 c=new CDES1();
                LogIdTex.Text = c.Encrypt1(blogContext.LogId.ToString());  //加密以免有人修改
                Weblog_Log l = BWeblog_log.GetWithDraftByID(blogContext.LogId);
                Title.Text = l.Log_Title;
                Editor.Html = l.Log_Content;
            }
            DataBind();
        }
        public override void DataBind()
        {
            Add.Click += new EventHandler(Add_Click);
            AddDraft.Click += new EventHandler(AddDraft_Click);
            Cansel.Click += new EventHandler(Cansel_Click);
            AddCategory.Click += new EventHandler(AddCategory_Click);
            base.DataBind();
        }

        void AddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (CateName.Text.Trim() != "")
                {
                    Weblog_Category WC = new Weblog_Category();
                    WC.Cate_CreateTime = DateTime.Now;
                    WC.Cate_Intro = CateName.Text.Trim();
                    WC.Cate_Name = CateName.Text.Trim();
                    WC.Cate_UserId = blogContext.BlogUserId;
                    BWeblog_Category.Insert(WC);
                    CateName.Text = "";
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            //throw new NotImplementedException();
        }

        void Cansel_Click(object sender, EventArgs e)
        {
            PageRedirct(false);
        }

        void AddDraft_Click(object sender, EventArgs e)
        {
            LogTitle = Title.Text;
            LogContext = Editor.Html;

            Weblog_Log WL = new Weblog_Log();
            WL.Log_CommentCount = 0;
            WL.Log_IsTop = false;
            WL.Log_IsVisible = true;
            WL.Log_ViewCount = 0;
            WL.Log_IP = Globals.IPAddress;
            WL.Log_IsDraft = true;
            WL.Log_LastModiTime = DateTime.Now;
            WL.Log_Title = LogTitle;
            WL.Log_Content = LogContext;
            WL.Log_UserId = blogContext.User.BlogUserID;
            WL.Log_CreateTime = DateTime.Now;
            BWeblog_log.Insert(WL);
        }

        void Add_Click(object sender, EventArgs e)
        {
            if (LogIdTex.Text != "")
            {
                CDES1 c = new CDES1();
                LogId = Convert.ToInt32(c.Decrypt1(LogIdTex.Text));
            }


      
            LogTitle = Title.Text;
            LogContext = Editor.Html;
           
            if (LogId == 0)//添加
            {
                Weblog_Log WL = new Weblog_Log();
                WL.Log_CommentCount = 0;
                WL.Log_IsTop = false;
                WL.Log_IsVisible = true;
                WL.Log_ViewCount = 0;
                WL.Log_IP = Globals.IPAddress;
                WL.Log_IsDraft = false;
                WL.Log_CreateTime = DateTime.Now;
                WL.Log_LastModiTime = DateTime.Now;
                WL.Log_Title = LogTitle;
                WL.Log_Content = LogContext;
                WL.Log_UserId = blogContext.User.BlogUserID;
                BWeblog_log.Insert(WL);
                PageRedirct(true);
            
            }
            else   //修改
            {
                Weblog_Log WL = new Weblog_Log();
                WL.Log_IsDraft = false;
                WL.Log_Id = LogId;
                WL.Log_LastModiTime = DateTime.Now;
                WL.Log_Title = LogTitle;
                WL.Log_Content = LogContext;
                BWeblog_log.Update(WL);
                PageRedirct(true);
              }
        }
        private void PageRedirct(bool Succ)//成功
        {
            if (IsThemed)
            {
                if (Succ)
                {
                    HttpContext.Current.Response.Write("<script>alert('操作成功！');window.location='log.aspx?mfiid="+blogContext.MFiiD+"';</script>");
                    HttpContext.Current.Response.End();
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.location='log.aspx?mfiid=" + blogContext.MFiiD + "';</script>");
                    HttpContext.Current.Response.End();
                }
            }
            else
            {
                if (Succ)
                {
                    HttpContext.Current.Response.Write("<script>alert('操作成功！');window.location='logs.aspx?mfiid=" + blogContext.MFiiD + "';</script>");
                    HttpContext.Current.Response.End();
                }
                else
                {
                    HttpContext.Current.Response.Write("<script>window.location='logs.aspx?mfiid=" + blogContext.MFiiD + "';</script>");
                    HttpContext.Current.Response.End();
                }
            }
        }
    }
}
