<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseStatisc.aspx.cs" Inherits="web.Application.GZL.CG.PurchaseStatisc" %>

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
                <li><a href="#">工作申请</a></li>
                <li><a href="#">采购管理</a></li>
                <li><a href="#">查询统计</a></li>
            </ul>
        </div>

        <div class="rightinfo">

           
                        <div class="toolsearch">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ToolkitScriptManager>
                
            <div class="formtitle"><span>查询条件</span></div>
                            <div class="pullleft">


                                        申请部门：<asp:DropDownList ID="ddlDept" runat="server" CssClass="dfinput" Height="30px" Width="120px">
                                        </asp:DropDownList>
                                        项目名称：<asp:TextBox ID="tbItemName" runat="server" CssClass="dfinput " Width="120px"></asp:TextBox>
                                         开始时间：<asp:TextBox ID="tbStartTime" runat="server" CssClass="dfinput " Width="120px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" runat="server" TargetControlID="tbStartTime"></asp:CalendarExtender>
                                        结束时间：<asp:TextBox ID="tbEndTime" runat="server" CssClass="dfinput " Width="120px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender2"  Format="yyyy-MM-dd" runat="server" TargetControlID="tbEndTime"></asp:CalendarExtender>
                                        

                 </div>
                                 
                 <div class="pullleft">
                        <asp:LinkButton ID="lbSearch" runat="server"
                            onclick="lbSearch_Click" ><i class="mbtn"><img src="/media/images/ico06.png" />查询</i></asp:LinkButton>
                     </div>
                  <div class="pullright">
                      <asp:LinkButton ID="lbDaoChu" runat="server" OnClick="lbDaoChu_Click"><i class="mbtn"><img src="/media/images/t05.png" />导出excel</i></asp:LinkButton>
                  </div>
                <div class="clear"></div>
            </div>
            <!-- ****************** -->
            
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <asp:GridView ID="gvApply" runat="server" AutoGenerateColumns="False"
                DataKeyNames="ItemId" PageSize="20" Width="100%"
                CssClass="tablelist">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lbActorId" runat="server"><%# Eval("ItemId") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="项目名称">
                        <ItemTemplate>

                            <asp:Label ID="lbItemName" runat="server"><%# Eval("ItemName") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="申请人">
                        <ItemTemplate>
                            <asp:Label ID="lbApplyUser" runat="server" Text='<%# Eval("applyUserName")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="申请时间">
                        <ItemTemplate>
                            <asp:Label ID="lbApplyDate" runat="server" Text='<%# Eval("ApplyDate")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="当前步骤">
                        <ItemTemplate>
                            <asp:Label ID="lbActorName" runat="server" Text='<%# Eval("actorName")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <asp:Label ID="lbState" runat="server" OnDataBinding="lbState_DataBinding" Text='<%# Eval("State")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="项目类型">
                        <ItemTemplate>
                            <asp:Label ID="lbItemType" runat="server" Text='<%# Eval("ItemType")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            
                                                <asp:LinkButton ID="lbLookDetail" runat="server" OnDataBinding="lbLookDetail_DataBinding">查看采购明细</asp:LinkButton>
                             &nbsp; <asp:LinkButton ID="lbHistory" runat="server" OnDataBinding="lbHistory_DataBinding">查看审批历史</asp:LinkButton>

                        </ItemTemplate>
                        <ItemStyle Width="100px" />
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
            <!-- ****************** -->


        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>

</html>