<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changePassword.aspx.cs" Inherits="WebApplication2.ChangePassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>修改密码</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>   
        <asp:ChangePassword ID="ChangePassword1" runat="server" CancelDestinationPageUrl="~/login.aspx" OnChangedPassword="ChangePassword1_ChangedPassword" OnChangingPassword="ChangePassword1_ChangingPassword" SuccessPageUrl="~/changepasswordsuccess.aspx">
        </asp:ChangePassword>   
    </div>
    </form>
</body>
</html>
