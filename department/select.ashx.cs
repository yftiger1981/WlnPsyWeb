using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace WebApplication2.department
{
    /// <summary>
    /// select 的摘要说明
    /// </summary>
    public class select : IHttpHandler
    {
        DBHelper dbhelper = new DBHelper();
        public void ProcessRequest(HttpContext context)
        {

            int pagesize=9;
            long count;
            //int pagenum=1;
            StringBuilder stringbuilder = new StringBuilder();
            int pagenum =Convert.ToInt32(context.Request["pagenum"].ToString());
            string role = context.Request["role"].ToString();
            int isLastPage=0;
            if (role == "consulter")
            {
                string sql = "select username,headPhoto,profession,prolevel,selfIntro,ROW_NUMBER() OVER(ORDER BY username) AS PagerAutoRowNumber from Consulter";
                string pagesql = dbhelper.GetPaerSql(sql, pagesize, pagenum, out count);
                if (pagenum * pagesize >= count)
                    isLastPage = 1;
                SqlDataReader reader = dbhelper.GetDataReader(pagesql);
                stringbuilder.Append("{\"consulters\":[");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string username = reader["username"].ToString();
                        //string headPhoto1 = reader["headPhoto"].ToString();
                        string headPhoto = reader["headPhoto"].ToString().Replace(@"~",@"..");
                        string profession = reader["profession"].ToString();
                        string prolevel = reader["prolevel"].ToString();
                        string selfIntro = reader["selfIntro"].ToString();
                        stringbuilder.Append("{");
                        stringbuilder.Append("\"username\"");
                        stringbuilder.Append(":");
                        stringbuilder.Append("\""+username+"\"");
                        stringbuilder.Append(",");
                        stringbuilder.Append("\"headPhoto\"");
                        stringbuilder.Append(":");
                        stringbuilder.Append("\"" + headPhoto + "\"");
                        stringbuilder.Append(",");
                        stringbuilder.Append("\"selfIntro\"");
                        stringbuilder.Append(":");
                        stringbuilder.Append("\"" + selfIntro + "\"");
                        stringbuilder.Append(",");
                        stringbuilder.Append("\"profession\"");
                        stringbuilder.Append(":");
                        stringbuilder.Append("\"" + profession + "\"");
                        stringbuilder.Append(",");
                        stringbuilder.Append("\"prolevel\"");
                        stringbuilder.Append(":");
                        stringbuilder.Append("\"" + prolevel + "\"");
                        stringbuilder.Append("},");
                    }
                    stringbuilder.Remove(stringbuilder.Length - 1,1);
					stringbuilder.Append("],");
					stringbuilder.Append("\"isLastPage\"");
                    stringbuilder.Append(":");
                    stringbuilder.Append(isLastPage);
                    stringbuilder.Append("}");
                }
            }
            else if (role == "bussiness")
            {
                string sql = "select login.username,login.phone,bussiness.Image1,bussiness.Intro1,ROW_NUMBER() OVER(ORDER BY login.username) AS PagerAutoRowNumber from login inner join bussiness on login.username=bussiness.username where rolemode='商家'";
                string pagesql = dbhelper.GetPaerSql(sql, pagesize, pagenum, out count);
                if (pagenum * pagesize >= count)
                    isLastPage = 1;
                SqlDataReader reader = dbhelper.GetDataReader(pagesql);
                stringbuilder.Append("{\"bussiness\":[");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string username = reader["username"].ToString();
                        //string sql2 = "select Image1,Intro1 from bussiness where username=@username";
                        //SqlParameter[] para = {new SqlParameter("@username",SqlDbType.NVarChar){Value=username}};
                        //SqlDataReader reader2 = dbhelper.GetDataReader(sql2,para);
                        string Img = reader["Image1"].ToString().Replace(@"~",@"..");
                        string intro = reader["Intro1"].ToString();
                        string phone = reader["phone"].ToString();
                        stringbuilder.Append("{");
                        stringbuilder.Append("\"username\"");
                        stringbuilder.Append(":");
                        stringbuilder.Append("\"" + username + "\"");
                        stringbuilder.Append(",");
                        stringbuilder.Append("\"Img\"");
                        stringbuilder.Append(":");
                        stringbuilder.Append("\"" + Img + "\"");
                        stringbuilder.Append(",");
                        stringbuilder.Append("\"intro\"");
                        stringbuilder.Append(":");
                        stringbuilder.Append("\"" + intro + "\"");
                        stringbuilder.Append(",");     
                        stringbuilder.Append("\"phone\"");
                        stringbuilder.Append(":");
                        stringbuilder.Append("\"" + phone + "\"");
                        stringbuilder.Append("},");
                    }
                    stringbuilder.Remove(stringbuilder.Length - 1, 1);
					stringbuilder.Append("],");
					stringbuilder.Append("\"isLastPage\"");
                    stringbuilder.Append(":");
                    stringbuilder.Append(isLastPage);
                    stringbuilder.Append("}");
                }
            }
            context.Response.ContentType = "application/json";
            context.Response.Write(stringbuilder);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}