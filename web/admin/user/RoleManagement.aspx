<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="RoleManagement.aspx.cs" Inherits="web.admin.user.RoleManagement" %>

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
                <li><a href="#">系统管理</a></li>
                <li><a href="#">用户管理</a></li>
                <li><a href="#">角色管理</a></li>
            </ul>
        </div>

        <div class="rightinfo">

            <div class="tools">

                <ul class="toolbar">
                    <li><span>
                        <img src="/media/images/t01.png" /></span>
                        <asp:LinkButton ID="lbAdd" runat="server"
                            OnClick="lbAdd_Click">添加账号 </asp:LinkButton></li>
                </ul>


            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <asp:Panel ID="PanelAddRole" runat="server">
                <table class="tablelist">
                    <tr>
                        <th>&nbsp; KEY</th>
                        <th>角色名称</th>
                        <th>&nbsp; 备注</th>
                        <th>操作</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="tbRoleKey" runat="server" ValidationGroup="juese" CssClass="dfinput" Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ControlToValidate="tbRoleKey" ErrorMessage="*" ForeColor="Red"
                                ValidationGroup="juese" Width="5px"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="tbRoleName" runat="server" ValidationGroup="juese" CssClass="dfinput" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ControlToValidate="tbRoleName" ErrorMessage="*" ForeColor="Red"
                                ValidationGroup="juese" Width="5px"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="tbRoleRemark" CssClass="dfinput" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btAdd" runat="server" OnClick="btAdd_Click" Text="添加"
                                CssClass="btn green" ValidationGroup="juese" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Key" OnRowCancelingEdit="gvRoles_RowCancelingEdit"
                OnRowDeleting="gvRoles_RowDeleting" OnRowEditing="gvRoles_RowEditing"
                OnRowUpdating="gvRoles_RowUpdating" PageSize="20" Width="100%" OnPageIndexChanging="gvRoles_PageIndexChanging"
                CssClass="tablelist"
                AllowPaging="True">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbKey" runat="server" Text='<%# Eval("Key") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbKey" runat="server"><%# Eval("Key") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="角色名称">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbRoleName" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbRoleName" runat="server" OnDataBinding="lbRoleName_DataBinding"><%# Eval("Name") %></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbRemark" runat="server" Text='<%# Eval("Remark") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="tbRemark" runat="server"><%# Eval("Remark")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
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
                                                <asp:LinkButton ID="lbDel" runat="server" CommandName="Delete">删除</asp:LinkButton>
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

