// 判断是否为ie6浏览器
var isMsIe6 = false;
// 针对IE6 不支持验证码显示的解决方案，显示用户提示
if($.browser.msie && $.browser.version == '6.0'){
    isMsIe6 = true;
    getFcmmValidCode = function(imgId, codeId, url, appId) {
        $("#" + imgId).attr("src", InterfaceLoginObj.pinganoneUrl + "/pinganone/pa/paic/common/vcode.do?r="+Math.random());
        $("#" + codeId).attr("name", "");
        $("#" + codeId).attr("value", "");
    };              
    $("#vcodeVer").val("");
    $('#J_verifyCode_tr').show().data('show', true);
    $('#validCode').val('').data('isValidCode', true);
    getFcmmValidCode('validateImg','validCodeId');
    //showErrorInfo("手机注册不支持IE6浏览器，请升级到IE8以上版本", "check_info");
}
//展示成功提示
function showCorrectInfo(str, id) {
    var _div = "<div class='pa_ui_valid_tip pa_ui_validator_oncorrect'>" + str + "</div>";
    $('#' + id).html(_div).show();
}
//展示错误提示
function showErrorInfo(str, id) {
    var _div = "<div class='pa_ui_valid_tip pa_ui_validator_onerror'>" + str + "</div>";
    $('#' + id).html(_div).show();
}
// 输入框添加focus、error样式
function applyElClass(el, type){
    el.removeClass('valid_csselfocus').removeClass('valid_csselerror');
    var elParent = el.parent().removeClass('valid_csselfocus').removeClass('valid_csselerror');
    if(type){
        elParent.addClass('valid_cssel'+type);
    }               
}

if (!isMsIe6) {
    $('#userID').bind('blur', function() {
        // 有改变
        if ($('#userID').val() != $('#userID').data('name')) {
            $('#J_verifyCode_tr').hide().data('show', false);
            $('#validCode').val('').data('isValidCode', false);
        }
        $('#userID').data('name',$('#userID').val());
    });
}
$('#J-changeVerifyImg').bind('click', function(){
    if (isMsIe6) {
       getFcmmValidCode('validateImg','validCodeId','<c:out value="${pinganoneUrl}" escapeXml="false"></c:out>/pinganone/pa/paic/common/urlvcode.do');
   } else {
        // 验证码AJAX
        phoneLogin.ajaxAuthCode('mima', function(data) {
            $('#validCodeId').val(data.id);
            $('#J_verifyCode_tr').show().data('show', true);
            $('#validateImg').attr('src', data.img);
            // 记录图形验证码ID
            $('#validCode').val('').data('isValidCode', true);
        });
   }
});

function clickSubmit() {
    var verifyCode_isShow = $('#J_verifyCode_tr').data('show');

    var isValid = validForm();

    if (!isValid) {
        return false;
    }

    // 是否已经展示验证输入
    if (!verifyCode_isShow ) {

        // 验证码AJAX
        phoneLogin.ajaxAuthCode('mima', function(data) {
            $('#validCodeId').val(data.id);
            
            // 要显示图形验证码
            if (data.type == '0') {
                $('#J_verifyCode_tr').show().data('show', true);
                $('#validateImg').attr('src', data.img);
                // 记录图形验证码ID
                $('#validCode').val('').data('isValidCode', true);
            } else {
               submitForm(); 
            }
            
        });
    } else {
        submitForm();
    }
};

$('#loginlink').bind('click', clickSubmit);

function validForm() {
        //记住用户名选择框被勾选的`时候
    var remember = $('#remember');
    // 是否要验证验证码输入
    var isValidCode = $('#validCode').data('isValidCode');
    if(remember.attr("checked")){
        var userID = $('#userID').val();
        setUserID("userID", userID);
    }
    //用户名密码没输入的时候出现的提示信息                
    var userID = $('#userID').val();
    var password = $('#v_password').val();
    var validCode = $('#validCode').val();
    var errorArray = [];
    
    if(''==userID){
        applyElClass($('#userID'), 'error');
        errorArray.push('用户名或密码不能为空');
    }
    if(''==password){
        applyElClass($('#v_password'), 'error');
        errorArray.push('用户名或密码不能为空');
    }
    if(''==validCode && isValidCode){
        applyElClass($('#validCode'), 'error');
        errorArray.push('验证码不能为空');
    }
    // 判断是否有错误信息
    if(errorArray.length>0){
        showErrorInfo(errorArray[0], "sysTip");
        return false;
    }
    
    var isValid = $('#login_form').validator({triggerOnSubmit : false }).validator('check');
    return isValid;
}

