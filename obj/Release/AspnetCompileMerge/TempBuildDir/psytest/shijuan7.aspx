<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shijuan7.aspx.cs" Inherits="WebApplication2.psytest.shijuan7" %>

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
            height: 572px;
        }
        .auto-style5 {
            width: 268435456px;
            height: 76px;
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
        .auto-style10 {
            height: 618px;
        }
        .auto-style11 {
            width: 268435488px;
            height: 76px;
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
                  <td class="auto-style9" colspan="3">
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
                  <td class="auto-style4" colspan="3">       
      <p> 55. 生活有规律，很少违反作息制度。</p>
              <br />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="185px" RepeatLayout="Flow">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>

  <p> 56.在多数情况下情绪是乐观的。</p>
            <asp:RadioButtonList ID="RadioButtonList2" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>

 <p>
                57.对工作学习、事业有很高的热情。</p>
            <asp:RadioButtonList ID="RadioButtonList3" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
<p>
    
                58.宁愿侃侃而谈，不愿窃窃私语。 </p>
            <asp:RadioButtonList ID="RadioButtonList4" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
 <p>
                59.能够很快的忘记那些不愉快的事情。 </p>
            <asp:RadioButtonList ID="RadioButtonList5" runat="server" Width="185px">
                <asp:ListItem>完全一致</asp:ListItem>
                <asp:ListItem>比较一致</asp:ListItem>
                <asp:ListItem>一致与不一致之间</asp:ListItem>
                <asp:ListItem>不太一致</asp:ListItem>
                <asp:ListItem>很不一致</asp:ListItem>
            </asp:RadioButtonList>
 <p>60.和周围的人的关系总是相处得不好。 </p>
            <asp:RadioButtonList ID="RadioButtonList6" runat="server" Width="185px">
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
                  <td rowspan="2" >
                      <div style="height: 65px; width: 326px">
	                </div></td>
                  <td class="auto-style10" colspan="2">
                      </td>
              </tr>              
              <tr>
                  <td class="auto-style5">
                      <asp:ImageButton ID="ImageButtonUndo" runat="server" CssClass="imagebutton" Height="71px" ImageUrl="~/Images/testtjfinished_01.gif" OnClick="ImageButtonUndo_Click" Width="131px" />
	                </td>
                  <td class="auto-style11">
                      <asp:ImageButton ID="ImageButton2" runat="server" CssClass="imagebutton" Height="71px" ImageUrl="~/Images/testtjfinished_02.gif" OnClick="ImageButton1_Click" Width="131px" />
	                </td>
              </tr>              
                   </table>
               </form>
          </div>
       
          </div>
	
</body>
</html>
