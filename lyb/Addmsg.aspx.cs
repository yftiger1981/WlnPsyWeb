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
using System.Data.OleDb;
using System.IO ;
using System.Text ;

namespace MessageBor
{
	/// <summary>
	/// Addmsg 的摘要说明。
	/// </summary>
	public class Addmsg : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlTableCell TD_header;
		protected System.Web.UI.HtmlControls.HtmlImage IMG1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.DropDownList DDL_img;
		protected System.Web.UI.WebControls.DropDownList DDL_xb;
		protected System.Web.UI.HtmlControls.HtmlInputText T_Ip;
		protected System.Web.UI.WebControls.TextBox TB_username;
		protected System.Web.UI.WebControls.TextBox TB_dh;
		protected System.Web.UI.WebControls.TextBox TB_sj;
		protected System.Web.UI.WebControls.TextBox TB_email;
		protected System.Web.UI.WebControls.TextBox TB_oicq;
		protected System.Web.UI.WebControls.TextBox TB_www;
		protected System.Web.UI.WebControls.TextBox TB_dwmc;
		protected System.Web.UI.WebControls.TextBox TB_dwdz;
		protected System.Web.UI.WebControls.TextBox TB_zt;
		protected System.Web.UI.WebControls.TextBox TB_nr;
		protected System.Web.UI.WebControls.RegularExpressionValidator username;
		protected System.Web.UI.WebControls.RegularExpressionValidator dh;
		protected System.Web.UI.WebControls.RegularExpressionValidator sj;
		protected System.Web.UI.WebControls.RegularExpressionValidator email;
		protected System.Web.UI.WebControls.RegularExpressionValidator icq;
		protected System.Web.UI.WebControls.RegularExpressionValidator ww;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD_foot;
		//----------------
		string _lywordbs="0";
		protected System.Web.UI.HtmlControls.HtmlInputFile upFile;
		string _lyfilesname="";
		int Ll_FileLength = 0;
        static int userid=0;
		//int i=0;
		string Ls_FileContentType=null;
		//---------------------
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面			
			__AddEvent();
			T_Ip.Value =Request.UserHostAddress;
			if(!IsPostBack)
			{
				clsMain.WriterHFinfo(TD_header,TD_foot);
				GetFiles();
				GetImgFilePath();
                //TB_username.Text=Session["username"].ToString();
                userid++;
                Session["userid"] = userid;
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
			this.DDL_img.SelectedIndexChanged += new System.EventHandler(this.DDL_img_SelectedIndexChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		private void GetFiles()
		{
			string _FilName=string.Empty ;
			try
			{
				string _CuPath = this.MapPath (@"touxinag");				
				string[] _CuImgFiles=Directory.GetFiles(_CuPath,"*.gif");
				for(int i=0;i<_CuImgFiles.Length;i++)
					_CuImgFiles[i]=UserParameters.GetString (_CuImgFiles[i],@"\");
				DDL_img.DataSource =_CuImgFiles;
				DDL_img.DataBind();
			}
			catch(Exception ex)
			{
				Session["errors"]=Session["errors"].ToString()+ex.Message.ToString()+"<br>";
			}
		}
		private void GetImgFilePath()
		{
			IMG1.Src =@"touxinag\"+DDL_img.SelectedValue;
		}

		private void DDL_img_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			IMG1.Src =@"touxinag\"+DDL_img.SelectedValue;
		}
		private string IsNull()
		{
			if(TB_username.Text.Trim ().Length ==0 || TB_zt.Text .Trim ().Length ==0 || TB_nr.Text .Trim ().Length ==0)
				return "NO";
			else
				return "YES";
		}
		private void _SaveMsgInfo()
		{
			string[] Parameters	={"@username", "@xb", "@E_mail", "@www", "@telephone", "@sj", "@oicq", "@dwmc", "@dwdz", "@zt", "@nr", "@img", "@ip", "@lyrq", "@lyword", "@hfwordbs", "@lywordbs","@userid"};
			string _lyrq=UserParameters.CurrentDate ();
			//发送成功留言为1，不成功为0。
//			if(upFile.PostedFile.FileName.Trim ().Length >0)				
//				File_upDownd();//上传文件
           
			string[] Ptext	={TB_username.Text.Trim(),DDL_xb.SelectedValue,TB_email.Text.Trim (),TB_www.Text .Trim (),TB_dh.Text .Trim (),TB_sj.Text ,TB_oicq.Text ,TB_dwmc.Text ,TB_dwdz.Text ,TB_zt.Text ,UserParameters.ToNewString2(ZhNetLibrary.FiltrationStr(TB_nr.Text.Trim())) ,@"touxinag\"+DDL_img.SelectedValue ,T_Ip.Value,_lyrq ,@"lyword\"+_lyfilesname,"0",_lywordbs,Session["userid"].ToString().Trim()};
			_lywordbs = "0";//再次初始标识
			//--save
			string __SqlStr="INSERT INTO Msg_book(username, xb, E_mail, www, telephone, sj, oicq, dwmc, dwdz, zt, nr, img, ip, lyrq, lyword, hfwordbs, lywordbs,uid) VALUES (@username, @xb, @E_mail, @www, @telephone, @sj, @oicq, @dwmc, @dwdz, @zt, @nr, @img, @ip, @lyrq, @lyword, @hfwordbs, @lywordbs,@userid)";
			try
			{
				UserParameters.OleDbSaveParametersCommand(clsMain.__GetConn(),__SqlStr,Parameters,Ptext);
			}
			catch(OleDbException ex)
			{
				Session["errors"]=Session["errors"].ToString()+ex.Message.ToString()+"<br>";
			}

			//if(i>0)
				//Response.Write ("<script Language='JavaScript'>alert('保存成功！')</script>");
			//else
				//Response.Write ("<script Language='JavaScript'>alert('保存失败！')</script>");
		}
		private void File_upDownd()
		{
			
			_lyfilesname = upFile.PostedFile.FileName;
			_lyfilesname = Path.GetFileName(_lyfilesname);//获得文件名称			
			Ll_FileLength = upFile.PostedFile.ContentLength;//获得文件字节大小
			Ls_FileContentType = upFile.PostedFile.ContentType;//文件类型

			if(Ll_FileLength > 2000*1024)
				Response.Write("<script language='JavaScript'>alert('上传的文件太大!')</script>");
			else
			{
				try
				{
					upFile.PostedFile.SaveAs(HttpRuntime.AppDomainAppPath +@".\lyword\"+_lyfilesname);				
					_lywordbs = "1";//再次初始标识
				}
				catch(Exception ex)
				{
					_lywordbs = "0";//再次初始标识
					Session["errors"]=Session["errors"].ToString()+ex.Message.ToString()+"<br>";

					
				}						
			}			
		}
		private void Button1_Click(object sender, System.EventArgs e)
		{
			if(IsNull().CompareTo ("YES")==0)
			{
				_SaveMsgInfo();
				Response.Redirect("home.aspx");
			}
			else
				Response.Write ("<script Language='JavaScript'>alert('请输入完整信息！')</script>");
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			Response.Redirect ("home.aspx");
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			TB_username.Text="";
			TB_email.Text="";
			TB_www.Text ="";
			TB_dh.Text="";
			TB_sj.Text="";
			TB_oicq.Text="";
			TB_dwmc.Text="";
			TB_dwdz.Text="";
			TB_zt.Text="";
			TB_nr.Text="";
		}

		private void __AddEvent()
		{
			//__KeyDown()
			TB_username.Attributes.Add("onkeydown","__KeyDown();");
			DDL_xb.Attributes.Add("onkeydown","__KeyDown();");
			TB_email.Attributes.Add("onkeydown","__KeyDown();");
			TB_www.Attributes.Add("onkeydown","__KeyDown();");
			TB_dh.Attributes.Add("onkeydown","__KeyDown();");
			TB_sj.Attributes.Add("onkeydown","__KeyDown();");
			TB_oicq.Attributes.Add("onkeydown","__KeyDown();");
			TB_dwmc.Attributes.Add("onkeydown","__KeyDown();");
			TB_dwdz.Attributes.Add("onkeydown","__KeyDown();");
			TB_zt.Attributes.Add("onkeydown","__KeyDown();");			
		}
	}
}
