<%@ Page Language="VB" MasterPageFile="masterpage.master" AutoEventWireup="false" CodeFile="message_send.aspx.vb" Inherits="executive_message_send" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <strong><em><span style="font-size: 18pt; font-family: Arial, Helvetica, sans-serif">
        Mesaj Gönder</span></em></strong>
        <br />
        <br />
    Mesaj göndermek istediğiniz kullanıcıyı seçiniz..<br />
    <asp:DropDownList ID="DropDownList1" runat="server" Width="320px">
    </asp:DropDownList><br />
    <br />
    Mesajınız:<br />
    <asp:TextBox ID="TextBox1" runat="server" Height="144px" TextMode="MultiLine" Width="312px"></asp:TextBox><br />
    <br />
    <asp:Button ID="Button1" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True"
        Text="Gönder" />
    &nbsp; &nbsp;
    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
</asp:Content>

