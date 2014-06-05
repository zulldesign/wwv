swfobject.addDomLoadEvent(function() {
  swfobject.embedSWF(
					"text_and_image_cloud.swf", "myContent4",
					"900", "200",
					"10", "expressInstall.swf",
					{
						cloud_data:"cloud_data.xml",
						tcolor:"0xFA9100",
						tcolor2:"0xFF5900",
						hicolor:"0xA63A00",
						tspeed:"1000",
						fontFace:"Impact"
					},
					{wmode: "window", menu: "false", quality: "best"}
					);
