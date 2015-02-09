using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.KQ
{
    public partial class SchedulingManagement : System.Web.UI.Page
    {
        List<KQ_Shift> listShift = new List<KQ_Shift>();//数据库读出的班次记录
        List<KQ_Scheduling> listScheduling = new List<KQ_Scheduling>(); //数据库读出的排班记录
        List<KQ_Scheduling> listSchedulingResult = new List<KQ_Scheduling>();//最终结果
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                databind();
            }
        }

        protected void initdata()
        {
            listSchedulingResult.Clear();
            listShift.Clear();
            listScheduling.Clear();
            listShift = BLL.Application.KQ.SchedulingManagement.getShift();
            listScheduling = BLL.Application.KQ.SchedulingManagement.getSchedulingList(Convert.ToInt32(lbYear.Text), Convert.ToInt32(ddlMonth.SelectedValue));
        }

        protected void databind()
        {
            lbYear.Text = DateTime.Now.Year.ToString();
            ddlMonth.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
            
            PanelAdd.Visible = false;
            gvShift.DataSource = BLL.Application.KQ.SchedulingManagement.getShift();
            gvShift.DataBind();
            initTable();
            
        }

        protected void getNewDDL(ref DropDownList ddl)
        {
            ddl.Width = 100;
            ddl.Items.Clear();
            foreach (KQ_Shift l in listShift)
            {
                ListItem li = new ListItem();
                li.Value = l.Id.ToString();
                li.Text = l.Name;
                if (l.isDefault !=null && (bool)l.isDefault)
                    li.Selected = true;
                ddl.Items.Add(li);
            }
        }
        protected Literal getNewLiteral()
        {
            Literal l = new Literal();
            l.Text = "</br>";
            return l;
        }

        protected void initTable()
        {
            initdata();
            DateTime date = new DateTime(Convert.ToInt32(lbYear.Text), Convert.ToInt32(ddlMonth.SelectedValue), 1);
            int preMonth = date.Month;
            for (int j = 0; j < 6; j++)
            {
                TableRow tr = (TableRow)tableMonth.Controls[j + 1];
                for (int i = 0; i < 7; i++)
                {
                    TableCell cell = (TableCell)tr.Controls[i];
                    Label lb = cell.FindControl("lb" +j+ i) as Label;
                    CheckBox cb = cell.FindControl("cb" +j+ i) as CheckBox;
                    DropDownList ddl = cell.FindControl("ddl" +j+ i) as DropDownList;
                    getNewDDL(ref ddl);
                    if ((DayOfWeek)i == date.DayOfWeek && date.Month == preMonth)
                    {
                        cb.Visible = true;
                        ddl.Visible = true;

                        if (listScheduling.Where(l => l.Day == date.Day).Count() == 1) //如果有记录说明已经排过班，则勾选
                            cb.Checked = true;
                        else
                            cb.Checked = false;
                        lb.Text = date.Day.ToString();
                        cell.BackColor = System.Drawing.Color.FromArgb(224, 235, 252);

                        if (date.Month == preMonth)
                        {
                            preMonth = date.Month;
                            date = date.AddDays(1);
                        }
                    }
                    else
                    {
                        lb.Text = "---- ";
                        cell.BackColor = System.Drawing.Color.White;
                        cb.Visible = false;
                        ddl.Visible = false;
                    }
                }
            }
        }


        protected void lbPaiban_Click(object sender, EventArgs e)
        {
            mv1.ActiveViewIndex = 0;
        }

        protected void lbBanci_Click(object sender, EventArgs e)
        {

            mv1.ActiveViewIndex = 1;
        }

        protected void lbAdd_Click(object sender, EventArgs e)
        {
            PanelAdd.Visible = true;
        }

        protected void cbShangban_DataBinding(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            KQ_Shift sh = GetDataItem() as KQ_Shift;
            cb.Checked = (sh.isClockOn == null) ? false : (bool)sh.isClockOn;
        }

        protected void cbXiaban_DataBinding(object sender, EventArgs e)
        {

            CheckBox cb = (CheckBox)sender;
            KQ_Shift sh = GetDataItem() as KQ_Shift;
            cb.Checked = (sh.isClockOff == null) ? false : (bool)sh.isClockOff;
        }

        protected void cbDefault_DataBinding(object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            KQ_Shift sh = GetDataItem() as KQ_Shift;
            cb.Checked = (sh.isDefault == null) ? false : (bool)sh.isDefault;
        }

        protected void gvShift_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

            gvShift.EditIndex = -1;
        }


        protected void gvShift_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            String id = gvShift.DataKeys[e.RowIndex].Value.ToString();

            if (BLL.Application.KQ.SchedulingManagement.deleteShift(id))
            {
                BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "删除成功！");
                databind();
            }
        }

        protected void gvShift_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvShift.EditIndex = e.NewEditIndex;
            databind();
        }

        protected void gvShift_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            KQ_Shift sh = new KQ_Shift();
            sh.Id = Convert.ToInt32( gvShift.DataKeys[e.RowIndex].Value.ToString());
            sh.Name = ((TextBox)gvShift.Rows[e.RowIndex].Cells[1].FindControl("tbName")).Text;
            sh.isClockOn = ((CheckBox)gvShift.Rows[e.RowIndex].Cells[2].FindControl("cbShangban")).Checked;
            sh.ClockOnTime = ((TextBox)gvShift.Rows[e.RowIndex].Cells[3].FindControl("tbClockOnTime")).Text;
            sh.isClockOff = ((CheckBox)gvShift.Rows[e.RowIndex].Cells[4].FindControl("cbXiaban")).Checked;
            sh.ClockOffTime = ((TextBox)gvShift.Rows[e.RowIndex].Cells[5].FindControl("tbClockOffTime")).Text;
            sh.isDefault = ((CheckBox)gvShift.Rows[e.RowIndex].Cells[6].FindControl("cbDefault")).Checked;
            sh.Remark = ((TextBox)gvShift.Rows[e.RowIndex].Cells[7].FindControl("tbRemark")).Text;

            BLL.Application.KQ.SchedulingManagement.updateShift(sh);
            gvShift.EditIndex = -1; //将GridView控件恢复为编辑前的状态。即更新完了就得回到非编辑状态
            databind(); //更新完了之后，就得重新绑定，即重新从数据库中读取刚才更新的数据。

        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            KQ_Shift sh = new KQ_Shift();
            sh.Name = tbName.Text;
            sh.isClockOn = cbShangban.Checked;
            sh.ClockOnTime = tbShangbanTime.Text;
            sh.isClockOff = cbXiaban.Checked;
            sh.ClockOffTime = tbXiabanTime.Text;
            sh.isDefault = cbDefault.Checked;
            sh.Remark = tbRemark.Text;
            BLL.Application.KQ.SchedulingManagement.addShift(sh);
            databind();
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            initTable();
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            initTable();
        }

        protected void lbSaveSched_Click(object sender, EventArgs e)
        {
            putResultToList();
            lbMessage.Text = "";
            foreach( KQ_Scheduling sh in listSchedulingResult)
            {
                lbMessage.Text += sh.Date.ToString() + "------";
            }
        }

        protected void putResultToList()
        {
            listSchedulingResult.Clear();
            for (int j = 0; j < 6; j++)
            {
                TableRow tr = (TableRow)tableMonth.Controls[j + 1];
                for (int i = 0; i < 7; i++)
                {
                    TableCell cell = (TableCell)tr.Controls[i];
                    Label lb = cell.FindControl("lb" + j + i) as Label;
                    CheckBox cb = cell.FindControl("cb" + j + i) as CheckBox;
                    DropDownList ddl = cell.FindControl("ddl" + j + i) as DropDownList;
                    if (cb.Checked)
                    {
                        KQ_Scheduling sh = new KQ_Scheduling();
                        sh.Year = Convert.ToInt32( lbYear.Text);
                        sh.Month = Convert.ToInt32(ddlMonth.SelectedValue);
                        sh.Day = Convert.ToInt32(lb.Text);
                        sh.Date = new DateTime((int)sh.Year, (int)sh.Month, (int)sh.Day);
                        sh.ShiftId = Convert.ToInt32( ddl.SelectedValue);
                        sh.WeekDay = i;

                        listSchedulingResult.Add(sh);
                    }
                    
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            createTable();
        }

        protected void createTable()
        {

            listShift = BLL.Application.KQ.SchedulingManagement.getShift();
            for (int j = 0; j < 6; j++)
            {
                TableRow tr = new TableRow();
                for (int i = 0; i < 7; i++)
                {
                    TableCell cell = new TableCell();
                    

                    Label lb = new Label();
                    lb.Font.Size = FontUnit.Large;
                    lb.Font.Bold = true;
                    lb.ID = "lb"+j+i;
                    CheckBox cb = new CheckBox();
                    cb.ID = "cb" +j+ i;
                    DropDownList ddl = new DropDownList();
                    ddl.ID = "ddl" +j+ i;

                    cell.Controls.Add(lb);
                    cell.Controls.Add(getNewLiteral());
                    cell.Controls.Add(cb);
                    cell.Controls.Add(getNewLiteral());
                    cell.Controls.Add(ddl);

                    tr.Cells.Add(cell);
                }
                tableMonth.Controls.Add(tr);
            }
        }
       
    }
}