<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Class.aspx.cs" Inherits="web.Application.Assets.Base.Class" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>

  <frameset border="1" frameborder="yes" framespacing="0" cols="200,*">
    <frame src="ClassLeft.aspx" name="lframe" frameborder="yes" scrolling="auto" noresize>
    <frame src="ClassRight.aspx" name="rframe" frameborder="yes" scrolling="auto">
  </frameset>

<noframes>
  <body>
  <p><font color="red">抱歉！本系统使用了框架技术， 但您的浏览器不支持框架。  </font></p>
  </body>
</noframes>
</html>
