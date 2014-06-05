<%@ Page Title="" Language="VB" MasterPageFile="masterpage.master" AutoEventWireup="false" CodeFile="categories.aspx.vb" Inherits="admin_categories2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


	
	<table style="width: 100%">
		<tr>
			<td class="mid_box_red" colspan="2" style="height: 30px">
			Categories</td>
		</tr>
		<tr>
			<td valign="top">
			<table style="width: 100%">
				<tr>
					<td style="height: 18px"></td>
					<td style="width:10px; height: 18px;"></td>
				</tr>
				<tr>
					<td>Parent Category<br />

								
								

			    <asp:ListBox ID="CatList" runat="server" Height="200px" Width="100%">
                </asp:ListBox>


						
						
								
								
						<br />
										</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td style="text-align:right">
                <asp:Button ID="Button2" runat="server" Text="Delete Selected" Width="132px" />



    		    	</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>Category Name:<br />
			    <asp:TextBox ID="CatName" runat="server" Width="99%"></asp:TextBox>



    		    	</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>Category Description:<br />
			    <asp:TextBox ID="CatDesc" runat="server" Width="99%"></asp:TextBox>



    		    	</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>Category Keywords:<br />
			    <asp:TextBox ID="CatKeyw" runat="server" Width="99%"></asp:TextBox>



    		    	</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
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
								Category Info</td>
							</tr>
							<tr>
								<td style=" padding:5px; padding-bottom:10px;">
								
								
								
						<div  style="width:90&;  overflow:auto; ">

								
								


			    				<table style="width: 100%">
									<tr>
										<td style="width: 50px; height: 18px;">&nbsp;</td>
										<td style="height: 18px">
			                                &nbsp;</td>
									</tr>
									<tr>
										<td>&nbsp;</td>
										<td>
                <asp:Button ID="Button1" runat="server" Text="Save Category" Width="132px" />
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
					
						
						&nbsp;</td>
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

