<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test-listview.aspx.cs" Inherits="web.Application.Assets.Test.test_listview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ListTemplat</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:ListView ID="lv" runat="server" ItemPlaceholderID="holder">
            <LayoutTemplate>
                <p>1234</p>
                <p runat ="server" id="holder"></p>
                <p>5678</p>
            </LayoutTemplate>

            <ItemTemplate>
                <p><%#Eval("CkID") %><%#Eval("CkName") %></p>
            </ItemTemplate>
        </asp:ListView>
        

    </div>
    </form>
</body>
</html>
