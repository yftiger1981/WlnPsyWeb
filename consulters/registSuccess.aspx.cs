using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;


namespace WebApplication2.consulters
{
    public partial class registSuccess : System.Web.UI.Page
    {
        DBHelper dbhelper = new DBHelper();
        connectDb db = new connectDb();
        string username = null;
        string role = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Session["username"] = "consulter2";
                //Session["role"] = "咨询师";
                username = Session["username"].ToString();
                role = Session["role"].ToString();
                nameLabel.Text = username;
                if (username != null && role != null)
                {
                    if (role == "咨询师")
                    {
                        RadioButton1.Enabled = true;
                        RadioButton2.Enabled = true;
                        RadioButton3.Enabled = true;
                        RadioButton4.Enabled = false;
                        RadioButton5.Enabled = true;
                        RadioButton6.Enabled = true;
                        RadioButton7.Enabled = false;
                        RadioButton8.Enabled = false;
                        consulterButton.Visible = true;
                        string sql = "select headPhoto from Consulter where username=@username";
                        SqlParameter[] para = {new SqlParameter("@username",SqlDbType.NVarChar){Value=username} };
                        SqlDataReader reader = dbhelper.GetDataReader(sql, para);
                        if (reader.Read())
                        {
                            string ImgPath = reader[0].ToString();
                            if (ImgPath != string.Empty)
                                Image1.ImageUrl = ImgPath;
                            else
                                Image1.ImageUrl = "~/Images/consulter.png";
                        }      

                    }
                    else
                        if (role == "商家")
                        {
                            RadioButton1.Enabled = true;
                            RadioButton2.Enabled = true;
                            RadioButton3.Enabled = false;
                            RadioButton4.Enabled = true;
                            RadioButton5.Enabled = false;
                            RadioButton6.Enabled = true;
                            RadioButton7.Enabled = true;
                            RadioButton8.Enabled = true;
                            addActivityButton.Visible = true;
                            Image1.Visible = false;
                        }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string title = titleTextBox.Text.Trim();
            if (title == string.Empty)
            {
                titleLiteral.Text = "标题不能为空！";
                return;
            }
            string content = contentTextBox.Text.Trim();
            if (content == string.Empty)
            {
                contentLiteral.Text = "内容不能为空！";
                return;
            }
            username = Session["username"].ToString();
            role = Session["role"].ToString();
            string url = null;
            DateTime now = DateTime.Now;
            Guid uid = Guid.NewGuid();
            string sql = null;
            if (RadioButton1.Enabled && RadioButton1.Checked)
            {
                sql = "insert into adultperson(title,content1,author,time,uid) values (@title,@content,@author,@time,@uid)";
                url = "~/title.aspx?tablename=adultperson";
            }
            else if (RadioButton2.Enabled && RadioButton2.Checked)
            {
                sql = "insert into adultgroup(title,content1,author,time,uid) values (@title,@content,@author,@time,@uid)";
                url = "~/title.aspx?tablename=adultgroup";
            }
            else if (RadioButton3.Enabled && RadioButton3.Checked)
            {
                sql = "insert into adultroom(title,content1,author,time,uid) values (@title,@content,@author,@time,@uid)";
                url = "~/title.aspx?tablename=adultroom";
            }

            else if (RadioButton4.Enabled && RadioButton4.Checked)
            {
                sql = "insert into famActivity(title,content1,author,time,uid) values (@title,@content,@author,@time,@uid)";
                //url = "/adultsystem/familiyActivity.aspx";
                url = "~/title.aspx?tablename=famActivity";
            }
            else if (RadioButton5.Enabled && RadioButton5.Checked)
            {
                sql = "insert into childPerson(title,content1,author,time,uid) values (@title,@content,@author,@time,@uid)";
                //url = "/childsystem/childPersonHelp.aspx";
                url = "~/title.aspx?tablename=childPerson";
            }
            else if (RadioButton6.Enabled && RadioButton6.Checked)
            {
                sql = "insert into childgroup(title,content1,author,time,uid) values (@title,@content,@author,@time,@uid)";
                //url =  "/childsystem/childGroupHelp.aspx";
                url = "~/title.aspx?tablename=childgroup";
            }
            else if (RadioButton7.Enabled && RadioButton7.Checked)
            {
                sql = "insert into childfeeling(title,content1,author,time,uid) values (@title,@content,@author,@time,@uid)";
                //url = "/childsystem/childEmotionHelp.aspx";
                url = "~/title.aspx?tablename=childfeeling";
            }
            else if (RadioButton8.Enabled && RadioButton8.Checked)
            {
                sql = "insert into childActivity(title,content1,author,time,uid) values (@title,@content,@author,@time,@uid)";
                //url = "/childsystem/childEntertainmentActivity.aspx";
                url = "~/title.aspx?tablename=childActivity";
            }
            SqlConnection con = db.GetConn();
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@title", title), new SqlParameter("@content", content), new SqlParameter("@author", username), new SqlParameter("@time", now), new SqlParameter("@uid", uid) };
                cmd.Parameters.AddRange(paras);
                int i = cmd.ExecuteNonQuery();
                if (i == 1)
                    Label2.Text = "活动发布成功";
                Response.Redirect(url);
            }
            catch (Exception e1)
            {
                Label2.Text = e1.Message.ToString();
                return;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
           
            string role = Session["role"].ToString();
            if (role == "商家")
                Response.Redirect("/bussiness/bussinessModify.aspx");
            else if(role=="咨询师")
                Response.Redirect("/consulters/consulterModify.aspx");
        }

        protected void addActivityButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/bussiness/bussinessAddActivity.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("/consulters/consulter.aspx");
        }
    }
}