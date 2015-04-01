<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyBXForm.aspx.cs" Inherits="web.Application.BX.MyBXForm" %>

<%@ Register assembly="AspNetPager" namespace="Wuqi.Webdiyer" tagprefix="webdiyer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/calendar/WdatePicker.js"></script>
    <script type="text/javascript" src="/media/js/myjs.js"></script>
    
    <script type="text/javascript">
        function check() {
            return confirm("确定撤销？");
        }
    </script>
    <style type="text/css">

        span{display:inline;}

        h3{
            font-size:large;
        }
       
               
        .auto-style1 {
            height: 33px;
        }
       
               
    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">报销管理</a></li>
                <li><a href="#">我的报销</a></li>
            </ul>
        </div>

        <div class="rightinfo">
            <div class="tools">

                <ul class="toolbar">
                    <li><span>
                        <img src="/media/images/t01.png" /></span>
                        <asp:LinkButton ID="lbAdd" runat="server"
                            OnClick="lbAdd_Click">添加报销单 </asp:LinkButton></li>
                </ul>

                <b>报销管理办法：</b>住宿费：房费不超340元/天；伙食补助费：有接待的不报销伙食补助，否则市外没人每天100元，市内每人每天40元包干，市内半天不报销伙食费；市内交通凭票或包干报销，标准详见文档。<br />
                </div>
            <!-- ****************** -->
            
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <asp:Panel ID="PanelApply" runat="server" Visible="False">
            <div style="margin:auto;width:700px;border:1px solid #000;">
                <h3 align="center">鄞州职教中心差旅费报销单</h3>
                填报人: <span>
                <asp:Label ID="lbUsername" runat="server"></asp:Label>
                &nbsp; </span>出差时间:
                <asp:TextBox  CssClass="inputunderborder" Width="80px" ID="tbStartDate" runat="server" Height="25px"  onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbStartDate" ErrorMessage="*必填" ForeColor="Red" ValidationGroup="bx" Display="Dynamic"></asp:RequiredFieldValidator>
                到 
                <asp:TextBox  CssClass="inputunderborder" Width="80px" ID="tbEndDate" runat="server" Height="25px"  onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbEndDate" ErrorMessage="*必填" ForeColor="Red" ValidationGroup="bx"></asp:RequiredFieldValidator>
                &nbsp;&nbsp;<asp:Label ID="lbFormId" runat="server" Text="formId" Visible="False"></asp:Label>
                <br />
                出差事由：<asp:TextBox ID="tbReason" runat="server" CssClass="inputunderborder" Height="25px" Width="200px"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbReason" ErrorMessage="*必填" ForeColor="Red" ValidationGroup="bx" Display="Dynamic"></asp:RequiredFieldValidator>
                目的地：<asp:DropDownList ID="ddlPositionType" runat="server" AutoPostBack="True" CssClass="inputunderborder" OnSelectedIndexChanged="ddlPositionType_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlPositionType" ErrorMessage="*必填" ForeColor="Red" ValidationGroup="bx"></asp:RequiredFieldValidator>
                <asp:DropDownList ID="ddlPosition" runat="server" AutoPostBack="True" CssClass="inputunderborder" OnSelectedIndexChanged="ddlPosition_SelectedIndexChanged" Visible="False">
                </asp:DropDownList>
                地点：<asp:TextBox ID="tbPosition" runat="server" CssClass="inputunderborder" Height="25px" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbPosition" ErrorMessage="*必填" ForeColor="Red" ValidationGroup="bx"></asp:RequiredFieldValidator>
                <br />
                <br />
                报销类型：<asp:DropDownList ID="ddlBXType" runat="server" AutoPostBack="True" CssClass="inputunderborder" OnSelectedIndexChanged="ddlBXType_SelectedIndexChanged">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="1">凭票</asp:ListItem>
                    <asp:ListItem Value="2">包干</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlBXType" ErrorMessage="*必填" ForeColor="Red" ValidationGroup="bx"></asp:RequiredFieldValidator>
                <asp:Panel ID="PanelPeople" runat="server" Visible="False">
                包干人数:<asp:TextBox ID="tbPeopleNum" runat="server" CssClass="inputunderborder" Height="25px" Width="80px"></asp:TextBox>
                    人（必须为数字）&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbPeopleNum" ErrorMessage="*必填" ForeColor="Red" ValidationGroup="bx" Display="Dynamic"></asp:RequiredFieldValidator>
                    包干人员:<asp:TextBox ID="tbPeoples" runat="server" CssClass="inputunderborder" Height="25px" Width="200px"></asp:TextBox>
                    （逗号分隔）<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="tbPeoples" ErrorMessage="*必填" ForeColor="Red" ValidationGroup="bx"></asp:RequiredFieldValidator>
                <br />
                </asp:Panel>
                <br />
                <br />
                <asp:Panel ID="PanelItems" runat="server" Visible="False">
                    <table class="tableborder" align="center"; style="width:98%;text-align:center;">
                    <tr>
                        <td  width="80px">日期</td>
                        <td  width="60px">天数</td>
                        <td  width="60px">人数</td>
                        <td  width="80px">市内交通费</td>
                        <td  width="80px">城间交通费</td>
                        <td  width="60px">接待单位是否安排用餐</td>
                        <td>伙食补助费</td>
                        <td width="80px">住宿费</td>
                        <td width="50px">操作</td>
                    </tr>
                    <tr>
                        <td >
                            <asp:TextBox ID="tbItemsStart" runat="server" Height="25px" Width="80%"   onclick="WdatePicker({skin:'whyGreen'})" ValidationGroup="item"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="tbItemsStart" ErrorMessage="*" ForeColor="Red" ValidationGroup="item"></asp:RequiredFieldValidator>
                        </td>
                        <td>

                            <asp:TextBox ID="tbDays" runat="server" Height="25px"  ValidationGroup="item" Width="60%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="tbDays" ErrorMessage="*" ForeColor="Red" ValidationGroup="item"></asp:RequiredFieldValidator>
                            天</td>
                        <td >
                            <asp:TextBox ID="tbItemsPeopleNum" runat="server" Height="25px"  Width="60%" ValidationGroup="item"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="tbItemsPeopleNum" ErrorMessage="*" ForeColor="Red" ValidationGroup="item"></asp:RequiredFieldValidator>
                            人</td>
                        <td >
                            <asp:TextBox ID="tbShineiFee" runat="server" Height="25px" Width="70%" ValidationGroup="item"></asp:TextBox>
                            元</td>
                        <td >
                            <asp:TextBox ID="tbChengjianFee" runat="server" Height="25px"  Width="70%" ValidationGroup="item"></asp:TextBox>
                            元</td>
                        <td>
                            <asp:DropDownList ID="ddlIsReception" runat="server" CssClass="inputunderborder" OnSelectedIndexChanged="ddlBXType_SelectedIndexChanged">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="1">是</asp:ListItem>
                                <asp:ListItem Value="0">否</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlIsReception" ErrorMessage="*" ForeColor="Red" ValidationGroup="item"></asp:RequiredFieldValidator>
                        </td>
                        <td >自动计算</td>
                        <td >
                            <asp:TextBox ID="tbAccomdanceFee" runat="server" Height="25px"  Width="70%" ValidationGroup="item"></asp:TextBox>
                            元</td>
                        <td >
                             <asp:LinkButton ID="lbAddItem" OnClick="lbAddItem_Click" runat="server" ValidationGroup="item"><i class="mbtn"><img width="20px" src="/media/images/t01.png" /></i></asp:LinkButton>
                              
                        </td>
                    </tr>
                     <asp:Repeater ID="RepeaterItem" runat="server" OnItemCommand="RepeaterItem_ItemCommand">
                        
                        <ItemTemplate>
                             <tr>
                        <td >
                            <%# Convert.ToDateTime( Eval("Date")).ToShortDateString()%>
                        </td>
                        <td ><%# Eval("Days")%>天</td>
                        <td ><%# Eval("PeoplesNum")%>人</td>
                        <td ><%# Eval("TrafficFee")%>元</td>
                        <td ><%# Eval("CityTrafficFee")%>元</td>
                        <td ><%# Eval("IsReception").ToString() == "True"?"是":"否" %></td>
                        <td ><%# Convert.ToDecimal( Eval("Allowance"))%>元</td>
                        <td ><%# Eval("AccommodationFee")%></td>
                        <td > <asp:LinkButton ID="lbDelete" runat="server" CommandName="del" CommandArgument='<%# Eval("Id")%>'><i class="mbtn"><img src="/media/images/t03.png" width="20px" /></i></asp:LinkButton>
                        </td>
                    </tr>
                        </ItemTemplate>

                    </asp:Repeater>
                    
                </table>
                </asp:Panel>
                
                <br />
                <br />
                <asp:Button ID="btApply" runat="server" Text="保存后添加报销明细" CssClass="btn" ValidationGroup="bx"  OnClientClick="javascript:showConfirm('确定提交?')"  OnClick="btApply_Click" />
            </div>
                <br />

        </asp:Panel>
            <asp:GridView ID="gvBXForm" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Id" Width="100%" 
                CssClass="tablelist">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" FooterStyle-CssClass="hidden" ControlStyle-CssClass="hidden">
                    <HeaderStyle Width="60px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="填报人">
                        <ItemTemplate>
                            <asp:Label ID="lbUsername" runat="server"><%# Session["username"].ToString()%></asp:Label>
                        </ItemTemplate>
                    <HeaderStyle Width="80px" />
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="出差时间">
                        <ItemTemplate>
                            <asp:Label ID="time" runat="server"><%# Convert.ToDateTime( Eval("StartDate")).ToShortDateString()%>到<%# Convert.ToDateTime( Eval("EndDate")).ToShortDateString()%></asp:Label>
                        </ItemTemplate>
                    <HeaderStyle Width="150px" />
                    </asp:TemplateField>


                    
                    <asp:BoundField DataField="Reason" HeaderText="出差事由">
                    <HeaderStyle Width="300px" />
                    </asp:BoundField>
                    
                    <asp:BoundField DataField="Position" HeaderText="目的地">
                    <HeaderStyle Width="120px" />
                    </asp:BoundField>
                    
                   
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            
                            <asp:HyperLink ID="hlEdit" runat="server" OnDataBinding="hlEdit_DataBinding">编辑</asp:HyperLink>&nbsp;
                            
                            <asp:HyperLink ID="hlView" runat="server" OnDataBinding="hlView_DataBinding">详情打印</asp:HyperLink>&nbsp;

                             </ItemTemplate>
                        <ItemStyle Width="130px" />
                    </asp:TemplateField>
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
                      SubmitButtonText="Go">
                    </webdiyer:AspNetPager>

            
                               

        </div>
        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>
</html>
