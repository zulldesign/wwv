<%@ Page Title="" Language="VB" MasterPageFile="~/admin/masterpage.master" AutoEventWireup="false" CodeFile="test3.aspx.vb" Inherits="admin_test3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <script type="text/javascript">
                function uploadComplete() { $get("<%=SaveBtn2.ClientID %>").click(); }
            </script>
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
                <asp:ImageButton ID="SaveBtn2" runat="server" 
                    ImageUrl="images/register/buttons/save.png" />
            </ContentTemplate>
        </asp:UpdatePanel>  
</asp:Content>

