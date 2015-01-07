<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test_DDL.aspx.cs" Inherits="web.Application.Assets.Test.test_DDL" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        </asp:DropDownList>
    
        <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
            <asp:ListItem Value="a">111</asp:ListItem>
            <asp:ListItem Value="b">222</asp:ListItem>
            <asp:ListItem Value="c">333</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:TextBox ID="txt_1" runat="server" Height="108px" TextMode="MultiLine" Width="643px"></asp:TextBox>
        <br />
        <asp:Button ID="btn_Del" runat="server" OnClick="btn_Del_Click" Text="删除" />
        <asp:Button ID="btn_Add" runat="server" OnClick="btn_Add_Click" Text="新增" />
        <asp:Button ID="btn_Clear" runat="server" OnClick="btn_Clear_Click" Text="清除选择" />
        <asp:Button ID="btn_Clear_All" runat="server" OnClick="btn_Clear_All_Click" Text="清除项目" />
        <asp:Button ID="btn_Count" runat="server" OnClick="btn_Count_Click" Text="总数" />
        <asp:Button ID="btn_OK" runat="server" OnClick="btn_OK_Click" Text="确定" />
    </div>
    </form>
</body>
</html>
