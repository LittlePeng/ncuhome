
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="chat2_test.aspx.cs" Inherits="newpage_chat" %>
<html>

<head runat="server">
<script src="Inc/Js/base.js" type="text/javascript"></script>
<script src="Inc/Js/jquery.js" type="text/javascript"></script>
<script src="Inc/Js/json.js" type="text/javascript"></script>
<script src="Inc/Js/chat2_test.js" type="text/javascript"></script>
 <script type="text/javascript"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>南昌大学家园网 - 聊天室</title>
<link rel="Bookmark" href="http://www.ncuhome.cn/ncuhome.ico">
<link rel="Shortcut Icon" href="http://www.ncuhome.cn/ncuhome.ico">
<link href="http://www.ncuhome.cn/master/default/img/css.css" rel="stylesheet" type="text/css">
<style>
<!--
.STYLE14 {
	color: #000000;
	font-size: 12px;
}
    #ChatContent
    {
        width: 213px;
    }
-->
</style>

<script type="text/javascript">
    function Trim(str) {
        return str.replace(/\s+$|^\s+/g, "");
    }

    function c() {
        var inpcontent = Trim($("#ChatContent").val());

        if (inpcontent.length == 0) {
            alert("不能为空！");
            return false;
        }
        if (inpcontent.length > 500) {
            alert("不能超过500个字符！");
            return false;
        }
        return true;
    }
    function SubmitKeyClick(button) {
        if (event.keyCode == 13) {
            var inpcontent = Trim($("#ChatContent").val());

            if (inpcontent.length == 0) {
                alert("不能超过空字符！");
                return false;
            }
            if (inpcontent.length > 500) {
                alert("不能超过500个字符！");
                return false;
            }
            event.keyCode = 9;
            event.returnValue = false;
            document.all[button].click();
        }
    }
</script>

    
<script for="window" event="onbeforeunload">
if(document.body.clientWidth-event.clientX<15&&event.clientY< 0||event.altKey){
     location.href="logout.aspx";//执行退出登陆的页面
    alert("欢迎再次访问家园聊天室！");
}
</script>
</head>
<body onload="Prepare()" topmargin="0" leftmargin="0" rightmargin="0" bottommargin="0" scroll="auto" >
  <form id="form1" runat="server">
  
<table border="0" width="100%" cellspacing="0" cellpadding="0" id="table1" height="100%" bgcolor="efefef">
	<tr>
		<td style="padding:5px">
		<table border="0" width="100%" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF" height="100%" id="table2">
			<tr>
				<td valign="top">
				<table border="0" height="100%" width="100%" cellspacing="0" cellpadding="0" id="table3">
					<tr>
						<td height="49">

<table border="0" width="100%" cellspacing="0" cellpadding="0" id="table10">
	<tr>
		<td width="10">
		<img border="0" src="pic/top-left.gif" width="10" height="49"></td>
		<td   background="pic/top-bg.gif" width="100%">
		<table border="0" width="100%" cellspacing="0" cellpadding="0" id="table11">
			<tr>
				<td>
		<img border="0" src="pic/logo.gif" width="266" height="49"></td>
			</tr>
		</table>
		</td>
		<td width="10">
		<img border="0" src="pic/top-right.gif" width="10" height="49"></td>
	</tr>
