<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="conclusion.aspx.cs" Inherits="WebApplication2.psytest.conclusion" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<title>气质测试结果</title>
<style type="text/css">
<!--
#Layer1 {
	position:absolute;
	width:280px;
	height:147px;
	z-index:1;
	left: 573px;
	top: 673px;
}
#Layer2 {
	position:absolute;
	width:309px;
	height:135px;
	z-index:2;
	left: 416px;
	top: 347px;
}
-->
</style>
</head>

<body>
    <form id="form1" runat="server">
         
  <table width="1034" height="1021" border="0">
    <tr>
      <td height="150" colspan="5" background="./Images/提交结果_01.png">&nbsp;</td>
    </tr>
    <tr>
      <td width="80" height="468" background="./Images/提交结果_02.png">&nbsp;</td>
      <td width="154" bgcolor="#99FFCC">&nbsp;</td>
      <td colspan="2" bordercolor="#99FFCC" background="./Images/tmj.png" bgcolor="#99FFCC"><div id="Layer2">
         <asp:Label ID="TypeLabel" runat="server"></asp:Label>
          </div></td>
      <td width="207" bgcolor="#99FFCC">&nbsp;</td>
    </tr>
    <tr>
      <td height="198" colspan="2" background="./Images/water123.gif"><table width="200" border="1">
        <tr>
          <td><img src="./Images/右侧查询_01.gif" width="200" height="26"></td>
        </tr>
        <tr>
          <td><img src="./Images/右侧查询_02.gif" width="200" height="22"></td>
        </tr>
        <tr>
          <td><img src="./Images/右侧查询_03.gif" width="200" height="23"></td>
        </tr>
        <tr>
          <td><img src="./Images/右侧查询_04.gif" width="200" height="22"></td>
        </tr>
        <tr>
          <td height="31"><img src="./Images/右侧查询_05.gif" width="200" height="32"></td>
        </tr>
      </table></td>
      <td width="533" height="198" background="./Images/water123.gif"><a href="/soulcastlefrontpage.html"><img src="./Images/返回首页.png" width="149" height="150" border="0"></a>
      <div id="Layer1"><img src="./Images/seashell.png" width="280" height="144"></div></td>
      <td height="198" colspan="2" background="./Images/water123.gif">&nbsp;</td>
    </tr>
    <tr>
      <td height="164" colspan="5" background="./Images/FISH.gif">&nbsp;</td>
    </tr>
    <tr>
      <td height="29" colspan="5"><div align="center">&copy;<strong>2014 心灵之家科技有限公司soulcastle 版权所有</strong> </div></td>   </tr>
  </table>
  <p>&nbsp;</p>
    </form>
</body>
</html>
