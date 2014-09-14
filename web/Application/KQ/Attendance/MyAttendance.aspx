<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAttendance.aspx.cs" Inherits="web.Application.KQ.Attendance.MyAttendance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/calendar/WdatePicker.js"></script>

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
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">考勤管理</a></li>
                <li><a href="#">请假管理</a></li>
                <li><a href="#">我的请假</a></li>
            </ul>
        </div>

        <div class="rightinfo">
            <div class="tools">

                <ul class="toolbar">
                    <li><span>
                        <img src="/media/images/t01.png" /></span>
                        <asp:LinkButton ID="lbAdd" runat="server"
                            OnClick="lbAdd_Click">添加申请 </asp:LinkButton></li>
                </ul>

            </div>
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
                        <td><span lang="EN-US">
                            <asp:DropDownList ID="ddlDept" runat="server" CssClass="dfinput" ValidationGroup="apply" Width="100">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="1">经贸部</asp:ListItem>
                                <asp:ListItem Value="2">机电部</asp:ListItem>
                                <asp:ListItem Value="3">后勤</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDept" ErrorMessage="*必选项" ForeColor="Red" ValidationGroup="apply"></asp:RequiredFieldValidator>
                            </span></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">申请时间</td>
                        <td><span lang="EN-US">
                            <asp:Label ID="lbApplyTime" runat="server"></asp:Label>
                            </span></td>
                        <td>请假类型</td>
                        <td><span lang="EN-US">
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="dfinput" ValidationGroup="apply" Width="100">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlType" ErrorMessage="*必选项" ForeColor="Red" ValidationGroup="apply"></asp:RequiredFieldValidator>
                            </span></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">请假时间</td>
                        <td colspan="3"><span>自：<asp:TextBox ID="tbStartTime" runat="server" CssClass="dfinput" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm:ss',minDate:'2008-03-08 11:30:00',maxDate:'2100-03-10 20:59:30'})" ValidationGroup="apply" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbStartTime" ErrorMessage="*必选项" ForeColor="Red" ValidationGroup="apply"></asp:RequiredFieldValidator>
                            <span >至：<asp:TextBox ID="tbEndTime" runat="server" CssClass="dfinput" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm:ss',minDate:'2008-03-08 11:30:00',maxDate:'2100-03-10 20:59:30'})" ValidationGroup="apply" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbEndTime" ErrorMessage="*必选项" ForeColor="Red" ValidationGroup="apply"></asp:RequiredFieldValidator>
                            </span></span></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">请假事由</td>
                        <td colspan="3">
                            <textarea id="tbReason" runat="server" cols="20" name="S1" rows="1"></textarea></td>
                    </tr>
                </table>
                <br />
                <asp:Button ID="btApply" runat="server" Text="提交" CssClass="btn" ValidationGroup="apply" OnClick="btApply_Click" />
      
            </div>

        </asp:Panel>

            
                               

        </div>
        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>
</html>
