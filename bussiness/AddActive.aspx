<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddActive.aspx.cs" Inherits="WebApplication2.bussiness.AddActive" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .ActiveTextBox {}
    </style>
    <link href="../style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="head">
     心灵之家SOULCASTLE商家活动添加页面
    </div>
    <form id="form1" runat="server">
        <div>
    <table style="width:100%; height: 100%">
                <tr>
                    <td colspan="3"><p>亲爱的商家朋友，您好！当你来到此页面，你将在此完成活动的发布工作，目前支持一个商家最多发布三个活动。心灵之家网站感谢你的使用,谢谢！<p>
                </td>
                 </tr>
        <tr>
        <td> 提交商业活动相关图片：</td><td><asp:FileUpload ID="FileUpload1" runat="server" Height="29px" Width="237px" OnLoad="FileUpload1_Load" />
       <asp:CustomValidator ID="ImgCustomValidator" runat="server" ErrorMessage="请插入有效的.jpg图片" ControlToValidate="FileUpload1"></asp:CustomValidator>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </td>
       </tr>
         <tr><td>活动简介：</td><td><asp:TextBox ID="ActivateIntro" runat="server"  TextMode="MultiLine" CssClass="ActiveTextBox"></asp:TextBox></td></tr>
             <tr><td>
          <asp:Button ID="subButton" runat="server" Text="提交" OnClick="Button1_Click" CssClass="button" /> </td><td>
                     <asp:Button ID="Button1" runat="server" Text="返回上页" CssClass="button"  OnClick="Button1_Click1"/>
                 </td>
              </tr>
          </table>
        </div>
               <asp:Literal ID="errLiteral1" runat="server" ></asp:Literal>
    </form>

          <div class="foot">
           心灵之家soulcastle 科技有限公司版权所有 
       </div>

</body>
</html>
