﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAttendance.aspx.cs" Inherits="web.Application.KQ.Attendance.MyAttendance" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

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
            return confirm("确定撤销？");
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

                <b>请假规则：</b>半天以内【<font color="red">教研组长</font>】（大组长）审批，半天以上一天以内教研组长审批后还需【<font color="red">部主任</font>】审批，一天以上三天以内还需【<font color="red">主管校长</font>】审批，三天以上还需【<font color="red">大校长</font>】审批。<br />
                <b>计算方法：</b>超过5个小时算一天，3到5个小时算半天，不到3个小时的进行累计。工作时间：上午7:40~11:30,下午1:00~16:30</div>
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
                                <asp:ListItem>经贸部</asp:ListItem>
                                <asp:ListItem>机电部</asp:ListItem>
                                <asp:ListItem>后勤</asp:ListItem>
                                <asp:ListItem>社会服务中心</asp:ListItem>
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
                            <asp:DropDownList ID="ddlType" runat="server" CssClass="dfinput" ValidationGroup="apply" Width="100" AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
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
                <asp:Panel ID="PanelFile" runat="server">
                    上传通知文件：<asp:FileUpload ID="FileUpload1" runat="server" CssClass="dfinput" />
                    <span lang="EN-US">（文件小于2M，格式为doc、docx、rar、jpg）<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FileUpload1" ErrorMessage="*必选项" ForeColor="Red" ValidationGroup="apply"></asp:RequiredFieldValidator>
                    </span>
                </asp:Panel>
                <br />
                <asp:Button ID="btApply" runat="server" Text="提交" CssClass="btn" ValidationGroup="apply"  OnClientClick="javascript:showConfirm('确定提交?')"  OnClick="btApply_Click" />
            </div>

        </asp:Panel>
            <asp:GridView ID="gvAttendance" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Id" Width="100%" 
                CssClass="tablelist" OnRowDeleting="gvAttendance_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" ControlStyle-CssClass="hidden">
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                   
                    <asp:BoundField DataField="applyTime" HeaderText="申请时间">
                    <HeaderStyle Width="150px" />
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
                             <asp:LinkButton ID="lbView" runat="server" OnDataBinding="lbView_DataBinding">详情</asp:LinkButton> &nbsp;
                             <asp:LinkButton ID="lbPrint" runat="server" OnDataBinding="lbView_DataBinding">打印</asp:LinkButton>

                             <asp:LinkButton ID="lbDel" runat="server" OnDataBinding="lbDel_DataBinding" OnClientClick="javascript:return check();" CommandName="Delete">撤销申请</asp:LinkButton>
                       
                            &nbsp;
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

            
                               

        </div>
        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>
</html>
