<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bussinessAddActivity.aspx.cs" Inherits="WebApplication2.bussinessRegister" enableEventValidation="false" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="SHORTCUT ICON" href="Imagescom/scico.gif" />
    <title>商家活动添加页面</title>
    <link href="../style.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #Button1 {
        }
    </style>
</head>
<body>
    <div class="head">
     心灵之家SOULCASTLE商家活动展示页面
    </div>
    <form id="form1" runat="server">
        欢迎您,商家朋友：<asp:Label ID="bussinessLabel" runat="server"></asp:Label>
        &nbsp;您已发布的活动如下： 
        <table style="width: 100%; height: 173px;">
            <tr>
                <td>
        <asp:Image ID="Image1" runat="server" cssClass="image"/>
                </td>
                <td class="auto-style4">
        <asp:Image ID="Image2" runat="server" cssClass="image" />
                </td>
                <td class="auto-style6">
                    <asp:Image ID="Image3" runat="server" cssClass="image" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:TextBox ID="ImgTextBox1" runat="server" TextMode="MultiLine" CssClass="IntroTextBox"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="ImgTextBox2" runat="server" TextMode="MultiLine" CssClass="IntroTextBox"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="ImgTextBox3" runat="server" TextMode="MultiLine" CssClass="IntroTextBox"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="DeleteButton1" runat="server" Text="删除活动1" OnClick="DeleteButton1_Click"  CssClass="button"/>
                </td>
                <td>
                    <asp:Button ID="DeleteButton2" runat="server" Text="删除活动2" OnClick="DeleteButton2_Click" CssClass="button" />
                </td> 
                <td>
                    <asp:Button ID="DeleteButton3" runat="server" Text="删除活动3" OnClick="DeleteButton3_Click" CssClass="button" />
                </td>
            </tr>  
            <tr><td colspan="3">
                <asp:Button ID="Button1" runat="server" Text="发布活动" CssClass="button" Height="23px" OnClick="Button1_Click" Width="68px" />
                </td>
               </tr>         
        </table>
        <asp:Literal ID="errLiteral1" runat="server"></asp:Literal>
        <br />
        <br />
        <a href="../department/consulterBussinessInfo.html">查看咨询师和商家发布的活动信息</a>
        <br />
        <br/>
         <asp:LinkButton ID="LinkButton1" runat="server" OnClick="Button2_Click">回首页</asp:LinkButton>
    </form>
     <div class="foot">
    心灵之家SOULCASTLE科技有限公司版权所有
     </div>
</body>
</html>
