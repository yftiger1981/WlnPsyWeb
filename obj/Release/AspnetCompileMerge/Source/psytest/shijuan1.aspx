<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shijuan1.aspx.cs" Inherits="WebApplication2.psytest.shijuan1" %>

<!DOCTYPE html>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {

    }
</script>


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
            height: 572px;
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
            height: 417px;
        }
        .auto-style8 {
            width: 683px;
            height: 271px;
        }
        .auto-style9 {
            height: 100px;
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
                          1.做事力求稳妥，不做无把握的事。</p>
                      <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="80px" Width="177px">
                          <asp:ListItem>完全一致</asp:ListItem>
                          <asp:ListItem>比较一致</asp:ListItem>
                          <asp:ListItem>一致与不一致之间</asp:ListItem>
                          <asp:ListItem>不太一致</asp:ListItem>
                          <asp:ListItem>很不一致</asp:ListItem>
                      </asp:RadioButtonList>
                      <p>
                          2.遇到使你生气的事就怒不可遏。 
                      </p>
                      <asp:RadioButtonList ID="RadioButtonList2" runat="server" Width="185px">
                          <asp:ListItem>完全一致</asp:ListItem>
                          <asp:ListItem>比较一致</asp:ListItem>
                          <asp:ListItem>一致与不一致之间</asp:ListItem>
                          <asp:ListItem>不太一致</asp:ListItem>
                          <asp:ListItem>很不一致</asp:ListItem>
                      </asp:RadioButtonList>
                      <p>
                          3.宁肯一人干事，不愿意和很多人在一起。 
                      </p>
                      <asp:RadioButtonList ID="RadioButtonList3" runat="server" Width="185px">
                          <asp:ListItem>完全一致</asp:ListItem>
                          <asp:ListItem>比较一致</asp:ListItem>
                          <asp:ListItem>一致与不一致之间</asp:ListItem>
                          <asp:ListItem>不太一致</asp:ListItem>
                          <asp:ListItem>很不一致</asp:ListItem>
                      </asp:RadioButtonList>
                      <p>
                          4.到一个新环境很快就能适应。 
                      </p>
                      <asp:RadioButtonList ID="RadioButtonList4" runat="server" Width="185px">
                          <asp:ListItem>完全一致</asp:ListItem>
                          <asp:ListItem>比较一致</asp:ListItem>
                          <asp:ListItem>一致与不一致之间</asp:ListItem>
                          <asp:ListItem>不太一致</asp:ListItem>
                          <asp:ListItem>很不一致</asp:ListItem>
                      </asp:RadioButtonList>
                      <p>
                          5.厌恶那些强烈的刺激，如尖叫、噪音、危险镜头等。</p>
                      <asp:RadioButtonList ID="RadioButtonList5" runat="server" Width="185px">
                          <asp:ListItem>完全一致</asp:ListItem>
                          <asp:ListItem>比较一致</asp:ListItem>
                          <asp:ListItem>一致与不一致之间</asp:ListItem>
                          <asp:ListItem>不太一致</asp:ListItem>
                          <asp:ListItem>很不一致</asp:ListItem>
                      </asp:RadioButtonList>
                      <p>
                          6.和人争吵时，总想先发制人，喜欢挑衅。 
                      </p>
                      <asp:RadioButtonList ID="RadioButtonList6" runat="server" Width="185px">
                          <asp:ListItem>完全一致</asp:ListItem>
                          <asp:ListItem>比较一致</asp:ListItem>
                          <asp:ListItem>一致与不一致之间</asp:ListItem>
                          <asp:ListItem>不太一致</asp:ListItem>
                          <asp:ListItem>很不一致</asp:ListItem>
                      </asp:RadioButtonList>
                      <p>
                          7.喜欢安静的环境。</p>
                      <asp:RadioButtonList ID="RadioButtonList7" runat="server" Width="185px">
                          <asp:ListItem>完全一致</asp:ListItem>
                          <asp:ListItem>比较一致</asp:ListItem>
                          <asp:ListItem>一致与不一致之间</asp:ListItem>
                          <asp:ListItem>不太一致</asp:ListItem>
                          <asp:ListItem>很不一致</asp:ListItem>
                      </asp:RadioButtonList>
                      <br />
                      <p>
                          8.善于和人交往。 
                      </p>
                      <asp:RadioButtonList ID="RadioButtonList8" runat="server" Width="185px">
                          <asp:ListItem>完全一致</asp:ListItem>
                          <asp:ListItem>比较一致</asp:ListItem>
                          <asp:ListItem>一致与不一致之间</asp:ListItem>
                          <asp:ListItem>不太一致</asp:ListItem>
                          <asp:ListItem>很不一致</asp:ListItem>
                      </asp:RadioButtonList>
                      <br />
                      <p>
                          9.羡慕那些善于克制自己感情的人。</p>
                      <br />
                      &nbsp;<asp:RadioButtonList ID="RadioButtonList9" runat="server" RepeatLayout="Flow" Width="185px">
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
                  <td class="auto-style5">
                      &nbsp;</td>
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
