<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="member_left.aspx.cs" Inherits="web.admin.TeacherGroup.member_left" %>

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
    <form id="form1" runat="server">
    <div>
    <table width="100%" align=center border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="8px" height="8px"></td>
<td></td>
</tr>
<tr>
<td height="22px"></td>
<td background="../images/smallbg.jpg">&nbsp;<b>教研组</b></td>
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
        ExpandDepth="2" 
        OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
    </asp:TreeView>
  </td>
</tr>
</table>
    </div>
    </form>
</body>
</html>
