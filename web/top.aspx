<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="web.top" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>无标题文档</title>
<link href="media/css/style.css" rel="stylesheet" type="text/css" />
<script language="JavaScript" src="media/js/jquery.js"></script>
<script type="text/javascript">
$(function(){	
	//顶部导航切换
	$(".nav li a").click(function(){
		$(".nav li a.selected").removeClass("selected")
		$(this).addClass("selected");
	})	
})	
</script>

</head>
<body style="background:url(media/images/topbg.gif) repeat-x;">
    <form id="form1" runat="server">
    <div class="topleft">
    <a href="Default.aspx" target="_parent"><img src="media/images/logo.png" title="系统首页" /></a>
    </div>
        
    <ul class="nav">
    <li><a href="main.aspx" target="mainFrame" class="selected"><img src="media/images/icon01.png" title="工作台" /><h2>工作台</h2></a></li>
    <li><a href="/Application/GZL/GZLApply.aspx" target="mainFrame"><img src="media/images/icon02.png" title="工作申请" /><h2>工作申请</h2></a></li>
    <li><a href="/Application/WorkPlan/WorkPlan.aspx"  target="mainFrame"><img src="media/images/icon03.png" title="工作任务" /><h2>工作任务</h2></a></li>
    <li><a href="/Application/Assets/Default.aspx"  target="mainFrame"><img src="media/images/icon04.png" title="资产管理" /><h2>资产管理</h2></a></li>
  <%--  <li><a href="main.aspx" target="mainFrame"><img src="media/images/icon05.png" title="文件管理" /><h2>文件管理</h2></a></li> --%>
        <asp:Panel ID="PanelConfigure" runat="server">
    <li><a href="admin/Configure.aspx"  target="mainFrame"><img src="media/images/icon06.png" title="系统设置" /><h2>系统设置</h2></a></li>

        </asp:Panel>
    </ul>
            
    <div class="topright">    
    <ul>
    <li><span><img src="media/images/help.png" title="帮助"  class="helpimg"/></span><a href="#">帮助</a></li>
    <li><a href="#">关于</a></li>
    <li><asp:LinkButton ID="lbLogout" runat="server" OnClientClick="top.location.href= 'Login.aspx'" OnClick="lbLogout_Click">退出</asp:LinkButton></li>
    </ul>
     
    <div class="user">
    <span><%=Session["username"] %></span>
    <i>消息</i>
    <b id="bnum" runat="server">
        0</b>
    </div>    
    
    </div>
    </form>
</body>
</html>
