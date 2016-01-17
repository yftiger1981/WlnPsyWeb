<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consulterRegister.aspx.cs" Inherits="WebApplication2.consulter"  EnableViewStateMac="false"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="SHORTCUT ICON" href="Imagescom/scico.gif" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>咨询师注册页面</title>
    <link href="../style.css" rel="stylesheet" type="text/css" />
</head>
<body>
<div class="head">
<h2  style='background:url("Imagescom/zhixunshizhuce.jpg") no-repeat #cccccc;text-align:center'>心灵之家SOULCASTLE咨询师注册页面</h2>
</div>
    <form id="form1" runat="server">
        <table>
       <tr><td colspan="2"> 您好：<asp:Label ID="nameLabel" runat="server"></asp:Label></td></tr>
      <tr> <td> 您的的性别：</td><td><asp:RadioButtonList ID="sexRadioButtonList" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True">男</asp:ListItem>
            <asp:ListItem>女</asp:ListItem>
        </asp:RadioButtonList></td>
          </tr>
       <tr><td> 请填写身份证号：</td>
       <td><asp:TextBox ID="IDTextBox" runat="server" style="margin-top: 0px" Width="170px" Height="20px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IDTextBox" ErrorMessage="必须填写身份证号">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="IDTextBox" ErrorMessage="身份证号不对" ValidationExpression="\d{17}[\d|X]|\d{15}" ForeColor="#CC3300"></asp:RegularExpressionValidator>
           </td>
           </tr>
        <tr style="height:20px"></tr>
        <tr style="border:thick;border-color:azure"><td>请上传证件照：</td>
       <td> <asp:FileUpload ID="FileUpload1" runat="server" Height="36px" Width="245px" />（请上传.jpg类型的图片，大小不得超过200K）<asp:CustomValidator ID="ImgCustomValidator" runat="server" ErrorMessage="请上传有效的.jpg图片" ControlToValidate="FileUpload1"></asp:CustomValidator></td>
       </tr>
      <tr>
       <td> 偏好咨询类型(可多选)：</td>
       <td> <asp:CheckBoxList ID="PreferenceCheckBoxList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem>情感障碍咨询</asp:ListItem>
            <asp:ListItem>工作学习咨询</asp:ListItem>
            <asp:ListItem>婚姻家庭生活</asp:ListItem>
        </asp:CheckBoxList>
           </td>
       </tr>
      <tr>
        <td>咨询师擅长类型（可多选）：</td>
        <td><asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="33px" RepeatDirection="Horizontal" Width="434px" RepeatLayout="Flow">
            <asp:ListItem Value="抑郁质">抑郁质</asp:ListItem>
            <asp:ListItem Value="胆汁质">胆汁质</asp:ListItem>
            <asp:ListItem Value="多血质">多血质</asp:ListItem>
            <asp:ListItem Value="粘液质">粘液质</asp:ListItem>
        </asp:CheckBoxList>
            </td>
        </tr>
<tr><td>咨询师级别：</td>

       <td> <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="256px" Height="29px" RepeatLayout="Flow">
            <asp:ListItem>一级</asp:ListItem>
            <asp:ListItem>二级</asp:ListItem>
            <asp:ListItem selected="true">三级</asp:ListItem>
        </asp:RadioButtonList>
       </td>
        </tr>
          <tr> <td>自我介绍:</td> </tr>
          <tr><td colspan="2">
            <asp:TextBox ID="ActivityTextBox" runat="server" Columns="10" Rows="10" TextMode="MultiLine" CssClass="IntroTextBox"></asp:TextBox>
          </td>
          </tr>
       <tr><td><asp:Button ID="SubmitButton" runat="server" OnClick="Button1_Click" Text="提交"  cssclass="button"/> </td>     
       <td><asp:Button ID="NextButton" runat="server" Enabled="False" OnClick="NextButton_Click" Text="下一步" CssClass="button"/>
       </td></tr> 
       </table>
        <asp:Label ID="ErrLabel" runat="server"></asp:Label>
    </form>
    <a href="../soulcastlefrontpage.html">回首页</a>
  <div class="foot">
      心灵之家soulcastle 科技有限公司版权所有
  </div>

</body>
</html>

