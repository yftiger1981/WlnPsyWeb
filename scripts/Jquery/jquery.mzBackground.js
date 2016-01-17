/*------背景插件---------------
 *date:2013-12-5
 *version:1.0
 *author:muzilei
 *blog:http://www.muzilei.com/
 *email:530624206@qq.com
------------------------------*/
(function($) {   
  $.fn.mzBackground = function(options) {  
     var opts = $.extend({}, $.fn.mzBackground.defaults, options);  
     return this.each(function(){
		     var _this=$(this);
			 
			 bgInit(_this,opts);
			 
			 window.onresize=function(){
				 _this.find("img").remove();
  				 bgInit(_this,opts);
				 };
			
	 });	  
  };  
  	
	//初始化函数
	function bgInit(_this,opts){
		//获取容器大小
			 var o_w=_this.width(),o_h=_this.height();

			 //如果是平铺
			 if(opts.bgShowType=="tile"){
 			 setBgimg(_this,opts.imgSrc,o_w,o_h,0);
			 }
			 
			 //如果是居中
			 if(opts.bgShowType=="middle"){
			 setBgimg(_this,opts.imgSrc,o_w,o_h,1);
			 }
			 
			 //如果是拉伸
			 if(opts.bgShowType=="stretch"){
			 setBgimg(_this,opts.imgSrc,o_w,o_h,2);
			 }
			 
			 if(opts.bgShowType=="auto"){
 			    getImgWh(opts.imgSrc,function(w,h){
					var imgw=0;imgh=0,mt=0;
					
				       imgw=o_w;
					   imgh=(o_w/w)*h;
					  
					   if(imgh<o_h){
 						   imgw=(o_h/imgh)*imgw;
						   imgh=o_h;
						   if(imgw>o_w){
							   mt=0;
							   ml=(o_w-imgw)/2;
							   }
 						   }else{
							   ml=0;
							   mt=(o_h-imgh)/2;
							   }
  					setBgimg(_this,opts.imgSrc,imgw,imgh,3,mt,ml);
  				 }); 
			 }
		}
	//插入背景图片，设置大小
	function setBgimg(_this,imgSrc,ow,oh,type,mt,ml){
		 if(type==0){
			 _this.css("background","url("+imgSrc+") repeat");
			 }
		 if(type==1){
			 _this.css("background","url("+imgSrc+") no-repeat center center");
			 }	
		 if(type==2){
			 _this.html("<img src='"+imgSrc+"' width='"+ow+"' height='"+oh+"' />");
			 }
	     if(type==3){
			 _this.html("<img src='"+imgSrc+"' width='"+ow+"' height='"+oh+"' style='margin-top:"+mt+"px;margin-left:"+ml+"px'/>");
			 }
		}
    //获取图片真实大小		 
	function getImgWh(url, callback) {
					var width, height, intervalId, check, div, img = new Image(),
						body = document.body;
						
						img.src = url;
			
					//从缓存中读取
					if (img.complete) {
					  return callback(img.width, img.height);
					};
			
					//通过占位提前获取图片头部数据
					if (body) {
					  div = document.createElement('div');
					  div.style.cssText = 'visibility:hidden;position:absolute;left:0;top:0;width:1px;height:1px;overflow:hidden';
					  div.appendChild(img);
					  body.appendChild(div);
					  width = img.offsetWidth;
					  height = img.offsetHeight;
					  check = function() {
						if (img.offsetWidth !== width || img.offsetHeight !== height) {
						  clearInterval(intervalId);
						  callback(img.offsetWidth, img.clientHeight);
						  img.onload = null;
						  div.innerHTML = '';
						  div.parentNode.removeChild(div);
						};
					  };
					  intervalId = setInterval(check, 150);
					};
					// 加载完毕后方式获取
					img.onload = function() {
					  callback(img.width, img.height);
					  img.onload = img.onerror = null;
					  clearInterval(intervalId);
					  body && img.parentNode.removeChild(img);
					};
		      }
   
  //默认参数
  $.fn.mzBackground.defaults = {
			 bgShowType:"auto",   //背景图显示方式,tile：平铺,middle:居中,stretch:拉伸,auto:根据图片大小自动判断选择哪种方式
			 imgSrc:""           //背景图片路径
 			};  
// 闭包结束  
})(jQuery);  