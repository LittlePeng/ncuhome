<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test-JqueryAjax.aspx.cs" Inherits="Test_Test_JqueryAjax" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> </title>
    <script src="../Inc/Js/jquery.js" type="text/javascript"></script>
 <script type="text/javascript">
        function GetChat()
        {
            var cnum = document.getElementById("chatNumber").value;
            
            $.ajax({
              url: "../chat.ashx?cid=1&cnum="+cnum+"&mode=public",
              cache: false,
              success: function(html){
              $("#results").replaceWith(html);
              },
              error:function(){
	        
              }
            }); 
            
            //setTimeout("GetChat()",3000);  //刷新时间
        }
      
    </script>
</head>
<body onload="GetChat()">
    <form id="form1" runat="server">
    <div>
        <div id="results"></div>
        <input type="hidden" runat="server" id="chatNumber"/>
    </div>
    </form>
</body>

</html>
