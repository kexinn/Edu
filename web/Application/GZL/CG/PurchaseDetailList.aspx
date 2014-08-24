<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseDetailList.aspx.cs" Inherits="web.Application.GZL.CG.PurchaseDetailList" %>


<!DOCTYPE html>

<style type="text/css">
    p.MsoNormal {
        margin-bottom: .0001pt;
        text-align: justify;
        text-justify: inter-ideograph;
        font-size: 10.5pt;
        font-family: "Calibri","sans-serif";
        margin-left: 0cm;
        margin-right: 0cm;
        margin-top: 0cm;
    }

    table.MsoTableGrid {
        border: solid windowtext 1.0pt;
        font-size: 10.5pt;
        font-family: "Calibri","sans-serif";
    }

    p.MsoListParagraph {
        margin-bottom: .0001pt;
        text-align: justify;
        text-justify: inter-ideograph;
        text-indent: 21.0pt;
        font-size: 10.5pt;
        font-family: "Calibri","sans-serif";
        margin-left: 0cm;
        margin-right: 0cm;
        margin-top: 0cm;
    }

    .auto-style1 {
        width: 57px;
    }

    .auto-style2 {
        height: 121px;
    }
</style>

<!--[if IE 8]> <html lang="en" class="ie8"> <![endif]-->

<!--[if IE 9]> <html lang="en" class="ie9"> <![endif]-->

<!--[if !IE]><!-->
<html lang="en">
<!--<![endif]-->

<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>职教中心日常管理系统</title>

    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/formstyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/js/jquery.jqprint-0.3.js"></script>


    <!-- END GLOBAL MANDATORY STYLES -->
    <script language="javascript" type="text/jscript">
        //设置网页打印的页眉页脚为空
        function pagesetup_null() {
            var hkey_root, hkey_path, hkey_key;
            hkey_root = "HKEY_CURRENT_USER"
            hkey_path = "\\Software\\Microsoft\\Internet Explorer\\PageSetup\\";
            try {
                var RegWsh = new ActiveXObject("WScript.Shell");
                hkey_key = "header";
                RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "");
                hkey_key = "footer";
                RegWsh.RegWrite(hkey_root + hkey_path + hkey_key, "");
            } catch (e) { }
        }
        function preview() {

            bdhtml = window.document.body.innerHTML;
            sprnstr = "<!--startprint-->";
            eprnstr = "<!--endprint-->";
            prnhtml = bdhtml.substr(bdhtml.indexOf(sprnstr) + 17);
            prnhtml = prnhtml.substring(0, prnhtml.indexOf(eprnstr));
            window.document.body.innerHTML = prnhtml;
            window.print();
        }
        function print() {
            $("#print").jqprint();
        }
    </script>
