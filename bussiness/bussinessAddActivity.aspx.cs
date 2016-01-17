using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Data;

namespace WebApplication2
{
    public partial class bussinessRegister : System.Web.UI.Page
    {
        int imagecount=0;
        string userName=null;
        int count = 0;
        DBHelper dbHelper = new DBHelper();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["username"] = "bussiness1";
            if (!IsPostBack)
            {
                    //Session["username"] = "bussiness1";
                    ViewState["imagecount"]=imagecount;
                    userName=Session["username"].ToString();                 
                    string selsql = "select image1,image2,image3,intro1,intro2,intro3 from bussiness where username=@username ";
                   SqlParameter[] paras={new SqlParameter("@username",SqlDbType.NVarChar){Value=userName}};
                    SqlDataReader reader = dbHelper.GetDataReader(selsql,paras);
                    if (reader.Read())
                    {
                        string image1 = reader["image1"].ToString();
                        string image2 = reader["image2"].ToString();
                        string image3 = reader["image3"].ToString();
                        string intro1 = reader["intro1"].ToString();
                        string intro2 = reader["intro2"].ToString();
                        string intro3 = reader["intro3"].ToString();
                        reader.Close();
                        if (!string.IsNullOrEmpty(image1))
                        {
                            Image1.ImageUrl = image1;
                            ImgTextBox1.Text = HttpUtility.UrlDecode(intro1);
                        }
                        if (!string.IsNullOrEmpty(image2))
                        {
                            Image2.ImageUrl = image2;
                            ImgTextBox2.Text = HttpUtility.UrlDecode(intro2);
                        }
                        if (!string.IsNullOrEmpty(image3))
                        {
                            Image3.ImageUrl = image3;
                            ImgTextBox3.Text = HttpUtility.UrlDecode(intro3);
                        }
                    }
                }
            bussinessLabel.Text = Session["username"].ToString();
        }

    
        //public string UploadFile()
        //{
        //    string imgFilePath = null;
        //    string ImgPath = Server.MapPath("~/BussinessImages/");
        //    if (!FileUpload1.HasFile || !FileUpload1.FileName.ToString().EndsWith(".jpg"))
        //    {
        //        ImgCustomValidator.IsValid = false;
        //        return null;
        //    }
        //    else
        //    {
        //        string filename = FileUpload1.FileName;
        //        string fileextion = Path.GetExtension(filename);
        //        try
        //        {
        //            string Picname = Guid.NewGuid().ToString();
        //            FileUpload1.SaveAs(Path.Combine(ImgPath, Picname + fileextion));
        //            imgFilePath = HttpUtility.UrlPathEncode(Path.Combine("~/BussinessImages/" ,Picname+fileextion));
        //            return imgFilePath;
        //        }
        //        catch (Exception ex)
        //        {
        //           errLiteral1.Text = ex.ToString();
        //          return null;
        //        }
        //    }
        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    //userName = "consulter1";           
        //    userName = Session["username"].ToString();
        //    imagecount=(int)ViewState["imagecount"];
        //    imagecount++;
        //    ViewState["imagecount"] = imagecount;
        //    Imgfilepath = UploadFile();
        //    string time = DateTime.Now.Date.ToShortDateString();
        //    if (Imgfilepath != null)
        //    {
        //        try
        //        {
        //            if (imagecount <= 3)
        //            {
        //                string activateIntro = HttpUtility.UrlEncode(ActivateIntro.Text.Trim());
        //                if (imagecount == 1)
        //                {
        //                    string updatesql = "Update bussiness set Image1=@image1 ,Intro1=@intro1 ,Time1=@Time1 where username=@username ";
        //                    SqlParameter[] paras = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = userName }, new SqlParameter("@image1", SqlDbType.NVarChar) { Value = Imgfilepath }, new SqlParameter("@intro1", SqlDbType.NVarChar) { Value = activateIntro }, new SqlParameter("@Time1", SqlDbType.NVarChar) { Value = time } };
        //                    count = dbHelper.Execute(updatesql,paras);
        //                    Image1.ImageUrl = HttpUtility.UrlDecode(Imgfilepath);
        //                    ImgTextBox1.Text = ActivateIntro.Text;
        //                    if (count == 1)
        //                        errLiteral1.Text = "活动信息1插入成功！";
        //                    return;

