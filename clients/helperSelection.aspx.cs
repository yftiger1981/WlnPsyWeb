using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    class userConsulterRelation
    {
        string username;
        List<string> consulters = new List<string>();
       public string UserName
        {
         get  
           { return username;}
         set
           {username=value;}
        }

       public void pushConsulter(string consulter)
       {
           if (consulters.Count <= 5)
           {
               consulters.Add(consulter);
           }
       }

       public List<string> Consulters
       {
           get
           { return consulters; }
       }
    
    }

   
    public partial class helpee : System.Web.UI.Page
    {
        userConsulterRelation relation = new userConsulterRelation();
        string username = null;
        //connectDb conDb = new connectDb();
        //Dictionary<string,string> consults=new Dictionary<string,string>();
        DBHelper dbhelper = new DBHelper();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //username = Request["username"].ToString();
                //Session["username"] = "yf";
                //username = Session["username"].ToString();
                ViewState["SortExpression"] = "prolevel";
                ViewState["SortDirection"] = SortDirection.Descending;
            }
            userLabel.Text = Session["username"].ToString();
            
        }

        protected void consulterGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private int GetSortColumnIndex()
        {
            foreach (DataControlField field in consulterGridView.Columns)
            {
                if (field.SortExpression == ViewState["SortExpression"].ToString().Trim())
                    return consulterGridView.Columns.IndexOf(field);
            }
            return -1;
        }

        private void AddSortImage(int columnIndex, GridViewRow headerRow)
        {
            Image sortImage = new Image();
            if ((SortDirection)ViewState["SortDirection"] == SortDirection.Ascending)
            {
                sortImage.ImageUrl = "~/Images/up.jpg";
            }
            else
            {
                sortImage.ImageUrl = "~/Images/down.jpg";
            }
            headerRow.Cells[columnIndex].Controls.Add(sortImage);
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        { 
                    username =Session["username"].ToString() ;
                    relation.UserName = username;
            try
            {
                for (int index = 0; index < consulterGridView.Rows.Count; index++)
                {
                    if (((CheckBox)consulterGridView.Rows[index].FindControl("consulterCheck")).Checked)
                    {
                        string consulterusername = ((Label)consulterGridView.Rows[index].FindControl("consulterLabel")).Text.Trim();
                        if (relation.Consulters.Count < 5)
                            relation.pushConsulter(consulterusername);
                        else
                            throw new Exception("最多选择五个咨询师！");
                    }

                }
                foreach (string c in relation.Consulters)
                {
                    string consulter = c;
                    SqlParameter[] paras = { new SqlParameter("@helpee", SqlDbType.NVarChar) { Value = username }, new SqlParameter("@consulter", SqlDbType.NVarChar) { Value = consulter } };
                    string sel = "select count(*) from userConsulterRelation where helperUserName=@helpee and consulterUserName=@consulter ";
                    int count = Convert.ToInt32(dbhelper.GetFieldValue(sel, paras));
                    if (count == 1)
                        continue;
                    else if (count == 0)
                    {
                        string sqlinsert = "insert into userConsulterRelation values(@helpee,@consulter)";
                        dbhelper.Execute(sqlinsert, paras);
                        errLabel.Text = "谢谢！你已成功选择咨询师";
                    }
                }
            }
            catch (Exception e1)
            {
                errLabel.Text = e1.Message;
            }
          }
         

        //protected void DeleteButton_Click(object sender, EventArgs e)
        //{       
        //    consulters=(Dictionary<string,string>)ViewState["consulters"];
        //    consulters.Clear();
        //    ViewState["consulters"] = consulters;
        //    ListBox1.DataSource = consulters;
        //    ListBox1.DataBind();
        //}

        //protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        //{
        //    //int index = GridView1.SelectedIndex;
        //    //string consulterUserName = ((Label)GridView1.Rows[index].FindControl("consulterLabel")).Text;
        //    //if (relation.Consulters.Count <= 5)
        //    //{
        //    //    relation.pushConsulter(consulterUserName);
        //    //}  
        //    //else
        //    //{
        //    //    errLabel.Text = "最多只能选择五个咨询师";
        //    //    return;
        //    //}        
            
        //}

        protected void GridView2_RowDeleted(object sender, System.Web.UI.WebControls.GridViewDeletedEventArgs e)
        {
           
        }

        protected void GridView2_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
           username = Session["username"].ToString();
           string consulterusername = ((Label)selectGridView.Rows[e.RowIndex].FindControl("consulterLabel")).Text.ToString();
           string delete=SqlDataSource3.DeleteCommand;
           string constr = SqlDataSource3.ConnectionString;
           SqlConnection con = new SqlConnection(constr);
           try
           {
               if (con.State == ConnectionState.Closed)
                   con.Open();
               SqlCommand delcmd = new SqlCommand(delete, con);
               delcmd.Parameters.AddWithValue("@helperusername", username);
               delcmd.Parameters.AddWithValue("@consulterUserName", consulterusername);
               delcmd.ExecuteNonQuery();
           }

           finally 
           {
               con.Close();
               con.Dispose();
           }

        }

        protected void modifySelfButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("./HelperModify.aspx");
        }

        protected void consulterGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ViewState["SortExpression"].ToString().Trim() == e.SortExpression)
            {
                if ((SortDirection)ViewState["SortDirection"] == SortDirection.Ascending)
                    ViewState["SortDirection"] = SortDirection.Descending;
                else
                    ViewState["SortDirection"] = SortDirection.Ascending;
            }
            else
            {
                ViewState["SortExpression"] = e.SortExpression;
                ViewState["SortDirection"] = SortDirection.Descending;
            }
        }

        protected void consulterGridView_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                int sortColumnIndex = GetSortColumnIndex();

                if (sortColumnIndex != -1)
                    AddSortImage(sortColumnIndex, e.Row);
            }

        }

        //protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        //{
        //    //int index = GridView1.SelectedIndex;
        //    string consulterUserName = ((Label)GridView1.Rows[e.NewSelectedIndex].FindControl("consulterLabel")).Text;
        //    if (relation.Consulters.Count <= 5)
        //    {
        //        relation.pushConsulter(consulterUserName);
        //    }
        //    else
        //    {
        //        errLabel.Text = "最多只能选择五个咨询师";
        //        return;
        //    }        
        //}
    }
}