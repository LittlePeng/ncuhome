<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewChat.aspx.cs" Inherits="ChatAdmin_NewChat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>聊天室审核</title>
    <script src="../Inc/Js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
   
     function LoadM()
     {
      //调取信息
            $.ajax({
              url: "ChatList.ashx",
              cache: false,
              success: function(msg){   
              //alert("1"); 
              document.getElementById("info").innerHTML=msg;          
              //$("#info").html(msg);
              },
             error:function(){
	                alert('error GetList');
              }
            });    
            setTimeout("LoadM()",5000); 
     
     }
    
    </script>
 <script type="text/javascript" src="../Inc/Js/check.js"></script>
<style type="text/css">
body{ font-size:12px;}
</style>
</head>
<body>
   
    <div id="info">  </div>
   
 <input type="hidden" id="cid" runat="server" />
<iframe src="OnlineUserHelper.aspx" width="0" height="0"></iframe> 
</body>
</html>
<script type="text/javascript">LoadM();</script>
