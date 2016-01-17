using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.psytest
{
    public partial class shijuan7 : System.Web.UI.Page
    {
        int score = 0;
        string name = null;
        string category = null;
        int[] lianye = new int[] { 1, 7, 10, 13, 18, 22, 26, 30, 33, 39, 43, 45, 49, 55, 57 };
        int[] danzhi = new int[] { 2, 6, 9, 14, 17, 21, 27, 31, 36, 38, 42, 48, 50, 54, 58 };
        int[] yiyu = new int[] { 3, 5, 12, 15, 20, 24, 28, 32, 35, 37, 41, 47, 51, 53, 59 };
        int[] duoxue = new int[] { 4, 8, 11, 16, 19, 23, 25, 29, 34, 40, 44, 46, 52, 56, 60 };
        protected void Page_Load(object sender, EventArgs e)
        {
            score = int.Parse(Request["score"].ToString());
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (this.RadioButtonList1.SelectedIndex > -1)
            {
                name = this.RadioButtonList1.SelectedItem.Text.ToString();
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
            foreach (int a in lianye)
            {
                if (score == a)
                {
                    category = "粘液质";
                    break;
                }
            }
            if (category == null)
            {
                foreach (int a in danzhi)
                {
                    if (score == a)
                    {
                        category = "胆汁质";
                        break;
                    }
                }
            }
            if (category == null)
            {
                foreach (int a in yiyu)
                {
                    if (score == a)
                    {
                        category = "抑郁质";
                        break;
                    }
                }
            }
            if (category == null)
            {
                foreach (int a in duoxue)
                {
                    if (score == a)
                    {
                        category = "多血质";
                        break;
                    }
                }
            }
            if (category == null)
                category = "您好，心灵之家欢迎你的光临！请确定你是否认真答题。";
            Server.Transfer("conclusion.aspx?genre=" + category);
        }
        protected void ImageButtonUndo_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("shijuan1.aspx");
        }
    }
}