<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PositionRight.aspx.cs" Inherits="web.Application.Assets.Base.PositionRight" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/js/myjs.js"></script>


</head>

<body>
    <form id="form1" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">资产管理</a></li>
                <li><a href="#">基础数据</a></li>
                <li><a href="#">地点管理</a></li>
            </ul>
        </div>

        <div class="rightinfo">

            <div class="tools">

                <ul class="toolbar">
                    <li><span>
                        <img src="/media/images/t01.png" /></span>
                        <asp:LinkButton ID="lbAdd" runat="server"
                            OnClick="lbAdd_Click">添加地点</asp:LinkButton></li> 
                    
                    <li><span>
                        <img src="/media/images/t03.png" /></span>
                        <asp:LinkButton ID="lbDelete" runat="server" OnClientClick="javascript:showConfirm('确定删除当前地点?')" OnClick="lbDelete_Click" >删除地点</asp:LinkButton></li> 
                    <li><span>
                        <img src="/media/images/ico04.png" /></span>
                        <asp:LinkButton ID="lbSave" runat="server" OnClick="lbSave_Click" ValidationGroup="menu" >保存地点</asp:LinkButton></li> 
                </ul>

            <div style="float:left">
                <asp:Label ID="lbMode" runat="server" Font-Bold="False" Font-Size="Large" ForeColor="Blue"></asp:Label>
                </div>
            </div>
            <!-- ****************** -->
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            <div style="margin-bottom: 10px;">
            </div>
    
    
    <ul class="forminfo">
    <li><div><label>地点序号<b>：</b></label><asp:TextBox ID="tbPositionId" runat="server" CssClass="dfinput" Width="518px"  Enabled="False"></asp:TextBox></div></li>
   
    <li><div><label>地点名称<b>：</b></label> <asp:TextBox ID="tbName" runat="server" CssClass="dfinput" Width="518px" ValidationGroup="menu"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*必选项" ForeColor="Red" ControlToValidate="tbName" CssClass="inline" ValidationGroup="menu">*必选项</asp:RequiredFieldValidator></div></li> 
    

    
    <li><div><label>地点备注<b>：</b></label><asp:TextBox ID="tbRemark" runat="server" CssClass="dfinput" Width="518px"></asp:TextBox></div></li> 
    

    <li><label>上级地点<b>：</b></label></li>
        
   
    </ul>
     
            <!-- ****************** -->


        </div>

    </form>
</body>

</html>
