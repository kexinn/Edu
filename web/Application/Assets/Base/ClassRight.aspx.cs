using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace web.Application.Assets.Base
{
    public partial class ClassRight : System.Web.UI.Page
    {
        public static string id;
        public static string level;
        public static Int32 int_id;
        public static Int32 pre_id;
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

                tbClassId.Enabled = false;
                switch (level)
                {
                    case "R":
                        int_id = Convert.ToInt32(id.Substring(1));
                        AS_Class0 p0 = BLL.Application.Assets.Base.Class.getClass0ById(int_id);

                        tbClassId.Text = p0.Class0ID.ToString();
                        tbBH.Text = p0.Class0BH;
                        tbName.Text = p0.Class0Name;
                        tbRemark.Text = p0.Class0Remark;
                        break;
                    case "A":
                        pre_id = Convert.ToInt32(id.Substring(id.IndexOf("R") + 1, id.IndexOf("A") - 1));
                        int_id = Convert.ToInt32(id.Substring(id.IndexOf("A") + 1));
                        AS_Class1 p1 = BLL.Application.Assets.Base.Class.getClass1ById(int_id);

                        tbClassId.Text = p1.Class1ID.ToString();
                        tbBH.Text = p1.Class1BH;
                        tbName.Text = p1.Class1Name;
                        tbRemark.Text = p1.Class1Remark;
                        break;                  
                    case "B":
                        pre_id = Convert.ToInt32(id.Substring(id.IndexOf("A") + 1, id.IndexOf("B") - id.IndexOf("A") - 1));

                        int_id = Convert.ToInt32(id.Substring(id.IndexOf("B") + 1));
                        AS_Class2 p2 = BLL.Application.Assets.Base.Class.getClass2ById(int_id);

                        tbClassId.Text = p2.Class2ID.ToString();
                        tbBH.Text = p2.Class2BH;
                        tbName.Text = p2.Class2Name;
                        tbRemark.Text = p2.Class2Remark;
                        break;
                    case "C":
                        pre_id = Convert.ToInt32(id.Substring(id.IndexOf("B") + 1, id.IndexOf("C") - id.IndexOf("B") - 1));
                        int_id = Convert.ToInt32(id.Substring(id.IndexOf("C") + 1));
                        AS_Class3 p3 = BLL.Application.Assets.Base.Class.getClass3ById(int_id);

                        tbClassId.Text = p3.Class3ID.ToString();
                        tbBH.Text = p3.Class3BH;
                        tbName.Text = p3.Class3Name;
                        tbRemark.Text = p3.Class3Remark;
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

            tbClassId.Text = "";
            tbBH.Text = "";
            tbName.Text = "";
            tbRemark.Text = "";

            ViewState["mode"] = "add";
            lbMode.Text = "添加模式";
            tbClassId.Enabled = false;
        }
        protected void lbAdd_Click(object sender, EventArgs e)
        {
            clearData();
        }




        protected void lbDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(tbClassId.Text))
                {
                    switch (level)
                    {
                        case "R":
                            BLL.Application.Assets.Base.Class.deleteClass0ById(Convert.ToInt32(tbClassId.Text));
                            break;
                        case "A":
                            BLL.Application.Assets.Base.Class.deleteClass1ById(Convert.ToInt32(tbClassId.Text));
                            break;
                        case "B":
                            BLL.Application.Assets.Base.Class.deleteClass2ById(Convert.ToInt32(tbClassId.Text));
                            break;
                        case "C":
                            BLL.Application.Assets.Base.Class.deleteClass3ById(Convert.ToInt32(tbClassId.Text));
                            break;
                    }
                    Response.Write("<script language=javascript>");
                    Response.Write("window.parent.lframe.location='ClassLeft.aspx';<");
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
                    switch (level)
                    {
                        case "/":
                            AS_Class0 p0 = new AS_Class0();
                            p0.Class0Name = tbName.Text;
                            p0.Class0BH = tbBH.Text;
                            p0.Class0Remark = tbRemark.Text;
                            BLL.Application.Assets.Base.Class.createClass0(p0);
                            break;
                        case "R":
                            AS_Class1 p1 = new AS_Class1();
                            p1.Class0ID = int_id;
                            p1.Class1Name = tbName.Text;
                            p1.Class1BH = tbBH.Text;
                            p1.Class1Remark = tbRemark.Text;
                            BLL.Application.Assets.Base.Class.createClass1(p1);
                            break;
                        case "A":
                            AS_Class2 p2 = new AS_Class2();
                            p2.Class1ID = int_id;
                            p2.Class2BH = tbBH.Text;
                            p2.Class2Name = tbName.Text;
                            p2.Class2Remark = tbRemark.Text;
                            BLL.Application.Assets.Base.Class.createClass2(p2);
                            break;
                        case "B":
                            AS_Class3 p3 = new AS_Class3();
                            p3.Class2ID = int_id;
                            p3.Class3BH = tbBH.Text;
                            p3.Class3Name = tbName.Text;
                            p3.Class3Remark = tbRemark.Text;
                            BLL.Application.Assets.Base.Class.createClass3(p3);
                            break;
                    }
                    Response.Write("<script language=javascript>");
                    Response.Write("window.parent.lframe.location='ClassLeft.aspx';<");
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
                        switch (level)
                        {
                            case "R":
                                AS_Class0 p0 = new AS_Class0();
                                p0.Class0ID = Convert.ToInt32(tbClassId.Text);
                                p0.Class0BH = tbBH.Text;
                                p0.Class0Name = tbName.Text;
                                p0.Class0Remark = tbRemark.Text;
                                BLL.Application.Assets.Base.Class.updateClass0(p0);
                                break;
                            case "A":
                                AS_Class1 p1 = new AS_Class1();
                                p1.Class1ID = Convert.ToInt32(tbClassId.Text);
                                p1.Class1BH = tbBH.Text;
                                p1.Class0ID = pre_id;
                                p1.Class1Name = tbName.Text;
                                p1.Class1Remark = tbRemark.Text;
                                BLL.Application.Assets.Base.Class.updateClass1(p1);
                                break;
                            case "B":
                                AS_Class2 p2 = new AS_Class2();
                                p2.Class2ID = int_id;
                                p2.Class2BH = tbBH.Text;
                                p2.Class1ID = pre_id;
                                p2.Class2Name = tbName.Text;
                                p2.Class2Remark = tbRemark.Text;
                                BLL.Application.Assets.Base.Class.updateClass2(p2);
                                break;
                            case "C":
                                AS_Class3 p3 = new AS_Class3();
                                p3.Class3ID = int_id;
                                p3.Class3BH = tbBH.Text;
                                p3.Class2ID = pre_id;
                                p3.Class3Name = tbName.Text;
                                p3.Class3Remark = tbRemark.Text;
                                BLL.Application.Assets.Base.Class.updateClass3(p3);
                                break;
                                
                        }
                        Response.Write("<script language=javascript>");
                        Response.Write("window.parent.lframe.location='ClassLeft.aspx';<");
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