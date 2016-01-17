using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using jmail;

namespace WebApplication2
{
    public partial class Passwordrecovery : System.Web.UI.Page
    {
        DBHelper dbhelper = new DBHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            string title = "你的心灵之家登录密码";
            string username = UserName.Text.Trim();
            string sql = "select password,email from login where username=@username";
            SqlParameter[] paras={new SqlParameter("@username",SqlDbType.NVarChar){Value=username}};
            SqlDataReader reader = dbhelper.GetDataReader(sql, paras);
            if (reader.Read())
            {
                string password = reader["password"].ToString();
                //string recipient = "51124130@QQ.com";
                string recipient = reader["email"].ToString();
                string content = "您的登录密码为：" + password;
                jmail.Message JMail = new jmail.Message();
                string strFromEmail = "yftiger1981@163.com";
                JMail.Silent = false;
                JMail.Logging = true;
                JMail.Charset = "GB2312";
                JMail.Encoding = "Base64";
                JMail.ContentType = "text/html";
                JMail.Subject = title.Trim();            //【邮件标题】
                JMail.Body = content.Trim();                  //【邮件内容】                          
                JMail.AddRecipient(recipient.Trim());
                JMail.From = strFromEmail.Trim();           //【发件人】
                JMail.MailServerUserName = "yftiger1981";
                JMail.MailServerPassWord = "ylgs654312";
                try
                {

                    JMail.Send("smtp.163.com", false);
                    FailureText.Text = "密码已发送到你注册的邮箱里！";
                }
                catch (Exception ex)
                {
                    FailureText.Text = "邮件发送失败！";
                    return;
                }
                finally
                {
                    JMail.Close();
                }
            }
            else
            {
                FailureText.Text = "用户名不存在！";
            }


        }
    }
}