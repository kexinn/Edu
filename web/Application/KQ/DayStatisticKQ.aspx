<%@ Page Language="C#"  EnableEventValidation="false" AutoEventWireup="true" CodeBehind="DayStatisticKQ.aspx.cs" Inherits="web.Application.KQ.DayStatisticKQ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                <li><a href="#">当天统计</a></li>
            </ul>
        </div>

        <div class="rightinfo">


            <div class="toolsearch">
                <div class="pullleft">
                    选择日期：<asp:TextBox ID="tbStartTime" CssClass="dfinput" Width="120px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="inline" runat="server" ControlToValidate="tbStartTime" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    &nbsp;<asp:DropDownList ID="DropDownListType" runat="server" CssClass="dfinput" Width="120px" Height="34px">
                        <asp:ListItem Value="1">上班打卡</asp:ListItem>
                        <asp:ListItem Value="2">下班打卡</asp:ListItem>
                       
                    </asp:DropDownList>

                    <asp:DropDownList ID="DropDownListPunch" runat="server" CssClass="dfinput" Width="120px" Height="34px">
                        <asp:ListItem Value="1">已打卡</asp:ListItem>
                        <asp:ListItem Value="2">未打卡</asp:ListItem>
                       
                    </asp:DropDownList>

                    
                    <asp:DropDownList ID="DropDownListStatus" runat="server" CssClass="dfinput" Width="120px" Height="34px">
                        <asp:ListItem Value="0">正常</asp:ListItem>
                        <asp:ListItem Value="1">迟到</asp:ListItem>
                        <asp:ListItem Value="2">早退</asp:ListItem>
                       
                    </asp:DropDownList>
                   <%-- <asp:TextBox ID="TextBox1" CssClass="dfinput" runat="server" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm:ss',minDate:'2008-03-08 11:30:00',maxDate:'2100-03-10 20:59:30'})"></asp:TextBox>
               --%> </div>

                <div class="pullleft">
                    <asp:LinkButton ID="lbStatisc" runat="server"
                        OnClick="lbStatisc_Click"> <i class="mbtn"><img src="/media/images/ico06.png" />统计</i></asp:LinkButton>
                </div>
                <div class="pullright">
                    <asp:LinkButton ID="lbOutExcel1" runat="server" Style="margin-right: 10px;" OnClick="lbOutExcel1_Click"><i class="mbtn"><img src="/media/images/f05.png" />导出统计结果</i></asp:LinkButton>

                </div>
                <div class="clear"></div>
            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <asp:Panel ID="PanelDaka" runat="server">
            <div class="formtitle"><span>打卡名单</span></div>
            <asp:GridView ID="gvKQList" runat="server" AutoGenerateColumns="False"
                 Width="100%"
                CssClass="tablelist" style="margin-bottom:10px;" AllowPaging="True" OnPageIndexChanging="gvKQList_PageIndexChanging" PageSize="500">
                <Columns>
                    <asp:BoundField DataField="序号" HeaderText="序号">
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="工号">
                        <ItemTemplate>
                            <asp:Label ID="lbJobnumber" runat="server"><%# Eval("工号") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="姓名">
                        <ItemTemplate>
                            <asp:Label ID="lbUsername" runat="server"><%# Eval("姓名")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    
                    <asp:BoundField DataField="电话" HeaderText="电话">
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="打卡时间">
                        <ItemTemplate>
                            <asp:Label ID="lbTime" runat="server"><%# Eval("打卡时间")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                            <asp:Label ID="lbStatus" runat="server" OnDataBinding="lbStatus_DataBinding"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="打卡类型">
                        <ItemTemplate>
                            <asp:Label ID="lbCardType" runat="server" OnDataBinding="lbCardType_DataBinding"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>

                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
                
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            </asp:Panel>

            
            <asp:Panel ID="PanelWeiDaka" runat="server">
            <div class="formtitle"><span>未打卡名单</span></div>

            <asp:GridView ID="gvRecordNull" runat="server" AutoGenerateColumns="False"
                Width="100%"
                CssClass="tablelist" AllowPaging="True" OnPageIndexChanging="gvRecordNull_PageIndexChanging" PageSize="500">

                <Columns>
                    
                    <asp:BoundField DataField="序号" HeaderText="排序号">
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="工号">
                        <ItemTemplate>
                            <asp:Label ID="lbJobnumber" runat="server"><%# Eval("工号") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="姓名">
                        <ItemTemplate>
                            <asp:Label ID="lbUsername" runat="server"><%# Eval("姓名")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="电话长号">
                        <ItemTemplate>
                            <asp:Label ID="lbtel1" runat="server"><%# Eval("电话长号")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="电话短号">
                        <ItemTemplate>
                            <asp:Label ID="lbtel2" runat="server"><%# Eval("电话短号")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="打卡次数">
                        <ItemTemplate>
                            <asp:Label ID="lbTime" runat="server">0</asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
                    </asp:TemplateField>


                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
                
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
            </asp:Panel>

        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>
</html>
