<%@ Page Language="VB" MasterPageFile="masterpage.master" AutoEventWireup="false" CodeFile="article_add.aspx.vb" Inherits="admin_makale_ekle" title="Untitled Page" ValidateRequest="false"  %>



<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


	<table style="width: 800px">
		<tr>
			<td width="400">
			    <span style="text-decoration: underline"><strong><em>Add Article<br />
				</em></strong></span><br />
			    Title:<br />
			    <asp:TextBox ID="BaslikTxt" runat="server" Width="400px"></asp:TextBox>
			<br />
			    Writer:<br />
			    <asp:TextBox ID="YazarTxt" runat="server" Width="400px"></asp:TextBox>
			<br />
			    Date: <br />
			    <asp:TextBox ID="TarihTxt" runat="server" Width="400px"></asp:TextBox>
			<br />
			    Category:<br />
			    <asp:DropDownList ID="KategoriTxt" runat="server" Width="400px">
                </asp:DropDownList>
			<br />
			Keywords:<br />
				<asp:TextBox ID="KeywTxt" runat="server" Width="400px"></asp:TextBox>
				<br />
			</td>
		</tr>
		<tr>
			<td>Summary of Article (For the first page): 
			<FCKeditorV2:FCKeditor ID="SummaryFCK" runat="server" Height="250px">
            </FCKeditorV2:FCKeditor>



    		    <br />
                Article:
			<FCKeditorV2:FCKeditor ID="ContentFCK" runat="server" Height="500px">
            </FCKeditorV2:FCKeditor>



    		</td>
		</tr>
		<tr>
			<td>
                <asp:Button ID="Button1" runat="server" Text="Save" Width="132px" />
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

