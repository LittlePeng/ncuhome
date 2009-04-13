using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Collections.Generic;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Controls.uploadservice;

namespace Ncuhome.Blog.Controls.Manage
{
    public class UserInfo:SkinnedBlogWebControl
    {
        private string headName=string.Empty;

        private Button Save;
        private Button BeginUpLoad;
        private TextBox UserDomainName;
        private TextBox UserNickName;
        private TextBox UserQQ;
        private TextBox UserMSN;
        private TextBox UserHomePage;
        private TextBox UserInterest;
        private TextBox UserBook;
        private TextBox UserMusic;
        private TextBox UserMovie;
        private TextBox UserGame;
        private FileUpload UpLoadUserHead;
        private Image UserHead;
        private Literal Literal1;

        public UserInfo()
        {
            SkinFileName = "UserInfo.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            Save = (Button)Skin.FindControl("Save");
            BeginUpLoad = (Button)Skin.FindControl("BeginUpLoad");
            UserDomainName = (TextBox)Skin.FindControl("UserDomainName");
            UserNickName = (TextBox)Skin.FindControl("UserNickName");
            UserQQ = (TextBox)Skin.FindControl("UserQQ");
            UserMSN = (TextBox)Skin.FindControl("UserMSN");
            UserHomePage = (TextBox)Skin.FindControl("UserHomePage");
            UserInterest = (TextBox)Skin.FindControl("UserInterest");
            UserBook = (TextBox)Skin.FindControl("UserBook");
            UserMusic = (TextBox)Skin.FindControl("UserMusic");
            UserMovie = (TextBox)Skin.FindControl("UserMovie");
            UserGame = (TextBox)Skin.FindControl("UserGame");
            UpLoadUserHead = (FileUpload)Skin.FindControl("UpLoadUserHead");
            UserHead = (Image)Skin.FindControl("UserHead");
            Literal1 = (Literal)Skin.FindControl("Literal1");
            
            DataBind();
        }
        public override void DataBind()
        {
            if (blogContext.Owner.User_PortraitUrl == null || blogContext.Owner.User_PortraitUrl .Length== 0)
            {
                UserHead.ImageUrl = "/images/defaulthead.gif";
            }
            else
            {
                UserHead.ImageUrl = "http://resource.ncuhome.cn/Blog/ThumbnailImage/UserHead/" + blogContext.Owner.User_PortraitUrl+"?v="+DateTime.Now.ToString();
            }
            if (!Page.IsPostBack)
            {
                UserNickName.Text = blogContext.Owner.User_NickName;
                UserQQ.Text = blogContext.Owner.User_QQ;
                UserMSN.Text = blogContext.Owner.User_MSN;
                UserHomePage.Text = blogContext.Owner.User_HomePage;
                UserInterest.Text = blogContext.Owner.User_Interest;
                UserBook.Text = blogContext.Owner.User_Book;
                UserMusic.Text = blogContext.Owner.User_Music;
                UserMovie.Text = blogContext.Owner.User_Movie;
                UserGame.Text = blogContext.Owner.User_Game;
            }
            Save.Click += new EventHandler(Save_Click);
            BeginUpLoad.Click += new EventHandler(BeginUpLoad_Click);
            base.DataBind();
        }
         

        void BeginUpLoad_Click(object sender, EventArgs e)
        {
            Weblog_User WU = new Weblog_User();
            uploadservice.Upload up = new Upload();
            if (UpLoadUserHead.HasFile)
            {
                headName = BlogContext.Current.Owner.User_DomainName + Path.GetExtension(UpLoadUserHead.PostedFile.FileName);
               
                WU = blogContext.Owner;
                WU.User_PortraitUrl = headName;

                if (BWeblog_User.Update(WU))
                {
                    up.UploadFileWithSmall(UpLoadUserHead.FileBytes, "Blog/", "UserHead/", headName, 100, 100);
                    Context.Response.Write("<script>alert('上传成功！');window.location='/" + blogContext.Owner.User_DomainName + "/Manage/userinfor.aspx';</script>");
                    Context.Response.End();
                  //  UserHead.ImageUrl = "http://resource.ncuhome.cn/Blog/ThumbnailImage/UserHead/" + headName;
                 }
                else
                {
                    Literal1.Text = "<font color=red>上传失败!</font>";
                }
            }
            else
            {
                Literal1.Text = "<font color=red>请确认头像路径正确!</font>";
            }
            
        }

        void Save_Click(object sender, EventArgs e)
        {
            bool IsUpdateNickName = false;
            Weblog_User WU = new Weblog_User();
            WU=blogContext.Owner;
            string NickName = UserNickName.Text.Trim();

            if (NickName != blogContext.Owner.User_NickName)
            {
                if (!BWeblog_User.CheckNickName(NickName))
                {
                    IsUpdateNickName = true;
                    WU.User_NickName = Globals.HtmlEncode(NickName);
                }

            }
            else
            {
                IsUpdateNickName = true;
            }
            WU.User_QQ=Globals.HtmlEncode( UserQQ.Text);
            WU.User_MSN = Globals.HtmlEncode( UserMSN.Text);
            WU.User_HomePage = Globals.HtmlEncode( UserHomePage.Text);
            WU.User_Interest = Globals.HtmlEncode( UserInterest.Text);
            WU.User_Book =Globals.HtmlEncode( UserBook.Text);
            WU.User_Music =Globals.HtmlEncode( UserMusic.Text);
            WU.User_Movie =Globals.HtmlEncode( UserMovie.Text);
            WU.User_Game = Globals.HtmlEncode( UserGame.Text);
            if (BWeblog_User.Update(WU))
            {
                if(IsUpdateNickName)
                Context.Response.Write("<script>alert('修改成功！');window.location='/" + blogContext.Owner.User_DomainName + "/Manage/userinfor.aspx';</script>");
                else
                    Context.Response.Write("<script>alert('昵称已经被使用，换个其他的试一下！');window.location='/" + blogContext.Owner.User_DomainName + "/Manage/userinfor.aspx';</script>");
                Context.Response.End();
            }
            else
            {
                Context.Response.Write("<script>alert('修改失败！');window.location='/" + blogContext.Owner.User_DomainName + "/Manage/userinfor.aspx'</script>");
                Context.Response.End();
            }
            //throw new NotImplementedException();
        }
    }
}
