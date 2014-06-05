<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="executive_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" xmlns:v="urn:schemas-microsoft-com:vml" xmlns:o="urn:schemas-microsoft-com:office:office" >
<head runat="server">
    <meta http-equiv="Content-Language" content="tr" />
    <title>Untitled Page</title>
    <link href="../executive/default.css" rel="stylesheet" type="text/css" />
    <link href="../iiygportal/default.css" rel="stylesheet" type="text/css" />
</head>
<body style="margin-top:0px;margin-left:0px">
    <form id="form1" runat="server">
<p style="font-size: xx-large">
<img alt="" src="images/BANNER.gif" width="1216" height="90" /></p>
        <p style="text-align: right">
            <font size="-1">
&nbsp;<a target="_blank" href="http://projett.turktelekom.com.tr">ProjeTT</a> -
<a  target="_blank" href="http://212.175.9.136/itg/dashboard/app/portal/PageView.jsp">ProjeBT</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </font></p>

            <table align="center" cellpadding="0" cellspacing="0" style="width: 400px; border: 2px solid #d3dbeb; margin-bottom: 10px;             font-family: Arial, Lucida Grande, Lucida Sans Unicode, Bitstream Vera Sans, Verdana, Futura, Helvetica, sans-serif">
                <tr>
                    <td style="padding-left: 10px; font-weight: bold; font-size: 18px; background: #f5f8fb;
                        padding-bottom: 1px; line-height: 24px; padding-top: 3px; font-family: Arial, Lucida Grande, Lucida Sans Unicode, Bitstream Vera Sans, Verdana, Futura, Helvetica, sans-serif;
                        height: 9px; text-align: center;">
                        Hoşgeldiniz</td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-bottom: 15px; padding-top: 10px">
                        <table style="width: 98%">
							<tr>
								<td>Kullanıcı Adı:</td>
								<td>
                                    <asp:TextBox ID="TextBox1" runat="server" Width="98%"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>Şifre:</td>
								<td>
                                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="98%"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td >
								<div style="text-align:right;">
                                    <asp:Button  ID="Button1" runat="server" Text="Giriş" Width="101px" />
                                 </div>
                                </td>
							</tr>
							<tr>
								<td>&nbsp;</td>
								<td>
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                    </td>
							</tr>
						</table>
                    </td>
                </tr>
            </table>

    </form>
	
	<p>&nbsp;</p>
<p style="text-align: center"><font size="-1">
<a target="_blank" href="http://www.turktelekom.com.tr">Türk Telekom Kurumsal Sitesi</a> -
<a target="_blank" href="http://ilettisim">İlettişim Portalı</a> -
<a target="_blank" href="http://btportal">BT Portal</a> -
<a target="_blank" href="#">Merkezi Raporlama Portalı</a></font><br />
<br />

<font size="-1">
<a target="_blank" href="http://www.avea.com.tr">Avea</a> -
<a target="_blank"  href="http://www.ttnet.com.tr">TTNet</a> -
<a target="_blank"  href="http://www.innova.com.tr">Innova</a> -

<a target="_blank"  href="http://www.argela.com">Argela</a> -
<a target="_blank"  href="http://www.assistt.com.tr">AssisTT</a> -
<a target="_blank"  href="http://www.sobee.com.tr">Sobee</a> -
<a target="_blank"  href="http://www.sebit.com.tr">Sebit</a> 



</font></p>
	
</body>
</html>
