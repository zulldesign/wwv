<%@ Page Language="VB" MasterPageFile="masterpage.master" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="index"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	
	<asp:Label ID="TopicTxt" runat="server"></asp:Label>
    <br />
    <br />


        <asp:ListView id="ListView1" runat="server"  OnItemDataBound="ComputeSum"  OnPagePropertiesChanging="PagePropertiesChanging" >
        <LayoutTemplate>
        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate></ItemTemplate>
        </asp:ListView>

        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="5" QueryStringField="p" >
        <Fields>
        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
        <asp:NumericPagerField  ButtonCount="5" />
        <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
        </Fields>
        </asp:DataPager>



&nbsp;
</asp:Content>

