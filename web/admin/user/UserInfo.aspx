<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="web.admin.user.UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link href="/media/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <div class="place">
    <span>位置：</span>
    <ul class="placeul">
    <li><a href="#">首页</a></li>
    <li><a href="#">用户信息</a></li>
    </ul>
    </div>
    
    <div class="formbody">
    
    <div class="formtitle"><span>基本信息</span></div>
        <asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>
    <div style="width:45%;float:left;">
    <ul class="forminfo">
    <li><label>姓&nbsp;&nbsp;&nbsp; 名：</label><asp:TextBox ID="tbUsername" runat="server" CssClass="dfinput"></asp:TextBox></li>
    <li><label>NETID：</label><asp:TextBox ID="tbNetId" runat="server" CssClass="dfinput"></asp:TextBox></li>
    <li><label>所属部门：</label><asp:DropDownList ID="ddlDept" runat="server" CssClass="dfinput"></asp:DropDownList></li>
    <li><label>启用状态：</label>启用 <asp:RadioButton ID="rbYes" runat="server"  GroupName="isenabled" />禁用：<asp:RadioButton ID="rbNo" runat="server"  GroupName="isenabled" /></li>
    <li><label>手机短号：</label><asp:TextBox ID="tbDuanhao" runat="server" CssClass="dfinput"></asp:TextBox></li>
    <li><label>手机长号：</label><asp:TextBox ID="tbChanghao" runat="server" CssClass="dfinput"></asp:TextBox></li>
  
    <li><label>&nbsp;</label><asp:LinkButton ID="lbSave" runat="server" OnClick="lbSave_Click"><i class="mbtn"><img src="/media/images/d02.png" />保存</i></asp:LinkButton></li>
    </ul>
    </div>
        <div style="width:45%;float:left;">
     <ul class="forminfo">
    <li><label>工&nbsp;&nbsp;&nbsp; 号：</label><asp:TextBox ID="tbJobNumber" runat="server" CssClass="dfinput"></asp:TextBox></li>
    <li><label>邮&nbsp;&nbsp;&nbsp; 箱：</label><asp:TextBox ID="tbEmail" runat="server" CssClass="dfinput"></asp:TextBox></li>
    <li><label>用户类型：</label><asp:DropDownList ID="ddlType" runat="server" CssClass="dfinput">
        <asp:ListItem Value="1">在编</asp:ListItem>
        <asp:ListItem Value="2">外聘</asp:ListItem>
        <asp:ListItem Value="3">其他</asp:ListItem>
        </asp:DropDownList></li>
    <li><label>openId：</label><asp:TextBox ID="openid" runat="server" CssClass="dfinput"></asp:TextBox></li>
    <li><label>系统排序：</label><asp:TextBox ID="tbOrder" runat="server" CssClass="dfinput"></asp:TextBox></li>
          <li><label>教研组：</label><asp:DropDownList ID="ddlJyz" runat="server" CssClass="dfinput"></asp:DropDownList></li>
    </ul>

        </div>
    </div>

    </form>
</body>
</html>
