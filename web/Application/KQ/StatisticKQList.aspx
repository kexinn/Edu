<%@ Page Title="" Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="StatisticKQList.aspx.cs" Inherits="web.Application.KQ.StatisticKQList" %>



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
                <li><a href="#">考勤统计</a></li>
            </ul>
        </div>

        <div class="rightinfo">


            <div class="toolsearch">
                <div class="pullleft">
                    开始时间：<asp:TextBox ID="tbStartTime" CssClass="dfinput" Width="120px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="inline" runat="server" ControlToValidate="tbStartTime" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    结束时间：<asp:TextBox ID="tbEndTime" CssClass="dfinput" Width="120px" runat="server"  onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="inline" runat="server" ControlToValidate="tbEndTime" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                   <%-- <asp:TextBox ID="TextBox1" CssClass="dfinput" runat="server" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm:ss',minDate:'2008-03-08 11:30:00',maxDate:'2100-03-10 20:59:30'})"></asp:TextBox>
               --%> </div>

                <div class="pullleft">
                    <asp:LinkButton ID="lbStatisc" runat="server"
                        OnClick="lbStatisc_Click"> <i class="mbtn"><img src="/media/images/ico06.png" />统计</i></asp:LinkButton>
                </div>
                <div class="pullright">
                    <asp:LinkButton ID="lbOutExcel1" runat="server" Style="margin-right: 10px;" OnClick="lbOutExcel1_Click"><i class="mbtn"><img src="/media/images/f05.png" />导出统计结果</i></asp:LinkButton>
                    <asp:LinkButton ID="lbOutExcel2" runat="server" OnClick="lbOutExcel2_Click"><i class="mbtn"><img src="/media/images/f05.png" />导出未刷卡名单</i></asp:LinkButton>

                </div>
                <div class="clear"></div>
            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            
            <div class="formtitle"><span>考勤统计</span></div>
            <asp:GridView ID="gvKQList" runat="server" AutoGenerateColumns="False"
                DataKeyNames="jobnumber" Width="100%"
                CssClass="tablelist" style="margin-bottom:10px;" AllowPaging="True" OnPageIndexChanging="gvKQList_PageIndexChanging" PageSize="20">
                <Columns>
                    <asp:BoundField DataField="order" HeaderText="排序号">
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="工号">
                        <ItemTemplate>
                            <asp:Label ID="lbJobnumber" runat="server"><%# Eval("jobnumber") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="打卡人">
                        <ItemTemplate>
                            <asp:Label ID="lbUsername" runat="server"><%# Eval("username")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="总打卡次数">
                        <ItemTemplate>
                            <asp:Label ID="lbTime" runat="server"><%# Eval("clockTotle")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="上班打卡次数">
                        <ItemTemplate>
                            <asp:Label ID="lbClockon" runat="server"><%# Eval("clockOnNum")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="下班打卡次数">
                        <ItemTemplate>
                            <asp:Label ID="lbClockoff" runat="server"><%# Eval("clockOffNum")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="迟到次数">
                        <ItemTemplate>
                            <asp:Label ID="lbChidao" runat="server"><%# Eval("lateTimes")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="早退次数">
                        <ItemTemplate>
                            <asp:Label ID="lbZaotui" runat="server"><%# Eval("earlyTimes")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
            
            <div class="formtitle"><span>未刷卡名单</span></div>

            <asp:GridView ID="gvRecordNull" runat="server" AutoGenerateColumns="False"
                DataKeyNames="jobnumber" Width="100%"
                CssClass="tablelist" AllowPaging="True" OnPageIndexChanging="gvRecordNull_PageIndexChanging" PageSize="20">

                <Columns>
                    
                    <asp:BoundField DataField="order" HeaderText="排序号">
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="工号">
                        <ItemTemplate>
                            <asp:Label ID="lbJobnumber" runat="server"><%# Eval("jobnumber") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="打卡人">
                        <ItemTemplate>
                            <asp:Label ID="lbUsername" runat="server"><%# Eval("username")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="总打卡次数">
                        <ItemTemplate>
                            <asp:Label ID="lbTime" runat="server">0</asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="上班打卡次数">
                        <ItemTemplate>
                            <asp:Label ID="lbShangban" runat="server">0</asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="下班打卡次数">
                        <ItemTemplate>
                            <asp:Label ID="lbXiaban" runat="server">0</asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>

                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>

        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>

</html>



