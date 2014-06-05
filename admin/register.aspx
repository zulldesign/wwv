<%@ Page Language="VB" AutoEventWireup="false" CodeFile="register.aspx.vb" Inherits="admin_register2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="tr" http-equiv="Content-Language" />
    <title></title>
    
    
    
   
<link rel="stylesheet" href="images/register/style_0.css" type="text/css" media="screen" />
<link rel="stylesheet" href="images/wpdn-v1,0.css" type="text/css" media="screen" />    

<script type="text/javascript" src="images/register/js/bsn.js"></script>
<script type='text/javascript' src='images/register/js/prototype.js'></script>
<script type='text/javascript' src='images/register/js/scriptaculous.js?load=effects'></script>
<script type="text/javascript" src="images/register/js/effects.js"></script>
<script type="text/javascript" src="images/register/js/carousel.js"></script>


<script type="text/javascript" src="images/register/js/jquery-1.4.2.min.js"></script>
<script type="text/javascript" src="images/register/js/jquery.mousewheel-3.0.2.pack.js"></script>
<script type="text/javascript" src="images/register/js/jquery.fancybox-1.3.1.js"></script>
<link rel="stylesheet" href="images/register/js/jquery.fancybox-1.3.1.css" type="text/css"media="screen" />

<script type="text/javascript">
		$(document).ready(function() {
			$("a[rel=lightbox]").fancybox({'width' : '45%',	'height' : '90%','autoScale' : true,	'transitionIn' : 'fadein',	'transitionOut' : 'fadeout','type' : 'iframe'});
			$("a[rel=lightbox2]").fancybox({'width' : '45%',	'height' : '70%','autoScale' : true,	'transitionIn' : 'fadein',	'transitionOut' : 'fadeout','type' : 'iframe'});
			$("a[rel=lightbox3]").fancybox({'width' : '45%',	'height' : '83%','autoScale' : true,	'transitionIn' : 'fadein',	'transitionOut' : 'fadeout','type' : 'iframe'});

		});
</script>



    
    
    
   
</head>
<body style=" background: #dcdcdc">
    <form id="form1" runat="server">
    <div>
    
   




		<table style="width: 100%;  background:#f5f5f5">
			<tr>
				<td style="height: 131px; background-image: url('images/register/herader_back_1.jpg');">
				<table class=" tablo_orta" style="width: 500px">
					<tr>
						<td>
						<img alt="vaox editorial system - earn money" height="54" src="images/register/logo_0.png" width="500" /></td>
					</tr>
				</table>
				</td>
			</tr>
			<tr>
				<td >

				
              
  
                
