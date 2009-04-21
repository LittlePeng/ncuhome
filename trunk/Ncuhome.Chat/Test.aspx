<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        &nbsp; &nbsp; &nbsp;
    
    </div>
        &nbsp; &nbsp; &nbsp;&nbsp;<br />
        <asp:Timer ID="Timer1" runat="server" Interval="6000">
        </asp:Timer>
        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress1"
         runat="server" 
         AssociatedUpdatePanelID="UpdatePanel1" DynamicLayout="False" 
          EnableViewState="False">
            <ProgressTemplate>
                .... .............
                <br />
                .... .............
                <br />
                .... .............
                <br />
                .... .............
            </ProgressTemplate>
            
        </asp:UpdateProgress>
    </form>
</body>
</html>
