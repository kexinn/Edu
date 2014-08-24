<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="ActorSetting.aspx.cs" Inherits="web.Application.GZL.Setting.ActorSetting" %>


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
                <li><a href="RoutSetting.aspx">流程设计</a></li>
                <li><a href="#">流程步骤管理</a></li>
            </ul>
        </div>

        <div class="rightinfo">

            <div class="tools">

                <ul class="toolbar">
                    <li><span>
                        <img src="/media/images/t01.png" /></span>
                        <asp:LinkButton ID="lbAdd" runat="server"
                            OnClick="lbAdd_Click">添加流程步骤 </asp:LinkButton></li>
                </ul>

            </div>
            <!-- ****************** -->
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <asp:Panel ID="PanelAddActor" runat="server">
                <table class="tablelist">
                    <tr>

                        <th>名称</th>
                        <th>步骤序号</th>
                        <th>操作</th>
                    </tr>
                    <tr>
                        <td>
                                <asp:TextBox ID="tbActorName" runat="server" CssClass="dfinput" Width="220px" ValidationGroup="juese"></asp:TextBox>
                           
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="inline"
                                ControlToValidate="tbActorName" ErrorMessage="*" ForeColor="Red"
                                ValidationGroup="juese"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                                <asp:TextBox ID="tbSortNo" CssClass="dfinput" Width="100px" runat="server" ValidationGroup="juese"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="inline" ControlToValidate="tbSortNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="juese"></asp:RequiredFieldValidator>
                          
                        </td>
                        <td>
                            <asp:Button ID="btAdd" runat="server" OnClick="btAdd_Click" Text="添加"
                                CssClass="btn" ValidationGroup="juese" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <div style="margin-bottom: 10px;">
                <asp:GridView ID="gvActor" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="actorId" OnRowCancelingEdit="gvActor_RowCancelingEdit"
                    OnRowDeleting="gvActor_RowDeleting" OnRowEditing="gvActor_RowEditing"
                    OnRowUpdating="gvActor_RowUpdating" PageSize="20" Width="100%" OnPageIndexChanging="gvActor_PageIndexChanging"
                    CssClass="tablelist"
                    AllowPaging="True">
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <EditItemTemplate>
                                <asp:Label ID="lbActorId" runat="server"><%# Eval("actorId") %></asp:Label>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbActorId" runat="server"><%# Eval("actorId") %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="步骤名称">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbActorName" runat="server" Text='<%# Eval("actorName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>

                                <asp:Label ID="lbActorName" runat="server"><%# Eval("actorName") %></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="120px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="步骤序号">
                            <EditItemTemplate>
                                <asp:TextBox ID="tbSortNo" runat="server" Text='<%# Eval("sortNo") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lbSortNo" runat="server" Text='<%# Eval("sortNo")%>'></asp:Label>
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
                            <ItemStyle Width="120px" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle HorizontalAlign="Center" />
                </asp:GridView>


            </div>


            <!-- ****************** -->


        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>

</html>

