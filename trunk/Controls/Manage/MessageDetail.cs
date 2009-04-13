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
    public class MessageDetail :SkinnedBlogWebControl
    {
        public Repeater Repeater1;


        public TextBox MsgReceiver;
        public Button Send;
        public TextBox MsgTitle;
        public TextBox MsgContent;
        public MessageDetail()
        {
            SkinFileName = "MessageDetail.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            
            Repeater1 = (Repeater)Skin.FindControl("Repeater1");
            MsgReceiver = (TextBox)Skin.FindControl("MsgReceiver");

            Send = (Button)Skin.FindControl("Send");
            MsgTitle = (TextBox)Skin.FindControl("MsgTitle");
            MsgContent = (TextBox)Skin.FindControl("MsgContent");
            Send.Click += new EventHandler(Send_Click);
            DataBind();
        }

        void Send_Click(object sender, EventArgs e)
        {
            int ReceiceTxzId = Convert.ToInt32(MsgReceiver.Text);
            string Title = HttpContext.Current.Server.HtmlEncode(MsgTitle.Text);
            string Content = HttpContext.Current.Server.HtmlEncode( MsgContent.Text);
            HttpContext.Current.Session["Id"] = null;
            BMail.SendMail(ReceiceTxzId, Title, Content);
            HttpContext.Current.Response.Write("<script>alert('发送成功！');top.window.location.reload();</script>");
        }
        public override void DataBind()
        {
            if (blogContext.Action == "SendBox")
            {
                List<Ncuhome.Blog.Core.MailServices.SendeBox> l = new List<Ncuhome.Blog.Core.MailServices.SendeBox>();
                foreach (SendeBox s in BMail.GetSendeBox(1,1000))
                {
                    if (s.MailAttri_ID == blogContext.ID)
                        l.Add(s);
                }
                Repeater1.DataSource = l;
                MsgReceiver.Text = l.First().Sender.ToString();
                MsgTitle.Text ="re:"+ l.First().Title;
                BMail.UpdateNewMaid(Convert.ToInt32( l.First().MailAttri_ID));
            }
            else
            {

                List<Ncuhome.Blog.Core.MailServices.InBox> l = new List<Ncuhome.Blog.Core.MailServices.InBox>();
                foreach (InBox s in BMail.GetInbox(1,1000))
                {
                    if (s.MailAttri_ID ==blogContext.ID)
                        l.Add(s);
                }
                Repeater1.DataSource =l;
                MsgReceiver.Text = l.First().Sender.ToString();
                MsgTitle.Text = "re:" + l.First().Title;
                BMail.UpdateNewMaid(Convert.ToInt32( l.First().MailAttri_ID));
            }
            Repeater1.DataBind();
            base.DataBind();
        }
    }
}
