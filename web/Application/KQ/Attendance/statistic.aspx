<%@ Page Language="C#"  EnableEventValidation="false"  AutoEventWireup="true" CodeBehind="statistic.aspx.cs" Inherits="web.Application.KQ.Attendance.statistic" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <div class="rightinfo">


            <div class="toolsearch">
                <div class="pullleft">

                                        开始时间：<asp:TextBox ID="tbStartTime" runat="server" CssClass="dfinput " Width="120px"  onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="inline" ControlToValidate="tbStartTime" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        结束时间：<asp:TextBox ID="tbEndTime" runat="server" CssClass="dfinput " Width="120px"  onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="inline" ControlToValidate="tbEndTime" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        部门：<asp:DropDownList ID="DropDownListDept" runat="server" CssClass="dfinput" Width="120px" Height="34px">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="经贸部">经贸部</asp:ListItem>
                        <asp:ListItem Value="机电部">机电部</asp:ListItem>
                        <asp:ListItem Value="后勤">后勤</asp:ListItem>
                       
                    </asp:DropDownList>

                    状态：<asp:DropDownList ID="DropDownListStatus" runat="server" CssClass="dfinput" Width="120px" Height="34px">
                        <asp:ListItem Value=""></asp:ListItem>
                        <asp:ListItem Value="审批中">审批中</asp:ListItem>
                        <asp:ListItem Value="审批通过">审批通过</asp:ListItem>
                        <asp:ListItem Value="审批拒绝">审批拒绝</asp:ListItem>
                       
                    </asp:DropDownList>
                    
                    请假类型：<asp:DropDownList ID="DropDownListType" runat="server" CssClass="dfinput" Width="120px" Height="34px">
                       
                    </asp:DropDownList>
                 </div>
                     
                <div class="pullright">
                    <asp:LinkButton ID="lbOutExcel" runat="server" Style="margin-right: 10px;" OnClick="lbOutExcel_Click"><i class="mbtn"><img src="/media/images/f05.png" />导出统计结果</i></asp:LinkButton>

                </div>
    <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional"  runat="server">
    <ContentTemplate>             
                 <div class="pullleft">
                      
                        <asp:LinkButton ID="lbCompute" runat="server" OnClick="lbCompute_Click"><i class="mbtn" ><img src="/media/images/t02.png" />开始统计</i></asp:LinkButton>
                      
                     </div>
        
                <div class="clear">
                    
      <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2" >
        <ProgressTemplate>
           
            <font color="blue" >正在计算<asp:Image ID="Image1" runat="server" ImageUrl="/media/images/jindu.gif" /></font>
            
        </ProgressTemplate>
    </asp:UpdateProgress>

                </div>
            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>

                
                <asp:GridView ID="GridView1" runat="server" CssClass="tablelist">
                </asp:GridView>
 </ContentTemplate></asp:UpdatePanel> 
                <asp:GridView ID="GridView2" runat="server">
                </asp:GridView>
            </div>
            
                               
        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>

</html>

