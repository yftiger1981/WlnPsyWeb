<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelperRegister.aspx.cs" Inherits="WebApplication2.Helper" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>求助者注册页面</title>
    <style type="text/css">
        .auto-style1 {
            width: 281px;
            height:30px;
        }
        .auto-style3 {
            height: 25px;
        }
        .auto-style4 {
            width: 464px;
        }
        .auto-style5 {
            height: 24px;
        }
        .auto-style6 {
            height: 24px;
            width: 464px;
        }
        .auto-style65 {
            width: 43%;
        }
        .auto-style69 {
            width: 371px;
        }
        .auto-style70 {
            width: 43%;
            height: 39px;
            margin-right: 0px;
        }
        .auto-style71 {
            height: 39px;
            width: 371px;
        }
        .auto-style72 {
            width: 43%;
            height: 42px;
            margin-right: 0px;
        }
        .auto-style73 {
            width: 371px;
            height: 42px;
        }
        .auto-style74 {
            width: 43%;
            height: 38px;
            margin-right: 0px;
        }
        .auto-style75 {
            height: 38px;
            width: 371px;
        }
        .auto-style76 {
            width: 43%;
            height: 37px;
            margin-right: 0px;
        }
        .auto-style77 {
            height: 37px;
            width: 371px;
        }
        .auto-style78 {
            width: 43%;
            height: 40px;
            margin-right: 0px;
        }
        .auto-style79 {
            width: 371px;
            height: 40px;
        }
        .auto-style80 {
            width: 43%;
            height: 35px;
            margin-right: 0px;
        }
        .auto-style81 {
            width: 371px;
            height: 35px;
        }
    </style>
    <link href="../style.css" rel="stylesheet" type="text/css" />
    <link href="../webcss.css" rel="stylesheet"  type="text/css"/>
</head>
<body>
     <table class="auto-style1">
                <tr>
                    <td class="auto-style3" colspan="3"  style='background:url("Imagescom/qiuzhuzhezhuce.jpg") no-repeat #cccccc;'><span class="auto-style19">心灵之家SOULCASTLE  求助者注册页面</span></td>
                </tr>
     </table>
    
    <form id="form1" runat="server">
        <div>
    你是为谁求助：
        <asp:RadioButtonList ID="helpRadioButtonList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True">
            <asp:ListItem>自己</asp:ListItem>
            <asp:ListItem>孩子</asp:ListItem>
            <asp:ListItem>他人</asp:ListItem>
        </asp:RadioButtonList>
