//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Ncuhome.Blog.Core;
//using System.Web.UI.WebControls;
//using Ncuhome.Blog.Controls;
//using System.Web.UI;
//using Ncuhome.Blog.Entity;

//namespace Ncuhome.Blog.Controls.Manage
//{
//    public class ShowRecommend:SkinnedBlogWebControl
//    {
//        private Repeater repeater;
//        private Literal literal;
//        private Literal literal2;
//        private TextBox Edition;
//        private string title;
//        private string content;
//        private Int32 PageIndex;
        

//        private LinkButton Pre;
//        private LinkButton Next;

//        private Button OK;
        
//        public ShowRecommend()
//        {
//            SkinFilename = "ShowRecommend.ascx";
//        }
//        protected override void InitializeSkin(System.Web.UI.Control Skin)
//        {
//            Pre = (LinkButton)Skin.FindControl("LinkButton1");
//            Next = (LinkButton)Skin.FindControl("LinkButton2");
//            repeater = (Repeater)Skin.FindControl("Repeater1");
//            Edition = (TextBox)Skin.FindControl("TextBox1");
//            literal = (Literal)Skin.FindControl("Literal1");
//            literal2 = (Literal)Skin.FindControl("Literal2");
//            OK = (Button)Skin.FindControl("Button1");
//            OK.Click += new EventHandler(OK_Click);
//            //Edition.TextChanged += new EventHandler(Edition_TextChanged);
//            //repeater.DataSource = BView_WeblogUserRecommend.GetLatestRecommend();


//            Weblog_RecommendTheme WRT = BWeblog_RecommendTheme.GetLatestTheme();//获取最新一期的简介标题、内容、期数
            
//            Int32 LatestEdition = WRT.Reco_Edition;//定义最新一期
            
           
          
//            if (LatestEdition == 1)//如果期数只有一期，则不显示“上一期”“下一期”
//            {
//                Pre.Visible = false;
//                Next.Visible = false;
//            }
//            else//如果期数不只一期
//            {
                
//                if (Context.Request.QueryString["PageIndex"] == null)//如果没有传参数
//                {

//                    repeater.DataSource = BView_WeblogUserRecommend.GetLatestRecommend();//repeater的数据源如左
//                    PageIndex = LatestEdition;//定义PageIndex为最新期数，结合下一行，可以使得一打开页面，默认显示的是最新期刊
//                    Weblog_RecommendTheme WRT2 = BWeblog_RecommendTheme.GetThemeByEdition(PageIndex);//根据PageIndex获得数据（给Literal用），从而默认显示的是最新期刊的简介
//                    //if (WRT2 != null)
//                    //{

//                    //    title = WRT2.Reco_Title;
//                    //    content = WRT2.Reco_Content;
//                    //}
//                    //else 
                    
//                    //{
//                    //    Page.RegisterStartupScript("key", "<script>alert('没有这一期')</script>");
//                    //}
                    
//                    //Weblog_RecommendTheme WRT2 = BWeblog_RecommendTheme.GetThemeByEdition(PageIndex);

//                    title = WRT2.Reco_Title;
//                    content = WRT2.Reco_Content;
//                    literal.Text = "本期焦点：" + title + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + content;
//                }
//                else
//                {


//                    Weblog_RecommendTheme WRT2 = BWeblog_RecommendTheme.GetThemeByEdition(Convert.ToInt32(Context.Request.QueryString["PageIndex"]));//根据PageIndex获得数据（给Literal用）
//                    if (WRT2 != null)
//                    {
//                        title = WRT2.Reco_Title;
//                        content = WRT2.Reco_Content;
//                    }
//                    else 
//                    {
//                        Page.RegisterStartupScript("key", "<script>alert('没有这一期');window.location='default.aspx';</script>");
                        
//                    }
                    
                    
                    
//                    PageIndex = Convert.ToInt32(Context.Request.QueryString["PageIndex"]);//使PageIndex的值为传来的参数
//                    repeater.DataSource = BView_WeblogUserRecommend.GetRecommendByEdition(Convert.ToInt32(Context.Request.QueryString["PageIndex"]));//repeater的数据源

