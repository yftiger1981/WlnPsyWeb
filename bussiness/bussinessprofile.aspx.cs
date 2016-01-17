using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class bussinessprofile : System.Web.UI.Page
    {
        string timespan = null;
        connectDb condb = new connectDb();
        DBHelper dbhelper = new DBHelper();
        PagedDataSource pds1 = new PagedDataSource();
        PagedDataSource pds2 = new PagedDataSource();
        PagedDataSource pds3= new PagedDataSource();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView2.DataSource = null;
            GridView3.DataSource = null;
            pds1.AllowPaging = true;
            pds1.PageSize = AspNetPager1.PageSize;
            pds2.AllowPaging = true;
            pds2.PageSize = AspNetPager2.PageSize;
            pds3.AllowPaging = true;
            pds3.PageSize = AspNetPager3.PageSize;
        }

  

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                SqlConnection conn = condb.GetConn();
                timespan = RadioButtonList1.SelectedValue;
                try
                {
                if (timespan == "week")
                {
                    string weekselect1 = "select username,Image1,Intro1 from bussiness where Time1 Between @weekago And @now ";
                    string weekselect2 = "select username,Image2,Intro2 from bussiness where Time2 Between @weekago And @now ";
                    string weekselect3 = "select username,Image3,Intro3 from bussiness where Time3 Between @weekago And @now ";
                    TimeSpan time = new TimeSpan(7, 0, 0, 0);
                    string now = DateTime.Now.Date.ToShortDateString();
                    string weekago = (DateTime.Now - time).Date.ToShortDateString();
                    SqlCommand cmd1 = new SqlCommand(weekselect1, conn);
                    cmd1.Parameters.AddWithValue("@now", now);
                    cmd1.Parameters.AddWithValue("@weekago", weekago);
                    SqlDataReader reader = cmd1.ExecuteReader();
                    DataTable tb1 = new DataTable();
                    DataColumn col1 = new DataColumn("username");
                    DataColumn col2 = new DataColumn("Image1");
                    DataColumn col3 = new DataColumn("Intro1");
                    tb1.Columns.Add(col1);
                    tb1.Columns.Add(col2);
                    tb1.Columns.Add(col3);
                    while (reader.Read())
                    {
                        DataRow row1 = tb1.NewRow();
                        string username = reader[0].ToString();
                        string imgurl = reader[1].ToString();
                        row1[0] = username;
                        row1[1] = HttpUtility.UrlDecode(imgurl);
                        row1[2] = HttpUtility.UrlDecode(reader[2].ToString());
                        tb1.Rows.Add(row1);
                    }
                    pds1.DataSource = tb1.DefaultView;
                    pds1.CurrentPageIndex = 0;
                    this.AspNetPager1.RecordCount = tb1.Rows.Count;
                    GridView1.DataSource = pds1;
                    GridView1.DataBind();
                    reader.Close();
                    SqlCommand cmd2 = new SqlCommand(weekselect2, conn);
                    cmd2.Parameters.AddWithValue("@now", now);
                    cmd2.Parameters.AddWithValue("@weekago", weekago);
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    DataTable tb2 = new DataTable();
                    DataColumn col21 = new DataColumn("username");
                    DataColumn col22 = new DataColumn("Image2");
                    DataColumn col23 = new DataColumn("Intro2");
                    tb2.Columns.Add(col21);
                    tb2.Columns.Add(col22);
                    tb2.Columns.Add(col23);
                    while (reader2.Read())
                    {
                        DataRow row1 = tb2.NewRow();
                        string username = reader2[0].ToString();
                        string imgurl = reader2[1].ToString();
                        row1[0] = username;
                        row1[1] = HttpUtility.UrlDecode(imgurl);
                        row1[2] =HttpUtility.UrlDecode(reader2[2].ToString());
                        tb2.Rows.Add(row1);
                    }
                    pds2.DataSource = tb2.DefaultView;
                    pds2.CurrentPageIndex = 0;
                    this.AspNetPager2.RecordCount = tb2.Rows.Count;
                    GridView2.DataSource = pds2;
                    GridView2.DataBind();
                    reader2.Close();
                    SqlCommand cmd3 = new SqlCommand(weekselect3, conn);
                    cmd3.Parameters.AddWithValue("@now", now);
                    cmd3.Parameters.AddWithValue("@weekago", weekago);
                    SqlDataReader reader3 = cmd3.ExecuteReader();
                    DataTable tb3 = new DataTable();
                    DataColumn col31 = new DataColumn("username");
                    DataColumn col32 = new DataColumn("Image3");
                    DataColumn col33 = new DataColumn("Intro3");
                    tb3.Columns.Add(col31);
                    tb3.Columns.Add(col32);
                    tb3.Columns.Add(col33);
                    while (reader3.Read())
                    {

                        DataRow row1 = tb3.NewRow();
                        string username = reader3[0].ToString();
                        string imgurl = reader3[1].ToString();
                        row1[0] = username;
                        row1[1] = HttpUtility.UrlDecode(imgurl);
                        row1[2] = HttpUtility.UrlDecode(reader3[2].ToString());
                        tb3.Rows.Add(row1);
                    }
                    pds3.DataSource = tb3.DefaultView;
                    pds3.CurrentPageIndex = 0;
                    this.AspNetPager3.RecordCount = tb3.Rows.Count;
                    GridView3.DataSource = pds3;
                    GridView3.DataBind();

                }
                if (timespan == "month")
                {
                    string monthselect1 = "select username,Image1,Intro1 from bussiness where Time1 Between  @monthago And  @now";
                    string monthselect2 = "select username,Image2,Intro2 from bussiness where Time2 Between  @monthago And  @now";
                    string monthselect3 = "select username,Image3,Intro3 from bussiness where Time3 Between  @monthago And  @now";
                    TimeSpan time = new TimeSpan(30, 0, 0, 0);
                    string now = DateTime.Now.Date.ToShortDateString();
                    string monthago = (DateTime.Now - time).Date.ToShortDateString();
                    SqlCommand cmd1 = new SqlCommand(monthselect1, conn);
                    cmd1.Parameters.AddWithValue("@now", now);
                    cmd1.Parameters.AddWithValue("@monthago", monthago);
                    SqlDataAdapter adt1 = new SqlDataAdapter(cmd1);
                    SqlCommand cmd2 = new SqlCommand(monthselect2, conn);
                    cmd2.Parameters.AddWithValue("@now", now);
                    cmd2.Parameters.AddWithValue("@monthago", monthago);
                    SqlDataAdapter adt2 = new SqlDataAdapter(cmd2);
                    SqlCommand cmd3 = new SqlCommand(monthselect3, conn);
                    cmd3.Parameters.AddWithValue("@now", now);
                    cmd3.Parameters.AddWithValue("@monthago", monthago);
                    SqlDataAdapter adt3 = new SqlDataAdapter(cmd3);
                    DataSet set1 = new DataSet();
                    adt1.Fill(set1, "monthago1");
                    adt2.Fill(set1, "monthago2");
                    adt3.Fill(set1, "monthago3");
                    GridView1.DataSource = set1.Tables["monthago1"];
                    GridView1.DataBind();
                    GridView2.DataSource = set1.Tables["monthago2"];
                    GridView2.DataBind();
                    GridView3.DataSource = set1.Tables["monthago3"];
                    GridView3.DataBind();
                }
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            string begin =TextBox1.Text.ToString();
            string end = TextBox2.Text.ToString();
            string select1 = "select username,Image1,Intro1 from bussiness where Time1 Between @begin And @end";
            string select2 = "select username,Image2,Intro2 from bussiness where Time2 Between @begin And @end ";
            string select3 = "select username,Image3,Intro3 from bussiness where Time3 Between @begin And @end ";
            SqlParameter[] paras1 = {new SqlParameter("@begin",SqlDbType.VarChar){Value=begin},new SqlParameter("@end",SqlDbType.VarChar){Value=end}};
            DataTable table1 = dbhelper.GetDataTable(select1,paras1);
            DataTable table2 = dbhelper.GetDataTable(select2,paras1);
            DataTable table3 = dbhelper.GetDataTable(select3, paras1);
            GridView1.DataSource = table1;
            GridView1.DataBind();
            GridView2.DataSource = table2;
            GridView2.DataBind();
            GridView3.DataSource = table3;
            GridView3.DataBind();
        }

        protected void AspNetPager2_PageChanged(object sender, EventArgs e)
        {

        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {

        }

        protected void AspNetPager3_PageChanged(object sender, EventArgs e)
        {

        }
    }
}