</table>

						</td>
					</tr>
					<tr>
						<td>
				<table border="0" bgcolor="#ffffff" width="100%" cellspacing="0" cellpadding="0" height="100%" id="table6">
					<tr>
						<td width="20%" bgcolor="#ffffff" height="100%" valign="top">
						<table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" id="table7">
							<tr>
								<td bgcolor="#ffffff" valign="top">

		<table border="0" width="100%" cellspacing="0" cellpadding="0" id="table12">
			<tr>
				<td height="4"></td>
			</tr>
			<tr>
				<td  background="pic/left-bg.gif" height="25" valign="middle">
				<table border="0" width="100%" cellspacing="0" cellpadding="0" id="table13">
					<tr>
						<td style="padding-left:5px;padding-top:5px;FILTER: dropshadow(color=#ffffff,offx=1,offy=1)">
						<font color="#336699"><b>本期嘉宾</b> (<span id="OnlineGuestCount"></span>
                            )</font></td>
					</tr>
				</table>
				</td>
			</tr>
			<tr>
				<td style="padding:10px">
				<asp:Panel ID="Panel_GuestList" runat="server" ScrollBars="Auto" Width="100%" Height="130">
        <div id="GuestList"></div>
           </asp:Panel>
				</td>
			</tr>
			<tr>
				<td  background="pic/left-bg.gif" height="25" valign="middle">
				<table border="0" width="100%" cellspacing="0" cellpadding="0" id="table14">
					<tr>
						<td style="padding-left:5px;padding-top:5px;FILTER: dropshadow(color=#ffffff,offx=1,offy=1)">
						<font color="#336699"><b>当前在线</b> (<span id="OnlineUserCount"></span>)</font></td>
					</tr>
				</table>
				</td>
			</tr>
			<tr>
				<td style="padding:8px">
				<asp:Panel ID="Panel_ListBox" runat="server" BackColor="transparent" ScrollBars="Auto" Width="100%" Height="265">
          
           <span color="#333333" >
                   <a  href="javascript:ChangeTalkTo('大家')">大家</a><br />
                    <div id="UserList"></div>
           </span>     
             
           </asp:Panel>
				</td>
			</tr>
			</table>
		</td>
								<td width="9" >
								<table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" id="table9">
														<tr>
															<td background="pic/dot-bg.gif"><img border="0" src="pic/dot.gif" width="9" height="9"></td>
														</tr>
													</table></td>
							</tr>
						</table>
						</td>
						<td style="padding:10px" width="80%" height="100%"  valign="top">
						<table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" id="table15">
							<tr>
								<td>
						<table border="0" width="100%" height="100%" cellspacing="0" cellpadding="0" id="table17">
							<tr>
								<td height="28">
								<table border="0" width="100%" cellspacing="0" cellpadding="0" id="table18">
									<tr>
				<td style="padding-left:10px"  height="28" width="60%">
		<asp:Literal id="Literal_public" runat="server"  Mode="PassThrough"></asp:Literal></td>
				<td height="28" width="20%"><b><font color="#008000"><SCRIPT language=JavaScript>
<!--
var y=new Date();
var gy=y.getYear();
var dName=new Array("周日","周一","周二","周三","周四","周五","周六");
var mName=new Array("1月","2月","3月","4月","5月","6月","7月","8月","9月","10月","11月","12月");
document.write("<FONT  COLOR=\"#009933\">"+y.getFullYear() +"年"+ mName[y.getMonth()] + y.getDate() + "日"  + "　"  + dName[y.getDay()] + "</FONT>");
// -->
</SCRIPT>
		            　</font></b></td>
		   <td height="28" width="20%" style="text-align:right">
                       <asp:Literal ID="UserName" runat="server"></asp:Literal>&nbsp;  <asp:LinkButton ID="LinkButton4" runat="server" OnClick="Button2_Click" Text="退出"></asp:LinkButton></td>
									</tr>
								</table>
								</td>
							</tr>
							<tr>
								<td height="10">

                        <table border="0" height="4" width="100%" cellspacing="0" cellpadding="0" id="table30">
	                        <tr>
		                        <td width="10">
		                        <img border="0" src="pic/k-l.gif" width="10" height="24"></td>
		                        <td background="pic/k-g.gif" width="100%">
		                        <table border="0" width="100%" cellspacing="0" cellpadding="0" id="table31">
			                        <tr>
				                        <td width="100%">
				                        <font color="#336699"><b>公聊窗口&gt; 
				                        <img border="0" style="VERTICAL-ALIGN: middle" src="pic/k.gif" width="3" height="24">
				                        <a href="History.aspx" target="_blank">聊天记录</a></font></td>
				                        <td width="10"></td>
			                        </tr>
		                        </table>
		                        </td>
		                        <td width="10">
		                        <img border="0" src="pic/k-r.gif" width="10" height="24"></td>
	                        </tr>
                        </table>
						</td>
							</tr>
							<tr>
								<td valign="top" style="border: 1px solid #95d9fc"  >
								<table border="0" width="100%" cellspacing="0" cellpadding="0" id="table27" >
									<tr>
						<td valign="top" style=" padding-top:4px; padding-left:8px; padding-bottom:4px" >
						
					
					
						
                  <asp:Panel ID="Panel2" runat="server"  ScrollBars="Auto" Height="235px" >
                         <div id="PublicChatResults"></div>
                </asp:Panel>
 
						</td>
					</tr>
								</table>
								</td>
							</tr>
							<tr>
								<td height="140">
				<table border="0" width="100%" cellspacing="0" cellpadding="0" id="table22">
					<tr>
						<td>

