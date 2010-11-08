<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false"  EnableEventValidation="false" CodeFile="manage.aspx.cs" Inherits="ChatAdmin_manage1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>聊天室后台管理</title>
    <link href="../Themes/Blue/Default.css" rel="stylesheet" type="text/css" />
     <style type="text/css">
    .btn_2k3
    { border-right:#002d96 1px solid; padding-right:2px; border-top:#002d96 1px solid; padding-left:2px; font-size:12px;
       filter:progid:DXImageTransform.Microsoft.Gradient(GradienType=0,StartColorStr=#FFFFFF, EndColorStr=#9DBCeA);
       border-left:#002d96 1px solid; cursor:hand; color:Black; padding-top:2px; border-bottom::#002d96 1px solid;
    	
    	}
    </style>
</head>
<body background="../pic/dark blue.jpg">
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button3" runat="server" CssClass="btn_2k3" OnClick="Button3_Click" Text="导出聊天记录" Width="130px" />
        <asp:Button ID="Button4" runat="server" CssClass="btn_2k3"  OnClientClick="javascript:return confirm('你确定此操作吗？')" OnClick="Button4_Click" Text="" Width="130px" />
        <asp:Button ID="Button5" runat="server" CssClass="btn_2k3" OnClientClick="javascript:return confirm('你真的开启新的聊天室吗？')"  OnClick="Button5_Click" Text="新的聊天主题" Width="130px" />
        <asp:Button ID="Button6" runat="server" CssClass="btn_2k3" OnClick="Button6_Click" Text="修改聊天主题" Width="130px" />
        <asp:Button ID="Button7" runat="server" CssClass="btn_2k3" OnClick="Button7_Click" Text="要屏蔽的用户名" Width="130px" />
        <asp:Button ID="Button8" runat="server" CssClass="btn_2k3" OnClick="Button8_Click" Text="要屏蔽的字眼" Width="130px" />
        <asp:Button ID="Button9" runat="server" CssClass="btn_2k3" OnClick="Button9_Click" Text="查看留言内容" Width="130px" />
        <asp:Button ID="Button10" runat="server" CssClass="btn_2k3" OnClick="Button10_Click" Text="整理聊天纪录" Width="130px" />
        <asp:Button ID="Button2" runat="server" CssClass="btn_2k3" OnClick="Button2_Click" Text="踢人" Width="130px" />
        <asp:Button ID="Button11" runat="server" Text="嘉宾入口" CssClass="btn_2k3" OnClick="Button11_Click" Width="130px" />
   
        <hr />
        <asp:TextBox runat="server" ID="TextBox_PublicTale" Width="560px" Visible="False"></asp:TextBox>
        <asp:Button runat="server" ID="Button_Pub" Text="发布公告" OnClick="Button_Pub_OnClick" Visible="False" />
        
           
    
    </div>
        
        <br />
        <a href="NewChat.aspx" target="_blank"><h1 style=" text-align:center; text-decoration:underline; color:Red; ">审核信息</h1></a>
        <br />
            &nbsp;

        
        </form>
</body>
</html>
