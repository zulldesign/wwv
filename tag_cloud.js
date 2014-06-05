swfobject.addDomLoadEvent(function() {
  swfobject.embedSWF(
					"tag_text_and_image_cloud.swf", "myContent4",
					"290", "250",
					"10", "tag_expressInstall.swf",
					{
						cloud_data:"tag_cloud_data.xml",
						tcolor:"0xFA9100",
						tcolor2:"0xFF5900",
						hicolor:"0xA63A00",
						tspeed:"250",
						fontFace:"Impact"
					},
					{wmode: "window", menu: "false", quality: "best"}
					);
});
