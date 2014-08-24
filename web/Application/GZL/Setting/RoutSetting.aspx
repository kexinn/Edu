<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="RoutSetting.aspx.cs" Inherits="web.Application.GZL.Setting.RoutSetting" %>


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
                <li><a href="#">流程设置</a></li>
                <li><a href="#">流程设计</a></li>
            </ul>
        </div>

        <div class="rightinfo">

            <div class="tools">

                <ul class="toolbar">
                    <li><span>
                        <img src="/media/images/t01.png" /></span>
                        <asp:LinkButton ID="lbAdd" runat="server"
                            OnClick="lbAdd_Click">添加流程 </asp:LinkButton></li>
                </ul>


            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <asp:Panel ID="PanelAddRout" runat="server">
                <table class="tablelist">
                    <tr>

                        <th>名称</th>
                        <th>版本号</th>
                        <th>操作</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="tbRoutName" runat="server" ValidationGroup="juese" CssClass="dfinput" Width="220px"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="inline"
                                ControlToValidate="tbRoutName" ErrorMessage="*" ForeColor="Red"
                                ValidationGroup="juese"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="tbVerson" runat="server" CssClass="dfinput" Width="120px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="inline" ControlToValidate="tbVerson" ErrorMessage="*" ForeColor="Red" ValidationGroup="juese"></asp:RequiredFieldValidator>

                        </td>
                        <td>
                            <asp:Button ID="btAdd" runat="server" OnClick="btAdd_Click" Text="添加"
                                CssClass="btn" ValidationGroup="juese" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:GridView ID="gvRout" runat="server" AutoGenerateColumns="False"
                DataKeyNames="routId" OnRowCancelingEdit="gvRout_RowCancelingEdit"
                OnRowDeleting="gvRout_RowDeleting" OnRowEditing="gvRout_RowEditing"
                OnRowUpdating="gvRout_RowUpdating" PageSize="20" Width="100%" OnPageIndexChanging="gvRout_PageIndexChanging"
                CssClass="tablelist"
                AllowPaging="True" OnRowCommand="gvRout_RowCommand">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                            <asp:Label ID="lbRoutId" runat="server"><%# Eval("routId") %></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbRoutId" runat="server"><%# Eval("routId") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="流程名称">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbRoutName" runat="server" Text='<%# Eval("routName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbRoutName" runat="server" OnDataBinding="lbRoutName_DataBinding"><%# Eval("routName") %></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="版本">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbVersion" runat="server" Text='<%# Eval("version") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbVersion" runat="server" Text='<%# Eval("version")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="状态">
                        <EditItemTemplate>
                            <asp:Label ID="lbState" runat="server" OnDataBinding="lbState_DataBinding" Text='<%# Eval("State") %>'></asp:Label>

                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbState" runat="server" OnDataBinding="lbState_DataBinding" Text='<%# Eval("State") %>'></asp:Label>
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

                            <asp:LinkButton ID="lbRelease" runat="server" OnDataBinding="lbRelease_DataBinding" CommandName="release" CommandArgument='<%# Eval("routId") %>'>发布</asp:LinkButton>
                            &nbsp;&nbsp;
                                                <asp:LinkButton ID="lbStop" runat="server" OnDataBinding="lbStop_DataBinding" CommandName="stop" CommandArgument='<%# Eval("routId") %>'>停止</asp:LinkButton>
                            &nbsp;&nbsp;
                                                <asp:LinkButton ID="lbEdit" runat="server" OnDataBinding="lbEdit_DataBinding" CommandName="Edit">修改</asp:LinkButton>
                            &nbsp;&nbsp;
                                                <asp:LinkButton ID="lbDel" runat="server" OnDataBinding="lbDel_DataBinding" CommandName="Delete">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
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

