<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChatReplace.aspx.cs" Inherits="ChatAdmin_ChatReplace" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../Themes/Blue/default.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="Replace" HeaderText="Replace" SortExpression="Replace" />
                <asp:BoundField DataField="ReplaceTo" HeaderText="ReplaceTo" SortExpression="ReplaceTo" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HomeChatConnectionString %>"
            DeleteCommand="DELETE FROM [Replace] WHERE [ID] = @ID" InsertCommand="INSERT INTO [Replace] ([Replace], [ReplaceTo]) VALUES (@Replace, @ReplaceTo)"
            SelectCommand="SELECT [Replace], [ReplaceTo], [ID] FROM [Replace]" UpdateCommand="UPDATE [Replace] SET [Replace] = @Replace, [ReplaceTo] = @ReplaceTo WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int64" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Replace" Type="String" />
                <asp:Parameter Name="ReplaceTo" Type="String" />
                <asp:Parameter Name="ID" Type="Int64" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="Replace" Type="String" />
                <asp:Parameter Name="ReplaceTo" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>
                <asp:TextBox ID="TextBox_Replace" runat="server"></asp:TextBox><br />
                <asp:TextBox ID="TextBox_ReplaceTo" runat="server"></asp:TextBox><br />
                <asp:Button ID="Button1" runat="server" Text="确定" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返回" />
       <%-- <cc1:textboxwatermarkextender id="TextBoxWatermarkExtender1" runat="server" targetcontrolid="TextBox_Replace" WatermarkText="要被替换的词眼"></cc1:textboxwatermarkextender>--%>
    </div>
      <%--  <cc1:textboxwatermarkextender id="TextBoxWatermarkExtender2" runat="server" targetcontrolid="TextBox_ReplaceTo" WatermarkText="替换成什么样的字眼"></cc1:textboxwatermarkextender>--%>
    </form>
</body>
</html>
