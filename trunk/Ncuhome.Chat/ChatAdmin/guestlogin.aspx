<%@ Page Language="C#" AutoEventWireup="true" CodeFile="guestlogin.aspx.cs" Inherits="ChatAdmin_guestlogin" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
        <td>嘉宾名称：</td>
        
        <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
       </td>
        <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="填写名称" ControlToValidate="TextBox1"></asp:RequiredFieldValidator></td>
    </tr>
    
    <tr>
        <td>密码：</td>
        <td>
        <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox></td>
        <td>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="填写密码" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
    </td>
    </tr>
       
    </table> <asp:Button ID="Button1" runat="server" Text="登陆" onclick="Button1_Click" />
    </div>
    </form>
</body>
</html>
