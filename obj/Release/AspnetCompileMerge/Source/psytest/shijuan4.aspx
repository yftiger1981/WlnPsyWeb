<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shijuan4.aspx.cs" Inherits="WebApplication2.psytest.shijuan4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="StyleSheet.css" rel="stylesheet" />
    <title>气质测试</title>
    <style type="text/css">
        .auto-style1 {
            width: 472%;
            height: 2150px;
        }
        .auto-style3 {
            width: 385px;
        }
        .auto-style4 {
            height: 492px;
        }
        .auto-style5 {
            width: 268435456px;
            height: 76px;
        }
        .auto-style6 {
            width: 549px;
        }
        .auto-style7 {
            width: 627px;
            height: 144px;
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
            height: 37px;
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
                  <td class="auto-style4" colspan="2">          
    <p>
        28.别人说我总是闷闷不乐。&nbsp;</p>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <p>
                29.理解问题常比别人慢。 </p>
            <asp:RadioButtonList ID="RadioButtonList3" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
           <p> 30.厌倦时只要短暂的休息就能精神抖擞，重新投入工作。</p> &nbsp; 
            <asp:RadioButtonList ID="RadioButtonList4" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
          <p>  31.心里有话宁愿自己想，不愿说出来。</p>
            <asp:RadioButtonList ID="RadioButtonList5" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
          <p>  32. 认准一个目标就希望尽快实现，不达目的，誓不罢休。 </p>&nbsp; 
            <asp:RadioButtonList ID="RadioButtonList6" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <p>33. 学习工作一段时间后，常比别人更困倦。</p>&nbsp; <br />
            <asp:RadioButtonList ID="RadioButtonList7" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <br />
          <p>  34. 做事有些鲁莽，常常不考虑后果。</p>&nbsp; 
            <br />
            <asp:RadioButtonList ID="RadioButtonList8" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <br />
           <p> 35.老师讲授新知识时，总希望讲解慢些，多重复几便。</p><br />
            <asp:RadioButtonList ID="RadioButtonList9" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <br />
           <p> 36. 能够很快的忘记那些不愉快的事情。</p> <br />
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