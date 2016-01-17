<%@ Page language="c#" Codebehind="Addmsg.aspx.cs" AutoEventWireup="false" Inherits="MessageBor.Addmsg" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>留言板-增加留言</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="message.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" onload="document.myform.TB_username.focus();">
		<form id="myform" method="post" runat="server">
			<FONT face="宋体">
				<TABLE id="Table1" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 8px" height="100%"
					cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD vAlign="top" align="center">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" border="0">
								<TR>
									<TD class="cellheard" id="TD_header" height="36" runat="server"></TD>
								</TR>
								<TR>
									<TD vAlign="top" align="center" height="460">
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="760" border="0">
											<TR>
												<TD width="660">
													<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="660" border="0">
														<TR>
															<TD class="Gcell17" width="100"><FONT color="#ff0033">*</FONT>昵称：</TD>
															<TD class="Gcell18" width="560"><asp:textbox id="TB_username" name="TB_username" runat="server" Width="120px" CssClass="TextBoxs"
																	MaxLength="30"></asp:textbox>&nbsp; 性别：
																<asp:dropdownlist id="DDL_xb" runat="server" Width="50px">
																	<asp:ListItem Value="男">男</asp:ListItem>
																	<asp:ListItem Value="女">女</asp:ListItem>
																</asp:dropdownlist><asp:regularexpressionvalidator id="username" runat="server" Display="Dynamic" ValidationExpression="[^~`!@#$%\\\^\(\)\[\]\{\}&amp;*+=|'&quot;;:/?><,]{1,30}"
																	ControlToValidate="TB_username" ErrorMessage="用户名错！"></asp:regularexpressionvalidator></TD>
														</TR>
														<TR style="DISPLAY:none">
															<TD class="Gcell17" width="100">电话：</TD>
															<TD class="Gcell18" width="300"><asp:textbox id="TB_dh" runat="server" Width="120px" CssClass="TextBoxs"></asp:textbox>&nbsp;
																<asp:regularexpressionvalidator id="dh" runat="server" Display="Dynamic" ValidationExpression="((\(\d{3}\)|\d{3}-)?\d{8})|([0-9]{3,4}-[0-9]{6,9})"
																	ControlToValidate="TB_dh" ErrorMessage="输入错误！"></asp:regularexpressionvalidator></TD>
														</TR>
														<TR>
															<TD class="Gcell17" width="100">手机：</TD>
															<TD class="Gcell18" width="300"><asp:textbox id="TB_sj" runat="server" Width="120px" CssClass="TextBoxs"></asp:textbox>&nbsp;
																<asp:regularexpressionvalidator id="sj" runat="server" Display="Dynamic" ValidationExpression="[\d]{10,12}" ControlToValidate="TB_sj"
																	ErrorMessage="输入错误！"></asp:regularexpressionvalidator></TD>
														</TR>
														<TR>
															<TD class="Gcell17" width="100">E_mail:</TD>
															<TD class="Gcell18" width="300"><asp:textbox id="TB_email" runat="server" Width="230px" CssClass="TextBoxs"></asp:textbox><asp:regularexpressionvalidator id="email" runat="server" Display="Dynamic" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
																	ControlToValidate="TB_email" ErrorMessage="输入错误！"></asp:regularexpressionvalidator></TD>
														</TR>
														<TR>
															<TD class="Gcell17" width="100">OICQ:</TD>
															<TD class="Gcell18" width="300"><asp:textbox id="TB_oicq" runat="server" Width="120px" CssClass="TextBoxs"></asp:textbox>&nbsp;
																<asp:regularexpressionvalidator id="icq" runat="server" Display="Dynamic" ValidationExpression="[\d]{6,12}" ControlToValidate="TB_oicq"
																	ErrorMessage="输入错误！"></asp:regularexpressionvalidator></TD>
														</TR>
														<TR>
															<TD class="Gcell17" width="100">网站：</TD>
															<TD class="Gcell18" width="300"><asp:textbox id="TB_www" runat="server" Width="230px" CssClass="TextBoxs"></asp:textbox><asp:regularexpressionvalidator id="ww" runat="server" Display="Dynamic" ValidationExpression="http://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"
																	ControlToValidate="TB_www" ErrorMessage="输入错误！"></asp:regularexpressionvalidator></TD>
														</TR>
														<TR style="DISPLAY:none">
															<TD class="Gcell17" width="100">单位名称：</TD>
															<TD class="Gcell18" width="300"><asp:textbox id="TB_dwmc" runat="server" Width="448px" CssClass="TextBoxs" MaxLength="125"></asp:textbox></TD>
														</TR>
														<TR style="DISPLAY:none">
															<TD class="Gcell17" width="100">单位地址：</TD>
															<TD class="Gcell18" width="300"><asp:textbox id="TB_dwdz" runat="server" Width="448px" CssClass="TextBoxs" MaxLength="125"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="Gcell17" width="100"><FONT color="#ff0000">*</FONT>主题：</TD>
															<TD class="Gcell18" width="300"><asp:textbox id="TB_zt" runat="server" Width="448px" CssClass="TextBoxs" MaxLength="50"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="Gcell17" width="100"><FONT color="#ff0033">*</FONT>内容：</TD>
															<TD class="Gcell18" width="300"><asp:textbox id="TB_nr" runat="server" Width="560px" CssClass="TextBoxs" Height="196px" TextMode="MultiLine"></asp:textbox></TD>
														</TR>
														<TR>
															<TD class="Gcell17" width="100">附件：</TD>
															<TD class="Gcell18" width="300"><INPUT style="WIDTH: 496px; HEIGHT: 22px" type="file" size="63" id="upFile" name="File1"
																	runat="server" disabled></TD>
														</TR>
														<TR>
															<TD class="Gcell17" width="100"></TD>
															<TD class="Gcell18" width="300"></TD>
														</TR>
													</TABLE>
												</TD>
												<TD vAlign="top" align="center" width="100">
													<P><BR>
														<IMG id="IMG1" style="WIDTH: 60px; HEIGHT: 60px" alt="" src="" runat="server"></P>
													<P>&nbsp;</P>
													<P><br>
														<asp:dropdownlist id="DDL_img" runat="server" Width="100px" AutoPostBack="True"></asp:dropdownlist></P>
												</TD>
											</TR>
											<TR>
												<TD vAlign="middle" align="center" width="560" height="30"><asp:button id="Button1" runat="server" CssClass="Button" Text="提交"></asp:button>&nbsp;<asp:button id="Button2" runat="server" CssClass="Button" Text="重填写"></asp:button>&nbsp;<asp:button id="Button3" runat="server" CssClass="Button" Text="返回"></asp:button></TD>
												<TD width="100" height="30"></TD>
											</TR>
											<TR>
												<TD width="400"><INPUT id="T_Ip" style="VISIBILITY: hidden" type="text" name="T_Ip" runat="server">
												</TD>
												<TD width="100"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD class="cellfoot" id="TD_foot" height="30" runat="server"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
				</TABLE>
			</FONT>
		</form>
		<script language="JavaScript">
			function __KeyDown()
			{
				if(event.keyCode==13) event.keyCode=9;
			}
		</script>
	</body>
</HTML>
