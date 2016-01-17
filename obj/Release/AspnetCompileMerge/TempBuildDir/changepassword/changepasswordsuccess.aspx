<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="changepasswordsuccess.aspx.cs" Inherits="WebApplication2.changepasswordsuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>密码修改成功</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ChangePassword ID="ChangePassword1" runat="server" OnContinueButtonClick="ChangePassword1_ContinueButtonClick">
        </asp:ChangePassword>
    
    </div>
    </form>
</body>
</html>
