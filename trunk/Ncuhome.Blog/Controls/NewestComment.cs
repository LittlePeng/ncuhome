using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;


namespace Ncuhome.Blog.Controls
{
    public class NewestComment : SkinnedBlogWebControl
    {
        public NewestComment() 
              
        {
            SkinFileName = "NewestComment.ascx";
            IsThemed = true;
        }

        private Repeater CommentRepeater;


        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            CommentRepeater = (Repeater)Skin.FindControl("NewComment");
            //CommentRepeater.DataSource = BView_WeblogUserComment.GetTopCommentByLogUID(blogContext.BlogUserId);
            CommentRepeater.DataSource = BGetCommentInfoByLogId.GetTopCommentByLogUID(blogContext.BlogUserId);
            CommentRepeater.DataBind();

            //throw new NotImplementedException();
        }
    
    
    
    }
            
    
}
