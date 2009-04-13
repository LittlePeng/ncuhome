using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Ncuhome.Blog.Controls
{
    public class Calendars:SkinnedBlogWebControl
    {
        private Calendar cDate;
        public Calendars()
        {
            SkinFileName = "Calendars.ascx";
            IsThemed = true;
        }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            cDate=(Calendar)Skin.FindControl("cDate");
            cDate.SelectionChanged += new EventHandler(cDate_SelectionChanged);
            //throw new NotImplementedException();
        }
        protected void cDate_SelectionChanged(object sender, EventArgs e)
        {
            //Context.Response.Redirect("log.aspx?mfiid="+blogContext.MFiiD+"&afiid="+blogContext.AFiiD+"&year="+cDate.SelectedDate.Year+"&month="+cDate.SelectedDate.Month+"&day="+cDate.SelectedDate.Day);
        }
    }
}
