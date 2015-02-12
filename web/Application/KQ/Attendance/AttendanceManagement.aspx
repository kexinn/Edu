<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceManagement.aspx.cs" Inherits="web.Application.KQ.Attendance.AttendanceManagement" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/calendar/WdatePicker.js"></script>
    <script type="text/javascript" src="/media/js/myjs.js"></script>
    
    <script type="text/javascript">
        function check() {
            return confirm("确定删除该请假记录？");
        }
    </script>
    <style type="text/css">

        span{display:inline;}
        #TextArea1 {
            height: 132px;
            width: 478px;
        }
        #tbReason {
            height: 115px;
            width: 491px;
        }
        .auto-style2 {
            width: 122px;
        }
        .auto-style3 {
            width: 122px;
            height: 42px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">请假管理</a></li>
            </ul>
        </div>

        <div class="rightinfo">
            <!-- ****************** -->
            
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <asp:Panel ID="PanelApply" runat="server">
            <div style="margin:auto;width:700px;">
                <h1 align="center">请假单</h1>
                <table class="tableborder" style="width:100%;">
                    <tr>
                        <td class="auto-style2">姓名</td>
                        <td><span >
                            <asp:Label ID="lbUsername" runat="server"></asp:Label>
                            </span></td>
                        <td>部门</td>
                        <td><span>
                            <asp:Label ID="lbDept" runat="server"></asp:Label>
                            </span></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">申请时间</td>
                        <td><span lang="EN-US">
                            <asp:Label ID="lbApplyTime" runat="server"></asp:Label>
                            </span></td>
                        <td>请假类型</td>
                        <td><span lang="EN-US">
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="dfinput" ValidationGroup="apply" Width="100" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlType" ErrorMessage="*必选项" ForeColor="Red" ValidationGroup="apply"></asp:RequiredFieldValidator>
                            </span></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">请假时间</td>
                        <td colspan="3"><span>自：<asp:TextBox ID="tbStartTime" runat="server" CssClass="dfinput" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm:ss',minDate:'2008-03-08 11:30:00',maxDate:'2100-03-10 20:59:30'})" ValidationGroup="apply" Width="200px" AutoPostBack="True" OnTextChanged="tbStartTime_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbStartTime" ErrorMessage="*必选项" ForeColor="Red" ValidationGroup="apply"></asp:RequiredFieldValidator>
                            <span >至：<asp:TextBox ID="tbEndTime" runat="server" CssClass="dfinput" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm:ss',minDate:'2008-03-08 11:30:00',maxDate:'2100-03-10 20:59:30'})" ValidationGroup="apply" Width="200px" AutoPostBack="True" OnTextChanged="tbEndTime_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbEndTime" ErrorMessage="*必选项" ForeColor="Red" ValidationGroup="apply"></asp:RequiredFieldValidator>
                            </span></span></td>
                    </tr>
                    <tr>
                        <td class="auto-style3">请假时长</td>
                        <td class="seachform" colspan="3">共请假:<asp:Label ID="lbDaySpan" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="Larger"></asp:Label>
                            &nbsp;天 
                            <asp:Label ID="lbTimeSpan" runat="server" ForeColor="Red" Font-Bold="True" Font-Size="Larger"></asp:Label>
                            &nbsp;小时 
                            <asp:Label ID="lbMinute" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Red"></asp:Label>
                            <asp:Label ID="lbMtip" runat="server" Text="分钟" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">请假事由</td>
                        <td colspan="3">
                            <textarea id="tbReason" runat="server" cols="20" name="S1" rows="1"></textarea><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbReason" ErrorMessage="*必选项" ForeColor="Red" ValidationGroup="apply"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <asp:Button ID="btApply" runat="server" Text="保存" CssClass="btn" ValidationGroup="apply"  OnClientClick="javascript:showConfirm('确定提交?')"  OnClick="btApply_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btDelete" runat="server" CssClass="btn" OnClick="btDelete_Click" OnClientClick="javascript:return check();" Text="删除" />
            </div>

        </asp:Panel>

            
                               

        </div>
        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>
</html>
