<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Kick.aspx.cs" Inherits="ChatAdmin_Kick" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        
                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1"
                    DataTextField="UserName" DataValueField="UserName">
                </asp:DropDownList>
           
                <br />
           
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HomeChatConnectionString %>"
                    SelectCommand="SELECT [UserName], [UserID] FROM [User] WHERE [IsOnline] = 1 and username not in (select UserName from kickedUser) and username!='大家'">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="true" Name="IsOnline" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
        <asp:TextBox ID="txtReason" runat="server" Width="362px"   ></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtReason" ErrorMessage="*">*</asp:RequiredFieldValidator>
                &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" 
            Text="踢！" Width="80px" />

 

        <br />

        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返回" 
            Width="165px" ValidationGroup="2" />
    </form>
</body>
</html>
