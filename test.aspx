<%@ Page Language="VB" AutoEventWireup="false" CodeFile="test.aspx.vb" Inherits="test" ValidateRequest="false"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta content="tr" http-equiv="Content-Language" />
    <title>Untitled Page</title>




    <link type="text/css" rel="stylesheet" href="scripts/syntaxhighlighter/styles/shCoreDefault.css"/>
	<script type="text/javascript" src="scripts/syntaxhighlighter/scripts/shCore.js"></script>


	<script type="text/javascript" src="scripts/syntaxhighlighter/scripts/shBrushJScript.js"></script>
    <script type="text/javascript" src="scripts/syntaxhighlighter/scripts/shBrushAppleScript.js"></script>
    <script type="text/javascript" src="scripts/syntaxhighlighter/scripts/shBrushCpp.js"></script>
    <script type="text/javascript" src="scripts/syntaxhighlighter/scripts/shBrushCSharp.js"></script>
    <script type="text/javascript" src="scripts/syntaxhighlighter/scripts/shBrushCss.js"></script>
    <script type="text/javascript" src="scripts/syntaxhighlighter/scripts/shBrushJava.js"></script>
    <script type="text/javascript" src="scripts/syntaxhighlighter/scripts/shBrushPhp.js"></script>
    <script type="text/javascript" src="scripts/syntaxhighlighter/scripts/shBrushPython.js"></script>
    <script type="text/javascript" src="scripts/syntaxhighlighter/scripts/shBrushRuby.js"></script>
    <script type="text/javascript" src="scripts/syntaxhighlighter/scripts/shBrushSql.js"></script>
    <script type="text/javascript" src="scripts/syntaxhighlighter/scripts/shBrushVb.js"></script>
    <script type="text/javascript" src="scripts/syntaxhighlighter/scripts/shBrushXml.js"></script>

	<script type="text/javascript">	    SyntaxHighlighter.all();</script>



       

</head>
<body>
    <form id="form1" runat="server">
    <asp:TextBox ID="TextBox1" runat="server" Height="212px" TextMode="MultiLine" 
        Width="394px"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Button" />
    <asp:Button ID="Button2" runat="server" Text="Regex" />
    &nbsp;
    <asp:Button ID="Button5" runat="server" Text="GetDataFromWeb" />
    <br />
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


    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="Button3" runat="server" Text="DataSet" />
    <asp:Button ID="Button4" runat="server" Text="DataReader" />
    <asp:Button ID="Button6" runat="server" Text="HtmlEncode" />
    <br />
    <br />
    </form>
    </body>
</html>
