<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseForm.aspx.cs" Inherits="web.Application.GZL.CG.PurchaseForm" %>


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

</head>
<body>


    <form id="form1" runat="server" >
        <div>
        <!-- BEGIN HEADER -->
            <div class="logintop">    
    <span>欢迎登录日常管理平台</span>    
    <ul>
    <li><asp:LinkButton ID="lbSongShen" runat="server" OnClick="lbSongShen_Click">送审</asp:LinkButton></li>
  
    </ul>    
    </div>

            
            <div class="fixhead"></div>

        <div  style="margin: 0 auto; width: 720px;">
            <asp:Panel ID="PanelSongShen" runat="server">
            <div >


                <h3>部门领导审批</h3>

            </div>

            <div >
                        <div>选择部门审批领导：</div>
                <div class="pullleft">
                        <asp:ListBox ID="listBoxLeader" runat="server" Height="177px" Width="521px" CssClass="dfinput"></asp:ListBox>
                    </div>
                <div class="clear" style="margin-bottom:10px;"></div>
                <asp:LinkButton ID="lbSure" runat="server" OnClick="lbSure_Click"><i class="ibtn">确认提交</i></asp:LinkButton>
                       

                        <p>
                            <asp:Label ID="lbModalMessage" runat="server" ForeColor="Red"></asp:Label>

                        </p>

            </div>
