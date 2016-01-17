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
    public partial class bussinessDetail : System.Web.UI.Page
    {
        DBHelper dbhelper = new DBHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Request["username"].ToString();
            Literal1.Text = username;
            string adultperson = "select title,content1,time from adultperson where author=@username";
            SqlParameter[] para = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = username } };
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

            string familyAct = "select title,content1,time from famActivity where author=@username";
            DataTable tb3 = dbhelper.GetDataTable(familyAct, para);
            if (tb3.Rows.Count > 0)
            {
                familyActGridView.DataSource = tb3;
                familyActGridView.DataBind();
            }
            else
                familyActLiteral.Text = "暂时没有信息！";
            string childrenGroup = "select title,content1,time from  childgroup where author=@username";
            DataTable tb4 = dbhelper.GetDataTable(childrenGroup, para);
            if (tb4.Rows.Count > 0)
            {
                childrenGroupGridView.DataSource = tb4;
                childrenGroupGridView.DataBind();
            }
            else
                childrenGroupLiteral.Text = "暂时没有信息！";

            string childrenEmo = "select title,content1,time from  childfeeling where author=@username";
            DataTable tb5 = dbhelper.GetDataTable(childrenEmo, para);
            if (tb5.Rows.Count > 0)
            {
                childrenEmotionGridView.DataSource = tb5;
                childrenEmotionGridView.DataBind();
            }
            else
                childrenEmotionLiteral.Text = "暂时没有信息！";

            string childrenAct = "select title,content1,time from  childActivity where author=@username";
            DataTable tb6 = dbhelper.GetDataTable(childrenAct, para);
            if (tb6.Rows.Count > 0)
            {
                childrenActGridView.DataSource = tb6;
                childrenActGridView.DataBind();
            }
            else
                childrenActLiteral.Text = "暂时没有信息！";


        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "", "<script language=javascript>window.opener=null;window.open('','_self');window.close(); </script>");
        }
    }
}