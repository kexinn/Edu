<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="DepartmentManagement.aspx.cs" Inherits="web.admin.user.DepartmentManagement" %>


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
                <li><a href="#">用户管理</a></li>
                <li><a href="#">机构管理</a></li>
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
                <asp:Panel ID="PanelAddRole" runat="server">
                    <table class="tablelist">
                        <tr>

                            <th>组织机构名称</th>
                            <th>
                            &nbsp; 描述</th>
                                            <th>操作</th>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="tbDepartmentName" runat="server" CssClass="dfinput" ValidationGroup="juese"></asp:TextBox>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="tbDepartmentName" ErrorMessage="*" ForeColor="Red"
                                    ValidationGroup="juese" Width="5px"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="tbRemark" CssClass="dfinput" runat="server"></asp:TextBox>

                            </td>
                            <td>
                                <asp:Button ID="btAdd" runat="server" OnClick="btAdd_Click" Text="添加"
                                    CssClass="btn green" ValidationGroup="juese" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <asp:GridView ID="gvDepartment" runat="server" AutoGenerateColumns="False"
                DataKeyNames="ID" OnRowCancelingEdit="gvDepartment_RowCancelingEdit"
                OnRowDeleting="gvDepartment_RowDeleting" OnRowEditing="gvDepartment_RowEditing"
                OnRowUpdating="gvDepartment_RowUpdating" PageSize="20" Width="100%" OnPageIndexChanging="gvDepartment_PageIndexChanging"
                CssClass="tablelist"
                AllowPaging="True">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                            <asp:TextBox ID="lbID" runat="server" Text='<%# Eval("ID") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbID0" runat="server"><%# Eval("ID") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="组织机构名称">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbDepartmentName" runat="server" Text='<%# Eval("Name") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbDepartmentName" runat="server" OnDataBinding="lbDepartmentName_DataBinding"><%# Eval("Name") %></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="描述">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbRemark" runat="server" Text='<%# Eval("Description") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="tbRemark" runat="server"><%# Eval("Description")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="部门领导">
                        <EditItemTemplate>
                            <asp:Label ID="lbLingdao" runat="server" OnDataBinding="lbDepartmentHead_DataBinding"></asp:Label>

                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="tbLingdao" runat="server" OnDataBinding="lbDepartmentHead_DataBinding"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="主管校长">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownListHeadmaster" runat="server" OnDataBinding="ddlHeadmaster_DataBinding">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbHeadmaster" runat="server"><%# Eval("headmaster") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="部门负责人">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbManagerName" runat="server" CssClass="dfinput " Width="120px"></asp:TextBox>
                                        
                           <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="tbManagerName" ServicePath="/webservice/user/UserWebService.asmx"  ServiceMethod="GetUsers" CompletionSetCount="10" MinimumPrefixLength="1"></asp:AutoCompleteExtender>
                                       
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbManager" runat="server"><%# Eval("ManagerName") %></asp:Label>
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
