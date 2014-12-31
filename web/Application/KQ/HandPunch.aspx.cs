using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web.Application.KQ
{
    public partial class HandPunch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
               if (!BLL.admin.role.RoleManagement.ifUserInRole(Convert.ToInt32(Session["userid"]), 6))
               {
                   lbClockOffBu.Enabled = false;
                   lbClockOnBu.Enabled = false;
               }
            }
        }

        protected void lbClockOnBu_Click(object sender, EventArgs e)
        {
            try
            {
                if (BLL.Application.KQ.KQManagement.insertPunchCardRecordByType(tbUsername.Text, tbStartTime.Text, '1',"补卡",Session["username"].ToString()))
                    lbMessage.Text = "上班补卡成功！";
                else
                    lbMessage.Text = "该用户已打过卡";
            }
            catch (Exception ex)
            {
                lbMessage.Text = "补打卡异常：" + ex.Message;
            }
        }

        protected void lbClockOffBu_Click(object sender, EventArgs e)
        {
            try
            {
                if (BLL.Application.KQ.KQManagement.insertPunchCardRecordByType(tbUsername.Text, tbStartTime.Text, '2', "补卡", Session["username"].ToString()))
                    lbMessage.Text = "下班补卡成功！";
                else
                    lbMessage.Text = "该用户已打过卡";
            }catch (Exception ex)
            {
                lbMessage.Text = "补打卡异常：" + ex.Message;
            }
        }
    }
}