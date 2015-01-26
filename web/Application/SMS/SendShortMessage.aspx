<%@ Page Language="C#" EnableEventValidation="false" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="SendShortMessage.aspx.cs" Inherits="web.Application.SMS.SendShortMessage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>无标题文档</title>
    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>
    <script type="text/javascript" src="/media/calendar/WdatePicker.js"></script>
    
    <script type="text/javascript">

        function check() {
            return confirm("确定提交？");
        }
    </script>
</head>


<body>
    <form id="form1" runat="server">
        <div class="place">
            <span>位置：</span>
            <ul class="placeul">
                <li><a href="#">首页</a></li>
                <li><a href="#">短信群发</a></li>
                <li><a href="#">发送短信</a></li>
            </ul>
        </div>
        
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <div class="rightinfo">


            <div class="toolsearch">
                <div class="pullleft">
                    上班时间：<asp:TextBox ID="tbShangbanTime" CssClass="dfinput" Width="120px" runat="server" >8:00:00</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="inline" runat="server" ControlToValidate="tbShangbanTime" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    下班时间：<asp:TextBox ID="tbXiabanTime" CssClass="dfinput" Width="120px" runat="server" >16:25:00</asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="inline" runat="server" ControlToValidate="tbXiabanTime" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    统计开始时间：<asp:TextBox ID="tbStartTime" CssClass="dfinput" Width="120px" runat="server" onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="inline" runat="server" ControlToValidate="tbStartTime" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    统计结束时间：<asp:TextBox ID="tbEndTime" CssClass="dfinput" Width="120px" runat="server"  onclick="WdatePicker({skin:'whyGreen'})"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="inline" runat="server" ControlToValidate="tbEndTime" ErrorMessage="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <%-- <asp:TextBox ID="TextBox1" CssClass="dfinput" runat="server" onclick="WdatePicker({skin:'whyGreen',dateFmt:'yyyy-MM-dd HH:mm:ss',minDate:'2008-03-08 11:30:00',maxDate:'2100-03-10 20:59:30'})"></asp:TextBox>
               --%> </div>

                <div class="pullright">

                </div>
                <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional"  runat="server">
    <ContentTemplate> 
                <div class="pullleft">
                    <asp:LinkButton ID="lbStatisc" runat="server"
                        OnClick="lbStatisc_Click"> <i class="mbtn"><img src="/media/images/ico06.png" />统计</i></asp:LinkButton>
                </div>  
                <div class="clear">
                    <br />
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2" >
        <ProgressTemplate>
           
            <font color="blue" >正在计算<asp:Image ID="Image1" runat="server" ImageUrl="/media/images/jindu.gif" /></font>
            
        </ProgressTemplate>
    </asp:UpdateProgress>
                </div>
            </div>
            <div>
                &nbsp;<asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>


            </div>
            
            <div class="formtitle"><span>发送名单</span></div>
            <asp:GridView ID="GridView1" runat="server" CssClass="tablenoborder">
                 <Columns>
                <asp:TemplateField HeaderText="序号" InsertVisible="False">
               <ItemStyle HorizontalAlign="Center" />
               <HeaderStyle HorizontalAlign="Center" />
              <ItemTemplate>
               <%#Container.DataItemIndex+1%>
             </ItemTemplate>
             </asp:TemplateField>
                     </Columns>
            </asp:GridView>
 </ContentTemplate></asp:UpdatePanel> 
        </div>

        <script type="text/javascript">
            $('.tablelist tbody tr:odd').addClass('odd');
        </script>
    </form>
</body>

</html>



