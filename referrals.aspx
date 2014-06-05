<%@ Page Language="VB" AutoEventWireup="false" CodeFile="referrals.aspx.vb" Inherits="referrals" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="themes/default/css/reset.css" rel="stylesheet" type="text/css" />
    <link href="themes/default/css/wpdn-v1,0.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <asp:Label ID="TopicTxt" runat="server"></asp:Label>
        <br />
        <br />            
        <asp:ListView id="ListView1" runat="server"  OnItemDataBound="ComputeSum"  OnPagePropertiesChanging="PagePropertiesChanging" >
        <LayoutTemplate>
        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
        </LayoutTemplate>
        <ItemTemplate></ItemTemplate>
        </asp:ListView>

        <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1" PageSize="50" QueryStringField="p" >
        <Fields>
        <asp:NextPreviousPagerField ButtonType="Link" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
        <asp:NumericPagerField  ButtonCount="5" />
        <asp:NextPreviousPagerField ButtonType="Link" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
        </Fields>
        </asp:DataPager>


    </div>
    </form>
</body>
</html>
