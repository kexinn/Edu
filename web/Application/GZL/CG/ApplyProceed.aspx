<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyProceed.aspx.cs" Inherits="web.Application.GZL.CG.ApplyProceed" %>

<!DOCTYPE html>


<!--[if IE 8]> <html lang="en" class="ie8"> <![endif]-->

<!--[if IE 9]> <html lang="en" class="ie9"> <![endif]-->

<!--[if !IE]><!-->
<html lang="en">
<!--<![endif]-->

<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>职教中心日常管理系统</title>

    <link href="/media/css/style.css" rel="stylesheet" type="text/css" />
    <link href="/media/css/formstyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/media/js/jquery.js"></script>

</head>
<body>


    <form id="form1" runat="server" >

        <div>
            <div class="logintop">
                <span>欢迎登录日常管理平台</span>
                <ul>
                    <li><a href="#">任务办理</a></li>

                </ul>
            </div>


            <div class="fixhead"></div>
            
           <div  style="margin: 0 auto; width: 720px;">
            <asp:Panel ID="PanelFirst" runat="server">
                <div class="container-fluid">
                    <p>
                    </p>
                    <h4>
                        <asp:Label ID="lbActorName" runat="server"></asp:Label>
                    </h4>
                    <p>
                    </p>
                    <div>
                        办理意见：<asp:TextBox ID="tbOpinion" runat="server" CssClass="dfinput" Height="78px" TextMode="MultiLine" Width="342px"></asp:TextBox>
                    </div>

                    <asp:LinkButton ID="lbAgree" OnClick="lbAgree_Click" runat="server"><i class="mbtn">同意</i></asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="lbRefuse" OnClick="lbRefuse_Click" runat="server"><i class="mbtn">拒绝</i></asp:LinkButton>
                </div>
            </asp:Panel>
            <asp:Panel ID="PanelNext" runat="server">
                <div>
                    <h4>下一步：<asp:Label ID="lbNextActor" runat="server"></asp:Label></h4>
                    <br />
                    选择下一步执行用户或部门<br />
                    <asp:ListBox ID="listBoxUser" runat="server" Height="171px" Width="295px" CssClass="dfinput"></asp:ListBox>
                    <br />
                    <asp:LinkButton ID="lbApply" OnClick="lbApply_Click" runat="server"><i class="mbtn">确定</i></asp:LinkButton>
                </div>
            </asp:Panel>
            </div>
        </div>

        <!-- END CONTAINER -->

        <!-- BEGIN FOOTER -->



        <asp:Label ID="lbMessage" runat="server" ForeColor="Red"></asp:Label>



    </form>
</body>
</html>

