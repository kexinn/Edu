<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SysManage.aspx.cs" Inherits="web.admin.Sys.SysManage" %>


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
                <li><a href="#">子系统管理</a></li>
                <li><a href="#">子系统管理</a></li>
            </ul>
        </div>

        <div class="rightinfo">

            <div class="tools">

                <ul class="toolbar">
                    <li><span>
                        <img src="/media/images/t01.png" /></span>
                        <asp:LinkButton ID="lbAdd" runat="server"
                            OnClick="lbAdd_Click">添加系统 </asp:LinkButton></li>
                </ul>
                <ul class="toolbar">
                </ul>
                <ul class="toolbar1">
                </ul>

            </div>
            <!-- ****************** -->
            <asp:Panel ID="PanelAddSys" runat="server">

                <div class="formtitle"><span>基本信息</span></div>
                <table class="tablelist">
                    <tr>
                        <th>&nbsp; 名称</th>
                        <th>备注</th>
                        <th>操作</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="tbName" CssClass="dfinput" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbName" ErrorMessage="*必选" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="tbRemark" CssClass="dfinput" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btAdd" runat="server" OnClick="btAdd_Click" Text="添加"
                                CssClass="btn" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:GridView ID="gvSys" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Id" Width="100%"
                CssClass="tablelist" OnRowCancelingEdit="gvSys_RowCancelingEdit" OnRowDeleting="gvSys_RowDeleting" OnRowEditing="gvSys_RowEditing" OnRowUpdating="gvSys_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                            <asp:Label ID="lbID" runat="server"><%# Eval("Id") %></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbID0" runat="server"><%# Eval("Id") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="名称">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbName" runat="server" Text='<%# Eval("name") %>' Width="120px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbName" runat="server"><%# Eval("name")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="备注">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbRemark" runat="server" Text='<%# Eval("remark") %>' Width="120px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbRemark" runat="server"><%# Eval("remark")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="90px" />
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

            <!-- ****************** -->


        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>

</html>


