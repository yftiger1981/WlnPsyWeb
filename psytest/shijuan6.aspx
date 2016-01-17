<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shijuan6.aspx.cs" Inherits="WebApplication2.psytest.shijuan6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="StyleSheet.css" rel="stylesheet" />
    <link rel="SHORTCUT ICON" href="Imagescom/scico.gif" />
    <title>气质测试</title>
    <style type="text/css">
        .auto-style1 {
            width: 472%;
            height: 2031px;
        }
        .auto-style3 {
            width: 385px;
        }
        .auto-style4 {
            height: 591px;
        }
        .auto-style5 {
            width: 268435456px;
            height: 99px;
        }
        .auto-style6 {
            width: 549px;
        }
        .auto-style7 {
            width: 627px;
            height: 335px;
        }
        .auto-style8 {
            width: 683px;
            height: 271px;
        }
        .auto-style9 {
            height: 100px;
        }
        .auto-style10 {
            width: 268435456px;
            height: 150px;
        }
    </style>
   </head>
    <body>      
  <div  style ="background:url(./Images/tibackground.jpg); height: 2550px; width: 1359px;" > 
      <div style="height: 1px; width: 225px; margin-top: 220px;"> 
          <form id="form1" runat="server">     
          <table class="auto-style1">              
              <tr>
                  <td class="auto-style3" rowspan="4"><div style="height: 871px; width: 353px; margin-right: 45px"></div></td>
                  <td class="auto-style9" colspan="2">
                    <%--  <td>--%>
                      <table class="auto-style7">
                          <tr>
                              <td class="auto-style8" colspan="2">

                                  &nbsp;</td>
                          </tr>
                      </table>
                  </td>
              </tr>
              <tr>
                  <td class="auto-style4" colspan="2">    <p>
        46.喜欢变化大，花样多的工作。 </p>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <p>
                47.小的时候会背的诗歌，我似乎比别人记得更清楚。 </p>
            <asp:RadioButtonList ID="RadioButtonList3" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <p> 48.别人说我出语伤人，自己并不觉得这样。</p>
            <asp:RadioButtonList ID="RadioButtonList4" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <p>  49.在体育活动中，常因反应慢而落后。</p>
            <asp:RadioButtonList ID="RadioButtonList5" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <p>  50. 反应敏捷，头脑机智。</p>
            <asp:RadioButtonList ID="RadioButtonList6" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <p>  51. 喜欢有条理而不甚麻烦的工作。</p> 
            <asp:RadioButtonList ID="RadioButtonList7" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <p> 52.兴奋的事情常使我失眠。</p>
            <asp:RadioButtonList ID="RadioButtonList8" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
          <p>  53.老师讲的新概念，我常常听不懂。</p>
            <asp:RadioButtonList ID="RadioButtonList9" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <p>54. 假如工作枯燥无味，马上就会情绪低落。</p>
            <asp:RadioButtonList ID="RadioButtonList10" runat="server" Width="233px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
          <br />

      </td>
              </tr>
              <tr>
                  <td class="auto-style6" rowspan="2" >
                      <div style="height: 64px; width: 486px">
	                </div></td>
                  <td class="auto-style10">
                      </td>
              </tr>              
              <tr>
                  <td class="auto-style5">
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/testtjmiddle_02.png" OnClick="ImageButton1_Click" CssClass="imagebutton" />         
	                </td>
              </tr>              
                   </table>
               </form>
          </div>
       
          </div>
	
</body>
</html>