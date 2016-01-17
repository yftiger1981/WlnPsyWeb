<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consulterprofiles.aspx.cs" Inherits="WebApplication2.consulterprofiles" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>咨询师简介</title>
    <link href="../style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="head">
<h2  style='background:url("Imagescom/zhixunshizhuce.jpg") no-repeat #cccccc;text-align:center'>心灵之家SOULCASTLE咨询师信息浏览</h2>
       </div>
    <form id="form1" runat="server">
    <div>  
        <h2>咨询师简介：</h2></div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" DataSourceID="SqlDataSource1" Height="283px" Width="1000px" AutoGenerateColumns="False" style="margin-right: 75px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical"  >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" >
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="照片" SortExpression="Imgpath">
                    <ItemTemplate>
                        <asp:image runat="server"  ImageUrl='<%#Eval("Imgpath") %>' AlternateText="没有照片" Width="200px" Height="200px"></asp:image>
                    </ItemTemplate>
                    <HeaderStyle Width="220px" />
                </asp:TemplateField>
                <asp:BoundField DataField="profession" HeaderText="擅长类型" SortExpression="profession" >
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="prolevel" HeaderText="等级" SortExpression="prolevel" >
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="selfIntro" HeaderText="自我介绍" SortExpression="selfIntro" >
                <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="email" HeaderText="邮箱" SortExpression="email" />
                <asp:BoundField DataField="phone" HeaderText="电话" SortExpression="phone" />
                <asp:BoundField DataField="QQ" HeaderText="QQ" SortExpression="QQ" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:websiteConnectionStringhome %>" SelectCommand="SELECT login.name, login.email, login.phone, login.QQ, Consulter.Imgpath, Consulter.profession, Consulter.prolevel, Consulter.selfIntro FROM Consulter INNER JOIN login ON login.username = Consulter.username"></asp:SqlDataSource>
    </form>
    <a href="../soulcastlefrontpage.html">回首页</a>
    <div class="foot">
      心灵之家SOULCASTLE商家注册页面为2014 心灵之家科技有限公司soulcastle 版权所有
  </div>
</body>
</html>
