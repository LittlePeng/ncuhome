using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Controls;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;
using System.Data.SqlClient;


namespace Ncuhome.Blog.Controls
{
    public class AddFriend_Form : SkinnedBlogWebControl
    {
        private RepeaterPaged Repeater1;

        private TextBox SearchByXH;
        private TextBox SearchByName;
        private TextBox SearchByNickName;
        private TextBox SearchByQQ;

        private DropDownList DropXY;
        private DropDownList DropZY;

        private RadioButtonList RadioList;

        private Button SearchButton1;
        private string querry;
        private string querrycount;
        private int count;
        private SqlDataSource Source1;

        public AddFriend_Form()
        {
            SkinFileName = "AddFriend_Form.ascx";
        }

        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            Repeater1 = (RepeaterPaged)Skin.FindControl("RepeaterPaged1");

            SearchByXH = (TextBox)Skin.FindControl("XH");
            SearchByNickName = (TextBox)Skin.FindControl("NickName");
            SearchByName = (TextBox)Skin.FindControl("Name");
            SearchByQQ = (TextBox)Skin.FindControl("QQ");

            DropXY = (DropDownList)Skin.FindControl("DropDownList1");
            DropZY = (DropDownList)Skin.FindControl("DropDownList2");

            RadioList = (RadioButtonList)Skin.FindControl("RadioButtonList1");

            Source1 = (SqlDataSource)Skin.FindControl("SqlDataSource3");

            SearchButton1 = (Button)Skin.FindControl("Search1");

            ListItem ValueNull = new ListItem();

            ValueNull.Value = "null";

            DropZY.Items.Add(ValueNull);
            DropZY.Items.FindByValue("null").Selected = true;
            DropXY.Items.Add(ValueNull);
            DropXY.Items.FindByValue("null").Selected = true;

            SearchButton1.Click += new EventHandler(SearchButton1_Click);

            if (!Page.IsPostBack)
            {
                Repeater1.Count = 0;
            }

            Repeater1.Length = 5;
            Repeater1.UrlFormat = "AddFriend.aspx?mfiid=" + blogContext.MFiiD.ToString() + "&";

            querry = "select * from View_WeblogUserXSJBXX where [XB]='" + RadioList.SelectedValue + "'";
        }

        /// <summary>
        /// myself：不用异常处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton1_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (SearchByXH.Text != "")
            {
                querry += "and [XH]= @XH";
            }
            if (SearchByNickName.Text != "")
            {
                querry += "and [User_NickName]=@UNN";
            }
            if (SearchByName.Text != "")
            {
                querry += "and [XM]=@XM";
            }
            if (SearchByQQ.Text != "")
            {
                querry += "and [User_QQ]=@UQ";
            }
            if (DropXY.SelectedValue != null)
            {
                querry += "and [YXSMC]=@XY";
            }
            if (DropZY.SelectedValue != null)
            {
                querry += "and [ZYMC]=@ZY";
            }
            //}
            //catch
            //{
            //    Context.Response.Write("<script>alert('出错了!')</script>");
            //}
            ParameterCollection co = new ParameterCollection();
            co.Add("@XH", SearchByXH.Text);
            co.Add("@UNN", SearchByNickName.Text);
            co.Add("@XM", SearchByName.Text);
            co.Add("@UQ", SearchByQQ.Text);
            co.Add("@XY", DropXY.SelectedValue);
            co.Add("@ZY", DropZY.SelectedValue);

            Source1.SelectCommand = querry;
            Repeater1.DataSource = Source1;
            Repeater1.DataBind();
        }
    }
}
