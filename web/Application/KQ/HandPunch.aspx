<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HandPunch.aspx.cs" Inherits="web.Application.KQ.HandPunch" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>

</head>


<body>
    <form id="form1" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">考勤管理</a></li>
                <li><a href="#">手工打卡</a></li>
            </ul>
        </div>

        <div class="rightinfo">


            <div class="toolsearch">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ToolkitScriptManager>
                <div class="pullleft">

                                        姓名：<asp:TextBox ID="tbUsername" runat="server" CssClass="dfinput " Width="120px"></asp:TextBox>
                                        
                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="tbUsername" ServicePath="/webservice/user/UserWebService.asmx"  ServiceMethod="GetUsers" CompletionSetCount="10" MinimumPrefixLength="1"></asp:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="inline" ControlToValidate="tbUsername" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        选择打卡日期：<asp:TextBox ID="tbStartTime" runat="server" CssClass="dfinput " Width="120px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" runat="server" TargetControlID="tbStartTime"></asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="inline" ControlToValidate="tbStartTime" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        

                 </div>
                                 
                 <div class="pullleft">
                        <asp:LinkButton ID="lbClockOnBu" runat="server" style="margin-right:10px;"
                            onclick="lbClockOnBu_Click" ><i class="mbtn inline">上班补打</i></asp:LinkButton>
                     <asp:LinkButton ID="lbClockOffBu" runat="server" 
                            onclick="lbClockOffBu_Click" ><i class="mbtn inline">下班补打</i></asp:LinkButton>
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