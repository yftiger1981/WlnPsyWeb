using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        DBHelper dbhelper = new DBHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangePassword1_CancelButtonClick(object sender, EventArgs e)
        {
            Server.Transfer("/login.aspx");
        }


        protected void ChangePasswordPushButton_Click(object sender, EventArgs e)
        {

            string username = userNameTextBox.Text.Trim();
            string oldpassword = CurrentPassword.Text.Trim();
            string newpassword = NewPassword.Text.Trim();
            string sql= "select password from login where username=@username";
            SqlParameter[] paras = {new SqlParameter("@username",SqlDbType.NVarChar){Value=username}};
            SqlDataReader reader = dbhelper.GetDataReader(sql, paras); ;
            if (reader.Read())
            {
                string password = reader["password"].ToString();
                reader.Close();
                if (password == oldpassword)
                {

                    string updatestr = "update login set password=@newpassword where username=@username";
                    SqlParameter[] paras2 = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = username }, new SqlParameter("@newpassword", SqlDbType.VarChar) { Value = newpassword } };
                    int count = dbhelper.Execute(updatestr, paras2);
                    if (count == 1)
                    {
                        FailureText.Text = "密码修改成功!";
                        return;
                    }
                    else
                    {
                        FailureText.Text = "密码修改失败！";
                        return;
                    }
                }
                else
                {
                    FailureText.Text = "密码错误！";
                    return;
                }
            }
        }

        protected void CancelPushButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("/login.aspx");
        }

        protected void CancelPushButton_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/login.aspx",false);
        }

        
    }
}