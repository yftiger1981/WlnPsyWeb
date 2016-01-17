using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login2 : IHttpHandler
    {
        connectDb db = new connectDb();
        public void ProcessRequest(HttpContext context)
        {
            string userID = context.Request.Form["Login1_UserName"].ToString();
            string password = context.Request.Form["Login1_Password"].ToString();
            //string userID = context.Request["username"].ToString();
            //string password = context.Request["password"].ToString();
            SqlConnection con = db.GetConn();
            string sql = "select count(*) from login where username=@userID and password=@password";
            SqlParameter[] paras={new SqlParameter("@userID",SqlDbType.Text){Value=userID},new SqlParameter("@password",SqlDbType.Char){Value=password}};
            using (con)
            {
                SqlCommand cmd = new SqlCommand(sql,con);
                int count = Int32.Parse(db.ExecuteScalar(sql));
                if (count == 1)
                {
                    string sel = "select username,rolemode from login where username=@userID";
                    SqlParameter[] paras2 = { new SqlParameter("@userID", SqlDbType.Text) { Value = userID } };
                    SqlDataReader reader = db.GetDataReader(sel, paras2);
                    string name = reader["username"].ToString();
                    string role = reader["rolemode"].ToString();
                    if (role == "商家"||role == "咨询师")
                    {
                        context.Response.Redirect("/consulters/registSuccess.aspx?username="+name);
                        return;
                    }
                    else if (role == "求助者")
                    {
                        context.Response.Redirect("/clients/helperRegistSuc.aspx?password="+password);
                        return;
                    }
                }
                else
                {
                    context.Response.ContentType = "text/plain";
                    context.Response.Write("不存在的用户名和密码！");
                    return;
                }
            }   
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