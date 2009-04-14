//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Web.UI.WebControls;
//using Ncuhome.Blog.Core;
//using Ncuhome.Blog.Entity;

//namespace Ncuhome.Blog.Controls.Manage
//{
//    public class Recommend:SkinnedBlogWebControl
//    {
//        private TextBox Edition;
//        private TextBox Title;
//        private TextBox Intro;
//        private TextBox Reco1;
//        private TextBox Reco2;
//        private TextBox Reco3;
//        private TextBox Reco4;
//        private TextBox Reco5;
//        private TextBox Reco6;
//        private TextBox Reco7;
        
//        private Button Sub;
//        public Recommend()
//        {
//            SkinFilename = "Recommend.ascx";
//        }
//        private TextBox[] Recos; 
//        protected override void InitializeSkin(System.Web.UI.Control Skin)
//        {
//            Edition = (TextBox)Skin.FindControl("TextBox1");
//            Title = (TextBox)Skin.FindControl("TextBox10");
//            Intro = (TextBox)Skin.FindControl("TextBox2");
//            Reco1 = (TextBox)Skin.FindControl("TextBox3");
//            Reco2 = (TextBox)Skin.FindControl("TextBox4");
//            Reco3 = (TextBox)Skin.FindControl("TextBox5");
//            Reco4 = (TextBox)Skin.FindControl("TextBox6");
//            Reco5 = (TextBox)Skin.FindControl("TextBox7");
//            Reco6 = (TextBox)Skin.FindControl("TextBox8");
//            Reco7 = (TextBox)Skin.FindControl("TextBox9");
//            Sub = (Button)Skin.FindControl("Button1");
//            Recos = new TextBox[7]{ Reco1, Reco2, Reco3, Reco4, Reco5, Reco6, Reco7};
//            Sub.Click += new EventHandler(Sub_Click);
//        }

//        void Sub_Click(object sender, EventArgs e)
//        {      
//            Weblog_Recommend WR=new Weblog_Recommend();
//            Weblog_RecommendTheme WRT = new Weblog_RecommendTheme();
//            Int32 i;
            
//            for (i = 0; i <7; i++)
//            {
                
//                WR.Recommend_LogId =Convert.ToInt32( Recos[i].Text);
//                WR.Recommend_Edition = Convert.ToInt32(Edition.Text);
//                WR.Recommend_CreateTime = DateTime.Now;
//                BWeblog_Recommend.Insert(WR);
//            }
//            WRT.Reco_Edition = Convert.ToInt32(Edition.Text);
//            WRT.Reco_Title = Title.Text;
//            WRT.Reco_Content = Intro.Text;
//            WRT.Reco_CreateTime = DateTime.Now;
//            BWeblog_RecommendTheme.Insert(WRT);
            
//        }

//    }
//}
