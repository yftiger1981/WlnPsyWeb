using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2.clients
{
    public partial class consulterSearch : System.Web.UI.Page
    {
        DBHelper DbHelper = new DBHelper();
        string username = null;
        string agegroup = null;
        string sel = null;
        protected void Page_Load(object sender, EventArgs e)
        {  
            if (!IsPostBack)
            {
                //if (Request["username"] != null)
                //{
                //    username = Request["username"].ToString();
                //    Session["username"] = username;
                //}   
                username = Session["username"].ToString();
                SqlParameter[] paras = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = username } };
                string sql = "select ageGroup from login where username=@username";
                agegroup = DbHelper.GetFieldValue(sql, paras).Trim();           
                if (agegroup == "C")
                {
                    sel = "select personality,photoPath from childHelper where username=@username";
                }
                else if (agegroup == "A")
                {
                    sel = "select personality,photoPath from adultHelper where username=@username";
                }
                string[] data = DbHelper.getReaderFields(sel, paras);
                if (data!=null&&data.Length>0)
                {
                    string personlity = data[0].ToString();
                    string imgPath = data[1].ToString();
                    if (imgPath ==string.Empty)
                    {
                        selImage.ImageUrl = "~/Images/helper-man.png";
                    }
                    else
                    {
                        selImage.ImageUrl = imgPath;
                    }

                    qizhiLabel.Text = personlity;
                    selImage.ImageUrl = imgPath;
                }    
            }
            username = Session["username"].ToString();
            userLabel.Text = username;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = null;
            username = Session["username"].ToString();
            string title = titleTextBox.Text.Trim();
            string content = contentTextBox.Text.Trim();
            DateTime time =DateTime.Now;
            sql = "insert into helperQuestion values (@title,@content,@time,@username)";        
            SqlParameter[] paras = { new SqlParameter("@title", SqlDbType.NVarChar) { Value = title }, new SqlParameter("@content", SqlDbType.NVarChar) { Value = content }, new SqlParameter("@time", SqlDbType.DateTime) { Value = time }, new SqlParameter("@username", SqlDbType.NVarChar) { Value = username } };
            int i=DbHelper.Execute(sql, paras);
            if (i == 1)
                Label1.Text = "您的问题已提交成功！";
            else
                Label1.Text = "您的问题提交失败！";
        }
    }
}