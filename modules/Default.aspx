<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="modules_Default" %>


<%@ Register src="ajax-file-upload/file-upload.ascx" tagname="file" tagprefix="uc1" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  
    <form id="form1" runat="server">
     <asp:scriptmanager ID="Scriptmanager1" runat="server"></asp:scriptmanager>
    <uc1:file ID="file1" runat="server" />
   
    </form>
</body>
</html>
