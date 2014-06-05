<%@ Page Language="VB" MasterPageFile="masterpage.master" AutoEventWireup="false" CodeFile="search.aspx.vb" Inherits="search" title="Untitled Page" aspcompat=true  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table cellpadding="0" cellspacing="0" style="margin-top:22px;WIDTH: 100%; border-right:solid; border-top:solid;  border-left:solid; border-bottom: solid; border-color:#3399FF; border-width:1px">
        <tr>
            <td style="PADDING-LEFT: 10px; font-style:italic; FONT-WEIGHT: bold; FONT-SIZE: 18px; BACKGROUND: #3399FF; PADDING-BOTTOM: 1px; LINE-HEIGHT: 24px; PADDING-TOP: 3px;  HEIGHT: 9px; color: #FFFFFF;">
                Advanced Search</td>
        </tr>
        <tr>
            <td style="PADDING-LEFT: 10px; PADDING-BOTTOM: 15px; PADDING-TOP: 10px; background-color: #D6EBFF;">
                <table style="WIDTH: 100%">
                    <tr>
                        <td style="  HEIGHT: 26px" >
                        <asp:Panel runat="server" ID="DefButton"  DefaultButton="ImageButton1">
                            <b>Keyword(s)</b> <i>(e.g. &quot;log fire&quot;, boat, &quot;long let&quot;)<br />
                            </i>
                            <asp:TextBox ID="SearchTxt" runat="server" style=" vertical-align:middle" 
                                Width="361px">
                            </asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="ImageButton1" runat="server" alt="Go" height="26" 
                                ImageUrl="themes/default/images/navigation/go.gif" 
                                style="vertical-align:middle" width="60" />
                                </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td style="HEIGHT: 26px">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <asp:Label ID="ResultsTxt" runat="server"></asp:Label>
    <br />
    <br />
    <asp:Label ID="SayfalamaTxt" runat="server"></asp:Label>
    <br />
</asp:Content>

