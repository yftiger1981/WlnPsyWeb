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
using System.IO ;

namespace MessageBor
{
	/// <summary>
	/// Adminhf 的摘要说明。
	/// </summary>
	public class Adminhf : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlTableCell TD_header;
		protected System.Web.UI.HtmlControls.HtmlTextArea T_hfnr;
		protected System.Web.UI.HtmlControls.HtmlInputFile upFile;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD_foot;
		string _lyfilesname=string.Empty ;
		protected System.Web.UI.WebControls.Button bt_save;
		protected System.Web.UI.WebControls.Button bt_return;
		string _hfwordbs="1";
		object obj,objs;
	static	string _Cuid=string.Empty ;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面

			if(!IsPostBack)
			{ 
				clsMain.WriterHFinfo(TD_header,TD_foot);
				objs=Session["admin"];
				if(objs!=null && objs.ToString ().Trim ().CompareTo ("admin")==0)
				{
					if(objs!=null)
					{
						obj=Request.Params ["cuid"];
						if(obj!=null)
							_Cuid=obj.ToString ();
						if(!UserParameters.IsNumbers(_Cuid))
						{
							Response.Write("<font color='Red' size='9'>出错了……</font>");
							Response.End();
						}
					}
				}
				else
				{
					Response.Write("你没有回复留言的权限,请与管理员联系！");
					Response.Redirect ("login_M.aspx");		
				}
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
			this.bt_save.Click += new System.EventHandler(this.bt_save_Click);
			this.bt_return.Click += new System.EventHandler(this.bt_return_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		private void File_upDownd()//上传文件
		{
			
			_lyfilesname = upFile.PostedFile.FileName;
			_lyfilesname = Path.GetFileName(_lyfilesname);//获得文件名称			
		int	Ll_FileLength = upFile.PostedFile.ContentLength;//获得文件字节大小
			//Ls_FileContentType = upFile.PostedFile.ContentType;//文件类型
			
			if(Ll_FileLength > 2000*1024)
				Response.Write("<script language='JavaScript'>alert('上传的文件太大!')</script>");
			else
			{
				try
				{
					upFile.PostedFile.SaveAs(HttpRuntime.AppDomainAppPath +@"hfword\"+_lyfilesname);				
					_hfwordbs = "2";//再次初始标识
				}
				catch(Exception ex)
				{
					_hfwordbs = "1";//再次初始标识
					Session["errors"]=Session["errors"].ToString()+ex.Message.ToString()+"<br>";
				}						
			}			
		}
		private void SaveUpdateInfo()
		{
			//zhsp_UpdataeMsgInfo
			if(T_hfnr.Value .Trim ().Length ==0)
				return;
			string _hfrq=UserParameters.CurrentDate ();
			string _hfword =@"hfword\"+_lyfilesname;
			string[] MParametes={"@hfnr","@hfrq","@hfword","@hfwordbs"};
			//if(ZhNetLibrary.IsHtml(T_hfnr.Value.Trim ()))
			string[] MPtext={UserParameters.ToNewString2(ZhNetLibrary.FiltrationStr(T_hfnr.Value.Trim ())),_hfrq,_hfword,_hfwordbs};//_Cuid
			string	__SqlStr="UPDATE Msg_book  SET hfnr=@hfnr,hfrq=@hfrq,hfword=@hfword,hfwordbs=@hfwordbs WHERE id=@id";
			try
			{
				OleDbSaveParametersCommand(clsMain.__GetConn(),__SqlStr,MParametes,MPtext);
				Response.Redirect ("home.aspx");
			}
			catch(OleDbException ex)
			{
				Session["errors"]=Session["errors"].ToString()+ex.Message.ToString()+"<br>";
			}
		}

		private void bt_save_Click(object sender, System.EventArgs e)
		{
			//if(upFile.Value .Trim ().Length >0)
				//File_upDownd();
			//-----------
				SaveUpdateInfo();
		}

		private void bt_return_Click(object sender, System.EventArgs e)
		{
			Response.Write ("<script>document.location.href='home.aspx';</script>");
		}

		public static int OleDbSaveParametersCommand(OleDbConnection zhConn,string zhSql,string[] zhParameters,string[] zhText )
		{
			/*
			 * 参数:zhConn连接对象
			 *		zhParameters存储过程参数数组
			 *		zhText参数值数组
			 * 
			 * */
			int row =0;
			OleDbCommand zhComm = new OleDbCommand(zhSql,zhConn);
			//////zhComm.CommandType = CommandType.StoredProcedure;

			for(int p=0; p<zhParameters.Length; p++)
				zhComm.Parameters.Add(zhParameters[p],zhText[p]);
				zhComm.Parameters.Add("@id",Int32.Parse(_Cuid.Trim()));
			try
			{
				if(zhConn.State == ConnectionState.Closed)
					zhConn.Open();
				row = zhComm.ExecuteNonQuery();
			}
			catch(Exception Ex)
			{
				string aaa=Ex.Message.ToString();
				string bb=aaa;
			}
			finally
			{
				if(zhConn!=null)
					zhConn.Dispose();				
			}
			if(row > 0)
				return row;
			else
				return 0;
		}
	}
}
