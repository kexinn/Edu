<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPlanHistory.aspx.cs" Inherits="web.Application.WorkPlan.WorkPlanHistory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>

    <script type="text/javascript">

        function check() {
            return confirm("确定导入？");
        }
    </script>


</head>


<body>
    <form id="form1" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">工作任务</a></li>
                <li><a href="#">部门工作计划</a></li>
                <li><a href="#">历史查询</a></li>
            </ul>
        </div>

        <div class="rightinfo">
            

            <div class="toolsearch">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ToolkitScriptManager>
                <div class="pullleft">

                                        内容：<asp:TextBox ID="tbContent" runat="server" CssClass="dfinput " Width="120px" ValidationGroup="lishi"></asp:TextBox>
                                        
                                        开始时间：<asp:TextBox ID="tbStartTime" runat="server" CssClass="dfinput " Width="120px" ValidationGroup="lishi"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" runat="server" TargetControlID="tbStartTime"></asp:CalendarExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="inline" ControlToValidate="tbStartTime" ErrorMessage="*" ForeColor="Red" ValidationGroup="lishi"></asp:RequiredFieldValidator>
                                        结束时间：<asp:TextBox ID="tbEndTime" runat="server" CssClass="dfinput " Width="120px" ValidationGroup="lishi"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="inline" ControlToValidate="tbEndTime" ErrorMessage="*" ForeColor="Red" ValidationGroup="lishi"></asp:RequiredFieldValidator>
                                        <asp:CalendarExtender ID="CalendarExtender2"  Format="yyyy-MM-dd" runat="server" TargetControlID="tbEndTime"></asp:CalendarExtender>
                                        

                 </div>
                                 
                 <div class="pullleft">
                        <asp:LinkButton ID="lbSearch" runat="server"
                            onclick="lbSearch_Click" ValidationGroup="lishi" ><i class="mbtn"><img src="/media/images/ico06.png" />查询</i></asp:LinkButton>
                     </div>
                <div class="clear"></div>
            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            
            <asp:GridView ID="gvWeekPlan" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Id" OnRowCancelingEdit="gvWeekPlan_RowCancelingEdit" OnRowEditing="gvWeekPlan_RowEditing"
                OnRowUpdating="gvWeekPlan_RowUpdating" PageSize="20" Width="100%"
                CssClass="tablelist" OnRowCommand="gvWeekPlan_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="排序编号">
                        <EditItemTemplate>
                            <asp:Label ID="lbSortNo" runat="server"><%# Eval("sortNo") %></asp:Label>

                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbSortNo" runat="server"><%# Eval("sortNo") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="60px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="发布人">
                        <EditItemTemplate>
                            <asp:Label ID="lbCreateTime" runat="server"><%# Eval("username") %></asp:Label></ItemTemplate>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbCreateTime" runat="server"><%# Eval("username") %></asp:Label></ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="计划周期">
                        <EditItemTemplate>
                            <asp:Label ID="lbWeekPeriod" runat="server"><%# Eval("planPeriod") %></asp:Label></ItemTemplate>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbWeekPeriod" runat="server"><%# Eval("planPeriod") %></asp:Label></ItemTemplate>
                        <ItemStyle Width="160px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="计划内容" ItemStyle-CssClass="textleft">
                        <EditItemTemplate>
                            <asp:Label ID="lbContent" runat="server"><%# Eval("content")%></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbContent" runat="server"><%# Eval("content")%></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="发布部门">
                        <EditItemTemplate>
                            <asp:Label ID="lbDeptName" runat="server"><%# Eval("deptName")%></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbDeptName" runat="server"><%# Eval("deptName")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="是否完成">
                        <EditItemTemplate>
                            <asp:Label ID="lbComplete" runat="server"><%# Eval("isComplete")%></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Image ID="imgState" OnDataBinding="imgState_DataBinding" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="未完成原因">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbEvaContent" CssClass="dfinput" runat="server" Text='<%# Eval("evalutionContent") %>'></asp:TextBox>
                        </EditItemTemplate>

                        <ItemTemplate>
                            <asp:Label ID="lbEvaContent" runat="server"><%# Eval("evalutionContent")%></asp:Label>
                        </ItemTemplate>
                        
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <EditItemTemplate>
                            <asp:LinkButton ID="lbUpdate" runat="server" CommandName="Update">更新</asp:LinkButton>
                            &nbsp;&nbsp;
                                                <asp:LinkButton ID="lbCancel" runat="server" CommandName="Cancel">取消</asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbEdit" runat="server" CommandName="Edit">修改</asp:LinkButton>
                            &nbsp;&nbsp;
                          <asp:LinkButton ID="lbDel" runat="server" CommandName="complete" CommandArgument='<%# Eval("Id") %>'>完成</asp:LinkButton>
                            &nbsp;&nbsp;
                          <asp:LinkButton ID="lbThisWeek" runat="server" CommandName="week" CommandArgument='<%# Eval("Id") %>'>提到本周</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="150px" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
            
            <div class="pagin">
                <div class="pullleft">
                    共  
                                            <asp:Label ID="lbTotPage" runat="server" CssClass="inline" ForeColor="Red"></asp:Label>
                    页 
                                            当前 
                                            <asp:Label ID="lbIndexPage" CssClass="inline" runat="server"></asp:Label>
                    /<asp:Label ID="lbTotPage1" CssClass="inline" runat="server"></asp:Label>
                    &nbsp;页
                </div>



                <div class="pullright">
                    <ul class="toolbar">


                        <li><span></span>
                            <asp:LinkButton ID="lbFirstPage" runat="server" OnClick="lbFirstPage_Click">第一页</asp:LinkButton></li>
                        <li><span></span>
                            <asp:LinkButton ID="lbPrePage" runat="server" OnClick="lbPrePage_Click">上一页</asp:LinkButton></li>

                        <li><span></span>
                            <asp:LinkButton ID="lbNexPage" runat="server" OnClick="lbNexPage_Click">下一页</asp:LinkButton></li>

                        <li><span></span>
                            <asp:LinkButton ID="lbLastPage" runat="server" OnClick="lbLastPage_Click">最后一页</asp:LinkButton></li>
                        <li><span></span>第：
                            <asp:TextBox ID="tbGoNo" runat="server" Width="30px" CssClass="dfinput"></asp:TextBox>
                            <asp:LinkButton ID="lbGo" runat="server"
                                Style="margin-top: 2px; margin-right: 5px" OnClick="lbGo_Click">go</asp:LinkButton></li>

                    </ul>
                </div>
            </div>

        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>

</html>
