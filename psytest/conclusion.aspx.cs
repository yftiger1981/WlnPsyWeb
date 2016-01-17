using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.psytest
{
    public partial class conclusion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string genre = Request["genre"].ToString();
            this.TypeLabel.Text = genre;
        }
    }
}