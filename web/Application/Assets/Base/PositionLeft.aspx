<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PositionLeft.aspx.cs" Inherits="web.Application.Assets.Base.PositionLeft" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <style>
        

a:link{color:green;} 

a:active{color:red;} 



 
a:hover{color:blue;} 

 

    </style>
</head>
<body>
    <form id="form2" runat="server">        
        <div class="place">
            <span>地点管理</span>
        </div>
    <div>
    <table width="100%" align=center border="0" cellpadding="0" cellspacing="0">
<tr>
<td width="8px" height="8px"></td>
<td></td>
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
