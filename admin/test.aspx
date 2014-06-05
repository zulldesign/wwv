<%@ Page Language="VB" AutoEventWireup="false" CodeFile="test.aspx.vb" Inherits="admin_test" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<link href="images/wpdn-v1,0.css" rel="stylesheet" type="text/css" />



</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    <div>
    
        <asp:Button ID="Button1" runat="server" Text="Button" />
    
        
    
        <br />
        <br />
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <script type="text/javascript">
                    function uploadComplete() { $get("<%=btnShowUploadResult.ClientID %>").click(); }
                   </script>
                <cc1:AsyncFileUpload ID="AsyncFileUpload1" runat="server" 
                    CompleteBackColor="Lime" ErrorBackColor="Red" 
                    OnClientUploadComplete="uploadComplete" ThrobberID="Throbber" 
                    UploaderStyle="Modern" UploadingBackColor="#66CCFF" Width="400px" 
                 />
                <asp:Label ID="Throbber" runat="server" Style="display: none">  <img style=" max-height:30px" src="images/uploading.gif" align="absmiddle" alt="loading" />  </asp:Label>
                <asp:Button ID="btnShowUploadResult" runat="server" CausesValidation="false"   Text="hidden" Style="display: none" />
                <br />
                <asp:Label ID="ResTxt" runat="server"></asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
    
        <br />
    



        <br />
    



    

        <br />

    </div>
    </form>
	</body>
</html>