<table border="0" height="4" width="100%" cellspacing="0" cellpadding="0" id="table23">
	<tr>
		<td width="10">
		<img border="0" src="pic/k-l.gif" width="10" height="24"></td>
		<td background="pic/k-g.gif" width="100%">
		<table border="0" width="100%" cellspacing="0" cellpadding="0" id="table24">
			<tr>
				<td style="padding-top:0px" width="100%">
		<table border="0" width="100%" cellspacing="0" cellpadding="0" id="table25">
			<tr>
				<td width="100%">
				<font color="#336699"><b>私聊窗口</b> 
				<img border="0" style="VERTICAL-ALIGN: middle" src="pic/k.gif" width="3" height="24"></font></td>
				<td width="3"></td>
			</tr>
		</table>
				</td>
			</tr>
		</table>
		</td>
		<td width="10">
		<img border="0" src="pic/k-r.gif" width="10" height="24"></td>
	</tr>
</table></td>
		</tr>
			<tr>
				<td style="padding:8px;border: 1px solid #95d9fc">
			
         <asp:Panel ID="Panel3" runat="server" Height="83px" ScrollBars="Auto">
         
         <div id="PrivateChatResults"></div>
    
     </asp:Panel>

     <div id="userID" style="display:none"><asp:Literal ID="liUserID" runat="server" ></asp:Literal></div>
				</td>
					</tr>
				</table>
					</td>
							</tr>
							<tr>
								<td height="69">
								<table border="0" width="100%" cellspacing="0" cellpadding="0" id="table19">
									<tr>
										<td>
				<table border="0" width="100%" cellspacing="0" cellpadding="0" id="table20">
					<tr>
						<td style="padding:10px;border: 1px solid #95d9fc" bgcolor="#EBF5FE">
						<span class="STYLE14">
								    <asp:RadioButtonList ID="RadioButtonList_color" Font-Size="12px" runat="server" RepeatColumns="10" Width="100%"
                                      RepeatDirection="Horizontal">
                                      <asp:ListItem Selected="True" Value="#000000">绝对黑色</asp:ListItem>
                                      <asp:ListItem Value="#0000ff">&lt;font color=&quot;#0000ff&quot;&gt;碧空蓝天&lt;/font&gt;</asp:ListItem>
                                      <asp:ListItem Value="#8000ff">&lt;font color=&quot;#8000ff&quot;&gt;发亮蓝紫&lt;/font&gt;</asp:ListItem>
                                      <asp:ListItem Value="#aa00cc">&lt;font color=&quot;#aa00cc&quot;&gt;紫的拘谨&lt;/font&gt;</asp:ListItem>
                                      <asp:ListItem Value="#ccaa00">&lt;font color=&quot;#ccaa00&quot;&gt;卡布其诺&lt;/font&gt;</asp:ListItem>
                                      <asp:ListItem Value="#ff0000">&lt;font color=&quot;#ff0000&quot;&gt;正宗喜红&lt;/font&gt;</asp:ListItem>
                                      <asp:ListItem Value="#ff0080">&lt;font color=&quot;#ff0080&quot;&gt;爱的暗示&lt;/font&gt;</asp:ListItem>
                                      <asp:ListItem Value="#0080ff">&lt;font color=&quot;#0080ff&quot;&gt;蔚蓝海洋&lt;/font&gt;</asp:ListItem>
                                      <asp:ListItem Value="#008000">&lt;font color=&quot;#008000&quot;&gt;橄榄树绿&lt;/font&gt;</asp:ListItem>
                                  </asp:RadioButtonList>
						<div>

                             
                              <font color="#336699">聊天对象：<asp:Label ID="Sendto" runat="server" Text="大家"></asp:Label>&nbsp;私聊：</font><input type="checkbox" id="isPrivate" />
                        <%--<input id="ChatContent" onkeydown="javascript:SubmitKeyClick('SendInfo')" />--%>
                        <textarea cols="2"  id="ChatContent" style=" width:500px" onkeydown="javascript:SubmitKeyClick('SendInfo')"></textarea>
                      <input onclick="javascript:if(c())SendChatInfo();" type="button" value="发送!" id="SendInfo" />
                       <div style="float:left">
                               
                       </div>
						</div>
						</span></td>
					</tr>
				</table>
										</td>
									</tr>
								</table>
								</td>
							</tr>
						</table>
								</td>
							</tr>
						</table>
						</td>
					</tr>
				</table>
						</td>
					</tr>
					<tr>
						<td height="4"><table border="0" height="4" width="100%" cellspacing="0" cellpadding="0">
	<tr>
		<td width="4">
		<img border="0" src="pic/bottom-let.gif" width="3" height="4"></td>
		<td background="pic/bottom-bg.gif" width="100%" height="4"></td>
		<td width="4">
		<img border="0" src="pic/bottom-rig.gif" width="3" height="4"></td>
	</tr>
</table></td>
					</tr>
				</table>
				</td>
			</tr>
		</table>
        <input type="hidden" runat="server" id="chatNumber"/>
        <input type="hidden" runat="server" id="sender"/>

</form>

</body>

</html>
