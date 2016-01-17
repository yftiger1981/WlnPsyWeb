/*-----------------------------------------------------------
 *version: fwkj 1.0
 *author: renze
 *email: 289426557@qq.com
 *date:2014-1-9 13:34
 *桌面基础库和资源加载脚本
 ----------------------------------------------------------*/
//声明mydesktop命名空间 
var myLogin = {};

//页面布局模块
myLogin.layout = {
    syinit: function () {
        var sywrap = $("#sywrap"),
        sytopBar = $("#sytopBar"),
        systateBar = $("#systateBar"),
        cxslide = sywrap.find(".cxslide"),
        cxslidebox = sywrap.find(".cxslide .box"),
        cxslideboxlist = sywrap.find(".cxslide .list li");

        //计算中间模块高度
        var mh = $(window).height() - sytopBar.height() - systateBar.height(),
        //mw = sywrap.width();
        mw = $(window).width()

        sywrap.css({
            width: mw,
            height: mh,
            top: sytopBar.height()
        });

        cxslide.css(
            {
                width: mw,
                height: mh
            });

        cxslidebox.css(
            {
                width: mw,
                height: mh
            });
        cxslideboxlist.css(
            {
                width: mw,
                height: mh
            });

        // 自定义参数调用 
        $("#element_id").cxSlide({
            events: "click",
            type: "x",
            speed: 800,
            time: 5000,
            auto: true,
            btn: true,
            plus: false,
            minus: false
        });
    }
};