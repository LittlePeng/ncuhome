using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;

namespace Ncuhome.Blog.Controls.Manage
{
    public class AddFriend : SkinnedBlogWebControl
    {
        private TextBox SearchByXH;
        private TextBox SearchByName;
        private TextBox SearchByNickName;
        private TextBox SearchByQQ;

        private DropDownList DropXY;
        private DropDownList DropZY;

        private RadioButtonList RadioList;

        private Button SearchButton1;
        private SqlDataSource Source1;
        private RepeaterPaged RepeaterPaged1;

        public AddFriend()
        {
            SkinFileName = "AddFriend.ascx";
        }

        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            SearchByXH = (TextBox)Skin.FindControl("XH");
            SearchByNickName = (TextBox)Skin.FindControl("NickName");
            SearchByName = (TextBox)Skin.FindControl("Name");
            SearchByQQ = (TextBox)Skin.FindControl("QQ");

            DropXY = (DropDownList)Skin.FindControl("DropDownList1");
            DropZY = (DropDownList)Skin.FindControl("DropDownList2");

            RadioList = (RadioButtonList)Skin.FindControl("RadioButtonList1");

            Source1 = (SqlDataSource)Skin.FindControl("SqlDataSource3");
            SearchButton1 = (Button)Skin.FindControl("Search1");


            DropXY.DataBound += new EventHandler(DropXY_DataBound);
            DropZY.DataBound += new EventHandler(DropZY_DataBound);

            SearchButton1.Click += new EventHandler(SearchButton1_Click);
            RepeaterPaged1 = (RepeaterPaged)Skin.FindControl("RepeaterPaged1");
            DataBind();
        }

        private void DropZY_DataBound(object sender, EventArgs e)
        {
            ListItem ValueNull = new ListItem();
            ValueNull.Text = "==不选择==";
            ValueNull.Value = "0";

            DropZY.Items.Add(ValueNull);
            DropZY.Items.FindByValue("0").Selected = true;
        }

        private void DropXY_DataBound(object sender, EventArgs e)
        {
            ListItem ValueNull = new ListItem();
            ValueNull.Text = "==不选择==";
            ValueNull.Value = "0";
            DropXY.Items.Add(ValueNull);
            DropXY.Items.FindByValue("0").Selected = true;
        }

        private void SearchButton1_Click(object sender, EventArgs e)
        {
            //保存用户的搜索状态
            View_WeblogUserXSJBXX v = new View_WeblogUserXSJBXX();
            v.User_NickName = SearchByNickName.Text.Trim();
            v.User_Name = SearchByName.Text.Trim();
            v.User_QQ = SearchByQQ.Text.Trim();
            v.XH = SearchByXH.Text.Trim();
            v.XB = RadioList.SelectedValue;
            v.YXSH = DropXY.SelectedValue;
            v.ZYH = DropZY.SelectedValue;
            HttpContext.Current.Session["SearchKey"] = null;
            if (v.User_NickName != "" || v.User_Name != "" || v.User_QQ != "" || v.XH != "" || v.XB != "0" || v.YXSH != "" || v.ZYH != "")
            {
                HttpContext.Current.Session["SearchKey"] = v;
            }
            HttpContext.Current.Response.Redirect("/" + blogContext.Owner.User_DomainName + "/Manage/AddFriend.aspx");
        }

        public override void DataBind()
        {
            if (blogContext.ID != -1)
            {
                Common_Friend CF = new Common_Friend();
                CF.Frd_CreateTime = DateTime.Now;
                CF.Frd_FriendUserId = BWeblog_User.GetUserIDByFiiD(blogContext.ID);
                
                //myself：不用强制类型转换
                CF.Frd_TxzUID = blogContext.Owner.User_TxzId.Value;
                CF.Frd_UserId = blogContext.BlogUserId;

                BCommon_Friend.Insert(CF);
                HttpContext.Current.Response.Redirect("/" + blogContext.Owner.User_DomainName + "/Manage/Friend.aspx");
            }

            if (blogContext.Action == "All")
            {
                HttpContext.Current.Session["SearchKey"] = null; //清楚信息
            }

            if (HttpContext.Current.Session["SearchKey"] != null)
            {
                View_WeblogUserXSJBXX v = (View_WeblogUserXSJBXX)HttpContext.Current.Session["SearchKey"];
                RepeaterPaged1.Length = 30;
                RepeaterPaged1.UrlFormat = "/Manage/AddFriend.aspx?mfiid=" + blogContext.MFiiD.ToString() + "&";
                int Count = 0;
                RepeaterPaged1.DataSource = BView_WeblogUserXSJBXX.SearchByAll(blogContext.PageIndex, 30, out Count, v.XB, v.User_QQ, v.User_NickName, v.User_Name, v.XH, v.YXSH, v.ZYH);
                RepeaterPaged1.Count = Count;
                RepeaterPaged1.DataBind();
            }
            else
            {
                RepeaterPaged1.Length = 30;
                RepeaterPaged1.UrlFormat = "/Manage/AddFriend.aspx?mfiid=" + blogContext.MFiiD.ToString() + "&";
                int Count = 1;
                RepeaterPaged1.DataSource = BWeblog_User.GetAllPaged(blogContext.PageIndex, 30, out Count);
                RepeaterPaged1.Count = Count;
                RepeaterPaged1.DataBind();
            }
            base.DataBind();
        }
    }
}
