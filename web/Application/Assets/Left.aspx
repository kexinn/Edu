<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="web.Application.Assets.Left" %>

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
    <div class="lefttop"><span></span>资产管理2</div>
    
    <dl class="leftmenu">
        
    <dd>
    <div class="title">
    <span><img src="/media/images/leftico01.png" /></span>基础数据
    </div>
    	<ul class="menuson">
        <li ><cite></cite><a href="/Application/GZL/CG/PurchaseApply.aspx" target="rightFrame">仓库地点</a><i></i></li>
        <li ><cite></cite><a href="/Application/GZL/CG/ApplyApprove.aspx" target="rightFrame">我的审批</a><i></i></li>
        <li><cite></cite><a href="/Application/GZL/CG/PurchaseStatisc.aspx" target="rightFrame">查询统计</a><i></i></li>
        </ul>    
    </dd>

    <dd>
    <div class="title">
    <span><img src="/media/images/leftico01.png" /></span>入库管理
    </div>
    	<ul class="menuson">
        <li ><cite></cite><a href="/Application/GZL/CG/PurchaseApply.aspx" target="rightFrame">仓库地点</a><i></i></li>
        <li ><cite></cite><a href="/Application/GZL/CG/ApplyApprove.aspx" target="rightFrame">我的审批</a><i></i></li>
        <li><cite></cite><a href="/Application/GZL/CG/PurchaseStatisc.aspx" target="rightFrame">查询统计</a><i></i></li>
        </ul>    
    </dd>        

    <dd>
    <div class="title">
    <span><img src="/media/images/leftico01.png" /></span>流通管理
    </div>
    	<ul class="menuson">
        <li ><cite></cite><a href="/Application/GZL/CG/PurchaseApply.aspx" target="rightFrame">仓库地点</a><i></i></li>
        <li ><cite></cite><a href="/Application/GZL/CG/ApplyApprove.aspx" target="rightFrame">我的审批</a><i></i></li>
        <li><cite></cite><a href="/Application/GZL/CG/PurchaseStatisc.aspx" target="rightFrame">查询统计</a><i></i></li>
        </ul>    
    </dd>        
  
      
    <dd>
    <div class="title">
    <span><img src="/media/images/leftico01.png" /></span>查询统计
    </div>
    	<ul class="menuson">
        <li ><cite></cite><a href="/Application/GZL/CG/PurchaseApply.aspx" target="rightFrame">仓库地点</a><i></i></li>
        <li ><cite></cite><a href="/Application/GZL/CG/ApplyApprove.aspx" target="rightFrame">我的审批</a><i></i></li>
        <li><cite></cite><a href="/Application/GZL/CG/PurchaseStatisc.aspx" target="rightFrame">查询统计</a><i></i></li>
        </ul>    
    </dd>        

     <dd>
    <div class="title">
    <span><img src="/media/images/leftico01.png" /></span>条码管理
    </div>
    	<ul class="menuson">
        <li ><cite></cite><a href="/Application/GZL/CG/PurchaseApply.aspx" target="rightFrame">仓库地点</a><i></i></li>
        <li ><cite></cite><a href="/Application/GZL/CG/ApplyApprove.aspx" target="rightFrame">我的审批</a><i></i></li>
        <li><cite></cite><a href="/Application/GZL/CG/PurchaseStatisc.aspx" target="rightFrame">查询统计</a><i></i></li>
        </ul>    
    </dd>   
                      
   <%-- <dd>
    <div class="title">
    <span><img src="/media/images/leftico02.png" /></span>请假申请
    </div>
    <ul class="menuson">
        <li><cite></cite><a href="#" target="rightFrame">添加请假</a><i></i></li>
        <li><cite></cite><a href="#" target="rightFrame">请假审批</a><i></i></li>
        <li><cite></cite><a href="#" target="rightFrame">请假统计</a><i></i></li>
        </ul>     
    </dd> --%>
    
<%--        <asp:Panel ID="PanelGZLSetting" runat="server">
    <dd><div class="title"><span><img src="/media/images/leftico03.png" /></span>流程设置</div>
    <ul class="menuson">
        <li><cite></cite><a href="#">表单设计</a><i></i></li>
        <li><cite></cite><a href="/Application/GZL/Setting/RoutSetting.aspx" target="rightFrame">流程设计</a><i></i></li>
    </ul>    
    </dd>  
    </asp:Panel>--%>

    
    </dl>
    </form>
</body>
</html>