using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;

namespace Ncuhome.Blog.Controls
{
    public class LogCategory:SkinnedBlogWebControl
    {
        private Repeater LogCategorys;
        public LogCategory()
        {
            SkinFileName = "LogCategory.ascx"; 
            IsThemed = true;
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            LogCategorys = (Repeater)Skin.FindControl("LogCategory");
            DataBind();
            //throw new NotImplementedException();
        }
        public override void DataBind()
        {
            LogCategorys.DataSource = BView_WeblogUserLogCategory.GetByUserId(Ncuhome.Blog.Core.BlogContext.Current.BlogUserId);
            LogCategorys.DataBind();
            base.DataBind();
        }
    }
}
