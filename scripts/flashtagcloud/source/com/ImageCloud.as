/* Original tagCloud taken from www.raytanck.com  */
/* modified by artViper designstudio www.artviper.net */


package com
{
	import flash.display.MovieClip;
	import flash.display.Sprite;
	import flash.display.Stage;
	import flash.display.StageAlign;
	import flash.display.StageScaleMode;
	import flash.display.LoaderInfo;
	import flash.events.Event;
	import flash.net.URLRequest;
	import flash.net.URLLoader;
	import flash.text.TextField;
	import flash.text.TextFieldAutoSize;
	import flash.text.TextFormat;
	import flash.geom.ColorTransform;
	import flash.events.MouseEvent;

	import flash.net.navigateToURL;
	import flash.net.URLRequest;
	import com.OneElement;

	public class ImageCloud extends MovieClip	{

		// private vars
		private var radius:Number = 150;
		private var mcList:Array;
		private var dtr:Number = Math.PI/180;
		private var d:Number = 300;
		private var sa:Number;
		private var ca:Number;
		private var sb:Number;
		private var cb:Number;
		private var sc:Number;
		private var cc:Number;
		private var originx:Number;
		private var originy:Number;
		private var tcolor:Number;
		private var hicolor:Number;
		private var tcolor2:Number;
		private var tspeed:Number;
		private var fontFace:String;
		private var distr:Boolean;
		private var lasta:Number;
		private var lastb:Number;
		private var holder:MovieClip;
		private var active:Boolean;
		private var cloud_data:String;
		private var myXML:XML;
		
		public function ImageCloud(){
			// stage settings
			var swfStage:Stage = this.stage;
			swfStage.scaleMode = StageScaleMode.NO_SCALE;
			swfStage.align = StageAlign.TOP_LEFT;

			// get xml file name
			cloud_data = ( this.loaderInfo.parameters.cloud_data == null ) ? "cloud_data.xml" : String(this.loaderInfo.parameters.cloud_data);

			// get flashvar for text color
			tcolor = ( this.loaderInfo.parameters.tcolor == null ) ? 0x333333 : Number(this.loaderInfo.parameters.tcolor);
			tcolor2 = ( this.loaderInfo.parameters.tcolor2 == null ) ? 0x995500 : Number(this.loaderInfo.parameters.tcolor2);
			hicolor = ( this.loaderInfo.parameters.hicolor == null ) ? 0x000000 : Number(this.loaderInfo.parameters.hicolor);
			tspeed = ( this.loaderInfo.parameters.tspeed == null ) ? 1 : Number(this.loaderInfo.parameters.tspeed)/100;

			// get font face
			fontFace = ( this.loaderInfo.parameters.fontFace == null ) ? "Arial" : String(this.loaderInfo.parameters.fontFace);

			// some more vars
			distr = true;
			
			// start load or parse the data
			myXML = new XML();
			if( this.loaderInfo.parameters.mode == null )	{
				// base url
				var a:Array = this.loaderInfo.url.split("/");
				a.pop();
				var baseURL:String = a.join("/") + "/";
				// load XML file
				var myXMLURL:URLRequest = new URLRequest( baseURL + cloud_data );
				var myLoader:URLLoader = new URLLoader(myXMLURL);
				myLoader.addEventListener("complete", xmlLoaded);
				function xmlLoaded(event:Event):void {
						myXML = XML(myLoader.data);
						init( myXML );
				}
			}
			// end load or parse the data
		}
		

		
		private function init( o:XML ):void {
			sineCosine( 0,0,0 );
			mcList = [];
			active = false;
			lasta = 1;
			lastb = 1;
			// create holder mc, center it		
			holder = new MovieClip();
			addChild(holder);
			resizeHolder();
			// loop though them to find the smallest and largest 'tags'
			var largest:Number = 0;
			var smallest:Number = 9999;
			for each( var node:XML in o.a ){
				var nr:Number = getNumberFromString( node["@style"] );
				largest = Math.max( largest, nr );
				smallest = Math.min( smallest, nr );
			}
			// create movie clips
			for each( var node2:XML in o.a ){
				// figure out what color it should be
				var nr2:Number = getNumberFromString( node2["@style"] );
				var perc:Number = ( smallest == largest ) ? 1 : (nr2-smallest) / (largest-smallest);
	
				// create mc
				var col:Number = ( node2["@color"] == undefined ) ? getColorFromGradient( perc ) : Number( node2["@color"] );
				var hicol:Number = ( node2["@hicolor"] == undefined ) ? ( ( hicolor == tcolor ) ? getColorFromGradient( perc ) : hicolor ) : Number( node2["@hicolor"] );
				var image:String = ( node2["@rev"] == undefined ) ? ( "" ) : String( node2["@rev"] );
				var mc:OneElement = new OneElement( node2, col, hicol, image, fontFace );
				holder.addChild(mc);
				// store reference
				mcList.push( mc );
			}
			// distribute the tags on the sphere
			positionAll();
			// add event listeners
			addEventListener(Event.ENTER_FRAME, updateTags);
			stage.addEventListener(Event.MOUSE_LEAVE, mouseExitHandler);
			stage.addEventListener(MouseEvent.MOUSE_MOVE, mouseMoveHandler);
			stage.addEventListener(Event.RESIZE, resizeHandler);
		}

		private function updateTags( e:Event ):void {
			var a:Number;
			var b:Number;
			if( active ){
				a = (-Math.min( Math.max( holder.mouseY, -d ), d ) / radius ) * tspeed;
				b = (Math.min( Math.max( holder.mouseX, -d ), d ) /radius ) * tspeed;
			} else {
				a = lasta * 0.98;
				b = lastb * 0.98;
			}
			lasta = a;
			lastb = b;
			// if a and b under threshold, skip motion calculations to free up the processor
			if( Math.abs(a) > 0.01 || Math.abs(b) > 0.01 ){
				var c:Number = 0;
				sineCosine( a, b, c );
				// bewegen van de punten
				for( var j:Number=0; j<mcList.length; j++ ) {
					// multiply positions by a x-rotation matrix
					var rx1:Number = mcList[j].cx;
					var ry1:Number = mcList[j].cy * ca + mcList[j].cz * -sa;
					var rz1:Number = mcList[j].cy * sa + mcList[j].cz * ca;
					// multiply new positions by a y-rotation matrix
					var rx2:Number = rx1 * cb + rz1 * sb;
					var ry2:Number = ry1;
					var rz2:Number = rx1 * -sb + rz1 * cb;
					// multiply new positions by a z-rotation matrix
					var rx3:Number = rx2 * cc + ry2 * -sc;
					var ry3:Number = rx2 * sc + ry2 * cc;
					var rz3:Number = rz2;
					// set arrays to new positions
					mcList[j].cx = rx3;
					mcList[j].cy = ry3;
					mcList[j].cz = rz3;
					// add perspective
					var per:Number = d / (d+rz3);
					// setmc position, scale, alpha
					mcList[j].x = rx3 * per;
					mcList[j].y = ry3 * per;
					mcList[j].scaleX = mcList[j].scaleY =  per;
					mcList[j].alpha = per/2;
				}
				depthSort();
			}
		}
		
		private function depthSort():void {
			mcList.sortOn( "cz", Array.DESCENDING | Array.NUMERIC );
			var current:Number = 0;
			for( var i:Number=0; i<mcList.length; i++ ){
				holder.setChildIndex( mcList[i], i );
				if( mcList[i].active == true ){
					current = i;
				}
			}
			holder.setChildIndex( mcList[current], mcList.length-1 );
		}
		
		/* See http://blog.massivecube.com/?p=9 */
		private function positionAll():void {		
			var phi:Number = 0;
			var theta:Number = 0;
			var max:Number = mcList.length;
			// mix up the list so not all a' live on the north pole
			mcList.sort( function(){ return Math.random()<0.5 ? 1 : -1; } );
			// distibute
			for( var i:Number=1; i<max+1; i++){
				if( distr ){
					phi = Math.acos(-1+(2*i-1)/max);
					theta = Math.sqrt(max*Math.PI)*phi;
				}else{
					phi = Math.random()*(Math.PI);
					theta = Math.random()*(2*Math.PI);
				}
				// Coordinate conversion
				mcList[i-1].cx = radius * Math.cos(theta)*Math.sin(phi);
				mcList[i-1].cy = radius * Math.sin(theta)*Math.sin(phi);
				mcList[i-1].cz = radius * Math.cos(phi);
			}
		}
		

		
		private function mouseExitHandler( e:Event ):void { active = false; }
		private function mouseMoveHandler( e:MouseEvent ):void { active = true; }
		private function resizeHandler( e:Event ):void { resizeHolder(); }
		
		private function resizeHolder():void {
			var s:Stage = this.stage;
			holder.x = s.stageWidth/2;
			holder.y = s.stageHeight/2;

			var scale:Number = ( s.stageWidth > s.stageHeight ) ? ( s.stageHeight/(radius*4) ) : ( s.stageWidth/(radius*4) );
			holder.scaleX = holder.scaleY =  scale;
		}
		
		private function sineCosine( a:Number, b:Number, c:Number ):void {
			sa = Math.sin(a * dtr);
			ca = Math.cos(a * dtr);
			sb = Math.sin(b * dtr);
			cb = Math.cos(b * dtr);
			sc = Math.sin(c * dtr);
			cc = Math.cos(c * dtr);
		}
		
		private function getNumberFromString( s:String ):Number {
			return( Number( s.match( /(\d|\.|\,)/g ).join("").split(",").join(".") ) );
		}
		
		private function getColorFromGradient( perc:Number ):Number {
			var r:Number = ( perc * ( tcolor >> 16 ) ) + ( (1-perc) * ( tcolor2 >> 16 ) );
			var g:Number = ( perc * ( (tcolor >> 8) % 256 ) ) + ( (1-perc) * ( (tcolor2 >> 8) % 256 ) );
			var b:Number = ( perc * ( tcolor % 256 ) ) + ( (1-perc) * ( tcolor2 % 256 ) );
			return( (r << 16) | (g << 8) | b );
		}
		
	}

}