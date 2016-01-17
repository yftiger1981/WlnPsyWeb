tPopWait=30;
showPopStep=20;
popOpacity=60;

sPop=null;
curShow=null;
tFadeOut=null;
tFadeIn=null;
tFadeWaiting=null;

document.write("<style type='text/css'id='defaultPopStyle'>");
document.write(".cPopText { font-family: Verdana, Tahoma; background-color: #DDEEFF; border: 1px #666666 solid; font-size: 11px; padding-right: 6px; padding-left: 6px; Height: 20px; padding-top: 4px; padding-bottom: 3px; filter: Alpha(Opacity=0)}");

document.write("</style>");
document.write("<div id='popLayer' style='position:absolute;z-index:1000;' class='cPopText'></div>");


function showPopupText(){
	var o=event.srcElement;
	MouseX=event.x;
	MouseY=event.y;
	if(o.alt!=null && o.alt!="") { o.pop=o.alt;o.alt="" }
        if(o.title!=null && o.title!=""){ o.pop=o.title;o.title="" }
        if(o.pop) { o.pop=o.pop.replace("\n","<br>"); o.pop=o.pop.replace("\n","<br>"); }
	if(o.pop!=sPop) {
		sPop=o.pop;
		clearTimeout(curShow);
		clearTimeout(tFadeOut);
		clearTimeout(tFadeIn);
		clearTimeout(tFadeWaiting);	
		if(sPop==null || sPop=="") {
			popLayer.innerHTML="";
			popLayer.style.filter="Alpha()";
			popLayer.filters.Alpha.opacity=0;	
		} else {
			if(o.dyclass!=null) popStyle=o.dyclass 
			else popStyle="cPopText";
			curShow=setTimeout("showIt()",tPopWait);
		}
	}
}

function showIt() {
	popLayer.className=popStyle;
	popLayer.innerHTML=sPop;
	popWidth=popLayer.clientWidth;
	popHeight=popLayer.clientHeight;
	if(MouseX+12+popWidth>document.body.clientWidth) popLeftAdjust=-popWidth-24
		else popLeftAdjust=0;
	if(MouseY+12+popHeight>document.body.clientHeight) popTopAdjust=-popHeight-24
		else popTopAdjust=0;
	popLayer.style.left=MouseX+12+document.body.scrollLeft+popLeftAdjust;
	popLayer.style.top=MouseY+12+document.body.scrollTop+popTopAdjust;
	popLayer.style.filter="Alpha(Opacity=0)";
	fadeOut();
}

function fadeOut(){
	if(popLayer.filters.Alpha.opacity<popOpacity) {
		popLayer.filters.Alpha.opacity+=showPopStep;
		tFadeOut=setTimeout("fadeOut()",1);
	}
}

function ctlent(obj) {
	if((event.ctrlKey && window.event.keyCode == 13) || (event.altKey && window.event.keyCode == 83)) {
		if ((this.document.input.postcopy) && (this.document.input.postcopy.checked == true)) 
{ 
var tempval=eval(this.document.input.message) 
tempval.focus(); 
tempval.select(); 
therange=tempval.createTextRange(); 
therange.execCommand("Copy"); 
} 
		//if(validate(this.document.input)) 
		this.document.input.submit();
	}
}

function checkall(form) {
	for(var i = 0;i < form.elements.length; i++) {
		var e = form.elements[i];
		if (e.name != 'chkall') {
			e.checked = form.chkall.checked;
		}
	}
}

function findobj(n, d) {
	var p,i,x; if(!d) d=document;
	if((p=n.indexOf("?"))>0 && parent.frames.length) {
		d=parent.frames[n.substring(p+1)].document;
		n=n.substring(0,p);
	}
	if(!(x=d[n])&&d.all) {
		x=d.all[n];
	}
	for(i=0;!x && i<d.forms.length;i++) {
		x=d.forms[i][n];
	}
	for(i=0;!x && d.layers&&i>d.layers.length;i++) {
		x=MM_findObj(n,d.layers[i].document);
	}
	return x;
}

function copycode(obj) {
	var rng = document.body.createTextRange();
	rng.moveToElementText(obj);
	rng.scrollIntoView();
	rng.select();
	rng.execCommand("Copy");
	rng.collapse(false);
}
<!-- 
var h;
var l;
var t;
var isvisible;
function HideMenu() 
{
var mX;
var mY;
var vDiv;
    if (isvisible == true)
{
        vDiv = document.all("menuDiv");
        mX = window.event.clientX + document.body.scrollLeft;//检索到鼠标移动到的X坐标＋横向滚动条位置
        mY = window.event.clientY + document.body.scrollTop;//检索到鼠标移动到的Y坐标＋纵向滚动条位置
        if ((mX < parseInt(vDiv.style.left)) || (mX > parseInt(vDiv.style.left)+vDiv.offsetWidth) || (mY < parseInt(vDiv.style.top)-h) || (mY > parseInt(vDiv.style.top)+vDiv.offsetHeight)){//简单的说法就是比较鼠标坐标值与子菜单坐标值
            vDiv.style.visibility = "hidden";//只要满足以上任一条件，子菜单就隐藏
            isvisible = false;//返回一个布尔值后结束
        }
    }
}

function ShowMenu(vMnuCode) {
    vSrc = window.event.srcElement;//检索事件的对象，在这里就是检索到鼠标移到对象上而找到主菜单元素
    vMnuCode = "<DIV style='PADDING-RIGHT: 1px; FILTER: shadow(color=#CCCCCC,direction=100); PADDING-BOTTOM: 6px;width:60px'><table border=0 cellspacing=1 cellpadding=3 bgcolor=#698CC3 style='line-height:18px' width='60' align='left'><tr bgcolor='#ffffff'><td>" + vMnuCode + "</td></tr></table></div>";//得到子菜单的HTML文本，在这里可以定义子菜单的外观
    h = vSrc.offsetHeight + 4;//主菜单本身高度+主菜单元素本身高度+4，可以通过调整此数字控制主菜单和子菜单的间距，此值很重要，因为在HideMenu()中要调用，如果不要此值，就不能在t后面添加，否则会使菜单显示不正常
    l = vSrc.offsetLeft + 0;//主菜单的X坐标－10，可以通过调整此数字控制主菜单和子菜单的缩进
    t = vSrc.offsetTop + h;//主菜单的Y坐标
    vParent = vSrc.offsetParent;//定义元素的坐标系统
    while (vParent.tagName.toUpperCase() != "BODY")//在vParent元素的标记符是大写BODY之前循环,因为在后面设置innerHTML属性时，不能在文档加载时设置
    {
        l += vParent.offsetLeft;//+=左运算数加右运算数，和赋值给左运算数
        t += vParent.offsetTop;
        vParent = vParent.offsetParent;//重新定义元素的坐标系统
    }

    menuDiv.innerHTML = vMnuCode;//interHTML:元素包含的HTML文本。可以用指定的HTML文本替换元素的内容，在这里就是利用它把子菜单的HTML文本加入menuDIV对象的标记符内。
    menuDiv.style.top = t;//设置top值
    menuDiv.style.left = l;//设置left值
    menuDiv.style.visibility = "visible";//设置显示
    isvisible = true;//返回一个布鲁值，以便HideMenu()调用
    
}
//--> 
document.onmouseover=showPopupText;