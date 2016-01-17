<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shijuan2.aspx.cs" Inherits="WebApplication2.psytest.shijuan2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="StyleSheet.css" rel="stylesheet" />
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
            height: 596px;
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
            height: 254px;
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
            height: 104px;
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

                                  </td>
                          </tr>
                      </table>
                  </td>
              </tr>
              <tr>
                  <td class="auto-style4" colspan="2">
           
    <p>
        10.碰到陌生人觉得很拘束。&nbsp; </p>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <p>
                11.遇到令人气愤的事，能很好的自我克制。</p>
            <asp:RadioButtonList ID="RadioButtonList3" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <br />
          <p>  12.做事总是有旺盛的精力。&nbsp; </p>
            <asp:RadioButtonList ID="RadioButtonList4" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <br />
          <p>  13.遇到问题常常举棋不定，优柔寡断。</p>
            <asp:RadioButtonList ID="RadioButtonList5" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <br />
           <p> 14. 在人群中不觉得过分拘束。</p>&nbsp; 
            <asp:RadioButtonList ID="RadioButtonList6" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
           <p> 15. 情绪高昂时，觉得什么都有趣，情绪低落时，又觉得干什么都没意思。</p><br />
            <asp:RadioButtonList ID="RadioButtonList7" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
         <p>   16. 当注意力集中于一件事物时，别的事很难放到心上。 </p>
            <asp:RadioButtonList ID="RadioButtonList8" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
         <p>   17.理解问题总比别人快。 </p>
            <br />
            <asp:RadioButtonList ID="RadioButtonList9" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
            <br />
        <p>    18. 碰到危险情况时，有极度恐怖感。</p><br />
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
                      <div style="height: 89px; width: 486px">
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

