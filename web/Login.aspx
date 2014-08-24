<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>欢迎登录后台管理系统</title>
<link href="media/css/style.css" rel="stylesheet" type="text/css" />
<script language="JavaScript" src="media/js/jquery.js"></script>
<script src="media/js/cloud.js" type="text/javascript"></script>

<script language="javascript">
	$(function(){
    $('.loginbox').css({'position':'absolute','left':($(window).width()-692)/2});
	$(window).resize(function(){  
    $('.loginbox').css({'position':'absolute','left':($(window).width()-692)/2});
    })  
});  
</script> 

</head>
<body style="background-color:#1c77ac; background-image:url(media/images/light.png); background-repeat:no-repeat; background-position:center top; overflow:hidden;">
    <form id="form1" runat="server">
    <div>
    <div id="mainBody">
      <div id="cloud1" class="cloud"></div>
      <div id="cloud2" class="cloud"></div>
    </div>  
        
<div class="logintop">    
    <span>欢迎登录日常管理平台</span>    
    <ul>
    <li><a href="#">回首页</a></li>
    <li><a href="#">帮助</a></li>
    <li><a href="#">关于</a></li>
    </ul>    
    </div>
    
    <div class="loginbody">
    
    <span class="systemlogo"></span> 
       
    <div class="loginbox">
    
    <ul>
    <li>
        <asp:TextBox ID="usernetid" CssClass="loginuser" runat="server"></asp:TextBox></li>
    <li>
        <asp:TextBox ID="pwd" CssClass="loginpwd" runat="server" TextMode="Password"></asp:TextBox></li>
    <li>
        <asp:Button ID="btLogin" CssClass="loginbtn"  runat="server" Text="登陆" OnClick="btLogin_Click" /><asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label></li>
    </ul>
    
    
    </div>
    
    </div>
    
    
    
    <div class="loginbm">版权所有  2014  <a href="http://www.nbyzzj.cn">nbyzzj</a>  仅供学习交流</div>
	
    
    </div>
    </form>
</body>
</html>
