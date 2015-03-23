<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zcdj.aspx.cs" Inherits="web.Application.Assets.Lkgl.Zcdj" %>

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
        function chuan(mobj)
            //双击将选定行的名称赋值给母窗口并关闭,wpbm_view中赋的是名称 wpbm中赋的是编码
        {
            window.opener.document.body.all.txt_ZcDjID.value = mobj;
            window.close();
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
                <li><a href="#">资产登记</a></li>
            </ul>
        </div>
        <div class="toolsearch">
            <div class="pullleft">
            <ul class="toolbar">
                <li><span>
                    <img src="/media/images/t01.png" /></span>
                    <asp:LinkButton ID="lbAdd" runat="server"
                        OnClick="lbAdd_Click">新增</asp:LinkButton>
                    </li>
            </ul> 
                <asp:TextBox ID="tb_search" runat="server" CssClass="dfinput" Width="200px"></asp:TextBox>
                </div>              
             <div class="pullleft">
                    <asp:LinkButton ID="lbStatisc" runat="server"
                        OnClick="lbStatisc_Click"> <i class="mbtn"><img src="/media/images/ico06.png" />查询</i></asp:LinkButton>
                </div>
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
                                    <td width="80">资产登记ID</td>
                                    <td width="150">
                                        <asp:Label ID="lbl_ZcDjID" CssClass="dfinput" runat="server" Text="" Width="150px"></asp:Label></td>
                                    <td width="80">资产名称</td>
                                    <td width="100">
                                        <asp:TextBox ID="txt_ZcName" CssClass="dfinput" runat="server" Width="150px"></asp:TextBox></td>
                                    <td width="80">资产型号</td>
                                    <td width="100">
                                        <asp:TextBox ID="txt_ZcType" CssClass="dfinput" runat="server" Width="150px"></asp:TextBox></td>
                                    <td width="80">购买单</td>
                                    <td width="100">
                                        </td>
                                </tr>
                                <tr>
                                    <td width="80">分类0</td>
                                    <td width="150">
                                        <asp:DropDownList ID="ddl_Class0" CssClass="dfinput"  runat="server" Width="150" OnSelectedIndexChanged="ddl_Class0_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                                    <td>分类1</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Class1" CssClass="dfinput"  runat="server" Width="150" AutoPostBack="True" OnSelectedIndexChanged="ddl_Class1_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td>分类2</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Class2" CssClass="dfinput"  runat="server" Width="150" AutoPostBack="True" OnSelectedIndexChanged="ddl_Class2_SelectedIndexChanged"></asp:DropDownList></td>
                                    <td>分类3</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_Class3" CssClass="dfinput"  runat="server" Width="150"></asp:DropDownList></td>
                                </tr>
                                <tr>
                                    <td>总数量</td>
                                    <td>
                                        <asp:TextBox ID="txt_ZcSl" runat="server" CssClass="dfinput" Width="120px" Text="1"></asp:TextBox></td>
                                    <td>单位</td>
                                    <td>
                                        <asp:DropDownList ID="ddl_DW" CssClass="dfinput"  runat="server" Width="150"></asp:DropDownList></td>
                                    <td>单价</td>
                                    <td>
                                        <asp:TextBox ID="txt_ZcJg" CssClass="dfinput" runat="server" Width="120px" Text="0.00"></asp:TextBox></td>
                                    <td>操作日期</td>
                                    <td><asp:TextBox ID="txt_ZcDjOperateDate" CssClass="dfinput" Width="120px" runat="server" ></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>登记日期</td>
                                    <td><asp:TextBox ID="txt_ZcDjDate" CssClass="dfinput" Width="120px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox></td>
                                    <td></td>
                                    <td>&nbsp;</td>
                                    <td></td>
                                    <td></td>
                                    <td>登记操作员</td>
                                    <td>
                                        <asp:TextBox ID="txt_ZcDjUserKey" CssClass="dfinput"  Width="120px"  runat="server"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>备注</td>
                                    <td colspan="7">
                                        <asp:TextBox ID="txt_ZcDjRemark" runat="server" CssClass="dfinput" Width="800px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td colspan="8">
                                        <asp:Button ID="bt_Save" runat="server" OnClick="bt_Save_Click" Text="保存" CssClass="btn green" ValidationGroup="juese" /></td>
                                </tr>
                            </table>

                        </asp:Panel>
                    </div>

                    <asp:GridView ID="gvZC" runat="server" AutoGenerateColumns="False"
                        DataKeyNames="ZcDjID"  Width="100%" 
                        CssClass="tablelist" OnRowCommand ="gvZC_RowCommand" OnRowDataBound="gvZC_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="ZcDjID" HeaderText="资产登记ID" ItemStyle-Width="100px" >
                            <ItemStyle Width="100px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ZcName" HeaderText="资产名称"  ItemStyle-Width="200px" >
                            <ItemStyle Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ZcType" HeaderText="资产型号"  ItemStyle-Width="200px" >
                            <ItemStyle Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ZcSl" HeaderText="总数"  ItemStyle-Width="70px" >
                            <ItemStyle Width="80px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ZcJg" HeaderText="单价" DataFormatString="{0:c}"  ItemStyle-Width="100px" >
                            <ItemStyle HorizontalAlign="Right" Width="100px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="登记时间"  ItemStyle-Width="240px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ZcDjDate" runat="server" Text='<%# string.Format("{0:D}", Eval("ZcDjDate")) %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作时间"  ItemStyle-Width="200px">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_ZcDjOperateDate" runat="server" Text='<%# string.Format("{0:D}", Eval("ZcDjOperateDate")) %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle Width="100px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" ItemStyle-Width="160px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbEdit" runat="server" CommandName="ed" CommandArgument='<%# Eval("ZcDjID") %>   '>编辑</asp:LinkButton>&nbsp;&nbsp;
                                    <asp:LinkButton ID="lbDelete" runat="server" CommandName="del" CommandArgument='<%# Eval("ZcDjID") %>   '>删除</asp:LinkButton>
                                    <asp:LinkButton ID="lbSelectOK" runat="server" CommandName="sok" OnDataBinding="lbSelectOK_DataBinding" CommandArgument='<%# Eval("ZcDjID") %>   '>选择</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle Width="200px" />
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