//提交按钮
function submitForm() {

    var isLoging = $("#loginlink").data('isLoging');

    if (isLoging) {
        return false;
    }

    if (!isLoging) {
        //禁用按钮
        $("#loginlink").text('正在登录，请稍候...').data('isLoging', true);

        if (isMsIe6) {
            submitLoginForm();
        } else {
            
            if ( $('#J_verifyCode_tr').data('show') ) {
                var data = {
                    validCode: $("#validCode").val(),
                    validCodeId: $("#validCodeId").val(),
                    appId: InterfaceLoginObj.appId,
                    userId: $('#userID').val()
                }
                // 免验证码登录需求验证码检查接口
                $.getJSON(InterfaceLoginObj.pinganoneUrl + '/pinganone/pa/checkAppVcode.do?callback=?', data, function(data) {
                    $('#loginlink').attr('data-status', 'checkAppVcode');
                    if (data.data.returnCode == '0000') {
                        submitLoginForm();
                    } else {
                        showErrorInfo(data.data.returnMsg, "sysTip");
                        //恢复按钮
                        $("#loginlink").text('登录').data('isLoging', false);
                    }
                    
                });
            } else {
                submitLoginForm();
            }
        }
        
    } else {
        //恢复按钮
        $("#loginlink").text('登录').data('isLoging', false);
    }
    return false;
}
// 提交登录请求
function submitLoginForm(){
    //密码加密
    var PublicKey = InterfaceLoginObj.publicKey;
    var pwd = $("#v_password").val();
    var RSA = new RSAKey();
    RSA.setPublic(PublicKey, "10001");
    var Res = RSA.encrypt(pwd);
    $("#loginPwd").val(Res);
    //发送签名串给后台
    $.ajax({
        type : "GET",
        async : false,
        cache : false,
        url : "./param-sign.ajax",
        data : {
            userID : $("#userID").val()
        },
        success : function(data) {
            $('#loginlink').attr('data-status', 'param-sign');
            var signData = eval("(" + data + ")");
            $('#signature').val(signData.sign);
            //获取后台返回的时间戳
            $('#timestamp').val(signData.timestamp);
            $('#appId').val(signData.appID);
            $('#regResource').val(signData.appID);
            //提交表单
            $("#login_form").attr("method", "post");
            if (isMsIe6) {
                // 验证图形验证码的正确性和有效性
                $("#login_form").attr("action", InterfaceLoginObj.pinganoneUrl + "/pinganone/pa/appLogin.view");
            } else {
                // 移动终端登录认证接口
                $("#login_form").attr("action", InterfaceLoginObj.pinganoneUrl + "/pinganone/pa/appVcodeLogin.do");
            }
            // 表单方式登录
            // $("#login_form").submit();

            // AJAX方式登录
            login(signData);
        }
    });
}
function login(signData) {
    var prame = {
        appId: signData.appID,
        userID: $('#userID').val(),
        loginPwd: $("#loginPwd").val(),
        validCodeId: $('#validCodeId').val(),
        validCode: $('#validCode').val(),
        signature: signData.sign,
        timestamp: signData.timestamp,
        backFormat: 'json'
    };

    $.ajax({
        url: InterfaceLoginObj.pinganoneUrl + "/pinganone/pa/appVcodeLogin.do?callback=?",
        type : "GET",
        timeout : 5000,
        async : false,
        cache : false,
        dataType:'jsonp',
        data : prame,
        success : function(data) {
            $('#loginlink').attr('data-status', 'appVcodeLogin');
            if (data && data.status === 'success' ) {
                data.data.ptag = $('#ptag').val(); 
                $.ajax({
                    url: "/customer/commonLogin.do",
                    type : "POST",
                    dataType: "json",
                    async : false,
                    cache : false,
                    data : data.data,
                    success : function(res) {
                        $('#loginlink').attr('data-status', 'commonLogin');
                        loginCallback(res);
                    },
                    error : function(res) {
                        // 登录超时
                        showErrorInfo('登录超时，请重新登录', "sysTip");
                        $("#loginlink").text('登录').data('isLoging', false);
                    }
                });
            } else {
                //登录失败
                var str = data.msg || '一账通登录异常';
                showErrorInfo(str, "sysTip");
                $("#loginlink").text('登录').data('isLoging', false);
            }
        },
        error: function() {
            //一账通登录异常
            showErrorInfo('一账通登录异常', "sysTip");
            $("#loginlink").text('登录').data('isLoging', false);
        }
    });
}

