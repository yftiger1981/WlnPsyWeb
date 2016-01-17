<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bussinessModify.aspx.cs" Inherits="WebApplication2.bussiness.bussinessModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="SHORTCUT ICON" href="Imagescom/scico.gif" />
    <title>商家个人信息修改</title>
    <%--  <script>
        <%Session['username']='b1'%>
    </script>--%>
    <link href="../style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="head">
            商家信息修改
        </div>
    <div>   
        您好，<asp:Label ID="nameLabel" runat="server"></asp:Label>
        ：<br />
        你的个人信息如下：<br />
    </div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdated="GridView1_RowUpdated" OnRowUpdating="GridView1_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="姓名" >
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="password" HeaderText="密码" >
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:BoundField DataField="email" HeaderText="电子邮件" >
                <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:BoundField DataField="phone" HeaderText="电话" >
                <HeaderStyle Width="150px" />
                </asp:BoundField>
                <asp:BoundField DataField="QQ" HeaderText="QQ" >
                <HeaderStyle Width="150px" />
                </asp:BoundField>
                <asp:CommandField ShowEditButton="True" />
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
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上一页" CssClass="button"/>
        </p>
    </form>
     <div class="foot">
           心灵之家soulcastle 科技有限公司版权所有 
       </div>
</body>
</html>
