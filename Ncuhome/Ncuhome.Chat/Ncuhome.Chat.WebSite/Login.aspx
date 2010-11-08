<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<html>
<head>
    <meta http-equiv="Content-Language" content="zh-cn">
    <title>家园网聊天室</title>
    <link rel="Bookmark" href="http://www.ncuhome.cn/ncuhome.ico">
    <link rel="Shortcut Icon" href="http://www.ncuhome.cn/ncuhome.ico">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <script language="javascript" type="text/javascript">
        function SubmitKeyClick(button) {
            if (event.keyCode == 13) {
                event.keyCode = 9;
                event.returnValue = false;
                document.all[button].click();
            }
        }
        // -->
    </script>
    <body topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0" bgcolor="#EFEFEF">
        <form id="form1" runat="server">
        <center>
            <table border="0" width="556" cellspacing="0" cellpadding="0" height="100%" id="table1">
                <tr>
                    <td>
                        <table border="0" width="100%" cellspacing="0" cellpadding="0" id="table44">
                            <tr>
                                <td bgcolor="#FFFFFF">
                                    <table border="0" height="4" width="100%" cellspacing="0" cellpadding="0" id="table45">
                                        <tr>
                                            <td width="10">
                                                <img border="0" src="img/k-l.gif" width="10" height="24">
                                            </td>
                                            <td background="img/k-g.gif" width="100%">
                                                <table border="0" width="100%" cellspacing="0" cellpadding="0" id="table46">
                                                    <tr>
                                                        <td class="10" swidth="100%">
                                                            <font color="#000080"><b>家园聊天室 沟通你我他</b></font><font color="#E23300"> </font><font
                                                                color="#336699">
                                                                <img border="0" style="vertical-align: middle" src="img/k.gif" width="3" height="24">
                                                            </font>
                                                        </td>
                                                        <td width="">
                                                            <a href="GuestLogin.aspx">嘉宾入口</a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="10">
                                                <img border="0" src="img/k-r.gif" width="10" height="24">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid #95d9fc" bgcolor="#FFFFFF">
                                    <table border="0" width="551" cellspacing="0" cellpadding="0" id="table48">
                                        <tr>
                                            <td width="172">
                                                <p align="center">
                                                    <img border="0" src="img/ncu.jpg">
                                            </td>
                                            <td width="379">
                                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table border="0" width="100%" cellspacing="0" cellpadding="0" id="table50">
                            <tr>
                                <td class="10" style="border-left: 1px solid #95D9FC; border-right: 1px solid #95D9FC;
                                    border-bottom: 1px solid #95D9FC; padding: 10px;" bgcolor="#FFFFFF">
                                    <asp:Panel runat="server" ID="Panel_login">
                                        <table border="0" width="534" cellspacing="0" cellpadding="0" id="table52">
                                            <tr>
                                                <td class="10" width="25">
                                                    <img border="0" src="img/chat.png" width="19" height="19" align="right">
                                                </td>
                                                <td class="10" width="65">
                                                    <p align="center">
                                                        <font color="#666666">昵称：</font>
                                                </td>
                                                <td class="10" width="145">
                                                    <asp:TextBox ID="TextBox_Username" runat="server" style="padding-right: 0px; padding-left: 0px;
                                                        font-weight: normal; font-size: 12px; padding-bottom: 0px; margin: 0px; padding-top: 0px;
                                                        font-style: normal; font-family: Verdana, Arial, Helvetica, sans-serif; list-style-type: none;
                                                        font-variant: normal" size="21" name="UID2" MaxLength="10">
                                                    </asp:TextBox>
                                                </td>
                                                <td class="10" width="10">
                                                    <p align="center">
                                                </td>
                                                <td class="10" width="60">
                                                </td>
                                                <td class="10" width="97">
                                                    <asp:Button ID="Button1" name="B1" runat="server" OnClick="Button1_Click" Text="登陆"
                                                        UseSubmitBehavior="false" />&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </center>
        </form>
    </body>
</html>
