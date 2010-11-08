<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test-JqueryWebservice.aspx.cs" Inherits="Test_Test_JqueryWebservice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script src="../Inc/Js/jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $.ajax({
            url:"../ChatService.asmx/GetOnlineUserCount",
            cache: false,
            type:"POST",
            data:"{}",
            contentType:"application/json;utf-8",
            success:function(data){
                try
                {
                    json=eval('(' + data + ')');
                }
                catch(e)
                {
                   return;
                }
                //alert(json.d);
            },
            error:function(){}
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input id="input" value="llj098" />
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
function SendChatInfo()
{        
        $.ajax({
            url:"../ChatService.asmx/Test",
            cache: false,
            type:"POST",
            data:"{sender:\"sender\",sendto:\"sendto\",content:\"content\",chatnum:35,isPrivate:\"true\",color:\"red\"}",
            contentType:"application/json;utf-8",
            success:function(data){},
            error:function(){alert('发送超时，请重试');}
        });
}
</script>