        //                }
        //                if (imagecount == 2)
        //                {
        //                    string updatesql = "Update bussiness set Image2=@image2 ,Intro2=@intro2 ,Time2=@Time2 where username=@username ";
        //                    SqlParameter[] paras = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = userName }, new SqlParameter("@image2", SqlDbType.NVarChar) { Value = Imgfilepath }, new SqlParameter("@intro2", SqlDbType.NVarChar) { Value = activateIntro }, new SqlParameter("@Time2", SqlDbType.NVarChar) { Value = time } };
        //                    count = dbHelper.Execute(updatesql, paras);
        //                    Image2.ImageUrl = HttpUtility.UrlDecode(Imgfilepath);
        //                    ImgTextBox2.Text = ActivateIntro.Text;
        //                    if (count == 1)
        //                        errLiteral1.Text = "活动信息2插入成功！";
        //                    return;

        //                }
        //                if (imagecount == 3)
        //                {
        //                    string updatesql = "Update bussiness set Image3=@image3 ,Intro3=@intro3,Time3=@Time3 where username=@username ";
        //                    SqlParameter[] paras = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = userName }, new SqlParameter("@image3", SqlDbType.NVarChar) { Value = Imgfilepath }, new SqlParameter("@intro3", SqlDbType.NVarChar) { Value = activateIntro }, new SqlParameter("@Time3", SqlDbType.NVarChar) { Value = time } };
        //                    count = dbHelper.Execute(updatesql, paras);
        //                    Image2.ImageUrl = HttpUtility.UrlDecode(Imgfilepath);
        //                    Image3.ImageUrl = HttpUtility.UrlDecode(Imgfilepath);
        //                    ImgTextBox3.Text = ActivateIntro.Text;
        //                    if (count == 1)
        //                        errLiteral1.Text = "活动信息3插入成功！";
        //                    return;
        //                }
        //            }
        //            else
        //            {
        //                errLiteral1.Text = "只能上传三张活动图片！";
        //                return;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            errLiteral1.Text = ex.ToString();
        //            return;
        //        }
        //    }
        //}

        protected void DeleteButton1_Click(object sender, EventArgs e)
        {
            userName = Session["username"].ToString();
            Image1.ImageUrl = "";
            ImgTextBox1.Text = " ";
            try
            {
                string updatesql = "Update bussiness set Image1=@image1 ,Intro1=@intro1,Time1=@time1 where username=@username ";
                SqlParameter[] paras = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = userName }, new SqlParameter("@image1", SqlDbType.NVarChar) { Value =string.Empty}, new SqlParameter("@intro1", SqlDbType.NVarChar) { Value = string.Empty }, new SqlParameter("@Time1", SqlDbType.NVarChar) { Value = string.Empty} };
                count = dbHelper.Execute(updatesql, paras);
                if (count == 1)
                    errLiteral1.Text = "活动信息1删除成功！";
            }
            catch (Exception ex)
            {
                errLiteral1.Text = ex.ToString();
                return;
            }
        }

        protected void DeleteButton2_Click(object sender, EventArgs e)
        {
            userName = Session["username"].ToString();
            Image2.ImageUrl = " ";
            ImgTextBox2.Text = " ";
            try
            {
                string updatesql = "Update bussiness set Image2=@image2 ,Intro2=@intro2,Time2=@time2 where username=@username ";
                SqlParameter[] paras = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = userName }, new SqlParameter("@image2", SqlDbType.NVarChar) { Value = string.Empty }, new SqlParameter("@intro2", SqlDbType.NVarChar) { Value = string.Empty }, new SqlParameter("@Time2", SqlDbType.NVarChar) { Value = string.Empty } };
                count = dbHelper.Execute(updatesql, paras);
                if (count == 1)
                    errLiteral1.Text = "活动信息2删除成功！";
            }
            catch (Exception ex)
            {
                errLiteral1.Text = ex.ToString();
                return;
            }
        }

        protected void DeleteButton3_Click(object sender, EventArgs e)
        {
            userName = Session["username"].ToString();
            Image3.ImageUrl = "";
            ImgTextBox3.Text = "";
            try
            {
                string updatesql = "Update bussiness set Image3=@image3 ,Intro3=@intro3,Time3=@time3 where username=@username ";
                SqlParameter[] paras = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = userName }, new SqlParameter("@image3", SqlDbType.NVarChar) { Value = string.Empty }, new SqlParameter("@intro3", SqlDbType.NVarChar) { Value = string.Empty }, new SqlParameter("@Time3", SqlDbType.NVarChar) { Value = string.Empty } };
                count = dbHelper.Execute(updatesql, paras);
                if (count == 1)
                    errLiteral1.Text = "活动信息3删除成功！";
            }
            catch (Exception ex)
            {
                errLiteral1.Text = ex.ToString();
                return;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/bussiness/AddActive.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/soulcastlefrontpage.html");
        }
        }
}