</head>
<body>


    <form id="form1" runat="server" style="background-color: #ffffff">

        <!-- BEGIN HEADER -->
        <div class="logintop">
            <span>欢迎登录日常管理平台</span>
            <ul>


                <li>
                    <asp:Panel ID="PanelBanli" runat="server" CssClass="pull-right">
                        <a href="#" id="linkBanli" runat="server">办理</a>
                    </asp:Panel>
                </li>

                <li>
                    <a href="#" onclick="print()">打印</a>

                </li>
            </ul>
            <div class="clear"></div>
        </div>


        <div class="fixhead"></div>
        <!-- END HEADER -->
        <!--startprint-->
        <div id="print">
            <div>

                <div style="margin: 0 auto; width: 800px;">

                    <p class="MsoNormal">
                        <span>附件</span><span lang="EN-US">2<o:p></o:p></span>
                    </p>
                    <p align="center" class="MsoNormal" style="margin: 0 auto; width: 280px;">
                        <b><span>鄞州职教中心购物、维修申请单</span><span lang="EN-US"><o:p></o:p></span></b>
                    </p>
                    <p class="MsoNormal">
                        <span lang="EN-US">
                            <o:p>&nbsp;</o:p>
                        </span>
                    </p>
                    <p class="MsoNormal">
                        <span>申请部门：</span><span lang="EN-US">&nbsp;<asp:Label ID="lbDept" runat="server"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;申购人：<asp:Label ID="lbUserName" runat="server"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span>申购日期：</span><span lang="EN-US">&nbsp;&nbsp;<asp:Label ID="lbYear" runat="server"></asp:Label>
                                &nbsp; </span><span>年</span><span lang="EN-US">&nbsp;<asp:Label ID="lbMonth" runat="server"></asp:Label>
                                    &nbsp; </span><span>月</span><span lang="EN-US">&nbsp;&nbsp;<asp:Label ID="lbDay" runat="server"></asp:Label>
                                        &nbsp;</span><span>日</span><span lang="EN-US"><o:p></o:p></span>
                    </p>
                    <table border="1" cellpadding="0" cellspacing="0" class="MsoTableGrid tableform">
                        <tr>
                            <td width="36">
                                <p align="center" class="MsoNormal">
                                    <span>序号</span><span lang="EN-US"><o:p></o:p></span>
                                </p>
                            </td>
                            <td colspan="2" width="189">
                                <p align="center" class="MsoNormal">
                                    <span>资产名称</span><span lang="EN-US"><o:p></o:p></span>
                                </p>
                            </td>
                            <td colspan="2" width="113">
                                <p align="center" class="MsoNormal">
                                    <span>规格型号</span><span lang="EN-US"><o:p></o:p></span>
                                </p>
                            </td>
                            <td class="auto-style1">
                                <p align="center" class="MsoNormal">
                                    <span>需量</span><span lang="EN-US"><o:p></o:p></span>
                                </p>
                            </td>
                            <td width="57">
                                <p align="center" class="MsoNormal">
                                    <span>单价(元)</span>
                                </p>
                            </td>
                            <td width="57">
                                <p align="center" class="MsoNormal">
                                    <span>采购量</span><span lang="EN-US"><o:p></o:p></span>
                                </p>
                            </td>
                            <td width="57">
                                <p align="center" class="MsoNormal">
                                    <span>金额</span><span lang="EN-US"><o:p></o:p></span>
                                </p>
                            </td>
                            <td colspan="2" width="57">
                                <p align="center" class="MsoNormal">
                                    验收人员签名
                                </p>
                            </td>
                            <td width="45">
                                <p align="center" class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>备注</o:p>
                                    </span>
                                </p>
                            </td>
                        </tr>
                        <asp:Repeater ID="RepeaterItem" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td valign="top" width="36">
                                        <p align="center" class="MsoNormal">
                                            <span lang="EN-US">
                                                <o:p><%# Eval("sortId")%></o:p>
                                            </span>
                                        </p>
                                    </td>
                                    <td colspan="2" valign="top" width="189">
                                        <p class="MsoNormal">
                                            <span lang="EN-US">
                                                <o:p><%# Eval("itemName")%></o:p>
                                            </span>
                                        </p>
                                    </td>
                                    <td colspan="2" valign="top" width="113">
                                        <p class="MsoNormal">
                                            <span lang="EN-US">
                                                <o:p><%# Eval("type")%></o:p>
                                            </span>
                                        </p>
                                    </td>
                                    <td valign="top" width="57">
                                        <p class="MsoNormal">
                                            <span lang="EN-US">
                                                <o:p><%# Eval("needNumber")%></o:p>
                                            </span>
                                        </p>

                                    </td>
                                    <td valign="top" width="57">
                                        <p class="MsoNormal">
                                            <span lang="EN-US">
                                                <o:p><%# Eval("price")%></o:p>
                                            </span>
                                        </p>
                                    </td>
                                    <td valign="top" width="57">
                                        <p class="MsoNormal">
                                            <span lang="EN-US">
                                                <o:p><%# Eval("number")%></o:p>
                                            </span>
                                        </p>
                                    </td>
                                    <td colspan="2" valign="top" width="57">
                                        <p class="MsoNormal">
                                            <span lang="EN-US">
                                                <o:p><%# Eval("totalPrice")%></o:p>
                                            </span>
                                        </p>
                                    </td>
                                    <td valign="top" width="57">
                                        <p class="MsoNormal">
                                            <span lang="EN-US">
                                                <o:p></o:p>
                                            </span>
                                        </p>
                                    </td>
                                    <td valign="top" width="45">
                                        <p class="MsoNormal">
                                            <span lang="EN-US">
                                                <o:p><%# Eval("memo")%></o:p>
                                            </span>
                                        </p>
                                    </td>
                                </tr>
                            </ItemTemplate>

                        </asp:Repeater>

                        <tr>
                            <td width="36">
                                <p align="center" class="MsoNormal">
                                    &nbsp;
                                </p>
                            </td>
                            <td colspan="2" valign="top" width="189">
                                <p class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                            </td>
                            <td colspan="2" valign="top" width="113">
                                <p class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                            </td>
                            <td valign="top" class="auto-style1">
                                <p class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                                <p class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                            </td>
                            <td valign="top" width="57">
                                <p class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                            </td>
                            <td valign="top" width="57">
                                <p class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                            </td>
                            <td valign="top" width="57">
                                &nbsp;</td>
                            <td colspan="2" valign="top" width="57">
                                <p class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                            </td>
                            <td valign="top" width="45">
                                <p class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td width="36">
                                <p align="center" class="MsoNormal">
                                    &nbsp;
                                </p>
                            </td>
                            <td colspan="2" valign="top" width="189">
                                <p class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                            </td>
                            <td colspan="2" valign="top" width="113">
                                <p class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                            </td>
                            <td valign="top" class="auto-style1">
                                <p class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                                <p class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                            </td>
                            <td valign="top" width="57">
                                <p class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                            </td>
                            <td valign="top" width="57">
                                <p class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                            </td>
                            <td valign="top" width="57">
                                &nbsp;</td>
                            <td colspan="2" valign="top" width="57">
                                <p class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                            </td>
                            <td valign="top" width="45">
                                <p class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td width="36" class="auto-style2" colspan="12">

                                <p align="center" class="MsoNormal">
                                    <span>申购理 由</span><span lang="EN-US"><o:p></o:p>
                                        ：</span>
                                </p>
                                <p align="center" class="MsoNormal">
                                    &nbsp;
                                </p>
                                <p align="center" class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p></o:p>
                                        <asp:Label ID="lbReason" runat="server"></asp:Label>
                                        &nbsp;</span>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="54">
                                <p align="center" class="MsoNormal">
                                    <span>分管</span><span lang="EN-US"><o:p></o:p></span>
                                </p>
                                <p align="center" class="MsoNormal">
                                    <span>校长</span><span lang="EN-US"><o:p></o:p></span>
                                </p>
                                <p align="center" class="MsoNormal">
                                    <span>意见</span><span lang="EN-US"><o:p></o:p></span>
                                </p>
                            </td>
                            <td width="170">
                                <p align="center" class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                                <p align="center" class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                                <p align="center" class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                        <asp:Label ID="lbFenguanYijian" runat="server"></asp:Label>
                                    </span>
                                </p>
                                <p align="center" class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                            </td>
                            <td width="57">
                                <p align="center" class="MsoNormal">
                                    <span>校长</span><span lang="EN-US"><o:p></o:p></span>
                                </p>
                                <p align="center" class="MsoNormal">
                                    <span>审批</span><span lang="EN-US"><o:p></o:p></span>
                                </p>
                                <p align="center" class="MsoNormal">
                                    <span>意见</span><span lang="EN-US"><o:p></o:p></span>
                                </p>
                            </td>
                            <td colspan="3" width="170">
                                <p align="center" class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                                <p align="center" class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                                <p align="center" class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                        <asp:Label ID="lbXiaozhangYijian" runat="server"></asp:Label>
                                    </span>
                                </p>
                                <p align="center" class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p>&nbsp;</o:p>
                                    </span>
                                </p>
                            </td>
                            <td colspan="3" width="76">
                                <p align="center" class="MsoNormal">
                                    <span>资产</span><span lang="EN-US"><o:p></o:p></span>
                                </p>
                                <p align="center" class="MsoNormal">
                                    <span>保管人</span><span lang="EN-US"><o:p></o:p></span>
                                </p>
                                <p align="center" class="MsoNormal">
                                    <span>签名</span><span lang="EN-US"><o:p></o:p></span>
                                </p>
                            </td>
                            <td colspan="2" valign="top" width="83">
                                <p class="MsoNormal">
                                    <span lang="EN-US">
                                        <o:p></o:p>
                                    </span>
                                </p>
                            </td>
                        </tr>
                        <![if !supportMisalignedColumns]>
 <![endif]>
                    </table>
                    <p class="MsoNormal">
                        <span>注：</span><span lang="EN-US">1</span><span>、维修、购物申请必须由部门提出，部门在提交购物申请前必须核对库存情况。</span><span lang="EN-US"><o:p></o:p></span>
                    </p>
                    <p class="MsoNormal">
                        <span lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp; 2</span><span>、列入政府采购目录物品采购必须严格按规定操作；维修项目超规定额度的必须公开招标。</span><span lang="EN-US"><o:p></o:p></span>
                    </p>
                    <p class="MsoNormal">
                        <span lang="EN-US"><span>&nbsp;&nbsp;&nbsp; </span>3</span><span>、维修、采购要专人验收并签名；使用人须在“资产保管人”栏签名。</span><span lang="EN-US"><o:p></o:p></span>
                    </p>
                    <p class="MsoNormal">
                        <span lang="EN-US"><span>&nbsp;&nbsp;&nbsp; </span>4</span><span>、报销或支付时必须附本申请表。</span><span lang="EN-US"><o:p></o:p></span>
                    </p>
                    <p class="MsoNormal">
                        <span lang="EN-US">
                            <o:p>&nbsp;</o:p>
                        </span>
                    </p>
                    <p class="MsoListParagraph">
                        <span lang="EN-US">
                            <o:p>&nbsp;</o:p>
                        </span>
                    </p>
                    <p class="MsoNormal">
                        <span lang="EN-US">
                            <o:p>&nbsp;</o:p>
                        </span>
                    </p>



                    <!-- BEGIN PAGE -->

                    <!-- END PAGE -->
                </div>

            </div>

        </div>
        <!--endprint-->
        <!-- END CONTAINER -->

        <!-- BEGIN FOOTER -->

        <div class="footer">

            <div class="footer-inner">
            </div>

            <div class="footer-tools">

                <span class="go-top">

                    <i class="icon-angle-up"></i>

                </span>

            </div>


        </div>
    </form>
</body>
</html>
