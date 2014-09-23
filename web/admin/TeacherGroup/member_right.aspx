<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="member_right.aspx.cs" Inherits="web.admin.TeacherGroup.member_right" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>


</head>

<body>
    <form id="form1" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">系统设置</a></li>
                <li><a href="#">教研组管理</a></li>
                <li><a href="#">教研组成员</a></li>
            </ul>
        </div>

        <div class="rightinfo">

            <div class="tools">

                <ul class="toolbar">
                    <li><span>
                        <img src="/media/images/t01.png" /></span>
                        <asp:LinkButton ID="lbAdd" runat="server"
                            OnClick="lbAdd_Click">添加成员 </asp:LinkButton></li> 
                </ul>

            <div style="float:left"><asp:Label ID="lbTeacherName" runat="server" Font-Bold="False" Font-Size="Large" ForeColor="Blue"></asp:Label></div>
            </div>
            <!-- ****************** -->
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <asp:Panel ID="PanelAddGroup" runat="server">
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
                                <asp:LinkButton ID="lbDel" runat="server" CommandName="Add">添加到教研组</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle Width="80px" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle HorizontalAlign="Center" />
                </asp:GridView>
            </div>
            <asp:GridView ID="gvGroupUsers" runat="server" AutoGenerateColumns="False"
                DataKeyNames="userid"
                PageSize="20" Width="100%" OnPageIndexChanging="gvGroupUsers_PageIndexChanging"
                CssClass="tablelist"
                AllowPaging="True">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lbID0" runat="server"><%# Eval("userid") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="教研组名称">
                        <ItemTemplate>
                            <asp:Label ID="lbRoleName" runat="server"><%# Eval("TeacherGroupName") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="用户名称">
                        <ItemTemplate>
                            <asp:Label ID="lbUsername" runat="server"><%# Eval("username") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
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
