using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using Ncuhome.Blog.Core;
using Ncuhome.Blog.Entity;
using System.ComponentModel;
using System.Web.UI.HtmlControls;


namespace Ncuhome.Blog.Controls.Manage
{
   public class LogList:SkinnedBlogWebControl
    {
       private RepeaterPaged RepeaterPaged1;
       private Button MoveCategory;
       private DropDownList DropDownList1;
       private DropDownList DropDownList2;
       private HtmlInputHidden Hidden1;
       private CheckBox CheckBox1;
 
       [DefaultValue(false)]
       public bool IsDraft { get; set; }
       public LogList()
       {
           SkinFileName = "LogList.ascx";
       }
        protected override void InitializeSkin(System.Web.UI.Control Skin)
        {
            RepeaterPaged1 = (RepeaterPaged)Skin.FindControl("RepeaterPaged1");
            MoveCategory = (Button)Skin.FindControl("MoveCategory");
            DropDownList1 = (DropDownList)Skin.FindControl("DropDownList1");
            DropDownList2 = (DropDownList)Skin.FindControl("DropDownList2");

            if (!IsDraft)
            {

                DropDownList1.SelectedIndexChanged += new EventHandler(DropDownList1_SelectedIndexChanged);
                DropDownList1.AutoPostBack = true;
                DropDownList1.DataBound += new EventHandler(DropDownList1_DataBound);
                DropDownList2.DataBound += new EventHandler(DropDownList2_DataBound);
                MoveCategory.Click += new EventHandler(MoveCategory_Click);

            }
            else
            {
                MoveCategory.Enabled = false;
            }
            if (Context.Request["DeleteLogId"]!=null)
            {
                if (BWeblog_log.DeleteByID(Convert.ToInt32(Context.Request["DeleteLogId"])))
                {
                    BWeblog_User.SetUserCommentCount(blogContext.BlogUserId);
                    BWeblog_log.SetLogCountByUID(blogContext.BlogUserId);
                    Context.Response.Write("<script>alert('删除成功！');window.location='/" + blogContext.Owner.User_DomainName + "/Manage/logs.aspx';</script>");
                    Context.Response.End();
                }
                else
                {
                    Context.Response.Write("<script>alert('删除失败！');window.location='/" + blogContext.Owner.User_DomainName + "/Manage/logs.aspx';</script>");
                    Context.Response.End();
                    
                }
            }
            ListDataBind();
        }

