<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoleMenus.aspx.cs" Inherits="web.admin.Menu.RoleMenus" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>

    <script type="text/javascript">
       
        function check() {
            return confirm("确定导入？");
        }
    </script>


</head>


<body>
    <form id="form1" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">系统管理</a></li>
                <li><a href="#">菜单角色</a></li>
            </ul>
        </div>

        <div class="rightinfo">

            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <asp:GridView ID="gvMenu" runat="server" AutoGenerateColumns="False"
                DataKeyNames="menuId"  Width="100%"
                CssClass="tablelist" >
                <Columns>
                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate>
                            <asp:Label ID="lbKey" runat="server" Text='<%# Eval("menuId") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="菜单名称">
                        <ItemTemplate>
                             <asp:HyperLink ID="hlMenuName" OnDataBinding="hlMenuName_DataBinding" ForeColor="Blue" runat="server"><%# Eval("name") %></asp:HyperLink>
                        </ItemTemplate>
                        <ItemStyle Width="220px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="菜单地址" ItemStyle-CssClass="textleft">
                        <ItemTemplate>
                            <asp:Label ID="lbUrl" runat="server"><%# Eval("url")%></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="是否启用">
                        <ItemTemplate>
                            <asp:Image ID="imgStatus" OnDataBinding="imgStatus_DataBinding" runat="server" />
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="授权">
                        
                        <ItemTemplate>
                            <asp:CheckBox ID="cbAuth" runat="server" OnCheckedChanged="cbAuth_CheckedChanged"  Checked='<%# Eval("auth")%>' AutoPostBack="True" />
                        </ItemTemplate>
                        <ItemStyle Width="120px" />
                    </asp:TemplateField>
                </Columns>
                <RowStyle HorizontalAlign="Center" />
            </asp:GridView>


        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>

</html>

