<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bussinessprofile.aspx.cs" Inherits="WebApplication2.bussinessprofile" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="SHORTCUT ICON" href="Imagescom/scico.gif" />
    <title>商家浏览页面</title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
    </style>
    <link href="../style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="head">
            商家活动展示页面
        </div>
    <div> 
        <table>   
        <tr><td style="text-align:left" colspan="2">请选择活动发布的时间范围：<asp:ScriptManager ID="ScriptManager1" runat="server"  EnableScriptGlobalization="true" EnableScriptLocalization="true">
            </asp:ScriptManager>
            </td></tr>
        <tr><td><asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem Value="week">一周内</asp:ListItem>
            <asp:ListItem Value="month">一月内</asp:ListItem>
        </asp:RadioButtonList>
            </td>
           
            </tr>
            <tr> <td>或者您可以按时间选择：</td></tr>
       <tr><td> 开始时间：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
           <ajaxToolkit:CalendarExtender ID="TextBox1_CalendarExtender" runat="server" TargetControlID="TextBox1" Format="yyyy/MM/dd" CssClass="myCalender"/>
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
          <td> 结束时间：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
              <ajaxToolkit:CalendarExtender ID="TextBox2_CalendarExtender" runat="server" TargetControlID="TextBox2" Format="yyyy/MM/dd" CssClass="myCalender"/>
&nbsp;</td></tr>
            <tr><td>
                <asp:Button ID="Button1" runat="server" Text="搜索" CssClass="button" OnClick="Button1_Click" />
                </td></tr>
            </table>
    </div>
        <table>
            <tr>
                <td class="auto-style1">活动一展区</td><td class="auto-style1">活动二展区</td><td class="auto-style1">活动三展区</td>
            </tr>
            <tr>
                <td style="vertical-align:top"><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                <asp:TemplateField HeaderText="介绍">
                    <ItemTemplate>
                        <asp:textbox ID="Label1" runat="server" TextMode="MultiLine" rows="15" columns="20" Text='<%# Bind("Intro1") %>'></asp:textbox>
                    </ItemTemplate>
                    <HeaderStyle Width="100px" />
                </asp:TemplateField>
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
                <td style="vertical-align:top"><asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                 <asp:TemplateField HeaderText="介绍">
                     <ItemTemplate>
                         <asp:textbox ID="Label1" runat="server" TextMode="MultiLine" rows="15" columns="20" Text ='<%# Bind("Intro2") %>'></asp:textbox>
                     </ItemTemplate>
                     <HeaderStyle Width="100px" />
                 </asp:TemplateField>
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
                <td style="vertical-align:top"><asp:GridView ID="GridView3" runat="server"  AutoGenerateColumns="False" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                 <asp:TemplateField HeaderText="介绍">
                     <ItemTemplate>
                         <asp:textbox ID="Label1" runat="server" TextMode="MultiLine" rows="15" columns="20" Text='<%# Bind("Intro3") %>'></asp:textbox>
                     </ItemTemplate>
                     <HeaderStyle Width="100px" />
                 </asp:TemplateField>
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
            <tr><td><webdiyer:AspNetPager ID="AspNetPager1" runat="server" PageSize="5" 
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
PagingButtonSpacing="3px" OnPageChanged="AspNetPager1_PageChanged" >
</webdiyer:AspNetPager> </td>
 <td><webdiyer:AspNetPager ID="AspNetPager2" runat="server" PageSize="5" 
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
PagingButtonSpacing="3px" OnPageChanged="AspNetPager2_PageChanged" >
</webdiyer:AspNetPager></td>
 <td><webdiyer:AspNetPager ID="AspNetPager3" runat="server" PageSize="5" 
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
PagingButtonSpacing="3px" OnPageChanged="AspNetPager3_PageChanged">
</webdiyer:AspNetPager></td></tr>
        </table>      
    </form>
    <a href="../soulcastlefrontpage.html">回首页</a>
    <div class="foot">
         心灵之家soulcastle 科技有限公司版权所有 
    </div>
</body>
</html>
