<%@ Page Language="C#" AutoEventWireup="true" CodeFile="History.aspx.cs" Inherits="History" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>聊天记录</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>全部聊天记录</h1>
    <asp:Panel ID="Panel2" runat="server" BackColor="Transparent" ScrollBars="Auto"
                      Width="100%">
     <asp:SqlDataSource ID="PublicChatDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:HomeChatConnectionString %>" />

    <asp:Repeater ID="PublicChat" runat="server" DataSourceID="PublicChatDataSource">
                          <HeaderTemplate>
                          </HeaderTemplate>
                          <ItemTemplate>
                              <div style="width: 95%; margin-left:10px; overflow:hidden">
                                  <asp:LinkButton ID="Sender" runat="server" ForeColor="Green" 
                                      Text='<%#Eval("Sender")%>'>
                                        <%#Eval("Sender")%>
                                      </asp:LinkButton>
                                  <font style="color: Blue;">对</font>
                                  <asp:LinkButton ID="LinkButton3" runat="server" ForeColor="Green" 
                                      Text='<%#Eval("Sendto")%>'>
                                            <%#Eval("Sendto")%>
                                      </asp:LinkButton>
                                  <font style="color: Blue;">说</font>: <font style="line-height: 180%">
                                      <%#Eval("content") %>
                                  </font>&nbsp;&nbsp;
                                  <font style="color:#999999">(
                                    <asp:Literal  ID="LI" runat="server" Text='<%#Eval("time") %>'></asp:Literal>
                                    <asp:Literal  ID="LIHIDDEN" Visible="false" runat="server" Text='<%#Eval("Checktime") %>'></asp:Literal>)
                                    </font>
                                    </td>
                              </div>
                          </ItemTemplate>
                          <FooterTemplate>
                          </FooterTemplate>
                      </asp:Repeater>
                      </asp:Panel>
    </div>
    </form>
</body>
</html>
