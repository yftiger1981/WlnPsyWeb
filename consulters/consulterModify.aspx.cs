using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using WebApplication2;

namespace WebApplication2.consulters
{
    public partial class consulterModify : System.Web.UI.Page
    {
        connectDb db = new connectDb();
        string username = null;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["username"] = "consulter1";
            username = Session["username"].ToString();
            nameLabel.Text=username ;
            if (!IsPostBack)
            {
                SqlConnection con1 = db.GetConn();
                try
                {                  
                    if (con1.State == ConnectionState.Closed)
                        con1.Open();
                    string sql = "select login.name,login.password,login.email,Consulter.sex,Consulter.IDCard,Consulter.headPhoto,Consulter.Imgpath,Consulter.preference,Consulter.profession,Consulter.prolevel,Consulter.selfIntro from login inner join Consulter on login.username=Consulter.username where login.username=@username";
                    SqlCommand cmd1 = new SqlCommand(sql, con1);
                    cmd1.Parameters.AddWithValue("@username", username);
                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        //Label1.Text = reader[].ToString();
                        nameTextBox.Text = reader["name"].ToString();
                        passwordTextBox.Text = reader["password"].ToString();
                        mailTextBox.Text = reader["email"].ToString();
                        sexTextBox.Text = reader["sex"].ToString();
                        IdTextBox.Text = reader["IDCard"].ToString();
                        string imgPath = null;
                         imgPath = reader["headPhoto"].ToString();
                         if (imgPath != "")
                         {
                             Image1.ImageUrl = imgPath;
                         }
                         else
                             Image1.ImageUrl = "~/Images/consulter.png";
                        string zjImgpath = null;
                        zjImgpath = reader["Imgpath"].ToString();
                        if (zjImgpath !=string.Empty)
                        {
                            Image2.ImageUrl = zjImgpath;
                        }
                        string prefer= reader["preference"].ToString();
                        string profession = reader["profession"].ToString();
                        string[] perferarr = prefer.Split(new char[] { ',' });
                        string[] professionarr = profession.Split(new char[]{','});
                        foreach (string type in perferarr)
                        {
                            if (type == "情感障碍咨询")
                            {
                                qgzaCheckBox.Checked = true;
                                continue;
                            }
                            if(type=="工作学习咨询")
                            {
                                gzxxCheckBox.Checked = true;
                                continue;
                            }
                            if (type == "婚姻家庭咨询")
                            {
                                hyjtCheckBox.Checked = true;
                                continue;
                            }
                        }

                        foreach (string type in professionarr)
                        {
                            if (type == "抑郁质")
                            {
                                yyzCheckBox.Checked = true;
                                continue;
                            }
                            if (type == "胆汁质")
                            {
                                dzzCheckBox.Checked = true;
                                continue;
                            }
                            if (type == "多血质")
                            {
                                dxzCheckBox.Checked = true;
                                continue;
                            }
                            if (type == "黏液质")
                            {
                                lyzCheckBox.Checked = true;
                                continue;
                            }
                        }
                        string level=reader["prolevel"].ToString();
                        if (level == "一级")
                        {
                            LevelRadioButtonList.Items[0].Selected = true;
                        }
                        else if (level == "二级")
                        {
                            LevelRadioButtonList.Items[1].Selected = true;
                        }
                        else if (level == "三级")
                        {
                            LevelRadioButtonList.Items[2].Selected = true;
                        }
                        introTextBox.Text = reader["selfIntro"].ToString();
                    }
                }
                catch (Exception e2)
                {
                    errLiteral.Text = "读取数据不成功，请联系系统管理员！";
                    return;
                }
                finally
                {
                    con1.Close();
                    con1.Dispose();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            string mail = mailTextBox.Text.Trim();
            string sex= sexTextBox.Text.Trim();
            string ID = IdTextBox.Text.Trim();
            string prefer = null;
            string profession =null;
            if (qgzaCheckBox.Checked)
                prefer += "情感障碍咨询" + @",";
            if (gzxxCheckBox.Checked)
                prefer += "工作学习咨询" + @",";
            if(hyjtCheckBox.Checked)
                prefer += "婚姻家庭咨询" + @",";
            if (dzzCheckBox.Checked)
                profession += "胆汁质" + @",";
            if (yyzCheckBox.Checked)
                profession += "抑郁质" + @",";
            if (dxzCheckBox.Checked)
                profession += "多血质" + @",";
            if (lyzCheckBox.Checked)
                profession += "黏液质" + @",";
            connectDb.splitcomma(ref prefer);
            connectDb.splitcomma(ref profession);
            string level = LevelRadioButtonList.SelectedValue.ToString();
            string intro = introTextBox.Text.Trim();      
            string updateLogin = "update login set name=@name,password=@password,email=@email where username=@username";
            string updateConsulter = "update Consulter set sex=@sex,IDCard=@ID,preference=@prefer,profession=@profession,prolevel=@level,selfIntro=@intro where username=@username";
            SqlConnection con1 = db.GetConn();
            try
            {
                if (con1.State == ConnectionState.Closed)
                    con1.Open();
                SqlCommand cmd1 = new SqlCommand(updateLogin, con1);
                SqlCommand cmd2 = new SqlCommand(updateConsulter, con1);
                cmd1.Parameters.AddWithValue("@username", nameLabel.Text);
                cmd1.Parameters.AddWithValue("@name", name);
                cmd1.Parameters.AddWithValue("@password",password);
                cmd1.Parameters.AddWithValue("@email", mail);
                cmd2.Parameters.AddWithValue("@username", nameLabel.Text);
                cmd2.Parameters.AddWithValue("@sex", sex);
                cmd2.Parameters.AddWithValue("@ID", ID);
                cmd2.Parameters.AddWithValue("@prefer",prefer );
                cmd2.Parameters.AddWithValue("@profession", profession);
                cmd2.Parameters.AddWithValue("@level", level);
                cmd2.Parameters.AddWithValue("@intro", intro);
                //cmd2.Parameters.AddWithValue("@headPhoto", imgurl);
                int count=cmd1.ExecuteNonQuery();
                int count2 = cmd2.ExecuteNonQuery();
                if (count == 1 && count2 == 1)
                    errLiteral.Text = "您的个人信息已更改成功！";
            }
            catch (Exception e1)
            {
                errLiteral.Text = "数据更新不成功，请联系系统管理员！";
                return;
            }
            finally
            {
                con1.Close();
                con1.Dispose();
            }

        }
       bool updateImg(string sql,SqlParameter[] paras)
        { 
           SqlConnection con1 = db.GetConn();
           try
           {
               if (con1.State == ConnectionState.Closed)
                   con1.Open();
               SqlCommand cmd = new SqlCommand(sql, con1);
               cmd.Parameters.AddRange(paras);
               cmd.ExecuteNonQuery();
               return true;
           }
           catch (Exception e3)
           {
               //Literal1.Text = "图片上传失败！";
               return false;
           }
           finally
           {
               con1.Close();
               con1.Dispose();
           }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string imgUrl = null;
            username = Session["username"].ToString();
            if (FileUpload1.HasFile)
            {
                string filename = FileUpload1.FileName;
                string ext = System.IO.Path.GetExtension(filename);
                if (ext == ".jpg" || ext == ".png")
                {
                    string path = Server.MapPath("~/ConsulterImages/");
                    string imgname = Guid.NewGuid().ToString();
                    FileUpload1.SaveAs( path+ imgname + ext);
                    imgUrl = Path.Combine("~/ConsulterImages/" ,imgname + ext);
                    string sql = "update Consulter set headPhoto=@headPhoto where username=@username";
                    SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@headPhoto", SqlDbType.VarChar){Value=imgUrl}, new SqlParameter("@username", SqlDbType.NVarChar){Value=username} };
                    bool upSuc=updateImg(sql,paras);
                    if(upSuc)
                         Literal1.Text = "您的头像图片已更新成功！";
                    else
                        Literal1.Text = "图片上传失败！";

                }
                else
                {
                    Literal1.Text = "您的图片格式不对，请检查是否以是jpg或png格式！";
                }
            }
            else
            {
                Literal1.Text = "请先选择要上传的图片！";
            }

        }

        protected void subButton_Click(object sender, EventArgs e)
        {
            username = Session["username"].ToString();
            string uploadPath = "~/ConsulterImages/";
            string sql = "update Consulter set Imgpath=@Imgpath where username=@username";
            string format = null;
            if (FileUpload2.HasFile)
            {
                string ext = Path.GetExtension(FileUpload2.FileName);
                if (ext.EndsWith(".jpg") || ext.EndsWith(".png"))
                {
                    HttpPostedFile f1 = FileUpload2.PostedFile;
                    ExcelHelper.UploadFile(f1, ref uploadPath, ref format);
                    SqlParameter[] paras = new SqlParameter[] { new SqlParameter("@Imgpath", SqlDbType.VarChar) { Value = uploadPath }, new SqlParameter("@username", SqlDbType.NVarChar) { Value = username } };
                    bool upSuc = updateImg(sql, paras);
                    if (upSuc)
                        errLiteral2.Text = "您的证件照已更新成功！";
                    else
                        errLiteral2.Text = "图片上传失败！";
                }
                else
                {
                    errLiteral2.Text = "只能上传.jpg或.png格式的文件!";
                }
            }
        }

    }
}