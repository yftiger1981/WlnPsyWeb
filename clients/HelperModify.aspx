<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelperModify.aspx.cs" Inherits="WebApplication2.HelperModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="SHORTCUT ICON" href="Imagescom/scico.gif" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="head">
            求助者个人信息修改
        </div>
    <div>
    
        您好:<asp:Label ID="NameLabel" runat="server"></asp:Label>
        ,你的个人信息如下：
        <br/>
        <asp:Image ID="selfImage" runat="server" cssclass="image"/>
        <br/>
        更改我的头像:
        <br/>
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" Height="31px" Width="230px" /> 
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上传" cssclass="button" />
        <br />
        （请上传.jpg类型的图片，大小不得超过200K）<br />
        <br />
        <asp:Label ID="errLabel" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="username" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="username" HeaderText="用户名" ReadOnly="True" SortExpression="username" />
                <asp:BoundField DataField="password" HeaderText="密码" SortExpression="password" />
                <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" />
                <asp:BoundField DataField="email" HeaderText="邮箱" SortExpression="email" />
                <asp:BoundField DataField="phone" HeaderText="电话" SortExpression="phone" />
                <asp:BoundField DataField="QQ" HeaderText="QQ" SortExpression="QQ" />
                <asp:CommandField CancelText="" DeleteText="" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:websiteConnectionStringhome %>" DeleteCommand="DELETE FROM [login] WHERE [username] = @username" InsertCommand="INSERT INTO [login] ([username], [password], [name], [email], [phone], [QQ]) VALUES (@username, @password, @name, @email, @phone, @QQ)" SelectCommand="SELECT [username], [password], [name], [email], [phone], [QQ] FROM [login] WHERE ([username] = @username)" UpdateCommand="UPDATE [login] SET [password] = @password, [name] = @name, [email] = @email, [phone] = @phone, [QQ] = @QQ WHERE [username] = @username">
            <DeleteParameters>
                <asp:Parameter Name="username" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="phone" Type="String" />
                <asp:Parameter Name="QQ" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter Name="username" SessionField="username" Type="String" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="password" Type="String" />
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="email" Type="String" />
                <asp:Parameter Name="phone" Type="String" />
                <asp:Parameter Name="QQ" Type="String" />
                <asp:Parameter Name="username" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <br />
        <a href="helperSelection.aspx">回上页</a></div>
    </form>
    <div class="foot">
        心灵之家soulcastle 科技有限公司版权所有 
    </div>
</body>
</html>
