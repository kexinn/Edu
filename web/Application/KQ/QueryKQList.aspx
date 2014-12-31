<%@ Page Title="" Language="C#"  AutoEventWireup="true" CodeBehind="QueryKQList.aspx.cs" Inherits="web.Application.KQ.QueryKQList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/calendar/WdatePicker.js"></script>
    <script type="text/javascript" src="/media/js/myjs.js"></script>

</head>


<body>
    <form id="form1" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">考勤管理</a></li>
                <li><a href="#">打卡查询</a></li>
            </ul>
        </div>

        <div class="rightinfo">


            <div class="toolsearch">
                <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ToolkitScriptManager>
                <div class="pullleft">

                                        姓名：<asp:TextBox ID="tbUsername" runat="server" CssClass="dfinput " Width="120px"></asp:TextBox>
                                        
                                        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="tbUsername" ServicePath="/webservice/user/UserWebService.asmx"  ServiceMethod="GetUsers" CompletionSetCount="10" MinimumPrefixLength="1"></asp:AutoCompleteExtender>
                                        开始时间：<asp:TextBox ID="tbStartTime" runat="server" CssClass="dfinput " Width="120px"  onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" CssClass="inline" ControlToValidate="tbStartTime" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        结束时间：<asp:TextBox ID="tbEndTime" runat="server" CssClass="dfinput " Width="120px"  onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" CssClass="inline" ControlToValidate="tbEndTime" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                                        
                 </div>
                                 
                 <div class="pullleft">
                        <asp:LinkButton ID="lbSearch" runat="server"
                            onclick="lbSearch_Click" ><i class="mbtn"><img src="/media/images/ico06.png" />查询</i></asp:LinkButton> 
                     <asp:LinkButton ID="lbBuka" runat="server" OnClick="lbBuka_Click" ><i class="mbtn"><img src="/media/images/ico06.png" />所有补卡</i></asp:LinkButton>
                     </div>
                <div class="clear"></div>
            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <asp:GridView ID="gvKQList" runat="server" AutoGenerateColumns="False" 
                                    DataKeyNames="ID" Width="100%" 
                                    CssClass="tablelist" AllowPaging="True" OnPageIndexChanging="gvKQList_PageIndexChanging" PageSize="20" OnRowDeleting="gvKQList_RowDeleting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lbID0" runat="server"><%# Eval("ID") %></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="打卡人">
                                            <ItemTemplate>
                                                <asp:Label ID="lbUsername" runat="server"><%# Eval("username")%></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="打卡时间">
                                            <ItemTemplate>
                                                <asp:Label ID="lbTime" runat="server"><%# Eval("Time")%></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IP地址">
                                           <ItemTemplate>
                                                <asp:Label ID="lbAddress" runat="server"><%# Eval("IpAddress")%></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="80px" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="打卡类型">
                                           <ItemTemplate>
                                                <asp:Label ID="lbJobNumber" runat="server"><%# (Char)Eval("PunchCardType") =='1'?"上班打卡":"下班打卡"%></asp:Label>
                                                
                                            </ItemTemplate>
                                            <ItemStyle Width="80px" />
                                        </asp:TemplateField>

                                       
                                        <asp:TemplateField HeaderText="考勤状态">
                                           <ItemTemplate>
                                                <asp:Label ID="lbStatus" runat="server" OnDataBinding="lbStatus_DataBinding"></asp:Label>
                                                
                                            </ItemTemplate>
                                            <ItemStyle Width="80px" />
                                        </asp:TemplateField>
                                        
                                       
                                        <asp:TemplateField HeaderText="是否补打">
                                           <ItemTemplate>
                                                <asp:Label ID="lbFill" runat="server" ><%# Eval("fillCard")%></asp:Label>
                                                
                                            </ItemTemplate>
                                            <ItemStyle Width="80px" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="补打人">
                                           <ItemTemplate>
                                                <asp:Label ID="lbFillPeople" runat="server" ><%# Eval("fillcardUser")%></asp:Label>
                                                
                                            </ItemTemplate>
                                            <ItemStyle Width="80px" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="补打时间">
                                           <ItemTemplate>
                                                <asp:Label ID="lbFillTime" runat="server" ><%# Eval("fillCardTime")%></asp:Label>
                                                
                                            </ItemTemplate>
                                            <ItemStyle Width="80px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="操作">
                       
                                            <ItemTemplate>
                            
                                                <asp:LinkButton ID="lbDel" runat="server" OnClientClick="javascript:showConfirm('确定删除?')" CommandName="Delete" ForeColor="Blue">删除</asp:LinkButton>
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
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

