<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyAttendance.aspx.cs" Inherits="web.Application.KQ.Attendance.MyAttendance" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/calendar/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">考勤管理</a></li>
                <li><a href="#">请假管理</a></li>
                <li><a href="#">我的请假</a></li>
            </ul>
        </div>

        <div class="rightinfo">
            <div class="tools">

                <ul class="toolbar">
                    <li><span>
                        <img src="/media/images/t01.png" /></span>
                        <asp:LinkButton ID="lbAdd" runat="server"
                            OnClick="lbAdd_Click">添加申请 </asp:LinkButton></li>
                </ul>

            </div>
            <!-- ****************** -->
            
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <asp:Panel ID="PanelAddUser" runat="server">

                <div class="formtitle"><span>基本信息</span></div>
               <div>


               </div>
            </asp:Panel>
            <asp:GridView ID="gvAttendance" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Id" 
                PageSize="25" Width="100%"
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
                            <asp:Label ID="lbUsername" runat="server"><%# Eval("TrueName")%></asp:Label>
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


            
                               

        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>
</html>
