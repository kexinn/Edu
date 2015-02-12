<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SchedulingManagement.aspx.cs" Inherits="web.Application.KQ.SchedulingManagement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
        #TextArea1 {
            height: 132px;
            width: 478px;
        }
        #tbReason {
            height: 115px;
            width: 491px;
        }
        .tableMonth{
            border:1px solid #000000;
            margin-top:10px;
        }
         .tableMonth th{
            border:1px solid #000000;
            background:#f2a665 ;
            height:25px;
        }
          .tableMonth td{
            border:1px solid #000000;
            text-align:center;
            height:60px;
            width:50px;
        }
        </style>

</head>
<body>
    <form id="form1" runat="server">
    <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">请假管理</a></li>
                <li><a href="#">排班管理</a></li>
            </ul>
        </div>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <div class="rightinfo">
            <div class="tools">

                <ul class="toolbar">
                    <li><span>
                        <img src="/media/images/t05.png" /></span>
                        <asp:LinkButton ID="lbPaiban" runat="server" OnClick="lbPaiban_Click">排班管理 </asp:LinkButton></li>
                    
                    <li><span>
                        <img src="/media/images/t05.png" /></span>
                        <asp:LinkButton ID="lbBanci" runat="server" OnClick="lbBanci_Click">班次管理 </asp:LinkButton></li>
                    <li><span>
                        <img src="/media/images/t05.png" /></span>
                        <asp:LinkButton ID="lbGen" runat="server" OnClick="lbGen_Click">生成报表 </asp:LinkButton></li>
                </ul>

                </div>
            <!-- ****************** -->
          

            <asp:MultiView ID="mv1" runat="server" ActiveViewIndex="0">
                <asp:View ID="viewPaiban" runat="server">
                     <div class="formtitle"><span>排班管理</span>
                        
                </div>
                     选择年份：<asp:DropDownList ID="ddlYear" runat="server" AutoPostBack="True" CssClass="dfinput"  Width="80px" OnSelectedIndexChanged="ddlYear_SelectedIndexChanged">
                        
                     </asp:DropDownList>
                     当前年份：<asp:Label ID="lbYear" runat="server" Font-Bold="True"></asp:Label> ，选择月份：<asp:DropDownList ID="ddlMonth" CssClass="dfinput" Width="80px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged">
                         <asp:ListItem Value="1">一月</asp:ListItem>
                         <asp:ListItem Value="2">二月</asp:ListItem>
                         <asp:ListItem Value="3">三月</asp:ListItem>
                         <asp:ListItem Value="4">四月</asp:ListItem>
                         <asp:ListItem Value="5">五月</asp:ListItem>
                         <asp:ListItem Value="6">六月</asp:ListItem>
                         <asp:ListItem Value="7">七月</asp:ListItem>
                         <asp:ListItem Value="8">八月</asp:ListItem>
                         <asp:ListItem Value="9">九月</asp:ListItem>
                         <asp:ListItem Value="10">十月</asp:ListItem>
                         <asp:ListItem Value="11">十一月</asp:ListItem>
                         <asp:ListItem Value="12">十二月</asp:ListItem>
                     </asp:DropDownList>
                     &nbsp;
                     <asp:Button ID="btSearch" runat="server" CssClass="btn" OnClick="btSearch_Click" Text="查看排班" />
                     &nbsp;&nbsp;<asp:Table ID="tableMonth" runat="server" CellPadding="5" CssClass="tableMonth" Width="100%">
                         <asp:TableHeaderRow>
                             <asp:TableHeaderCell>星期天</asp:TableHeaderCell>
                             <asp:TableHeaderCell>星期一</asp:TableHeaderCell>
                             <asp:TableHeaderCell>星期二</asp:TableHeaderCell>
                             <asp:TableHeaderCell>星期三</asp:TableHeaderCell>
                             <asp:TableHeaderCell>星期四</asp:TableHeaderCell>
                             <asp:TableHeaderCell>星期五</asp:TableHeaderCell>
                             <asp:TableHeaderCell>星期六</asp:TableHeaderCell>
                         </asp:TableHeaderRow>
                     </asp:Table>
                     &nbsp;<asp:LinkButton ID="lbSaveSched" runat="server" OnClick="lbSaveSched_Click"><i class="mbtn"><img src="../../media/images/leftico04.png" />保存排班</i></asp:LinkButton>
                     <br />
                     <br />
                     <br />
                     <br />
                     <asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>
                     <br />
                </asp:View>
                <asp:View ID="viewBanci" runat="server">
                <div class="formtitle"><span>班次管理</span>
                        
                   

                </div> <asp:LinkButton ID="lbAdd" runat="server"
                                            OnClick="lbAdd_Click"><i class="mbtn"><img src="../../media/images/leftico04.png" />添加班次</i></asp:LinkButton>
                    <asp:Panel ID="PanelAdd" runat="server">

                <table class="tablelist">
                    <tr>
                        <th>名称</th>
                        <th >是否上班 </th>
                        <th>上班时间</th>
                        <th>是否下班</th>
                        <th>下班时间</th>
                        <th>是否默认</th>
                        <th>备注</th>
                        <th>操作</th>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="tbName" CssClass="dfinput" runat="server" Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbName" ErrorMessage="*" ForeColor="Red" ValidationGroup="shift"></asp:RequiredFieldValidator>
                        </td>
                        <td>
                             <asp:CheckBox ID="cbShangban" runat="server" Text="是否上班打卡" />
                        </td>
                        <td>
                             <asp:TextBox ID="tbShangbanTime" CssClass="dfinput"  onclick="WdatePicker({skin:'whyGreen',dateFmt:'H:mm:ss'})"  runat="server" Width="100px"></asp:TextBox>
                        </td>
                        <td> <asp:CheckBox ID="cbXiaban" runat="server" Text="是否下班打卡" />

                        </td>
                        <td>
                            <asp:TextBox ID="tbXiabanTime" CssClass="dfinput"  onclick="WdatePicker({skin:'whyGreen',dateFmt:'H:mm:ss'})" runat="server" Width="100px"></asp:TextBox>
                        </td>
                        
                        <td>
                             <asp:CheckBox ID="cbDefault" runat="server" Text="是否默认" />
                        </td>
                        <td>
                            <asp:TextBox ID="tbRemark" CssClass="dfinput" runat="server" Width="100px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btAdd" runat="server" OnClick="btAdd_Click" Text="添加"
                                CssClass="btn" ValidationGroup="shift" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
           
                     <asp:GridView ID="gvShift" runat="server" AutoGenerateColumns="False"
                DataKeyNames="Id"  Width="100%"
                CssClass="tablelist" OnRowCancelingEdit="gvShift_RowCancelingEdit" OnRowDeleting="gvShift_RowDeleting" OnRowEditing="gvShift_RowEditing" OnRowUpdating="gvShift_RowUpdating">
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <EditItemTemplate>
                            <asp:Label ID="lbID" runat="server"><%# Eval("Id") %></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbID" runat="server"><%# Eval("Id") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="名称">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbName" runat="server" Text='<%# Eval("Name") %>' Width="120px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbName" runat="server"><%# Eval("Name") %></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>

                    
                    <asp:TemplateField HeaderText="是否上班打卡">
                        <EditItemTemplate>
                            <asp:CheckBox ID="cbShangban" runat="server" OnDataBinding="cbShangban_DataBinding" Enabled ="true" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="cbShangban" runat="server" OnDataBinding="cbShangban_DataBinding" Enabled ="false" />
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="上班打卡时间">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbClockOnTime" runat="server" Text='<%# Eval("ClockOnTime") %>' Width="120px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbClockOnTime" runat="server"><%# Eval("ClockOnTime")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="90px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否下班打卡">
                        <EditItemTemplate>
                            <asp:CheckBox ID="cbXiaban" runat="server" OnDataBinding="cbXiaban_DataBinding"  Enabled ="true" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="cbXiaban" runat="server" OnDataBinding="cbXiaban_DataBinding"  Enabled ="false" />
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="下班打卡时间">
                        <EditItemTemplate>
                            <asp:TextBox ID="tbClockOffTime" runat="server" Text='<%# Eval("ClockOffTime") %>' Width="120px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbClockOffTime" runat="server"><%# Eval("ClockOffTime")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="90px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="是否默认">
                        <EditItemTemplate>
                            <asp:CheckBox ID="cbDefault" runat="server" OnDataBinding="cbDefault_DataBinding"  Enabled ="true" />
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="cbDefault" runat="server" OnDataBinding="cbDefault_DataBinding"   Enabled ="false" />
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="备注">
                        <EditItemTemplate>
                           <asp:TextBox ID="tbRemark" runat="server" Text='<%# Eval("Remark") %>' Width="120px"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lbRemark" runat="server" ><%# Eval("Remark")%></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="100px" />
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
                                                <asp:LinkButton ID="lbDel" runat="server" Enabled="false" CommandName="Delete">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                   
                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
                </asp:View>

                <asp:View ID="viewGen" runat="server">
                <div class="formtitle"><span>生成报表</span>
                </div> 
                    
            <div class="toolsearch">
                <div class="pullleft">
                    开始时间：<asp:TextBox ID="tbStartTime" CssClass="dfinput" Width="120px" runat="server" onclick="WdatePicker({skin:'whyGreen'})" ValidationGroup="gen"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="inline" runat="server" ControlToValidate="tbStartTime" ErrorMessage="*" ForeColor="Red" ValidationGroup="gen"></asp:RequiredFieldValidator>
                    结束时间：<asp:TextBox ID="tbEndTime" CssClass="dfinput" Width="120px" runat="server"  onclick="WdatePicker({skin:'whyGreen'})" ValidationGroup="gen"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="inline" runat="server" ControlToValidate="tbEndTime" ErrorMessage="*" ForeColor="Red" ValidationGroup="gen"></asp:RequiredFieldValidator>
                    <%-- <asp:TextBox ID="TextBox1" CssClass="dfinput" runat="server" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm:ss',minDate:'2008-03-08 11:30:00',maxDate:'2100-03-10 20:59:30'})"></asp:TextBox>
               --%> </div>

                <div class="pullright">

                </div>
                <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional"  runat="server">
    <ContentTemplate> 
                <div class="pullleft">
                    <asp:LinkButton ID="lbStatisc" runat="server"
                        OnClick="lbStatisc_Click" ValidationGroup="gen"> <i class="mbtn"><img src="/media/images/ico06.png" />生成报表</i></asp:LinkButton>
                </div>  
                <div class="clear">
                    <br />
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2" >
        <ProgressTemplate>
           
            <font color="blue" >正在计算<asp:Image ID="Image1" runat="server" ImageUrl="/media/images/jindu.gif" /></font>
            
        </ProgressTemplate>
    </asp:UpdateProgress>
                </div>
            </div>
            <div>
                &nbsp;<asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>


            </div>
            
            <asp:GridView ID="GridView1" runat="server" CssClass="tablenoborder">
                 <Columns>
                <asp:TemplateField HeaderText="序号" InsertVisible="False">
               <ItemStyle HorizontalAlign="Center" />
               <HeaderStyle HorizontalAlign="Center" />
              <ItemTemplate>
               <%#Container.DataItemIndex+1%>
             </ItemTemplate>
             </asp:TemplateField>
                     </Columns>
            </asp:GridView>
 </ContentTemplate></asp:UpdatePanel> 
        </div>
                </asp:View>
            </asp:MultiView>
          

        </div>
        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>
</html>
