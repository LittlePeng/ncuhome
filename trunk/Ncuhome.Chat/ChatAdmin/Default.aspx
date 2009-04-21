<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ChatAdmin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../Themes/Blue/Default.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
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
    <div id="LoginPannel">
        <asp:Panel ID="Panel1" runat="server" Height="50px" Width="125px">
            用户:<asp:TextBox ID="TextBox1" runat="server" Width="135px"></asp:TextBox>
            密码:<asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="135px"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" CssClass="btn_2k3" OnClick="Button1_Click" Text="登陆" />
        </asp:Panel>
      </div>  
    </form>
</body>
</html>
 