<%@ Page Language="C#"   EnableEventValidation="false"  AutoEventWireup="true" CodeBehind="MyKqQuery.aspx.cs" Inherits="web.Application.KQ.MyKqQuery" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>无标题文档</title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/calendar/WdatePicker.js"></script>
    
    <style type="text/css">

        span{display:inline;}
    </style>   
     <script type="text/javascript">
                    function check() {
                        return confirm("确定撤销？");
                    }
    </script>
</head>
<body>
    <form id="form1" runat="server">
<div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">请假管理</a></li>
                <li><a href="#">我的考勤</a></li>
            </ul>
        </div>

        <div class="rightinfo">


            <div class="toolsearch">
                <div class="pullleft">
                    起始日期：<asp:TextBox ID="tbDate" CssClass="dfinput" Width="120px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbDate" ErrorMessage="*必选" ForeColor="Red"></asp:RequiredFieldValidator>
                    结束日期：<asp:TextBox ID="tbEndDate" CssClass="dfinput" Width="120px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbEndDate" ErrorMessage="*必选" ForeColor="Red"></asp:RequiredFieldValidator>
                    &nbsp;<%-- <asp:TextBox ID="TextBox1" CssClass="dfinput" runat="server" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm:ss',minDate:'2008-03-08 11:30:00',maxDate:'2100-03-10 20:59:30'})"></asp:TextBox>
               --%></div>

                <div class="pullleft">
                    <asp:LinkButton ID="lbSearch" runat="server" OnClick="lbSearch_Click" > <i class="mbtn"><img src="/media/images/ico06.png" />查询</i></asp:LinkButton>
                </div>
                <div class="pullright">

                </div>
                <div class="clear"></div>
            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <div class="formtitle"><span>考勤记录</span></div>
            <asp:GridView ID="gvKQ" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Id" Width="100%" 
                CssClass="tablelist" >
                <Columns>
                   
                    
                    <asp:TemplateField HeaderText="姓名">
                        <ItemTemplate>
                            <asp:Label ID="lbName" runat="server" ><%# Session["username"] %></asp:Label>
                        </ItemTemplate>
                    <HeaderStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="考勤日期">
                        <ItemTemplate>
                            <asp:Label ID="lbDate" runat="server" OnDataBinding="lbDate_DataBinding"></asp:Label>
                        </ItemTemplate>
                    <HeaderStyle Width="80px" />
                    </asp:TemplateField>

                    
                    <asp:TemplateField HeaderText="星期">
                        <ItemTemplate>
                            <asp:Label ID="lbWeek" runat="server" OnDataBinding="lbWeek_DataBinding"></asp:Label>
                        </ItemTemplate>
                    <HeaderStyle Width="80px" />
                    </asp:TemplateField>
                    
                     <asp:BoundField DataField="shangbanTime" HeaderText="上班时间">
                    <HeaderStyle Width="130px" />
                    </asp:BoundField>
                     <asp:BoundField DataField="xiabanTime" HeaderText="下班时间">
                    <HeaderStyle Width="130px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="迟到">
                        <ItemTemplate>
                            <asp:Label ID="lbLate" runat="server" OnDataBinding="lbLate_DataBinding"></asp:Label>
                        </ItemTemplate>
                    <HeaderStyle Width="60px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="早退">
                        <ItemTemplate>
                            <asp:Label ID="lbEarly" runat="server" OnDataBinding="lbEarly_DataBinding"></asp:Label>
                        </ItemTemplate>
                    <HeaderStyle Width="60px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="旷工">
                        <ItemTemplate>
                            <asp:Label ID="lbKuanggong" runat="server" OnDataBinding="lbKuanggong_DataBinding"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="60px" />
                    </asp:TemplateField>
                   

                    <asp:TemplateField HeaderText="请假">
                        <ItemTemplate>
                            <asp:Label ID="lbQingjia" runat="server" OnDataBinding="lbQingjia_DataBinding"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="60px" />
                    </asp:TemplateField>

                    <asp:BoundField DataField="qingjiaTime" HeaderText="请假时长">
                    <HeaderStyle Width="120px" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="remark" HeaderText="备注">
                    <HeaderStyle />
                    </asp:BoundField>
                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>

             <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
                      OnPageChanged="AspNetPager1_PageChanged"  
                      ShowCustomInfoSection="left" 
                      ShowInputBox="Auto" 
                      AlwaysShow="false"
                      CustomInfoHTML="<font color='#333333'>共 %RecordCount% 行/每页%PageSize%行 第%CurrentPageIndex%/%PageCount%页</font>" 
                      NumericButtonCount="10" 
                      FirstPageText="首页" 
                      LastPageText="末页" 
                      NextPageText="下页" 
                      PrevPageText="上页" 
                      CustomInfoSectionWidth="250px" 
                      CssClass="page_text" 
                      ShowBoxThreshold="11" 
                      InputBoxClass="pagetext" 
                      SubmitButtonClass="pagebtn" 
                      SubmitButtonText="Go" BackColor="White" BorderColor="Gray" CustomInfoClass="" Height="25px" Wrap="False"></webdiyer:AspNetPager>

            
                
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>

            
        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>
</html>