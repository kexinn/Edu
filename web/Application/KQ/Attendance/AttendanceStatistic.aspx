<%@ Page Language="C#"  EnableEventValidation="false"  AutoEventWireup="true" CodeBehind="AttendanceStatistic.aspx.cs" Inherits="web.Application.KQ.Attendance.AttendanceStatistic" %>

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
</head>
<body>
    <form id="form1" runat="server">
<div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">请假管理</a></li>
                <li><a href="#">请假查询</a></li>
            </ul>
        </div>

        <div class="rightinfo">


            <div class="toolsearch">
                <div class="pullleft">
                    请假日期：<asp:TextBox ID="tbStartTime" CssClass="dfinput" Width="120px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                    &nbsp;请假人：<asp:TextBox ID="tbApplyUser" CssClass="dfinput" Width="120px" runat="server"></asp:TextBox>
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
                   <%-- <asp:TextBox ID="TextBox1" CssClass="dfinput" runat="server" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm:ss',minDate:'2008-03-08 11:30:00',maxDate:'2100-03-10 20:59:30'})"></asp:TextBox>
               --%> </div>

                <div class="pullleft">
                    <asp:LinkButton ID="lbStatisc" runat="server"
                        OnClick="lbStatisc_Click"> <i class="mbtn"><img src="/media/images/ico06.png" />查询</i></asp:LinkButton>
                </div>
                <div class="pullright">
                    <asp:LinkButton ID="lbOutExcel" runat="server" Style="margin-right: 10px;" OnClick="lbOutExcel_Click"><i class="mbtn"><img src="/media/images/f05.png" />导出查询</i></asp:LinkButton>

                </div>
                <div class="clear"></div>
            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <asp:Panel ID="PanelDaka" runat="server">
            <div class="formtitle"><span>请假名单</span></div>
            <asp:GridView ID="gvAttendance" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Id" Width="100%" 
                CssClass="tablelist" >
                <Columns>
                   
                    <asp:BoundField DataField="applyTime" HeaderText="申请时间">
                    <HeaderStyle Width="130px" />
                    </asp:BoundField>

                    <asp:BoundField DataField="username" HeaderText="请假人">
                    <HeaderStyle Width="80px" />
                    </asp:BoundField>
                    
                    <asp:TemplateField HeaderText="起止时间">
                        <ItemTemplate>
                            <asp:Label ID="lbSpanDate" runat="server" OnDataBinding="lbSpanDate_DataBinding"></asp:Label>
                        </ItemTemplate>
                    <HeaderStyle Width="320px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="请假时长">
                        <ItemTemplate>
                            <asp:Label ID="lbSpanDiscription" runat="server" OnDataBinding="lbSpanDiscription_DataBinding"></asp:Label>
                        </ItemTemplate>
                    <HeaderStyle Width="120px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="请假类型">
                        <ItemTemplate>
                            <asp:Label ID="lbType" runat="server"><%# Eval("applytype")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="90px" />
                    </asp:TemplateField>
                   
                    <asp:BoundField DataField="dept" HeaderText="部门">
                    <HeaderStyle Width="80px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <asp:Label ID="lbStatus" runat="server" OnDataBinding="lbStatus_DataBinding"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="ApprovalName" HeaderText="审批人">
                    <HeaderStyle Width="80px" />
                    </asp:BoundField>

                   
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                             <asp:LinkButton ID="lbView" runat="server" OnDataBinding="lbView_DataBinding">详情</asp:LinkButton>
                            &nbsp;&nbsp;
                             <asp:LinkButton ID="lbHistory" runat="server" OnDataBinding="lbHistory_DataBinding">审批历史</asp:LinkButton>
                         </ItemTemplate>
                        <ItemStyle Width="130px" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>

             <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
                      OnPageChanged="AspNetPager1_PageChanged"  
                      ShowCustomInfoSection="left" 
                      ShowInputBox="Auto" 
                      AlwaysShow="false"
                      CustomInfoHTML="<font color='#333333'>共 %RecordCount% 行/每页%PageSize%行 第%CurrentPageIndex%/%PageCount%页</font>" 
                      NumericButtonCount="10" 
                      FirstPageText="首页" 
                      LastPageText="末页" 
                      NextPageText="下页" 
                      PrevPageText="上页" 
                      CustomInfoSectionWidth="250px" 
                      CssClass="page_text" 
                      ShowBoxThreshold="11" 
                      InputBoxClass="pagetext" 
                      SubmitButtonClass="pagebtn" 
                      SubmitButtonText="Go">
                    </webdiyer:AspNetPager>

            
                
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            </asp:Panel>

            
        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>
</html>