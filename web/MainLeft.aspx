<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainLeft.aspx.cs" Inherits="web.MainLeft" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="/media/css/style.css" rel="stylesheet" type="text/css" />
<script language="JavaScript" src="/media/js/jquery.js"></script>

<script type="text/javascript">
$(function(){	
	//导航切换
	$(".menuson li").click(function(){
		$(".menuson li.active").removeClass("active")
		$(this).addClass("active");
	});
	
	$('.title').click(function(){
		var $ul = $(this).next('ul');
		$('dd').find('ul').slideUp();
		if($ul.is(':visible')){
			$(this).next('ul').slideUp();
		}else{
			$(this).next('ul').slideDown();
		}
	});
})	
</script>

</head>
<body style="background:#f0f9fd;">
    <form id="form1" runat="server">
    <div class="lefttop"><span></span>系统主页</div>
    
    <dl class="leftmenu">
        
    <dd>
    <div class="title">
    <span><img src="/media/images/leftico01.png" /></span>考勤管理
    </div>
    	<ul class="menuson">
        <li ><cite></cite><a href="/Application/KQ/MyKQList.aspx" target="rightFrame">我的打卡</a><i></i></li>
            <asp:Panel ID="PanelKQ" runat="server">
        <li ><cite></cite><a href="/Application/KQ/QueryKQList.aspx" target="rightFrame">打卡查询</a><i></i></li>
        <li ><cite></cite><a href="/Application/KQ/HandPunch.aspx" target="rightFrame">手工打卡</a><i></i></li>
        <li ><cite></cite><a href="/Application/KQ/DayStatisticKQ.aspx" target="rightFrame">考勤统计</a><i></i></li>
<%--        <li><cite></cite><a href="/Application/KQ/StatisticKQList.aspx" target="rightFrame">考勤统计</a><i></i></li>--%>
                </asp:Panel>
        </ul>    
    </dd>
        
   <%-- 
    <dd>
    <div class="title">
    <span><img src="/media/images/leftico02.png" /></span>其他设置
    </div>
    <ul class="menuson">
        <li><cite></cite><a href="#">编辑内容</a><i></i></li>
        <li><cite></cite><a href="#">发布信息</a><i></i></li>
        <li><cite></cite><a href="#">档案列表显示</a><i></i></li>
        </ul>     
    </dd> 
    
    
    <dd><div class="title"><span><img src="/media/images/leftico03.png" /></span>编辑器</div>
    <ul class="menuson">
        <li><cite></cite><a href="#">自定义</a><i></i></li>
        <li><cite></cite><a href="#">常用资料</a><i></i></li>
        <li><cite></cite><a href="#">信息列表</a><i></i></li>
        <li><cite></cite><a href="#">其他</a><i></i></li>
    </ul>    
    </dd>  
    
    
    <dd><div class="title"><span><img src="/media/images/leftico04.png" /></span>日期管理</div>
    <ul class="menuson">
        <li><cite></cite><a href="#">自定义</a><i></i></li>
        <li><cite></cite><a href="#">常用资料</a><i></i></li>
        <li><cite></cite><a href="#">信息列表</a><i></i></li>
        <li><cite></cite><a href="#">其他</a><i></i></li>
    </ul>
    
    </dd>   --%>
    
    </dl>
    </form>
</body>
</html>
