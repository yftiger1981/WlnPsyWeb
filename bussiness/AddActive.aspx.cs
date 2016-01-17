using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication2.bussiness
{
    public partial class AddActive : System.Web.UI.Page
    {
        DBHelper dbhelper = new DBHelper();
        //ExcelHelper exhelper = new ExcelHelper();
        static int count = 0;
        bool[] array = {false,false,false};
        string username = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["username"] = "bussiness1";
            if (!IsPostBack)
            {
                username=Session["username"].ToString();
                string sql = "select image1,Intro1,image2,Intro2,image3,Intro3 from bussiness where username=@username";
                SqlParameter[] para = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = username } };
                SqlDataReader reader = dbhelper.GetDataReader(sql,para);
                if (reader.Read())
                {
                    if (string.IsNullOrEmpty(reader["image1"].ToString()) && string.IsNullOrEmpty(reader["Intro1"].ToString()))
                    { 
                       array[0]=true;
                       count++;
                    }
                    if (string.IsNullOrEmpty(reader["image2"].ToString()) && string.IsNullOrEmpty(reader["Intro2"].ToString()))
                    {
                        array[1] = true;
                        count++;
                    }
                    if (string.IsNullOrEmpty(reader["image3"].ToString()) && string.IsNullOrEmpty(reader["Intro3"].ToString()))
                    {
                        array[2] = true;
                        count++;
                    }
                }
                if(count == 0)
                {
                    errLiteral1.Text = "您已经发布了三个活动，不能再发布新活动！请删除现有的活动后才能发布";
                    subButton.Enabled = false;
                }
                else
                {
                    errLiteral1.Text = "";
                    if(!subButton.Enabled)
                    subButton.Enabled = true;
                }
                ViewState["boolarr"] = array;
            }
            if (count == 0)
            {
                errLiteral1.Text = "您已经发布了三个活动，不能再发布新活动！请删除现有的活动后才能发布";
                subButton.Enabled = false;
            }
            
        }

        protected void FileUpload1_Load(object sender, EventArgs e)
        {

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string intro = ActivateIntro.Text.Trim();
            string time = DateTime.Now.Date.ToShortDateString();
            username = Session["username"].ToString();
            if (!FileUpload1.HasFile)
            {
                ImgCustomValidator.IsValid = false;
                return;
            }
            else
            {  
                string filename=FileUpload1.FileName;
                string ext = Path.GetExtension(filename);
                if (!ext.EndsWith(".jpg") && !ext.EndsWith(".png"))
                {
                    Literal1.Text = "上传活动图片需为.jpg或.png格式的图片！不能大于200K";
                    return;
                }
                else
                {
                    HttpPostedFile file = FileUpload1.PostedFile;
                    string uploadUrl = "~/BussinessImages/";
                    //string format = null;
                    string filename2 = ExcelHelper.UploadFile(file, ref uploadUrl);
                    string updatesql = null;
                    //SqlParameter[] paras;
                    bool[] array = (bool[])ViewState["boolarr"];
                    if (array[0])
                    {
                        updatesql = "Update bussiness set Image1=@image1 ,Intro1=@intro1 ,Time1=@Time1 where username=@username ";
                        SqlParameter[] paras = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = username }, new SqlParameter("@image1", SqlDbType.NVarChar) { Value = uploadUrl }, new SqlParameter("@intro1", SqlDbType.NVarChar) { Value = intro }, new SqlParameter("@Time1", SqlDbType.NVarChar) { Value = time } };
                        int count2 = dbhelper.Execute(updatesql, paras);
                        if (count2 == 1)
                        {
                            array[0] = false;
                            ViewState["boolarr"] = array;
                            count--;
                            errLiteral1.Text = "您的活动已成功发布，您还能再发布"+count+"个活动";
                            return;
                        }
                    }
                    else if (array[1])
                    {
                        updatesql = "Update bussiness set Image2=@image2 ,Intro2=@intro2 ,Time2=@Time2 where username=@username ";
                        SqlParameter[] paras = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = username }, new SqlParameter("@image2", SqlDbType.NVarChar) { Value = uploadUrl }, new SqlParameter("@intro2", SqlDbType.NVarChar) { Value = intro }, new SqlParameter("@Time2", SqlDbType.NVarChar) { Value = time } };
                        int count2 = dbhelper.Execute(updatesql, paras);
                        if (count2 == 1)
                        {
                            array[1] = false;
                            ViewState["boolarr"] = array;
                            count--;
                            errLiteral1.Text = "您的活动已成功发布，您还能再发布" + count + "个活动";
                            return;
                        }
                    }
                    else if (array[2])
                    {
                        updatesql = "Update bussiness set Image3=@image3 ,Intro3=@intro3,Time3=@Time3 where username=@username ";
                        SqlParameter[] paras = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = username }, new SqlParameter("@image3", SqlDbType.NVarChar) { Value = uploadUrl }, new SqlParameter("@intro3", SqlDbType.NVarChar) { Value = intro }, new SqlParameter("@Time3", SqlDbType.NVarChar) { Value = time } };
                        int count2 = dbhelper.Execute(updatesql, paras);
                        if (count2 == 1)
                        {
                            array[2] = false;
                            ViewState["boolarr"] = array;
                            count--;
                            errLiteral1.Text = "您的活动已成功发布，您还能再发布" + count + "个活动";
                            return;
                        }
                    }

                    
                }
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/bussiness/bussinessAddActivity.aspx");
        }
    }
}