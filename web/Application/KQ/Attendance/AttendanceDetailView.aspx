<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttendanceDetailView.aspx.cs" Inherits="web.Application.KQ.Attendance.AttendanceDetailView" %>

<!DOCTYPE html>


<style type="text/css">
    .auto-style1 {
        height: 79px;
    }
    .auto-style3 {
        height: 26px;
    }
    .auto-style4 {
        height: 31px;
    }
    .auto-style5 {
        height: 39px;
    }
    .auto-style6 {
        height: 26px;
        width: 118px;
    }
    .auto-style7 {
        height: 31px;
        width: 118px;
    }
    .auto-style8 {
        height: 39px;
        width: 118px;
    }
    .auto-style9 {
        height: 79px;
        width: 118px;
    }
    .auto-style10 {
        height: 51px;
        width: 118px;
    }
    .auto-style11 {
        height: 51px;
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
                                  <h1 align="center"><b><font size="24">请假单</font></b></h1><br />
                <table class="tableborder" style="width:90%;">
                    <tr>
                        <td class="auto-style6">姓名</td>
                        <td class="auto-style3"><span >
                            <asp:Label ID="lbUsername" runat="server"></asp:Label>
                            </span></td>
                        <td class="auto-style3">部门</td>
                        <td class="auto-style3">
                            <asp:Label ID="lbDept" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style7">申请时间</td>
                        <td class="auto-style4"><span lang="EN-US">
                            <asp:Label ID="lbApplyTime" runat="server"></asp:Label>
                            </span></td>
                        <td class="auto-style4">请假类型</td>
                        <td class="auto-style4">
                            <asp:Label ID="lbType" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8">请假时间</td>
                        <td colspan="3" class="auto-style5"><span>自：<asp:Label ID="lbStartTime" runat="server"></asp:Label>
                            <span >至：<asp:Label ID="lbEndtime" runat="server"></asp:Label>
                            </span></span></td>
                    </tr>
                    <tr>
                        <td class="auto-style9">请假事由</td>
                        <td colspan="3" class="auto-style1">
                            <asp:Label ID="lbReason" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">审批人签字</td>
                        <td colspan="3" class="auto-style11">
                            </td>
                    </tr>
                </table>
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