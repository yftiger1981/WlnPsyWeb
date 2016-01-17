using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;


namespace WebApplication2
{
    public partial class Helper : System.Web.UI.Page
    {
        connectDb con1 = new connectDb();
        string username = null;
        string ageGroup = null;

       
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    username = Request.QueryString["id"].ToString();
            //    Session["username"] = username;
            //}
            username = Session["username"].ToString();
            Label1.Text = username;
           
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (helpRadioButtonList.SelectedValue == "成人")
            {
                this.adulthelp.Visible = true;
                this.childtable.Visible = false;
                ageGroup = "A";
                ViewState["ageGroup"] = ageGroup;
            }
            else
            {
                this.adulthelp.Visible = false;
                this.childtable.Visible = true;
                ageGroup = "C";
                ViewState["ageGroup"] = ageGroup;
            }
        }

        protected void subButton_Click(object sender, EventArgs e)
        {
            string personanity = personRadioButtonList.SelectedValue;
            //for (int i = 0; i < personRadioButtonList.Items.Count; i++)
            //{
            //    if (personRadioButtonList.Items[i].Selected)
            //    {
            //        personanity = personRadioButtonList.Items[i].Text;
            //        break;
            //    }
            //}
            int age = int.Parse(ageTextBox.Text.Trim());
            string parentedu = pareduRadioButtonList.SelectedItem.Text;
            string seledu = selduRadioButtonList0.SelectedItem.Text;
            string psykonwledge = PsykonwRadioButtonList1.SelectedItem.Text;
            string prolength = ProlenRadioButtonList1.SelectedItem.Text;
            string bodyCondi = BodycondiRadioButtonList2.SelectedValue;
            string workcondi = WorkRadioButton.SelectedValue;
            string prosolv = prosolvRadioButtonList1.SelectedValue;
            string tellpar = tellparRadioButtonList.SelectedValue;
            string firstapp = firstappRadioButtonList3.SelectedValue;
            string photopath =string.Empty;
            ageGroup = ViewState["ageGroup"].ToString();
            try
            {
                SqlConnection con = con1.GetConn();
                string insertsql = "insert into adultHelper values(@id,@photoPath,@personanity,@age,@parentedu,@seledu,@psykonwledge,@prolength,@bodyCondi,@workcondi,@prosolv,@tellpar,@firstapp)";
                SqlCommand sql = new SqlCommand(insertsql, con);
                username = Session["username"].ToString();
                sql.Parameters.AddWithValue("@id", username);
                sql.Parameters.AddWithValue("@photoPath",photopath);
                sql.Parameters.AddWithValue("@personanity", personanity);
                sql.Parameters.AddWithValue("@age", age);
                sql.Parameters.AddWithValue("@parentedu", parentedu);
                sql.Parameters.AddWithValue("@seledu", seledu);
                sql.Parameters.AddWithValue("@psykonwledge", psykonwledge);
                sql.Parameters.AddWithValue("@prolength", prolength);
                sql.Parameters.AddWithValue("@bodyCondi", bodyCondi);
                sql.Parameters.AddWithValue("@workcondi", workcondi);
                sql.Parameters.AddWithValue("@prosolv", prosolv);
                sql.Parameters.AddWithValue("@tellpar", tellpar);
                sql.Parameters.AddWithValue("@firstapp", firstapp);
                int count = sql.ExecuteNonQuery();
                string update = "update login set ageGroup=@ageGroup ,answerExam=@isAnswer where username=@username";
                SqlCommand cmd2 = new SqlCommand(update, con);
                cmd2.Parameters.AddWithValue("@ageGroup", ageGroup);
                cmd2.Parameters.AddWithValue("@isAnswer", 1);
                cmd2.Parameters.AddWithValue("@username", username);
                int i = cmd2.ExecuteNonQuery();
                if ((i == 1) && (count == 1))
                {
                    errLabel1.Text = "您的问卷信息已提交成功，请点击下一步！";
                    nextButton2.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                errLabel1.Text = "信息存储错误，请联系管理员！";
                return;
            }
            finally
            {
                con1.closeConn();
            }

        }

        protected void subButton1_Click(object sender, EventArgs e)
        {
            string personanity = personRadioButtonList0.SelectedValue;
            string age = ageTextBox.Text.Trim();
            string gender = null;
            if (mailradiobutton.Checked)
                gender = "男";
            else
                gender = "女";
            string bodyCondi = BodycondiRadioButtonList3.SelectedValue;
            string psykonw = PsykonwRadioButtonList2.SelectedValue;
            string childcare = careRadioButtonList3.SelectedValue;
            string liveto = null;
            ageGroup = ViewState["ageGroup"].ToString();
            if (livetogether.Checked)
                liveto = livetogether.Value; 
            else
                liveto = nolivetogether.Value;
            string separate = null;
            if (sepratebychild.Checked)
                separate = sepratebychild.Value;
            else
                separate = nosepratebychild.Value;
            string carebyoldstr = null;
            if (carebyold.Checked)
                carebyoldstr = carebyold.Value;
            else
                carebyoldstr = nocarebyold.Value;
            string photopath ="";
            SqlConnection con = con1.GetConn();
            try
            {                
                string insertsql = "insert into childHelper values(@id,@photoPath,@personanity,@age,@gender,@bodyCondi,@psykonw,@childcare,@liveto,@separate,@carebyoldstr)";
                SqlCommand insert = new SqlCommand(insertsql, con);
                username = Session["username"].ToString();
                insert.Parameters.AddWithValue("@id", username);
                insert.Parameters.AddWithValue("@photoPath",photopath);
                insert.Parameters.AddWithValue("@personanity", personanity);
                insert.Parameters.AddWithValue("@age", age);
                insert.Parameters.AddWithValue("@gender", gender);
                insert.Parameters.AddWithValue("@bodyCondi", bodyCondi);
                insert.Parameters.AddWithValue("@psykonw", psykonw);
                insert.Parameters.AddWithValue("@childcare", childcare);
                insert.Parameters.AddWithValue("@liveto", liveto);
                insert.Parameters.AddWithValue("@separate", separate);
                insert.Parameters.AddWithValue("@carebyoldstr", carebyoldstr);
                int count = insert.ExecuteNonQuery();
                string update = "update login set ageGroup=@ageGroup ,answerExam=@isAnswer where username=@username";
                SqlCommand cmd2 = new SqlCommand(update, con);
                cmd2.Parameters.AddWithValue("@ageGroup", ageGroup);
                cmd2.Parameters.AddWithValue("@isAnswer", 1);
                cmd2.Parameters.AddWithValue("@username", username);
                int i=cmd2.ExecuteNonQuery();
                 if ((i == 1) && (count == 1))
                 {
                   errLabel1.Text = "您的问卷信息已提交成功，请点击下一步！";
                   NextButton.Enabled = true;
                 }
            }
            catch (Exception ex)
            {
                errLabel1.Text = ex.ToString();
                return;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/clients/helperRegistSuc.aspx",false);
        }

        protected void nextButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/clients/helperRegistSuc.aspx", false);
        }   
            }
 }
    
