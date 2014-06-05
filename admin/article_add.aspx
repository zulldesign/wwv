<%@ Page Language="VB" MasterPageFile="masterpage.master" AutoEventWireup="false" CodeFile="article_add.aspx.vb" Inherits="admin_makale_ekle" title="Untitled Page" ValidateRequest="false"  %>



<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


	
	<table style="width: 100%">
		<tr>
			<td class="mid_box_red" colspan="2" style="height: 30px">
			Add Article

			</td>
		</tr>
		<tr>
			<td valign="top">
			<table style="width: 100%">
				<tr>
					<td style="height: 18px"></td>
					<td style="width:10px; height: 18px;"></td>
				</tr>
				<tr>
					<td>Title:<br />
			    <asp:TextBox ID="TitleTxt" runat="server" Width="99%"></asp:TextBox>
										</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>Article:<FCKeditorV2:FCKeditor ID="ContentFCK" runat="server" Height="500px">
            </FCKeditorV2:FCKeditor>



    				</td>
					<td>&nbsp;</td>
				</tr>
			</table>
<br />



    		</td>
			<td style="width: 300px" valign="top">
			<table style="width: 100%">
				<tr>
					<td>
					
						
						<table   class="mid_box">
							<tr>
								<td  class="mid_box">
								Article Info</td>
							</tr>
							<tr>
								<td style=" padding:5px; padding-bottom:10px;">
								
								
								
						<div  style="width:90&;  overflow:auto; ">

								
								


			    				<table style="width: 100%">
									<tr>
										<td style="width: 50px; height: 18px;">Author</td>
										<td style="height: 18px">
			    <asp:TextBox ID="AuthorTxt" runat="server" Width="97%" Enabled="False"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td>Date</td>
										<td>
			    <asp:TextBox ID="DateTxt" runat="server" Width="97%"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td valign="top">Keywords</td>
										<td>
				<asp:TextBox ID="KeywTxt" runat="server" Width="97%"></asp:TextBox>
										<br />
										(seperate with comma ",")</td>
									</tr>
									<tr>
										<td>&nbsp;</td>
										<td>&nbsp;</td>
									</tr>
									<tr>
										<td>&nbsp;</td>
										<td>
                <asp:Button ID="Button1" runat="server" Text="Save Article" Width="132px" />
                						</td>
									</tr>
									<tr>
										<td>&nbsp;</td>
										<td>
                <asp:Label ID="WarnTxt" runat="server"></asp:Label>
            							</td>
									</tr>
								</table>


						
						
								
								
						</div>
						
						
								
								
								</td>
							</tr>
						</table>
						
						
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>
					
						
						<table   class="mid_box">
							<tr>
								<td  class="mid_box">
								Category</td>
							</tr>
							<tr>
								<td style=" padding:5px; padding-bottom:10px;">
								
								
								
						<div  style="width:90&;  overflow:auto; ">

								
								


			    <asp:ListBox ID="CatList" runat="server" Height="200px" Width="100%">
                </asp:ListBox>


						
						
								
								
						</div>
						
						
								
								
								</td>
							</tr>
						</table>
						
						
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
			</td>
		</tr>
	</table>


	
</asp:Content>

