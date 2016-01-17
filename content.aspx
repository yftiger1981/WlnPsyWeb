<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="content.aspx.cs" Inherits="WebApplication2.adultsystem.content" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="SHORTCUT ICON" href="Imagescom/scico.gif" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>内容展示</title>
    <style type="text/css">
        #form1 {
            text-align: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center"> 
        <asp:Label ID="titlelabel" runat="server" style="text-align: center"></asp:Label>
    </div>
        <br/>
        <div style="text-align:center">
            <asp:Literal ID="contentLiteral" runat="server"></asp:Literal>
        </div>
         <br/>
         <div style="text-align:right">
            <asp:Literal ID="authorLiteral" runat="server"></asp:Literal>
        </div>
         <br/>
        <asp:Literal ID="timeLiteral" runat="server"></asp:Literal>
         <br/>
         <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上一页" />
        <br/>
        <asp:Label ID="Label1" runat="server"></asp:Label>
    </form>
   
</body>
</html>
