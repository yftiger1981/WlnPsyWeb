<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consulterModify.aspx.cs" Inherits="WebApplication2.consulters.consulterModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>咨询师个人信息修改页面</title>
    <link href="../style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="head">
         咨询师信息修改页面
        </div>
          <table>
          <tr> <td>您好，<asp:Label ID="nameLabel" runat="server"></asp:Label></td> 
           <td>您的个人信息如下：</td> </tr>
            <tr><td>姓名:</td><td id="name">
                <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td>密码:</td><td id="password">
                <asp:TextBox ID="passwordTextBox" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td>邮箱:</td><td id="sex">
                <asp:TextBox ID="mailTextBox" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td>性别:</td><td id="mailbox">
                <asp:TextBox ID="sexTextBox" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td>身份证号:</td><td id="IDCard">
                <asp:TextBox ID="IdTextBox" runat="server"></asp:TextBox>
                </td></tr>
            <tr><td>个人头像:</td><td id="photo">
                <div>
                <asp:Image ID="Image1" runat="server" CssClass="image" />
                </div>
               </td>
                <td style="vertical-align:bottom"> 
                    修改个人头像（jpg,png格式，大小不超过200K）：
                    <br/>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <asp:Button ID="Button3" runat="server" Text="上传" OnClick="Button3_Click" />
                    <br/>
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr><td>证件照:</td><td id="photo2">
                <div>
                <asp:Image ID="Image2" runat="server" CssClass="image" />
                </div>
               </td>
                <td style="vertical-align:bottom"> 
                    修改证件照：（jpg,png格式，大小不超过200K）：
                    <br/>
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                    <asp:Button ID="subButton" runat="server" Text="上传" OnClick="subButton_Click"/>
                    <br/>
                    <asp:Literal ID="errLiteral2" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr><td>偏好:</td><td id="prefer">
                <asp:CheckBox ID="qgzaCheckBox" runat="server" Text="情感障碍" />
            &nbsp;
                <asp:CheckBox ID="gzxxCheckBox" runat="server" Text="工作学习" />
            &nbsp;
                <asp:CheckBox ID="hyjtCheckBox" runat="server" Text="婚姻家庭" />
            </td><td>
            &nbsp;&nbsp;
                </td></tr>
            <tr><td>擅长类型:</td><td id="skill">
                <asp:CheckBox ID="yyzCheckBox" runat="server" Text="抑郁质" />
                &nbsp;&nbsp;
                <asp:CheckBox ID="dzzCheckBox" runat="server" Text="胆汁质" />
            &nbsp;&nbsp;
                <asp:CheckBox ID="dxzCheckBox" runat="server" Text="多血质" />
            &nbsp;
                <asp:CheckBox ID="lyzCheckBox" runat="server" Text="黏液质" />
                </td><td>
            &nbsp;
                &nbsp;
                </td></tr>
            <tr><td>等级:</td><td id="level">
                <asp:RadioButtonList ID="LevelRadioButtonList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem>一级</asp:ListItem>
                    <asp:ListItem>二级</asp:ListItem>
                    <asp:ListItem>三级</asp:ListItem>
                </asp:RadioButtonList>
                </td></tr>
            <tr><td>自我介绍:</td><td id="intro">
                <asp:TextBox ID="introTextBox" runat="server" Columns="10" Rows="10" TextMode="MultiLine" CssClass="ActiveTextBox"></asp:TextBox>
                </td></tr>
            <tr><td>
                <asp:Button ID="submitButton" runat="server" Text="提交" Width="57px" OnClick="Button2_Click" />
                </td><td>&nbsp;</td></tr>
        </table>
            <asp:Literal ID="errLiteral" runat="server"></asp:Literal>
             <br />
            <a href="consulter.aspx">上一页</a>

    </form>
     <div class="foot">
         心灵之家soulcastle 科技有限公司版权所有 
     </div>    
</body>
</html>
