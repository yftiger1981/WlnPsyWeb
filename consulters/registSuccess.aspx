<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registSuccess.aspx.cs" Inherits="WebApplication2.consulters.registSuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link rel="SHORTCUT ICON" href="Imagescom/scico.gif" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>问题发布</title>
    <style type="text/css">
        #TextArea1 {
            height: 71px;
            width: 261px;
        }
        .auto-style1 {
            height: 40px;
        }
    </style>
    <link href="../style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>  
         <div class="head">
         版块活动发布页面
        </div>
        欢迎您：<asp:Label ID="nameLabel" runat="server"></asp:Label>
        &nbsp;<br />
        您的头像：
        <br/>
         <asp:Image ID="Image1" runat="server" CssClass="image"/>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="个人资料查看及修改" />      
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
             <ContentTemplate>
              <table>
               <tr><td colspan="2">活动添加：
                   </td></tr>
                <tr> <td colspan="2">标题：</td></tr>
               <tr> <td> <asp:TextBox ID="titleTextBox" runat="server" CssClass="textbox"></asp:TextBox></td><td>
                   <asp:Literal ID="titleLiteral" runat="server"></asp:Literal>
                   </td></tr>
                <tr> <td colspan="2"> 活动内容：</td></tr>

        <tr>
            <td>
                <asp:TextBox ID="contentTextBox" runat="server" CssClass="ActiveTextBox" TextMode="MultiLine" Columns="10" Rows="10"></asp:TextBox> </td>
            <td>
                <asp:Literal ID="contentLiteral" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td colspan="2">请选择活动发布的版块：</td>
        </tr>
        </table>
        <table>
        <tr>
            <td>
                <asp:RadioButton ID="RadioButton1" runat="server" Text="成人个体帮助" GroupName="s" checked="true"/>
            </td>
              <td>
                <asp:RadioButton ID="RadioButton2" runat="server" Text="成人团体帮助" GroupName="s" />
                </td>
            <td>
                <asp:RadioButton ID="RadioButton3" runat="server" Text="成人咨询室" GroupName="s" />
            </td>
                <td>
                <asp:RadioButton ID="RadioButton4" runat="server" Text="家庭系列活动" GroupName="s" />
                </td>
        </tr>
        <tr>
            <td><asp:RadioButton ID="RadioButton5" runat="server" Text="儿童个体帮助" GroupName="s" /></td>
            <td>
       <asp:RadioButton ID="RadioButton6" runat="server" Text="儿童团体帮助" GroupName="s" /></td>
<td> <asp:RadioButton ID="RadioButton7" runat="server" Text="儿童情感转移" GroupName="s" /></td>
 <td><asp:RadioButton ID="RadioButton8" runat="server" Text="儿童文体娱活动" GroupName="s" /></td>
        </tr>
    </table>
               
                                    </ContentTemplate>
                   <Triggers>
                       <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
             </Triggers>
                   </asp:UpdatePanel>
          <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="提交" Width="57px" />
        <br/>
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <asp:Button ID="addActivityButton" runat="server" OnClick="addActivityButton_Click" Text="增加商家活动" Visible="False" />
        <br />
        <br />
        <asp:Button ID="consulterButton" runat="server" OnClick="Button3_Click" Text="查看选择我的求助者" Visible="False" />
        <br />
        <br />
        <a href="../department/consulterBussinessInfo.html">查看咨询师和商家发布的活动信息</a><br />
        <br />
        <a href="../soulcastlefrontpage.html">回首页</form>
    <div class="foot">
         心灵之家soulcastle 科技有限公司版权所有 
     </div>
    </body>
</html>
