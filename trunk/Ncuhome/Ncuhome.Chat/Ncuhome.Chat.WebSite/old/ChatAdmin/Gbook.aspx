<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Gbook.aspx.cs" Inherits="ChatAdmin_Gbook" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="返回" Width="79px" /><br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
            AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MesID" DataSourceID="SqlDataSource1"
            Font-Size="12px" ForeColor="#333333" GridLines="None" PageSize="20" Width="100%">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="MesName" HeaderText="留言者姓名" SortExpression="MesName" />
                <asp:BoundField DataField="MesXY" HeaderText="留言者学院" SortExpression="MesXY" />
                <asp:BoundField DataField="MesContent" HeaderText="留言内容" SortExpression="MesContent" />
                <asp:BoundField DataField="MesTime" HeaderText="留言时间" SortExpression="MesTime" />
                <asp:BoundField DataField="MesID" HeaderText="MesID" InsertVisible="False" ReadOnly="True"
                    SortExpression="MesID" Visible="False" />
            </Columns>
            <RowStyle BackColor="#EFF3FB" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Left"
                VerticalAlign="Top" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        &nbsp;</div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HomeChatConnectionString %>"
            DeleteCommand="DELETE FROM [Mes] WHERE [MesID] = @MesID" InsertCommand="INSERT INTO [Mes] ([MesName], [MesXY], [MesContent], [MesTime]) VALUES (@MesName, @MesXY, @MesContent, @MesTime)"
            SelectCommand="SELECT [MesName], [MesXY], [MesContent], [MesTime], [MesID] FROM [Mes]"
            UpdateCommand="UPDATE [Mes] SET [MesName] = @MesName, [MesXY] = @MesXY, [MesContent] = @MesContent, [MesTime] = @MesTime WHERE [MesID] = @MesID">
            <DeleteParameters>
                <asp:Parameter Name="MesID" Type="Int64" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="MesName" Type="String" />
                <asp:Parameter Name="MesXY" Type="String" />
                <asp:Parameter Name="MesContent" Type="String" />
                <asp:Parameter Name="MesTime" Type="DateTime" />
                <asp:Parameter Name="MesID" Type="Int64" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="MesName" Type="String" />
                <asp:Parameter Name="MesXY" Type="String" />
                <asp:Parameter Name="MesContent" Type="String" />
                <asp:Parameter Name="MesTime" Type="DateTime" />
            </InsertParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
