Imports Microsoft.VisualBasic

Public Class wpdn_v10




    Public Const MyDBConfPath = "|DataDirectory|ex_conf.mdb"
    Public Const MyDBDataPath = "|DataDirectory|ex_data_2013.01.18.mdb" 'make
    Public Const MyDBDataToPath = ""
    Public Const MyDBUserDataPath = "|DataDirectory|ex_user_data_2013.01.17.mdb"
    Public Const MyDBPass = "extremeteam"

    Public Const MyAdSenseID = "6897003821103945" 'nslhnbal
    Public Const MyAdSenseAdSlotAFS = "6747225122" 'ex.gen.tr (AFS)
    Public Const MyAdSenseAdSlot1 = "9922311121" 'ex.gen.tr (728x90)
    Public Const MyAdSenseAdSlot2 = "2399044326" 'ex.gen.tr (25ox25o)
    Public Const MyAdSenseAdSlotInTopic = "3875777529" 'ex.gen.tr (336x28o)



    Public Const MySite = "ex.gen.tr"
    Public Const PreTopicForURL = "konu/" 'recipes/ID/Cat-SubCat
    Public Const PreTopicForArticle = ""
    Public Const PostTopicForArticle = "<br /><strong>En hızlı</strong> ve <strong>kolay</strong> yoldan <strong>direkt bilgi kaynağınız</strong>. <br />" 'recipes/ID/Cat-SubCat
    Public Const IntroLen As Integer = 6000 'Short version of Content 
    Public Shared SayyacSTR = Sayyac("www.ex.gen.tr", "exgentr")
    Public Const KeywSloMod = "ON"
    Public Const KeywSlogan = "<h2>[KW]</h2> : <strong>En hızlı</strong> ve <strong>kolay</strong> yoldan <strong>direkt bilgi kaynağınız</strong>. Aynen şunun gibi: <h2>[KW]</h2>! <strong><em>[KW]</em></strong> hakkında bilgi, <strong><em>[KW]</em></strong> hakkında sözler, <strong><em>[KW]</em></strong> nedir, <strong><em>[KW]</em></strong> ne değildir, <strong><em>[KW]</em></strong> nasıl olur ve <strong><em>[KW]</em></strong> hakkında her türlü faydalı içeriğe sitemiz aracılığıyla ulaşabileceksiniz!  <br />" 'recipes/ID/Cat-SubCat
    Public Const SearchSloMod = "ON"
    Public Const SearchSlogan = "<h2>[TAG]</h2> : Bu sayfaya Google arama sonucu olan: <h2>[TAG]</h2> ile geldiniz.  <strong><em>[TAG]</em></strong> hakkında bilgi, <strong><em>[TAG]</em></strong> hakkında sözler, <strong><em>[TAG]</em></strong> nedir, <strong><em>[TAG]</em></strong> ne değildir, <strong><em>[TAG]</em></strong> nasıl olur ve <strong><em>[TAG]</em></strong> hakkında her türlü faydalı içeriğe sitemiz aracılığıyla ulaşabileceksiniz!"
    Public Const DBtoCount = 20


    Public Const MixedContent = "no"
    Public Const ExternalImages = "no"
    Public Const ExternalVideo = "no"
    Public Const ShowDummyVideo = "no"
    Public Const RssTitle = "eX.gen.tr - Bir başka bilgi kaynağı!"
    Public Shared UserImgPath As String = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath & "userfiles\images\"
    'Public Const ShowFullScreenFlashBG = "1.jpg,2.jpg,3.jpg,4.jpg,5.jpg,6.jpg,7.jpg,8.jpg,9.jpg,10.jpg,11.jpg,12.jpg"
    Public Const ShowFullScreenFlashBG = ""

    Public Const GoogleAnalytics = "<script>  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');  ga('create', 'UA-41630281-1', 'ex.gen.tr');  ga('send', 'pageview');</script>"


    'Public Const MyDBConfPath = "|DataDirectory|pz_conf.mdb"
    'Public Const MyDBDataPath = "|DataDirectory|pz_data_2013.01.18.mdb" 'make
    'Public Const MyDBDataToPath = ""
    'Public Const MyDBUserDataPath = "|DataDirectory|pz_user_data_2013.01.17.mdb"
    'Public Const MyDBPass = "extremeteam"

    'Public Const MyAdSenseID = "6897003821103945" 'nslhnbal
    'Public Const MyAdSenseAdSlotAFS = "2719042323" 'programmerz.net (AFS)
    'Public Const MyAdSenseAdSlot1 = "4335376323" 'programmerz.net (728x90)
    'Public Const MyAdSenseAdSlot2 = "2858643122" 'programmerz.net(25ox25o)
    'Public Const MyAdSenseAdSlotInTopic = "5812109527" 'programmerz.net(336x28o)

    'Public Const MySite = "programmerz.net"
    'Public Const PreTopicForURL = "pz/" 'recipes/ID/Cat-SubCat
    'Public Const PreTopicForArticle = ""
    'Public Const PostTopicForArticle = "<br />Your source of best, simple, original informations of all environments and <strong>programming languages</strong>. <br />" 'recipes/ID/Cat-SubCat
    'Public Const IntroLen As Integer = 6000 'Short version of Content 
    'Public Shared SayyacSTR = Sayyac("www.programmerz.net", "programmerz")
    'Public Const KeywSloMod = "ON"
    'Public Const KeywSlogan = "<h2>[KW]</h2> : ProgrammerZ.net Broughts you the solutions as well as <h2>[KW]</h2>! You're sure to find the <strong>best programming solutions</strong> for <strong><em>[KW]</em></strong>. <br />" 'recipes/ID/Cat-SubCat
    'Public Const SearchSloMod = "ON"
    'Public Const SearchSlogan = "<h2>[TAG]</h2> : You've come to this page through Google search with the syntax: <h2>[TAG]</h2>. You'll find relevant informations and suggestions about <strong><em>[TAG]</em></strong> in this page."
    'Public Const DBtoCount = 20

    'Public Const MixedContent = "no"
    'Public Const ExternalImages = "no"
    'Public Const ExternalVideo = "no"
    'Public Const ShowDummyVideo = "no"
    'Public Const RssTitle = "ProgrammerZ.net - Hottest programming solutions!"
    'Public Shared UserImgPath As String = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath & "userfiles\images\"
    ''Public Const ShowFullScreenFlashBG = "1.jpg,2.jpg,3.jpg,4.jpg,5.jpg,6.jpg,7.jpg,8.jpg,9.jpg,10.jpg,11.jpg,12.jpg"
    'Public Const ShowFullScreenFlashBG = ""



    'Public Const MyAdSenseID = "6897003821103945" 'nslhnbal
    'Public Const MyDBConfPath = "|DataDirectory|vaox_conf.mdb"
    'Public Const MyDBDataPath = "|DataDirectory|vaox_data_2011.12.12.mdb" 'make
    'Public Const MyDBDataToPath = "|DataDirectory|vaox_data_to_2011.10.14.mdb"
    'Public Const MyDBUserDataPath = "|DataDirectory|vaox_user_data_2011.12.12.mdb"

    'Public Const MyDBPass = "extremeteam"
    'Public Const MyAdSenseAdSlotAFS = "3439324487" 'vaox.net (AFS)
    'Public Const MyAdSenseAdSlot1 = "8244928916" 'vaox.net (728x90)
    'Public Const MyAdSenseAdSlot2 = "9921190438" 'vaox.net (25ox25o)
    'Public Const MyAdSenseAdSlotInTopic = "3152020956" 'vaox.net (336x280)
    'Public Const MySite = "vaox.net"
    'Public Const PreTopicForURL = "portal/" '/ID/Cat-SubCat
    'Public Const PreTopicForArticle = ""
    'Public Const PostTopicForArticle = "<br />Brought to you by VaoX Portal!<br />"
    'Public Const IntroLen As Integer = 500 'Short version of Content 
    'Public Shared SayyacSTR = Sayyac("www.vaox.net", "vaox")
    'Public Const KeywSloMod = "ON"
    'Public Const KeywSlogan = "Brought to you by VaoX Portal! <strong><em>[KW]</em></strong> <br />"
    'Public Const SearchSloMod = "ON"
    'Public Const SearchSlogan = "<strong><em>[TAG]</em></strong> : You've come to this page through Google search with the syntax: <h2>[TAG]</h2>. You'll find relevant informations about <h2>[TAG]</h2> in this page."
    'Public Const DBtoCount = 10
    'Public Const MixedContent = "no"
    'Public Const ExternalImages = "no"
    'Public Const ExternalVideo = "no"
    'Public Const RssTitle = "VaoX Portal - Hottest Picks!"
    'Public Shared UserImgPath As String = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath & "userpanel\userfiles\images\"



    'Public Const MyAdSenseID = "6897003821103945" 'nslhnbal
    'Public Const MyDBConfPath = "|DataDirectory|br_conf.mdb"
    'Public Const MyDBDataPath = "|DataDirectory|br_data_2012.03.25.mdb"
    'Public Const MyDBDataToPath = "|DataDirectory|vaox_data_to_2011.10.14.mdb" 'no need for hc
    'Public Const MyDBPass = "extremeteam"

    'Public Const MyAdSenseAdSlotAFS = "9391375522" 'bestrecipes1.com (AFS)
    'Public Const MyAdSenseAdSlot1 = "6372234571" 'bestrecipes1.com (728x90)
    'Public Const MyAdSenseAdSlot2 = "2987703459" 'bestrecipes1.com (25ox25o)
    'Public Const MyAdSenseAdSlotInTopic = "0813289285" 'bestrecipes1.com (336x280)
    'Public Const MySite = "bestrecipes1.com"
    'Public Const PreTopicForURL = "recipe/" 'recipes/ID/Cat-SubCat
    'Public Const PreTopicForArticle = ""
    'Public Const PostTopicForArticle = "<br />BestRecipes1.com Broughts you the Number 1 recipes all around the World! You're sure to find the perfect dish. <br />" 'recipes/ID/Cat-SubCat
    'Public Const IntroLen As Integer = 500 'Short version of Content 
    'Public Shared SayyacSTR = Sayyac("www.bestrecipes1.com", "bestrecipes1")
    'Public Const KeywSloMod = "ON"
    'Public Const KeywSlogan = "<span style=""color:black;background-color: yellow""><strong><em>[KW]</span></em></strong></span> : BestRecipes1.com Broughts you the Best Number 1 recipes from All around the World like <span style=""color:black;background-color: yellow""><strong><em>[KW]</em></strong></span>! You're sure to find the <strong>best recipes</strong> for <span style=""color:black;background-color: yellow""><strong><em>[KW]</em></strong></span>. <br />" 'recipes/ID/Cat-SubCat
    'Public Const SearchSloMod = "ON"
    'Public Const SearchSlogan = "<span style=""color:black;background-color: yellow""><strong><em>[TAG]</em></strong></span> : You've come to this page through Google search with the syntax: <span style=""color:black;background-color: yellow""><strong><em>[TAG]</em></strong></span>. You'll find relevant informations, recipes and cooking suggestions about <span style=""color:black;background-color: yellow""><strong><em>[TAG]</em></strong></span> in this page."
    'Public Const DBtoCount = 20
    'Public Const MixedContent = "yes"
    'Public Const ExternalImages = "yes"
    'Public Const ExternalVideo = "yes"
    'Public Const RssTitle = "BestRecipes1.com - Hottest Recipes All Around the World!"



    'Public Const MyAdSenseID = "7699795735814589" 'balgkhn
    'Public Const MyDBConfPath = "|DataDirectory|pz_conf.mdb"
    'Public Const MyDBDataPath = "|DataDirectory|pz_data_2011.12.12.mdb"
    'Public Const MyDBDataToPath = "|DataDirectory|vaox_data_to_2011.10.14.mdb" 'no need for hc
    'Public Const MyDBPass = "extremeteam"

    'Public Const MyAdSenseAdSlotAFS = "3414342241" 'holidaychoices (AFS)
    'Public Const MyAdSenseAdSlot1 = "6494581990" 'programmerz.net (728x90)
    'Public Const MyAdSenseAdSlot2 = "4949225246" 'programmerz.net(25ox25o)
    'Public Const MyAdSenseAdSlotInTopic = "8529891010" 'programmerz.net(336x28o)
    'Public Const MySite = "programmerz.net"
    'Public Const PreTopicForURL = "topic/" 'recipes/ID/Cat-SubCat
    'Public Const PreTopicForArticle = ""
    'Public Const PostTopicForArticle = "<br />Programmerz.net - Programcıların buluşma noktası! En iyi <strong>programlama</strong> sitesine hoşgeldiniz. <br />" 'recipes/ID/Cat-SubCat
    'Public Const IntroLen As Integer = 6000 'Short version of Content 
    'Public Shared SayyacSTR = Sayyac("www.programmerz.net", "programmerz")
    'Public Const KeywSloMod = "ON"
    'Public Const KeywSlogan = "<h2>[KW]</h2> : Programmerz.net - Programcıların buluşma noktası! Programlama konusunda aradığınız <h2>[KW]</h2> ve daha fazlasını içeride bulacaksınız! <strong>Programlama</strong> konusunda <strong><em>[KW]</em></strong> için en iyi seçenek! <br />" 'recipes/ID/Cat-SubCat
    'Public Const SearchSloMod = "ON"
    'Public Const SearchSlogan = "<h2>[TAG]</h2> : Bu sayfaya Google arama kelimesi olan: <h2>[TAG]</h2> ile geldiniz.  <strong><em>[TAG]</em></strong> ile ilgili en detaylı makaleleri sitemizde bulacaksınız."
    'Public Const DBtoCount = 20
    'Public Const MixedContent = "no"
    'Public Const ExternalImages = "no"
    'Public Const ExternalVideo = "no"
    'Public Const RssTitle = "ProgrammerZ.net - Hottest Codes All Around the World!"





    'Public Const MyAdSenseID = "6897003821103945" 'nslhnbal
    'Public Const MyDBConfPath = "|DataDirectory|vaox_conf.mdb"
    'Public Const MyDBDataPath = "|DataDirectory|vaox_data_2011.11.08.mdb"make
    'Public Const MyDBDataToPath = "|DataDirectory|vaox_data_to_2011.10.14.mdb"

    'Public Const MyDBPass = "extremeteam"
    'Public Const MyAdSenseAdSlotAFS = "3439324487" 'vaox.net (AFS)
    'Public Const MyAdSenseAdSlot1 = "8244928916" 'vaox.net (728x90)
    'Public Const MyAdSenseAdSlot2 = "9921190438" 'vaox.net (25ox25o)
    'Public Const MyAdSenseAdSlotInTopic = "3152020956" 'vaox.net (336x280)
    'Public Const MySite = "vaox.net"
    'Public Const PreTopicForURL = "portal/" '/ID/Cat-SubCat
    'Public Const PreTopicForArticle = "Brought to you by VaoX Portal!<br />"
    'Public Const PostTopicForArticle = "Brought to you by VaoX Portal!<br />"
    'Public Const IntroLen As Integer = 500 'Short version of Content 
    'Public Shared SayyacSTR = Sayyac("www.vaox.net", "vaox")
    'Public Const KeywSloMod = "ON"
    'Public Const KeywSlogan = "Brought to you by VaoX Portal! <strong><em>[KW]</em></strong> <br />"
    'Public Const SearchSloMod = "ON"
    'Public Const SearchSlogan = "<strong><em>[TAG]</em></strong> : You've come to this page through Google search with the syntax: <h2>[TAG]</h2>. You'll find relevant informations about <h2>[TAG]</h2> in this page."
    'Public Const DBtoCount = 10



    'Public Const MyAdSenseID = "6897003821103945" 'nslhnbal
    'Public Const MyDBConfPath = "|DataDirectory|hc_conf.mdb"
    'Public Const MyDBDataPath = "|DataDirectory|hc_data_2012.05.17.mdb" 'make
    'Public Const MyDBDataToPath = "|DataDirectory|vaox_data_to_2011.10.14.mdb"
    'Public Const MyDBUserDataPath = "|DataDirectory|hc_user_data_2011.12.12_2.mdb"

    'Public Const MyDBPass = "extremeteam"
    'Public Const MyAdSenseAdSlotAFS = "3439324487" 'healthylive1.com (AFS)
    'Public Const MyAdSenseAdSlot1 = "8244928916" 'healthylive1.com (728x90)
    'Public Const MyAdSenseAdSlot2 = "9921190438" 'healthylive1.com (25ox25o)
    'Public Const MyAdSenseAdSlotInTopic = "3152020956" 'healthylive1.com (336x280)

    'Public Const MySite = "healthylive1.com"
    'Public Const PreTopicForURL = "livinghealthy/" '/ID/Cat-SubCat
    'Public Const PreTopicForArticle = "<strong><em>Healthy Living</em></strong>, <strong><em>Wellness</em></strong>, <strong><em>Nutritions</em></strong> and <strong><em>Alternative Medicine</em></strong> informations all in at one place!"
    ''find information about flowers, floral arrangements, flower types, planting and blooming tips and much more!
    'Public Const PostTopicForArticle = "<br />HealthyLive1.com Broughts you the best tips for <strong><em>Healthy Living</em></strong>, <strong><em>Wellness</em></strong>, <strong><em>Nutritions</em></strong> and <strong><em>Alternative Medicine</em></strong> informations all in at one place! Best choice for <strong><em>living healthy</em></strong>. <br />" 'recipes/ID/Cat-SubCat
    'Public Const IntroLen As Integer = 500 'Short version of Content 
    'Public Shared SayyacSTR = Sayyac("www.healthylive1.com", "healthylive1")
    'Public Const KeywSloMod = "ON"
    'Public Const KeywSlogan = "<strong><em>[KW]</em></strong> : HealthyLive1.com Broughts you the best tips for <strong><em>Healthy Living</em></strong>, <strong><em>Wellness</em></strong>, <strong><em>Nutritions</em></strong> and <strong><em>Alternative Medicine</em></strong> informations all in at one place! Like <h2>[KW]</h2>! Best choice for <strong><em>living healthy</em></strong> tips for the <strong><em>[KW]</em></strong>. <br />" 'recipes/ID/Cat-SubCat
    'Public Const SearchSloMod = "ON"
    'Public Const SearchSlogan = "<strong><em>[TAG]</em></strong> : You've come to this page through Google search with the syntax: <h2>[TAG]</h2>. You'll find relevant informations, <strong><em>Healthy Living</em></strong>, <strong><em>Wellness</em></strong>, <strong><em>Nutritions</em></strong> and <strong><em>Alternative Medicine</em></strong> informations about <h2>[TAG]</h2> in this page."
    'Public Const DBtoCount = 10
    'Public Const MixedContent = "no"
    'Public Const ExternalImages = "no"
    'Public Const ExternalVideo = "no"
    'Public Const RssTitle = "HolidayChoices.net - Hottest Offers All Around the World!"



    'Public Const MyDBPathTo = "|DataDirectory|database_fz_to_2011.10.27.mdb"
    'Public Const MyDBPath = "|DataDirectory|database_fz_2011.10.20.mdb"
    'Public Const MyDBPass = "extremeteam"
    'Public Const MyAdSenseAdSlotAFS = "7365657740" 'LyricsAndListen.com (AFS)
    'Public Const MyAdSenseAdSlot1 = "6467638617" 'LyricsAndListen.com (728x90)
    'Public Const MyAdSenseAdSlot2 = "9807681115" 'LyricsAndListen.com (25ox25o)
    'Public Const MyAdSenseAdSlotInTopic = "2357729338" 'LyricsAndListen.com (336x280)
    'Public Const MySite = "flowerz1.com"
    'Public Const PreTopicForURL = "lal/" 'recipes/ID/Cat-SubCat
    'Public Const PreTopicForArticle = "<strong><em>Flowers</em></strong>,<strong><em>Floral Arrangements</em></strong> and <strong><em>Blooming Tips</em></strong>!"
    ''find information about flowers, floral arrangements, flower types, planting and blooming tips and much more!
    'Public Const PostTopicForArticle = "<br />Flowerz1.com Broughts you the best tips for <strong><em>Flowers</em></strong>,<strong><em>Floral Arrangements</em></strong> and <strong><em>Blooming Tips</em></strong>!</em></strong> Best choice for flower lovers. <br />" 'recipes/ID/Cat-SubCat
    'Public Const IntroLen As Integer = 500 'Short version of Content 
    'Public Shared SayyacSTR = Sayyac("www.flowerz1.com", "flowerz1")
    'Public Const KeywSloMod = "ON"
    'Public Const KeywSlogan = "<strong><em>[KW]</em></strong> : Flowerz1.com Broughts you the best tips for <strong><em>Flowers</em></strong>,<strong><em>Floral Arrangements</em></strong> and <strong><em>Blooming</em></strong> like <h2>[KW]</h2>! Best choice for <strong><em>flower</em></strong> lovers for the <strong><em>[KW]</em></strong>. <br />" 'recipes/ID/Cat-SubCat
    'Public Const SearchSloMod = "ON"
    'Public Const SearchSlogan = "<strong><em>[TAG]</em></strong> : You've come to this page through Google search with the syntax: <h2>[TAG]</h2>. You'll find relevant informations, <strong><em>flowers</em></strong>,<strong><em>floral arrangements</em></strong> and <strong><em>blooming tips</em></strong> about <h2>[TAG]</h2> in this page."
    'Public Const DBtoCount = 10




    'Public Const MyDBConfPath = "|DataDirectory|lal_conf.mdb"
    'Public Const MyDBDataPath = "|DataDirectory|lal_data_2011.11.10.mdb"
    'Public Const MyDBDataToPath = "|DataDirectory|lal_data_to_2011.11.10.mdb"

    'Public Const MyDBPass = "extremeteam"

    'Public Const MyAdSenseAdSlotAFS = "7099867848" 'LyricsAndListen.com (AFS)
    'Public Const MyAdSenseAdSlot1 = "4757815677" 'LyricsAndListen.com (728x90)
    'Public Const MyAdSenseAdSlot2 = "9472229470" 'LyricsAndListen.com (25ox25o)
    'Public Const MyAdSenseAdSlotInTopic = "8540679350" 'LyricsAndListen.com (336x280)
    'Public Const MySite = "lyricsandlisten.com"
    'Public Const PreTopicForURL = "lal/" 'recipes/ID/Cat-SubCat
    'Public Const PreTopicForArticle = "<strong><em>Lyrics</em></strong> and <strong><em>Listen!</em></strong>"
    'Public Const PostTopicForArticle = "<br />LyricsAndListen.com Broughts you the best <strong><em>songs</em></strong> all around the World with the options <strong><em>lyrics</em></strong> and <strong><em>listening!</em></strong> Best choice for <strong><em>listening</em></strong> and <strong><em>lyrics</em></strong>. <br />" 'recipes/ID/Cat-SubCat
    'Public Const IntroLen As Integer = 500 'Short version of Content 
    'Public Shared SayyacSTR = Sayyac("www.lyricsandlisten.com", "lyricsandlisten")
    'Public Const KeywSloMod = "ON"
    'Public Const KeywSlogan = "<strong><em>[KW]</em></strong> : LyricsAndListen.com Broughts you the best <strong><em>songs</em></strong> all around the World like <h2>[KW]</h2>! Best choice for <strong><em>listening</em></strong> and <strong><em>lyrics</em></strong> for the song <strong><em>[KW]</em></strong>. <br />" 'recipes/ID/Cat-SubCat
    'Public Const SearchSloMod = "ON"
    'Public Const SearchSlogan = "<strong><em>[TAG]</em></strong> : You've come to this page through Google search with the syntax: <h2>[TAG]</h2>. You'll find relevant informations, <strong><em>lyrics</em></strong> and <strong><em>listening</em></strong> options about <h2>[TAG]</h2> in this page."
    'Public Const DBtoCount = 50

    'Public Const MyDBPathTo = "|DataDirectory|database_fs1_to_2011.10.09.mdb"
    'Public Const MyDBPath = "|DataDirectory|database_fs1_2011.09.28.mdb"
    'Public Const MyDBPass = "extremeteam"
    'Public Const MyAdSenseAdSlotAFS = "9582667423" 'fashionstyle1.com (AFS)
    'Public Const MyAdSenseAdSlot1 = "3007070630" 'fashionstyle1.com (728x90)
    'Public Const MyAdSenseAdSlot2 = "6416713763" 'fashionstyle1.com (25ox25o)
    'Public Const MyAdSenseAdSlotInTopic = "8344420448" 'fashionstyle1.com (336x28o)
    'Public Const MySite = "fashionstyle1.com"
    'Public Const PreTopicForURL = "fashion/" 'recipes/ID/Cat-SubCat
    'Public Const PreTopicForArticle = "With FashionStyle1.com, You'll discover the latest high street fashions and celebrity style. Find out what the must-have women's and men's fashion and clothing trends from all the leading high street. FashionStyle1.com's continuous coverage of the fashion scene includes daily fashion news, profiles of designers and models, comprehensive runway slideshows! We're best fashion, beauty, shopping, health, travel and culture trends, runway slideshows. <br /><br />" 'recipes/ID/Cat-SubCat
    'Public Const PostTopicForArticle = "<br />FashionStyle1.com Broughts you the Worlds Number 1 fashions and styles from All over the World! You're sure to find the <strong>best styles</strong> and <strong>best fashions</strong>!. <br />" 'recipes/ID/Cat-SubCat
    'Public Const IntroLen As Integer = 1000 'Short version of Content 
    'Public Shared SayyacSTR = Sayyac("www.fashionstyle1.com", "fashionstyle")
    'Public Const KeywSloMod = "ON"
    'Public Const KeywSlogan = "<strong><em>[KW]</em></strong> : FashionStyle1.com Broughts you the Worlds Number 1 fashions and styles from All over the World! You may like to see our article: <strong><em>[KW]</em></strong>! You're sure to find the best <strong>fashion</strong> and <strong>style</strong> deals about <strong><em>[KW]</em></strong>. <br />" 'recipes/ID/Cat-SubCat
    'Public Const SearchSloMod = "ON"
    'Public Const SearchSlogan = "<strong><em>[TAG]</em></strong> : You've come to this page through Google search with the syntax: <strong><em>[TAG]</em></strong>. You'll find relevant informations and suggestions about <strong><em>[TAG]</em></strong> in this page."
    'Public Const DBtoCount = 50






    'Public Const MyAdSenseID = "6897003821103945" 'nslhnbal
    'Public Const MyDBConfPath = "|DataDirectory|bpcg_conf.mdb"
    'Public Const MyDBDataPath = "|DataDirectory|bpcg_data_2011.12.13.mdb" 'make
    ''Public Const MyDBDataToPath = "|DataDirectory|vaox_data_to_2011.10.14.mdb"
    'Public Const MyDBUserDataPath = "|DataDirectory|vaox_user_data_2011.12.12.mdb"
    'Public Const MyDBPass = "extremeteam"

    'Public Const MyAdSenseAdSlotAFS = "3526599842" 'bestpcgames.net (AFS)
    'Public Const MyAdSenseAdSlot1 = "4199699262" 'bestpcgames.net (728x90)
    'Public Const MyAdSenseAdSlot2 = "4246604153" 'bestpcgames.net(25ox25o)
    'Public Const MyAdSenseAdSlotInTopic = "7844416056" 'bestpcgames.net(336x28o)
    'Public Const MySite = "bestpcgames.net"
    'Public Const PreTopicForURL = "games/" 'recipes/ID/Cat-SubCat
    'Public Const PreTopicForArticle = ""
    'Public Const PostTopicForArticle = "BestPcGames.net Broughts you the Number 1 games from All Categories! You're sure to find the <strong>best pc games</strong>."
    'Public Const IntroLen As Integer = 500 'Short version of Content 
    'Public Shared SayyacSTR = Sayyac("www.bestpcgames.net", "bestpcgames")
    'Public Const KeywSloMod = "ON"
    'Public Const KeywSlogan = "<strong><em>[KW]</em></strong> : BestPcGames.net Broughts you the Best PC Games from All categories like <strong><em>[KW]</em></strong>! You're sure to find the <strong>best pc games</strong>, as well as secrets, cheats, and walkthroughs for the game <strong><em>[KW]</em></strong>. <br />" 'recipes/ID/Cat-SubCat
    'Public Const SearchSloMod = "ON"
    'Public Const SearchSlogan = "<strong><em>[TAG]</em></strong> : You've come to this page through Google search with the syntax: <strong><em>[TAG]</em></strong>. You'll find relevant game informations, secrets, cheats, and walkthroughs for the game <strong><em>[TAG]</em></strong> in this page."
    'Public Const DBtoCount = 20

    'Public Const MixedContent = "yes"
    'Public Const ExternalImages = "no"
    'Public Const ExternalVideo = "no"
    'Public Const RssTitle = "HolidayChoices.net - Hottest Offers All Around the World!"
    'Public Shared UserImgPath As String = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath & "userfiles\images\"



    'Public Const MyAdSenseID = "6897003821103945" 'nslhnbal
    'Public Const MyDBConfPath = "|DataDirectory|hc_conf.mdb"
    'Public Const MyDBDataPath = "|DataDirectory|hc_data_2012.05.17.mdb" 'make
    'Public Const MyDBDataToPath = "|DataDirectory|vaox_data_to_2011.10.14.mdb"
    'Public Const MyDBUserDataPath = "|DataDirectory|hc_user_data_2011.12.12_2.mdb"
    'Public Const MyDBPass = "extremeteam"

    'Public Const MyAdSenseAdSlotAFS = "3414342241" 'holidaychoices.net (AFS)
    'Public Const MyAdSenseAdSlot1 = "9160861927" 'holidaychoices.net (728x90)
    'Public Const MyAdSenseAdSlot2 = "0138284228" 'holidaychoices.net(25ox25o)
    'Public Const MyAdSenseAdSlotInTopic = "2299557052" 'holidaychoices.net(336x28o)
    'Public Const MySite = "holidaychoices.net"
    'Public Const PreTopicForURL = "hc/" 'recipes/ID/Cat-SubCat
    'Public Const PreTopicForArticle = ""
    'Public Const PostTopicForArticle = "<br />HolidayChoices.net Broughts you the Best Number 1 choices of Vacation Destinations from All over the World! You're sure to find the <strong>best holiday choices</strong>. <br />" 'recipes/ID/Cat-SubCat
    'Public Const IntroLen As Integer = 6000 'Short version of Content 
    'Public Shared SayyacSTR = Sayyac("www.holidaychoices.net", "holidaychoices")
    'Public Const KeywSloMod = "ON"
    'Public Const KeywSlogan = "<h2>[KW]</h2> : HolidayChoices.net Broughts you the Best Number 1 choices of Vacation Destinations as well as <h2>[KW]</h2>! You're sure to find the <strong>best holiday choices</strong> for <strong><em>[KW]</em></strong>. <br />" 'recipes/ID/Cat-SubCat
    'Public Const SearchSloMod = "ON"
    'Public Const SearchSlogan = "<h2>[TAG]</h2> : You've come to this page through Google search with the syntax: <h2>[TAG]</h2>. You'll find relevant informations and suggestions about <strong><em>[TAG]</em></strong> in this page."
    'Public Const DBtoCount = 20

    'Public Const MixedContent = "no"
    'Public Const ExternalImages = "no"
    'Public Const ExternalVideo = "no"
    'Public Const ShowDummyVideo = "no"
    'Public Const RssTitle = "HolidayChoices.net - Hottest Offers All Around the World!"
    'Public Shared UserImgPath As String = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath & "userfiles\images\"
    ''Public Const ShowFullScreenFlashBG = "1.jpg,2.jpg,3.jpg,4.jpg,5.jpg,6.jpg,7.jpg,8.jpg,9.jpg,10.jpg,11.jpg,12.jpg"

    'Public Const ShowFullScreenFlashBG = ""












    Public Const UrlRW = "ON" 'local
    Public Const TopicPath = "ON" 'local

    'Public Const PreTopic = "topic" 'recipes/ID/Cat-SubCat

    Public Const ListSBK = 5 'Sayba Başına Kayıt
    'Public Const ListSBK = 10


    Public Const FCKPath = "scripts/fckeditor/" 'local
    Public Const FCKSessionUserFilesPath = "~/userfiles/" 'local
    Public Const FCKImageBrowserURL = "editor/filemanager/browser/default/browser.html?Type=Image&Connector="
    'Public Const FCKPath = "scripts/fckeditor/"
    'Public Const FCKSessionUserFilesPath = "~/cubuk-tursusu/userfiles/"
    'Public Const FCKImageBrowserURL = "editor/filemanager/browser/default/browser.aspx?Type=Image&Connector="

    Public Const FCKConnectorPath = "editor/filemanager/connectors/aspx/connector.aspx"
    Public Const FCKID = "dynamicname"
    Public Const FCKSkinPath = "skins/silver/"
    Public Const FCKToolbarSet = "Serkan" 'Basic | Default | Serkan
    'Public Const FCKToolbarSet = "Default" 'Basic | Default | Serkan
    'Public Const FCKToolbarSet = "Default"



    Public Shared Function Ads_GetNotFoundString(ByVal LangNotFoundAds)
        Dim MySTR = LangNotFoundAds & " <br /><br />"
        MySTR = MySTR & wpdn_v10.AdsenseInTopic()
        Return MySTR
    End Function

    Public Shared Function GetAdsenseCodeAFSQuery(ByVal MyQuery, ByVal SearchedFromURL)
        Dim COF = "FORID%3A10"
        Dim MySTR = "cx=partner-pub-" & MyAdSenseID & "%3A" & MyAdSenseAdSlotAFS & "&cof=" & COF & "&ie=UTF-8&q=" & MyQuery & "&sa=Search&siteurl=" & SearchedFromURL & ""
        'MySTR = "search.aspx?cx=partner-pub-6897003821103945%3A3414342241&cof=FORID%3A10&ie=UTF-8&q=serkan+bal&sa=Search&siteurl=%2FC%3A%2FUsers%2FSerkan%2FDesktop%2F1.html"
        Return MySTR
    End Function

    Public Shared Function GetAdsenseCodeAFS()
        Dim Str As New StringBuilder

        Str.AppendLine("<div id=""cse-search-results""></div>")
        Str.AppendLine("<script type=""text/javascript"">")
        Str.AppendLine("  var googleSearchIframeName = ""cse-search-results"";")
        Str.AppendLine("  var googleSearchFormName = ""cse-search-box"";")
        Str.AppendLine("  var googleSearchFrameWidth = 600;")
        Str.AppendLine("  var googleSearchDomain = ""www.google.com"";")
        Str.AppendLine("  var googleSearchPath = ""/cse"";")
        Str.AppendLine("</script>")
        Str.AppendLine("<script type=""text/javascript"" src=""http://www.google.com/afsonline/show_afs_search.js""></script>")

        Return Str.ToString
    End Function
    Public Shared Function GetAdsenseCode1()
        Dim STR As New StringBuilder

        STR.AppendLine("<script type=""text/javascript""><!--" & vbCrLf)
        STR.AppendLine("google_ad_client = ""ca-pub-" & MyAdSenseID & """;" & vbCrLf)
        STR.AppendLine("/* BestRecipes1.com-728x90 */" & vbCrLf)
        STR.AppendLine("google_ad_slot = """ & MyAdSenseAdSlot1 & """;" & vbCrLf)
        STR.AppendLine("google_ad_width = 728;" & vbCrLf)
        STR.AppendLine("google_ad_height = 90;" & vbCrLf)
        STR.AppendLine("//-->" & vbCrLf)
        STR.AppendLine("</script>" & vbCrLf)
        STR.AppendLine("<script type=""text/javascript""" & vbCrLf)
        STR.AppendLine("src=""http://pagead2.googlesyndication.com/pagead/show_ads.js"">" & vbCrLf)
        STR.AppendLine("</script>" & vbCrLf)

        Return STR.ToString
    End Function
    Public Shared Function GetAdsenseCode2()
        Dim STR As New StringBuilder

        STR.AppendLine("<script type=""text/javascript""><!--" & vbCrLf)
        STR.AppendLine("google_ad_client = ""ca-pub-" & MyAdSenseID & """;" & vbCrLf)
        STR.AppendLine("/* BestRecipes1.com-250x250 */" & vbCrLf)
        STR.AppendLine("google_ad_slot = """ & MyAdSenseAdSlot2 & """;" & vbCrLf)
        STR.AppendLine("google_ad_width = 250;" & vbCrLf)
        STR.AppendLine("google_ad_height = 250;" & vbCrLf)
        STR.AppendLine("//-->" & vbCrLf)
        STR.AppendLine("</script>" & vbCrLf)
        STR.AppendLine("<script type=""text/javascript""" & vbCrLf)
        STR.AppendLine("src=""http://pagead2.googlesyndication.com/pagead/show_ads.js"">" & vbCrLf)
        STR.AppendLine("</script>" & vbCrLf)

        Return STR.ToString
    End Function

    Public Shared Function AdsenseInTopic()
        Dim STR As New StringBuilder

        STR.AppendLine("<div style=""float: left;width:auto;"">" & vbCrLf)

        STR.AppendLine("<script type=""text/javascript""><!--")
        STR.AppendLine("google_ad_client = ""ca-pub-" & MyAdSenseID & """;")
        STR.AppendLine("/* BestRecipes1.com-336x280 */")
        STR.AppendLine("google_ad_slot = """ & MyAdSenseAdSlotInTopic & """;")
        STR.AppendLine("google_ad_width = 336;")
        STR.AppendLine("google_ad_height = 280;")
        STR.AppendLine("//-->")
        STR.AppendLine("</script>")
        STR.AppendLine("<script type=""text/javascript""")
        STR.AppendLine("src=""http://pagead2.googlesyndication.com/pagead/show_ads.js"">")
        STR.AppendLine("</script>")

        STR.AppendLine("</div>" & vbCrLf)

        Return STR.ToString
    End Function




    Public Shared Sub WriteMasterPageData(ByVal MyControl As String, ByVal MyTxt As String, ByVal oPage As Page)
        Dim mpLabel As Label

        If MyControl = "footer" Then
            mpLabel = CType(oPage.Master.FindControl("TitleForSEOTxt"), Label)
        ElseIf MyControl = "tags" Then
            mpLabel = CType(oPage.Master.FindControl("TagTxt"), Label)

        End If
        If Not mpLabel Is Nothing Then
            mpLabel.Text = MyTxt
        End If

    End Sub




    Public Shared Function MakeURL(ByVal Alan, Optional ByVal Cat = "", Optional ByVal Baslik = "", Optional ByVal ID = "", Optional ByVal BasePath = "", Optional ByVal Tag1 = "", Optional ByVal TagID = "", Optional ByVal CatURL = "", Optional ByVal PreURL = "")
        Dim MyURL = ""  'Make url makes http://


        Cat = fn_general_v30.TextToURL(Cat, "IncludeSlash") : Baslik = fn_general_v30.TextToURL(Baslik) : Tag1 = fn_general_v30.TextToURL(Tag1)
        'Cat = HttpUtility.UrlEncode(Cat) : Baslik = HttpUtility.UrlEncode(Baslik) : Tag1 = HttpUtility.UrlEncode(Tag1)


        If Alan = "topic" Then
            MyURL = BasePath & PreTopicForURL & Cat & "/" & ID & "_" & Baslik & ".aspx"
        ElseIf Alan = "search" Then 'tag olayları
            MyURL = BasePath & PreTopicForURL & Cat & "/" & ID & "_" & Baslik & ".aspx?tag=" & TagID & "-" & Tag1
          

        ElseIf Alan = "tree" Then
            MyURL = BasePath & "category/" & CatURL & Baslik & "/" & ID & "/"

        ElseIf Alan = "cat" Then
            MyURL = BasePath & "category/" & ID & "" & Baslik & "/" & ID & "/"

        ElseIf Alan = "date" Then
            MyURL = BasePath & "archive/" & Baslik & "/"


        ElseIf Alan = "referrals" Then
            If PreURL <> "" Then
                MyURL = PreURL & "?searched=" & ID & "-" & Baslik
            Else
                MyURL = BasePath & "search/" & ID & "/" & Baslik & "/"
            End If
        End If

        Return MyURL
    End Function

    Public Shared Function FCKPathYaz(ByVal Port1, ByVal Protocol1, ByVal ServerName1, ByVal AppPath)
        'USAGE ####
        'PathYaz (Request.ServerVariables("SERVER_PORT"),Request.ServerVariables("SERVER_PORT_SECURE"),Request.ServerVariables("SERVER_NAME"),Request.ApplicationPath)
        Dim Port = Port1
        Dim Protocol = Protocol1
        Dim ServerName = ServerName1
        Dim BasePath

        If Port = "" Or Port = "80" Or Port = "443" Then
            Port = ""
        Else
            Port = ":" + Port
        End If
        If Protocol = "" Or Protocol = "0" Then
            Protocol = "http://"
        Else
            Protocol = "https://"
        End If


        BasePath = Protocol + ServerName + Port + AppPath

        If Right(Trim(BasePath), 1) <> "/" Then
            BasePath = BasePath & "/"
        End If
        Return BasePath & FCKPath


    End Function




    Public Shared Function TopicStart()
        Dim TopicString
        TopicString = TopicString & "<table id=""topic_table"" class=""topic_table"">" & vbCrLf
        Return TopicString
    End Function

    Shared Function ClearLink(ByVal MySTR)
        MySTR = Replace(MySTR, "<a href=""http://www.teenvogue.com", "<a href=""http://www.fashionstyle1.com")

        Return MySTR
    End Function


    Public Shared Function TopicData(ByVal TopicID, ByVal content_title, ByVal content_intro, ByVal authorID, ByVal content_date, ByVal contentx, ByVal BasePath, ByVal SESS_lang_tags, ByVal SESS_lang_cat, ByVal SESS_lang_more, Optional ByVal AllowAdsenseInTopic = "", Optional ByVal REFS = "", Optional ByVal ShortForm = "", Optional ByVal MyTag = "", Optional ByVal MySearch = "", Optional ByVal SESS_short_http_name = "", Optional ByVal CatID = "", Optional ByVal lang_author = "")


        If Replace(content_intro, "{READ MORE}", "") = content_intro Then
            content_intro = content_intro
        Else
            content_intro = fn_general_v30.FindAndCutData_Before(content_intro, "{READ MORE}")
        End If

        contentx = Replace(contentx, "{READ MORE}", "")


        Dim ExternalImageLink As String = ""
        If ExternalImages = "yes" Then
            Dim TopicImg = BasePath & "content/images/" & TopicID & ".jpg"
            ExternalImageLink = fn_general_v30.MakeImg(content_title, TopicImg)
            ExternalImageLink = "<div style=""float: left;width:auto;"">" & ExternalImageLink & "</div>"
        End If

        content_intro = html_tidy_v10.HTML_Tidy(content_intro) : content_intro = fn_general_v30.NoFollow(content_intro) : content_intro = ClearLink(content_intro)
        contentx = html_tidy_v10.HTML_Tidy(contentx) : contentx = fn_general_v30.NoFollow(contentx) : contentx = ClearLink(contentx)

        If content_intro = "" Then content_intro = fn_general_v30.HtmlCut(contentx, IntroLen)

        Dim MyDataFromDB As New fn_db_data

        Dim MyCatz As New class_decl_v10.ParentCatNamez
        MyCatz = MyDataFromDB.FindBreadCrumb(CatID, BasePath, "topic_keywords")
        'Dim CatForURL = fn_general_v30.TextToURL(categories)
        'Dim CatURL = MakeURL("cat", , categories, CatID, BasePath)
        'Dim CatLink = fn_general_v30.MakeLink(categories, CatURL, "topic_keywords")
        Dim CatLink = MyCatz.CatWithLink
        Dim CatForUrl = MyCatz.cat_parent_url & MyCatz.cat_name
        Dim CatLinkWithLang = "<span class='keywordstext'>" & SESS_lang_cat & ": </span>" & CatLink


        Dim MyUserDataFromDB As New fn_db_userdata
        Dim MyAuthor As New class_decl_v10.UserDetails
        MyAuthor = MyUserDataFromDB.Get_User_Info(authorID)
        Dim AuthorWithLang = "<span class='keywordstext'>" & lang_author & ": " & MyAuthor.MyName & "</span>"



        Dim MyKeys As New class_decl_v10.Keywordz
        MyKeys = MyDataFromDB.FindKeywWithLink(TopicID, CatForUrl, content_title, SESS_lang_tags, BasePath)
        Dim keyw1 = MyKeys.Keyw1 : Dim keyw1id = MyKeys.Keyw1ID : Dim keyw2 = MyKeys.Keyw2 : Dim keyw2id = MyKeys.Keyw2ID : Dim keyw3 = MyKeys.Keyw3 : Dim keyw3id = MyKeys.Keyw3ID
        Dim KeywWithLink = MyKeys.KeywWithLink : If ShortForm = "yes" Then KeywWithLink = ""
        If MySite = "bestpcgames.net" Then content_intro = MyKeys.KeywWithoutLink

        MyTag = HttpUtility.UrlDecode(MyTag) : MyTag = fn_general_v30.ForSearch(MyTag)
        Dim MyKeywSlogan : If KeywSloMod = "ON" Then MyKeywSlogan = Replace(KeywSlogan, "[KW]", MyTag)

        MySearch = HttpUtility.UrlDecode(MySearch) : MySearch = fn_general_v30.ForSearch(MySearch)
        Dim MySearchSlogan : If SearchSloMod = "ON" Then MySearchSlogan = Replace(SearchSlogan, "[TAG]", MySearch)


        '################ CONTENT RENK START #################################
        Dim Keyw1URL = MakeURL("search", CatForUrl, content_title, TopicID, BasePath, keyw1, keyw1id)
        Dim Keyw2URL = MakeURL("search", CatForUrl, content_title, TopicID, BasePath, keyw2, keyw2id)
        Dim Keyw3URL = MakeURL("search", CatForUrl, content_title, TopicID, BasePath, keyw3, keyw3id)

        'MsgBox(Keyw1URL)
        'MsgBox(Keyw2URL)


        Dim kirmizi As String = "themes/default/images/content/seo/kirmizi-" & TopicID & ".gif"
        Dim sari As String = "themes/default/images/content/seo/sari-" & TopicID & ".gif"
        Dim yesil As String = "themes/default/images/content/seo/yesil-" & TopicID & ".gif"
        Dim google As String = "themes/default/images/content/seo/google-" & TopicID & ".gif"
        Dim GoogleURL As String = "http://www.google.com/search?q=site:" & SESS_short_http_name & " " & fn_general_v30.aTitle(content_title)
        Dim content_renk = fn_general_v30.MakeImgLink(keyw1, Keyw1URL, kirmizi, , "topic_images") & fn_general_v30.MakeImgLink(keyw2, Keyw2URL, sari, , "topic_images") & fn_general_v30.MakeImgLink(keyw3, Keyw3URL, yesil, , "topic_images") & fn_general_v30.MakeImgLink("Google", GoogleURL, google, , "topic_images")
        '################ CONTENT RENK END #################################
        If keyw1 = "" Then content_renk = ""




        Dim gun, ay, yil : Dim tarih As Date
        tarih = content_date

        gun = tarih.ToString("dd") : ay = tarih.ToString("MMM") : yil = tarih.ToString("yyyy")


        Dim TopicURL = MakeURL("topic", CatForUrl, content_title, TopicID, BasePath)
        Dim TopicTitleWithLink = fn_general_v30.MakeLink(content_title, TopicURL, "topic_title")



        Dim STR As New StringBuilder

        STR.AppendLine("	<tr>" & vbCrLf)
        STR.AppendLine("		<td class='table_kesik_alt_cizgi'>" & vbCrLf)

        STR.AppendLine("<table>")
        STR.AppendLine("<tr>")
        STR.AppendLine("   <td>")
        STR.AppendLine("       <table><tr>")
        STR.AppendLine("       <td class='time_td'>")
        STR.AppendLine("           <table class='time_table' >" & vbCrLf)
        STR.AppendLine("       	    <tr>" & vbCrLf)
        STR.AppendLine("       		    <td class='time_backg' >" & vbCrLf)
        STR.AppendLine("                   <small class='PostTime'>")
        STR.AppendLine("                   <strong class='day'>" & gun & "</strong>")
        STR.AppendLine("                   <strong class='month'>" & ay & "</strong>")
        STR.AppendLine("                   <strong class='year'>" & yil & "</strong></small>")
        STR.AppendLine("       	        </td>" & vbCrLf)
        STR.AppendLine("       	    </tr>" & vbCrLf)
        STR.AppendLine("           </table>" & vbCrLf)
        STR.AppendLine("       </td>")
        STR.AppendLine("       <td class='topic_title_td'>")
        STR.AppendLine("		    <h1>" & TopicTitleWithLink & "</h1>" & content_renk & vbCrLf)  '############################################

        STR.AppendLine("		    <br />")

        STR.AppendLine("		    " & vbCrLf)
        STR.AppendLine("       </td>")
        STR.AppendLine("       </tr></table>")
        STR.AppendLine("   </td>")
        STR.AppendLine("</tr>")
        STR.AppendLine("<tr>")
        STR.AppendLine("   <td  colspan='2'>")

        STR.AppendLine("   		" & CatLinkWithLang & "" & vbCrLf)
        STR.AppendLine("   		<br />")
        STR.AppendLine("   		" & AuthorWithLang & "" & vbCrLf)
        STR.AppendLine("   		<br /><br />")



        Dim MyContent As String, MoreTxt As String, MyPreTopic As String, MyPostTopic As String
        If ShortForm = "yes" Then
            MyPreTopic = ""
            MyPostTopic = PostTopicForArticle
            MyContent = ExternalImageLink & content_intro
            MoreTxt = "		    <a class='read_more' href='" & TopicURL & "' >" & SESS_lang_more & "»</a>"

        Else
            MyPreTopic = PreTopicForArticle
            MyPostTopic = PostTopicForArticle
            MyContent = ExternalImageLink & contentx
            MoreTxt = ""
            If MySite = "bestpcgames.net" Then MyContent = SWFYap(TopicID, Trim(contentx))
        End If

        Dim MyAdsense = ""
        If AllowAdsenseInTopic = "yes" Then MyAdsense = AdsenseInTopic()


        STR.AppendLine("   		<div class='topic_content'>" & MyAdsense & MyPreTopic & MyContent & MyPostTopic & "</div>" & vbCrLf & MoreTxt & vbCrLf)


        STR.AppendLine("   		<br /><br />")
        STR.AppendLine("	    	<div>" & KeywWithLink & "</div>" & vbCrLf)

        If KeywSloMod = "ON" Then
            If MyTag <> "" Then
                STR.AppendLine("   		<br /><br />")
                STR.AppendLine("	    	<div>" & MyKeywSlogan & "</div>" & vbCrLf)
            End If
        End If

        If SearchSloMod = "ON" Then
            If MySearch <> "" Then
                STR.AppendLine("   		<br /><br />")
                STR.AppendLine("	    	<div>" & MySearchSlogan & "</div>" & vbCrLf)
            End If
        End If

        'If REFS <> "" Then
        '    STR.AppendLine("   		<br />")
        '    STR.AppendLine("	    	" & MyREFS & "" & vbCrLf)
        '    STR.AppendLine("	    	<br />")
        'End If
        STR.AppendLine("	    	" & vbCrLf)

        STR.AppendLine("   </td>")
        STR.AppendLine("</tr>")
        STR.AppendLine("</table>")

        STR.AppendLine("		</td>" & vbCrLf)
        STR.AppendLine("	</tr>" & vbCrLf)

        Return STR.ToString
    End Function

    Public Shared Function TopicEnd()
        Dim TopicString
        TopicString = TopicString & "	</table>" & vbCrLf
        Return TopicString
    End Function


    'Function ContentRenkBul(ByVal ArticleID, ByVal CatName, ByVal content_title)
    '    Dim MyRES


    '    MyRES = content_renk

    '    Return MyRES
    'End Function


    Public Shared Function SWFYap(ByVal id, ByVal link)
        Dim str As New StringBuilder
        str.AppendLine("<object id=""" & id & """ data=""" & link & """ height=""520"" type=""application/x-shockwave-flash"" width=""650"">")
        str.AppendLine("	<param name=""movie"" value=""" & link & """ />")
        str.AppendLine("</object>")

        Return str.ToString
    End Function


    Public Shared Function Sayyac(ByVal Alexa, ByVal SayyacStr)
        Dim Str As New StringBuilder
        Str.AppendLine("        <script type='text/javascript' language='javascript' src='http://xslt.alexa.com/site_stats/js/s/a?url=" & Alexa & "'></script>")
        Str.AppendLine("")
        Str.AppendLine("        <!-- Sayyac counter START v4.3 -->")
        Str.AppendLine("        <script type=""text/javascript"">")
        Str.AppendLine("        <!--")
        Str.AppendLine("            document.write(unescape(""%3Cscript src='"" + ((""https:"" == document.location.protocol) ? ""https://"" : ""http://"")")
        Str.AppendLine("         + ""srv.sayyac.net/sa.js?_salogin=" & SayyacStr & "&_sav=4.3' type='text/javascript'%3E%3C/script%3E""));")
        Str.AppendLine("        //-->")
        Str.AppendLine("        </script>")
        Str.AppendLine("        <script type=""text/javascript"">")
        Str.AppendLine("        <!--")
        Str.AppendLine("            sayyac.track('" & SayyacStr & "', 'srv.sayyac.net');")
        Str.AppendLine("        //-->")
        Str.AppendLine("        </script>")

        Str.AppendLine("        <!-- Sayyac counter END v4.3 -->")
        Return Str.ToString

    End Function



End Class

