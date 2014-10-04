<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigureLeft.aspx.cs" Inherits="web.admin.ConfigureLeft" %>

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
    <div class="lefttop"><span></span>通讯录</div>
    
    <dl class="leftmenu">
        
    <dd>
    <div class="title">
    <span><img src="/media/images/leftico01.png" /></span>用户管理
    </div>
    	<ul class="menuson">
        <li ><cite></cite><a href="/admin/user/UserManagement.aspx" target="rightFrame">账号管理</a><i></i></li>
        <li ><cite></cite><a href="/admin/user/DepartmentManagement.aspx" target="rightFrame">机构管理</a><i></i></li>
        <li><cite></cite><a href="/admin/user/RoleManagement.aspx" target="rightFrame">角色管理</a><i></i></li>
        </ul>    
    </dd>
        
    
    <dd>
    <div class="title">
    <span><img src="/media/images/leftico02.png" /></span>教研组管理
    </div>
    <ul class="menuson">
        <li><cite></cite><a href="/admin/TeacherGroup/TeacherGroupManagement.aspx" target="rightFrame">教研组管理</a><i></i></li>
        <li><cite></cite><a href="/admin/TeacherGroup/TeacherGroupMember.aspx"  target="rightFrame">教研组成员</a><i></i></li>
        </ul>     
    </dd> 
    
    
    <dd><div class="title"><span><img src="/media/images/leftico03.png" /></span>菜单管理</div>
    <ul class="menuson">
        <li><cite></cite><a href="/admin/Menu/MenuManagement.aspx" target="rightFrame">菜单管理</a><i></i></li>
    </ul>    
    </dd>  
    
    
<%--    <dd><div class="title"><span><img src="/media/images/leftico04.png" /></span>日期管理</div>
    <ul class="menuson">
        <li><cite></cite><a href="#">自定义</a><i></i></li>
        <li><cite></cite><a href="#">常用资料</a><i></i></li>
        <li><cite></cite><a href="#">信息列表</a><i></i></li>
        <li><cite></cite><a href="#">其他</a><i></i></li>
    </ul>
    
    </dd> --%>  
    
    </dl>
    </form>
</body>
</html>