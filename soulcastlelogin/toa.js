
function loadWTScript(a, b) {
	var c = document.createElement("script");
	c.type = "text/javascript",
	c.async = !0,
	c.src = a,
	dcsReady(c, b),
	document.getElementsByTagName("head")[0].appendChild(c)
}
function dcsReady(a, b) {
	a.readyState ? a.onreadystatechange = function() { ("loaded" == a.readyState || "complete" == a.readyState) && (a.onreadystatechange = null, b())
	}: a.onload = function() {
		b()
	}
}

var pt;
loadWTScript(window.location.protocol.indexOf('https:')==0?'https://pa-ssl.pingan.com/app_js/sdc/prd/sdc9.js':'http://www.pingan.com/app_js/sdc/prd/sdc9.js', function(){ 
    if (typeof(_tag) != "undefined"){
        _tag.dcsCustom=function(){
            _tag.DCSext.svrid='toa';
            var m = window.location.hostname.split('.');
            if(m[0]) _tag.DCSext.toa_dom=m[0];

            var o=document.getElementsByTagName("h1")[0];
            if(o)  _tag.WT.ti=pt=o.innerText||o.textContent
            else _tag.WT.ti=pt=document.title;
            
            if (_tag.WT.page_name){
                _tag.WT.ti=pt=pt+'-'+_tag.WT.page_name;
            }
        }

        _tag.dcsE = function(evt) {
        var t;
        if (document.all) t = window.event.srcElement;
        else t = evt.target;

        var a=_tag.WT;
        a.tsp=a.ttp=a.ti=a.obj=a.inputval=a.area=a.obj=a.texturl=a.textarea=a.textSerial=null;

        if(!_tag.dcsv(t, "otitle"))
        {
            var p=t;
            for(var i=0;i<4;i++)
            {
                if(p.parentNode)
                {
                    p = p.parentNode;
                    if (p && _tag.dcsv(p, "otitle")) {
                        t = p;
                        break;
                    }
                }
                else break;
            }
        }

        var tn = t.tagName.toLowerCase();
        if(tn=="select"&&evt.type!="change") return;
        if (t != _tag.lt) _tag.lt = t;
        else if (t == _tag.lt && evt.type == "focus") return;
        if (_tag.dcsv(t, "otitle")||_tag.dcsv(t, "otype")||_tag.dcsv(t, "omenu")){

        a.ti = _tag.dcsv(t, "otitle");
        a.obj = _tag.dcsv(t, "otype");
        a.area = _tag.dcsv(t, "oarea");

        if(a.ti)
        {
            if(!a.obj||a.obj.indexOf("adtext")<0) a.obj = "button";
        }
        else if(_tag.dcsv(t, "omenu"))//toa
        {
           a.ti = _tag.dcsv(t, "omenu");
           if(!a.obj||a.obj.indexOf("adtext")<0) a.obj = "menu";
        }

        if(tn=="a"&&a.obj&&a.obj.indexOf("adtext")>-1)
        {
            a.texturl = t.href;
            a.textarea = _tag.dcsv(t,"adtextArea");   
            a.ti = t.innerText||t.textContent||a.ti;
            var o = document.getElementsByTagName("A");    
            var i,j;
            for(i=0,j=0;i<o.length;i++)
            {
                if(_tag.dcsv(o[i],"adtextArea")==a.textarea) 
                {
                    j++;
                    if(o[i] == t)
                    {   
                        a.textSerial = j;break;
                    }
                }
            }
        }
        else if(t.type=="text"||tn=="textarea") {
            if(evt.type == "click") return;    
            else if(evt.type == "blur")
            {
                if(t.value=='') {_tag.lt=t;_tag.ltv=t.value;return}
                if(t==_tag.lt&&t.value==_tag.ltv) {return}
                a.inputval = t.value;
                a.obj = "input"
            }
        }
        else
        if(t.type=="radio"){
            a.inputval=t.value
        }
        else
        if(t.type=="checkbox"){
            a.inputval=t.checked?"1":"0"
        }
        else
        if(tn=="select"){
            a.inputval=t.options[t.selectedIndex].text
        }
        a.ti=a.ti||"null";
        var url=window.location.pathname+"\/"+evt.type+".event";
        a.pageurl="http://"+window.location.hostname+window.location.pathname;
        if(_tag.DCSext.toa_dom&&pt) {a.ti=pt+'-'+a.ti;a.pagetitle=pt}
        else a.pagetitle = document.title;
        _tag.lt=t;_tag.ltv=t.value;
        _tag.dcsMultiTrack('DCS.dcsuri',url,'WT.dl',25,'DCSext.wt_click','page');
        }
        }
        
        
        var s=_tag.dcsGetIdAsync();
        if(s) 
            dcsReady(s,function(){_tag.dcsCollect()});
        else
            _tag.dcsCollect();
    }
})
