using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class regedit : System.Web.UI.Page
    {
        connectDb condb = new connectDb();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        int insertBussinessName(SqlConnection con,string username)
        {
            string insertbussiness = "insert into bussiness(username) values(@idname)";
            SqlCommand insertcmd2 = new SqlCommand(insertbussiness, con);
            insertcmd2.Parameters.AddWithValue("idname", username);
            int count=insertcmd2.ExecuteNonQuery();
            return count;
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            SqlConnection con = condb.GetConn();
            string id = IdTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();
            string phone = phoneTextBox.Text.Trim();
            string qq = qqTextBox.Text.Trim();
            string name = NameTextBox4.Text.Trim();
            string email = EmailTextBox.Text.Trim();
            string rolemode = null;

            if (MerdizeRadioButton.Checked)
                    rolemode = "商家";
            else
            {
                if (ConsultRadioButton.Checked)
                    rolemode = "咨询师";
                else 
                    rolemode = "求助者";
            }
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                string select = "select count(*) from login where username=@id";
                SqlCommand selectcmd = new SqlCommand(select, con);
                selectcmd.Parameters.AddWithValue("@id", id);
                int row = (int)selectcmd.ExecuteScalar();
                string insertsql = null;
                bool isAnswer = false;
                if (row == 0)
                {
                    insertsql = "INSERT INTO login(username,password,name,email,phone,QQ,rolemode,answerExam) VALUES (@idname,@password,@name,@email,@phone,@qq,@rolemode,@isAnswer)";                  
                    SqlCommand insertcmd = new SqlCommand(insertsql, con);                   
                    insertcmd.Parameters.AddWithValue("@idname", id);
                    insertcmd.Parameters.AddWithValue("@password", password);
                    insertcmd.Parameters.AddWithValue("@name", name);
                    insertcmd.Parameters.AddWithValue("@email", email);
                    insertcmd.Parameters.AddWithValue("@phone", phone);
                    insertcmd.Parameters.AddWithValue("@qq", qq);
                    insertcmd.Parameters.AddWithValue("@rolemode", rolemode);
                    insertcmd.Parameters.AddWithValue("@isAnswer", isAnswer);
                    int rowcount = insertcmd.ExecuteNonQuery();
                    if (rolemode == "商家")
                    {
                        int count = insertBussinessName(con,id);
                        if ((count == 1) && (rowcount == 1))
                        {
                           Response.Redirect("~/RegistSuccessful.html?username="+id,false);
                            return;
                        }
                    }
                    else if (rowcount == 1)
                    {
                        Response.Redirect("~/RegistSuccessful.html?username=" + id,false);
                        return;
                    }
                }
                    else
                    {
                        IdErrorLabel.Text = "对不起，您注册的用户名已存在！";
                        return;
                    }
                }
            catch (Exception ex)
            {
                IdErrorLabel.Text = "后台数据库连接错误，请联系系统管理员！";
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Server.Transfer("~/soulcastlefrontpage.html");
        //}

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue == "是")
                SaveButton.Enabled = true;
            else
                SaveButton.Enabled = false;
        }

        //protected void MerdizeRadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (MerdizeRadioButton.Checked)
        //    {
        //        MerImage.Visible = true;
        //        ConsultImage.Visible = false;
        //        HelperImage.Visible = false;
        //    }
        //}

        //protected void ConsultRadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (ConsultRadioButton.Checked)
        //    {
        //        MerImage.Visible = false;
        //        ConsultImage.Visible = true;
        //        HelperImage.Visible = false;
        //    }
        //}

        //protected void HelperRadioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (HelperRadioButton.Checked)
        //    {
        //        MerImage.Visible = false;
        //        ConsultImage.Visible = false;
        //        HelperImage.Visible = true;
        //    }
        //}
    }
}
