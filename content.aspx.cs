using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;


namespace WebApplication2.adultsystem
{
    public partial class content : System.Web.UI.Page
    {
        connectDb db=new connectDb();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string pervurl = Request.UrlReferrer.ToString();
                string uids = Request.QueryString["uid"];
                string tablename=Request.QueryString["tablename"];
                Guid uid = new Guid(uids);
                ViewState["prevpage"] = pervurl;
                string sql = "select * from "+tablename+" where uid=@uid";
                using (SqlConnection con = db.GetConn())
                {
                    try
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        SqlCommand cmd = new SqlCommand(sql, con);
                        cmd.Parameters.Add("@uid", SqlDbType.UniqueIdentifier).Value = uid;
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            string title = reader["title"].ToString();
                            string content = reader["content1"].ToString();
                            string author = reader["author"].ToString();
                            string time = reader["time"].ToString();
                            string shotTime = time.Split(' ')[0];
                            titlelabel.Text = title;
                            contentLiteral.Text = content;
                            authorLiteral.Text = "作者：" + " " + author;
                            timeLiteral.Text = shotTime;
                        }
                    }
                    catch (Exception e1)
                    {
                        Label1.Text = "信息读取失败！";
                        return;
                    }

                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pervurl = ViewState["prevpage"].ToString();
            Response.Redirect(pervurl);
        }
    }
}