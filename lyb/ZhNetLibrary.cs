using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Threading;
using System.Runtime .InteropServices ;
using System.Collections;
using System.Xml;
using System.Web.SessionState;


namespace MessageBor
{
	
	/// <summary>
	/// ZhNetLibrary 的摘要说明。
	/// </summary>
	public class ZhNetLibrary
	{
		public ZhNetLibrary()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		private static string ConnDataConfigKey="";		
		/// <summary>
		/// WebConfig文件中连接数据库文件的键值
		/// </summary>
		public static string DataBaseConfigKey
		{
			get
			{
				return ConnDataConfigKey;
			}
			set
			{
				ConnDataConfigKey=value;
			}
		}
		/// <summary>
		/// 创建连接数据库对象在使用前必须给本类的DataBaseConfigKey属性赋值
		/// </summary>
		/// <param name="Cukey">WebConfig文件中连接数据库文件的键值</param>
		/// <returns>连接数据库对象</returns>
		public static SqlConnection	connection()
		{			
			SqlConnection conn = null;
			try
			{	
				if(ConnDataConfigKey.Trim().Length==0)
					conn = new SqlConnection(ConfigurationSettings.AppSettings["SHUIFANG"]);
				else
					conn = new SqlConnection(ConfigurationSettings.AppSettings[ConnDataConfigKey]);
				
			}
			catch(Exception Ex)
			{
				throw new Exception(Ex.Message.ToString());
			}
			return conn;
		}
		/// <summary>
		/// 连接数据库
		/// </summary>
		/// <param name="ConnKeys">连接字符串</param>
		/// <returns>返回连接对象</returns>
		public static SqlConnection Connection(string ConnKeys)
		{
			SqlConnection _conn=null;
			
			try
			{
				_conn = new SqlConnection(ConnKeys);
			}
			catch(Exception  Ex)
			{
				throw new Exception(Ex.Message.ToString());
			}
			return _conn;
		}
		/// <summary>
		/// 创建数据视图
		/// </summary>
		/// <param name="SqlString">支持此视图的SQL语句</param>
		/// <param name="TableName">视图标识</param>
		/// <returns>返回基于SqlString的数据视图对象</returns>
		public static DataView dataview(string SqlString ,string TableName)
		{			
			SqlConnection cc=connection();			
			SqlDataAdapter pter = null;
			DataSet ds=new DataSet();			
			DataView dv = null;
			try
			{
				pter = new SqlDataAdapter(SqlString,cc);
				ds=new DataSet();
				pter.Fill(ds,TableName);
				dv = new DataView(ds.Tables[TableName]);
			}
			catch(Exception Ex)
			{
				throw new Exception(Ex.Message.ToString());
			}
			finally
			{
				if(cc!=null)	cc.Dispose();
				if(pter!=null)	pter.Dispose();
				if(ds!=null)	ds.Dispose();
			}
			return dv;
		}
		/// <summary>
		/// 对字符串加密
		/// </summary>
		/// <param name="jmstring">要加密的字符串</param>
		/// <returns>加密后字符串</returns>
		public static string ReturnPasswordString(string jmstring)
		{
			string NewPassWord=string.Empty;
			MD5CryptoServiceProvider HashMD5 = null;
			try
			{
				HashMD5 = new MD5CryptoServiceProvider();
				NewPassWord = ASCIIEncoding.ASCII.GetString(HashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(jmstring.Trim())));							
			}
			catch(Exception _Ex)
			{
				throw new Exception(_Ex.Message.ToString());
			}
			finally
			{
				if(HashMD5!=null)
					HashMD5.Clear();
			}
			return NewPassWord;
		}
		/// <summary>
		/// 保存数据到数据库
		/// </summary>		
		/// <param name="zhSql">要执行的存储过程无反回参数</param>
		/// <param name="zhParameters">存储过程参数数组</param>
		/// <param name="zhText">存储过程参数对应值数组</param>
		/// <returns>执行成功返回影响数据库的行数，失败返回 0 </returns>
		public static int SaveParametersCommand(SqlConnection zhConn,string zhSql,string[] zhParameters,string[] zhText )
		{
			/*
			 * 参数:zhConn连接对象
			 *		zhParameters存储过程参数数组
			 *		zhText参数值数组
			 * 
			 * */
			int row =0;			
			SqlCommand zhComm = null;			
			try
			{
				zhComm = new SqlCommand(zhSql,zhConn);
				zhComm.CommandType = CommandType.StoredProcedure;
				for(int p=0; p<zhParameters.Length; p++)
					zhComm.Parameters.Add(zhParameters[p],zhText[p]);
				if(zhConn.State == ConnectionState.Closed)
					zhConn.Open();
				row = zhComm.ExecuteNonQuery();
			}
			catch(Exception Ex)
			{	
				throw new Exception(Ex.Message.ToString());
			}
			finally
			{
				if(zhConn!=null) zhConn.Dispose();
				if(zhComm!=null) zhComm.Dispose();				
			}
			if(row > 0)
				return row;
			else
				return 0;
		}
		/// <summary>
		/// 给指定字符串补充指定个数个'0'字符
		/// </summary>
		/// <param name="Ls_FirstBm">要补充‘0’的字符串</param>
		/// <param name="ZeroNum">‘0’的个数</param>
		/// <returns>返回处理后的字符串</returns>
		public static  string AutoBm(string Ls_FirstBm,int ZeroNum)
		{	
			string Ls_Year = DateTime.Now.Year.ToString();//年
			string Ls_Month = DateTime.Now.Month.ToString().Trim();//月
			Ls_Month=(Ls_Month.Length <2)?"0"+Ls_Month:Ls_Month;
			string Ls_Day = DateTime.Now.Day.ToString().Trim();//日
			Ls_Day = (Ls_Day.Length <2)?"0"+Ls_Day:Ls_Day;
			string Ls_BmHeard = Ls_Year+Ls_Month+Ls_Day;//编码头部			
			string ls_year2 = Ls_FirstBm.Substring(0,4);
			Ls_FirstBm = Ls_FirstBm.Substring(8,4);
			if(Convert.ToInt32(Ls_Year)>Convert.ToInt32(ls_year2))
				Ls_FirstBm = "0001";
			int li=Convert.ToInt32(Ls_FirstBm.Trim())+1;
			string Ls_FirstBms =li.ToString();
			Ls_FirstBm = li.ToString();
			for(int i=ZeroNum;i>Ls_FirstBms.Length;i--)
				Ls_FirstBm="0"+Ls_FirstBm;	
			return Ls_BmHeard+Ls_FirstBm;
		}
		/// <summary>
		/// 以HH：MM：SS形式返回当前系统时间
		/// </summary>
		/// <returns></returns>
		public static string CurrentTime()
		{
			return DateTime.Now.Hour.ToString()+"："+DateTime.Now.Minute.ToString()+"："+DateTime.Now.Second.ToString();
		}
		/// <summary>
		/// 创建数据集对象
		/// </summary>
		/// <param name="SqlString">支持数据集的SQL语句</param>
		/// <param name="TableName">数据集标识</param>
		/// <returns>基于此SQL语句的数据集对象</returns>
		public static DataSet dataset(string SqlString ,string TableName)
		{			
			SqlConnection conn=connection();
			SqlDataAdapter pter = null;			
			DataSet ds=null;
			try
			{
				pter = new SqlDataAdapter(SqlString,conn);
				ds=new DataSet();
				pter.Fill(ds,TableName);
			}			
			catch(Exception EX)
			{
				throw new Exception(EX.Message.ToString());
			}
			finally
			{
				if(conn!=null) conn.Dispose();
				if(pter!=null) pter.Dispose();
			}			
			return ds;
		}
		/// <summary>
		/// 简单加密
		/// </summary>
		/// <param name="strIn">要加密的字符串</param>
		/// <returns>加密后的字符串</returns>
		public static string Password(string strIn)//简单加密码函数
		{
			strIn = strIn.Trim();
			string str = "plokm9ijn8uhb7ygv6tfc5rdx4esz12q3waQAZWSXEDCRFVTGBYHNUJMIKOLP";
			int iLen = strIn.Length;
			int iLenexp=str.Length;
			string strOne,strPassone,strPassword;
			int iFind,iMod;
			strPassword = "";
			try
			{
				for (int i=0;i<iLen;i++)
				{
					strOne = strIn.Substring(i,1);
					iFind = str.IndexOf(strOne);
					iFind ++;
					if (iFind == 0)
						return "0";
					iFind = (iFind + 2) * 3;
					iMod = iFind % iLenexp;
					if (iMod == 0)
						strPassone = str.Substring(iLenexp - 1,1);
					else
						strPassone = str.Substring(iMod - 1 ,1);
					strPassword += strPassone;
				}
			}
			catch(Exception Ex)
			{
				throw new Exception(Ex.Message.ToString());
			}
			return strPassword;
		}
		/// <summary>
		/// 返回数据视图
		/// </summary>
		/// <param name="Conn">连接数据库对象</param>
		/// <param name="SqlString">支持视图的SQL语句</param>
		/// <param name="TableName">视图标识</param>
		/// <returns>基于此SQL的视图</returns>
		public static DataView dataview_2(SqlConnection Conn,string SqlString ,string TableName)
		{					
			SqlDataAdapter pter = null;
			DataView dv=null;
			DataSet ds=new DataSet();
			try
			{
				pter = new SqlDataAdapter(SqlString,Conn);
				pter.Fill(ds,TableName);
				dv = new DataView(ds.Tables[TableName]);
			}
			catch(Exception Ex)
			{
				throw new Exception(Ex.Message.ToString());
			}
			finally
			{
				if(Conn!=null)	Conn.Dispose();
				if(pter!=null)	pter.Dispose();
				if(ds!=null)	ds.Dispose();
			}			
			return dv;
		}
		/// <summary>
		/// 创建数据集对象
		/// </summary>
		/// <param name="Conn">连接数据库对象</param>
		/// <param name="SqlString">支持数据集的SQL语句</param>
		/// <param name="TableName">数据集标识</param>
		/// <returns>基于此SQL的数据集对象</returns>
		public static DataSet dataset_2(SqlConnection Conn,string SqlString ,string TableName)
		{
			SqlDataAdapter pter = null;
			DataSet ds=new DataSet();
			try
			{
				pter = new SqlDataAdapter(SqlString,Conn);
				pter.Fill(ds,TableName);
			}
			catch(Exception Ex)
			{
				throw new Exception(Ex.Message.ToString());
			}
			finally
			{
				if(Conn!=null)
					Conn.Dispose();
				if(pter!=null)
					pter.Dispose();
			}
			return ds;
		}
		/// <summary>
		/// 得到-- StrLenght --长度的用-- Str --字符补充的字符串
		/// </summary>
		/// <param name="InitiallStr">被补充的字符串</param>
		/// <param name="StrLenght">要反回的字符串的长度</param>
		/// <param name="Str">用于补充的字符</param>
		/// <returns>处理后的字符串</returns>
		public static string GetStr_Lenght(string InitiallStr,int StrLenght,string Str)
		{			
			int j=InitiallStr.Length;
			try
			{
				for(int i=0;	i	<	StrLenght	-	j;	i++)
					InitiallStr=Str+InitiallStr;
			}
			catch(Exception Ex)
			{
				throw new Exception(Ex.Message.ToString());
			}
			return InitiallStr;
		}
		/// <summary>
		/// 返回两个时间差
		/// </summary>
		/// <param name="date1">起始时间</param>
		/// <param name="date2">终止时间</param>
		/// <param name="bs">标识 1 反回短字符串不包括天, 2 返回带天的时间差 </param>
		/// <returns>不成功反回 null</returns>
		public static string DateSpan(DateTime date1,DateTime date2,string bs)
		{
			if(date1.ToString().Trim().Length==0 || date2.ToString().Trim().Length==0)
				return null;
			else
			{
				TimeSpan date3=date2.Subtract(date1);
				//还可以反回天数
				if(bs.Trim()=="1")
					return date3.Hours.ToString()+"小时"+date3.Minutes.ToString()+"分钟"+date3.Seconds.ToString()+"秒";
				else if(bs.Trim()=="2")
					return date3.Days.ToString()+"天"+date3.Hours.ToString()+"小时"+date3.Minutes.ToString()+"分钟"+date3.Seconds.ToString()+"秒";
				else
					return null;
			}
		}
		/// <summary>
		/// 得到时间差值
		/// </summary>
		/// <param name="cudate">起始时间(?:?:?),终止时间是当前时间</param>
		/// <returns>时间差，?时?分?秒</returns>
		public static string GetSjC(string cudate)
		{
			string[] yea=DateTime.Now.Date.ToShortDateString().Split(new char[]{'-'});;
			string[] aaa=cudate.Split(new char[]{':'});
			string[] bbb=DateTime.Now.ToLongTimeString().Split(new char[]{':'});
			DateTime date1 = new DateTime(Int32.Parse(yea[0]),Int32.Parse(yea[1]),Int32.Parse(yea[2]),Int32.Parse(aaa[0]),Int32.Parse(aaa[1]),Int32.Parse(aaa[2]));//年、月、日、时、分、秒
			DateTime date2 = new DateTime(Int32.Parse(yea[0]),Int32.Parse(yea[1]),Int32.Parse(yea[2]),Int32.Parse(bbb[0]),Int32.Parse(bbb[1]),Int32.Parse(bbb[2]));//年、月、日、时、分、秒
			return DateSpan(date1,date2,"1");
		}
		/// <summary>
		/// 汉化当前星期表示
		/// </summary>
		/// <returns>汉化后的星期表示</returns>
		public static string CurrentWeek()
		{
			string ss=DateTime.Now.DayOfWeek.ToString();

			switch(ss)
			{
				case "Sunday":
					ss= "星期日";
					break;
				case "Monday":
					ss= "星期一";
					break;
				case "Tuesday":
					ss= "星期二";
					break;
				case "Wednesday":
					ss= "星期三";
					break;
				case "Thursday":
					ss= "星期四";
					break;
				case "Friday":
					ss= "星期五";
					break;
				case "Saturday":
					ss= "星期六";
					break;
			}			
			return ss;
		}
		/// <summary>
		/// 保存网站错误信息
		/// </summary>
		/// <param name="_ErrorInfo">错误信息</param>
		/// <param name="_ErrorLx">错误信息类型</param>
		public static void SaveErrorInfo(string _ErrorInfo,string _ErrorLx)
		{
			SqlConnection _Conn = connection();
			string[] _Params = {"@error","@lx"};
			string[] _Ptexts = {_ErrorInfo,_ErrorLx};
			SaveParametersCommand(_Conn,"zhsp_saveerrors",_Params,_Ptexts);
		}
		/// <summary>
		/// 填充 DropDownList 控件
		/// </summary>
		/// <param name="_CuDDL">DropDownList控件ID</param>
		/// <param name="_SqlStr">支持的SQL语句</param>
		/// <param name="_Table_Name">视图标识</param>
		/// <param name="_Value">数据字段</param>
		/// <param name="_Mc">显示字段</param>
		/// <param name="_ErrorsWZ">记录程序中的位置</param>
		public static void Fill_DropDownList(SqlConnection _Conn,DropDownList _CuDDL,string _SqlStr,string _Table_Name,string _Value,string _Mc,string _ErrorsWZ)
		{
			//SqlConnection _Conn = new SqlConnection(ConfigurationSettings.AppSettings["YJH"]);
			try
			{
				_CuDDL.DataSource =dataview_2 (_Conn,_SqlStr,_Table_Name);
				_CuDDL.DataTextField =_Mc;
				_CuDDL.DataValueField = _Value;
				_CuDDL.DataBind ();
			}
			catch(Exception _ex)
			{
				throw new Exception(_ex.Message.ToString());
			}			
			finally
			{
				if(_Conn!=null) _Conn.Dispose ();
			}			
		}
		/// <summary>
		/// 得到最后一个匹配的字符后的所有字符
		/// </summary>
		/// <param name="_TheString">检验字符串</param>
		/// <param name="_PPstr">匹配字符</param>
		/// <returns>最后一个匹配的字符后的所有字符</returns>
		public static string GetString(string _TheString,string _PPstr)
		{
			if(_PPstr.Trim().Length >0 && _TheString.Trim ().Length >1)
			{
				int i = _TheString.Trim ().LastIndexOf (_PPstr)+1;
				return _TheString.Trim ().Substring (i,_TheString.Trim ().Length -i);
			}
			else
				return "";
		}
		/// <summary>
		/// 用于药交会网站得到数据库中的友好连接内容(以html形式表示的字符串)
		/// </summary>
		/// <returns>返回HTML字符串</returns>
		public static string FriendConnection()
		{
			/*
			 * 提取超连接信息
			 * */
			SqlConnection _Conn=connection ();
			StringBuilder lsb_cl = new StringBuilder ("<font COLOR='BLUE'>友好链接：</font>&nbsp;");
			DataSet F_ds = dataset_2 (_Conn,"SELECT friendmc,url FROM hy_yjh_friendconnection Where bs='1'","Friendcl");
			foreach(DataRow CL in F_ds.Tables ["Friendcl"].Rows )
				lsb_cl.Append ("&nbsp;<a href='"+CL["url"].ToString ()+"' target='_blank' class='cslist'>"+CL["friendmc"].ToString ()+"</a>");
			return lsb_cl.ToString ();
		}
		/// <summary>
		/// 上传文件
		/// </summary>
		/// <param name="upFile">HtmlInputFile控件ID</param>
		/// <param name="_lyfilesname">返回文件名子</param>
		/// <param name="Ll_FileLength">返回文件大小</param>
		/// <param name="Ls_FileContentType">返回文件类型</param>
		/// <param name="_ML">上传文件的服务器目录(物理目录)</param>
		/// <param name="_FileSize">上传文件最大值（KB）</param>
		/// <returns>反回0标识成功</returns>
		public static string File_upDownd(HtmlInputFile upFile, out string _lyfilesname,out int Ll_FileLength,out string Ls_FileContentType,string _ML,int _FileSize)
		{
			string _bs=string.Empty;
			_lyfilesname = upFile.PostedFile.FileName;
			_lyfilesname = Path.GetFileName(_lyfilesname);//获得文件名称
			Ll_FileLength = upFile.PostedFile.ContentLength;//获得文件字节大小
			Ls_FileContentType = upFile.PostedFile.ContentType;//文件类型

			if(Ll_FileLength > _FileSize*1024)
			{				
				throw new Exception("上传文件太大");
			}
			else
			{
				try
				{
					upFile.PostedFile.SaveAs(HttpRuntime.AppDomainAppPath +_ML+@"\"+_lyfilesname);
					_bs="0";//上传成功
					
				}
				catch(Exception ex)
				{						
					throw new Exception(ex.Message.ToString());
				}						
			}
			return _bs;//反回0标识成功
		}
		/// <summary>
		/// 得到当前系统日期、星期 字符串
		/// </summary>
		/// <returns>string</returns>
		public static string DataWeek()
		{
			string ls_Year=string.Empty ,ls_Month=string.Empty ,ls_Day=string.Empty ,ls_Week=string.Empty ;
			int li_Time=0;
			li_Time = Convert.ToInt32(DateTime.Now.Hour.ToString());	//当前时间
			ls_Week = System.DateTime.Today.DayOfWeek.ToString();		//当前星期
			ls_Year = DateTime.Now.Year.ToString()+"年";
			ls_Month = DateTime.Now.Month.ToString()+"月";
			ls_Day = DateTime.Now.Day.ToString()+"日";
			switch (ls_Week)
			{
				case "Monday":
					ls_Week = "星期一";break;
				case "Tuesday":
					ls_Week = "星期二";break;
				case "Wednesday":
					ls_Week = "星期三";break;
				case "Thursday":
					ls_Week = "星期四";break;
				case "Friday":
					ls_Week = "星期五";break;
				case "Saturday":
					ls_Week = "星期六";break;
				case "Sunday":
					ls_Week = "星期日";break;
			}
			return "&nbsp;"+ls_Year+ls_Month+ls_Day+" <font color='Red'>『</font>"+ls_Week+"<font color='Red'>』</font> &nbsp;&nbsp;┃<a href=''>登陆</a>┃<a href=''>注册</a>┃<a href=''>会员专区</a>┃";
			
		}
		/// <summary>
		/// 填充DataList组件
		/// </summary>
		/// <param name="CuDL">当前DataList</param>
		/// <param name="SqlStr">SQL语句字符串</param>
		/// <param name="TableName">表名</param>
		public static void FillDList(DataList CuDL,string SqlStr,string TableName,string Wz)
		{
			if(SqlStr.Trim().Length==0 || TableName.Trim().Length==0)
				return;
			SqlConnection _Conn=connection();
			try
			{
				CuDL.DataSource=dataset_2(_Conn,SqlStr,TableName);
				CuDL.DataBind();
			}
			catch(Exception _Ex)
			{
				throw new Exception(_Ex.Message.ToString());
			}
			finally
			{
				if(_Conn!=null)
					_Conn.Dispose();
			}
		}
		/// <summary>
		/// 填充DataGrid组件
		/// </summary>
		/// <param name="CuDL">当前DataGrid</param>
		/// <param name="SqlStr">SQL语句字符串</param>
		/// <param name="TableName">表名</param>
		public static void FillDataGrid(SqlConnection _Conn,DataGrid CuDL,string SqlStr,string TableName)
		{
			if(SqlStr.Trim().Length==0 || TableName.Trim().Length==0)
				return;
			//SqlConnection _Conn=connection();
			try
			{
				CuDL.DataSource=dataset_2(_Conn,SqlStr,TableName);
				CuDL.DataBind();
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message.ToString());
			}
			finally
			{
				if(_Conn!=null)
					_Conn.Dispose();
			}
		}
		/// <summary>
		/// 填充LISTBOX控件数据
		/// </summary>
		/// <param name="CuLB">当前ListBox控件</param>
		/// <param name="SqlStr">SQL语句</param>
		/// <param name="TableName">表名</param>
		/// <param name="TextField">要显示的字段</param>
		/// <param name="ValueField">数据字段</param>
		public static void Fill_ListBox(ListBox CuLB,string SqlStr,string TableName,string TextField,string ValueField)
		{
			SqlConnection _Conn=connection();
			try
			{
				CuLB.DataSource=dataset_2(_Conn,SqlStr,TableName);
				CuLB.DataTextField = TextField;
				CuLB.DataValueField= ValueField;
				CuLB.DataBind();
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message.ToString());
			}
			finally
			{
				if(_Conn!=null)
					_Conn.Dispose();
			}
		}
		/// <summary>
		/// ListBox列表控件之间移动列表项
		/// </summary>
		/// <param name="CurrentListBoxFrom">从ListBox</param>
		/// <param name="CurrentListBoxTo">到ListBox</param>
		public static void CurrentLB_Choose(ListBox CurrentListBoxFrom,ListBox CurrentListBoxTo)
		{
			int i=0,j=0;
			j=CurrentListBoxFrom.Items.Count;
			ListItem[] CuChoose=new ListItem[j];
			foreach(ListItem CuListitem in CurrentListBoxFrom.Items)
				if(CuListitem.Selected==true)					
					if(CurrentListBoxTo.Items.FindByValue(CuListitem.Value)==null)
					{						
						CurrentListBoxTo.Items.Add(CuListitem);
						CuChoose[i]=CuListitem;
						i++;
					}
			foreach(ListItem Citm in CuChoose)
				CurrentListBoxFrom.Items.Remove(Citm);
			CurrentListBoxTo.ClearSelection();
		}
		/// <summary>
		/// 把一个LISTBOX中的列表项全部移动到另一个LISTBOX列表项中
		/// </summary>
		/// <param name="CurrentListBoxFrom">From列表控件</param>
		/// <param name="CurrentListBoxTo">To列表控件</param>
		/// <param name="istrue">全部移动标识</param>
		public static void CurrentLB_Choose(ListBox CurrentListBoxFrom,ListBox CurrentListBoxTo,bool istrue)
		{
			int i=0,j=0;
			j=CurrentListBoxFrom.Items.Count;
			ListItem[] CuChoose=new ListItem[j];
			foreach(ListItem CuListitem in CurrentListBoxFrom.Items)
				if(CurrentListBoxTo.Items.FindByValue(CuListitem.Value)==null)
				{						
					CurrentListBoxTo.Items.Add(CuListitem);
					CuChoose[i]=CuListitem;
					i++;
				}
			foreach(ListItem Citm in CuChoose)
				CurrentListBoxFrom.Items.Remove(Citm);
			CurrentListBoxTo.ClearSelection();			
		}
		/// <summary>
		/// 把带有\r\n的字符串转化为能自动分段的标准字符串(段间距较大)
		/// </summary>
		/// <param name="OldString">要转换的字符串</param>
		/// <returns>新的字符串</returns>
		public static string ToNewString(string OldString)
		{
			if(OldString.Trim().Length==0)	return "";
			
			OldString="<p>&nbsp;&nbsp;&nbsp;&nbsp;"+OldString.Trim(new char[]{'\t'});
			OldString=OldString.Replace("\r\n","</p><p><br>&nbsp;&nbsp;&nbsp;&nbsp;");
			OldString=OldString+"</p>";
			return OldString;
		}
		/// <summary>
		/// 把带有\r\n的字符串转化为能自动分段的标准字符串(标准段间距)
		/// </summary>
		/// <param name="OldString">要转换的字符串</param>
		/// <returns>新的字符串</returns>
		public static string ToNewString2(string OldString)
		{
			if(OldString.Trim().Length==0)	return "";
			
			OldString="<p>&nbsp;&nbsp;&nbsp;&nbsp;"+OldString.Trim(new char[]{'\t'});
			OldString=OldString.Replace("\r\n","<br>&nbsp;&nbsp;&nbsp;&nbsp;");
			OldString=OldString+"</p>";
			return OldString;
		}
		/// <summary>
		/// 把带有\r\n的字符串转化为能自动分段的标准字符串(标准段间距)
		/// </summary>
		/// <param name="OldString">要转换的字符串</param>
		/// <returns>新的字符串</returns>
		public static string ToNewString3(string OldString)
		{
			if(OldString.Trim().Length==0)	return "";
			
			OldString="<p>"+OldString.Trim(new char[]{'\t'});
			OldString=OldString.Replace("\r\n","<br>&nbsp;&nbsp;");
			OldString=OldString+"</p>";
			return OldString;
		}
		/// <summary>
		/// 把带有\r\n的字符串转化为能自动分段的标准字符串(标准段间距)
		/// </summary>
		/// <param name="OldString">要转换的字符串</param>
		/// <returns>新的字符串</returns>
		public static string ToNewString4(string OldString)
		{
			if(OldString.Trim().Length==0)	return "";
			
			OldString=""+OldString.Trim(new char[]{'\t'});
			OldString=OldString.Replace("\r\n","<br>&nbsp;&nbsp;");
			OldString=OldString+"";
			return OldString;
		}
		/// <summary>
		/// 执行Sql语句，并返回对数据库的影响行数
		/// </summary>
		/// <param name="SqlString">要执行的SQL语句</param>
		/// <param name="wz">执行此SQL语句的程序位置</param>
		/// <returns> 0 执行失败 1 执行成功</returns>
		public static int BeginSqlCommand(string SqlString,string wz)
		{
			if(SqlString.Trim().Length==0) return 0;
			SqlConnection _Conn = null;
			SqlTransaction _Tran= null;
			SqlCommand		_Comm=null;
			int Rows=0;
			try
			{
				_Conn=connection();
				_Conn.Open();
				_Tran =_Conn.BeginTransaction();
				_Comm = new SqlCommand(SqlString,_Conn,_Tran);
				Rows=_Comm.ExecuteNonQuery();
				_Tran.Commit();
			}
			catch(Exception _Ex)
			{
				_Tran.Rollback();
				throw new Exception(_Ex.Message.ToString());
			}
			finally
			{
				if(_Conn!=null) _Conn.Dispose();
				if(_Comm!=null) _Comm.Dispose();
				if(_Tran!=null) _Tran.Dispose();
			}
			return Rows;
		}
		/// <summary>
		/// 判断字前字符串是否为数字,是数字返回TRUE 否则为FALSE
		/// </summary>
		/// <param name="CuStr">要验证的字符串</param>
		/// <returns>是数字返回TRUE 否则为FALSE</returns>
		public static bool IsNumbers(string CuStr)
		{
			if(CuStr.Trim().Length==0) return false;
			bool _bs=true;
			for(int i=0;i<CuStr.Trim().Length;i++)
				if(!(char.IsNumber(CuStr,i)))
				{
					_bs=false;
					break;
				}
			return _bs;
		}
		/// <summary>
		/// 输出ArrayList中的可枚举的成员
		/// </summary>
		/// <param name="myList">公开枚举数接口</param>
		public static void PrintValues( IEnumerable myList )  
		{
			System.Collections.IEnumerator myEnumerator = myList.GetEnumerator();
			while ( myEnumerator.MoveNext() )
				Console.Write( "\t{0}", myEnumerator.Current );
			Console.WriteLine();
		}
		/// <summary>
		/// [DaArray]即动态数组
		/// </summary>
		public IList DyArray
		{
			get{return dyarray;}

		}private ArrayList dyarray=new ArrayList();
		/// <summary>
		/// 避开<>内的内容，进行替换
		/// </summary>
		/// <param name="CuHtmlStr">要处理的HTML字串</param>
		/// <param name="OldStr">要查找的字符串</param>
		/// <param name="NewStr">替换内容</param>
		/// <returns>返回新的HTML字符串</returns>
		public static string OverReplace(string CuHtmlStr,string OldStr,string NewStr)
		{
			/*
			 * 指导思想在E盘开发文档
			 * */
			if(CuHtmlStr.Trim().Length==0) return null;
			if(OldStr.Trim().Length>0)
			{
				if(CuHtmlStr.Trim().IndexOf("<",0,CuHtmlStr.Trim().Length)==-1)	//无HTML字符串				
					return CuHtmlStr.Replace(OldStr,NewStr);
				string[] HtmlArrar=CuHtmlStr.Split(new char[]{'<'});
				for(int i=0;i<HtmlArrar.Length;i++)
				{
					if(HtmlArrar[i].IndexOf(">",0,HtmlArrar[i].Trim().Length)>=0)
						HtmlArrar[i]=HtmlArrar[i].Split(new char[]{'>'})[1];
					if(HtmlArrar[i].Length>0)
						CuHtmlStr=CuHtmlStr.Replace(HtmlArrar[i],HtmlArrar[i].Replace(OldStr,NewStr));
				}
				return CuHtmlStr;
			}
			else
				return CuHtmlStr;		
		}
		/// <summary>
		/// 填充 CheckBoxList 控件
		/// </summary>
		/// <param name="_CuDDL">CheckBoxList控件ID</param>
		/// <param name="_SqlStr">支持的SQL语句</param>
		/// <param name="_Table_Name">视图标识</param>
		/// <param name="_Value">数据字段</param>
		/// <param name="_Mc">显示字段</param>
		/// <param name="_ErrorsWZ">记录程序中的位置</param>
		public static void Fill_ChecBoxList(CheckBoxList _CuDDL,string _SqlStr,string _Table_Name,string _Value,string _Mc,string _ErrorsWZ)
		{
			SqlConnection _Conn = new SqlConnection(ConfigurationSettings.AppSettings["YJH"]);
			try
			{
				_CuDDL.DataSource =dataview_2 (_Conn,_SqlStr,_Table_Name);
				_CuDDL.DataTextField =_Mc;
				_CuDDL.DataValueField = _Value;
				_CuDDL.DataBind ();
			}
			catch(Exception _ex)
			{
				throw new Exception(_ex.Message.ToString());
			}			
			finally
			{
				if(_Conn!=null) _Conn.Dispose ();
			}			
		}
		/// <summary>
		/// 验证字体串中是否包括HTML代码
		/// </summary>
		/// <param name="ValidatedStr">待验证字体串</param>
		/// <returns>包含HTML返回TRUE 否则返回FALSE	</returns>
		public static bool IsHtml(string ValidatedStr)
		{
			if(ValidatedStr.Trim().Length==0)
				return true;
			// validate <> script /
			int validateBs_1=-1,validateBs_2=-1;
			validateBs_1=ValidatedStr.IndexOf("<");			
			validateBs_2=ValidatedStr.IndexOf(">");

			if(validateBs_2>0 && validateBs_1>=0)
				return true;
			validateBs_1=-1;
			validateBs_2=-1;

			validateBs_1=ValidatedStr.IndexOf("script");
			validateBs_2=ValidatedStr.IndexOf("SCRIPT");

			if(validateBs_2>0 && validateBs_1>=0)
				return true;
			else
				return false;
		}
		public static string CurrentDateTime()	
		{
			return DateTime.Now.ToString();
		}
		public static string CurrentYear()
		{
			return DateTime.Now.Year.ToString();
		}
		public static string CurrentMonth()
		{
			return DateTime.Now.Month.ToString();
		}
		public static string CurrentDay()
		{
			return DateTime.Now.Day.ToString();
		}
		public static string CurrentDate()
		{
			return DateTime.Today.ToShortDateString();
		}
		public static string CurrentTime2()
		{
			return DateTime.Now.Hour.ToString()+"："+DateTime.Now.Minute.ToString()+"："+DateTime.Now.Second.ToString();
		}
		public static string Login_Users()
		{
			string _UserNumbers=string.Empty;
			try
			{
				_UserNumbers=dataset("SELECT count(*) FROM Exam_ksrs","usernumbers").Tables["usernumbers"].Rows[0][0].ToString();
			}
			catch
			{			
			}
			if(_UserNumbers.Trim().Length >0)
				_UserNumbers=(Convert.ToInt32(_UserNumbers)+2000).ToString();
			return _UserNumbers;
		}
		/// <summary>
		/// 过滤脏话
		/// </summary>
		/// <param name="_BadStr">要过滤的串</param>
		/// <returns></returns>
		public static string FiltrationStr(string _BadStr)
		{
			if(_BadStr.Trim().Length==0 ) return "";
			string Custr=string.Empty;
			Custr=_BadStr;
			string[] BadLanguage={"我是你爸","我是你妈","尻","干你","我操","妈妈的","我靠","fuck","bitch","他妈的","性爱","法轮功","falundafa","falun","江泽民","操你妈","三级片","sex","腚","妓","娼","阴蒂","奸","贱","婊","叉","龟头","屄","赑","妣","肏","尻","屌"};
			foreach(string i in BadLanguage)
			Custr	=Custr.Replace(i.Trim(),"不要说脏话");
			return Custr;
		}
		/// <summary>
		/// 得到考试类别代码
		/// </summary>
		/// <param name="ExamLb">考试类别串</param>
		/// <returns></returns>
		public static string GetDm(string ExamLb)
		{
			if(ExamLb.Trim().Length==0) return null;
			string LbDm=string.Empty;

			switch (ExamLb.Trim())
			{
				case "IELTS":
					LbDm="05";
				break;
				case "TOEFL":
					LbDm="04";
					break;
				case "GRADUATE":
					LbDm="03";
					break;
				case "FOURSIX":
					LbDm="02|01";
					break;
			}
			return LbDm;
		}
		public static string __GetName(string __AS_id,string __AS_Sql)//select ypmc from hh_dm_ypmc 
		{
			string __Name=string.Empty;
			SqlCommand __Comm= null;
			SqlConnection	__Conn =null;
			try
			{
				__Conn = ZhNetLibrary.connection();
				__Comm = new SqlCommand(__AS_Sql+"  WHERE uid="+__AS_id ,__Conn);
				__Conn.Open();
				__Name	=	__Comm.ExecuteScalar().ToString();
			}
			catch(Exception Ex)
			{
				string aa=Ex.Message.ToString();
			}
			finally
			{
				if(__Conn!=null)
					__Conn.Close();
				__Conn.Dispose();
				if(__Comm!=null)
					__Comm.Dispose();
			}
			return __Name;
		}
		/// <summary>
		/// 得到条件ID字符串
		/// </summary>
		/// <param name="__AS_Column">列名 "ypmc"</param>
		/// <param name="__AS_Sql">SQL语句"select id from HH_dm_ypmc"</param>
		/// <param name="__AS_Contain">查询条件内容"消炎片"</param>
		/// <returns>返回如 "id=1 or id=2 "串</returns>
		public static string __GetID(string	__AS_Column,string	__AS_Sql,string	__AS_Contain)
		{
			if(__AS_Column.Trim().Length==0	|| __AS_Sql.Trim().Length==0)
				return null;
			SqlCommand	__Comm	=	null;
			SqlConnection	__Conn	=	null;
			string	__WhereStr	=	string.Empty;
			try
			{
				__Conn	=	ZhNetLibrary.connection();				
				__Comm	=	new SqlCommand(__AS_Sql+" WHERE "+__AS_Column+"  like '%"+__AS_Contain+"%'",__Conn);
				__Conn.Open();
				SqlDataReader	__DataReader	=	__Comm.ExecuteReader();

				while(__DataReader.Read())
					__WhereStr += __AS_Column+" = '"+__DataReader.GetInt32(0).ToString().Trim()+"' or ";
			}
			catch(Exception Ex)
			{
				throw new Exception(Ex.Message.ToString());
			}
			finally
			{
				if(__Conn!=null)
					__Conn.Close();
				__Conn.Dispose();
				if(__Comm!=null)
					__Comm.Dispose();
			}
			if(__WhereStr.Trim().Length>0)
				__WhereStr=__WhereStr.Trim().TrimEnd(new char[]{'r'}).TrimEnd(new char[]{'o'});

			return __WhereStr;
		}
		/// <summary>
		/// 生成一个漂亮的控件
		/// </summary>
		/// <param name="__As_Width">控件的总宽度</param>
		/// <param name="__As_BarHeight">工具条的高度</param>
		/// <param name="__As_ItemWidth">项目的宽度</param>
		/// <param name="__As_ItemHeight">项目的高度</param>
		/// <param name="__As_BarImagPath">工具条背景图片路径</param>
		/// <param name="__As_ItemImagPath">项目图片路径</param>
		/// <param name="__As_BarFeilds">工具条字段</param>
		/// <param name="__As_BarSql">工具条数据库SQL语句</param>
		/// <param name="__As_ItemFeilds">项目字段</param>
		/// <param name="__As_ItemSql">项目数据库SQL语句</param>
//		public	static	void	__CreateWebBar(int	__As_Width,int	__As_BarHeight,int	__As_ItemWidth,int	__As_ItemHeight,
//			string	__As_BarImagPath,string	__As_ItemImagPath,string	__As_BarFeilds,string	__As_BarSql,
//			string	__As_ItemFeilds,string	__As_ItemSql)
//		{
//			StringBuilder	__CreateString	=	new StringBuilder("");
//			
//			DataView	__BarDv	=null;
//			DataView	__ItemDv=null;
//
//			__BarDv	=	ZhNetLibrary.dataview(__As_BarSql,"bardv");
//			if(__BarDv.Count==0)
//			{
//				throw new Exception("连接数据库失败！");
//				return;
//			}
//			__ItemDv	=	ZhNetLibrary.dataview(__As_ItemSql,"itemdv");
//
//			__CreateString.Append("<TABLE id='Table2' style='BORDER-RIGHT: #7aa4d4 1px solid; BORDER-LEFT: #7aa4d4 1px solid'"+
//									" cellSpacing='0' cellPadding='0' width='166' border='0' height='500' bgColor='#7aa4d4'> <TR> "+
//									"<TD align='center' vAlign='middle'>  ");
//
//		}
	}
}
