<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>JQuery File Upload (Uploadify) with ASP.NET</title>
    <link href="assets/css/jquery.plupload.queue.css" rel="stylesheet" type="text/css" />
    <script src="assets/js/jquery-1.6.1.js" type="text/javascript"></script>
    <script src="assets/js/plupload.full.js" type="text/javascript"></script>
    <script src="assets/js/jquery.plupload.queue.js" type="text/javascript"></script>
    <script type="text/javascript">
        // Convert divs to queue widgets when the DOM is ready
        $(function () {
            $("#uploader").pluploadQueue({
                // General settings,silverlight,browserplus,html5gears,
                runtimes: 'gears,flash,silverlight,browserplus,html5',
                url: 'FileUpload.ashx',
                max_file_size: '10mb',
                chunk_size: '1mb',
                unique_names: true,

                // Specify what files to browse for
                /*filters: [
                { title: "Image files", extensions: "jpg,gif,png" },
                { title: "Zip files", extensions: "zip" }
                ],*/

                // Flash settings
                flash_swf_url: 'assets/resources/plupload.flash.swf',

                // Silverlight settings
                silverlight_xap_url: 'assets/resources/plupload.silverlight.xap',

                init: {
                    FileUploaded: function (up, file, info) {

                    }
                }
            });

            // Client side form validation
            $('form').submit(function (e) {
                var uploader = $('#uploader').pluploadQueue();

                // Validate number of uploaded files
                if (uploader.total.uploaded == 0) {
                    // Files in queue upload them first
                    if (uploader.files.length > 0) {
                        // When all files are uploaded submit form
                        uploader.bind('UploadProgress', function () {
                            if (uploader.total.uploaded == uploader.files.length)
                                $('form').submit();
                        });

                        uploader.start();
                    } else
                        alert('You must at least upload one file.');

                    e.preventDefault();
                }
            });

            //tweak to reset the interface for new file upload
            $('#btnReset').click(function () {
                var uploader = $('#uploader').pluploadQueue();
                
                //clear files object
                uploader.files.length = 0;

                $('div.plupload_buttons').css('display', 'block');
                $('span.plupload_upload_status').html(''); 
                $('span.plupload_upload_status').css('display', 'none');
                $('a.plupload_start').addClass('plupload_disabled');
                //resetting the flash container css property
                $('.flash').css({
                    position: 'absolute', top: '292px',
                    background: 'none repeat scroll 0% 0% transparent',
                    width: '77px',
                    height: '22px',
                    left: '16px'
                });
                //clear the upload list
                $('#uploader_filelist li').each(function (idx, val) {
                    $(val).remove();
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <input id="btnReset" type="button" value="New Upload" />
    <div id="uploader">
        <p>
            You browser doesn't have Flash, Silverlight, Gears, BrowserPlus or HTML5 support.</p>
    </div>
    </form>
</body>
</html>
