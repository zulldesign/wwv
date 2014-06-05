<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="admin_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/just-fonts_v1,0.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    	<table align="center" style="width: 500px">
			<tr>
				<td>
				
				<br /><br /><br /><br />
				
				
				
    <div style="border-right: #d3dbeb 2px solid; border-top: #d3dbeb 2px solid; margin-bottom: 10px;
            border-left: #d3dbeb 2px solid; width: 500px; border-bottom: #d3dbeb 2px solid">
            <table cellpadding="0" cellspacing="0" style="width: 100%; ">
                <tr>
                    <td style=" font-style:italic; padding-left: 10px; font-weight: bold; font-size: 18px; background: #f5f8fb;
                        padding-bottom: 1px; line-height: 24px; padding-top: 3px; height: 9px">
                        User Login</td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-bottom: 15px; padding-top: 10px">
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 133px; height: 26px">
                                    Email</td>
                                <td style="height: 26px">
                                    <asp:TextBox ID="MailTxt" runat="server" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 133px">
                                    Password</td>
                                <td>
                                    <asp:TextBox ID="PassTxt" runat="server" TextMode="Password" Width="200px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td style="width: 133px">
                                </td>
                                <td>
                                    <asp:Button CssClass="trebuchet" ID="LoginTxt" runat="server" Text="Login" />
                                    </td>
                            </tr>
                            <tr>
                                <td style="width: 133px">
                                    &nbsp;</td>
                                <td>
                                    <asp:Label ID="WarnTxt" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
				
				
				
				
				
				</td>
			</tr>
		</table>
    </form>
</body>
</html>
