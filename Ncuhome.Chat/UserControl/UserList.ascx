<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserList.ascx.cs" Inherits="UserControl_UserList" %>
  <asp:Repeater ID="UserList"  runat="server" >
        <ItemTemplate>
         <a href="javascript:ChangeTalkTo('<%#Eval("UserName") %>')"> <%#Eval("UserName")%></a> 
               <br />
        </ItemTemplate>
</asp:Repeater>