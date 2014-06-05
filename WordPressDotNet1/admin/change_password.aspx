<%@ Page Language="VB" MasterPageFile="masterpage.master" AutoEventWireup="false" CodeFile="change_password.aspx.vb" Inherits="user_sifredegistir" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<a class="saat"><span style="font-size: 18pt">Şifre Değiştir</span></a><br />
    <br />
    <br />
	<table style="width: 100%">
		<tr>
			<td>
                <strong>&nbsp;Eski Şifre:<br />
			</strong>
                <asp:TextBox ID="TextBox1" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
			</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>
                <strong>&nbsp;Yeni Şifre:<br />
			</strong>
                <asp:TextBox ID="TextBox2" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
			</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>Yeni şifrenizi tekrar yazınız..<br />
                <asp:TextBox ID="TextBox3" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
			<br />
			<br />
			<asp:Button ID="Button1" runat="server" BorderStyle="Solid" BorderWidth="1px"
        Font-Bold="True" Text="Kaydet" /></td>
			<td>&nbsp;</td>
		</tr>
	</table>
	<br />
	<br />
</asp:Content>