<div id="content" class="container_16">

	<div class="grid_3" style="height:100px; "></div>
		<div class="grid_10" style="height:140px; ">
			<div class="icons" id="cf1" style="opacity: 0.3;"><img src="images/register/icon1.jpg" /></div>
			<div class="icons" id="cf2" style="opacity: 0.3;"><img src="images/register/icon2.jpg" /> </div>
			<div class="icons" id="cf3" style="opacity: 0.3;"><img src="images/register/icon4.jpg" /></div>
			<div class="icons" id="cf4" style="opacity: 0.3;"><img src="images/register/icon3.jpg" /></div>
        </div>

   	<div class="grid_3" style="height:100px;"></div>
	<div class="clearfix"></div>
	<div class="grid_3" style="height:100px; "></div>
		<div class="grid_10" style="height:140px;">

			<div class="info" id="cf1a" style="opacity: 0.3;">
                <center>
                <h2>DO RESEARCH</h2>
				<p class="note">
                “ Make a research on a topic of your interest, by using all kind of encyclopedias, internet and other sources or just by your own knowledge and experiences. You can write it in any Language!<br /> Keep them in a safe place. ”
                </p>
                </center>
            </div>
			<div class="info" id="cf2a" style="opacity: 0.3;">
            	<center>
                <h2>CREATE YOUR ARTICLE</h2>
                <p class="note">
                “ Enrich your original article with Photos and Videos (That'll give you extra points). <br />When you are done, Send your article right away from VaoX Editor panel.”
                </p>
                </center>

            </div>
			<div class="info" id="cf3a" style="opacity: 0.3;">
            	<center>
                <h2>MAKE PROFIT!</h2>
                <p class="note">
                “ Your article will be evaluated. Accepted articles will be published and you'll see your earnings right away in your editor panel. 
                Withdraw your money to your payment account (Bank via SWIFT/PayPal/MoneyBookers/Neteller) whenever you want!<br />
                Keep writing and producing new ideas. ”
                </p>
                </center>

            </div>
			<div class="info" id="cf4a" style="opacity: 0.3;">
            	<center>
                <h2>SHARE &amp; EARN MORE!</h2>
                <p class="note">
                “ Share your article on Facebook, Twitter, Friendfeed etc. to reach more audience. <br />
                You will also learn extra points by sharing your article. -that means you'll earn more! ”
                </p>
                </center>
            </div>


        </div>
   	<div class="grid_3" style="height:100px; "></div>
    <div class="clearfix"></div>


    <script type="text/javascript">

        var cf = new Crossfader(new Array('cf1', 'cf2', 'cf3', 'cf4'), 700, 8000);
        var cf2 = new Crossfader2(new Array('cf1a', 'cf2a', 'cf3a', 'cf4a'), 700, 8000);
    </script>

				
                
                
                
                
                
                
                </td>
			</tr>
			<tr>
				<td>

				<br />
				    <div class="tablo_orta" style=" border:2px #C0C0C0 solid; margin-bottom: 10px;
             width: 500px; ">

            <table class="tablo_orta "  style="width:500px ">
                <tr>
                    <td class=" login-box-top-td  ">
                        Register</td>
                </tr>
                <tr>
                    <td style="padding-left: 10px; padding-bottom: 15px; padding-top: 10px">
                        <table style="width: 100%">
                            <tr>
                                <td class="login-box-td" style="width: 133px; height: 26px">
                                    Name</td>
                                <td style="height: 26px">
                                    <asp:TextBox ID="MailTxt" runat="server" Width="98%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="login-box-td" style="width: 133px">
                                    Nickname</td>
                                <td>
                                    <asp:TextBox ID="PassTxt" runat="server" TextMode="Password" Width="98%"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="login-box-td" style="width: 133px">
                                    Email</td>
                                <td>
                                    <asp:TextBox ID="PassTxt0" runat="server" TextMode="Password" Width="98%"></asp:TextBox></td>
                            </tr>
							<tr>
                                <td class="login-box-td" style="width: 133px; height: 22px;">
                                    Password</td>
                                <td style="height: 22px">
                                    <asp:TextBox ID="PassTxt1" runat="server" TextMode="Password" Width="98%"></asp:TextBox>
                                    </td>
                            </tr>
							<tr>
                                <td class="login-box-td" style="width: 133px">
                                    Password (again)</td>
                                <td>
                                    <asp:TextBox ID="PassTxt2" runat="server" TextMode="Password" Width="98%"></asp:TextBox></td>
                            </tr>
							<tr>
                                <td class="login-box-td" style="width: 133px; height: 22px;">
                                    </td>
                                <td style="height: 22px">
                                    <img alt="register" height="39" src="images/register/buttons/register.png" width="129" /></td>
                            </tr>
                            <tr>
                                <td style="width: 133px">
                                    &nbsp;</td>
                                <td class=" login-box-td">
                                    <asp:Label ID="WarnTxt" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            </div>
        		<br />
				<br />
				</td>
			</tr>
			<tr>
				<td class="footer ">


				 <table class="tablo_orta" style="width: 600px; font-size:10px; color: #777; font-family:'Lucida Sans Unicode', 'Lucida Grande', sans-serif;  ">
                        <tr>
                            <td>
                                <a class="footera">Privacy Policy</a></td>
                            <td>
                                <a class="footera">Terms &amp; Conditions</a></td>
                            <td>
                                <a class="footera">Help &amp; Contact Us</a></td>
                            <td>
                                <a class="footera">Message Board</a></td>
                            <td>
                                <a class="footera">Advertise</a></td>
                            <td>
                                <a class="footera">Developers API</a></td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="ortala footera" colspan="6">
                                  2011 <span class="footera" style="color:black">eXtreme Computer Software Inc.</span>, All rights reserved.</td>
                        </tr>
                    </table>

				<br />
				<br />
				<br />
				<br />
				<br />
				<br />
				<br />
				<br />
				<br />

				</td>
			</tr>
		</table>
	



    
    
    </div>
    </form>
</body>
</html>
