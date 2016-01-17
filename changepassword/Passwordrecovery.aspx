<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Passwordrecovery.aspx.cs" Inherits="WebApplication2.Passwordrecovery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link rel="SHORTCUT ICON" href="Imagescom/scico.gif" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

                            <table cellpadding="0">
                                <tr>
                                    <td align="center" colspan="2">是否忘记了您的密码?</td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2">要接收您的密码，请输入您的用户名。</td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">用户名:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="必须填写“用户名”。" ToolTip="必须填写“用户名”。" ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color:Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="提交" ValidationGroup="PasswordRecovery1" OnClick="SubmitButton_Click" />
                                    </td>
                                </tr>
                            </table>

    
    </div>
    </form>
</body>
</html>
