<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DW.aspx.cs" Inherits="web.Application.Assets.Base.DW" %>

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
                <li><a href="#">度量单位</a></li>
            </ul>
            <div class="tools">
                <ul class="toolbar">
                    <li><span>
                        <img src="/media/images/t01.png" /></span>
                        <asp:LinkButton ID="lbAdd" runat="server"
                            OnClick="lbAdd_Click">添加单位</asp:LinkButton>
                    </li>
                </ul>
            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div style="margin-bottom: 10px;">
                <asp:Panel ID="PanelAddDW" runat="server">
                    <table class="tablelist">
                        <tr>
                            <th>度量单位ID</th>
                            <th>度量单位名称</th>
                            <th>度量单位备注</th>
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
            <asp:GridView ID="gvDW" runat="server" AutoGenerateColumns="False"
                DataKeyNames="DW_ID" OnRowCancelingEdit="gvDW_RowCancelingEdit"
                OnRowDeleting="gvDW_RowDeleting" OnRowEditing="gvDW_RowEditing"
                OnRowUpdating="gvDW_RowUpdating" PageSize="20" Width="100%" OnPageIndexChanging="gvDW_PageIndexChanging"
                CssClass="tablelist"
                AllowPaging="True">
                <Columns>
                    <asp:TemplateField HeaderText="度量单位ID">
                        <EditItemTemplate>
                            <asp:Label ID="lbID" runat="server"><%# Eval("DW_ID") %></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbID" runat="server"><%# Eval("DW_ID") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="度量单位名称">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbName" runat="server" Text='<%# Eval("DW_Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbName" runat="server"><%# Eval("DW_Name") %></asp:Label>
                           </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="度量单位备注">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbRemark" runat="server" Text='<%# Eval("DW_Remark") %>'></asp:TextBox>
                       </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="tbRemark" runat="server" Text='<%# Eval("DW_Remark") %>' ></asp:Label>
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
