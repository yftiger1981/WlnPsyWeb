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
using System.Collections;
using System.ComponentModel;
using System.Web.SessionState;
using System.Drawing;
using System.Web.UI;
using System.Data.OleDb;

namespace MessageBor
{
	/// <summary>
	/// UserParameters 的摘要说明。
	/// </summary>
	public class UserParameters
	{
		public UserParameters()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static SqlConnection	connection()
		{
			/*功能:创建数据连接对象
			 * 返回:数据库连接对象
			 * */
			SqlConnection conn = new SqlConnection(ConfigurationSettings.AppSettings["OA"]);
			return conn;
		}
		public static DataView dataview(string SqlString ,string TableName)
		{
			/*功能:反回数据视图对象
			 * 
			 * 参数:SqlString 检索数据库的SQL语句
			 *	   TableName 数据集中的表名
			 * 返回:数据视图对象
			 * */
			
			SqlDataAdapter pter = new SqlDataAdapter(SqlString,connection());
			DataSet ds=new DataSet();
			pter.Fill(ds,TableName);

			DataView dv = new DataView(ds.Tables[TableName]);
			return dv;

		}
		public static string ReturnPasswordString(string jmstring)
		{
			/*功能:对任意字符串进行加密
			 * 参数:要加密的字符串
			 *返回:加密后的字符串
			 * */
			
			MD5CryptoServiceProvider HashMD5 = new MD5CryptoServiceProvider();
			string NewPassWord = ASCIIEncoding.ASCII.GetString(HashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(jmstring.Trim())));							
			return NewPassWord;
		}
		//添加动态增加输入参数及处理参数利用COMMAND命令提交数据库函数
		public static int SaveParametersCommand(SqlConnection zhConn,string zhSql,string[] zhParameters,string[] zhText )
		{
			/*
			 * 参数:zhConn连接对象
			 *		zhParameters存储过程参数数组
			 *		zhText参数值数组
			 * 
			 * */
			int row =0;
			SqlCommand zhComm = new SqlCommand(zhSql,zhConn);
			zhComm.CommandType = CommandType.StoredProcedure;

			for(int p=0; p<zhParameters.Length; p++)
				zhComm.Parameters.Add(zhParameters[p],zhText[p]);
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
//				Response.Write("--SQLException--<br/>");
//				Response.Write("Message:");
//				Response.Write(ex.Message.Replace("\n","<br/>")+"<br>");
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
		public static  TextBox GetFootTextBox(DataGrid dg,string TextBoxId)
		{
			/*
			 * 功能:得到DATAGRID指定项目(Item,Footer)中的子控件TextBox对象
			 * 参数:dg被查找的DataGrid对象
			 *		TextBoxId子控件的ID名称
			 * */
			TextBox tb = null;
			foreach( DataGridItem i in dg.Controls[0].Controls)
			{
				if(i.ItemType == ListItemType.Footer)
				{
					tb = (TextBox)i.FindControl(TextBoxId);
					break;
				}
				
			}
			return tb;
		}
		public static  TextBox GetItemTextBox(DataGrid dg,string TextBoxId)
		{
			/*
			 * 功能:得到DATAGRID指定项目(Item,Footer)中的子控件TextBox对象
			 * 参数:dg被查找的DataGrid对象
			 *		TextBoxId子控件的ID名称
			 * */
			TextBox tb = null;
			foreach( DataGridItem i in dg.Controls[0].Controls)
			{
				if(i.ItemType == ListItemType.Item)
				{
					tb = (TextBox)i.FindControl(TextBoxId);
					break;
				}
				
			}
			return tb;
		}

		public static  string AutoBm(string Ls_FirstBm,int ZeroNum)
		{	//参数为编码的超始值/及要补充的0的最大个数
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
			//return DateTime.Now.DayOfWeek.ToString();
			return ss;
		}
		public static string CurrentDate()
		{
			return DateTime.Today.ToShortDateString();
		}
		public static string CurrentTime()
		{
			return DateTime.Now.Hour.ToString()+"："+DateTime.Now.Minute.ToString()+"："+DateTime.Now.Second.ToString();
		}
		public static DataSet dataset(string SqlString ,string TableName)
		{
			/*功能:反回数据集对象
			 * 
			 * 参数:SqlString 检索数据库的SQL语句
			 *	   TableName 数据集中的表名
			 * 返回:数据集对象
			 * */
			SqlConnection conn=connection();
			SqlDataAdapter pter = null;			
			DataSet ds=null;
			try
			{
				pter = new SqlDataAdapter(SqlString,connection());
				ds=new DataSet();
				pter.Fill(ds,TableName);
			}
			catch
			{
			}
			finally
			{
				if(conn!=null) conn.Dispose();
				if(pter!=null) pter.Dispose();

			}
			
			return ds;

		}
		public static string Password(string strIn)//简单加密码函数
		{
			strIn = strIn.Trim();
			string str = "plokm9ijn8uhb7ygv6tfc5rdx4esz12q3waQAZWSXEDCRFVTGBYHNUJMIKOLP";
			int iLen = strIn.Length;
			int iLenexp=str.Length;
			string strOne,strPassone,strPassword;
			int iFind,iMod;
			strPassword = "";
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
			return strPassword;
		}
		public static DataView dataview_2(SqlConnection Conn,string SqlString ,string TableName)
		{
			/*功能:反回数据视图对象
			 * 
			 * 参数:SqlString 检索数据库的SQL语句
			 *	   TableName 数据集中的表名
			 * 返回:数据视图对象
			 * */
			SqlDataAdapter pter=null;
			pter = new SqlDataAdapter(SqlString,Conn);
			DataSet ds=new DataSet();
			pter.Fill(ds,TableName);

			DataView dv = new DataView(ds.Tables[TableName]);
			if(pter!=null)
				pter.Dispose();
			if(ds!=null)
				ds.Dispose();
			return dv;

		}
		public static DataSet dataset_2(SqlConnection Conn,string SqlString ,string TableName)
		{
			/*功能:反回数据集对象
			 * 
			 * 参数:SqlString 检索数据库的SQL语句
			 *	   TableName 数据集中的表名
			 * 返回:数据集对象
			 * */
			
			SqlDataAdapter pter = new SqlDataAdapter(SqlString,Conn);
			DataSet ds=new DataSet();
			pter.Fill(ds,TableName);
			
			return ds;

		}
		public static string GetStr_Lenght(string InitiallStr,int StrLenght,string Str)
		{
			/*
			 * 功能：反回-- StrLenght --长度的用-- Str --字符补充的字符串
			 * 参数：
			 * InitiallStr	：被补充的字符串;
			 * StrLenght	：要反回的字符串的长度
			 * Str			：用于补充的字符
			 * */
			int j=InitiallStr.Length;
			for(int i=0;	i	<	StrLenght	-	j;	i++)
				InitiallStr=Str+InitiallStr;
			return InitiallStr;
		}
		public static int GetUserRight(string UserId,string MkId,out string bs)
		{
			/*
			 * 用于OA系统，取用户的每个模块的权限值
			 * 用到表格：Group_user（组、用户关系）、oa_right（权限表）
			 * 参数：
			 *		UserId 用户ID
			 *		MkId	模块ID
			 * */
			SqlConnection Rconn=connection();
			string RightString=string.Empty;			
			string Qsbs="SELECT bs FROM oa_user WHERE id="+UserId;
			string SQLstr="SELECT MAX(oa_right.fwjb)FROM oa_right INNER JOIN  Group_user ON oa_right.group_id = Group_user.group_id WHERE (oa_right.mk_id = "+MkId+") AND (Group_user.user_id = "+UserId+")";
			bs=dataset_2(Rconn,Qsbs,"qs").Tables["qs"].Rows[0][0].ToString();

			try
			{
				RightString=dataset_2(Rconn,SQLstr,"right").Tables["right"].Rows[0][0].ToString();
				
			}
			catch
			{
			}
			finally
			{
				if(Rconn!=null)	Rconn.Dispose();
			}
			if(RightString.Length==0)
				RightString="0";
            return Convert.ToInt32(RightString.Trim());
		}
	public static DateTime GetInt_Date(string DateStr)
	{
		//把串型日期中的年、月、日取出，并以整型的形式输出,如果DateStr是正确的串型日期，函数反回 1 否则 反回 0
		//正确的串型日期：yyyy-mm-dd   yyyy-m-d(当月、日是单时)
		//string[] _tokens = _ClientCommand.Split(new Char[]{'|'});//把各个子子符串放入数据中
		string[] _Date = DateStr.Split (new char []{'-'});
		DateTime _NewDateTime = new DateTime (Convert.ToInt32 (_Date[0]),Convert.ToInt32 (_Date[1]),Convert.ToInt32 (_Date[2]));
			
		return _NewDateTime;

	}
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
		public static string GetString(string _TheString,string _PPstr)
		{
			//得到最后一个匹配的字符后的所有字符
			if(_PPstr.Trim().Length >0 && _TheString.Trim ().Length >1)
			{
				int i = _TheString.Trim ().LastIndexOf (_PPstr)+1;
				return _TheString.Trim ().Substring (i,_TheString.Trim ().Length -i);
			}
			else
				return "";
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
	}
}
