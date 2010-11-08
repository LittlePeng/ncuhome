<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test-JqueryInput.aspx.cs" Inherits="Test_Test_JqueryInput" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <script src="../Inc/Js/jquery.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input checked="checked" type="checkbox" id="chk" />
        <input  type="button" id="btn" value="btn" onclick="javascript:test()"/>
        <input type="radio" name="radion" value="1" />
        <input type="radio" name="radion" value="3" />
        <input type="radio" name="radion" value="2" />
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
  function test()
  {
    $("input").each(function(i){
       var elem  = $("input").get(i)
       if(elem.type=="radio"&&elem.checked)
       {
            alert(elem.value);
       }
    });
    
    //var ret =($("#chk").get(0));
    alert(ret.checked);
  }  
  
</script>