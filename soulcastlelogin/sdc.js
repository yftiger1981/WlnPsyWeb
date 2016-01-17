var gDomain="sdc.pingan.com";	// SDC Production Mode Domain
var gDcsId="dcs82b9ujitigdu3gaykxw0hn_5p6b";
var gFpc="WT-FPC";
var gConvert=true;
var gWTIDJS=window.document.createElement("script"); 

window.document.getElementsByTagName("head")[0].appendChild(gWTIDJS); 

if ((typeof(gConvert)!="undefined")&&gConvert&&(document.cookie.indexOf(gFpc+"=")==-1)&&(document.cookie.indexOf("WTLOPTOUT=")==-1)){
  gWTIDJS.src="http"+(window.location.protocol.indexOf('https:')==0?'s':'')+"://"+gDomain+"/"+gDcsId+"/wtid.js"; 
}

setTimeout('setsdcjs()',0);
function setsdcjs(){
  var jDomain="pa-ssl.pingan.com";
  var js_path="/app_js/sdc/src/toa.js";
  var domain="http"+(window.location.protocol.indexOf('https:')==0?'s':'')+"://"+jDomain;
  var SDC_js=document.createElement("script");
  SDC_js.src=domain+js_path;
  var headElem=document.getElementsByTagName("head")[0];
  headElem.appendChild(SDC_js);   
}