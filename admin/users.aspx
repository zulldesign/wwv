<%@ Page Title="" Language="VB" MasterPageFile="~/admin/masterpage.master" AutoEventWireup="false" CodeFile="users.aspx.vb" Inherits="admin_users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        Users List<br />
        <br />
        <asp:ListBox ID="ListBox1" runat="server" Height="251px" Width="577px">
        </asp:ListBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Update Admin" />
    </p>
</asp:Content>

