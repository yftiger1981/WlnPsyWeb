<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consulterModify.aspx.cs" Inherits="WebApplication2.consulters.consulterModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <p>
            您好，<asp:Label ID="nameLabel" runat="server"></asp:Label>
        </p>
        <p>
            你的个人信息如下：</p>
       
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="username" HeaderText="用户名" />
                <asp:BoundField DataField="name" HeaderText="姓名" />
                <asp:BoundField DataField="password" HeaderText="密码" SortExpression="password" />
                <asp:BoundField DataField="sex" HeaderText="性别" SortExpression="gender" />
                <asp:BoundField DataField="email" HeaderText="邮箱" />
                <asp:BoundField DataField="IDCard" HeaderText="身份证号" />
                <asp:TemplateField HeaderText="照片">
                    <ItemTemplate>
                        <asp:image ID="Img1" runat="server" ImageUrl='<%#Eval("Imgpath") %>' AlternateText="没有照片" Width="200px" Height="200px"></asp:image>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="preference" HeaderText="偏好" />
                <asp:BoundField DataField="profession" HeaderText="擅长类型" />
                <asp:BoundField DataField="prolevel" HeaderText="等级" />
                <asp:BoundField DataField="selfIntro" HeaderText="自我介绍" />
                <asp:CommandField DeleteText="" ShowEditButton="True" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:websiteConnectionStringhome %>" SelectCommand="SELECT login.username, login.password, login.name, login.email, Consulter.profession, Consulter.prolevel, Consulter.selfIntro, Consulter.Imgpath, Consulter.IDCard, Consulter.preference, Consulter.sex FROM login INNER JOIN Consulter ON login.username = Consulter.username WHERE (login.username = @username)" UpdateCommand="UPDATE [Consulter] SET [Imgpath] = @Imgpath, preference=@preference,[profession] = @profession, [prolevel] = @prolevel, [selfIntro] = @selfIntro WHERE [username] = @username" DeleteCommand="DELETE FROM [Consulter] WHERE [username] = @username" InsertCommand="INSERT INTO [Consulter] ([username], [Imgpath], [profession], [prolevel], [selfIntro]) VALUES (@username, @Imgpath, @profession, @prolevel, @selfIntro)">
            <DeleteParameters>
                <asp:Parameter Name="username" Type="String" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="username" Type="String" />
                <asp:Parameter Name="Imgpath" Type="String" />
                <asp:Parameter Name="profession" Type="String" />
                <asp:Parameter Name="prolevel" Type="String" />
                <asp:Parameter Name="selfIntro" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="username" SessionField="username" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Imgpath" Type="String" />
                <asp:Parameter Name="preference" />
                <asp:Parameter Name="profession" Type="String" />
                <asp:Parameter Name="prolevel" Type="String" />
                <asp:Parameter Name="selfIntro" Type="String" />
                <asp:Parameter Name="username" Type="String" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <p>
            <strong>注意:</strong></p>
        <p>
            <strong>1.偏好只能修改为:情感障碍咨询,工作学习咨询,婚姻家庭生活 中的项目。</strong></p>
        <p>
            <strong>2.擅长类型只能修改为：抑郁质，胆汁质，多血质，粘液质 中的项目。</strong></p>
        <p>
            <strong>3.等级只能修改为：一级，二级，三级 中的项目。</strong></p>
    </form>
    <p>
        上一<a href="consulter.aspx">页</a></p>
</body>
</html>
