using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2.department
{
    public partial class detail1 : System.Web.UI.Page
    {
        DBHelper dbhelper = new DBHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            ////string role = Request["role"].ToString();
            string username = Request["username"].ToString();
            //string username = "consulter1";
            Literal1.Text = username;
            string adultperson = "select title,content1,time from adultperson where author=@username";
            SqlParameter[] para={new SqlParameter("@username",SqlDbType.NVarChar){Value=username}};
            DataTable tb1 = dbhelper.GetDataTable(adultperson, para);
            if (tb1.Rows.Count > 0)
            {
                adultPersonGridView.DataSource = tb1;
                adultPersonGridView.DataBind();
            }
            else
                adultPersonLiteral.Text = "暂时没有信息！";
            string adultGroup = "select title,content1,time from adultgroup where author=@username";
            DataTable tb2 = dbhelper.GetDataTable(adultGroup, para);
            if (tb2.Rows.Count > 0)
            {
                adultGroupGridView.DataSource = tb2;
                adultGroupGridView.DataBind();
            }
            else
                adultGroupLiteral.Text = "暂时没有信息！";
            string adultRoom = "select title,content1,time from adultroom where author=@username";
            DataTable tb3 = dbhelper.GetDataTable(adultRoom, para);
            if (tb3.Rows.Count > 0)
            {
                adultRoomGridView.DataSource = tb3;
                adultRoomGridView.DataBind();
            }
            else
                adultRoomLiteral.Text = "暂时没有信息！";
            string childrenPerson = "select title,content1,time from  childperson where author=@username";
            DataTable tb4 = dbhelper.GetDataTable(childrenPerson, para);
            if (tb4.Rows.Count > 0)
            {
                childrenPersonGridView.DataSource = tb4;
                childrenPersonGridView.DataBind();
            }
            else
                childrenPersonLiteral.Text = "暂时没有信息！";
            string childrenGroup = "select title,content1,time from  childgroup where author=@username";
            DataTable tb5 = dbhelper.GetDataTable(childrenGroup, para);
            if (tb5.Rows.Count > 0)
            {
                childrenGroupGridView.DataSource = tb5;
                childrenGroupGridView.DataBind();
            }
            else
                childrenGroupLiteral.Text = "暂时没有信息！";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "OK", "<script language=javascript>window.close();</script>");
            //Response.Write("<script>window.opener=null;window.close();</script>");
        }

        protected void adultRoomGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void prevButton_Click(object sender, EventArgs e)
        //{
        //    ClientScript.RegisterStartupScript(Page.GetType(), "", "<script language=javascript>history.go(-1);</script>");
        //}
    }
}