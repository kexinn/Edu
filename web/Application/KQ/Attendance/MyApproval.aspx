﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyApproval.aspx.cs" Inherits="web.Application.KQ.Attendance.MyApproval" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/calendar/WdatePicker.js"></script>
    
    <script type="text/javascript">
        function check() {
            return confirm("确定撤销？");
        }
    </script>
    <style>
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
                <li><a href="#">我的审批</a></li>
            </ul>
        </div>

        <div class="rightinfo">
            
            <!-- ****************** -->
            
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            
            <asp:GridView ID="gvAttendance" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Id" Width="100%"  OnRowCancelingEdit="gvAttendance_RowCancelingEdit"
                OnRowEditing="gvAttendance_RowEditing"
                OnRowUpdating="gvAttendance_RowUpdating"
                CssClass="tablelist" OnRowCommand="gvAttendance_RowCommand">
                <Columns>
                   
                    <asp:BoundField DataField="username" HeaderText="请假人">
                    <HeaderStyle Width="80px" />
                    </asp:BoundField>
                    
                    <asp:TemplateField HeaderText="起止时间">
                        <ItemTemplate>
                            <asp:Label ID="lbSpanDate" runat="server" OnDataBinding="lbSpanDate_DataBinding"></asp:Label>
                        </ItemTemplate>
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

                    <asp:BoundField DataField="ApprovalName" HeaderText="当前审批人">
                    <HeaderStyle Width="80px" />
                    </asp:BoundField>
                    
                    <asp:TemplateField HeaderText="拒绝理由">
                         <EditItemTemplate>
                            <asp:TextBox ID="tbReason" runat="server" Width="130px" CssClass="dfinput"></asp:TextBox>
                            <asp:LinkButton ID="lbRe" runat="server"   CommandName="Update"><i class="ibtn">保存</i></asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbReason" runat="server" ></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="130px" />
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                             <asp:LinkButton ID="lbView" runat="server" OnDataBinding="lbView_DataBinding">详情</asp:LinkButton>
                            
                             <asp:LinkButton ID="lbYes" runat="server" CommandName="yes">同意</asp:LinkButton>
                             <asp:LinkButton ID="lbNo" runat="server"   CommandName="Edit">拒绝</asp:LinkButton>
                           
                             <asp:LinkButton ID="lbHistory" runat="server" OnDataBinding="lbHistory_DataBinding">审批历史</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
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
        </div>
        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>
</html>