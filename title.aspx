<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="title.aspx.cs" Inherits="WebApplication2.title" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="SHORTCUT ICON" href="Imagescom/scico.gif" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center"> 
      <asp:Literal ID="titleLiteral" runat="server"></asp:Literal>   
    </div>
       <table>
        <tr><td>
        <div style="align-content:center;width:100%;text-align:center"/></td></tr>
        <tr><td style="text-align:center"><asp:GridView ID="GridView1" runat="server" align="center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" AllowPaging="True" PagezSize="10" OnPageIndexChanged="GridView1_PageIndexChanged" OnPageIndexChanging="GridView1_PageIndexChanging" style="margin-left: 0px">
            <Columns>
                <asp:TemplateField HeaderText="标题">       
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("title")%>' ></asp:Label>
                    </ItemTemplate>
                    <FooterStyle Width="200px" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Bottom" Width="500px" />
                </asp:TemplateField>
                <asp:BoundField DataField="author" HeaderText="作者" />
                <asp:TemplateField HeaderText="时间">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%#Bind("time") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="uid" SortExpression="uid" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="uid" runat="server" Text='<%# Bind("uid") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
           
         
<webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="10" 
HorizontalAlign="Center" Width="100%" 
meta:resourceKey="AspNetPager1" Style="font-size: 14px" 
AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" 
PrevPageText="上一页" SubmitButtonText="Go" SubmitButtonClass="submitBtn" 
CustomInfoStyle="font-size:14px;text-align:left;" 
InputBoxStyle="width:25px; border:1px solid #999999; text-align:center; " 
TextBeforeInputBox="转到第" TextAfterInputBox="页 " PageIndexBoxType="TextBox" 
ShowPageIndexBox="Always" TextAfterPageIndexBox="页" 
TextBeforePageIndexBox="转到" Font-Size="14px" CustomInfoHTML="共<font color='#ff0000'>%PageCount%</font>页，第<font color='#ff0000'>%CurrentPageIndex%</font>页" 
ShowCustomInfoSection="Left" CustomInfoSectionWidth="19%" 
PagingButtonSpacing="3px" onpagechanged="AspNetPager1_PageChanged">
</webdiyer:AspNetPager> 
         </td></tr>
        <tr><td><asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上一页" /></td></tr>
               </table>
    </form>
</body>
</html>
