<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UseQk.aspx.cs" Inherits="web.Application.Assets.Base.UseQk" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
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
                <li><a href="#">资产管理</a></li>
                <li><a href="#">基础数据</a></li>
                <li><a href="#">使用情况</a></li>
            </ul>
            <div class="tools">
                <ul class="toolbar">
                    <li><span>
                        <img src="/media/images/t01.png" /></span>
                        <asp:LinkButton ID="lbAdd" runat="server"
                            OnClick="lbAdd_Click">添加使用情况</asp:LinkButton>
                    </li>
                </ul>
            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div style="margin-bottom: 10px;">
                <asp:Panel ID="PanelAddUseQk" runat="server">
                    <table class="tablelist">
                        <tr>
                            <th>使用情况ID</th>
                            <th>使用情况名称</th>
                            <th>使用情况备注</th>
                            <th>操作</th>
                        </tr>
                        <tr>

                            <td>
                                <asp:TextBox ID="tbID" CssClass="dfinput" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="tbName" CssClass="dfinput" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="tbRemark" CssClass="dfinput" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" OnClick="btAdd_Click" Text="添加"
                                    CssClass="btn green" ValidationGroup="juese" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <asp:GridView ID="gvUseQk" runat="server" AutoGenerateColumns="False"
                DataKeyNames="UseQk_ID" OnRowCancelingEdit="gvUseQk_RowCancelingEdit"
                OnRowDeleting="gvUseQk_RowDeleting" OnRowEditing="gvUseQk_RowEditing"
                OnRowUpdating="gvUseQk_RowUpdating" PageSize="20" Width="100%" OnPageIndexChanging="gvUseQk_PageIndexChanging"
                CssClass="tablelist"
                AllowPaging="True">
                <Columns>
                    <asp:TemplateField HeaderText="使用情况ID">
                        <EditItemTemplate>
                            <asp:Label ID="lbID" runat="server"><%# Eval("UseQk_ID") %></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbID" runat="server"><%# Eval("UseQk_ID") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="使用情况名称">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbName" runat="server" Text='<%# Eval("UseQk_Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbName" runat="server"><%# Eval("UseQk_Name") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="备注">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbRemark" runat="server" Text='<%# Eval("UseQk_Remark") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="tbRemark" runat="server" Text='<%# Eval("UseQk_Remark") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <EditItemTemplate>
                            <asp:LinkButton ID="lbUpdate" runat="server" CommandName="Update">更新</asp:LinkButton>&nbsp;&nbsp;
                            <asp:LinkButton ID="lbCancel" runat="server" CommandName="Cancel">取消</asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbUpdate" runat="server" CommandName="Edit">修改</asp:LinkButton>&nbsp;&nbsp;
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
