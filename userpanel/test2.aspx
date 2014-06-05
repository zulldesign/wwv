<%@ Page Title="" Language="VB" MasterPageFile="~/userpanel/masterpage2.master" AutoEventWireup="false" CodeFile="test2.aspx.vb" Inherits="userpanel_test2" %>

<%@ Register src="../modules/ajax-file-upload/file-upload.ascx" tagname="file" tagprefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:file ID="file1" runat="server" />
    <br />
    <br />
    
</asp:Content>