        void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "0")
                Context.Response.Redirect("/" + blogContext.Owner.User_DomainName + "/Manage/Logs.aspx");
            RepeaterPaged1.UrlFormat = "/Manage/Logs.aspx?mfiid=" + blogContext.MFiiD.ToString() + "&";
            RepeaterPaged1.Count = BWeblog_log.GetCountByLogCateIDAndUID(Convert.ToInt32(DropDownList1.SelectedValue),blogContext.BlogUserId);
            RepeaterPaged1.Length = 15;
            RepeaterPaged1.DataSource = BWeblog_log.GetByBlogUIDPaged(blogContext.BlogUserId, blogContext.PageIndex, 15,Convert.ToInt32(DropDownList1.SelectedValue));
            RepeaterPaged1.DataBind();
        }

        void MoveCategory_Click(object sender, EventArgs e)   //移动日志
        {
            if (DropDownList2.SelectedValue == "0")
                Context.Response.Redirect("/" + blogContext.Owner.User_DomainName + "/Manage/Logs.aspx");
            if (DropDownList2.SelectedValue == "0")
            {

                Context.Response.Write("<script>alert('您必须必须先选择类别！');window.location='/" + blogContext.Owner.User_DomainName + "/Manage/logs.aspx';</script>");
                Context.Response.End();
            }
            if (DropDownList1.SelectedValue == DropDownList2.SelectedValue)
            {
                Context.Response.Write("<script>alert('您必须从一个类别移动到另一个类别！');window.location='/" + blogContext.Owner.User_DomainName + "/Manage/logs.aspx';</script>");
                Context.Response.End();
            }
            int count = 0;
            for (int i = 0; i < RepeaterPaged1.Items.Count; i++)
            {
               CheckBox1=(CheckBox)  RepeaterPaged1.Items[i].FindControl("CheckBox1");
               if (CheckBox1.Checked == true)
               {
                   count++;
                   Hidden1 = (HtmlInputHidden)RepeaterPaged1.Items[i].FindControl("Hidden1");
                   int LogId =Convert.ToInt32( Hidden1.Value);
                   int TagetCateId = Convert.ToInt32( DropDownList2.SelectedValue);
                   BWeblog_log.UpdateLogCateIdSingle(TagetCateId, LogId);
               }
            }
            RepeaterPaged1.Count = 10;
            RepeaterPaged1.Length = 10;
            if (count > 0)
            {
                Context.Response.Write("<script>alert('移动成功！');window.location='/" + blogContext.Owner.User_DomainName + "/Manage/logs.aspx';</script>");
                Context.Response.End();
            }
            else
            {
                Context.Response.Write("<script>alert('请选择需要移动的选项！');window.location='/" + blogContext.Owner.User_DomainName + "/Manage/logs.aspx';</script>");
                Context.Response.End();
            }

        }

        void DropDownList2_DataBound(object sender, EventArgs e)
        {

            ListItem List = new ListItem();
            List.Text = "==移动到==";
            List.Value = "0";
            if(!Page.IsPostBack)
            List.Selected = true;

            ListItem List2 = new ListItem();
            List2.Text = "随笔";
            List2.Value = "1";
           
            DropDownList2.Items.Add(List2);
            DropDownList2.Items.Add(List);
        }

        void DropDownList1_DataBound(object sender, EventArgs e)
        {
            ListItem List = new ListItem();
            List.Text = "==全部日志==";
            List.Value = "0";
            if (!Page.IsPostBack)
            List.Selected = true;

            ListItem List2 = new ListItem();
            List2.Text = "随笔";
            List2.Value = "1";
          
           
            DropDownList1.Items.Add(List2);
            DropDownList1.Items.Add(List);
        }

        //public void CheckPW()
        //{
        //    if (BWeblog_log.GetByID(Convert.ToInt32(Context.Request.QueryString["logid"])).Log_IsPasssword == true)
        //    {
        //        Context.Response.Redirect("EnterPW.aspx?mfiid=" + Context.Request.QueryString["mfiid"] + "&logid=" + Context.Request.QueryString["logid"]);
        //    }
        //}

        public  void ListDataBind()
        {   
            if (!IsDraft)
                {
                    var temp = BWeblog_Category.SelectByUID(blogContext.BlogUserId);
                    DropDownList1.DataSource = temp;
                    DropDownList1.DataTextField = "Cate_Name";
                    DropDownList1.DataValueField = "Cate_Id";
                    DropDownList1.DataBind();

                    DropDownList2.DataSource = temp;
                    DropDownList2.DataTextField = "Cate_Name";
                    DropDownList2.DataValueField = "Cate_Id";
                    DropDownList2.DataBind();
                }

            if (!Page.IsPostBack)
            {

            

                if (!IsDraft)
                {
                    RepeaterPaged1.UrlFormat = "/Manage/Logs.aspx?mfiid=" + blogContext.MFiiD.ToString() + "&";
                    RepeaterPaged1.Count = BWeblog_log.GetBLogCountByUID(blogContext.BlogUserId);
                    RepeaterPaged1.Length = 15;
                    RepeaterPaged1.DataSource = BWeblog_log.GetByBlogUIDPaged(blogContext.BlogUserId, blogContext.PageIndex, 15);

                }
                else
                {
                    RepeaterPaged1.UrlFormat = "/Manage/draft.aspx?mfiid=" + blogContext.MFiiD.ToString() + "&";
                    RepeaterPaged1.Count = BWeblog_log.GetBLogDraftCountByUID(blogContext.BlogUserId);
                    RepeaterPaged1.Length = 15;
                    RepeaterPaged1.DataSource = BWeblog_log.GetByBlogDraftUIDPaged(blogContext.BlogUserId, blogContext.PageIndex, 15);

                }


                RepeaterPaged1.DataBind();
            }
            //base.DataBind();
        }

    }
}
