<%@ Page Language="VB" MasterPageFile="masterpage.master" AutoEventWireup="false" CodeFile="article_delete.aspx.vb" Inherits="admin_makale_sil" title="Untitled Page" %>


<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


	<table style="width: 800px">
		<tr>
			<td width="400">
			    <span style="text-decoration: underline"><strong><em>Delete Article<br />
				</em></strong></span><br />
			    Choose the Article:<br />
			    <asp:DropDownList ID="ArticleTxt" runat="server" Width="400px">
                </asp:DropDownList>
			    <br />
			</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>
                <asp:Button ID="Button1" runat="server" Text="Delete" Width="132px" />
                <asp:Label ID="WarnTxt" runat="server"></asp:Label>
            </td>
		</tr>
		<tr>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td>&nbsp;</td>
		</tr>
	</table>





</asp:Content>

