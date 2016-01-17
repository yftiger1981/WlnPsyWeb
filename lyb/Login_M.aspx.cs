using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data.OleDb ;

namespace MessageBor
{
	/// <summary>
	/// Login 的摘要说明。
	/// </summary>
	public class Login_M : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlTableCell TD_header;
		protected System.Web.UI.WebControls.TextBox TB_username;
		protected System.Web.UI.WebControls.TextBox TB_password;
		protected System.Web.UI.WebControls.Button BT_login;
		protected System.Web.UI.WebControls.Button BT_ease;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD_foot;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!IsPostBack)
				clsMain.WriterHFinfo(TD_header,TD_foot);
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.BT_login.Click += new System.EventHandler(this.BT_login_Click);
			this.BT_ease.Click += new System.EventHandler(this.BT_ease_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void WriterHFinfo()
		{
			TD_header.InnerText ="ASP.NET学习|留言板_IF_V3.2";
			TD_foot.InnerHtml ="<HR width='100%' SIZE='1'><br>版权所有Copyright (c)2005-01 -- 辉辉 ASP.NET 工作窒研发<BR><span title='我的QQ号是254212580' style='CURSOR: hand'><IMG alt='' src='images/oicq.gif'>254212580</span>&nbsp;<IMG title='欢迎联系阿辉' height='16' src='images/emailtofriend.gif' width='16' border='0'><A onmouseover="+"\"window.status='联系阿辉 Asp.Net 知识大全网站';return true;"+"\" title='欢迎联系阿辉' onmouseout="+"\"window.status=''"+"\"href='mailto:zhprogrammer312@163.com'><SPAN style='CURSOR: hand'><FONT style='FONT-SIZE: 9pt; FONT-FAMILY: 宋体' color='#0000ff'>与我联系</FONT></SPAN></A>";
		}

		private void BT_ease_Click(object sender, System.EventArgs e)
		{
			Response.Write ("<script>document.location.href='home.aspx';</script>");
		}

		private void BT_login_Click(object sender, System.EventArgs e)
		{
			if(ISNULL().CompareTo ("YES")==0)
				AdminLogin();
			else
				Response.Write ("<script Language='JavaScript'>alert('请填写完整信息……')</script>");
		}
		private string ISNULL()
		{
			if(TB_username.Text .Trim ().Length ==0 || TB_password.Text .Trim ().Length ==0)
				return "NO";
			else
				return "YES";
		}
		private void AdminLogin()
		{
			//验证/置Session["admin"]="admin"/设置有效时间
			DataView _Cudv = null;
			string _CurrentPage=string.Empty ;
			OleDbConnection _Conn = clsMain.__GetConn ();
			try
			{
                _Cudv = clsMain.__GetDV(_Conn, "SELECT id,UserName,PassWord,adminbs FROM Msg_users Where UserName='" + TB_username.Text.Trim() + "'", "login");
				_Cudv.Sort ="UserName";
				if(_Cudv.Find (TB_username.Text .Trim ())>=0)
				{
					//验密码
					//把密码加密……
					_Cudv.Sort ="PassWord";
					if(_Cudv.Find (TB_password.Text .Trim ())>=0)
					{
						Session["admin"]="admin";
						Session.Timeout =2;
						_CurrentPage = Session["CurrentPage"].ToString ().Trim ();
						Session["username"]=TB_username.Text .Trim ();


						if(_CurrentPage.CompareTo ("ModifyPass.aspx")==0)
							Response.Redirect ("ModifyPass.aspx");
						else
							Response.Redirect ("home.aspx");
					}
					else
					{
						Response.Write ("<script Language='JavaScript'>alert('密码错误……')</script>");
						return;
					}
				}
				else
				{
					Response.Write ("<script Language='JavaScript'>alert('无此用户名……')</script>");
					return;
				}
			}
			catch(OleDbException _ex)
			{
				Session["errors"]=Session["errors"].ToString()+_ex.Message.ToString()+"<br>";
			}
			finally
			{
				if(_Conn!=null) _Conn.Dispose ();
				if(_Cudv!=null) _Cudv.Dispose ();
			}			
		}
        //private OleDbConnection __GetConnObject()
        //{

        //    string __ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath(@"..\databases\#Message DB.mdb");
        //    string __ConnStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + @"D:\wwwroot\zhaohui0312\databases\#Message DB.mdb";
        //    OleDbConnection __OleConn = new OleDbConnection(__ConnStr);
        //    return __OleConn;
        //}
        //private DataView __GetDV(OleDbConnection __Conn,string __SqlStr,string __TableName)
        //{
        //    OleDbDataAdapter	__Pter=null;
        //    DataSet				__DS=	new DataSet();
        //    DataView			__DV=null;
        //    try
        //    {
        //        __Pter=new OleDbDataAdapter(__SqlStr,__Conn);
        //        __Pter.Fill(__DS,__TableName);
        //        __DV=__DS.Tables[__TableName].DefaultView;

        //    }
        //    catch(OleDbException Ex)
        //    {
        //        Session["errors"]=Session["errors"].ToString()+Ex.Message.ToString()+"<br>";
        //    }
        //    finally
        //    {
        //        if(__Pter!=null)		__Pter.Dispose();
        //        if(__DS!=null)			__DS.Dispose();
        //        if(__Conn!=null)		__Conn.Dispose();
        //    }
        //    return __DV;
        //}

        protected void BT_ease_Click1(object sender, EventArgs e)
        {

        }

        protected void BT_login_Click1(object sender, EventArgs e)
        {

        }

        protected void ModifyButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ModifyPass.aspx");
        }
	}
}
