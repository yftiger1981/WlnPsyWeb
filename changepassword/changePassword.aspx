<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changePassword.aspx.cs" Inherits="WebApplication2.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="SHORTCUT ICON" href="Imagescom/scico.gif" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>修改密码</title>
    <link href="../style.css" rel="stylesheet" type="text/css" />
</head>
<body>
     <form id="form1" runat="server">
                <table style="border-collapse:collapse;">
                                <tr>
                                    <td style="text-align:center" colspan="2">更改密码</td>
                                </tr>
                                <tr>
                                    <td style="text-align:left">用户名：</td>
                                    <td><asp:TextBox ID="userNameTextBox" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align:left">
                                        密码:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword" ErrorMessage="必须填写“密码”。" ToolTip="必须填写“密码”。" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:left">
                                        新密码:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword" ErrorMessage="必须填写“新密码”。" ToolTip="必须填写“新密码”。" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:left">
                                        确认新密码:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" ErrorMessage="必须填写“确认新密码”。" ToolTip="必须填写“确认新密码”。" ValidationGroup="ChangePassword1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td  colspan="2" style="text-align:left">
                                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" Display="Dynamic" ErrorMessage="“确认新密码”与“新密码”项必须匹配。" ValidationGroup="ChangePassword1"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:left" colspan="2" style="color:Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align:left">
                                        <asp:Button ID="ChangePasswordPushButton" runat="server"  OnClick="ChangePasswordPushButton_Click" Text="确定" ValidationGroup="ChangePassword1" cssClass="button"/>
                                    </td>
                                    <td style="text-align:left">
                                        <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="取消" Width="59px" OnClick="CancelPushButton_Click1"  CssClass="button"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:HyperLink ID="PasswordRecoveryLink" runat="server" NavigateUrl="~/changepassword/Passwordrecovery.aspx">忘记密码</asp:HyperLink>
                                        </td>
                                    <td>
                                       <a href="../soulcastlefrontpage.html"> 回主页</a>
                                    </td>
                                </tr>
                            </table>
         </form>
</body>
</html>