function loginCallback(data) {
    if (data && data.resultCode == 'Y') {

        // 同步登录官网和4008时，iframe超时的处理办法
        setTimeout('memberSSO()', 15000);

       /* // 处理万里通账号异常
        phoneLogin.updateWltmember();
*/
        // 登录成功后同步登录4008
        var iframe = document.createElement('iframe');
        iframe.style.display = 'none';
        iframe.src = '/customer/logon/loginTickets.jsp';
        document.body.appendChild(iframe);
    } else {

        //登录失败
        var str = data.msg || '会员系统登录异常';
        showErrorInfo(str, "sysTip");
        $("#loginlink").text('登录').data('isLoging', false);
    }
}
$(document).ready(function() {

    // 密码框focus , blur事件
    $('#userID,#v_password,#validCode').bind('focus',function(){
        applyElClass($(this), 'focus');                 
    }).bind('blur',function(){
        applyElClass($(this));
    });
    $("input").focus(function() {
        $("#sysTipText").text("");
        $("#sysTipText").attr("style", "border: 0px");
    });

    getUserID("userID", "userID");
    getUserID("optPhoneID", "J-phoneLogin-phone");
});

//记住用户名
function setUserID(name, value){
    var Days = 30; //此 cookie 将被保存 30 天
    var exp = new Date();
    exp.setTime(exp.getTime() + Days*24*60*60*1000);
    document.cookie = name +" = "+ escape (value) + ";expires=" + exp.toGMTString();
}
//读取用户名
function getUserID(name, el){
    var arr = document.cookie.match(new RegExp("(^| )"+name+"=([^;]*)(;|$)"));
    if(arr != null)
    $('#'+ el).val(unescape(arr[2]));
    return null;
} 

// 来源：生态圈
if ($('#actionSource').val() == 'emall') {
    $('body').addClass('emall-wrap');
}

// TAB切换
$('#J-tabTitle > li').bind('click', function() {
    var index = $('#J-tabTitle > li').index(this);
    $(this).addClass('current').siblings().removeClass('current');
    if (index == 0) {
        $('#J-tabCont1').show();
        $('#J-tabCont2').hide();
    } else {
        $('#J-tabCont1').hide();
        $('#J-tabCont2').show();
        phoneLogin.init();
    }
});

