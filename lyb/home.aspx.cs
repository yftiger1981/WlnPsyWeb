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
using System.Text ;
using System.IO ;

namespace MessageBor
{
	/// <summary>
	/// index 的摘要说明。
	/// </summary>
	public class home : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton prev;
		protected System.Web.UI.WebControls.LinkButton next;
		protected System.Web.UI.WebControls.DropDownList gopage;
		protected System.Web.UI.HtmlControls.HtmlTable TABLE_page;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD_header;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD_foot;
		protected System.Web.UI.WebControls.DataGrid Msgbook;
		protected System.Web.UI.HtmlControls.HtmlTableCell jlcount;
		protected System.Web.UI.HtmlControls.HtmlTableCell currentpage;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.HyperLink HyperLink2;
		static DataView _Cudv=null;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			
			if(!IsPostBack)
			{
                Session["pageindex"] = 0;
                Session["CurrentPage"] = 0;
				clsMain.WriterHFinfo(TD_header,TD_foot);
				TABLE_page.Visible =false;	
                _Fill_nr();
               
			}
			this.SmartNavigation=true;
			
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
			this.Msgbook.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.Msgbook_ItemDataBound);
			this.gopage.SelectedIndexChanged += new System.EventHandler(this.gopage_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private DataView __GetDV(OleDbConnection __Conn,string __SqlStr,string __TableName)
		{
			OleDbDataAdapter	__Pter=null;
			DataSet				__DS=	new DataSet();
			DataView			__DV=null;
			try
			{
				__Pter=new OleDbDataAdapter(__SqlStr,__Conn);
				__Pter.Fill(__DS,__TableName);
				__DV=__DS.Tables[__TableName].DefaultView;

			}
			catch(OleDbException Ex)
			{
				Session["errors"]=Session["errors"].ToString()+Ex.Message.ToString()+"<br>";
			}
			finally
			{
				if(__Pter!=null)		__Pter.Dispose();
				if(__DS!=null)			__DS.Dispose();
				if(__Conn!=null)		__Conn.Dispose();
			}
			return __DV;
		}
		private void _Fill_nr()
		{
			OleDbConnection _Conn = clsMain.__GetConn();
			string _SqlString = string.Empty ;
//			_SqlString = "SELECT Msg_book.id, Msg_book.username, Msg_book.xb, Msg_book.E_mail,"+
//							" Msg_book.www, Msg_book.telephone, Msg_book.sj, Msg_book.oicq, Msg_book.dwmc,"+
//							" Msg_book.dwdz, Msg_book.zt, Msg_book.nr, Msg_book.img, Msg_book.ip, Msg_book.lyrq,"+
//							" Msg_book.hfnr, Msg_book.hfrq, Msg_book.hfword, Msg_book.lyword, Msg_book.hfwordbs,"+
//							" Msg_book.lywordbs, Msg_book.adminbs,Msg_Per_Info.jf FROM Msg_book INNER JOIN  Msg_Per_Info "+
//							"ON Msg_book.uid = Msg_Per_Info.userid ORDER BY Msg_book.lyrq DESC";

			_SqlString = "SELECT Msg_book.id, Msg_book.username, Msg_book.xb, Msg_book.E_mail,"+
				" Msg_book.www, Msg_book.telephone, Msg_book.sj, Msg_book.oicq, Msg_book.dwmc,"+
				" Msg_book.dwdz, Msg_book.zt, Msg_book.nr, Msg_book.img, Msg_book.ip, Msg_book.lyrq,"+
				" Msg_book.hfnr, Msg_book.hfrq, Msg_book.hfword, Msg_book.lyword, Msg_book.hfwordbs,"+
				" Msg_book.lywordbs, Msg_book.adminbs FROM Msg_book  ORDER BY Msg_book.lyrq DESC";
			try
			{
				_Cudv=this.__GetDV(_Conn,_SqlString,"Msgbook");
				Msgbook.DataSource = _Cudv;				
				Msgbook.CurrentPageIndex =Int32.Parse (Session["pageindex"].ToString ().Trim ());
				Msgbook.DataBind ();
				if(_Cudv.Count >0)	TABLE_page.Visible =true;
				
			}
			catch(OleDbException _ex)
			{
				Session["errors"]=Session["errors"].ToString()+_ex.Message.ToString()+"<br>";
			}			
			finally
			{
				if(_Conn!=null) _Conn.Dispose ();
				Status();
				Topagesize();
				ControlLinkButton();
			}
		}
	
		private void Status()
		{
			//_Cudv
			/*
			 * 总留言数：
			 * 当前页/总页
			*/
			int	_PageCount=0;
			StringBuilder _PCOUNT = new StringBuilder("");
			try
			{
				_PageCount = Msgbook.PageCount ;				
				jlcount.InnerHtml ="共有:<FONT color='#0000ff'>"+_Cudv.Count+"</FONT>条留言";
				currentpage.InnerHtml ="<FONT color='#0000ff'>"+(Msgbook.CurrentPageIndex+1)+"</FONT>/"+_PageCount+"页";
				for(int i=1;i<=_PageCount;i++)
					_PCOUNT.Append ("第"+i+"页|");
				string[] _PCount = _PCOUNT.ToString ().TrimEnd(new Char[]{'|'}).Split(new Char[]{'|'});			
				gopage.DataSource =_PCount;
				gopage.DataBind ();
			}
			catch(OleDbException ex)
			{
				Session["errors"]=Session["errors"].ToString()+ex.Message.ToString()+"<br>";
			}
			finally
			{				
			}			
		}
		public void PageButtonClick(object sender,System.EventArgs e)
		{
			string _cuid=string.Empty ;
			string _arg = ((LinkButton)sender).CommandName;
			if(_arg.CompareTo ("prev")==0)
			{
				if(Msgbook.CurrentPageIndex >0)
					Msgbook.CurrentPageIndex --;
			}
			if(_arg.CompareTo ("next")==0)
			{
				if(Msgbook.CurrentPageIndex < Msgbook.PageCount -1)
					Msgbook.CurrentPageIndex ++;
			}
			//--------------
			Session["pageindex"]=Msgbook.CurrentPageIndex;
            Session["CurrentPage"] = Msgbook.CurrentPageIndex;
			_Fill_nr();
		}
		public void DeleteFilesButton(object sender,System.EventArgs e)
		{
			string _cuid=string.Empty ;			
				//删除记录
				//判断是否是管理员；
			object obj;
			obj=Session["admin"];
			//obj=Session["groupid"];
			if(obj!=null)
			{
				if(obj.ToString ().CompareTo ("admin")==0)
				{
					_cuid=((LinkButton)sender).CommandArgument.Trim ();
					//DeleteFiles(_cuid);		//删除文件
					DeleteRecord(_cuid);	//删除留言信息
				}
				else
					//Response.Write("你没有删除留言的权限,请与管理员联系！");
					Response.Redirect ("Login_M.aspx");
			}
			else
				Response.Redirect ("Login_M.aspx");
			
		}

		private void gopage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int Pindex=0;
			string _SelectValue=((DropDownList)sender).SelectedItem .Text ;
			if(_SelectValue.Trim ().Length < 3) return;
			_SelectValue=_SelectValue.Substring (1,_SelectValue.Trim ().Length -1);
			_SelectValue= _SelectValue.Substring (0,_SelectValue.Length -1);
			Pindex = Convert.ToInt32 (_SelectValue)-1;
			if(Pindex >=0)
			{
				Msgbook.CurrentPageIndex = Pindex;
				Session["pageindex"]=Msgbook.CurrentPageIndex;
				_Fill_nr();
				if(Pindex < Msgbook.PageCount -1)
					Msgbook.CurrentPageIndex ++;
				else
					Msgbook.CurrentPageIndex =0;

				//---
				
			}
		}
		private void Topagesize()
		{
			string _CurrentPage = "第1页";
			_CurrentPage = "第"+(Msgbook.CurrentPageIndex+1)+"页";
			gopage.SelectedIndex =gopage.Items .IndexOf (gopage.Items .FindByValue (_CurrentPage));
		}

		private void Msgbook_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//HtmlGenericControl
			//HtmlTableCell
			string _lywordbs =string.Empty ;
			string _hfwordbs =string.Empty ;
			string _CuId = string.Empty ;
			HtmlGenericControl _span =null;
			HtmlTableCell _cell = null;
			LinkButton _lb=null;
			HtmlAnchor _a=null;
			
			if(e.Item .ItemIndex > -1)
			{
				_lywordbs=e.Item .Cells[1].Text.Trim ();
				_hfwordbs=e.Item .Cells [2].Text .Trim ();
				_CuId = e.Item .Cells [0].Text .Trim ();

				if(_lywordbs.Trim ().Length ==0||_lywordbs.CompareTo ("0")==0)
				{
					_span=(HtmlGenericControl)e.Item .FindControl("lyrword");
					_span.Visible =false;
				}
				if(_hfwordbs.Trim ().Length ==0||_hfwordbs.CompareTo ("0")==0)//没回复
				{
					_cell=(HtmlTableCell)e.Item .FindControl ("glyhf");
					_cell.InnerText ="";
					_cell=(HtmlTableCell)e.Item .FindControl ("glyhfnr");
					_cell.InnerText ="";
				}
				else if(_hfwordbs.Trim ().Length ==0||_hfwordbs.CompareTo ("0")==0)//没文档
				{
					_span=(HtmlGenericControl)e.Item .FindControl("hfrword");
					_span.InnerText ="";
				}
				
				_lb = (LinkButton)e.Item .FindControl ("lkdelete");
				_lb.CommandArgument =_CuId;	
				
				//----
				_a=(HtmlAnchor)e.Item .FindControl("adminhf");
				_a.HRef="Adminhf.aspx?cuid="+e.Item .Cells [0].Text .Trim ();				
			}
		}
		private void ControlLinkButton()
		{
			prev.Enabled =true;
			next.Enabled =true;

			if(Msgbook.CurrentPageIndex == Msgbook.PageCount - 1)
				next.Enabled=false;
			if(Msgbook.CurrentPageIndex==0)
				prev.Enabled=false;
		}
		private void DeleteRecord(string _Cuid)
		{
			//1.删除留言
			OleDbConnection _Conn =clsMain.__GetConn();
			OleDbCommand _Comm = null;
			OleDbTransaction _Tran=null;
			string _DeleStr="Delete From Msg_book Where id="+_Cuid;

			try
			{
				_Conn.Open ();
				_Tran = _Conn.BeginTransaction ();
				_Comm = new OleDbCommand(_DeleStr,_Conn,_Tran);
				_Comm.ExecuteNonQuery ();
				_Tran.Commit ();
			}
			catch(OleDbException ex)
			{
				_Tran.Rollback ();
				Session["errors"]=Session["errors"].ToString()+ex.Message.ToString()+"<br>";
			}			
			finally
			{
				if(_Conn!=null) _Conn.Dispose ();
				if(_Comm!=null) _Comm.Dispose ();				
				_Fill_nr();
			}
		}
		private void DeleteFiles(string _Cuid)
		{
			//2.删除文档信息
			//取标识；
			string _lyFileName=string.Empty ;
			string _hfFileName=string.Empty ;
			string _FilePath = string.Empty ;
			OleDbDataAdapter	__Pter=null;
			DataSet				_Cuds=	new DataSet();
			__Pter = new OleDbDataAdapter("SELECT lyword,hfword FROM msg_book WHERE id="+_Cuid,clsMain.__GetConn());
			__Pter.Fill(_Cuds,"bs");
			

			if(_Cuds.Tables ["bs"].Rows .Count >0)
			{
				_lyFileName = _Cuds.Tables ["bs"].Rows [0][0].ToString ().Trim ();
				_hfFileName = _Cuds.Tables ["bs"].Rows [0][1].ToString ().Trim ();
				//当文件名存在Delete
				if(_lyFileName.Length >0)
				{
					_FilePath=this.MapPath (_lyFileName);
					if(File.Exists (_FilePath))
						File.Delete (_FilePath);
				}
				if(_hfFileName.Length >0)
				{
					_FilePath=this.MapPath (_hfFileName);
					if(File.Exists (_FilePath))
						File.Delete (_FilePath);
				}
			}
		}
		
	}
}
