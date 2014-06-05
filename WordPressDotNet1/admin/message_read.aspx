<%@ Page Language="VB" MasterPageFile="masterpage.master" AutoEventWireup="false" CodeFile="message_read.aspx.vb" Inherits="executive_message_read" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	
    <strong><em><span style="font-size: 18pt; font-family: Arial, Helvetica, sans-serif">
        Mesaj Detayları</span></em></strong>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <table style="width: 45%">
		<tr>
			<td style="width: 86px">
                <strong>Tarih</strong></td>
			<td>
    <asp:Label ID="TarihTxt" runat="server" Font-Bold="False"></asp:Label></td>
		</tr>
		<tr>
			<td style="width: 86px">
                <strong>Gönderen</strong></td>
			<td>
    <asp:Label ID="GonderenTxt" runat="server" Font-Bold="False"></asp:Label></td>
		</tr>
		<tr>
			<td style="width: 86px">
                <strong>Mesaj</strong></td>
			<td>
    <asp:Label ID="MesajTxt" runat="server" Font-Bold="False"></asp:Label></td>
		</tr>
		<tr>
			<td style="width: 86px">&nbsp;</td>
			<td>
                <br />
                <asp:Button ID="Button1" runat="server" BorderStyle="Solid" BorderWidth="1px" Font-Bold="True"
                    Font-Size="10px" Height="20px" Text="Mesajı Sil" /></td>
		</tr>
	</table>
    <br />
    <br />
    &nbsp; &nbsp;<asp:Label ID="GeriTxt" runat="server"></asp:Label><br />
    <br />
    <br />
    </asp:Content>