// 手机登录
var phoneLogin = {

    // 是否已经初始化
    isInit: false,

    // 图形验证码ID
    authCodeId: '',

    // 短信动态密码ID
    smsCodeId: '',

    // 缓存手机号
    tempPhoneNum: '',

    // appId
    appId: InterfaceLoginObj.appId || '10023',

    // 登录成功后，调转的目标页面
    targetUrl: InterfaceLoginObj.targetUrl || 'http://' + location.hostname + '/member/index.shtml',

    // 页面元素
    elem: {

        // 手机号输入框
        input_phone: $('#J-phoneLogin-phone'),

        // 图形验证码输入框
        input_authCode: $('#J-phoneLogin-authCode'),

        // 短信动态密码输入框
        input_sms: $('#J-phoneLogin-sms'),

        // 图形验证码父级DIV
        wrap_authCode: $('#J-phoneLogin-authCode-wrap'),

        // 图形验证码图片
        img_authCode: $('#J-phoneLogin-authCode-img'),

        // 切换图形验证码的按钮
        btn_authCodeChange: $('#J-phoneLogin-authCode-change'),

        // 发送短信动态密码的按钮
        btn_sms: $('#J-phoneLogin-sms-btn'),

        // 注册按钮
        btn_register: $('.J-registerBtn'),

        // 登录按钮
        btn_submit: $('#J-phoneLogin-submit'),

        // 开通登录
        btn_loginUserInfo: $('#J-loginUserInfo')
    },

    // 手机号注册次数AJAX （2：注册次数2次 1：手机已经被注册 0：手机号未被注册 -1：系统异常 -2：手机号码为空）
    getCountMobileNo: function(callback) {
        var self = this,
            elem = self.elem,
            url = '/customer/getCountMobileNo.do',
            data = {
                mobileNo: elem.input_phone.val(),
                flowID: InterfaceLoginObj.ptag
            },
            options = {
                url: url,
                type: 'GET',
                dataType: 'json',
                data: data,
                jsonp: 'callBack',
                success: function(res) {
                    callback && callback(res);
                }
            };
        $.ajax(options);
    },

    // 根据手机号查询是否投保过的帐户
    queryAccountByMobileNo: function(callback) {
        var self = this,
            elem = self.elem,
            url = '/customer/queryAccountByMobileNo.do',
            data = {
                mobileNo: elem.input_phone.val()
            },
            options = {
                url: url,
                type: 'GET',
                dataType: 'json',
                data: data,
                jsonp: 'callBack',
                success: function(res) {
                    callback && callback(res);
                }
            };
        $.ajax(options);
    },

    // 图形验证码AJAX
    ajaxAuthCode: function(type, callback) {
        var self = this,
            elem = self.elem,
            url = InterfaceLoginObj.pinganoneUrl + '/pinganone/pa/paic/common/appvcode.do',
            data = {
                userId: type == 'otp' ? elem.input_phone.val() : $('#userID').val(),
                appId: self.appId,
                subsys: type
            },
            options = {
                url: url,
                type: 'GET',
                dataType: 'jsonp',
                data: data,
                jsonp: 'callBack',
                success: function(res) {
                    callback && callback(res);
                }
            };
        $.ajax(options);
    },

    // 短信动态密码AJAX
    ajaxSmsCode: function(callback) {
        
        var self = this,
            elem = self.elem,
            url = InterfaceLoginObj.pinganoneUrl + '/pinganone/pa/sendShortMessageBfappvcode.do';
        if (!self.authCodeId) {return;}
        var data = {
                mobileNo: elem.input_phone.val(),
                validCodeId: self.authCodeId,
                validCode: elem.input_authCode.val(),
                appId: self.appId
            },
            options = {
                url: url,
                type: 'GET',
                dataType: 'jsonp',
                data: data,
                jsonp: 'callBack',
                success: function(res) {
                    callback && callback(res);
                }
            };
        
        $.ajax(options);
    },

    // 登录AJAX
    ajaxSubmit: function(callback) {
        var self = this,
            elem = self.elem,
            url = '/customer/mobileLogin.do',
            data = {
                mobileNo: elem.input_phone.val(),
                activeNo: elem.input_sms.val(),
                activeId: self.smsCodeId,
                optType: 'login',
                ptag: InterfaceLoginObj.ptag
            },
            options = {
                url: url,
                type: 'GET',
                dataType: 'json',
                data: data,
                success: function(res) {
                    callback && callback(res);
                }
            };
        $.ajax(options);
    },

    // 事件
    bind: function() {
        var self = this, elem = self.elem;

        // 换一张图形验证码
        elem.btn_authCodeChange.bind('click', function() {

            // 验证码AJAX
            self.ajaxAuthCode('otp', function(data) {

                // 记录图形验证码ID
                self.authCodeId = data.id;

                // 图形验证码重新赋值
                elem.img_authCode.attr('src', data.img);
            });
        });

        // 发送短信动态密码
        elem.btn_sms.bind('click', function() {
            // 判断走登录流程还是注册流程
            phoneLogin.loginOrRegister();
        });

        // 注册
        elem.btn_register.bind('click', function() {
            location.href = 'http://' + location.hostname + '/customer/toRegisterUser.do?type=07&flowID=' + InterfaceLoginObj.ptag + '&target=' + phoneLogin.targetUrl;
        });

        // 开通登录
        elem.btn_loginUserInfo.bind('click', function() {
            location.href = 'http://' + location.hostname + '/member/user/userInfo.shtml';
        });

        // 登录
        elem.btn_submit.bind('click', phoneLogin.submit);

        // 手机输入框
        elem.input_phone.bind('blur', function() {
            // 手机号有改变
            if (elem.input_phone.val() != phoneLogin.tempPhoneNum) {
                phoneLogin.resetUi();
            }
        });
    },

    // 重置UI
    resetUi: function() {
        var elem = this.elem;
        elem.wrap_authCode.hide();
        phoneLogin.tempPhoneNum = elem.input_phone.val();
    },

  /*  // 处理万里通账号异常
    updateWltmember: function() {
        $.ajax({
            type : "GET",
            cache : false,
            url : "/customer/updateWltmember.do"
        });
    },*/

    // 提交
    submit: function() {
        var elem = phoneLogin.elem;
        phoneLogin.ajaxSubmit(function(data) {

            // Loading
            elem.btn_submit.text('正在登录，请稍候...');
            elem.btn_submit.unbind('click', phoneLogin.submit);

            if (data.resultCode == 'Y') {

                // 记住手机号
                if($('#J-phoneLogin-remembertel').attr("checked")) {
                    setUserID('optPhoneID', elem.input_phone.val());
                }

             /*   // 处理万里通账号异常
                phoneLogin.updateWltmember();*/

                // 登录成功
                var iframe = document.createElement('iframe');
                iframe.style.display = 'none';
                iframe.src = '/customer/logon/loginTickets.jsp';
                document.body.appendChild(iframe);
            } else if (data.resultCode == 'N') {

                //登录失败
                var msg = {
                        '0020': '短信动态密码无效，请重新输入',
                        '0011': '抱歉，系统异常，请稍候再试',
                        '0012': '该手机曾在多个账户内登记，暂不支持手机登录，请使用用户名加密码登录',
                        '0013': '请传入参数',
                        '0014': '用户不存在',
                        '0015': '您的账户异常，暂不能使用一账通',
                        '0017': '账户已被锁定',
                        '0018': '短信动态密码已过期，请重新获取',
                        '0019': '短信动态密码错误，请重新输入',
                        '01'  : '手机号不能为空',
                        '02'  : '短信动态密码不能为空'
                    },
                    str = msg[data.messageCode] || '系统异常';
                showErrorInfo(str, "J-phoneLogin-prompt");

                elem.btn_submit.text('登录');
                elem.btn_submit.bind('click', phoneLogin.submit);
            }
        });
    },

    /**
     * 倒记时
     * @param  {object} options         设置参数
     * @param.fresh_text {string}       倒计时结束要显示的文字，默认使用按钮最初的文字
     * @param.count {string}            倒计时的秒数
     * @param.btn {string}              一个input button对像
     * @param.ext_text {string}         在显示的秒数后面要附加的说明性文字
     * @param.ext_class {string}        倒计时中给A标签添加的class
     * @param.callback {string}         倒计时结束要执行的函数，也可以不设置
     */
    doTimeoutCount: function(options) {

        var isA = options.btn[0].nodeName == 'A';

        if (typeof(options.ext_class) === 'undefined'){
            options.ext_class = 'disabled';
        }

        if (typeof(options.fresh_text) === 'undefined'){
            options.fresh_text = isA ? options.btn.text() : options.btn.val();
        }
        if (isA) {
            options.btn.addClass(options.ext_class).text(options.count + options.ext_text);
        } else {
            options.btn.attr('disabled', true).val(options.count + options.ext_text);
        }

        var handle = setInterval(count_down, 1000);

        // 在每个周期中要执行的操作
        function count_down() {
            if (--options.count > 0) {
                if (isA) {
                    options.btn.text(options.count + options.ext_text);
                } else{
                    options.btn.val(options.count + options.ext_text);
                }
            } else {
                clearInterval(handle);
                if (isA) {
                    options.btn.removeClass(options.ext_class).text(options.fresh_text);
                } else {
                    options.btn.attr('disabled', false).val(options.fresh_text);
                }
                if (typeof(options.callback) !== 'undefined'){
                    options.callback();
                }
            }
        }
    },

    // 根据手机号注册次数，判断是该进行登录流程，还是转到注册流程
    loginOrRegister: function() {
        // 判断走登录流程还是注册流程
        phoneLogin.getCountMobileNo(function(data) {
            if (data.resultCode == 'Y') {
                if (data.res == '0') {
                    // 手机号未被注册，查询是否投过保
                    phoneLogin.whichRegister();
                } else if (data.res == '-1') {
                    // 系统异常
                    showErrorInfo('系统异常！', "J-phoneLogin-prompt");
                } else if (data.res == '-2') {
                    // 手机号码为空
                    showErrorInfo('手机号码为空！', "J-phoneLogin-prompt");
                } else {
                    // 手机号已被注册，可以继续走登录流程,发送短信动态密码
                    phoneLogin.sendValidCode();
                }
            }
        });
    },

    // 未被注册过的手机号，查询是否投过保
    whichRegister: function() {
        var elem = this.elem;
        phoneLogin.queryAccountByMobileNo(function(data) {
            if (data.resultCode == 'Y') {
                if (data.account == '') {
                    // 该手机号没有投过保
                    $('.J-register-mobileNo').text(elem.input_phone.val());
                    $.pa_ui.dialog.open({
                        title: '手机动态码注册',
                        dialogClass: 'dialog_default',
                        minimize: false,
                        maximize: false,
                        element: 'registerNoAccount',
                        width: 700,
                        height: 300
                    });
                } else {
                    // 该手机号有投过保
                    $('.J-register-mobileNo').text(elem.input_phone.val());
                    $('.J-register-username').text(data.account);
                    $.pa_ui.dialog.open({
                        title: '温馨提示',
                        dialogClass: 'dialog_default',
                        minimize: false,
                        maximize: false,
                        element: 'registerHasAccount',
                        width: 700,
                        height: 350
                    });
                }
            }
        });
    },

    // 发送短信动态密码
    sendValidCode: function() {
        var self = this;
        var elem = phoneLogin.elem;
        var validator = elem.input_phone.validator('check');
            // 校验通过 且 手机号改变
            if (validator) {

                // 手机号变更重发验证码。
                if (elem.input_phone.val() != phoneLogin.tempPhoneNum) {

                    // 手机号有改变
                    phoneLogin.tempPhoneNum = elem.input_phone.val();
                    phoneLogin.sendAuthCode();
                    
                } else if (elem.input_phone.val() == phoneLogin.tempPhoneNum && elem.wrap_authCode.css("display") === 'none' ) {

                    // 手机号没改变 且 不显示图形验证码的情况
                    phoneLogin.sendAuthCode();

                } else {

                    // 手机号没改变 且 显示图形验证码的情况
                    phoneLogin.sendCode();

                }
            }
    },

    // 判断是否显示图形验证码
    sendAuthCode: function() {
        var self = this;
        var elem = phoneLogin.elem;

        // 验证码AJAX
        phoneLogin.ajaxAuthCode('otp',function(data) {

            // 记录图形验证码ID
            phoneLogin.authCodeId = data.id;

            // 显示图形验证码
            if (data.type == '0') {
                elem.wrap_authCode.show();
                elem.img_authCode.attr('src', data.img);
                elem.input_authCode.val('');
            }
            phoneLogin.sendCode();
        });
    },

    // 获取短信动态密码
    sendCode: function() {
        var elem = phoneLogin.elem;
        // 前端校验
        if (elem.input_phone.val() == '') {
            showErrorInfo('手机不能为空', "J-phoneLogin-prompt");
        } else if (elem.wrap_authCode.css("display") !== 'none' && elem.input_authCode.val() == '') {
            showErrorInfo('请先输入图形验证码后，再点击发送短信动态密码。', "J-phoneLogin-prompt");
        } else {

            // 短信动态密码AJAX
            phoneLogin.ajaxSmsCode(function(data) {
                if (data.status == 'success') {

                    // 短信发送成功的回调
                    showCorrectInfo('短信发送成功', "J-phoneLogin-prompt");
                    phoneLogin.smsCodeId = data.data.activeId;

                    // 倒计时
                    var options = {
                        btn: elem.btn_sms,
                        count: 60,
                        fresh_text: '发送短信动态密码',
                        ext_text: '秒后可重新发送',
                        ext_class: 'telsend-disabled',
                        callback: function(){
                            elem.btn_sms.bind('click', phoneLogin.loginOrRegister);
                        }
                    };
                    elem.btn_sms.unbind('click');
                    phoneLogin.doTimeoutCount(options);
                } else if (data.status == 'fail') {
                    $('#J-phoneLogin-authCode-change').trigger('click');
                    // 短信发送失败
                    showErrorInfo(data.data.errorMessage || '短信发送失败', "J-phoneLogin-prompt");
                }
            });
        }
    },

    // 初始化
    init: function() {
        var self = this;
        if (!self.isInit) {
            self.isInit = true;
            self.bind();
        }
    }
};

// 登录跳转
function memberSSO() {

		window.location.href = phoneLogin.targetUrl;

}
// 嘉年华进来的，显示文案
(function() {
    if (InterfaceLoginObj.actionSource == 'carnival') {
        $('#J-carnivalShow').show();
        $('#J-thirdPartyLogin').hide();
        $('#J-noThirdPartyLoginShow').show();
    }else if(InterfaceLoginObj.actionSource == 'pagame'){
		$('#J-qqLogin').hide();
		$('#J-sinaLogin').hide();
		$('#J-wltLogin').css('marginLeft','-16px');
	}
})()