using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.WorkPlan
{
    public partial class LookByMonth : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                initdate();
                databind();
            }
        }

        protected void initdate()
        {
            int year = 2014;
            ddlYear.Items.Clear();
            ddlMonth.Items.Clear();
            for(int i=0;i<10;i++)
            {
                ListItem li = new ListItem();
                li.Text = (year + i).ToString();
                li.Value = (year + i).ToString();
                if ((year + i) == DateTime.Now.Year)
                    li.Selected = true;
                ddlYear.Items.Add(li);

            }
            for(int i =1;i<=12;i++)
            {
                ListItem li = new ListItem();
                li.Text = i.ToString();
                li.Value = i.ToString();
                if (i == DateTime.Now.Month)
                    li.Selected = true ;
                ddlMonth.Items.Add(li);
            }
        }

        protected void databind()
        {

            gvWeekPlan.DataSource = BLL.Application.WorkPlan.LookByMonth.getWorkPlanByDate(Convert.ToInt16(ddlYear.Text),Convert.ToInt16(ddlMonth.Text));
            gvWeekPlan.DataBind();

        }

        protected void gvWeekPlan_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvWeekPlan.PageIndex = e.NewPageIndex;
            databind();
        }


        protected void imgState_DataBinding(object sender, EventArgs e)
        {
            Image img = (Image)sender;
            v_WorkPlan plan = GetDataItem() as v_WorkPlan;

            if ((bool)plan.isComplete)
                img.ImageUrl = "/media/images/check-64.png";
            else
            {
                img.ImageUrl = "/media/images/t03.png";
            }
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            databind();
        }
    }
}