<%@ Page Language="VB" MasterPageFile="masterpage.master" AutoEventWireup="false" CodeFile="article_modify.aspx.vb" Inherits="admin_makale_duzenle" title="Untitled Page" ValidateRequest="false"   %>


<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


	<table style="width: 800px">
		<tr>
			<td width="400">
			    <span style="text-decoration: underline"><strong><em>Modify Article<br />
				</em></strong></span><br />
			    Makale Seç:<br />
			    <asp:DropDownList ID="ArticleTxt" runat="server" Width="400px" 
                    AutoPostBack="True">
                </asp:DropDownList>
			    <br />
			Başlık:<br />
			    <asp:TextBox ID="HeadingTxt" runat="server" Width="400px"></asp:TextBox>
			<br />
			Yazar:<br />
			    <asp:TextBox ID="AuthorTxt" runat="server" Width="400px"></asp:TextBox>
			<br />
			Tarih: <br />
			    <asp:TextBox ID="DateTxt" runat="server" Width="400px"></asp:TextBox>
			<br />
			Kagetori:<br />
				<asp:TextBox ID="CategoryTxt" runat="server" Width="400px"></asp:TextBox>
			<br />
			Keywords:<br />
				<asp:TextBox ID="KeywTxt" runat="server" Width="400px"></asp:TextBox>
				<br />
			</td>
		</tr>
		<tr>
			<td>İçerik Özet (İlk sayfa için): 
			<FCKeditorV2:FCKeditor ID="SummaryFCK" runat="server" Height="250px">
            </FCKeditorV2:FCKeditor>



    		    <br />
                İçerik:
			<FCKeditorV2:FCKeditor ID="ContentFCK" runat="server" Height="500px">
            </FCKeditorV2:FCKeditor>



    		</td>
		</tr>
		<tr>
			<td>
                <asp:Button ID="Button1" runat="server" Text="Kaydet" Width="132px" />
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

