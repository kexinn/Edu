<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LookByMonth.aspx.cs" Inherits="web.Application.WorkPlan.LookByMonth" %>

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
                <li><a href="#">学期工作行事历</a></li>
                <li><a href="#">按月查看</a></li>
            </ul>
        </div>

        <div class="rightinfo">

            <div class="tools">

                <ul class="toolbar">
                    <li>

                        选择年：<asp:DropDownList ID="ddlYear" CssClass="dfinput" Width="60px" runat="server">
                        </asp:DropDownList>

                    </li>
                    
                    <li>

                       选择月： <asp:DropDownList ID="ddlMonth" CssClass="dfinput" Width="60px"  runat="server" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>

                    </li>
                </ul>
                 </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            
            <asp:GridView ID="gvWeekPlan" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Id" PageSize="200" Width="100%" OnPageIndexChanging="gvWeekPlan_PageIndexChanging"
                CssClass="tablelist"
                AllowPaging="True">
                <Columns>
                    <asp:TemplateField HeaderText="年月">
                        <ItemTemplate>
                            <asp:Label ID="lbCreateTime" CssClass="inline" runat="server"><%# Eval("year") %>年<%# Eval("month") %>月</asp:Label></ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="计划周期">
                        <ItemTemplate>
                            <asp:Label ID="lbWeekPeriod" runat="server"><%# Eval("planPeriod") %></asp:Label></ItemTemplate>
                        <ItemStyle Width="160px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="工作计划" ItemStyle-CssClass="textleft">
                        <ItemTemplate>
                            <asp:Label ID="lbContent" runat="server"><%# Eval("content")%></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="执行部门">
                        <ItemTemplate>
                            <asp:Label ID="lbDeptName" runat="server"><%# Eval("deptName")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="是否完成">
                        <ItemTemplate>
                            <asp:Image ID="imgState"  OnDataBinding="imgState_DataBinding" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="未完成说明">
                        <ItemTemplate>
                            <asp:Label ID="lbEvalutionContent" runat="server"><%# Eval("evalutionContent")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
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

