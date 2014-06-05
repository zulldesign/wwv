<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CheckSession.aspx.vb" Inherits="admin_KeepAlive2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <div style="  font-family:Georgia; font-size:11px;">
                <asp:Label ID="Label1" runat="server"></asp:Label> </div>
                <asp:Timer ID="Timer1" runat="server" Interval="5000">
                </asp:Timer>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    
    </div>
    </form>
</body>
</html>
