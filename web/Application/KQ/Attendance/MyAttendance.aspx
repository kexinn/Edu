<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAttendance.aspx.cs" Inherits="web.Application.KQ.Attendance.MyAttendance" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

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
                                <asp:ListItem Value="经贸部">经贸部</asp:ListItem>
                                <asp:ListItem Value="机电部">机电部</asp:ListItem>
                                <asp:ListItem Value="后勤">后勤</asp:ListItem>
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
            <asp:GridView ID="gvAttendance" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Id" Width="100%" 
                CssClass="tablelist">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" ControlStyle-CssClass="hidden">
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                   
                    <asp:BoundField DataField="username" HeaderText="请假人">
                    <HeaderStyle Width="80px" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="applyTime" HeaderText="申请时间">
                    <HeaderStyle Width="130px" />
                    </asp:BoundField>
                    
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
                            <asp:Label ID="lbStatus" runat="server" OnDataBinding="lbStatus_DataBinding"><%# Eval("status")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="ApprovalName" HeaderText="审批人">
                    <HeaderStyle Width="80px" />
                    </asp:BoundField>

                   
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                             <asp:LinkButton ID="lbView" runat="server" OnDataBinding="lbView_DataBinding">详情</asp:LinkButton>

                             <asp:LinkButton ID="lbDel" runat="server" CommandName="Delete">撤销申请</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
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
