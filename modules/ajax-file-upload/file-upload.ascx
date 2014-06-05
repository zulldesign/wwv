<%@ Control Language="VB" AutoEventWireup="false" CodeFile="file-upload.ascx.vb" Inherits="modules_file_upload" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>



        <link href="../../css/just-fonts_v1,0.css" rel="stylesheet"     type="text/css" />


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

