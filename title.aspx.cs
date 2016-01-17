using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class title : System.Web.UI.Page
    {
        DBHelper dbHelper = new DBHelper();
        string tablename = null;
        string subTitle = null;
        DataSet set = null;
        PagedDataSource pds = new PagedDataSource();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //tablename = "adultperson";
                tablename = Request["tablename"].ToString();
                ViewState["tablename"] = tablename;
                string sql = "select title,author,time,uid from "+tablename+" order by time desc";
                set = dbHelper.GetDataSet(sql);
                ViewState["dataset"] = set;
                pds.DataSource = set.Tables[0].DefaultView;
                pds.AllowPaging = true;
                pds.PageSize = AspNetPager1.PageSize;
                pds.CurrentPageIndex = 0;
                this.AspNetPager1.RecordCount = set.Tables[0].Rows.Count;
                //GridView1.PageCount = pds.PageCount;
                GridView1.DataSource =pds;
                GridView1.DataBind();
                switch (tablename)
                { 
                    case "adultperson":
                        subTitle = "成人个体帮助";
                        break;
                    case "adultgroup":
                        subTitle = "成人团体帮助";
                        break;
                    case "adultroom":
                        subTitle = "成人咨询室";
                        break;
                    case "childActivity":
                        subTitle = "儿童活动帮助";
                        break;
                    case "childfeeling":
                        subTitle = "儿童情感帮助";
                        break;
                    case "childgroup":
                        subTitle = "儿童团体帮助";
                        break;
                    case "childperson":
                        subTitle = "儿童个体帮助";
                        break;
                    case "famActivity":
                        subTitle = "家庭活动帮助";
                        break;
                }
                ViewState["subTitle"] = subTitle;
            }
                
                titleLiteral.Text = subTitle;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            tablename = ViewState["tablename"].ToString();
            string uids = ((Label)row.FindControl("uid")).Text;
            Guid uid = new Guid(uids);
            string urlLink = "~/content.aspx?uid=" + uid + "&tablename="+tablename;
            Response.Redirect(urlLink);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string username = Session["username"].ToString();
            //string role = Session["role"].ToString();
            Response.Redirect("~/consulters/registSuccess.aspx");
        }

        protected void GridView1_PageIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //int pageindex = e.NewPageIndex;
            //pds.CurrentPageIndex = pageindex;
            //GridView1.DataSource = pds;
            //GridView1.DataBind();

        }
        private void DatasBind()
        {
            tablename=ViewState["tablename"].ToString();
            string sql = "select title,content1,author,uid,time from " + tablename;
            set = dbHelper.GetDataSet(sql);        
            pds.DataSource = set.Tables[0].DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = AspNetPager1.PageSize;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            GridView1.DataSource = pds;
            GridView1.DataBind();
            string title = ViewState["subTitle"].ToString();
            titleLiteral.Text = title;

        } 
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            DatasBind(); 
        }

      
    }
}