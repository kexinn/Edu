<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PaginationWebControl.ascx.cs" Inherits="web.uc.PaginationWebControl" %>

<div class="container-fluid">
<div class="row-fluid">
        <div class="span4">
         共  
            <asp:Label ID="lbTotPage" runat="server" ForeColor="Red"></asp:Label> 页 
            当前 
            <asp:Label ID="lbIndexPage" runat="server"></asp:Label>
            /<asp:Label ID="lbTotPage1" runat="server"></asp:Label> &nbsp;页
         </div>
         <div class="span8 ">

         <div class=" pull-right" >
            &nbsp;第： <asp:TextBox ID="tbGoNo" runat="server" Width="30px" CssClass="input-box margin-top-10"></asp:TextBox> 
             <asp:LinkButton ID="lbGo" runat="server" CssClass="btn green icn-only" 
                 style="margin-top:2px;margin-right:5px" onclick="lbGo_Click"><i class="icon-search"></i>go</asp:LinkButton>
         </div>
         
         <div class=" pull-right " >
         <ul class="pager margin-bottom-10 margin-top-10">
            <li><asp:LinkButton ID="lbPrePage" runat="server" onclick="lbPrePage_Click">上一页</asp:LinkButton></li>

            <li>
                <asp:LinkButton ID="lbNexPage" runat="server" onclick="lbNexPage_Click">下一页</asp:LinkButton></li>
        </ul>
        </div>
         </div>
    </div>
</div>