﻿<%@ Page Language="VB" MasterPageFile="masterpage.master" AutoEventWireup="false" CodeFile="portal_settings.aspx.vb" Inherits="admin_portal_settings2" title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


        <br />


        <table style="width: 44%">
			<tr>
				<td style="width: 309px"><span style="text-decoration: underline"><strong><em>
                    Configurations<br />
				</em></strong></span>
                    <br />
    

        <asp:ListBox ID="CatList" runat="server" Height="240px" Width="472px"></asp:ListBox>
                    <br />
        <asp:Button CssClass="trebuchet" ID="Button1" runat="server" Text="Delete Selected" 
                        Enabled="False" />&nbsp;
        <asp:Label ID="Label1" runat="server"></asp:Label>
                    <br />
            	</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td style="width: 309px">Name of Config: 
        <asp:Label ID="CatIDTxt" runat="server"></asp:Label> <br />
            <asp:TextBox ID="CatName" runat="server" Width="450px"></asp:TextBox>
            	    <br />
            	</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td style="width: 309px">Value of Config: <br />
            <asp:TextBox ID="CatDesc" runat="server" Width="450px" Height="88px" 
                        TextMode="MultiLine"></asp:TextBox>
            	</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td style="width: 309px">&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td style="width: 309px">
        
        
        
        <asp:Button CssClass="trebuchet" ID="Button2" runat="server" Text="Add / Modify Selected" />
				</td>
				<td>
        
        
        
        <asp:Button CssClass="trebuchet" ID="Button4" runat="server" Text="New" />
				</td>
			</tr>
			<tr>
				<td style="width: 309px">&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
		</table>
		<br />
		<br />
		<br />
        <br />
        <br />

        

</asp:Content>

