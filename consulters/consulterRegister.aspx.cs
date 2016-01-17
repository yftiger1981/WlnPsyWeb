using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace WebApplication2
{
    public partial class consulter : System.Web.UI.Page
    {
        
        string username = null;
        connectDb condb = new connectDb();
        DBHelper Dbhelper = new DBHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["username"] = "consulter1";
            if (!IsPostBack)
            {
                username = Session["username"].ToString();
                nameLabel.Text = username;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Imgfilepath=UploadFile();
            if (Imgfilepath == null)
            {
                ErrLabel.Text = "请上传有效的证件照，否则不能提交！";
                return;
            }
            username = Session["username"].ToString();
            string sex = this.sexRadioButtonList.SelectedValue;
            string profskill=null;
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                    profskill += CheckBoxList1.Items[i].Text + ",";
            }
            if (profskill == null)
            {
                ErrLabel.Text = "擅长类型必须选择，否则不能提交！";
                return;
            }
            connectDb.splitcomma(ref profskill);
            string IDCard = IDTextBox.Text;
            if (IDCard == null)
            {
                ErrLabel.Text = "身份证号不能为空，否则不能提交！";
                return;
            }
            string prolevel = RadioButtonList1.SelectedValue;
            string selfIntro = ActivityTextBox.Text.Trim();
            string preference = null;
            for (int i = 0; i < PreferenceCheckBoxList.Items.Count; i++)
            {
                if (PreferenceCheckBoxList.Items[i].Selected)
                    preference += PreferenceCheckBoxList.Items[i].Text + ",";
            }
            if (preference == null)
            {
                ErrLabel.Text = "偏好类型必须选择，否则不能提交！";
                return;
            }
            connectDb.splitcomma(ref preference);
            SqlConnection con = condb.GetConn();
                try
                {             
                    if (con.State==ConnectionState.Closed)
                        con.Open();
                    string insertsql = "insert into Consulter values(@id,@sex,@IDCard,@Imgpath,@preference,@prof,@prolevel,@selfIntro,@headPhoto)";
                    SqlCommand sql = new SqlCommand(insertsql, con);
                    sql.Parameters.AddWithValue("@id", username);
                    sql.Parameters.AddWithValue("@sex", sex);
                    sql.Parameters.AddWithValue("@IDCard",IDCard);
                    sql.Parameters.AddWithValue("@Imgpath", Imgfilepath);
                    sql.Parameters.AddWithValue("@preference",preference);
                    sql.Parameters.AddWithValue("@prof", profskill);
                    sql.Parameters.AddWithValue("@prolevel", prolevel);
                    sql.Parameters.AddWithValue("@selfIntro", selfIntro);
                    sql.Parameters.AddWithValue("@headPhoto","~/ConsulterImages/default.png");
                    string update = "update login set answerExam=@isAnswer where username=@username";
                    SqlParameter[] paras = {new SqlParameter("@username",SqlDbType.NVarChar){Value=username},new SqlParameter("@isAnswer",SqlDbType.Bit){Value=1}};
                    if (RegularExpressionValidator1.IsValid == true)
                    {
                        int count = sql.ExecuteNonQuery();
                        int count2 = Dbhelper.Execute(update, paras);
                        if ((count == 1)&&(count2==1))
                        {
                            NextButton.Enabled = true;
                            ErrLabel.Text = "资料提交成功，请点下一步继续！";
                            return;
                        }
                    }
                    else
                        return;                   
                }
                catch (Exception ex)
                {
                    ErrLabel.Text = "信息提交错误，请联系管理员！";
                    return;
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }
        }
        public string UploadFile()
        {
            string ImgPath = Server.MapPath("~/ConsulterImages/");
            string Imgfilepath = null;
            if (!FileUpload1.HasFile || !FileUpload1.FileName.ToString().EndsWith(".jpg"))
            {
                ImgCustomValidator.IsValid = false;
                return null;
            }
            else
            {
                string filename = FileUpload1.FileName;
                string fileextion = Path.GetExtension(filename);
                try
                {
                    string Picname = Guid.NewGuid().ToString();
                    FileUpload1.SaveAs(Path.Combine(ImgPath, Picname + fileextion));
                    Imgfilepath = Path.Combine("~/ConsulterImages/",Picname + fileextion);
                    return Imgfilepath;
                }
                catch (Exception ex)
                {
                    ErrLabel.Text = "图片上传错误，请重新上传！";
                    return null;
                }
            }
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/consulters/registSuccess.aspx");
        }
    }
}