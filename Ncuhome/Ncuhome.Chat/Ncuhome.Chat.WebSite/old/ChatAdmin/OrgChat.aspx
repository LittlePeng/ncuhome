<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false" ValidateRequest="false" CodeFile="OrgChat.aspx.cs" Inherits="ChatAdmin_OrgChat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<link href="../Themes/Blue/Default.css" rel="stylesheet" type="text/css" />
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function test(a)
        {
            __doPostBack('GridView1','Select$'+a);
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
    <div runat="server">
        &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1"
            DataTextField="ChatTime" DataValueField="ID" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
        &nbsp;
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:HomeChatConnectionString %>"
            SelectCommand="SELECT [ID], [Notice], [ChatTime] FROM [Chat] ORDER BY [ID] DESC">
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" 
        DataKeyNames="ID" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="selectChange">
            <Columns>
                <asp:CommandField ShowSelectButton="True" ShowDeleteButton="True" />
                <asp:BoundField DataField="OrgNum" HeaderText="整理编号" SortExpression="OrgNum" />
                <asp:BoundField DataField="Sender" HeaderText="发送者" ReadOnly="True" SortExpression="Sender" />
                <asp:TemplateField>
                    <ItemTemplate>
                        对
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SendTo" HeaderText="接受者" ReadOnly="True" SortExpression="SendTo" />
                <asp:TemplateField>
                    <ItemTemplate>
                        说
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="内容">
                    <ItemTemplate>
                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("content", "{0}") %>'></asp:Literal>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="time" HeaderText="时间" SortExpression="time" ReadOnly="True" />
                
            </Columns>
            <EditRowStyle BorderWidth="200px" />
        </asp:GridView>
       
       
       
       
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:HomeChatConnectionString %>"
            DeleteCommand="DELETE FROM [ChatInfo] WHERE [ID] = @ID" InsertCommand="INSERT INTO [ChatInfo] ([Sender], [SendTo], [content], [OrgNum], [UseFace], [time]) VALUES (@Sender, @SendTo, @content, @OrgNum, @UseFace, @time)"
            SelectCommand="SELECT [Sender], [SendTo], [content], [ID], [OrgNum], [UseFace], [time] FROM [ChatInfo] WHERE ([ChatNum] = @ChatNum) ORDER BY [ID] desc, [OrgNum] DESC"
            UpdateCommand="UPDATE [ChatInfo] SET [content] = @content, [OrgNum] = @OrgNum WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int64" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="content" Type="String" />
                <asp:Parameter Name="OrgNum" Type="Int64" />
                <asp:Parameter Name="ID" Type="Int64" />
            </UpdateParameters>
            <SelectParameters>
                <asp:ControlParameter ControlID="DropDownList1" Name="ChatNum" PropertyName="SelectedValue"
                    Type="Int64" />
            </SelectParameters>
            <InsertParameters>
                <asp:Parameter Name="Sender" Type="String" />
                <asp:Parameter Name="SendTo" Type="String" />
                <asp:Parameter Name="content" Type="String" />
                <asp:Parameter Name="OrgNum" Type="Int64" />
                <asp:Parameter Name="UseFace" Type="String" />
                <asp:Parameter Name="time" Type="DateTime" />
            </InsertParameters>
        </asp:SqlDataSource>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="导出该次聊天记录" Width="200px" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="返回" Width="90px" /><br />
        </div>
    </form>
</body>
</html>
