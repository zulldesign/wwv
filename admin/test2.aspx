<%@ Page Language="VB" AutoEventWireup="false" CodeFile="test2.aspx.vb" Inherits="admin_test2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <script type="text/javascript">
                function uploadComplete() { $get("<%=SaveBtn.ClientID %>").click(); }
            </script>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <cc1:AsyncFileUpload ID="AsyncFileUpload1" runat="server" 
                    CompleteBackColor="Lime" ErrorBackColor="Red" 
                    OnClientUploadComplete="uploadComplete" ThrobberID="Throbber" 
                    UploaderStyle="Modern" UploadingBackColor="#66CCFF" Width="400px" 
                 />
                <asp:Label ID="Throbber" runat="server" Style="display: none">  <img src="images/uploading.gif" align="absmiddle" alt="loading" />  </asp:Label>
                <asp:Button ID="btnShowUploadResult" runat="server" CausesValidation="false"   Text="hidden" Style="display: none" />
                <br />
                <asp:Label ID="ResTxt" runat="server"></asp:Label>
                <br />
                <br />
                <br />
                <asp:ImageButton ID="SaveBtn" runat="server" 
                    ImageUrl="images/register/buttons/save.png" />
            </ContentTemplate>
        </asp:UpdatePanel>       
    </div>
    </form>
</body>
</html>
