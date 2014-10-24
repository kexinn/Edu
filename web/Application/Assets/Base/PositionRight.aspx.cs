using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.Assets.Base
{
    public partial class PositionRight : System.Web.UI.Page
    {
        public static  string id;
        public static  string level;
        public static  Int32 int_id;
        public static  Int32 pre_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                databind();
            }
        }

        protected void databind()
        {
            id = Request.QueryString["id"];
            level = Request.QueryString["level"];

            if (!String.IsNullOrEmpty(id))
            {
                ViewState["mode"] = "update";
                ViewState["id"] = id;
                ViewState["level"] = level;
                lbMode.Text = "修改模式";

                tbPositionId.Enabled = false;
                switch(level)
                {
                    case "A":
                        int_id= Convert.ToInt32( id.Substring(1)) ;
                        AS_Position1 p1 = BLL.Application.Assets.Base.Position.getPosition1ById(int_id);
                        
                        tbPositionId.Text = p1.Position1ID.ToString();
                        tbName.Text = p1.Position1Name;
                        tbRemark.Text = p1.Position1Remark;
                        break;
                    case "B":
                        pre_id = Convert.ToInt32(id.Substring(1,id.IndexOf("B")-1));
                        int_id = Convert.ToInt32(id.Substring(id.IndexOf("B")+1));
                        AS_Position2 p2 = BLL.Application.Assets.Base.Position.getPosition2ById(int_id);
                        
                        tbPositionId.Text = p2.Position2ID.ToString();
                        tbName.Text = p2.Position2Name;
                        tbRemark.Text = p2.Position2Remark;
                        break;
                    case "C":
                        pre_id = Convert.ToInt32(id.Substring(id.IndexOf("B") + 1, id.IndexOf("C") - id.IndexOf("B") - 1));
                        int_id = Convert.ToInt32(id.Substring(id.IndexOf("C")+1));
                        AS_Position3 p3 = BLL.Application.Assets.Base.Position.getPosition3ById(int_id);
                        
                        tbPositionId.Text = p3.Position3ID.ToString();
                        tbName.Text = p3.Position3Name;
                        tbRemark.Text = p3.Position3Remark;
                        break;
                }
                
            }
            else
            {
                ViewState["mode"] = "add";
                lbMode.Text = "添加模式";
            }
        }
        
        protected void clearData()
        {

            tbPositionId.Text = "";
            tbName.Text = "";
            tbRemark.Text = "";

            ViewState["mode"] = "add";
            lbMode.Text = "添加模式";
            tbPositionId.Enabled = false;
        }
        protected void lbAdd_Click(object sender, EventArgs e)
        {
            clearData();
        }
        
       
       

        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(tbPositionId.Text))
                {
                    switch(level)
                    {
                        case "A":
                            BLL.Application.Assets.Base.Position.deletePosition1ById(Convert.ToInt32(tbPositionId.Text));
                            break;
                        case "B":
                            BLL.Application.Assets.Base.Position.deletePosition2ById(Convert.ToInt32(tbPositionId.Text));
                            break;
                        case "C":
                            BLL.Application.Assets.Base.Position.deletePosition3ById(Convert.ToInt32(tbPositionId.Text));
                            break;
                    }
                    Response.Write("<script language=javascript>");
                    Response.Write("window.parent.lframe.location='PositionLeft.aspx';<");
                    Response.Write("/script>");
                    BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "删除成功！");
                    clearData();
                }
            }
            catch (Exception ex)
            {
                lbMessage.Text = "删除错误：" + ex.Message;
            }
        }
        
        protected void lbSave_Click(object sender, EventArgs e)
        {
            if ((string)ViewState["mode"] == "add")
            {
                try
                {
                    switch(level ){
                        case "/":
                            AS_Position1 p1  = new AS_Position1();
                            p1.Position1Name = tbName.Text;
                            p1.Position1Remark = tbRemark.Text;
                            BLL.Application.Assets.Base.Position.createPosition1(p1);
                            break;
                        case "A":
                            AS_Position2 p2  = new AS_Position2();
                            p2.Position1ID = int_id;
                            p2.Position2Name = tbName.Text;
                            p2.Position2Remark = tbRemark.Text;
                            BLL.Application.Assets.Base.Position.createPosition2(p2);      
                            break;
                        case "B":
                            AS_Position3 p3  = new AS_Position3();
                            p3.Position2ID = int_id;
                            p3.Position3Name = tbName.Text;
                            p3.Position3Remark = tbRemark.Text;
                            BLL.Application.Assets.Base.Position.createPosition3(p3);    
                            break;
                   }
                    Response.Write("<script language=javascript>");
                    Response.Write("window.parent.lframe.location='PositionLeft.aspx';<");
                    Response.Write("/script>");
                    BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "添加成功！");
                    lbMode.Text = "修改模式";
                    ViewState["mode"] = "update";
                }
                catch (Exception ex)
                {
                    lbMessage.Text = "添加错误：" + ex.Message;
                }

            }
            else
                if ((string)ViewState["mode"] == "update")
                {
                    try
                    {
                        switch(level){
                            case "A":
                                    AS_Position1 p1 = new AS_Position1();
                                    p1.Position1ID = Convert.ToInt32(tbPositionId.Text);
                                    p1.Position1Name = tbName.Text;
                                    p1.Position1Remark = tbRemark.Text;
                                    BLL.Application.Assets.Base.Position.updatePosition1(p1);
                                    break;
                            case "B":
                                    AS_Position2 p2 = new AS_Position2();
                                    p2.Position2ID = int_id ;
                                    p2.Position1ID = pre_id;
                                    p2.Position2Name = tbName.Text;
                                    p2.Position2Remark = tbRemark.Text;
                                    BLL.Application.Assets.Base.Position.updatePosition2(p2);
                                    break;
                            case "C":
                                    AS_Position3 p3 = new AS_Position3();
                                    p3.Position3ID = int_id ;
                                    p3.Position2ID = pre_id;
                                    p3.Position3Name = tbName.Text;
                                    p3.Position3Remark = tbRemark.Text;
                                    BLL.Application.Assets.Base.Position.updatePosition3(p3);
                                    break;

                        }
                        Response.Write("<script language=javascript>");
                        Response.Write("window.parent.lframe.location='PositionLeft.aspx';<");
                        Response.Write("/script>");
                        BLL.pub.PubClass.showAlertMessage(Page, ClientScript, "修改成功！");
                        lbMode.Text = "修改模式";
                        ViewState["mode"] = "update";
                    }
                    catch (Exception ex)
                    {
                        lbMessage.Text = "修改错误：" + ex.Message;
                    }
                }
        }
    }
}