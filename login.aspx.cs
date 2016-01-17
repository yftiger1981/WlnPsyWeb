using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using  BPM.Data.MSSQL;
using System.Data;
using System.Data.SqlClient;
//using BPM.Platform;

namespace WebForm
{
    public partial class Login : System.Web.UI.Page
    {
        DBHelper dbhelper=new DBHelper();
        protected string Script = string.Empty;
        //string Script = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                check();
            }
        }

        private void check()
        {
            string isVcodeSessionKey = BPM.Utility.Keys.SessionKeys.IsValidateCode.ToString();
            string vcodeSessionKey = BPM.Utility.Keys.SessionKeys.ValidateCode.ToString();
            string userID = Request.Form["Account"];
            string password = Request.Form["Password"];
            string vcode = Request.Form["VCode"];
            bool isSessionLost = "1" == Request.QueryString["session"];//是否是超时后再登录
            if (Session[isVcodeSessionKey] != null
                && "1" == Session[isVcodeSessionKey].ToString()
                && (Session[vcodeSessionKey] == null
                || string.Compare(Session[vcodeSessionKey].ToString(), vcode.Trim(), true) != 0))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "error", "alert('验证码错误!');", true);
                return;
            }
            else
            {
                if (userID == null || password == null)
                {
                    Session[isVcodeSessionKey] = "1";
                    Script = "alert('帐号或密码不能为空!');";
                    return;
                }
                else
                {
                    using (SqlConnection con = new SqlConnection(dbhelper.ConnectionString))
                    {
                        string sql = "select count(*) from login where username=@userID and password=@password";
                        SqlParameter[] paras = { new SqlParameter("@userID", SqlDbType.NVarChar) { Value = userID }, new SqlParameter("@password", SqlDbType.Char) { Value = password } }; 
                        int count = Int32.Parse(dbhelper.ExecuteScalar(sql,paras));
                        if (count == 1)
                        {
                            string sel = "select username,rolemode,answerExam from login where username=@userID";
                            SqlParameter[] paras2 = { new SqlParameter("@userID", SqlDbType.NVarChar) { Value = userID } };
                            SqlDataReader reader = dbhelper.GetDataReader(sel, paras2);
                            if (reader.Read())
                            {
                                string role = reader["rolemode"].ToString();
                                string name = reader["username"].ToString();
                                Session["username"] = name;
                                Session["role"] = role;
                                if (role == "商家")
                                {
                                    Response.Redirect("~/consulters/registSuccess.aspx");
                                    return;
                                }
                                else
                                {
                                    bool isAnswer = (bool)reader["answerExam"];
                                    if ((role == "求助者") && (isAnswer))
                                    {

                                        Response.Redirect("~/clients/helperRegistSuc.aspx");
                                        return;
                                    }
                                    else if ((role == "求助者") && (!isAnswer))
                                    {
                                        Response.Redirect("~/clients/HelperRegister.aspx");
                                        return;
                                    }
                                    else if ((role == "咨询师") && (isAnswer))
                                    {
                                        Response.Redirect("~/consulters/registSuccess.aspx");
                                        return;
                                    }
                                    else if ((role == "咨询师") && (!isAnswer))
                                    {
                                        Response.Redirect("~/consulters/consulterRegister.aspx");
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Session[isVcodeSessionKey] = "1";
                            Script = "alert('帐号或密码错误!');";
                            return;
                        }
                    }
                }
                    }
                }

            }
        }