<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="helperSelection.aspx.cs" Inherits="WebApplication2.helpee" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="SHORTCUT ICON" href="Imagescom/scico.gif" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>求助者选择页面</title>
    <style type="text/css">
        .style2 {
            height: 31px;
            color:yellow;
        }
        </style>
    <link href="../style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="head">   
        咨询师选择页面
 </div>
    <div>   
        您好：<asp:Label ID="userLabel" runat="server"></asp:Label>
        &nbsp;&nbsp;
        <asp:Button ID="modifySelfButton" runat="server" OnClick="modifySelfButton_Click" Text="修改个人信息" />
        <br />
        <br />
        你已选择的咨询师信息如下：<br />
        <asp:GridView ID="selectGridView" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" OnRowDeleting="GridView2_RowDeleting" DataKeyNames="IDCard">
            <Columns>
                <asp:TemplateField HeaderText="consulterUserName" SortExpression="consulterUserName" Visible="False">
                    <ItemTemplate>
                        <asp:Label ID="consulterLabel" runat="server" Text='<%# Bind("consulterUserName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name" />
                <asp:BoundField DataField="IDCard" HeaderText="身份证号" SortExpression="IDCard" />
                <asp:BoundField DataField="preference" HeaderText="咨询偏向" SortExpression="preference" />
                <asp:BoundField DataField="profession" HeaderText="擅长类型" SortExpression="profession" />
                <asp:BoundField DataField="prolevel" HeaderText="级别" SortExpression="prolevel" />
                <asp:BoundField DataField="selfIntro" HeaderText="自我介绍" SortExpression="selfIntro" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <a href="/bussiness/bussinessprofile.aspx">
          <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:websiteConnectionStringHome %>" SelectCommand="SELECT userConsulterRelation.consulterUserName, login.name, Consulter.IDCard, Consulter.preference, Consulter.profession, Consulter.prolevel, Consulter.selfIntro FROM Consulter INNER JOIN userConsulterRelation ON Consulter.username = userConsulterRelation.consulterUserName INNER JOIN login ON login.username = userConsulterRelation.consulterUserName WHERE (userConsulterRelation.helperUserName = @username)" DeleteCommand="DELETE FROM userConsulterRelation WHERE (helperUserName = @helperusername) AND (consulterUserName = @consulterUserName)">
            <DeleteParameters>
                <asp:Parameter Name="helperUserName" />
                <asp:Parameter Name="consulterUserName" />
            </DeleteParameters>
            <SelectParameters>
                <asp:SessionParameter Name="username" SessionField="username" />
            </SelectParameters>
            </asp:SqlDataSource>
        </a>
        咨询师信息如下:<p style="color:red">(最多选中五个咨询师)</p>
        请选择咨询师偏好的类型：<asp:DropDownList ID="preferenceDropDownList" runat="server">
            <asp:ListItem>情感障碍咨询</asp:ListItem>
            <asp:ListItem>工作学习咨询</asp:ListItem>
            <asp:ListItem>婚姻家庭咨询</asp:ListItem>
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp; 咨询师擅长的类型：<asp:DropDownList ID="GenreDropDownList" runat="server" AutoPostBack="True">
            <asp:ListItem>抑郁质</asp:ListItem>
            <asp:ListItem>多血质</asp:ListItem>
            <asp:ListItem>胆汁质</asp:ListItem>
            <asp:ListItem>黏液质</asp:ListItem>
        </asp:DropDownList>
        <asp:GridView ID="consulterGridView" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" OnSorting="consulterGridView_Sorting" OnRowCreated="consulterGridView_RowCreated">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="选择">
                     <ItemTemplate>
                        <asp:CheckBox ID="consulterCheck" runat="server" ></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="name" HeaderText="姓名">
                <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="IDCard" HeaderText="身份证号" SortExpression="IDCard" >
                <HeaderStyle Width="200px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="证件照">
                    <ItemTemplate>
                        <asp:Image runat="server" AlternateText="image lost" Height="200" Imageurl='<%#Eval("Imgpath")%>' Width="200" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="prolevel" HeaderText="级别" SortExpression="prolevel">
                <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="自我介绍" SortExpression="selfIntro" >
                    <ItemTemplate>
                        <asp:textbox ID="Label1" runat="server"  TextMode="MultiLine"  Rows="15" Columns="30" style="text-align:center"  Text='<%# Bind("selfIntro")  %>'></asp:textbox>
                    </ItemTemplate>
                    <HeaderStyle Width="200px" />
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="username" SortExpression="username" Visible="False">        
                    <ItemTemplate>
                        <asp:Label ID="consulterLabel" runat="server" Text='<%# Bind("username") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <%-- <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />--%>
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle CssClass="sortasc-header" BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle  CssClass="sortdesc-header" BackColor="#4870BE"/>
        </asp:GridView>
        <br />
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:websiteConnectionStringHome %>" SelectCommand="SELECT login.username,login.name, Consulter.IDCard,Consulter.Imgpath, Consulter.prolevel, Consulter.selfIntro FROM Consulter INNER JOIN login ON login.username = Consulter.username WHERE (Consulter.profession LIKE '%' + @profession + '%') AND (Consulter.preference LIKE '%' + @preference + '%')">
            <SelectParameters>
                <asp:ControlParameter ControlID="GenreDropDownList" Name="profession" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="preferenceDropDownList" Name="preference" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Button ID="SubmitButton" runat="server" Height="28px" OnClick="SubmitButton_Click" style="margin-top: 0px" Text="提交" Width="74px" />
        <br />
        <asp:Label ID="errLabel" runat="server"></asp:Label>
        <br />
        <br />
        <a href="/bussiness/bussinessprofile.aspx">浏览商家活动</a><br />
        <br />
        <a href="../soulcastlefrontpage.html">回首页</a>
    </div>
    </form>
    <div class="foot">
        心灵之家soulcastle 科技有限公司版权所有 
    </div>
</body>
</html>
