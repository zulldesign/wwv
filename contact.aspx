<%@ Page Title="" Language="VB" MasterPageFile="masterpage.master" AutoEventWireup="false" CodeFile="contact.aspx.vb" Inherits="contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table cellpadding="0" cellspacing="0" style="margin-top:22px;WIDTH: 100%; border-right:solid; border-top:solid;  border-left:solid; border-bottom: solid; border-color:#3399FF; border-width:1px">
        <tr>
            <td style="PADDING-LEFT: 10px; font-style:italic; FONT-WEIGHT: bold; FONT-SIZE: 18px; BACKGROUND: #3399FF; PADDING-BOTTOM: 1px; LINE-HEIGHT: 24px; PADDING-TOP: 3px;  HEIGHT: 9px; color: #FFFFFF;">
                <asp:Label ID="TitleTxt" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="PADDING-LEFT: 10px; PADDING-BOTTOM: 15px; PADDING-TOP: 10px; background-color: #D6EBFF;">
                <table style="WIDTH: 100%">
                    <tr>
                        <td style="  HEIGHT: 26px" >
                            <table style="width: 100%">
								<tr>
									<td style="width: 112px">
                <asp:Label ID="NameTxt" runat="server"></asp:Label>
                                    </td>
									<td style="width: 5px">:</td>
									<td>
									<asp:TextBox style="width:90%" id="IsimTxt" runat="server"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td style="width: 112px">
                <asp:Label ID="MailTxt" runat="server"></asp:Label>
                                    </td>
									<td style="width: 5px">:</td>
									<td>
									<asp:TextBox style="width:90%" id="EmailTxt" runat="server"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td style="width: 112px; vertical-align:top" >
                <asp:Label ID="MessageTxt" runat="server"></asp:Label>
                                    </td>
									<td style="width: 5px; vertical-align:top">:</td>
									<td>
									<asp:TextBox style="width:90%; height:100px" id="MsgTxt" runat="server" 
                                            TextMode="MultiLine"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td style="width: 112px">&nbsp;</td>
									<td style="width: 5px">&nbsp;</td>
									<td>
                                        <asp:Button ID="Button1" runat="server" Text="Send" />
&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="WarnTxt" runat="server"></asp:Label>
                                    </td>
								</tr>
								<tr>
									<td style="width: 112px">&nbsp;</td>
									<td style="width: 5px">&nbsp;</td>
									<td>&nbsp;</td>
								</tr>
								<tr>
									<td style="width: 112px">&nbsp;</td>
									<td style="width: 5px">&nbsp;</td>
									<td>&nbsp;</td>
								</tr>
							</table>
						</td>
                    </tr>
                    </table>
            </td>
        </tr>
    </table>

</asp:Content>

