<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shijuan3.aspx.cs" Inherits="WebApplication2.psytest.shijuan3" %>

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
            height: 2087px;
        }
        .auto-style3 {
            width: 385px;
        }
        .auto-style4 {
            height: 537px;
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
            height: 150px;
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
            height: 59px;
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
        19.能够长时间做枯燥、单调的工作。&nbsp; </p>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <p>
                20.符合兴趣的事，干起来劲头十足，否则就不想干。</p>
            <asp:RadioButtonList ID="RadioButtonList3" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
         <p>   21.一点小事就能引起情绪波动。</p>&nbsp; 
            <asp:RadioButtonList ID="RadioButtonList4" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
           <p> 22.讨厌那种需要耐心细致的工作。</p><br />
            <asp:RadioButtonList ID="RadioButtonList5" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <p>23. 与人交往不卑不亢。</p>&nbsp; 
            <asp:RadioButtonList ID="RadioButtonList6" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
          <p>  24. 喜欢热烈的活动。</p> <br />
            <asp:RadioButtonList ID="RadioButtonList7" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <br />
         <p>   25. 喜看感情细腻描写人物内心活动的文学作品。</p> 
            <asp:RadioButtonList ID="RadioButtonList8" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
          <p>  26.工作学习时间长了，常感到厌倦。</p> 
            <br />
            <asp:RadioButtonList ID="RadioButtonList9" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <br />
          <p>  27. 不喜欢长时间谈论一个问题，愿意实际动手干。</p><br />
            <asp:RadioButtonList ID="RadioButtonList10" runat="server" Width="185px">
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
                      <div style="height: 77px; width: 486px">
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
