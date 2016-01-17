using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2.consulters
{
    public partial class contentsList : System.Web.UI.Page
    {
        DBHelper dbhelper = new DBHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            //string username = TextBox1.Text.Trim();
            //if (username != null)
            //{
            //    string sql = "select * from helperQuestion where author=@username";
            //    SqlParameter[] paras = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = username } };
            //    DataTable table1 = dbhelper.GetDataTable(sql, paras);
            //    GridView1.DataSource = table1;
            //    GridView1.DataBind();
            //}
            GridView1.Visible = false;
            GridView3.Visible = true;
        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                GridView1.Visible = true;
                GridView3.Visible = false;
            }
            else
            {
                GridView1.Visible = false;
                GridView3.Visible = true;
            }
        }
    }
}