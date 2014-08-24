<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkPlanLeft.aspx.cs" Inherits="web.Application.WorkPlan.WorkPlanLeft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script language="JavaScript" src="/media/js/jquery.js"></script>

    <script type="text/javascript">
        $(function () {
            //导航切换
            $(".menuson li").click(function () {
                $(".menuson li.active").removeClass("active")
                $(this).addClass("active");
            });

            $('.title').click(function () {
                var $ul = $(this).next('ul');
                $('dd').find('ul').slideUp();
                if ($ul.is(':visible')) {
                    $(this).next('ul').slideUp();
                } else {
                    $(this).next('ul').slideDown();
                }
            });
        })
    </script>

</head>
<body style="background: #f0f9fd;">
    <form id="form1" runat="server">
        <div class="lefttop"><span></span>工作任务</div>

        <dl class="leftmenu">

            <dd>
                <div class="title">
                    <span>
                        <img src="/media/images/leftico01.png" /></span>学期行事历表
                </div>
                <ul class="menuson">
                    <li><cite></cite><a href="/Application/WorkPlan/LookByMonth.aspx" target="rightFrame">按月查看</a><i></i></li>
                    <li><cite></cite><a href="/Application/WorkPlan/AssignTask.aspx" target="rightFrame">任务管理</a><i></i></li>
                </ul>
            </dd>

            <dd>
                <div class="title">
                    <span>
                        <img src="/media/images/leftico02.png" /></span>部门工作计划
                </div>
                <ul class="menuson">
                    <li><cite></cite><a href="/Application/WorkPlan/WeekPlan.aspx" target="rightFrame">本周计划</a><i></i></li>
                    <li><cite></cite><a href="/Application/WorkPlan/PreWeekPlanEvalution.aspx" target="rightFrame">上周评价</a><i></i></li>
                    <li><cite></cite><a href="/Application/WorkPlan/WorkPlanHistory.aspx" target="rightFrame">历史查询</a><i></i></li>
                </ul>
            </dd>
        </dl>
    </form>
</body>
</html>
