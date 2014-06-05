<%@ Page Language="VB" AutoEventWireup="false" CodeFile="index.aspx.vb" Inherits="admin_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/just-fonts_v1,0.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="border-right: #d3dbeb 2px solid; border-top: #d3dbeb 2px solid; margin-bottom: 10px;
            border-left: #d3dbeb 2px solid; width: 500px; border-bottom: #d3dbeb 2px solid">
            <table cellpadding="0" cellspacing="0" style="width: 100%; ">
                <tr>
                    <td style=" font-style:italic; padding-left: 10px; font-weight: bold; font-size: 18px; background: #f5f8fb;
                        padding-bottom: 1px; line-height: 24px; padding-top: 3px; height: 9px">
                        Admin Login</td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-bottom: 15px; padding-top: 10px">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 133px; height: 26px">
                                    Username:</td>
                                <td style="height: 26px">
                                    <asp:TextBox ID="KullTxt" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 133px">
                                    Pass:</td>
                                <td>
                                    <asp:TextBox ID="SifreTxt" runat="server" TextMode="Password" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 133px">
                                </td>
                                <td>
                                    <asp:Button CssClass="trebuchet" ID="Button3" runat="server" Text="Login" />
                                    <asp:Label ID="Label2" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
