using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApplication2
{
    public partial class consult : System.Web.UI.Page
    {
        DBHelper dbheler=new DBHelper();
        DataTable adults = new DataTable();
        DataTable children = new DataTable();
 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["username"] = "fan";
                string consultername = Session["username"].ToString();
                ConsulterName.Text = consultername;
                string sql = "select login.ageGroup,login.username from login  inner join  userConsulterRelation on login.username=userConsulterRelation.helperUserName  where userConsulterRelation.consulterUserName=@consulterusername";
                SqlParameter[] paras = {new SqlParameter("@consulterusername",SqlDbType.NVarChar){Value=consultername}};
                SqlDataReader reader = dbheler.GetDataReader(sql,paras);
                string select = null;
                while (reader.Read())
                {
                    string ageGroup =  reader[0].ToString().Trim();
                    string username = reader[1].ToString().Trim();
                    SqlParameter[] paras2 = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = username } };
                    SqlDataReader reader2;
                    if (ageGroup.IndexOf('C')==0)
                    {
                        select = "select login.phone,login.QQ,login.email,* from childHelper inner join login on login.username=childHelper.username  where login.username=@username";
                        reader2 = dbheler.GetDataReader(select,paras2);
                        children.Load(reader2);
                    }
                    else
                    {
                        select = "select login.phone,login.QQ,* from adultHelper  inner join login on login.username=adultHelper.username where login.username=@username";
                        reader2 = dbheler.GetDataReader(select, paras2);
                        adults.Load(reader2);                     
                    }
                }
                this.adultGridView.DataSource = adults;
                this.adultGridView.DataBind();
                childGridView.DataSource =children;
                childGridView.DataBind();
                if (adults.Rows.Count == 0)
                    adultLiteral.Text = "暂时没有成人求助者选择你！";
                if (children.Rows.Count == 0)
                    childLiteral.Text = "暂时没有儿童求助者选择你！";
            }
        }

    }
}