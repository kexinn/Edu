<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PreWeekPlanEvalution.aspx.cs" Inherits="web.Application.WorkPlan.PreWeekPlanEvalution" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
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
                <li><a href="#">上周评价</a></li>
            </ul>
        </div>

        <div class="rightinfo">

            <div class="tools">

               


                <h1>对本部门上一周工作完成情况说明</h1></div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            
            <asp:GridView ID="gvWeekPlan" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Id" OnRowCancelingEdit="gvWeekPlan_RowCancelingEdit"
                OnRowDeleting="gvWeekPlan_RowDeleting" OnRowEditing="gvWeekPlan_RowEditing"
                OnRowUpdating="gvWeekPlan_RowUpdating" PageSize="20" Width="100%" OnPageIndexChanging="gvWeekPlan_PageIndexChanging"
                CssClass="tablelist"
                AllowPaging="True">
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
                    <asp:TemplateField HeaderText="计划内容"  ItemStyle-CssClass="textleft">
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
                          <asp:LinkButton ID="lbDel" runat="server" CommandName="Delete">完成</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>


        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>

</html>
