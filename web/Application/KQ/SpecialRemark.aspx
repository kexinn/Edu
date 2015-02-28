<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SpecialRemark.aspx.cs" Inherits="web.Application.KQ.SpecialRemark" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
                <li><a href="#">异动备注</a></li>
            </ul>
        </div>

        <div class="rightinfo">


            <div class="toolsearch">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ToolkitScriptManager>
                <div class="pullleft">

                                        姓名：<asp:TextBox ID="tbUsername" runat="server" CssClass="dfinput " Width="120px" ValidationGroup="add"></asp:TextBox>
                                        
                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="tbUsername" ServicePath="/webservice/user/UserWebService.asmx"  ServiceMethod="GetUsers" CompletionSetCount="10" MinimumPrefixLength="1"></asp:AutoCompleteExtender>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" CssClass="inline" ControlToValidate="tbUsername" ErrorMessage="*必选" ForeColor="Red" ValidationGroup="add"></asp:RequiredFieldValidator>
                                         开始时间：<asp:TextBox ID="tbStartTime" CssClass="dfinput" Width="120px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="inline" runat="server" ControlToValidate="tbStartTime" ErrorMessage="*必选" ForeColor="Red" ValidationGroup="add"></asp:RequiredFieldValidator>
                                        结束时间：<asp:TextBox ID="tbEndTime" CssClass="dfinput" Width="120px" runat="server"  onclick="WdatePicker({skin:'whyGreen'})" ValidationGroup="gen"></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="inline" runat="server" ControlToValidate="tbEndTime" ErrorMessage="*必选" ForeColor="Red" ValidationGroup="add"></asp:RequiredFieldValidator>
                    
                                        说明：<asp:TextBox ID="tbRemark" runat="server" CssClass="dfinput " Width="320px" ValidationGroup="add"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="inline" ControlToValidate="tbRemark" ErrorMessage="*必选" ForeColor="Red" ValidationGroup="add"></asp:RequiredFieldValidator>
                 </div>
                                 
                 <div class="pullleft">
                        <asp:LinkButton ID="lbAdd" runat="server" OnClick="lbAdd_Click" ValidationGroup="add" ><i class="mbtn"><img src="/media/images/iadd.png" />添加</i></asp:LinkButton>
                     </div>
                <div class="clear"></div>
            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <asp:GridView ID="gvKQList" runat="server" AutoGenerateColumns="False" 
                                    DataKeyNames="Id" Width="100%" 
                                    CssClass="tablelist" AllowPaging="True" OnPageIndexChanging="gvKQList_PageIndexChanging" PageSize="20" OnRowDeleting="gvKQList_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lbID" runat="server"><%# Eval("Id") %></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="80px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="姓名">
                                            <ItemTemplate>
                                                <asp:Label ID="lbUsername" runat="server"><%# Eval("TrueName")%></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="起始时间">
                                            <ItemTemplate>
                                                <asp:Label ID="lbStarttime" runat="server"><%# Eval("starttime")%></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="120px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="结束时间">
                                            <ItemTemplate>
                                                <asp:Label ID="lbEndtime" runat="server"><%# Eval("endtime")%></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="120px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="说明">
                                            <ItemTemplate>
                                                <asp:Label ID="lbRemark" runat="server"><%# Eval("remark")%></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="操作">
                       
                        <ItemTemplate>
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

