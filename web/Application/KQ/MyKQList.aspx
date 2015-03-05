<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="MyKQList.aspx.cs" Inherits="web.Application.KQ.MyKQList" %>


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
                <li><a href="#">我的打卡</a></li>
            </ul>
        </div>

        <div class="rightinfo">


            <div class="toolsearch">
                <div class="pullleft">
                                        开始时间：<asp:TextBox ID="tbStartTime" runat="server" CssClass="dfinput" Width="200px"  onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                                        结束时间：<asp:TextBox ID="tbEndTime" runat="server" CssClass="dfinput" Width="200px"  onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                                          </div>                      
                 <div class="pullleft">
                        <asp:LinkButton ID="lbSearch" runat="server"
                            onclick="lbSearch_Click" ><i class="mbtn"><img src="/media/images/ico06.png" />查询</i></asp:LinkButton>
                     </div>
            <div class="clear"></div>
            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <asp:GridView ID="gvKQList" runat="server" AutoGenerateColumns="False" 
                                    DataKeyNames="ID" Width="100%" 
                                    CssClass="tablelist" AllowPaging="True" OnPageIndexChanging="gvKQList_PageIndexChanging" PageSize="20">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lbID" runat="server"><%# Eval("ID") %></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="80px" />
                                        </asp:TemplateField>
                                         
                                        <asp:TemplateField HeaderText="打卡时间">
                                            <ItemTemplate>
                                                <asp:Label ID="lbTime" runat="server"><%# Eval("Time")%></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="130px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IP地址">
                                           <ItemTemplate>
                                                <asp:Label ID="lbAddress" runat="server"><%# Eval("IpAddress")%></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" />
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="打卡类型">
                                           <ItemTemplate>
                                                <asp:Label ID="lbJobNumber" runat="server"><%# (Char)Eval("PunchCardType") =='1'?"上班打卡":"下班打卡"%></asp:Label>
                                                
                                            </ItemTemplate>
                                            <ItemStyle Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                           <ItemTemplate>
                                               
                                            </ItemTemplate>
                                            <ItemStyle />
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




