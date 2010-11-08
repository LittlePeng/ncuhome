<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChatList.ascx.cs" Inherits="UserControl_ChatList" %>
 <table style=" border:1px solid #cccccc; WIDTH:980px; text-align:center;  BORDER-COLLAPSE: collapse " border=1px; >
 <tr style="HEIGHT: 25px; background-color:#eef9eb ">    
    <th>来自</th>  <th>发给</th>  <th>类型</th> <th>聊天内容</th> <th>时间</th>  <th>操作</th> 
 </tr>
 <asp:Repeater ID="Repeater1" runat="server" >
 <ItemTemplate>
 <tr id="chat_<%#Eval("id") %>">
 <td><%#Eval("Sender")%></td>
 <td><%#Eval("SendTo")%></td>
 <td><%#ShowP(Eval("IsPrivate"))%></td>
  <td width="60%"><%#Eval("content")%></td> 
  <td width="5%"><%# Convert.ToDateTime(Eval("time").ToString()).ToLongTimeString()%></td>  
  <td width="8%">
  <a href="javascript:SendM('<%#Eval("id") %>')">发送</a> <a href="javascript:DeleteM('<%#Eval("id") %>')">删除</a>
  </td>   
 </tr>
 </ItemTemplate>
 </asp:Repeater>
 </table>