//                    if (Convert.ToInt32(Context.Request.QueryString["PageIndex"]) <= 1)//当参数PageIndex<=1时，前一期链接不可见，下一期可见
//                    {
//                        Pre.Visible = false;
//                        Next.Visible = true;
//                        //Pre.Style["Visible"] ="false";
//                    }
//                    if (LatestEdition <= Convert.ToInt32(Context.Request.QueryString["PageIndex"]))//当参数PageIndex>=最新期数时，下一期链接不可见，前一期可见
//                    {
//                        Next.Visible = false;
//                        Pre.Visible = true;
//                        //Next.Style["Visible"] = "false";
//                    }

//                }
//                    //title = WRT2.Reco_Title;
//                    //content = WRT2.Reco_Content;
//                    literal.Text = "本期焦点：" + title + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + content;

//            }
          
//            repeater.DataBind();

//             literal2.Text = LatestEdition.ToString();
//            //var WRT = BWeblog_RecommendTheme.GetLatestTheme();
            
//            //PageIndex = LatestEdition;
//            //Weblog_RecommendTheme WRT2 = BWeblog_RecommendTheme.GetThemeByEdition(Convert.ToInt32(Context.Request.QueryString["PageIndex"]));

//            //title = WRT2.Reco_Title;
//            //content =WRT2.Reco_Content;
//            //literal.Text = "本期焦点：" + title + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + content;
           
            
//            ////////////////////////////分页///////////////////////////////
//            //string PageIndex = 1;
//            //if (!Page.IsPostBack)
//            //{
//            //    PageIndex = LatestEdition;
//            //}
//            //Int32 Count=LatestEdition;
//            //if (Context.Request.QueryString["PageIndex"] != null)
//            //{
                
//            //}
            
//            Pre.Click += new EventHandler(Pre_Click);//点前一期链接触发新事件
//            Next.Click += new EventHandler(Next_Click);////点后一期链接触发新事件

//        }

//        void OK_Click(object sender, EventArgs e)
//        {
//            try
//            {
                
//                Context.Response.Redirect("default.aspx?PageIndex=" + Edition.Text);
//            }
//            catch (Exception)
//            {
//                //Page.RegisterStartupScript("key", "<script>alert('没有这一期')</script>");
//                //Context.Response.Write("<script>alert('没有这一期')</script>");
//            }
//        }

//        void Next_Click(object sender, EventArgs e)
//        {
           
//            PageIndex += 1;
//            Context.Response.Redirect("default.aspx?PageIndex=" + PageIndex);
//        }

//        void Pre_Click(object sender, EventArgs e)
//        {
            
//            PageIndex -= 1;
//            Context.Response.Redirect("default.aspx?PageIndex="+PageIndex);
//        }

//        //void Edition_TextChanged(object sender, EventArgs e)
//        //{
//        //    try
//        //    {
//        //        //var TempWRT = BWeblog_RecommendTheme.GetThemeByEdition(Convert.ToInt32(Edition.Text));
//        //        //title = TempWRT.Reco_Title;
//        //        //content = TempWRT.Reco_Content;
//        //        //literal.Text = "本期焦点：" + title + "<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + content;

//        //        //repeater.DataSource = BView_WeblogUserRecommend.GetRecommendByEdition(Convert.ToInt32(Edition.Text));
//        //        //repeater.DataBind();

//        //        //if (LatestEdition < Convert.ToInt32(Edition.Text))
//        //        //{
//        //        //    Page.RegisterStartupScript("key", "<script>alert('还没有这一期')</script>");//如果输入的参数比最新期数还大则提示没有这一期
//        //        //}
//        //        Context.Response.Redirect("default.aspx?PageIndex=" + Edition.Text);
//        //    }
//        //    catch (Exception)
//        //    {
//        //        Page.RegisterStartupScript("key", "<script>alert('没有这一期')</script>");
//        //        //Context.Response.Write("<script>alert('没有这一期')</script>");
//        //    }
//        //}
        
        
//    }
//}
