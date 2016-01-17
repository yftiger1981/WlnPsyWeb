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

namespace MessageBor.MessageBoard
{
	/// <summary>
	/// download 的摘要说明。
	/// </summary>
	public class download : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!IsPostBack)
			{
				string __Path=string.Empty;
				__Path = Request.Params["path"].ToString().Trim();
				//string ss=Request.MapPath("")+"\\"+"lyword\\20050523221539202.jpg";
				System.IO.FileInfo file=new System.IO.FileInfo(Request.MapPath("")+"\\"+__Path);
				Response.Clear();
				Response.Charset="GB2312";
				Response.ContentEncoding=System.Text.Encoding.UTF8;
				Response.AddHeader("Content-Disposition","attachment;filename="+Server.UrlEncode(file.Name));
				Response.AddHeader("Content-Length",file.Length.ToString());
				Response.ContentType="application/octet-stream";
				Response.WriteFile(file.FullName);
				Response.End();
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
