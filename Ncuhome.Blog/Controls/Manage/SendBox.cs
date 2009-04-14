using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;
using Ncuhome.Blog.Core.MailServices;
using System.Web;

namespace Ncuhome.Blog.Controls.Manage
{
    public class SendBox:SkinnedBlogWebControl
    {

        public TextBox MsgReceiver;
        public Button Send;
        public TextBox MsgTitle;
        public TextBox MsgContent;
        public Literal Literal1;

        public SendBox()
        {
            SkinFileName = "SendBox.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            MsgReceiver = (TextBox)Skin.FindControl("MsgReceiver");

            Send = (Button)Skin.FindControl("Send");
            MsgTitle = (TextBox)Skin.FindControl("MsgTitle");
            MsgContent = (TextBox)Skin.FindControl("MsgContent");
            Literal1 = (Literal)Skin.FindControl("Literal1");
            if (blogContext.ID != -1)
                MsgReceiver.Text = BWeblog_User.GetByFIID(blogContext.ID).User_NickName;
            Send.Click += new EventHandler(Send_Click);
            DataBind();
        }
        public override void DataBind()
        {
            base.DataBind();
        }
        void Send_Click(object sender, EventArgs e)
        {
            int ReceiceTxzId =BWeblog_User.GetByNickName( MsgReceiver.Text.Trim()).User_TxzId??0;
            if (ReceiceTxzId == 0)
            {
                Literal1.Text = "<script>alert('该用户不存在！！')</script>";
                return;
            }
            string Title = HttpContext.Current.Server.HtmlEncode(MsgTitle.Text);
            string Content = HttpContext.Current.Server.HtmlEncode(MsgContent.Text);
            BMail.SendMail(ReceiceTxzId, Title, Content);
            Context.Response.Write("<script>alert('发送成功！！');window.location='/" + blogContext.Owner.User_DomainName + "/Manage/message.aspx';</script>");
            Context.Response.End();
        }
    }
}
