<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bussinessprofile.aspx.cs" Inherits="WebApplication2.bussinessprofile" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>商家浏览页面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <h2>请选择活动发布的时间范围：</h2><asp:DropDownList ID="ActivityDropDownList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ActivityDropDownList_SelectedIndexChanged" Height="37px" Width="123px" >
            <asp:ListItem></asp:ListItem>
            <asp:ListItem Value="week">最近一周</asp:ListItem>
            <asp:ListItem Value="month">最近一个月</asp:ListItem>
        </asp:DropDownList>   
        <br />    
        <br /> 
    </div>
        <table>
            <tr>
                <td><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="username" HeaderText="商家名" >
                <HeaderStyle Width="100px" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="活动1图片">
                 <ItemTemplate>
                 <asp:Image ID="img1" ImageUrl='<%#Eval("Image1") %>' runat="server" AlternateText="image lost" Width="200" Height="200" />
                 </ItemTemplate>
                    <ItemStyle Height="200px" Width="200px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Intro1" HeaderText="介绍" >
                <HeaderStyle Width="100px" />
                </asp:BoundField>
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
        </asp:GridView></td>
                <td><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
             <Columns>
                <asp:BoundField DataField="username" HeaderText="商家名" >
                 <HeaderStyle Width="100px" />
                 </asp:BoundField>
                <asp:TemplateField HeaderText="活动2图片">
                 <ItemTemplate>
                 <asp:Image ID="img1" ImageUrl='<%#Eval("Image2") %>' runat="server" AlternateText="image lost"  Width="200" Height="200"/>
                 </ItemTemplate>
                    <ItemStyle Height="200px" Width="200px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Intro2" HeaderText="介绍" >
                 <HeaderStyle Width="100px" />
                 </asp:BoundField>
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
                </td>
                <td><asp:GridView ID="GridView3" runat="server"  AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
             <Columns>
                <asp:BoundField DataField="username" HeaderText="商家名" >
                 <HeaderStyle Width="100px" />
                 </asp:BoundField>
                <asp:TemplateField HeaderText="活动3图片">
                 <ItemTemplate>
                 <asp:Image ID="img1" ImageUrl='<%#Eval("Image3") %>' runat="server" AlternateText="image lost"  Width="200" Height="200"/>
                 </ItemTemplate>
                    <ItemStyle Height="200px" Width="200px" />
                </asp:TemplateField>
                <asp:BoundField DataField="Intro3" HeaderText="介绍" >
                 <HeaderStyle Width="100px" />
                 </asp:BoundField>
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
        </asp:GridView></td>
            </tr>
        </table>      
    </form>
    <a href="../soulcastlefrontpage.html">回首页</a>
</body>
</html>
