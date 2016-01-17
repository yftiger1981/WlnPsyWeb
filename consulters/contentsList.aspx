<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contentsList.aspx.cs" Inherits="WebApplication2.consulters.contentsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="SHORTCUT ICON" href="Imagescom/scico.gif" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
        <table style="width: 367px; height: 60px">
            <tr><td style="text-align:center">求助者问题列表</td></tr>
            <tr>   
            <td>输入求助者用户名：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
        </tr>
        </table>
        <asp:Button ID="SearchButton" runat="server" Text="搜索" OnClick="SearchButton_Click" Visible="true"/>
        &nbsp;
        <asp:CheckBox ID="CheckBox1" runat="server" Text="查看所有求助者问题" OnCheckedChanged="CheckBox1_CheckedChanged" AutoPostBack="True" />
&nbsp;<table>
            <tr>
                <td>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="title" HeaderText="标题" SortExpression="title" />
                <asp:BoundField DataField="content1" HeaderText="内容" SortExpression="content1" />
                <asp:BoundField DataField="author" HeaderText="求助者" SortExpression="author" />
                <asp:BoundField DataField="time" HeaderText="时间" SortExpression="time" />
            </Columns>
        </asp:GridView>
                    </td>
                <td>
                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Visible="false">
                        <Columns>
                            <asp:BoundField DataField="title" HeaderText="标题" SortExpression="title" />
                            <asp:BoundField DataField="content1" HeaderText="内容" SortExpression="content1" />
                            <asp:BoundField DataField="time" HeaderText="时间" SortExpression="time" />
                            <asp:BoundField DataField="author" HeaderText="作者" SortExpression="author" />
                        </Columns>
                    </asp:GridView>
                </td>
                </tr>
            </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:websiteConnectionStringHome %>" SelectCommand="SELECT * FROM [helperQuestion]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:websiteConnectionStringHome %>" SelectCommand="SELECT * FROM [helperQuestion] WHERE ([author] = @author)">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="author" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
    <p>
      <a href="../soulcastlefrontpage.html">  回主页</a></p>
</body>
</html>
