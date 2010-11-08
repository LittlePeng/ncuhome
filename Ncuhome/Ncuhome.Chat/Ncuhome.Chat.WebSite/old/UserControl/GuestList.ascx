<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GuestList.ascx.cs" Inherits="UserControl_GuestList" %>
  <asp:Repeater ID="GuestList"  runat="server" >
        <ItemTemplate>
         <a  href="javascript:ChangeTalkTo('<%#Eval("UserName") %>')"> <%#Eval("UserName")%></a> 
               <br />
        </ItemTemplate>
        </asp:Repeater>