<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApprovalHistory.aspx.cs" Inherits="web.Application.KQ.Attendance.ApprovalHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>职教中心日常管理系统</title>

    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/formstyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="rightinfo">

                <div class="formtitle"><span>审批历史</span></div>
                <div class="toolsearch"></div>
            <asp:GridView ID="gvHistory" runat="server" AutoGenerateColumns="False"
                DataKeyNames="attendanceId" PageSize="20" Width="100%"
                CssClass="tablelist"
                AllowPaging="True">
                <Columns>
                    <asp:TemplateField HeaderText="步骤序号">
                        <ItemTemplate>
                            <asp:Label ID="lbActorId" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作人">
                        <ItemTemplate>
                            <asp:Label ID="lbApplyUser" runat="server" Text='<%# Eval("TrueName")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作时间">
                        <ItemTemplate>
                            <asp:Label ID="lbApplyDate" runat="server" Text='<%# Eval("time")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="50px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="意见">
                        <ItemTemplate>
                            <asp:Label ID="lbActorName" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="操作内容">
                        <ItemTemplate>
                            <asp:Label ID="lbState" runat="server" Text='<%# Eval("action")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>

                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>

        </div>
    </form>
</body>
</html>
