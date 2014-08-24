<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="PurchaseApply.aspx.cs" Inherits="web.Application.GZL.CG.PurchaseApply" %>



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
                <li><a href="#">工作申请</a></li>
                <li><a href="#">采购管理</a></li>
                <li><a href="#">采购申请</a></li>
            </ul>
        </div>

        <div class="rightinfo">

            <div class="tools">

                <ul class="toolbar">
                    <li><span>
                        <img src="/media/images/t01.png" /></span>
                        <asp:LinkButton ID="lbAdd" runat="server"
                            OnClick="lbAdd_Click">添加申请项目 </asp:LinkButton></li>
                </ul>


            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <div style="margin-bottom: 10px;">
                <asp:Panel ID="PanelAddItem" runat="server">
                    <table class="tablelist">
                        <tr>
                            <td>&nbsp; 采购单名称</td>
                            <td>&nbsp; 所属部门</td>
                            <td>操作</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="tbItemName" CssClass="dfinput" Width="200px" runat="server" ValidationGroup="caigou"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="inline" runat="server" ControlToValidate="tbItemName" ErrorMessage="*" ForeColor="Red" ValidationGroup="caigou"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDept"  Width="120px" runat="server" ValidationGroup="caigou" Height="30px"></asp:DropDownList>
                                
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="inline" runat="server" ControlToValidate="ddlDept" ErrorMessage="*" ForeColor="Red" ValidationGroup="caigou"></asp:RequiredFieldValidator>
                                
                            </td>

                            <td>
                                <asp:Button ID="btAdd" runat="server" OnClick="btAdd_Click" Text="添加"
                                    CssClass="btn" ValidationGroup="caigou" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <asp:GridView ID="gvApply" runat="server" AutoGenerateColumns="False"
                DataKeyNames="ItemId" PageSize="20" Width="100%" OnPageIndexChanging="gvApply_PageIndexChanging"
                CssClass="tablelist"
                AllowPaging="True">
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

                            <asp:LinkButton ID="lbDetail" runat="server" OnDataBinding="lbDetail_DataBinding">添加采购明细</asp:LinkButton>
                            &nbsp;
                                                <asp:LinkButton ID="lbLookDetail" runat="server" OnDataBinding="lbLookDetail_DataBinding">查看采购明细</asp:LinkButton>
                            &nbsp;
                                                <asp:LinkButton ID="lbHistory" runat="server" OnDataBinding="lbHistory_DataBinding">查看历史</asp:LinkButton>

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

