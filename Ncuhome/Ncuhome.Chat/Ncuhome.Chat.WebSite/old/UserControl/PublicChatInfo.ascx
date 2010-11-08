<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PublicChatInfo.ascx.cs" Inherits="UserControl_PublicChatInfo" %>


<asp:Repeater ID="PublicChat"  runat="server" >
  <ItemTemplate>
  <table>
  <tr>
    <td style="font-size:14">
        <a style="color:#AA00CC" href="javascript:ChangeTalkTo('<%#Eval("Sender") %>')"><%#Eval("Sender")%></a>
          对
       <a style="color:#AA00CC" href="javascript:ChangeTalkTo('<%#Eval("Sendto") %>')"><%#Eval("Sendto")%></a>
          说：
          
          <font style="line-height: 180%; color:#333333">
              <%#Eval("content") %>
          </font>&nbsp;&nbsp;
          <font style="color:#999999">(
            <asp:Literal  ID="LI" runat="server" Text='<%#Eval("time") %>'></asp:Literal>
            <asp:Literal  ID="LIHIDDEN" Visible="false" runat="server" Text='<%#Eval("Checktime") %>'></asp:Literal>
          )
            </font>
           </td>
       </tr>
       </table>
  </ItemTemplate>
  <FooterTemplate>
    
    
  </FooterTemplate>
</asp:Repeater>
