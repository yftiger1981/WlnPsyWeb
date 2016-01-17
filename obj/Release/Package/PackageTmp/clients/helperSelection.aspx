<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="helperSelection.aspx.cs" Inherits="WebApplication2.helpee" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>求助者选择页面</title>
    <style type="text/css">
        .style2 {
            height: 31px;
            color:yellow;
        }
        .auto-style1 {
            height: 31px;
            color: yellow;
            text-align: center;
            font-family:'Comic Sans MS';
        }
    </style>
    <link href="../style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-image:url(/Imagescom/lttanc.png)">   
        <p class="style2">SOULCASTLE心灵之家</p>
        <p class="auto-style1">欢迎你来到心灵之家，从此将开启你的幸福之旅^-^! </p>  
 </div>
    <div>   
        您好：<asp:Label ID="userLabel" runat="server"></asp:Label>
        &nbsp;&nbsp; <a href="HelperModify.aspx">修改个人信息</a><br />
        你已选择的咨询师信息如下：<br />
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource3" OnRowDeleting="GridView2_RowDeleting" DataKeyNames="IDCard">
            <Columns>
                <asp:BoundField DataField="consulter" HeaderText="姓名" SortExpression="name" />
                <asp:BoundField DataField="IDCard" HeaderText="身份证号" SortExpression="IDCard" />
                <asp:BoundField DataField="preference" HeaderText="咨询偏向" SortExpression="preference" />
                <asp:BoundField DataField="profession" HeaderText="擅长类型" SortExpression="profession" />
                <asp:BoundField DataField="prolevel" HeaderText="级别" SortExpression="prolevel" />
                <asp:BoundField DataField="selfIntro" HeaderText="自我介绍" SortExpression="selfIntro" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        你选择的咨询师如下：<br />
        <asp:ListBox ID="ListBox1" runat="server" Height="128px" Width="157px"></asp:ListBox>
        &nbsp;&nbsp;
        <asp:Button ID="DeleteButton" runat="server" OnClick="DeleteButton_Click" Text="重新选择咨询师" Width="125px" style="margin-top: 0px" Height="27px" />
        <br />
        <br />
        咨询师信息如下：<br />
        请选择咨询师偏好的类型：<asp:DropDownList ID="preferenceDropDownList" runat="server">
            <asp:ListItem>情感障碍咨询</asp:ListItem>
            <asp:ListItem>工作学习咨询</asp:ListItem>
            <asp:ListItem>婚姻家庭咨询</asp:ListItem>
        </asp:DropDownList>
&nbsp;&nbsp;&nbsp; 及咨询师擅长的类型：<asp:DropDownList ID="GenreDropDownList" runat="server" AutoPostBack="True" >
            <asp:ListItem>抑郁质</asp:ListItem>
            <asp:ListItem>多血质</asp:ListItem>
            <asp:ListItem>胆汁质</asp:ListItem>
            <asp:ListItem>黏液质</asp:ListItem>
        </asp:DropDownList>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"  DataSourceID="SqlDataSource2" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" CellPadding="4" ForeColor="#333333" GridLines="None" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" >
                <HeaderStyle Width="50px" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:CommandField>
                <asp:BoundField DataField="name" HeaderText="姓名" >
                <HeaderStyle Width="100px" />
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="IDCard" HeaderText="身份证号" SortExpression="IDCard" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="证件照">
                    <ItemTemplate>
                   <asp:Image runat="server" Imageurl='<%#Eval("Imgpath")%>' AlternateText="image lost" Width="200" Height="200"> </asp:Image>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="prolevel" HeaderText="级别" SortExpression="prolevel" >
                <HeaderStyle Width="50px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="selfIntro" HeaderText="自我介绍" SortExpression="selfIntro" >
                <HeaderStyle Width="200px" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                </asp:BoundField>
                <asp:BoundField DataField="email" HeaderText="邮箱" SortExpression="email" />
                <asp:BoundField DataField="phone" HeaderText="电话" SortExpression="phone" />
                <asp:BoundField DataField="QQ" HeaderText="QQ" SortExpression="QQ" />
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
        <br />
        &nbsp;<br />
        <asp:Button ID="SubmitButton" runat="server" OnClick="SubmitButton_Click" style="margin-top: 0px" Text="提交"  cssclass="button"/>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <a href="../soulcastlefrontpage.html">回首页</a><br />
        <br />
        <asp:Label ID="errLabel" runat="server"></asp:Label>
        <br />
        <br />  
        <a href="/bussiness/bussinessprofile.aspx"><h2>浏览商家信息<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:websiteConnectionStringhome %>" SelectCommand="SELECT userConsulterRelation.consulter, Consulter.IDCard, Consulter.preference, Consulter.profession, Consulter.prolevel, Consulter.selfIntro FROM Consulter INNER JOIN userConsulterRelation ON Consulter.IDCard = userConsulterRelation.IDCard WHERE (userConsulterRelation.username = @username)" DeleteCommand="DELETE FROM userConsulterRelation WHERE (username = @username) AND (IDCard = @IDCard)">
            <DeleteParameters>
                <asp:Parameter Name="username" />
                <asp:Parameter Name="IDCard" />
            </DeleteParameters>
            <SelectParameters>
                <asp:QueryStringParameter Name="username" QueryStringField="username" />
            </SelectParameters>
            </asp:SqlDataSource>
        </h2></a> 
    </div>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:websiteConnectionStringhome %>" SelectCommand="SELECT login.name,login.email,login.phone,login.QQ, Consulter.IDCard,Consulter.Imgpath, Consulter.prolevel, Consulter.selfIntro FROM Consulter INNER JOIN login ON login.username = Consulter.username WHERE (Consulter.profession LIKE '%' + @profession + '%') AND (Consulter.preference LIKE '%' + @preference + '%')">
            <SelectParameters>
                <asp:ControlParameter ControlID="GenreDropDownList" Name="profession" PropertyName="SelectedValue" Type="String" />
                <asp:ControlParameter ControlID="preferenceDropDownList" Name="preference" PropertyName="SelectedValue" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
