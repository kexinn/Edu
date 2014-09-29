<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="statistic.aspx.cs" Inherits="web.Application.KQ.Attendance.statistic" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/calendar/WdatePicker.js"></script>

</head>


<body>
    <form id="form1" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">请假管理</a></li>
                <li><a href="#">请假统计</a></li>
            </ul>
        </div>

        <div class="rightinfo">


            <div class="toolsearch">
                <div class="pullleft">

                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="inline" ControlToValidate="tbUsername" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        开始时间：<asp:TextBox ID="tbStartTime" runat="server" CssClass="dfinput " Width="120px"  onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="inline" ControlToValidate="tbStartTime" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        结束时间：<asp:TextBox ID="tbEndTime" runat="server" CssClass="dfinput " Width="120px"  onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="inline" ControlToValidate="tbEndTime" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        
                 </div>
                                 
                 <div class="pullleft">
                        <asp:LinkButton ID="lbSearch" runat="server"
                            onclick="lbSearch_Click" ><i class="mbtn"><img src="/media/images/ico06.png" />统计</i></asp:LinkButton>
                     </div>
                <div class="clear"></div>
            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            
                               
        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>

</html>

