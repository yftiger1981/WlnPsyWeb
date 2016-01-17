using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace WebApplication2
{ 
    public partial class HelperModify : System.Web.UI.Page      
    {
        DBHelper Dbhelper = new DBHelper();
        string username;
        string agegroup = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            username =Session["username"].ToString();
            NameLabel.Text = username;
            if (!IsPostBack)              
            {
               string sel = null;
               SqlParameter[] paras = {new SqlParameter("@username",SqlDbType.NVarChar){Value=username}};
               string sql = "select ageGroup from login where username=@username";
               agegroup = Dbhelper.GetFieldValue(sql, paras).Trim();
               ViewState["ageGroup"] = agegroup;
               if (agegroup == "C")
               {
                   sel = "select photoPath from childHelper where username=@username";
               }
               else if (agegroup == "A")
                   {
                       sel = "select photoPath from adultHelper where username=@username";
                   }
               string imgPath=Dbhelper.GetFieldValue(sel,paras);
               if (imgPath!=null&&imgPath !=string.Empty)
               {
                   selfImage.ImageUrl = imgPath;
               }
               else
               {
                   selfImage.ImageUrl = "~/Images/helper-man.png";
               }


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           if(FileUpload1.HasFile)
           {
            HttpPostedFile file = Request.Files[0];
            string ext = Path.GetExtension(file.FileName);
            if (ext.IndexOf(@".jpg")==-1&&ext.IndexOf(@".png")==-1)
            {
                errLabel.Text = "请上传以.jpg,.png结尾的图片文件";
                return;
            }
            string filepath=@"~/clientImg/";
            string fileformat = null;
            username = Session["username"].ToString();
            agegroup = ViewState["ageGroup"].ToString();
            ExcelHelper.UploadFile(file,ref filepath,ref fileformat);
            SqlParameter[] paras2 = { new SqlParameter("@username", SqlDbType.NVarChar) { Value = username }, new SqlParameter("@path", SqlDbType.NVarChar) { Value = filepath } };
            if (agegroup=="A")
            {
                string update1 = "update adultHelper set photoPath=@path where username=@username";     
                int i = Dbhelper.Execute(update1, paras2);
                if (i == 1)
                    errLabel.Text = "头像修改成功！";
                else
                {
                    errLabel.Text = "头像修改失败！";
                    return;
                }

            }
            else  if (agegroup=="C")
            {
                    string update1 = "update childHelper set photoPath=@path where username=@username";        
                    int i = Dbhelper.Execute(update1, paras2);
                    if (i == 1)
                    {
                        errLabel.Text = "头像修改成功！";
                        return;
                    }
                    else
                    {
                        errLabel.Text = "头像修改失败！";
                        return;
                    }
                }
            
            }

            }
        }
    }