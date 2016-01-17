<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication2.login" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录</title>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>   
    </div>
  <img src="\Imagescom\prom.png" width="534" height="324" />
  <div id="Layer1" style="position:absolute; width:258px; height:166px; z-index:1; left: 550px; top: 36px;">
        <asp:Login ID="Login1" runat="server" CreateUserText="注册" CreateUserUrl="~/regist.aspx" OnAuthenticate="Login1_Authenticate" style="margin-top: 0px">
            <LayoutTemplate>
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0">
                                <tr>
                                    <td align="center" colspan="2">登录</td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">用户名:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密码:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="下次记住我。" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color:Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="登录" ValidationGroup="Login1" CssClass="button"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:HyperLink ID="CreateUserLink" runat="server" NavigateUrl="~/regist.aspx">注册</asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
        </asp:Login>   
  </div>
  <img src="\Imagescom\tj.png" width="240" height="147"/>
  <table width="832" height="130" border="1">
    <tr>
      <td colspan="2"><img src=".\Imagescom\TL.png" width="830" height="18" /></td>
    </tr>
    <tr>
      <td width="72" bgcolor="#DCEFAE"><span class="style14"> 注册说明</span></td>
      <td width="744" bgcolor="#EDF4E4"><p class="style12">该页面为一般用户及VIP用户登录页面.若尚未注册,请注册为该网会员,你将获得更多的优质服务.所有注册为免费注册,一般客户及游客也能享有我们提供的信息服务,VIP客户将享有服务的优先权.</p>
      <p class="style12">SOULCASTLE心灵之家欢迎你的光临!</p></td>
    </tr>
    <tr bgcolor="#CCCCCC">
      <td colspan="2"><table id="webFooterTable" class="webFooterTable" cellpadding="0" cellspacing="0">
          <tbody>
            <tr>
              <td align="center" valign="top">
                <div id="webFooter" class="webFooter">
                  <div id="footer" class="footer">
                    <table class="footerTop" cellpadding="0" cellspacing="0">
                      <tbody>
                        <tr valign="top">
                          <td class="topLeft"></td>
                          <td class="topCenter"></td>
                          <td class="topRight"></td>
                        </tr>
                      </tbody>
                    </table>
                    <table width="818" height="95" cellpadding="0" cellspacing="0" class="footerMiddle">
                      <tbody>
                        <tr valign="top">
                          <td class="middleLeft"></td>
                          <td align="center" bgcolor="#CADCAE" class="middleCenter">
                            <div class="footerContent">
                              <div id="footerNav" class="footerNav"> <span class="footerNavItem" id="footer2"><a hidefocus="true" href="soulcastlefrontpage.html">首页</a></span> <span class="footerSep">|</span> <span class="footerNavItem" id="footer5"><a hidefocus="true" href="/introduction.htm">心灵之家概况</a></span> <span class="footerSep">|</span> <span class="footerNavItem" id="footer6"><a hidefocus="true" href="/soulcastelmap.htm">联系我们</a></span> <span class="footerSep">|</span> <span class="footerNavItem" id="footer9"><a  href="./lyb/Addmsg.aspx">留言板</a></span> <span class="footerSep">|</span> <span class="footerNavItem" id="footer13"><a hidefocus="true" href="rememberregister.htm">会员注册</a></span></span> <span class="footerSep">|</span>  <span class="footerNavItem" id="footer13"><a hidefocus="true" href="http://www.soulcastle.net/mcart.jsp">顾客服务查询</a></span></span></div>
                              <div class="footerInfo">
                                <p><strong><font face="Arial"><img src="\imagescom\logo.png" width="41" height="42"></strong>&copy;<strong>2014 心灵之家科技有限公司soulcastle 版权所有</strong></p>
                              </div>
                              <div class="footerSupport"> <span class="footerFaisco">其他登陆：</span> <span class="footerSep">|</span> <span class="footerMobile"><a hidefocus="true" href="http://m.soulcastle.net/" target="_blank">手机版</a></span> <span class="footerSep">|</span> <span id="footerLogin" class="footerLogin"><a name="popupLogin" hidefocus="true" href="javascript:;" onClick="Site.popupLogin(&quot;http://www.faisco.cn&quot;,3751490);Fai.closeTip(&quot;#footerLogin&quot;);return false;">管理登录</a></span> <span class="bgplayerButton" id="bgplayerButton" style="display:none;"></span> </div>
                          </div></td>
                          <td class="middleRight"></td>
                        </tr>
                      </tbody>
                    </table>
                    <table class="footerBottom" cellpadding="0" cellspacing="0">
                      <tbody>
                        <tr valign="top">
                          <td class="bottomLeft"></td>
                          <td class="bottomCenter"></td>
                          <td class="bottomRight"></td>
                        </tr>
                      </tbody>
                    </table>
                  </div>
              </div></td>
            </tr>
          </tbody>
        </table>      </td>
    </tr>
  </table>
  <table width="818" border="1" cellspacing="0" cellpadding="0">
  <tr>
    <th width="818" bgcolor="#FFFFFF" scope="row"><img src="\imagescom\TL.png" width="832" height="20"/></th>
  </tr>
</table>
</form>
</body>
</html>
