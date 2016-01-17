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
using System.Data .SqlClient;

namespace MessageBor
{
	/// <summary>
	/// ModifyPass 的摘要说明。
	/// </summary>
	public class ModifyPass : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlTableCell TD_header;
		protected System.Web.UI.WebControls.Button BT_save;
		protected System.Web.UI.WebControls.Button BT_ease;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		protected System.Web.UI.WebControls.TextBox TB_ypassword;
		protected System.Web.UI.WebControls.TextBox TB_npassword;
		protected System.Web.UI.WebControls.TextBox TB_passwordqr;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD_foot;
		protected System.Web.UI.WebControls.HyperLink HL_login;
		object objs;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!IsPostBack)
			{ 
				clsMain.WriterHFinfo(TD_header,TD_foot);
				Session["CurrentPage"]="ModifyPass.aspx";
				objs=Session["admin"];
				if(objs!=null && objs.ToString ().Trim ().CompareTo ("admin")==0)
				{
				}
				else
					Response.Redirect ("Login_M.aspx");
			}
			
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
			this.BT_save.Click += new System.EventHandler(this.BT_save_Click);
			this.BT_ease.Click += new System.EventHandler(this.BT_ease_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		private void BT_ease_Click(object sender, System.EventArgs e)
		{
			Response.Redirect ("home.aspx");
		}
		private void Save_ModifyPassInfo()
		{
			string _UserName=string.Empty ;
			string _SqlStr=string.Empty ;
			
			if(TB_ypassword.Text .Trim().Length ==0 || TB_npassword.Text .Trim ().Length ==0)
				return;
			_UserName = Session["username"].ToString ();
			SqlConnection _conn=UserParameters.connection();
			try
			{
				_SqlStr="SELECT count(id) FROM Msg_users WHERE UserName='"+_UserName+"'";
				if(Convert.ToInt32 (UserParameters.dataset (_SqlStr,"login").Tables ["login"].Rows[0][0].ToString ().Trim ()) == 0)
				{
					HL_login.Visible =true;
					Response.Write ("<script Language='JavaScript'>alert('当前管理员用户名不正确，请您重新登录！')</script>");
					return;
				}
				_SqlStr="SELECT count(id) FROM Msg_users WHERE UserName='"+_UserName+"' AND PassWord='"+TB_ypassword.Text .Trim ()+"'";
				
				if(Convert.ToInt32 (UserParameters.dataset (_SqlStr,"yz").Tables ["yz"].Rows[0][0].ToString ().Trim ()) ==0)
				{
					Response.Write ("<script Language='JavaScript'>alert('当前管理员密码不正确，请您重新登录！')</script>");
					return;
				}
			//zhsp_ModifyMsgBoardPassWord
			
			
				string[] Ps={"@username","@password"};
				string[] Ts={_UserName,TB_npassword.Text .Trim ()};
				UserParameters.SaveParametersCommand (_conn,"zhsp_ModifyMsgBoardPassWord",Ps,Ts);
				Response.Write ("<script Language='JavaScript'>alert('当前管理员密码修改成功！')</script>");
				Response.Redirect ("home.aspx");
			}
			catch(Exception ex)
			{
				Session["errors"]=Session["errors"].ToString()+ex.Message.ToString()+"<br>";
			}
			finally
			{
				if(_conn!=null) _conn.Dispose ();
			}

		}

		private void BT_save_Click(object sender, System.EventArgs e)
		{
			Save_ModifyPassInfo();
		}
	}
}
