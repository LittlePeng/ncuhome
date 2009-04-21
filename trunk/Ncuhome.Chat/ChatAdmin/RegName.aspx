<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegName.aspx.cs" Inherits="ChatAdmin_RegName" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../Themes/Blue/Default.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CellPadding="4" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="#333333"
            GridLines="None">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="RegName" HeaderText="RegName" SortExpression="RegName" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="ID" />
            </Columns>
            <RowStyle BackColor="#EFF3FB" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HomeChatConnectionString %>"
            DeleteCommand="DELETE FROM [RegName] WHERE [ID] = @ID" InsertCommand="INSERT INTO [RegName] ([RegName]) VALUES (@RegName)"
            SelectCommand="SELECT [RegName], [ID] FROM [RegName]" UpdateCommand="UPDATE [RegName] SET [RegName] = @RegName WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int64" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="RegName" Type="String" />
                <asp:Parameter Name="ID" Type="Int64" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="RegName" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" /><br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返回" />
<%--        <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="TextBox1" WatermarkText="禁止注册的用户名">
        </cc1:TextBoxWatermarkExtender>--%>
    </div>
    </form>
</body>
</html>
