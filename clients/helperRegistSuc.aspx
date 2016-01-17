<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="helperRegistSuc.aspx.cs" Inherits="WebApplication2.clients.consulterSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="SHORTCUT ICON" href="Imagescom/scico.gif" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script src="../scripts/jquery-2.1.3.js"></script>
<script type="text/javascript">
    var username=<%=Request.Params["username"]%>
</script>    
 <title></title>
    <link href="../style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="head">
            求助者问题发布页面
        </div>
    <div>
    
       <table>
           <tr>
               <td>
        您好：<asp:Label ID="userLabel" runat="server"></asp:Label>
               </td>
    
       <td> <asp:Image ID="selImage" runat="server"  CssClass="image" /></td>
               </tr>
       <tr>
           <td colspan="2">
        您目前提交的气质类型为：<asp:Label ID="qizhiLabel" runat="server"></asp:Label>
               <br />
               <br />
           </td>
           </tr>
        </table>
        请向咨询师提供您的问题描述：<br />
        <br />
        标题：<br />
        <asp:TextBox ID="titleTextBox" runat="server" cssclass="textbox"></asp:TextBox>
        <br />
        内容：<br />
        <asp:TextBox ID="contentTextBox" runat="server" CssClass="ActiveTextBox" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="提交" Width="84px" Height="23px" OnClick="Button1_Click" />
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
       <a href="../department/consulterBussinessInfo.html"> 查看咨询师和商家发布的活动信息</a><br />
        <br />
        <a href="./helperSelection.aspx">选择咨询师</a><br />
        <br />
        <a href="HelperModify.aspx">修改个人信息</a><br />
        <br />
        <a href="../login.aspx">回首页</a><br />
&nbsp;</div>
        <div class="foot">
            心灵之家soulcastle 科技有限公司版权所有 
        </div>
    </form>
</body>
</html>
