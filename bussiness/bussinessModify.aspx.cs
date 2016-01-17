using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace WebApplication2.bussiness
{
    public partial class bussinessModify : System.Web.UI.Page
    {
        DBHelper dbHelper = new DBHelper();
        string username = null;
        //string[] array = null;
        void dataBind()
        {
            
            string username = Session["username"].ToString();
            string sql = "select name,password,email,phone,QQ from login where username=@username ";
            SqlParameter[] paras = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = username } };
            using (SqlConnection cn = new SqlConnection(dbHelper.ConnectionString))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddRange(paras);
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataSet set = new DataSet();
                adp.Fill(set);
                GridView1.DataSource = set;
                GridView1.DataBind();
            }
        
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           nameLabel.Text = Session["username"].ToString(); ;
           if(!IsPostBack) 
           {
               //Session["username"] = "b1";
               username = Session["username"].ToString();
               //string username = "b1";
               string sql = "select name,password,email,phone,QQ from login where username=@username ";
               SqlParameter[] paras={new SqlParameter("@username",SqlDbType.NVarChar){Value=username}};
               using (SqlConnection cn = new SqlConnection(dbHelper.ConnectionString))
               {
                   cn.Open();
                   SqlCommand cmd=new SqlCommand(sql,cn);
                   cmd.Parameters.AddRange(paras);
                   SqlDataAdapter adp = new SqlDataAdapter(cmd);
                   DataSet set=new DataSet();
                   adp.Fill(set);
                   GridView1.DataSource = set;
                   GridView1.DataBind();
               }
               
           }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            dataBind();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            username = Session["username"].ToString();
            string name = ((TextBox)GridView1.Rows[e.RowIndex].Cells[0].Controls[0]).Text.ToString();
            string password = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString();
            string email = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString();
            string phone = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString();
            string QQ = ((TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString();
            string update = "update login set name=@name,password=@password,email=@email,phone=@phone,QQ=@QQ where username=@username";
            SqlParameter[] paras = { new SqlParameter("@name", SqlDbType.NVarChar) { Value = name }, new SqlParameter("@password", SqlDbType.NVarChar) { Value =password }, new SqlParameter("@email", SqlDbType.NVarChar) { Value = email }, new SqlParameter("@phone", SqlDbType.NVarChar) { Value = phone}, new SqlParameter("@QQ", SqlDbType.NVarChar) { Value = QQ }, new SqlParameter("@username", SqlDbType.NVarChar) { Value = username } };
            int i=dbHelper.Execute(update, paras);
            if (i == 1)
                Label2.Text = "数据修改成功！";
            else
                Label2.Text = "数据修改失败！";
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            dataBind();
        }

        protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            //GridView1.EditIndex = -1;
            //dataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            username = Session["username"].ToString();
            string role = "商家";
            Response.Redirect("~/consulters/registSuccess.aspx?username="+username+"&role="+role);
        }


    }
}