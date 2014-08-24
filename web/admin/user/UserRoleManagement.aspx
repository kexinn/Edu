<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="UserRoleManagement.aspx.cs" Inherits="web.admin.user.UserRoleManagement" %>


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
                <li><a href="#">系统设置</a></li>
                <li><a href="#">用户管理</a></li>
                <li><a href="RoleManagement.aspx">角色管理</a></li>
                <li><a href="#">角色用户管理</a></li>
            </ul>
        </div>

        <div class="rightinfo">

            <div class="tools">

                <ul class="toolbar">
                    <li><span>
                        <img src="/media/images/t01.png" /></span>
                        <asp:LinkButton ID="lbAdd" runat="server"
                            OnClick="lbAdd_Click">添加角色用户 </asp:LinkButton></li>
                </ul>

            </div>
            <!-- ****************** -->
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <asp:Panel ID="PanelAddRole" runat="server">
                <table class="tablelist">

                    <tr>
                        <td>输入用户名：<asp:TextBox ID="tbTrueName" CssClass="dfinput" runat="server" ValidationGroup="juese"></asp:TextBox>

                            &nbsp;
                                                <asp:Button ID="btLookfor" runat="server" OnClick="btLookfor_Click" Text="查找"
                                                    CssClass="btn" ValidationGroup="juese" />
                        </td>

                    </tr>
                </table>
            </asp:Panel>
            <div style="margin-bottom: 10px;">
                <asp:GridView ID="gvSearchUser" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="Key"
                    PageSize="20" Width="100%"
                    CssClass="tablelist"
                    AllowPaging="True" OnRowCommand="gvSearchUser_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                                <asp:Label ID="lbID" runat="server"><%# Eval("Key") %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="NetID">
                            <ItemTemplate>
                                <asp:Label ID="lbRoleName" runat="server"><%# Eval("XMPY") %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="用户名称">
                            <ItemTemplate>
                                <asp:Label ID="lbUsername" runat="server"><%# Eval("TrueName") %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbDel" runat="server" CommandName="Add">添加到角色</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle HorizontalAlign="Center" />
                </asp:GridView>
            </div>
            <asp:GridView ID="gvRoleUsers" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Key"
                OnRowDeleting="gvRoleUsers_RowDeleting"
                PageSize="20" Width="100%" OnPageIndexChanging="gvRoles_PageIndexChanging"
                CssClass="tablelist"
                AllowPaging="True">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lbID0" runat="server"><%# Eval("Key") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="角色名称">
                        <ItemTemplate>
                            <asp:Label ID="lbRoleName" runat="server"><%# Eval("rolename") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="用户名称">
                        <ItemTemplate>
                            <asp:Label ID="lbUsername" runat="server"><%# Eval("username") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <asp:LinkButton ID="lbDel" runat="server" CommandName="Delete">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>

            <!-- ****************** -->


        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>

</html>

