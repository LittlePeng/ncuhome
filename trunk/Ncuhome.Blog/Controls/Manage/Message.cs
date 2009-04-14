using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core.MailServices;
using System.Collections.Generic;

namespace Ncuhome.Blog.Controls.Manage
{
    public  class Message :SkinnedBlogWebControl
    {
        public Repeater Repeater1;
        public Button Button1;
        public CheckBox CheckBox1; 
        public Message()
        {
            SkinFileName = "Message.ascx";
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            Repeater1 = (Repeater)Skin.FindControl("Repeater1");
            Button1 = (Button)Skin.FindControl("Button1");
            Button1.Click += new EventHandler(Button1_Click);
            DataBind();
        }
        public override void DataBind()
        {
            if (blogContext.ID != -1)
            {
                BMail.DeleteMail(blogContext.ID);
            }
            if (blogContext.Action == "SendBox")
            {
                List<Mailbox> send = new List<Mailbox>();
                foreach (SendeBox i in  BMail.GetSendeBox(1, 1000))
                {
                    Mailbox s = new Mailbox();
                    s.ReceiverID = i.ReceiverID;
                    s.Content = i.Content;
                    s.MailAttri_ID = i.MailAttri_ID;
                    s.Sender = i.Sender;
                    s.Time = i.Time;
                    s.Title = i.Title;
                    s.IsNew = false;
                    send.Add(s);
                }
                Repeater1.DataSource = send;
                Repeater1.DataBind();
            }
            else
            {
                InBox[] inbox=BMail.GetInbox(1, 1000);
                List<Mailbox> send = new List<Mailbox>();
                foreach (InBox i in inbox)
                {
                    Mailbox s = new Mailbox();
                    s.ReceiverID = 0;
                    s.Content = i.Content;
                    s.MailAttri_ID = i.MailAttri_ID;
                    s.Sender = i.Sender;
                    s.Time = i.Time;
                    s.Title = i.Title;
                    s.IsNew = i.IsNew;
                    send.Add(s);
                }
                Repeater1.DataSource = send;
                Repeater1.ItemDataBound += new RepeaterItemEventHandler(Repeater1_ItemDataBound);
                Repeater1.DataBind();
            }
            base.DataBind();
        }

        void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            
        }

        

        void Button1_Click(object sender, EventArgs e)
        {
            //foreach (var temp in Repeater1.Items)
            //{
            //    CheckBox1 = 
            //}
        }
    }
    public class Mailbox
    { 
        public long? ReceiverID {get;set;}
        public string Content {get;set;}
        public long? MailAttri_ID {get;set;}
        public long? Sender {get;set;}
        public DateTime? Time {get;set;}
        public string  Title {get;set;}
        public bool? IsNew {get;set;}
    }
}
