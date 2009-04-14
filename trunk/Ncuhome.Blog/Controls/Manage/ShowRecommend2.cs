using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;
using System.Web.UI.WebControls;



namespace Ncuhome.Blog.Controls.Manage
{
   public class ShowRecommend2:SkinnedBlogWebControl
    {
       public ShowRecommend2()
       {
           SkinFileName = "ShowRecommend2.ascx";
       
       }
       private RepeaterPaged RP;
       private Literal Theme;
       //private Int32 PageIndex=1;
       
              

       protected override void InitializeSkin(System.Web.UI.Control Skin)
       {


           RP = (RepeaterPaged)Skin.FindControl("RepeaterPaged1");
           Theme = (Literal)Skin.FindControl("Literal1");
           //if (Context.Request.QueryString["pageindex"] != "")
           //{
           //    PageIndex = Context.Request.QueryString["pageindex"];
           //}
           RP.Length = 7;
           RP.Count = BWeblog_RecommendTheme.GetAllThemeId().Count() * 7;
           RP.UrlFormat = "default.aspx?";

          int[] array= BWeblog_RecommendTheme.GetAllThemeId();
                       
           RP.DataSource = BView_WeblogUserRecommend.GetByPageIndex(array[blogContext.PageIndex-1],7);
           RP.DataBind();
           Weblog_RecommendTheme WRT = BWeblog_RecommendTheme.GetByPageIndex(array[blogContext.PageIndex - 1]);
           Theme.Text = WRT.Reco_Title+WRT.Reco_Content;  

       }
    }
}
