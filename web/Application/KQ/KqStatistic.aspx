<%@ Page Language="C#"  EnableEventValidation="false" AutoEventWireup="true" CodeBehind="KqStatistic.aspx.cs" Inherits="web.Application.KQ.KqStatistic" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>无标题文档</title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/calendar/WdatePicker.js"></script>
    
    <style type="text/css">

        span{display:inline;}
    </style>   
     <script type="text/javascript">
                    function check() {
                        return confirm("确定撤销？");
                    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
<div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">请假管理</a></li>
                <li><a href="#">考勤统计</a></li>
            </ul>
        </div>


            <div class="toolsearch">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ToolkitScriptManager>
                <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional"  runat="server">
    <ContentTemplate> 
               
                <div class="pullleft">
                     起始日期：<asp:TextBox ID="tbDate" CssClass="dfinput" Width="120px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbDate" ErrorMessage="*必选" ForeColor="Red"></asp:RequiredFieldValidator>
                    结束日期：<asp:TextBox ID="tbEndDate" CssClass="dfinput" Width="120px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbEndDate" ErrorMessage="*必选" ForeColor="Red"></asp:RequiredFieldValidator>
                    &nbsp;<%-- <asp:TextBox ID="TextBox1" CssClass="dfinput" runat="server" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm:ss',minDate:'2008-03-08 11:30:00',maxDate:'2100-03-10 20:59:30'})"></asp:TextBox>
               --%></div>

                <div class="pullleft">
                    <asp:LinkButton ID="lbSearch" runat="server" OnClick="lbSearch_Click" > <i class="mbtn"><img src="/media/images/ico06.png" />查询</i></asp:LinkButton>
                </div>
                        <div class="clear">
                    <br />
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2" >
        <ProgressTemplate>
           
            <font color="blue" >正在计算<asp:Image ID="Image1" runat="server" ImageUrl="/media/images/jindu.gif" /></font>
            
        </ProgressTemplate>
    </asp:UpdateProgress>
                </div>
                <div class="clear"></div>
            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <div class="formtitle"><span>考勤统计</span></div>
             

        
            <asp:GridView ID="gvResult" runat="server"
                Width="100%" 
                CssClass="tablelist" >
            </asp:GridView>
 </ContentTemplate></asp:UpdatePanel> 
                
                <div class="pullright">
                    <asp:LinkButton ID="lbOutExcel" runat="server" Style="margin-right: 10px;" OnClick="lbOutExcel_Click"><i class="mbtn"><img src="/media/images/f05.png" />导出EXCEL</i></asp:LinkButton>
                </div>    
        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>
</html>
