<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainRight.aspx.cs" Inherits="web.MainRight" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="media/js/jquery.js"></script>
    <script type="text/javascript" src="media/js/format+zh_CN,default,corechart.I.js"></script>
    <script type="text/javascript" src="media/js/jquery.ba-resize.min.js"></script>

</head>

<body>
    <form id="form1" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">工作台</a></li>
            </ul>
        </div>

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <div class="mainbox">

            <div class="mainleft">





                <div class="leftinfos">


                    <div class="infoleft">

                        <div class="listtitle"><a href="#" class="more1">更多</a>待办事项</div>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                            <ContentTemplate>
                                <asp:Timer runat="server" Interval="30000" OnTick="Unnamed_Tick">
                                </asp:Timer>
                                <ul class="newlist">
                                    <asp:Repeater ID="RepeaterTask" runat="server">
                                        <ItemTemplate>
                                            <li><a href="/Application/RoutTask.aspx?taskid=<%# Eval("Id")%>"><%# Eval("description")%></a><b><%# Eval("createtime")%></b></li>

                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </div>


                    <div class="inforight">
                        <div class="listtitle"><a href="#" class="more1"></a>考勤打卡</div>
                        <table class="tablecard">

                            <thead>

                                <tr>


                                    <th width="120px">考勤内容</th>

                                    <th width="120px">考勤时间</th>

                                    <th width="190px">考勤状态</th>

                                </tr>

                            </thead>

                            <tbody>

                                <tr>


                                    <td>上班考勤</td>

                                    <td>
                                        <asp:Label ID="lbClockOnTime" runat="server" ForeColor="Red"></asp:Label></td>

                                    <td>
                                        <asp:Label ID="lbClockOnState" CssClass="inline" runat="server"></asp:Label><asp:Image CssClass="inline" ID="imgClockOn" runat="server" Height="25px" />
                                    </td>

                                </tr>

                                <tr>

                                    <td>下班考勤</td>

                                    <td>
                                        <asp:Label ID="lbClockOffTime" runat="server" ForeColor="Red"></asp:Label></td>

                                    <td>
                                        <asp:Label ID="lbClockOffState" CssClass="inline" runat="server"></asp:Label><asp:Image CssClass="inline" ID="imgClokOff" runat="server" Height="25px" /></td>

                                </tr>



                                <tr>



                                    <td>


                                        <asp:LinkButton ID="lbClockOn" runat="server"
                                            OnClick="lbClockOn_Click" Style="margin-left: 5px; display: block;"><i class="mbtn"><img src="media/images/leftico04.png" />上班打卡</i></asp:LinkButton>

                                    </td>

                                    <td>
                                        <asp:LinkButton ID="lbClockOff" runat="server"
                                            OnClick="lbClockOff_Click"><i class="mbtn"><img src="media/images/leftico04.png" />下班打卡</i></asp:LinkButton>

                                    </td>
                                    <td>


                                        <img src="media/images/help.png" /><strong>打卡说明：</strong>上班下班每天只能打一次卡，同一电脑只能打一次卡。<br />
                                        <asp:Label ID="lbPunchCardMessage" runat="server" ForeColor="Red"></asp:Label>
                                        &nbsp;</td>

                                </tr>

                            </tbody>

                        </table>


                    </div>


                </div>
                <div class="leftinfo">
                    <div class="listtitle"><a href="#" class="more1">更多</a>宁波天气</div>

                    <div>
                        <asp:Label ID="lbWeatherMessage" runat="server"></asp:Label>
                    </div>
                    <div id="weatherDiv" runat="server">

                    </div>
                    
                </div>
                <!--leftinfo end-->

            </div>
            <!--mainleft end-->


            <div class="mainright">





                <div class="dflist1">
                    <div class="listtitle"><a href="/Application/WorkPlan/WorkPlanRight.aspx" class="more1">更多</a>本月学校工作</div>
                    <ul class="newlist">
                        <asp:Repeater ID="RepeaterPlan" runat="server">
                            <ItemTemplate>
                        <li><i><%# formatContentLen( Eval("content").ToString())%></i><%# Eval("deptName")%></li>
                                </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>



            </div>
            <!--mainright end-->


        </div>
    </form>
</body>
<script type="text/javascript">
    setWidth();
    $(window).resize(function () {
        setWidth();
    });
    function setWidth() {
        var width = ($('.leftinfos').width() - 12) / 2;
        $('.infoleft,.inforight').width(width);
    }
</script>
</html>
