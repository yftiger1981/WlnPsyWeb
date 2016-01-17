<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebForm.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link  rel="SHORTCUT ICON" href="..\Imagescom\scico.gif" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>soulcastle心灵之家咨询平台</title>
    <link href="Css/Login/Style/Login.css" rel="stylesheet" />
    <script src="Scripts/jquery-2.1.3.js"></script>
    <script src="Scripts/Jquery/jquery.winResize.js"></script>
    <script src="Scripts/Jquery/jquery.cxslide.min.js"></script>
    <script src="Scripts/Login/Login.js"></script>
    <script>
        $(Document).ready(function ()
        {
            $('#Account').text();
            $('#Password').text();
        }
        )
    </script>
</head>
<body>
    <!--顶部兰-->
    <div id="sytopBar">
        <table style="width:500px;height:100%" border="0" class="toplogoimg">
            <tr>
                <td style="vertical-align:bottom">
                    <img src="Css/Login/Images/logo.png" /></td>
            </tr>
        </table>
    </div>

    <div id="sywrap">
        <div id="element_id" class="cxslide">
            <div class="box">
                <ul class="list">
                    <li>
                        <img src="Css/Login/Images/bg1.jpg" style="width:100%;height:100%"/></li>
                    <li>
                        <img src="Css/Login/Images/bg2.jpg" style="width:100%;height:100%"/></li>
                    <li>
                        <img src="Css/Login/Images/bg3.jpg" style="width:100%;height:100%"/></li>
                </ul>
            </div>
        </div>

        <div class="loginbox">
            <form id="form1" runat="server">
               <%-- <input type="hidden" id="Force" name="Force" value="0" />--%>
                <div class="subMenu"><ul><li>用户登录</li></ul></div>
                <%--<div style="position: absolute; z-index: 99999; top: 15px; font-size: 14px; color: #808080; left: 330px; cursor: pointer;">退出</div>--%>
                <div class="subBoth"></div>
                <table style="width:100%" border="0" class="login-main">
                    <tr>
                        <td colspan="3">
                            <p class="uname">
                                <input type="text" id="Account" name="Account" value="" class="login-input" placeholder="输入用户名" />
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <p class="pwd">
                                <input type="password" id="Password" name="Password" class="login-input" placeholder="输入登陆密码" />
                            </p>
                        </td>
                    </tr>
                    <tr id="novcode" style="display: none;">
                        <td colspan="3">
                            <table width="100%" border="0">
                                <tr>
                                    <td width="33%">
                                        <p class="code VCode">
                                            <input type="text" id="VCode" name="VCode" class="login-input VCode-input" value="" maxlength="4" placeholder="输入验证码" style="width: 59%" />
                                        </p>
                                    </td>
                                    <td>
                                        <img alt="" src="VCode.ashx?<%=DateTime.Now.Ticks %>" onclick="cngimg();" style="height: 38px;" id="VcodeImg" /></td>
                                </tr>
                            </table>

                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <input type="submit" value="&nbsp;&nbsp;登&nbsp;&nbsp;录&nbsp;&nbsp;" id="loginbtn" name="loginbtn" onclick="return checkForm();" class="loginbtn" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width:100px"><a href="changepassword/changePassword.aspx">修改密码</a> </td>
                        <td style="width:100px"><a href="changepassword/Passwordrecovery.aspx">忘记密码</a></td>
                        <td style="width:100px"><a href="soulcastlefrontpage.html">回主页</a></td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <!--任务栏-->
    <div id="systateBar">
        <div class="footer">
            <p>建议使用Chrome、FireFox及IE9以上浏览器（最佳显示分辨率：1280 X 768 以上）</p>
        </div>
    </div>
</body>
</html>

<script type="text/javascript">
    $(window).load(function () {
        myLogin.layout.syinit();
    });
    $(window).resize(function () {
        myLogin.layout.syinit();
    });

    var isVcode = '1' == '<%=Session[BPM.Utility.Keys.SessionKeys.IsValidateCode.ToString()]%>';
    var isSessionLost = "1" == '<%=Request.QueryString["session"]%>';
    $(window).load(function () {
        if (isVcode) {
            if (!isSessionLost) {
                $(window).resize();
            }
            $("#novcode").show();
        }
       <%=Script%>
    });
    function checkForm() {
        var form1 = document.forms[0];
        if ($.trim(form1.Account.value).length == 0) {
            alert("帐号不能为空!");
            form1.Account.focus();
            return false;
        }
        if ($.trim(form1.Password.value).length == 0) {
            alert("密码不能为空!");
            form1.Password.focus();
            return false;
        }
        if (isVcode && form1.VCode && $.trim(form1.VCode.value).length == 0) {
            alert("验证码不能为空!");
            form1.VCode.focus();
            return false;
        }
        return true;
    }
    function cngimg() {
        $('#VcodeImg').attr('src', 'VCode.ashx?' + new Date().toString());
    }

   <%-- var rootdir = '<%=SitePath%>';--%>

</script>
