using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.BX
{
    public partial class FormDetailView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                databind();
            }
        }
        protected void databind()
        {

            if (Request["id"] != null)
            {
                lbDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
                t_BX_Form form = new t_BX_Form_Repository().Load(Convert.ToInt32(Request["id"]));
                lbUsername.Text = Session["username"].ToString();
                lbStartDate.Text = Convert.ToDateTime(form.StartDate).ToString("yyyy年MM月dd日");
                lbEndDate.Text = Convert.ToDateTime(form.EndDate).ToString("yyyy年MM月dd日");
                lbReason.Text = form.Reason;
                lbPositionType.Text = form.t_BX_PositionType.name;
                lbPosition.Text = form.Position;

                if (form.Type == 2)
                {
                    PanelPeople.Visible = true;
                    lbPeoples.Text = form.PeoplesName;
                    lbPeopleNum.Text = form.PeopleNumber.ToString();
                    lbType.Text = "包干";
                }
                else
                    lbType.Text = "凭票";
                var items = form.t_BX_FormItem.ToList();
                RepeaterItem.DataSource = items;
                RepeaterItem.DataBind();
                Decimal total = 0;
                Decimal cityFee = 0;
                Decimal tracficFee = 0;
                Decimal allowanceFee = 0;
                Decimal accommodationFee = 0;
                Decimal hejiFee = 0;

                foreach(t_BX_FormItem f in items)
                {
                    total = total + (Decimal)f.CityTrafficFee + (Decimal)f.TrafficFee + (Decimal)f.Allowance + (Decimal)f.AccommodationFee;
                    cityFee = cityFee + (Decimal)f.CityTrafficFee;
                    tracficFee = tracficFee + (Decimal)f.TrafficFee;
                    allowanceFee = allowanceFee + (Decimal)f.Allowance;
                    accommodationFee = accommodationFee + (Decimal)f.AccommodationFee;
                }
                hejiFee = total;
                lbTotMoney.Text = BLL.pub.Rmb.CmycurD(total);
                lbItemCityFee.Text = cityFee.ToString() + "元";
                lbItemTracficFee.Text = tracficFee.ToString() + "元";
                lbAllowance.Text = allowanceFee.ToString() + "元";
                lbAccodanceFee.Text = accommodationFee.ToString() + "元";
                lbHeji.Text = hejiFee.ToString() + "元";
            }
        }
    }
}