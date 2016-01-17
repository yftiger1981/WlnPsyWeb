<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="regist.aspx.cs" Inherits="WebApplication2.regedit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>注册页面</title>
    <style type="text/css">
        .auto-style1 {
            height: 39px;
        }
        #Button1 {
            height: 29px;
            width: 85px;
        }
        .auto-style2 {
            width: 17%;
        }
        .auto-style3 {
            height: 39px;
            width: 1%;
        }
        .auto-style4 {
            width: 1%;
        }
        .auto-style5 {
            text-align: right;
        }
    </style>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
   <form id="form1" runat="server">
    <div> 
        <table width="90%" border="0" cellpadding="8" style="margin-top: 101px">
      &nbsp;<tr bgcolor="#FF6600"> 
        <td colspan="2" class="HeaderColor"> <h4 align="center" class="style1">心灵之家soulcastle会员注册页面</h4></td>
      </tr>
      <tr bgcolor="#99FF66">
        <td colspan="2" class="HeaderColor style2">（注：你可以是商家会员，咨询师会员，以及求助者会员，但都请以真实身份登录。咨询师会员必须填写姓名！）</td>
      </tr>
      <tr style="vertical-align: top"> 
        <td nowrap class="auto-style4" style="text-align: right">用户名*</td>
        <td class="TitleColor"><asp:TextBox ID="IdTextBox" runat="server" CssClass="textbox"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IdTextBox" ErrorMessage="请填写用户名"></asp:RequiredFieldValidator>
            <br>        
            <span class="small style4">*你的唯一ID号，请记住它，不能有重复。<asp:Label ID="IdErrorLabel" runat="server"></asp:Label>
            </span></td>
      </tr>
      <tr style="vertical-align: top"> 
        <td nowrap class="auto-style4" style="text-align: right">是否同意网站声明</td>
        <td class="TitleColor">                    
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="true" Height="24px" Width="109px">
                <asp:ListItem>是</asp:ListItem>
                <asp:ListItem>否</asp:ListItem>
            </asp:RadioButtonList>
            （<a href="Policy.html">网站声明</a>查看）</td>
      </tr>
      <tr style="vertical-align: top"> 
        <td class="auto-style3" style="text-align: right">密码*</td>
        <td class="auto-style1"> <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
          <span class="style4">请你输入一个6位以上的密码  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordTextBox" ErrorMessage="请填写密码"></asp:RequiredFieldValidator>
            </span> </td>
      </tr>
      <tr style="vertical-align: top"> 
        <td class="auto-style4" style="text-align: right">密码确认*</td>
        <td class="TitleColor"><asp:TextBox ID="ConfirmPasswordTextBox" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ConfirmPasswordTextBox" ErrorMessage="请填写确认密码"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="PasswordTextBox" ControlToValidate="ConfirmPasswordTextBox" ErrorMessage="两次输入密码不匹配"></asp:CompareValidator>
            <br>          
          </td>
      </tr>
      <tr style="vertical-align: top"> 
        <td class="auto-style4" style="text-align: right">
          你的姓名</td>
        <td class="auto-style2"> <asp:TextBox ID="NameTextBox4" runat="server" CssClass="textbox"></asp:TextBox>
          </td>
      </tr>
      <tr style="vertical-align: top"> 
        <td class="auto-style3" style="text-align: right">Email</td>
        <td class="auto-style1"><asp:TextBox ID="EmailTextBox" runat="server" CssClass="textbox"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="电子邮件不正确" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
          </td>
      </tr>
      <tr style="vertical-align: top"> 
        <td class="auto-style5" >电话</td>
        <td >                   
            <asp:TextBox ID="phoneTextBox" runat="server" cssclass="textbox"></asp:TextBox>
          </td>
      </tr>
      <tr style="vertical-align: top"> 
        <td class="auto-style5"> QQ</td>
        <td class="auto-style1">                  
            <asp:TextBox ID="qqTextBox" runat="server" cssclass="textbox"></asp:TextBox>
          </td>
      </tr>
      <tr style="vertical-align: top"> 
        <td class="auto-style3" style="text-align: right">
            你用哪种角色注册</td>
        <td class="auto-style1">          
            <asp:RadioButton ID="MerdizeRadioButton" runat="server" GroupName="role" text="商家" />          
            <asp:RadioButton ID="ConsultRadioButton" runat="server" GroupName="role" Text="咨询师" />
            <asp:RadioButton ID="HelperRadioButton" runat="server" Checked="True" GroupName="role" Text="求助者" />
        </td>
      </tr>  
      <tr style="vertical-align: top"> 
        <td class="auto-style3" style="text-align: right">
            <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" Text="提交" Enabled="False" CssClass="button" />
          </td>
        <td class="auto-style1">          
            <a href="soulcastlefrontpage.html"><input id="Button1" type="button" value="回主页" class="button" /></a></td>
      </tr> 
      </table>       
    </div>
       <p>
            &nbsp;</p>
 
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
