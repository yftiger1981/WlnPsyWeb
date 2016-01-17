<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="consulter.aspx.cs" Inherits="WebApplication2.consult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>咨询师页面</title>
    <link href="../style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>  
        <p>
        咨询师：<asp:Label ID="ConsulterName" runat="server"></asp:Label>
        ,您好！ <a href="consulterModify.aspx">修改个人信息</a><br />
        选择你的求助者信息如下：<br />
        成人求助者：
        </p>
        <asp:GridView ID="adultGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="username" HeaderText="用户名" />
                <asp:BoundField DataField="personanity" HeaderText="人格特征" />
                <asp:BoundField DataField="age" HeaderText="年龄" />
                <asp:BoundField DataField="parentedu" HeaderText="父母受教育程度" />
                <asp:BoundField DataField="seledu" HeaderText="自己受教育程度" />
                <asp:BoundField DataField="psyknowledge" HeaderText="心理知识" />
                <asp:BoundField DataField="prolength" HeaderText="问题出现的时间" />
                <asp:BoundField DataField="bodycondi" HeaderText="身体状况" />
                <asp:BoundField DataField="workcondi" HeaderText="工作状况" />
                <asp:BoundField DataField="prosolv" HeaderText="希望问题解决的程度" />
                <asp:BoundField DataField="tellpar" HeaderText="是否告诉父母" />
                <asp:BoundField DataField="firstapp" HeaderText="是否第一次出现" />
                <asp:BoundField DataField="email" HeaderText="邮箱" />
                <asp:BoundField DataField="phone" HeaderText="电话" />
                <asp:BoundField DataField="QQ" HeaderText="QQ" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        <br/>
        </div>
        <br/>
        <p>儿童求助者：</p>
        <asp:GridView ID="childGridView" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="username" HeaderText="用户名" />
                <asp:BoundField DataField="personanity" HeaderText="人格特征" />
                <asp:BoundField DataField="age" HeaderText="年龄" />
                <asp:BoundField DataField="gender" HeaderText="性别" />
                <asp:BoundField DataField="bodycondi" HeaderText="身体状况" />
                <asp:BoundField DataField="psyknowledge" HeaderText="心理知识" />
                <asp:BoundField DataField="childcare" HeaderText="对孩子问题的关心程度" />
                <asp:BoundField DataField="liveto" HeaderText="是否和小孩一起居住" />
                <asp:BoundField DataField="separate" HeaderText="是否常年与小孩分开" />
                <asp:BoundField DataField="carebyold" HeaderText="孩子是否由老父母照看" />
                <asp:BoundField DataField="email" HeaderText="邮箱" />
                <asp:BoundField DataField="phone" HeaderText="电话" />
                <asp:BoundField DataField="QQ" HeaderText="QQ" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </form>
    <a href="../soulcastlefrontpage.html">回首页</a>
</body>
</html>
