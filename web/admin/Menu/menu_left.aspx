<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="menu_left.aspx.cs" Inherits="web.admin.Menu.menu_left" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        

a:link{color:green;} 

a:active{color:red;} 


a:visited{color:orange;} 

 
a:hover{color:blue;} 

 

    </style>
</head>
<body>
    <form id="form2" runat="server">
    <div>
    <table width="100%" align=center border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="8px" height="8px"></td>
<td></td>
</tr>
<tr>
<td height="22px"></td>
<td background="../images/smallbg.jpg">&nbsp;<b>菜单</b></td>
</tr>
<tr>
<td></td>
  <td valign="top">
    <asp:TreeView  ID="TreeView1" runat="server" 
        Font-Size="10pt" 
        BorderStyle="None" 
        ForeColor="Black" 
        NodeWrap="True" 
        ShowLines="True" 
        ExpandDepth="1" 
        OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
    </asp:TreeView>
  </td>
</tr>
</table>
    </div>
    </form>
</body>
</html>
