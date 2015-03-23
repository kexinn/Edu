<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Infomation.aspx.cs" Inherits="web.Application.Infomation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link href="/media/css/style.css" rel="stylesheet" type="text/css" />
<script language="JavaScript" src="/media/js/jquery.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">信息填报</a></li>
            </ul>
        </div>

        <div class="rightinfo">
            <asp:Label CssClass="inline" ID="lbName" runat="server" Font-Bold="True"></asp:Label>
        您的入校年月是：<asp:Label CssClass="inline"  ID="lbNianyue" runat="server" Font-Bold="True"></asp:Label>
        <br />
        请输入您的入校年月:<asp:TextBox ID="tbBianhao" runat="server" CssClass="dfinput" Width="200px"></asp:TextBox>
    
            &nbsp;（例如2015年1月入校，则填写201501)<br />
        <br />
        <asp:LinkButton ID="lbSave" runat="server" OnClick="lbSave_Click" ><i class="mbtn"><img src="../media/images/t02.png" />保存</i></asp:LinkButton>
    &nbsp;</div>
    </div>
    </form>
</body>
</html>
