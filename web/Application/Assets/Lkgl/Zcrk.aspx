<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zcrk.aspx.cs" Inherits="web.Application.Assets.Lkgl.Zcrk" %>

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
                <li><a href="#">入库管理</a></li>
                <li><a href="#">资产入库</a></li>
            </ul>
        </div>

        <div class="tools">
            <ul class="toolbar">
                <li><span>
                    <img src="/media/images/t01.png" /></span>
                    <asp:LinkButton ID="lbAdd" runat="server"
                        OnClick="lbAdd_Click">新增资产</asp:LinkButton>
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




                    <div style="margin-bottom: 10px;">
                        <asp:Panel ID="PanelAddZC" runat="server">
                            <table class="tablelist" width="851" border="1" cellspacing="0" cellpadding="5">
                                <tr>
                                    <td width="80">资产登记号</td>
                                    <td ><asp:TextBox ID="txt_ZcDjID" CssClass="dfinput" runat="server" Text="" Width="80px"></asp:TextBox>&nbsp;&nbsp;
                                        <asp:ImageButton ID="ibt_Search" runat="server" ImageUrl="~/media/images/fd.gif" AlternateText="查询登记号" />
                                        &nbsp;&nbsp;<asp:ImageButton ID="ibt_Refresh" runat="server" ImageUrl="~/media/images/refresh.gif" AlternateText="刷新显示登记信息" OnClick="ibt_Refresh_Click" /></td>
                                    <td width="80">资产ID</td>
                                    <td width="150">
                                        <asp:Label ID="lbl_ID" CssClass="dfinput" runat="server" Text="" Width="150px"></asp:Label></td>
                                    <td width="80">资产名称</td>
                                    <td width="100">
                                        <asp:TextBox ID="txt_Name" CssClass="dfinput" runat="server" Width="150px" Enabled ="false" ></asp:TextBox></td>
                                    <td width="80">资产型号</td>
                                    <td width="100">
                                        <asp:TextBox ID="txt_Type" CssClass="dfinput" runat="server" Width="150px" Enabled ="false" ></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td width="80">分类0</td>
                                    <td width="150">
                                        <asp:DropDownList ID="ddl_Class0" CssClass="dfinput"  runat="server" Width="150" OnSelectedIndexChanged="ddl_Class0_SelectedIndexChanged" AutoPostBack="True" Enabled ="false" ></asp:DropDownList></td>
                                    <td>分类1</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Class1" CssClass="dfinput"  runat="server" Width="150" AutoPostBack="True" OnSelectedIndexChanged="ddl_Class1_SelectedIndexChanged" Enabled ="false" ></asp:DropDownList></td>
                                    <td>分类2</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Class2" CssClass="dfinput"  runat="server" Width="150" AutoPostBack="True" OnSelectedIndexChanged="ddl_Class2_SelectedIndexChanged" Enabled ="false" ></asp:DropDownList></td>
                                    <td>分类3</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Class3" CssClass="dfinput"  runat="server" Width="150" Enabled ="false" ></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>数量</td>
                                    <td>
                                        <asp:TextBox ID="txt_Sl" runat="server" CssClass="dfinput" Width="120px" Text="1"></asp:TextBox></td>
                                    <td>单位</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_DW" CssClass="dfinput"  runat="server" Width="150" Enabled ="false" ></asp:DropDownList></td>
                                    <td>价格</td>
                                    <td>
                                        <asp:TextBox ID="txt_Jg" CssClass="dfinput" runat="server" Width="120px" Text="0.00" Enabled ="false" ></asp:TextBox></td>
                                    <td></td> 
                                    <td></td> 
                                </tr>
                                <tr>
                                    <td>资产编码</td>
                                    <td><asp:TextBox ID="txt_TXM" Width="120px" CssClass="dfinput" runat="server"></asp:TextBox></td>
                                    <td>仓库</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_CK" CssClass="dfinput"  runat="server" Width="150"></asp:DropDownList></td>
                                    <td>状态</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_ZT" CssClass="dfinput"  runat="server" Width="120px" OnDataBinding="ddl_ZT_DataBinding"></asp:DropDownList></td>
                                    <td>入库日期</td>
                                    <td>
                                        <asp:TextBox ID="txt_RkDate" CssClass="dfinput" Width="120px" runat="server"  onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>备注</td>
                                    <td colspan="5">
                                        <asp:TextBox ID="txt_Remark" runat="server" CssClass="dfinput" Width="800px"></asp:TextBox></td>
                                   <td>入库操作员</td>
                                    <td>
                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="dfinput"  Width="120px"  Enabled ="false"  ></asp:TextBox></td>
                                                   </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:Button ID="bt_Save" runat="server" OnClick="bt_Save_Click" Text="保存" CssClass="btn green" ValidationGroup="juese" /></td>
                                </tr>
                            </table>

                        </asp:Panel>
                    </div>

                    <asp:GridView ID="gvZC" runat="server" AutoGenerateColumns="False"
                        DataKeyNames="ZcID"  Width="100%" 
                        CssClass="tablelist" OnRowCommand ="gvZC_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="ZcID" HeaderText="资产ID" ItemStyle-Width="100px" />
                            <asp:BoundField DataField="ZcName" HeaderText="资产名称"  ItemStyle-Width="200px" />
                            <asp:BoundField DataField="ZcType" HeaderText="资产型号"  ItemStyle-Width="200px" />
                            <asp:BoundField DataField="ZcTXM" HeaderText="资产编码"  ItemStyle-Width="120px" />
                            <asp:TemplateField HeaderText="状态" ItemStyle-Width="100px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_Zt" runat="server"><%# Eval("ZT_Name") %></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="120px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="入库时间"  ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_LKDate" runat="server" Text='<%# string.Format("{0:D}", Eval("ZcRkDate")) %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbEdit" runat="server" CommandName="ed" CommandArgument='<%# Eval("ZcID") %>   '>编辑</asp:LinkButton>&nbsp;&nbsp;
                                    <asp:LinkButton ID="lbDelete" runat="server" CommandName="del" CommandArgument='<%# Eval("ZcID") %>   '>删除</asp:LinkButton>
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
