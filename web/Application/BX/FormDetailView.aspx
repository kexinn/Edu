<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormDetailView.aspx.cs" Inherits="web.Application.BX.FormDetailView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/js/jquery.jqprint-0.3.js"></script>
        <script language="javascript" type="text/jscript">
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
    <style type="text/css" media="screen">
        *{
            font-size:12px;
        }
        #container{
            width:700px;
            padding:5px;
        }
        table{
            
            border-collapse:collapse;
        }
        .noborder{
            border:1px solid #000;
        }
        #itemtable{
            border:1px solid #000;
        }
        #itemtable td{
            
            border:1px solid #000;
        }
        h3{
            font-size:28px;
        }
        .underline
        {
            border-bottom:1px solid #000;
        }
        #linkprint{
            font-size:large;
        }
        .line2
        {
            width:30px;
        }
        .line3{
            width:50px;
        }
        .line4{
            width:60px;
        }
        .line5{
            width:120px;
        }
        .line6{
            width:130px;
        }
        #heji{
            height:25px;
            padding-left:5px;
            font-size:18px;
            vertical-align:central;
            
        }
        .mbtn{background:url(/media/images/ibtnbg.png) repeat-x bottom;border:solid 1px #bfcfe1; height:30px; line-height:30px; display:block; float:left; padding:0 15px; cursor:pointer;}
        .mbtn img{margin-top:5px; float:left; padding-right:7px;}
        .mbtn a{text-decoration:none;}
    </style>
</head>
<body>
    <form id="form1" runat="server">

<!--startprint-->
    <div>
        <div id="print">
       <style type="text/css" media="print">
        *{
            font-size:8pt;
        }
        #container{
            width:468pt;
        }
        table{
            
            border-collapse:collapse;
        }
        #itemtable{
            border:1px solid #000;
        }
        #itemtable td{
            
            border:1px solid #000;
        }
        h3{
            font-size:22pt;
        }
        .underline
        {
            border-bottom:1px solid #000;
        }
        .noborder{
            border:none;
        }
        .line2
        {
            width:18pt;
        }
        .line3{
            width:36pt;
        }
        .line4{
            width:40pt;
        }
        .line5{
            width:60pt;
        }
        
        .line6{
            width:65pt;
        }
        #heji{
            height:25pt;
            padding-left:10pt;
            font-size:20pt;
            vertical-align:central;
        }
        .noprint{
            display:none;
        }
    </style>
            <div id="container" class="noborder" style="margin:auto;">
                <h3 align="center">鄞州职教中心差旅费报销单</h3>
                <table style="width:70%;">
                    <tr>
                        <td class="line3">填报人:</td>
                        <td class="underline"><span >
                            <asp:Label ID="lbUsername" runat="server"></asp:Label>
                            </span></td>
                        <td class="line4">出差时间:</td>
                        <td class="underline"><span>
                            <asp:Label ID="lbStartDate" runat="server"></asp:Label>
                            </span></td>
                        <td  class="line2">到</td>
                        <td class="underline"><span>
                            <asp:Label ID="lbEndDate" runat="server"></asp:Label>
                            </span></td>
                    </tr>
                    
                </table>
                <br />
                <table >
                    <tr>
                        <td class="line4">出差事由:</td>
                        <td class="underline" width="266pt"><span>
                            <asp:Label ID="lbReason" runat="server"></asp:Label>
                            </span></td>
                        <td class="line3">目的地:</td>
                        <td class="underline"><span>
                            <asp:Label ID="lbPositionType" runat="server"></asp:Label>&nbsp;
                            </span></td>
                        <td class="underline"><span>
                            <asp:Label ID="lbPosition" runat="server"></asp:Label>
                            </span></td>
                    </tr>
                    
                </table>
                
                <br />
                报销类型：<span><asp:Label ID="lbType" runat="server"></asp:Label>
                </span>
                <br />
                <br />
                <asp:Panel ID="PanelPeople" runat="server" Visible="False">
                   
                    <table >
                    <tr>
                        <td class="line4">报销人数:</td>
                        <td class="underline"><span>
                            <asp:Label ID="lbPeopleNum" runat="server"></asp:Label>
                            人</span></td>
                        <td  class="line4">报销人员:</td>
                        <td class="underline"><span>
                            <asp:Label ID="lbPeoples" runat="server"></asp:Label>
                            </span></td>
                    </tr>
                </table>
                </asp:Panel>
                
                <br />
                <asp:Panel ID="PanelItems" runat="server">
                    <table id="itemtable" class="tableborder" align="center"; style="width:98%;text-align:center;">
                    <tr>
                        <td  class="line5">日期</td>
                        <td  class="line4">天数</td>
                        <td  class="line4">人数</td>
                        <td  class="line5">市内交通费</td>
                        <td class="line5">城间交通费</td>
                        <td  class="line5">接待单位是否安排用餐</td>
                        <td class="line5">伙食补助费</td>
                        <td class="line5">住宿费</td>
                        <td class="line5">合计</td>
                    </tr>
                     <asp:Repeater ID="RepeaterItem" runat="server">
                        
                        <ItemTemplate>
                             <tr>
                        <td >
                            <%# Convert.ToDateTime( Eval("Date")).ToString("yyyy-MM-dd")%>
                        </td>
                        <td ><%# Eval("Days")%>天</td>
                        <td ><%# Eval("PeoplesNum")%>人</td>
                        <td ><%# Eval("TrafficFee")%>元</td>
                        <td ><%# Eval("CityTrafficFee")%>元</td>
                        <td ><%# Eval("IsReception").ToString() == "True"?"是":"否" %></td>
                        <td ><%# Convert.ToDecimal( Eval("Allowance"))%>元</td>
                        <td ><%# Eval("AccommodationFee")%></td>
                        <td> <%#  Convert.ToDecimal( Eval("TrafficFee"))+ Convert.ToDecimal( Eval("CityTrafficFee"))+ Convert.ToDecimal( Eval("Allowance"))+ Convert.ToDecimal( Eval("AccommodationFee")) %>元</td>
                    </tr>
                        </ItemTemplate>
                    
                    </asp:Repeater>
                        
                    <tr>
                        <td >合计</td> 
                        <td ></td>
                        <td ></td>
                        <td >
                            <asp:Label ID="lbItemTracficFee" runat="server"></asp:Label></td>
                        <td >
                            <asp:Label ID="lbItemCityFee" runat="server"></asp:Label></td>
                        <td ></td>
                        <td >
                            <asp:Label ID="lbAllowance" runat="server"></asp:Label></td>
                        <td >
                            <asp:Label ID="lbAccodanceFee" runat="server"></asp:Label></td>
                        <td>
                            <asp:Label ID="lbHeji" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td >总计</td>
                        <td id="heji" colspan="8" style="text-align:left;"><span>
                            <asp:Label ID="lbTotMoney" runat="server"></asp:Label>
                            </span></td>
                    </tr>
                </table>
                </asp:Panel>
                
                <br />
                <br />
                <br />
                此单作报销凭证，并附外出审批单、上级部门通知。

                 
                <br />
                <br />
                <table   style="text-align:left;">
                    <tr>
                        <td  class="line4">填报日期：</td>
                        <td  class="line5 underline"><asp:Label ID="lbDate" runat="server"></asp:Label></td>
                        <td  class="line4">&nbsp;</td>
                    </tr>
                   </table>
                <br />
                <br />
                
                <table   style="text-align:left;">
                    <tr>
                        <td  class="line6">部分负责人签字：</td>
                        <td  class="line5 underline">&nbsp;</td>
                        <td  class="line5">主管校长签字：</td>
                        <td  class="line5 underline">&nbsp;</td>
                        <td  class="line5">财务校长签字：</asp:Label></td>
                        <td  class="line5 underline">&nbsp;</td>
                    </tr>
                   </table>
               
                <br />
               
                     <i class="mbtn noprint"><img src="/media/images/i01.png" width="20pt" /><a class="noprint" href="#" onclick="preview()">打印</a></i>
                <br />
                <br />
                <br />
                <span class="noprint" style="font-size:large;color:red; font-weight:bold;">
                *首次打印前，请先在浏览器的—>设置—>打印—>页面设置 ，对话框中，将页眉、页脚中所有选项设置为“空”。</span>
            </div>
            </div>
                <br />

    
    </div>
        
<!--endprint-->
    </form>
</body>
</html>
