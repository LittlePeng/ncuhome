<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PrivateChatInfo.ascx.cs" Inherits="UserControl_PrivateChatInfo" %>
<asp:Repeater ID="PrivateChat"  runat="server" >
  <ItemTemplate>
  <table>
  <tr>
                <td style="font-size:14">
                    <a style="color:#AA00CC" href="javascript:ChangeTalkTo('<%#Eval("Sender") %>')"><%#Eval("Sender")%></a>        对
                    
                <a style="color:#AA00CC" href="javascript:ChangeTalkTo('<%#Eval("Sendto") %>')"><%#Eval("Sendto")%></a>
                    说：
                <font color="#333333"> <%#Eval("content") %></font>&nbsp;&nbsp; <font style="color: #999999;">
                    (<%#Eval("time") %>)</font></td>
            </tr>
            </table>
  </ItemTemplate>
  
</asp:Repeater>   