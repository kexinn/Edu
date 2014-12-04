<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserManagement.aspx.cs" Inherits="web.admin.user.UserManagement" %>


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
                <li><a href="#">账号管理</a></li>
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
                <div style="float: left;">
                    NetID：
            
                <asp:TextBox ID="tbUserId" runat="server" CssClass="dfinput"></asp:TextBox>

                </div>
                <ul class="toolbar">
                    <li><span>
                        <img src="/media/images/ico06.png" /></span>
                        <asp:LinkButton ID="lbSearch" runat="server"
                            OnClick="lbSearch_Click" Text="搜索"></asp:LinkButton></li>
                </ul>
                <ul class="toolbar1">
                    <li><span>
                        <img src="/media/images/t05.png" /></span><asp:LinkButton ID="lbDaoru" runat="server" OnClick="lbDaoru_Click">导入用户</asp:LinkButton></li>
                </ul>

            </div>
            <!-- ****************** -->
            <asp:Panel ID="PanelDaoru" runat="server">
                <div>

                    <div>

                        <h4>导入用户</h4>

                    </div>

                    <div>
                        选择模板文件：
                    <input id="FileExcel" class="dfinput" runat="server" name="FileUser" size="42"
                        style="width: 300px" type="file" />
                        <asp:Button ID="BtnImport" runat="server"
                            OnClick="BtnImport_Click" CssClass="btn" Text="导 入"
                            OnClientClick="javascript:return check();" />

                    </div>

                </div>
            </asp:Panel>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <asp:Panel ID="PanelAddUser" runat="server">

                <div class="formtitle"><span>基本信息</span></div>
                <table class="tablelist">
                    <tr>
                        <th>&nbsp; NetID</th>
                        <th>用户名</th>
                        <th class="style1">&nbsp; 密码</th>
                        <th>&nbsp; 角色</th>
                        <th>操作</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="tbNetId" CssClass="dfinput" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="tbUsername" CssClass="dfinput" runat="server" Width="200px"></asp:TextBox>
                        </td>
                        <td>&nbsp;
                                                <asp:Label ID="lbPasswd" runat="server" ForeColor="Red"
                                                    Text="密码默认&quot;000000&quot;"></asp:Label>
                        </td>
                        <td>&nbsp; 
                                                <asp:Label ID="lbMoRen" runat="server" ForeColor="Red" Text="默认为普通用户"></asp:Label>

                        </td>
                        <td>
                            <asp:Button ID="btAdd" runat="server" OnClick="btAdd_Click" Text="添加"
                                CssClass="btn" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Key" OnRowCancelingEdit="gvUsers_RowCancelingEdit"
                OnRowDeleting="gvUsers_RowDeleting" OnRowEditing="gvUsers_RowEditing"
                OnRowUpdating="gvUsers_RowUpdating" PageSize="20" Width="100%" OnPageIndexChanging="gvUsers_PageIndexChanging"
                CssClass="tablelist">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                            <asp:Label ID="lbID" runat="server"><%# Eval("Key") %></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbID0" runat="server"><%# Eval("Key") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NetID">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbNetid" runat="server" Text='<%# Eval("XMPY") %>' Width="120px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbNetid" runat="server"><%# Eval("XMPY")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="排序号">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbOrderNo" runat="server" Text='<%# Eval("orderNo") %>' Width="120px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbOrderNo" runat="server"><%# Eval("orderNo")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="用户名">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbUserName" runat="server" Text='<%# Eval("TrueName") %>' Width="100px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbUserInfo" OnDataBinding="lbUserInfo_DataBinding" runat="server"><%# Eval("TrueName") %></asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="密码">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbPasswd" runat="server" TextMode="Password" Width="80px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            ****
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="工号">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbJobNumber" runat="server" Text='<%# Eval("JobNumber") %>' Width="80px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbJobNumber" runat="server"><%# Eval("JobNumber")%></asp:Label>

                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="部门">
                        <EditItemTemplate>
                            <asp:DropDownList ID="DropDownListDepartment" runat="server" OnDataBinding="ddlDepartment_DataBinding" Width="100">
                            </asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbDepartment" runat="server" OnDataBinding="lbDepartment_DataBinding"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="角色">
                        <EditItemTemplate>

                            <asp:Label ID="lbJueSe" runat="server" OnDataBinding="juese_DataBinding"></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbJueSe" runat="server" OnDataBinding="juese_DataBinding"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <EditItemTemplate>
                            <asp:LinkButton ID="lbUpdate" runat="server" CommandName="Update">更新</asp:LinkButton>
                            &nbsp;&nbsp;
                                                <asp:LinkButton ID="lbCancel" runat="server" CommandName="Cancel">取消</asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:LinkButton ID="lbUpdate0" runat="server" CommandName="Edit">修改</asp:LinkButton>
                            &nbsp;&nbsp;
                                                <asp:LinkButton ID="lbDel" runat="server" CommandName="Delete">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>

            <div class="pagin">
                <div class="pullleft">
                    共  
                                            <asp:Label ID="lbTotPage" runat="server" CssClass="inline" ForeColor="Red"></asp:Label>
                    页 
                                            当前 
                                            <asp:Label ID="lbIndexPage" CssClass="inline" runat="server"></asp:Label>
                    /<asp:Label ID="lbTotPage1" CssClass="inline" runat="server"></asp:Label>
                    &nbsp;页
                </div>



                <div class="pullright">
                    <ul class="toolbar">


                        <li><span></span>
                            <asp:LinkButton ID="lbFirstPage" runat="server" OnClick="lbFirstPage_Click">第一页</asp:LinkButton></li>
                        <li><span></span>
                            <asp:LinkButton ID="lbPrePage" runat="server" OnClick="lbPrePage_Click">上一页</asp:LinkButton></li>

                        <li><span></span>
                            <asp:LinkButton ID="lbNexPage" runat="server" OnClick="lbNexPage_Click">下一页</asp:LinkButton></li>

                        <li><span></span>
                            <asp:LinkButton ID="lbLastPage" runat="server" OnClick="lbLastPage_Click">最后一页</asp:LinkButton></li>
                        <li><span></span>第：
                            <asp:TextBox ID="tbGoNo" runat="server" Width="30px" CssClass="dfinput"></asp:TextBox>
                            <asp:LinkButton ID="lbGo" runat="server"
                                Style="margin-top: 2px; margin-right: 5px" OnClick="lbGo_Click">go</asp:LinkButton></li>

                    </ul>
                </div>
            </div>
            <!-- ****************** -->


        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>

</html>