</asp:Panel>
        </div>
        <!-- END SAMPLE PORTLET CONFIGURATION MODAL FORM-->
            <asp:Panel ID="PanelForm" runat="server">
        <div >
            
            <div style="margin: 0 auto; width: 720px;">

                <p class="MsoNormal">
                    <span>附件</span><span lang="EN-US">2<o:p></o:p></span>
                </p>
                <p align="center" class="MsoNormal" style="margin: 0 auto; width: 280px;">
                    <b><span>鄞州职教中心购物、维修申请单</span><span lang="EN-US"><o:p></o:p></span></b>
                </p>
                <p class="MsoNormal">
                    <span lang="EN-US">
                        <o:p>&nbsp;</o:p>
                        <asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>
                    </span>
                </p>
                <p class="MsoNormal">
                    <span class="inline">申请部门：</span>&nbsp;<asp:Label ID="lbDept" CssClass="inline" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;申购人：<asp:Label ID="lbUserName"  CssClass="inline" runat="server"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="inline">申购日期：</span>&nbsp;&nbsp;<asp:Label ID="lbYear" CssClass="inline" runat="server"></asp:Label>
                            &nbsp; <span class="inline">年</span>&nbsp;<asp:Label ID="lbMonth" CssClass="inline" runat="server"></asp:Label>
                                &nbsp; <span class="inline">月</span>&nbsp;&nbsp;<asp:Label ID="lbDay" CssClass="inline" runat="server"></asp:Label>
                                    &nbsp;<span  class="inline">日</span><o:p></o:p>
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
                                <span>采购量</span></p>
                        </td>
                        <td width="57">
                            <p align="center" class="MsoNormal">
                                <span>金额</span><span lang="EN-US"><o:p></o:p></span>
                            </p>
                        </td>
                        <td colspan="2" width="57">
                            <p align="center" class="MsoNormal">
                                备注
                            </p>
                        </td>
                        <td width="45">
                            <p align="center" class="MsoNormal">
                                <span lang="EN-US">
                                    <o:p>操作</o:p>
                                </span>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td width="36">
                            <p class="MsoNormal">
                                <span lang="EN-US">
                                    <asp:TextBox ID="tbSortNo" runat="server" Width="25px" ValidationGroup="caigou" CssClass="dfinput"></asp:TextBox>
                                </span>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbSortNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="caigou" CssClass="inline"></asp:RequiredFieldValidator>
                            </p>
                        </td>
                        <td colspan="2" width="189">
                            <p class="MsoNormal">
                                <span lang="EN-US">
                                    <o:p>&nbsp;<asp:TextBox ID="tbZCName" runat="server" Width="140px" ValidationGroup="caigou" CssClass="dfinput"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbZCName" ErrorMessage="*" ForeColor="Red" ValidationGroup="caigou" CssClass="inline"></asp:RequiredFieldValidator>
                        </o:p>
                                </span>
                            </p>
                        </td>
                        <td colspan="2" width="113">
                            <p class="MsoNormal">
                                <span lang="EN-US">
                                    <o:p>&nbsp;<asp:TextBox ID="tbType" runat="server" Width="90px" ValidationGroup="caigou" CssClass="dfinput"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbType" ErrorMessage="*" ForeColor="Red" ValidationGroup="caigou" CssClass="inline"></asp:RequiredFieldValidator>
                        </o:p>
                                </span>
                            </p>
                        </td>
                        <td class="auto-style1">
                            <p class="MsoNormal">
                                <span lang="EN-US">
                                    <o:p>&nbsp;<asp:TextBox ID="tbNeedAmont" runat="server" Width="30px" ValidationGroup="caigou" CssClass="dfinput"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbNeedAmont" ErrorMessage="*" ForeColor="Red" ValidationGroup="caigou" CssClass="inline"></asp:RequiredFieldValidator>
                        </o:p>
                                </span>
                            </p>

                        </td>
                        <td width="57">
                            <p class="MsoNormal">
                                <span lang="EN-US">
                                    <o:p>&nbsp;<asp:TextBox ID="tbPrice" runat="server" Width="30px" ValidationGroup="caigou" CssClass="dfinput"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbPrice" ErrorMessage="*" ForeColor="Red" ValidationGroup="caigou" CssClass="inline"></asp:RequiredFieldValidator>
                        </o:p>
                                </span>
                            </p>
                        </td>
                        <td width="57">&nbsp;</td>
                        <td width="57">
                            <p class="MsoNormal">
                                <span lang="EN-US">
                                    <o:p>&nbsp;</o:p>
                                </span>
                            </p>
                        </td>
                        <td colspan="2" width="57">
                            <p class="MsoNormal">
                                <span lang="EN-US">
                                    <o:p>&nbsp;<asp:TextBox ID="tbMemo" runat="server" Width="28px" ValidationGroup="caigou" CssClass="dfinput"></asp:TextBox>
                        </o:p>
                                </span>
                            </p>
                        </td>
                        <td width="45">
                            <p class="MsoNormal">
                                <span lang="EN-US">
                                    <asp:LinkButton ID="lbAdd" OnClick="lbAdd_Click" runat="server" ValidationGroup="caigou"><i class="mbtn"><img width="20px" src="/media/images/t01.png" /></i></asp:LinkButton>
                                </span>
                            </p>
                        </td>
                    </tr>
                    <asp:Repeater ID="RepeaterItem" runat="server" OnItemCommand="RepeaterItem_ItemCommand">
                        
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
                                <td valign="top" width="57">
                                    <p class="MsoNormal">
                                        <span lang="EN-US">
                                            <o:p><%# Eval("totalPrice")%></o:p>
                                        </span>
                                    </p>
                                </td>
                                <td colspan="2" valign="top" width="57">
                                    <p class="MsoNormal">
                                        <span lang="EN-US">
                                            <o:p><%# Eval("memo")%></o:p>
                                        </span>
                                    </p>
                                </td>
                                <td valign="top" width="45">
                                    <p class="MsoNormal">
                                        <span lang="EN-US">
                                            <o:p><asp:LinkButton ID="lbDelete" runat="server" CommandName="del" CommandArgument='<%# Eval("Id")%>'><i class="mbtn"><img src="/media/images/t03.png" width="20px" /></i></asp:LinkButton></o:p>
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
                        <td valign="top" width="57">&nbsp;</td>
                        <td valign="top" width="57">
                            <p class="MsoNormal">
                                <span lang="EN-US">
                                    <o:p>&nbsp;</o:p>
                                </span>
                            </p>
                        </td>
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
                        <td valign="top" width="57">&nbsp;</td>
                        <td valign="top" width="57">
                            <p class="MsoNormal">
                                <span lang="EN-US">
                                    <o:p>&nbsp;</o:p>
                                </span>
                            </p>
                        </td>
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
                                </span>
                                <asp:LinkButton ID="lbSave" OnClick="lbSave_Click" runat="server"><i class="mbtn"><img src="/media/images/ico04.png" width="20px" />保存</i></asp:LinkButton>
                                <asp:Label ID="lbResMessage" runat="server" ForeColor="Red" ></asp:Label>
                            </p>
                            <asp:TextBox ID="tbReason" runat="server" Height="90px" TextMode="MultiLine" Width="627px" CssClass="dfinput"></asp:TextBox>
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
                        <td colspan="4" width="170">
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
                                </span>
                            </p>
                            <p align="center" class="MsoNormal">
                                <span lang="EN-US">
                                    <o:p>&nbsp;</o:p>
                                </span>
                            </p>
                        </td>
                        <td colspan="2" width="76">
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
                    <span >注：</span><span lang="EN-US">1</span><span >、维修、购物申请必须由部门提出，部门在提交购物申请前必须核对库存情况。</span><span lang="EN-US"><o:p></o:p></span>
                </p>
                <p class="MsoNormal">
                    <span  lang="EN-US">&nbsp;&nbsp;&nbsp;&nbsp; 2</span><span >、列入政府采购目录物品采购必须严格按规定操作；维修项目超规定额度的必须公开招标。</span><span lang="EN-US"><o:p></o:p></span>
                </p>
                <p class="MsoNormal">
                    <span lang="EN-US"><span>&nbsp;&nbsp;&nbsp; </span>3</span><span>、维修、采购要专人验收并签名；使用人须在“资产保管人”栏签名。</span><span  lang="EN-US"><o:p></o:p></span>
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


            </div>
        </div>
       </asp:Panel>

        </div>
    </form>
</body>
</html>
