<%@ Page language="c#" Codebehind="Adminhf.aspx.cs" AutoEventWireup="false" Inherits="MessageBor.Adminhf" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>留言板-管理员回复</title>
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
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" border="0">
								<TR>
									<TD id="TD_header" height="100" runat="server" class="cellheard"></TD>
								</TR>
								<TR>
									<TD>
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="780" border="0">
											<TR>
												<TD class="cellfoot" height="20" width="100"></TD>
												<TD class="cellfoot" height="20" width="680"></TD>
											</TR>
											<TR>
												<TD height="160" width="100" style="FONT-WEIGHT: normal; FONT-SIZE: 9pt; FONT-FAMILY: 宋体"
													vAlign="top" align="right">内容：</TD>
												<TD height="160" width="680" style="FONT-WEIGHT: normal; FONT-SIZE: 9pt; FONT-FAMILY: 宋体"><TEXTAREA class="TextBoxs" id="T_hfnr" style="WIDTH: 672px; HEIGHT: 328px" name="TEXTAREA1"
														rows="20" cols="81" runat="server">
													</TEXTAREA></TD>
											</TR>
											<TR>
												<TD height="40" width="100" style="FONT-WEIGHT: normal; FONT-SIZE: 9pt; FONT-FAMILY: 宋体"
													align="right">附件：</TD>
												<TD height="40" width="680" style="FONT-WEIGHT: normal; FONT-SIZE: 9pt; FONT-FAMILY: 宋体"><INPUT class="TextBoxs" id="upFile" style="WIDTH: 568px; HEIGHT: 22px" type="file" size="75"
														name="File1" runat="server" disabled></TD>
											</TR>
											<TR>
												<TD class="cellfoot" height="36" width="100"></TD>
												<TD class="cellfoot" height="36" width="680">
													<asp:Button id="bt_save" runat="server" CssClass="Button" Text="保存"></asp:Button>&nbsp;
													<asp:Button id="bt_return" runat="server" CssClass="Button" Text="返回"></asp:Button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD id="TD_foot" height="30" runat="server" class="cellfoot"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
	</body>
</HTML>
