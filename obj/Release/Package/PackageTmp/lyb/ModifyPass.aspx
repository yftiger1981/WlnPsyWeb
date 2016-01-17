<%@ Page language="c#" Codebehind="ModifyPass.aspx.cs" AutoEventWireup="false" Inherits="MessageBor.ModifyPass" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>留言板-修改管理员密码</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="message.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" cellSpacing="0"
					cellPadding="0" width="100%" border="0" height="100%">
					<TR>
						<TD vAlign="top" align="center">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="666" border="0">
								<TR>
									<TD class="cellheard" id="TD_header" vAlign="middle" align="center" height="36" runat="server"></TD>
								</TR>
								<TR>
									<TD vAlign="middle" align="center" height="200">
										<TABLE id="Table3" style="FONT-WEIGHT: normal; FONT-SIZE: 9pt; FONT-FAMILY: 宋体" cellSpacing="0"
											cellPadding="0" width="300" border="0">
											<TR>
												<TD class="font_cell" width="70" height="22">原密码：</TD>
												<TD width="130" height="22">
													<asp:TextBox id="TB_ypassword" runat="server" Width="120px" MaxLength="30" TextMode="Password"></asp:TextBox></TD>
												<TD class="font_cell" width="100" height="22"></TD>
											</TR>
											<TR>
												<TD class="font_cell" height="22">新密码：</TD>
												<TD height="22">
													<asp:TextBox id="TB_npassword" runat="server" TextMode="Password" Width="120px" MaxLength="30"></asp:TextBox></TD>
												<TD class="font_cell" height="22"></TD>
											</TR>
											<TR>
												<TD class="font_cell" height="22">密码确认：</TD>
												<TD height="22">
													<asp:TextBox id="TB_passwordqr" runat="server" TextMode="Password" Width="120px" MaxLength="30"></asp:TextBox></TD>
												<TD class="font_cell" height="22">
													<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="两次输入不一致" Display="Dynamic" ControlToValidate="TB_passwordqr"
														ControlToCompare="TB_npassword"></asp:CompareValidator></TD>
											</TR>
											<TR>
												<TD height="32"></TD>
												<TD height="32" align="center">
													<asp:Button id="BT_save" runat="server" Text="保存" CssClass="Button"></asp:Button>&nbsp;
													<asp:Button id="BT_ease" runat="server" Text="取消" CssClass="Button"></asp:Button></TD>
												<TD height="32"></TD>
											</TR>
										</TABLE>
										&nbsp;&nbsp;&nbsp;
										<asp:HyperLink id="HL_login" runat="server" Font-Size="9pt" ForeColor="Blue" NavigateUrl="Login_M.aspx"
											Visible="False">重新登录</asp:HyperLink>
									</TD>
								</TR>
								<TR>
									<TD class="cellfoot" id="TD_foot" vAlign="middle" align="center" height="30" runat="server"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
