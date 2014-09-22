<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherGroupManagement.aspx.cs" Inherits="web.admin.TeacherGroup.TeacherGroupManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
                <li><a href="#">教研组管理</a></li>
            </ul>
        </div>
        
         <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ToolkitScriptManager>
        <div class="rightinfo">

            <div class="tools">

                <ul class="toolbar">
                    <li><span>
                        <img src="/media/images/t01.png" /></span>
                        <asp:LinkButton ID="lbAdd" runat="server"
                            OnClick="lbAdd_Click">添加机构 </asp:LinkButton></li>
                </ul>


            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <div style="margin-bottom: 10px;">
                <asp:Panel ID="PanelAddGroup" runat="server">
                    <table class="tablelist">
                        <tr>

                            <th>教研组名称</th>
                            <th>
                                &nbsp; </th>
                                            <th>操作</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="tbGroupName" runat="server" CssClass="dfinput" ValidationGroup="juese"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="tbGroupName" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="juese" Width="5px"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="btAdd" runat="server" OnClick="btAdd_Click" Text="添加"
                                    CssClass="btn green" ValidationGroup="juese" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <asp:GridView ID="gvTeacherGroup" runat="server" AutoGenerateColumns="False"
                DataKeyNames="ID" OnRowCancelingEdit="gvTeacherGroup_RowCancelingEdit"
                OnRowDeleting="gvTeacherGroup_RowDeleting" OnRowEditing="gvTeacherGroup_RowEditing"
                OnRowUpdating="gvTeacherGroup_RowUpdating" PageSize="20" Width="100%" OnPageIndexChanging="gvTeacherGroup_PageIndexChanging"
                CssClass="tablelist"
                AllowPaging="True">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                            <asp:TextBox ID="lbID" runat="server" Text='<%# Eval("Id") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbID" runat="server"><%# Eval("Id") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="教研组名称">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbTeacherGroupName" runat="server" Text='<%# Eval("TeacherGroupName") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbTeacherGroupName" runat="server"><%# Eval("TeacherGroupName") %></asp:Label>
                         </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="教研组组长">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbLeaderName" runat="server" Text='<%# Eval("LeaderName") %>'></asp:TextBox>
                              <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="tbLeaderName" ServicePath="/webservice/user/UserWebService.asmx"  ServiceMethod="GetUsers" CompletionSetCount="10" MinimumPrefixLength="1"></asp:AutoCompleteExtender>
                      
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbLeaderName" runat="server"><%# Eval("LeaderName") %></asp:Label>
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
                            <asp:LinkButton ID="lbUpdate" runat="server" CommandName="Edit">修改</asp:LinkButton>
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
