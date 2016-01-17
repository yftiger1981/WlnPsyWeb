using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace WebApplication2
{
    class ExcelHelper
    {
       
        #region 上传任何文件

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="PostFile">FileUpLoad控件</param>
        /// <param name="UpLoadPath">传入文件保存路径，如：/UpLoadFile/excel/  返回文件绝对路径，如：/UpLoadFile/excel/a.xls</param>
        /// <param name="FileFormat">文件后缀，如：.xls</param>
        /// <returns>文件名称，如a.xls</returns>
        /// 
        public static string UploadFile(HttpPostedFile PostFile, ref string UpLoadPath, ref string FileFormat)
        {
            try
            {
                string savepath = HttpContext.Current.Server.MapPath(UpLoadPath);
                if (!Directory.Exists(savepath))
                    Directory.CreateDirectory(savepath);

                string ext = Path.GetExtension(PostFile.FileName);
                string filename = CreateIDCode() + ext;
                if (UpLoadPath.IndexOf(ext) == -1) //判断
                {
                    savepath = savepath + filename;
                }
                PostFile.SaveAs(savepath);
                UpLoadPath = UpLoadPath+filename;
                FileFormat = ext;
                return filename;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string CreateIDCode()
        {
            DateTime Time1 = DateTime.Now.ToUniversalTime();
            DateTime Time2 = Convert.ToDateTime("1970-01-01");
            TimeSpan span = Time1 - Time2;   //span就是两个日期之间的差额   
            string t = span.TotalMilliseconds.ToString("0");
            return t;
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="PostFile">FileUpLoad控件</param>
        /// <param name="UpLoadPath">传入文件保存路径，如：/UpLoadFile/excel/  返回文件绝对路径，如：/UpLoadFile/excel/a.xls</param>
        /// <param name="FileFormat">文件后缀，如：.xls</param>
        /// <returns>文件名称，如a.xls</returns>
        public static string UploadFile(HttpPostedFile PostFile, ref string UpLoadPath)
        {
            try
            {
                UpLoadPath += DateTime.Now.Year + "/" + DateTime.Now.Month;
                string savepath = HttpContext.Current.Server.MapPath(UpLoadPath);
                if (!Directory.Exists(savepath))
                {
                    Directory.CreateDirectory(savepath);
                }

                string ext = Path.GetExtension(PostFile.FileName);
                string filename = CreateIDCode() + ext;
                if (UpLoadPath.IndexOf(ext) == -1) //判断
                {
                    savepath = savepath + filename;
                }
                PostFile.SaveAs(savepath);

                UpLoadPath += filename;

                return filename;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        /// <summary>
        /// 获得Excel数据集
        /// </summary>
        /// <param name="filepath">文件路径（绝对路径+文件名称+格式）</param>
        /// <param name="fileFormat">文件格式【.xls 或 .xlsx】</param>
        /// <param name="strw">查询条件【已有 where 1 = 1 需加 and】</param>
        /// <returns>DataSet数据集</returns>
        public static DataSet GetExcelData(string filepath, string xlsTabName = "Sheet1", string fileFormat = ".xls", string strw = "")
        {
            DataSet set3;
            string excelSheet = xlsTabName;
            string str = fileFormat == ".xls" ? "Provider=Microsoft.Jet.OLEDB.4.0;" : "Provider=Microsoft.ACE.OLEDB.12.0;";
            OleDbConnection selectConnection = new OleDbConnection(str + "Data Source=" + filepath + ";Extended Properties='Excel 8.0;HDR=YES;IMEX=1'");
            try
            {
                selectConnection.Open();
                object[] restrictions = new object[4];
                restrictions[3] = "TABLE";
                DataTable oleDbSchemaTable = selectConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);
                bool flag = false;
                bool flag2 = false;
                foreach (DataRow row in oleDbSchemaTable.Rows)
                {
                    if (row["TABLE_NAME"].ToString().ToUpper() == (excelSheet.ToUpper() + "$"))
                    {
                        flag = true;
                        break;
                    }
                    if (row["TABLE_NAME"].ToString().ToUpper() == ("'" + excelSheet.ToUpper() + "$'"))
                    {
                        flag2 = true;
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    throw new Exception("未找到名称匹配的数据表格，模板数据表格名称为：【" + excelSheet + "】");
                }
                OleDbDataAdapter adapter = new OleDbDataAdapter(string.Format("SELECT * FROM [" + (flag2 ? ("'" + excelSheet + "$'") : (excelSheet + "$")) + "] where 1 = 1 " + strw, new object[0]), selectConnection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                selectConnection.Close();
                if ((dataSet == null) || (dataSet.Tables.Count == 0))
                {
                    throw new Exception("读取Excel数据时出错：Excel文件无有效工作表。");
                }
                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    throw new Exception("读取Excel数据时出错：Excel工作表数据为空。");
                }
                set3 = dataSet;
            }
            catch (Exception exception)
            {
                //throw new Exception("导入Excel数据时发生无法预计的错误。", exception);
                throw new Exception(exception.Message.ToString(), exception);
            }
            finally
            {
                selectConnection.Close();
            }
            return set3;
        }

        /// <summary>
        /// 导出含标题样式的Excel
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="FileName">文件名</param>
        public static void CreateExcel(DataTable dataTable, string FileName,StringBuilder title,string bodyTr,string bodyTd,StringBuilder end)
        {
            if (dataTable != null && !dataTable.Equals(null))
            {
                //////////body 数据部分
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    title.Append(bodyTr);
                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        title.Append(bodyTd + dataTable.Rows[i][j].ToString() + "</td>");
                    }
                    title.Append("</tr>");
                }
                //////////////
                title.Append(end.ToString());
                HttpResponse resp = System.Web.HttpContext.Current.Response;
                resp.ClearContent();
                resp.ContentEncoding = System.Text.Encoding.Default;
                resp.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
                resp.ContentType = "application/excel";
                resp.Write(title);
                resp.End(); 
            }
        }
        /// <summary>
        /// 导出Excel
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <param name="FileName">文件名</param>
        public static void CreateExcel(DataTable dt, string FileName)
        {

            HttpResponse resp = System.Web.HttpContext.Current.Response;
            resp.ClearContent();
            resp.ContentEncoding = System.Text.Encoding.Default;
            resp.AppendHeader("Content-Disposition", "attachment;filename=" + FileName);
            resp.ContentType = "application/excel";
            string colHeaders = "", ls_item = "";

            //定义表对象与行对象，同时用DataSet对其值进行初始化 
            DataRow[] myRow = dt.Select();//可以类似dt.Select("id>10")之形式达到数据筛选目的
            int i = 0;
            int cl = dt.Columns.Count;

            //取得数据表各列标题，各标题之间以t分割，最后一个列标题后加回车符 
            for (i = 0; i < cl; i++)
            {
                if (i == (cl - 1))//最后一列，加n
                {
                    colHeaders += dt.Columns[i].Caption.ToString() + "\n";
                }
                else
                {
                    colHeaders += dt.Columns[i].Caption.ToString() + "\t";
                }

            }
            resp.Write(colHeaders);
            //向HTTP输出流中写入取得的数据信息 

            //逐行处理数据   
            foreach (DataRow row in myRow)
            {
                //当前行数据写入HTTP输出流，并且置空ls_item以便下行数据     
                for (i = 0; i < cl; i++)
                {
                    if (i == (cl - 1))//最后一列，加n
                    {
                        ls_item += row[i].ToString() + "\n";
                    }
                    else
                    {
                        ls_item += row[i].ToString() + "\t";
                    }

                }
                resp.Write(ls_item);
                ls_item = "";

            }
            resp.End();
        }
    }
}
