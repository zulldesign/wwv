﻿<%@ Page Language="VB" MasterPageFile="masterpage.master" AutoEventWireup="false" CodeFile="article.aspx.vb" Inherits="admin_makale_ekle" title="Untitled Page" ValidateRequest="false"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>



<%@ Register src="../modules/ajax-file-upload/file-upload.ascx" tagname="file" tagprefix="uc2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="images/wpdn-v1,0.css" rel="stylesheet" type="text/css" />

	
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
					<td style="height: 18px">
					<table style="width: 100%">
						<tr>
							<td  style=" vertical-align:top; width:100px">Title:</td>
							<td>
			    <asp:TextBox class="input_text" ID="TitleTxt" runat="server" Width="99%"></asp:TextBox>
										</td>
						</tr>
						<tr>
							<td style=" vertical-align:top; height: 18px">Keywords:</td>
							<td style="height: 18px">
			    	<asp:TextBox class="input_text" ID="KeywTxt" runat="server" Width="99%"></asp:TextBox>
										<br />
										(seperate with comma "," | must be at 
							least 3 keywords)</td>
						</tr>
						<tr>
							<td valign="top">Article</td>
							<td>
			    	<asp:TextBox class="input_text" style="height:300px" ID="ArticleTxt"  runat="server" 
                                    Width="99%" TextMode="MultiLine"></asp:TextBox>
										</td>
						</tr>
						<tr>
							<td valign="top">Video Link</td>
							<td>
			    	<asp:TextBox class="input_text" ID="KeywTxt0" runat="server" Width="99%"></asp:TextBox>
										</td>
						</tr>
						<tr>
							<td valign="top">Images</td>
							<td>
			    	            
            
                                
                            
                            
                  
                            
                            
                            
                                        
                            
                            
                                <uc2:file ID="file1" runat="server" />
			    			
                            
                            
                            
                            
                  
                            
                            
                            
                                        
                            
                            
                            </td>
						</tr>
						<tr>
							<td valign="top">&nbsp;</td>
							<td>
			    			&nbsp;</td>
						</tr>
						<tr>
							<td valign="top">&nbsp;</td>
							<td>
			    			
                            
                            
                            
                            
                  
                            
                            
                            
                                        
                            
                            
                                &nbsp;</td>
						</tr>
						</table>
					</td>
					<td style="width:10px; height: 18px;"></td>
				</tr>
				<tr>
					<td>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />


                        
         



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
										<td style="width: 70px; height: 18px;">Author</td>
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
										<td valign="top">Language</td>
										<td>
										<asp:DropDownList Width="97%" id="DropDownList1" runat="server">
										</asp:DropDownList>
										<br />
										</td>
									</tr>
									<tr>
										<td>&nbsp;</td>
										<td>&nbsp;</td>
									</tr>
									<tr>
										<td>Save Type</td>
										<td>
										<asp:DropDownList Width="97%" id="SaveTypeTxt" runat="server">
										</asp:DropDownList>
                						</td>
									</tr>
									<tr>
										<td>&nbsp;</td>
										<td>
                						    <asp:ImageButton ID="SaveBtn" runat="server" 
                                                ImageUrl="images/register/buttons/save.png" />
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
								
								
								
						<div  style="width:98%;  overflow:auto; ">

								
								


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
					<td>
					
						
						<table   class="mid_box">
							<tr>
								<td  class="mid_box">
								Calculate Estimated Rating Points</td>
							</tr>
							<tr>
								<td style=" padding:5px; padding-bottom:10px;">
								
								
								
								<asp:CheckBox id="CheckBox1" runat="server" Text="Is your article original?"  />
								<br />
								
								
								
								<asp:CheckBox id="CheckBox2" runat="server" Text="Is your article original?"  />
								<br />
								<br />
								<br />
								Estimated Rating: </td>
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
			</table>
			</td>
		</tr>
	</table>


	
</asp:Content>

