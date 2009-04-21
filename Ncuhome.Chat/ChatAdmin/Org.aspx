<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeFile="Org.aspx.cs" Inherits="ChatAdmin_Org" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource2"
            DataTextField="ChatTime" DataValueField="ID">
        </asp:DropDownList>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HomeChatConnectionString %>"
            SelectCommand="SELECT [ChatTime], [ID] FROM [Chat] order by ChatTime desc"></asp:SqlDataSource>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
            DataSourceID="SqlDataSource1" AllowPaging="True" Font-Size="12px" PageSize="20" Width="100%" AllowSorting="True">
            <Columns>
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="true" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True"
                    SortExpression="ID" />
                <asp:BoundField DataField="Sender" HeaderText="Sender" SortExpression="Sender" />
                <asp:BoundField DataField="SendTo" HeaderText="SendTo" SortExpression="SendTo" />
                <asp:BoundField DataField="content" HeaderText="content" SortExpression="content" />
                <asp:BoundField DataField="OrgNum" HeaderText="OrgNum" SortExpression="OrgNum" />
            </Columns>
        </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
        &nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="点击返回" Width="98px" />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HomeChatConnectionString %>"
            DeleteCommand="DELETE FROM [ChatInfo] WHERE [ID] = @ID" InsertCommand="INSERT INTO [ChatInfo] ([Sender], [SendTo], [content], [OrgNum]) VALUES (@Sender, @SendTo, @content, @OrgNum)"
            SelectCommand="SELECT [ID], [Sender], [SendTo], [content], [OrgNum] FROM [ChatInfo] WHERE ([ChatNum] = @ChatNum) order by time desc"
            UpdateCommand="UPDATE [ChatInfo] SET [Sender] = @Sender, [SendTo] = @SendTo, [content] = @content, [OrgNum] = @OrgNum WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int64" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="Sender" Type="String" />
                <asp:Parameter Name="SendTo" Type="String" />
                <asp:Parameter Name="content" Type="String" />
                <asp:Parameter Name="OrgNum" Type="Int64" />
                <asp:Parameter Name="ID" Type="Int64" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="Sender" Type="String" />
                <asp:Parameter Name="SendTo" Type="String" />
                <asp:Parameter Name="content" Type="String" />
                <asp:Parameter Name="OrgNum" Type="Int64" />
            </InsertParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="ChatNum" PropertyName="SelectedValue"
                    Type="Int64" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
