using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.psytest
{
    public partial class shijuan6 : System.Web.UI.Page
    {
        int score = 0;
        string name = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            score = int.Parse(Request["score"].ToString());
            //score = 0;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (this.RadioButtonList2.SelectedIndex > -1)
            {
                name = this.RadioButtonList2.SelectedItem.Text.ToString();
                switch (name)
                {
                    case "完全一致": score = score + 2;
                        break;
                    case "比较一致": score = score + 1;
                        break;
                    case "一致与不一致之间": score = score + 0;
                        break;
                    case "不太一致": score = score - 1;
                        break;
                    case "很不一致": score = score - 2;
                        break;
                }
            }
            if (this.RadioButtonList3.SelectedIndex > -1)
            {
                name = this.RadioButtonList3.SelectedItem.Text.ToString();
                switch (name)
                {
                    case "完全一致": score = score + 2;
                        break;
                    case "比较一致": score = score + 1;
                        break;
                    case "一致与不一致之间": score = score + 0;
                        break;
                    case "不太一致": score = score - 1;
                        break;
                    case "很不一致": score = score - 2;
                        break;
                }
            }
            if (this.RadioButtonList4.SelectedIndex > -1)
            {
                name = this.RadioButtonList4.SelectedItem.Text.ToString();
                switch (name)
                {
                    case "完全一致": score = score + 2;
                        break;
                    case "比较一致": score = score + 1;
                        break;
                    case "一致与不一致之间": score = score + 0;
                        break;
                    case "不太一致": score = score - 1;
                        break;
                    case "很不一致": score = score - 2;
                        break;
                }
            }
            if (this.RadioButtonList5.SelectedIndex > -1)
            {
                name = this.RadioButtonList5.SelectedItem.Text.ToString();
                switch (name)
                {
                    case "完全一致": score = score + 2;
                        break;
                    case "比较一致": score = score + 1;
                        break;
                    case "一致与不一致之间": score = score + 0;
                        break;
                    case "不太一致": score = score - 1;
                        break;
                    case "很不一致": score = score - 2;
                        break;
                }
            }
            if (this.RadioButtonList6.SelectedIndex > -1)
            {
                name = this.RadioButtonList6.SelectedItem.Text.ToString();
                switch (name)
                {
                    case "完全一致": score = score + 2;
                        break;
                    case "比较一致": score = score + 1;
                        break;
                    case "一致与不一致之间": score = score + 0;
                        break;
                    case "不太一致": score = score - 1;
                        break;
                    case "很不一致": score = score - 2;
                        break;
                }
            }
            if (this.RadioButtonList7.SelectedIndex > -1)
            {
                name = this.RadioButtonList7.SelectedItem.Text.ToString();
                switch (name)
                {
                    case "完全一致": score = score + 2;
                        break;
                    case "比较一致": score = score + 1;
                        break;
                    case "一致与不一致之间": score = score + 0;
                        break;
                    case "不太一致": score = score - 1;
                        break;
                    case "很不一致": score = score - 2;
                        break;
                }
            }
            if (this.RadioButtonList8.SelectedIndex > -1)
            {
                name = this.RadioButtonList8.SelectedItem.Text.ToString();
                switch (name)
                {
                    case "完全一致": score = score + 2;
                        break;
                    case "比较一致": score = score + 1;
                        break;
                    case "一致与不一致之间": score = score + 0;
                        break;
                    case "不太一致": score = score - 1;
                        break;
                    case "很不一致": score = score - 2;
                        break;
                }
            }
            if (this.RadioButtonList9.SelectedIndex > -1)
            {
                name = this.RadioButtonList9.SelectedItem.Text.ToString();
                switch (name)
                {
                    case "完全一致": score = score + 2;
                        break;
                    case "比较一致": score = score + 1;
                        break;
                    case "一致与不一致之间": score = score + 0;
                        break;
                    case "不太一致": score = score - 1;
                        break;
                    case "很不一致": score = score - 2;
                        break;
                }
            }
            if (this.RadioButtonList10.SelectedIndex > -1)
            {
                name = this.RadioButtonList10.SelectedItem.Text.ToString();
                switch (name)
                {
                    case "完全一致": score = score + 2;
                        break;
                    case "比较一致": score = score + 1;
                        break;
                    case "一致与不一致之间": score = score + 0;
                        break;
                    case "不太一致": score = score - 1;
                        break;
                    case "很不一致": score = score - 2;
                        break;
                }
            }
            string Uri2 = "shijuan7.aspx?score=" + score;
            Server.Transfer(Uri2);
        }
    }
}