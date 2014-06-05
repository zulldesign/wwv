
Partial Class test2
    Inherits System.Web.UI.Page

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'Dim myfilename = "kalz.xsklueuQL3WJ.ÇZXNDlkdjfalsd.com/jskdalfja7/serkan.jpg"
        'MsgBox(System.IO.Path.GetFileName(myfilename))

        'MsgBox(Chr(34))



        Dim MySTR = "Umre ziyaretleriniz için herhangi bir turizm firmasıyla anlaşmış iseniz bu üzücü haber işleri biraz karıştırabilir.<br />Bilindiği üzere KABE nin etrafını genişletmek için çalışmalar yapılmaktadır. Suudi Arabistan hükümeti ise bu çalışmaları da bahane göstererek Umre süresinin 2 hafta ile sınırlı olduğunu belirtmiştir.&nbsp;<br />Bundan sonraki süreçte 2 hafta olacak olan umre zamanlaması daha önceden rezervasyon yaptırmış olan Umre ziyaretini gerçekleştirecek olan adayları oldukta üzecektir.&nbsp;<br /><br />Umreye gidecek olan adayların ziyaretlerinin kabul<img src='/userfiles/images.jpg' width='275' height='183' align='left' alt='' /> olmasını Allahtan niyaz ederiz.<br type='_moz' /><object width='560' height='315'><param name='movie' value='http://www.youtube.com/v/ZlgA8csFR88?hl=en_US&amp;version=3' /><param name='allowFullScreen' value='true' /><param name='allowscriptaccess' value='always' /><embed src='http://www.youtube.com/v/ZlgA8csFR88?hl=en_US&amp;version=3' type='application/x-shockwave-flash' width='560' height='315' allowscriptaccess='always' allowfullscreen='true'></embed></object>"

        Dim MyImgURL = fn_general_v30.Image_FindSingleFromAllHTML(MySTR)

        MsgBox(MyImgURL)
    End Sub
End Class
