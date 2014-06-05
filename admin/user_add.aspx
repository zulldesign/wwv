<%@ Page Title="" Language="VB" MasterPageFile="masterpage.master" AutoEventWireup="false" CodeFile="user_add.aspx.vb" Inherits="admin_user_add" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


	
	<table style="width: 100%">
		<tr>
			<td class="mid_box_red" colspan="2" style="height: 30px">
			Add User</td>
		</tr>
		<tr>
			<td valign="top">
			<table style="width: 100%">
				<tr>
					<td style="height: 18px"></td>
					<td style="width:10px; height: 18px;"></td>
				</tr>
				<tr>
					<td>Name:<br />
			    <asp:TextBox ID="NameTxt" runat="server" Width="99%"></asp:TextBox>
										</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>Nick Name:<br />
			    <asp:TextBox ID="NickTxt" runat="server" Width="99%"></asp:TextBox>



    		    	</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>Email:<br />
			    <asp:TextBox ID="EmailTxt" runat="server" Width="99%"></asp:TextBox>



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
			</table>



    		</td>
			<td style="width: 300px" valign="top">
			<table style="width: 100%">
				<tr>
					<td>
					
						
						<table   class="mid_box">
							<tr>
								<td  class="mid_box">
								User Info</td>
							</tr>
							<tr>
								<td style=" padding:5px; padding-bottom:10px;">
								
								
								
						<div  style="width:90&;  overflow:auto; ">

								
								


			    				<table style="width: 100%">
									<tr>
										<td style="width: 50px; height: 18px;">Role</td>
										<td style="height: 18px">
			                                <asp:DropDownList ID="RoleTxt" runat="server" Width="97%">
                                            </asp:DropDownList>
										</td>
									</tr>
									<tr>
										<td>Password</td>
										<td>
			    <asp:TextBox ID="PassTxt" runat="server" Width="97%" TextMode="Password"></asp:TextBox>
										</td>
									</tr>
									<tr>
										<td valign="top">&nbsp;</td>
										<td>
										<br />
										</td>
									</tr>
									<tr>
										<td>&nbsp;</td>
										<td>
                <asp:Button ID="Button1" runat="server" Text="Save User" Width="132px" />
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

