<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bussinessRegister.aspx.cs" Inherits="WebApplication2.bussiness" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>商家注册页面</title>
    <style type="text/css">
        .auto-style1 {
            width: 104px;
        }
        .auto-style2 {
            width: 104px;
            height: 129px;
        }
        .auto-style4 {
            height: 129px;
            width: 112px;
        }
        .auto-style5 {
            width: 112px;
        }
        .auto-style6 {
            height: 129px;
            width: 122px;
        }
        .auto-style7 {
            width: 122px;
        }
        #Button1 {
            height: 30px;
            width: 86px;
            margin-left: 1px;
        }
        .auto-style9 {
            width: 899px;
            height: 82px;
        }
        .auto-style10 {
            width: 203px;
        }
    </style>
</head>
<body style="height: 294px">
    <table style="width: 800px; height: 235px">
      <tr>
       <td class="auto-style3" colspan="3"  style='background:url("Imagescom/shangjiazhuce1.jpg") no-repeat #cccccc;'><span class="auto-style19">心灵之家SOULCASTLE</span>&nbsp;&nbsp;&nbsp;&nbsp; 商家注册页面</td>
       </tr>
                <tr>
                    <td class="auto-style10" colspan="3"><span class="倡导">亲爱的商家朋友，</span>您好！<br />当你来到此页面，你将完成在此的注册，也就是你将在此发布的活动，从此你不必为到处发宣传单而找不到客户担忧了。
                        <br />同时你所发布的消息，也为地球纸张资源浪费，做了一份贡献。我们心灵之家网站为了目前设计了一次在线完成提交的3个活动发布内容。
                        <br />心灵之家SOULCASTLE网站感谢你的使用,谢谢！
                    </td>
                 </tr>
        </table>
    <form id="form1" runat="server">
        欢迎您,商家朋友：<asp:Label ID="bussinessLabel" runat="server"></asp:Label>
        你发布的活动如下：<br />
        <table style="width: 66%; height: 173px;">
            <tr>
                <td class="auto-style2">
        <asp:Image ID="Image1" runat="server" Height="180px" Width="182px" />
                </td>
                <td class="auto-style4">
        <asp:Image ID="Image2" runat="server" Width="175px" Height="179px" />
                </td>
                <td class="auto-style6">
                    <asp:Image ID="Image3" runat="server" Height="176px" Width="178px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:TextBox ID="ImgTextBox1" runat="server" TextMode="MultiLine" Height="38px" Width="173px"></asp:TextBox>
                </td>
                <td class="auto-style5">
                    <asp:TextBox ID="ImgTextBox2" runat="server" TextMode="MultiLine" Height="39px" Width="164px"></asp:TextBox>
                </td>
                <td class="auto-style7">
                    <asp:TextBox ID="ImgTextBox3" runat="server" TextMode="MultiLine" Width="163px" Height="34px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="DeleteButton1" runat="server" Text="删除" Width="53px" OnClick="DeleteButton1_Click" />
                </td>
                <td>
                    <asp:Button ID="DeleteButton2" runat="server" Text="删除" Width="57px" OnClick="DeleteButton2_Click" />
                </td> 
                <td>
                    <asp:Button ID="DeleteButton3" runat="server" Text="删除" Width="59px" OnClick="DeleteButton3_Click" />
                </td>
            </tr>           
        </table>
        提交商业活动相关图片： <asp:FileUpload ID="FileUpload1" runat="server" Height="29px" Width="237px" />
        <asp:CustomValidator ID="ImgCustomValidator" runat="server" ErrorMessage="请插入有效的.jpg图片" ControlToValidate="FileUpload1"></asp:CustomValidator>
        <br />
        *每张图片大小不得超过200KB，上传图片总数不得超过3张<br />
        <br />
        活动简介：<asp:TextBox ID="ActivateIntro" runat="server" Height="82px" Width="355px"></asp:TextBox>
        <asp:Literal ID="errLiteral1" runat="server"></asp:Literal>
        <br />
        <br />
        <asp:Button ID="subButton" runat="server" Text="提交" Height="32px" OnClick="Button1_Click" Width="87px" /> 
        &nbsp;&nbsp;
        <a href="../soulcastlefrontpage.html"><input id="Button1" type="button" value="回主页" /></a><br />
        <br />
        <br />
    </form>
      <table>           
    <tr>
                    <td class="auto-style9" colspan="3">心灵之家SOULCASTLE商家注册页面为心灵之家科技有限公司soulcastle 版权所有</td>
                </tr>
            </table>
</body>
</html>
