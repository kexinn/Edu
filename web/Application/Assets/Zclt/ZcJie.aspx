<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ZcJie.aspx.cs" Inherits="web.Application.Assets.Zclt.ZcJie" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/calendar/WdatePicker.js"></script>
    <script type="text/javascript">

        function check() {
            return confirm("确定导入？");
        }
    </script>
    <style>
        span {
            display: inline;
        }
    </style>

</head>


<body>
    <form id="form1" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">资产管理</a></li>
                <li><a href="#">流通管理</a></li>
                <li><a href="#">资产出借</a></li>
            </ul>
        </div>

        <div class="tools">
            <ul class="toolbar">
                <li>
                    <span>
                        <img src="/media/images/t01.png" /></span>
                    <asp:LinkButton ID="lbAdd" runat="server"
                        OnClick="lbAdd_Click">增加资产</asp:LinkButton>
                </li>
            </ul>
        </div>

        <div class="rightinfo">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div>
                        &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>
                    </div>

                    <div class="toolsearch">
                        <div class="pullleft">
                            姓名：<asp:TextBox ID="txt_UserName" Width="120px" CssClass="dfinput" runat="server"></asp:TextBox>
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server" TargetControlID="txt_UserName" ServicePath="/webservice/user/UserWebService.asmx" ServiceMethod="GetUsers" CompletionSetCount="10" MinimumPrefixLength="1"></asp:AutoCompleteExtender>
                            <asp:Label ID="lbl_UserID" runat="server" Text=""></asp:Label>
                        </div>

                        <div class="pullleft">
                            <asp:LinkButton ID="lbn_SearchUser" runat="server"  
                                onclick="lbn_SearchUser_Click" ><i class="mbtn"><img src="/media/images/ico06.png" />教师查询</i></asp:LinkButton>
                        </div>
                        
                        <div class="pullleft">
                            &nbsp;&nbsp;&nbsp;&nbsp;资产编号：<asp:TextBox ID="txt_ZcTXM" Width="160px" CssClass="dfinput" runat="server" AutoPostBack="True" OnTextChanged="txt_ZcTXM_TextChanged"></asp:TextBox>
                            <asp:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server" TargetControlID="txt_UserName" ServicePath="/webservice/user/UserWebService.asmx" ServiceMethod="GetUsers" CompletionSetCount="10" MinimumPrefixLength="1"></asp:AutoCompleteExtender>
                            <asp:Label ID="lbl_ZcID" runat="server" Text=""></asp:Label>
                        </div>

                        <div class="pullleft">
                            <asp:LinkButton ID="lbn_SearchZc" runat="server" OnClick="lbn_SearchZc_Click"  
                               ><i class="mbtn"><img src="/media/images/ico06.png" />资产查询</i></asp:LinkButton>
                        </div>

                        <div class="clear"></div>
                    </div>

                    <div style="margin-bottom: 10px;">
                        <asp:Panel ID="PanelAddZC" runat="server">
                            <table class="tablelist" width="851" border="1" cellspacing="0" cellpadding="5">
                                <tr>
                                    <td width="80">资产ID</td>
                                    <td width="150">
                                        <asp:Label ID="lbl_ID" CssClass="dfinput" runat="server" Text="" Width="150px"></asp:Label></td>
                                    <td width="80">资产名称</td>
                                    <td width="100">
                                        <asp:TextBox ID="txt_Name" CssClass="dfinput" runat="server" Width="150px"></asp:TextBox></td>
                                    <td width="80">资产型号</td>
                                    <td width="100">
                                        <asp:TextBox ID="txt_Type" CssClass="dfinput" runat="server" Width="150px"></asp:TextBox></td>
                                    <td width="80">资产编码</td>
                                    <td width="100">
                                        <asp:TextBox ID="txt_TXM" Width="120px" CssClass="dfinput" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td width="80">分类0</td>
                                    <td width="150">
                                        <asp:DropDownList ID="ddl_Class0" runat="server" Width="150" AutoPostBack="True" ></asp:DropDownList></td>
                                    <td>分类1</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Class1" runat="server" Width="150" AutoPostBack="True" ></asp:DropDownList></td>
                                    <td>分类2</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Class2" runat="server" Width="150" AutoPostBack="True" ></asp:DropDownList></td>
                                    <td>分类3</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Class3" runat="server" Width="150"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>数量</td>
                                    <td>
                                        <asp:TextBox ID="txt_Sl" runat="server" CssClass="dfinput" Width="120px" Text="1"></asp:TextBox></td>
                                    <td>单位</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_DW" runat="server" Width="150"></asp:DropDownList></td>
                                    <td>价格</td>
                                    <td>
                                        <asp:TextBox ID="txt_Jg" CssClass="dfinput" runat="server" Width="120px" Text="0.00"></asp:TextBox></td>
                                    <td>购买单</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Buy" CssClass="dfinput" runat="server"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>仓库</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_CK" runat="server" Width="150"></asp:DropDownList></td>
                                    <td>状态</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_ZT" runat="server" Width="120px" OnDataBinding="ddl_ZT_DataBinding1"></asp:DropDownList></td>
                                    <td></td>
                                    <td></td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>当前借用</td>
                                    <td>&nbsp;</td>
                                    <td>历史记录</td>
                                    <td>&nbsp;</td>
                                    <td>入库日期</td>
                                    <td>
                                        <asp:TextBox ID="txt_LkDate" CssClass="dfinput" Width="120px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                                    </td>
                                    <td>入库操作员</td>
                                    <td>
                                        <asp:TextBox ID="txt_LkUser" runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>资产备注</td>
                                    <td colspan="7">
                                        <asp:TextBox ID="txt_Remark" runat="server" CssClass="dfinput" Width="800px"></asp:TextBox></td>
                                </tr>
                            </table>
                        </asp:Panel>

                        <asp:Panel ID="PanelJie" runat="server">
                            <table class="tablelist" width="851" border="1" cellspacing="0" cellpadding="5">
                                <tr>
                                    <td>使用地点1-楼</td>
                                    <td width="150">
                                        <asp:DropDownList ID="ddl_Position1" runat="server" Width="150" AutoPostBack="True"  OnSelectedIndexChanged="ddl_Position1_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td>使用地点2-层</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Position2" runat="server" Width="150" AutoPostBack="True" OnSelectedIndexChanged="ddl_Position2_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td>使用地点3-室</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Position3" runat="server" Width="150" AutoPostBack="True" ></asp:DropDownList></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td>借用用途</td>
                                    <td colspan="7">
                                        <asp:TextBox ID="txt_JieYongtu" runat="server" CssClass="dfinput" Width="800px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>借用日期</td>
                                    <td>
                                        <asp:TextBox ID="txt_JieDate" CssClass="dfinput" Width="120px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                                    <td>应还日期</td>
                                    <td>
                                        <asp:TextBox ID="txt_YingHuanDate" CssClass="dfinput" Width="120px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                                    <td>操作日期</td>
                                    <td>
                                        <asp:Label ID="lbl_JieOperateDate" CssClass="dfinput" runat="server" Text="" Width="150px"></asp:Label>
                                    </td>
                                    <td>出借操作员</td>
                                    <td>
                                        <asp:Label ID="lbl_JieJBRUserKey" CssClass="dfinput" runat="server" Text="" Width="150px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>出借备注</td>
                                    <td colspan="7">
                                        <asp:TextBox ID="txt_JieRemark" runat="server" CssClass="dfinput" Width="800px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:Button ID="bt_Save" runat="server" OnClick="bt_Save_Click" Text="保存" CssClass="btn green" ValidationGroup="juese" /></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>

                    <asp:GridView ID="gvJie" runat="server" AutoGenerateColumns="False"
                        DataKeyNames="JieID" Width="100%"
                        CssClass="tablelist" OnRowCommand="gvJie_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="JieID" HeaderText="出借ID" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="ZcName" HeaderText="资产名称" ItemStyle-Width="200px" />
                            <asp:TemplateField HeaderText="资产编码" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ZcTXM" runat="server" Text='<%# Eval("ZcTXM") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="借用人" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_TrueName" runat="server" Text='<%# Eval("TrueName") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="借用时间" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_JieDate" runat="server" Text='<%# string.Format("{0:D}", Eval("JieDate")) %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="应还时间" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_YingHuanDate" runat="server" Text='<%# string.Format("{0:D}", Eval("YingHuanDate")) %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbDetails" runat="server" CommandName="details" CommandArgument='<%# Eval("ZcTXM") %>   '>资产信息</asp:LinkButton>&nbsp;&nbsp;
                                    <asp:LinkButton ID="lbEdit" runat="server" CommandName="ed" CommandArgument='<%# Eval("JieID") %>   '>编辑</asp:LinkButton>&nbsp;&nbsp;
                                    <asp:LinkButton ID="lbDelete" runat="server" CommandName="del" CommandArgument='<%# Eval("JieID") %>   '>删除</asp:LinkButton>
                                </ItemTemplate>
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
                        InputBoxClass=""
                        SubmitButtonClass="pagebtn"
                        SubmitButtonText="Go" BackColor="White" BorderColor="Gray" CustomInfoClass="" Height="25px" Wrap="False">
                    </webdiyer:AspNetPager>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>

</html>
