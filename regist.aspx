<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="regist.aspx.cs" Inherits="WebApplication2.regedit" enableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="SHORTCUT ICON" href="Imagescom/scico.gif" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>注册页面</title>
    <style type="text/css">
        .auto-style1 {
            height: 39px;
        }
        .auto-style5 {
            text-align: right;
            width: 9%;
        }
        .auto-style8 {
            height: 24px;
        }
        .auto-style9 {
            width: 31%;
        }
        .auto-style10 {
            height: 39px;
            width: 31%;
        }
        .auto-style11 {
            width: 9%;
        }
        .auto-style12 {
            height: 39px;
            width: 9%;
        }
        .auto-style13 {
            width: 9%;
            height: 75px;
        }
        .auto-style14 {
            width: 31%;
            height: 75px;
        }
    </style>
    <link href="style.css" rel="stylesheet" type="text/css" />
</head>
<body>
   <form id="form1" runat="server">
    <div> 
        <table style="width:100%">
         <tr style="background-color:blue;height:100px"> 
        <td colspan="2" class="HeaderColor" style="text-align:center"> <h1>心灵之家soulcastle会员注册页面</h1></td>
      </tr>
      <tr style="text-align:center;background-color:#99FF66">
        <td colspan="2" class="HeaderColor style2"><h5 style="color:red">（注：你可以是商家会员，咨询师会员，以及求助者会员，但都请以真实身份登录。咨询师会员必须填写姓名！）</h5></td>
      </tr>
      <tr style="vertical-align: top"> 
        <td nowrap class="auto-style13" style="text-align: right">用户名*</td>
        <td class="auto-style14"><asp:TextBox ID="IdTextBox" runat="server" CssClass="textbox"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="IdTextBox" ErrorMessage="请填写用户名"></asp:RequiredFieldValidator>
            <br>        
            <span class="small style4">*您的唯一登录号，请牢记。<br />
            <asp:Label ID="IdErrorLabel" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
            </span></td>
      </tr>
      <tr style="vertical-align: top"> 
        <td class="auto-style11" style="text-align: right">您是否同意网站声明*</td>
        <td class="auto-style9">                    
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="true" Height="24px" Width="109px">
                <asp:ListItem>是</asp:ListItem>
                <asp:ListItem>否</asp:ListItem>
            </asp:RadioButtonList>
            （<a href="Policy.html">网站声明</a>查看）</td>
      </tr>
              <tr style="vertical-align: top"> 
        <td class="auto-style11" style="text-align: right" rowspan="2">
            你用哪种角色注册*
        </td>
        </tr>
         <tr>
                <td class="auto-style9">  
                    <table style="width:102%;">
                        <tr>
                            <td>          
            <asp:RadioButton ID="MerdizeRadioButton" runat="server" GroupName="role" text="商家" AutoPostBack="false" />          
                            </td>
                            <td>          
            <asp:RadioButton ID="ConsultRadioButton" runat="server" GroupName="role" Text="咨询师" AutoPostBack="false" />
                            </td>
                            <td class="auto-style8">
            <asp:RadioButton ID="HelperRadioButton" runat="server"  GroupName="role" Text="求助者"  AutoPostBack="false" Checked="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Image ID="MerImage" runat="server" hight="50px" Width="50px" ImageUrl="~/Images/bussiness.png" Visible="true"/>
                            </td>
                            <td>
                                <asp:Image ID="ConsultImage" runat="server" Height="50px" Width="50px" ImageUrl="~/Images/consulter.png" Visible="true" />
                            </td>
                            <td>
                                <asp:Image ID="HelperImage" runat="server" Height="50px" Width="50px" ImageUrl="~/Images/helper-man.png" Visible="true" />
                            </td>
                        </tr>
                    </table>                 
                </td>
            </tr>
      <tr style="vertical-align: top"> 
        <td class="auto-style12" style="text-align: right">密码*</td>
        <td class="auto-style10"> <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
          <span class="style4">&nbsp;  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PasswordTextBox" ErrorMessage="请填写密码"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="PasswordTextBox" ErrorMessage="密码强度不够，请输入一个六位以上以字母数字相结合的密码" Font-Bold="True" ForeColor="Red" ValidationExpression="^[0-9a-zA-Z]{6,15}$"></asp:RegularExpressionValidator>
            </span> </td>
      </tr>
      <tr style="vertical-align: top"> 
        <td class="auto-style11" style="text-align: right">密码确认*</td>
        <td class="auto-style9"><asp:TextBox ID="ConfirmPasswordTextBox" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ConfirmPasswordTextBox" ErrorMessage="请填写确认密码"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="PasswordTextBox" ControlToValidate="ConfirmPasswordTextBox" ErrorMessage="两次输入密码不匹配"></asp:CompareValidator>         
          </td>
      </tr>
      <tr style="vertical-align: top"> 
        <td class="auto-style11" style="text-align: right">
          你的姓名</td>
        <td class="auto-style9"> <asp:TextBox ID="NameTextBox4" runat="server" CssClass="textbox"></asp:TextBox>
          </td>
      </tr>
      <tr style="vertical-align: top"> 
        <td class="auto-style12" style="text-align: right;vertical-align:bottom">Email*</td>
        <td class="auto-style10" style="text-align:left;vertical-align:bottom"><asp:TextBox ID="EmailTextBox" runat="server" CssClass="textbox"></asp:TextBox>
            （请正确填写邮件地址，它将是您找回密码的凭证）<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="EmailTextBox" ErrorMessage="电子邮件不正确" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
      </tr>
      <tr style="vertical-align: top"> 
        <td class="auto-style5" >电话</td>
        <td class="auto-style9" >                   
            <asp:TextBox ID="phoneTextBox" runat="server" cssclass="textbox"></asp:TextBox>
          </td>
      </tr>
      <tr style="vertical-align: top"> 
        <td class="auto-style5"> QQ</td>
        <td class="auto-style10">                  
            <asp:TextBox ID="qqTextBox" runat="server" cssclass="textbox"></asp:TextBox>
          </td>
      </tr>
    
      <tr style="vertical-align: top"> 
         <td class="auto-style12" style="text-align: right">
            <asp:Button ID="SaveButton" runat="server" OnClick="SaveButton_Click" Text="提交" Enabled="False" CssClass="button" />
          </td>
        <td class="auto-style1">          
            <a href="soulcastlefrontpage.html"><input id="ComeHomeButton" type="button" value="回主页" class="button" /></a></td>
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
