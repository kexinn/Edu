<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPlanRight.aspx.cs" Inherits="web.Application.WorkPlan.WorkPlanRight" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/js/jquery.jqprint-0.3.js"></script>
        <script language="javascript" type="text/jscript">
        function print() {
            $("#print").jqprint();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="rightinfo">
        
            <div class="tools">

                <ul class="toolbar">
                    <li><span>
                        <img src="/media/images/t01.png" /></span>
                        
                    <a href="#" onclick="print()">打印</a></li>
                </ul>
                <div style="float:left;"><asp:DropDownList ID="ddlDeptList" CssClass="dfinput" Height="35px" Width="120px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDeptList_SelectedIndexChanged">
                        </asp:DropDownList></div>
             </div>
        <asp:Panel ID="PanelSchool" runat="server">
    <div  id="print" style="float:left;width:100%">

        <div style="text-align:center;font:large bold;"> 本月学校工作行事历表</div>
        <table class="tableborder" style="width:100%;">
           
            <tr>
                <td class="textcenter" style="width:100px; border:solid 1px #000000;">
                    <asp:Label ID="lbMonth" style="font:medium bold;" runat="server"></asp:Label>&nbsp;</td>
                <td >
                    <table style="width:100%;">
                        <tr>
                <td style="width:120px;font:medium bold;" ><b>日期</b></td>
                <td style="font:medium bold;"><b>工作安排</b></td>
                <td style="width:120px;font:medium bold;"><b>负责部门</b></td>
                <td style="width:70px;font:medium bold;"><b>是否完成</b></td>
                <td style="width:150px;font:medium bold;"><b>未完成原因</b></td>
                            </tr>
                        <asp:Repeater ID="RepeaterWorkMonth" runat="server">
                            <ItemTemplate>
                        <tr >
                            <td ondatabinding="Unnamed_DataBinding" runat="server"><%# Eval("planPeriod") %></td>
                            <td ><%# Eval("content")%></td>
                            <td ><%# Eval("deptName")%></td>
                            <td > <asp:Image ID="imgState" OnDataBinding="imgState_DataBinding" runat="server" /></td>
                            <td ><%# Eval("evalutionContent")%></td>
                        </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                       
                    </table>
                </td>
            </tr>
            </table>
        </div>
    </asp:Panel>
        <asp:Panel ID="PanelDept" runat="server">
            <div  id="print1" style="float:left;width:100%">

        <div style="text-align:center;font:large bold;"> 本周各部门工作计划</div>
        <table class="tableborder" style="width:100%;">
           
            <tr>
                <td class="textcenter" style="width:100px; border:solid 1px #000000;">
                    <asp:Label ID="lbDate" style="font:medium bold;" runat="server"></asp:Label>&nbsp;</td>
                <td >
                    <table style="width:100%;">
                        <tr>
                <td style="font:medium bold;"><b>工作计划</b></td>
                <td style="width:160px;font:medium bold;"><b>部门</b></td>
                            </tr>
                        <asp:Repeater ID="RepeaterDept" runat="server">
                            <ItemTemplate>
                        <tr >
                            <td ><%# Eval("content")%><br />&nbsp;</td>
                            <td ><%# Eval("deptName")%></td>
                        </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                       
                    </table>
                </td>
            </tr>
            </table>
        </div>

        </asp:Panel>
    </div>
    </form>
</body>
</html>
