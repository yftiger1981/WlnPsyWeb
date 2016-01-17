<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consulterRegister.aspx.cs" Inherits="WebApplication2.consulter" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>咨询师注册页面</title>
    <link href="../webcss.css" rel="stylesheet" type="text/css" />
    <link href="../style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <table class="auto-style1">
                <tr>
                    <td class="auto-style3" colspan="3"  style='background:url("Imagescom/zhixunshizhuce.jpg") no-repeat #cccccc;'><span class="auto-style19">心灵之家SOULCASTLE</span>&nbsp;&nbsp;&nbsp;&nbsp; 咨询师注册页面</td>
                </tr>
      </table>
    <form id="form1" runat="server">
        您的的性别：<asp:CheckBoxList ID="SexCheckBoxList" runat="server" Height="27px" RepeatDirection="Horizontal" Width="122px">
            <asp:ListItem>男</asp:ListItem>
            <asp:ListItem>女</asp:ListItem>
        </asp:CheckBoxList>
        <br />
        请填写身份证号：<br />
        <br />
        <asp:TextBox ID="IDTextBox" runat="server" style="margin-top: 0px" Width="170px" Height="20px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IDTextBox" ErrorMessage="必须填写身份证号">*</asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="IDTextBox" ErrorMessage="身份证号不对" ValidationExpression="\d{17}[\d|X]|\d{15}" ForeColor="#CC3300"></asp:RegularExpressionValidator>
        <br />
        请上传证件照：<asp:CustomValidator ID="ImgCustomValidator" runat="server" ErrorMessage="请上传有效的.jpg图片"></asp:CustomValidator>
        <br />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" Height="36px" Width="245px" />
        <br />
        （请上传.jpg类型的图片，大小不得超过200K）<br />
        <br />
        偏好咨询类型(可多选)：<br />
        <asp:CheckBoxList ID="PreferenceCheckBoxList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
            <asp:ListItem>情感障碍咨询</asp:ListItem>
            <asp:ListItem>工作学习咨询</asp:ListItem>
            <asp:ListItem>婚姻家庭生活</asp:ListItem>
        </asp:CheckBoxList>
        <br />
        <br />
        咨询师擅长类型（可多选）：<br />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" Height="33px" RepeatDirection="Horizontal" Width="434px" RepeatLayout="Flow">
            <asp:ListItem Value="抑郁质">抑郁质</asp:ListItem>
            <asp:ListItem Value="胆汁质">胆汁质</asp:ListItem>
            <asp:ListItem Value="多血质">多血质</asp:ListItem>
            <asp:ListItem Value="粘液质">粘液质</asp:ListItem>
        </asp:CheckBoxList>
        <br />
咨询师级别：

        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="256px" Height="29px" RepeatLayout="Flow">
            <asp:ListItem>一级</asp:ListItem>
            <asp:ListItem>二级</asp:ListItem>
            <asp:ListItem Value="三级">三级</asp:ListItem>
        </asp:RadioButtonList>

        <br />
        <p>
            自我介绍;</p>
        <p>
            <asp:TextBox ID="ActivityTextBox" runat="server" Height="119px" Width="379px"></asp:TextBox>
        </p>
        <asp:Button ID="SubmitButton" runat="server" OnClick="Button1_Click" Text="提交" Width="77px" Height="33px" cssclass="button"/>
        <asp:Label ID="ErrLabel" runat="server"></asp:Label>
        <br />
        <br />
    </form>
    <a href="../soulcastlefrontpage.html">回首页</a>
       <table>
          <tr>
          <td class="auto-style7" colspan="3"><span class="auto-style21">心灵之家SOULCASTLE商家注册页面为</span><span class="auto-style20">2014 心灵之家科技有限公司soulcastle 版权所有</span></span></td>
          </tr>
         </table>

</body>
</html>
