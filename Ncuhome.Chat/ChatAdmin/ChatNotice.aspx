<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChatNotice.aspx.cs" Inherits="ChatAdmin_ChatNotice" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register TagPrefix="CE" Namespace="CuteEditor" Assembly="CuteEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../Themes/Blue/Default.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
<center>
    <form id="form1" runat="server">
      <font style="color:Red; font-size:x-large"> 家园网聊天室首页主题修改</font> 
      <br />
    <CE:EDITOR id="Editor1" runat="server" Width="546px" AutoConfigure="Default" Height="288px" EditorOnPaste="PasteText">
        <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
            CssClass="CuteEditorFrame" Height="100%" Width="100%" />
    </CE:EDITOR>
        <br />
        
        <CE:Editor  ID="Editor2" runat="server" AutoConfigure="Default" Height="288px" Width="546px" Visible="False">
            <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                CssClass="CuteEditorFrame" Height="100%" Width="100%" />
        </CE:Editor>
        <div style="font-size:28px;  color:Red;">聊天室聊天页面竖直滚动公告:</div>
        <CE:Editor ID="Editor3" runat="server" AutoConfigure="Default" Height="288px" Width="546px">
            <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                CssClass="CuteEditorFrame" Height="100%" Width="100%" />
        </CE:Editor>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="修改" Width="100px" />&nbsp;&nbsp;
        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        &nbsp; &nbsp; &nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返回" Width="100px" />

       
    </form>
    </center>

</body>
</html>c