<table runat="server" id="adulthelp" visible="false">
                <tr>
                  <th colspan="2" scope="col">请填写下列表单</th>
                </tr>
                <tr>
                  <td class="auto-style65">请输入求助者所属的人格特性:</td>
                 <td class="auto-style69">
                     <asp:RadioButtonList ID="personRadioButtonList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                         <asp:ListItem Selected="True">多血质</asp:ListItem>
                         <asp:ListItem>抑郁质</asp:ListItem>
                         <asp:ListItem>胆汁质</asp:ListItem>
                         <asp:ListItem>黏液质</asp:ListItem>
                     </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                  <td>求助者的年龄:</td>
                     <td class="auto-style69" >
                         <asp:TextBox ID="ageTextBox" runat="server"></asp:TextBox>
                         <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="ageTextBox" ErrorMessage="年龄不在范围内" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                  <td class="auto-style70">求助者的父母文化程度: </td>
                  <td class="auto-style71">
                      <asp:RadioButtonList ID="pareduRadioButtonList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                          <asp:ListItem Selected="True">大学以上</asp:ListItem>
                          <asp:ListItem>大学</asp:ListItem>
                          <asp:ListItem>中学</asp:ListItem>
                          <asp:ListItem>小学</asp:ListItem>
                      </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                  <td class="auto-style72">求助者的文化程度:</td>
                  <td class="auto-style73">
                      <asp:RadioButtonList ID="selduRadioButtonList0" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                          <asp:ListItem Selected="True">大学以上</asp:ListItem>
                          <asp:ListItem>大学</asp:ListItem>
                          <asp:ListItem>中学</asp:ListItem>
                          <asp:ListItem>小学</asp:ListItem>
                      </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                  <td class="auto-style74">求助者对心理咨询了解的情况：</td>
                  <td class="auto-style75">
                      <asp:RadioButtonList ID="PsykonwRadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                          <asp:ListItem Selected="True">不了解</asp:ListItem>
                          <asp:ListItem>较为了解</asp:ListItem>
                          <asp:ListItem>很了解</asp:ListItem>
                      </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                  <td >发现目前问题时间有多长：</td>
                  <td class="auto-style69">
                      <asp:RadioButtonList ID="ProlenRadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                          <asp:ListItem Selected="True">一周左右</asp:ListItem>
                          <asp:ListItem>一个月左右</asp:ListItem>
                          <asp:ListItem>半年左右</asp:ListItem>
                          <asp:ListItem>一年以上</asp:ListItem>
                      </asp:RadioButtonList>
                   </td>
                </tr>
                <tr>
                  <td class="auto-style65">求助者目前的身体状态：</td>
                  <td class="auto-style69">
                      <asp:RadioButtonList ID="BodycondiRadioButtonList2" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                          <asp:ListItem Selected="True">体弱多病</asp:ListItem>
                          <asp:ListItem>身体健康</asp:ListItem>
                      </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                  <td class="auto-style76">求助者目前的工作状态：</td>
                  <td class="auto-style77">
                      <asp:RadioButtonList ID="WorkRadioButton" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                          <asp:ListItem Selected="True">厌烦工作</asp:ListItem>
                          <asp:ListItem>照常工作</asp:ListItem>
                          <asp:ListItem>热爱工作</asp:ListItem>
                      </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                  <td class="auto-style78">求助者希望问题得到解决的程度：</td>
                  <td class="auto-style79">
                      <asp:RadioButtonList ID="prosolvRadioButtonList1" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                          <asp:ListItem Selected="True">暂时解决</asp:ListItem>
                          <asp:ListItem>彻底解决</asp:ListItem>
                      </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                  <td class="auto-style80">求助者是否未告知家人前来:</td>
                  <td class="auto-style81">
                      <asp:RadioButtonList ID="tellparRadioButtonList" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                          <asp:ListItem Selected="True">是</asp:ListItem>
                          <asp:ListItem>否</asp:ListItem>
                      </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                  <td class="auto-style74">求助者的问题是否第一次出现：</td>
                  <td class="auto-style75">
                      <asp:RadioButtonList ID="firstappRadioButtonList3" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                          <asp:ListItem Selected="True">是</asp:ListItem>
                          <asp:ListItem>否</asp:ListItem>
                      </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                <th scope="col" style="text-align: left" class="auto-style65">
                    <asp:Button ID="subButton" runat="server" Text="提交"   OnClick="subButton_Click" CssClass="button"/>
                    </th>
                </tr>
              </table> 
        <table runat="server" id="childtable" visible="false">
            <tr>
                <th colspan="2" scope="col">请填写下列表单</th>
                </tr>
            <tr>
                <td> 请输入你孩子所属的人格特性:</td>
                    <td> <asp:RadioButtonList ID="personRadioButtonList0" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                         <asp:ListItem Selected="True">多血质</asp:ListItem>
                         <asp:ListItem>抑郁质</asp:ListItem>
                         <asp:ListItem>胆汁质</asp:ListItem>
                         <asp:ListItem>黏液质</asp:ListItem>
                     </asp:RadioButtonList>
                       </td>
              </tr>
              <tr>
                <td >选择您孩子的出生年份:</td>
                <td class="auto-style4">
                         <asp:TextBox ID="ageTextBox0" runat="server"></asp:TextBox>
                         <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="ageTextBox" ErrorMessage="年龄不在范围内" MaximumValue="100" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                    </td>
              </tr>
              <tr>
                <td class="auto-style5">您孩子的性别:</td>
                <td class="auto-style6">
                男
                <input type="radio"  name="genderradiobutton" id="mailradiobutton" value="男" runat="server" checked="true" />
                女
                <input type="radio" name="genderradiobutton" value="女" />
                </td>
              </tr>
              <tr>
                  <td>孩子身体状况</td>
                  <td class="auto-style4"> 
                      <asp:RadioButtonList ID="BodycondiRadioButtonList3" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                          <asp:ListItem Selected="True">体弱多病</asp:ListItem>
                          <asp:ListItem>身体健康</asp:ListItem>
                      </asp:RadioButtonList>
                  </td>            
              </tr>
            <tr>
                <td>您对心理咨询了解情况:</td>
                <td class="auto-style4">
                      <asp:RadioButtonList ID="PsykonwRadioButtonList2" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                          <asp:ListItem Selected="True">不了解</asp:ListItem>
                          <asp:ListItem>较为了解</asp:ListItem>
                          <asp:ListItem>很了解</asp:ListItem>
                      </asp:RadioButtonList>
                    </td>
              </tr>
              <tr>
                <td>您对孩子问题关心程度:</td>
               <td class="auto-style4">
                      <asp:RadioButtonList ID="careRadioButtonList3" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                          <asp:ListItem Selected="True">很少关心</asp:ListItem>
                          <asp:ListItem>较为关心</asp:ListItem>
                          <asp:ListItem>很关心</asp:ListItem>
                      </asp:RadioButtonList>
                    </td>
              </tr>
              <tr>
                <td class="auto-style5">您是否一人和孩子居住:</td>
                <td class="auto-style6" >是
                    <input type="radio" name="livetogether" value="是" checked="true" id="livetogether" runat="server" />
                    否
                    <input type="radio" name="livetogether" value="否"  id="nolivetogether" runat="server"/></td>
                </tr>
              <tr>
                <td>您是否常年与孩子分开:</td>
                <td class="auto-style4">是
                    <input type="radio" name="seprate" value="是" checked="true" runat="server" id="sepratebychild"/>
                否
                    <input type="radio" name="seprate" value="否" runat="server" id="nosepratebychild"/>
              </td>
              </tr>
              <tr>
                <td>您的孩子由年老父母照看:</td>
                <td class="auto-style4">
                    是
                    <input type="radio" name="carebypar" value="是" checked="true" runat="server" id="carebyold"/>
                否
                    <input type="radio" name="carebypar" value="否" runat="server" id="nocarebyold"/>
                </td>
              </tr>
              <tr>
                <td class="auto-style40">
                    <asp:Button ID="subButton1" runat="server" Text="提交" OnClick="subButton1_Click" cssclass="button"/>
                 </td>
              </tr>
            </table>
    </div>
        <asp:Label ID="errLabel1" runat="server"></asp:Label>
        <br />
        <br />
      <h2> <a href="../soulcastlefrontpage.html"> 回首页</a></h2>
    </form>
        <table>         
        <tr style="background-color: #D6D4AB" >
         <td>心灵之家SOULCASTLE求助者注册页面为心灵之家科技有限公司soulcastle 版权所有</td>
        </tr>
 </table>
</body>
</html>
