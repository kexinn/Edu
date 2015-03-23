<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="web.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript" src="/media/js/jquery-1.11.1.js"></script>
   <script type="text/javascript">
       $(function () {

           /*
               1、WebService请求类型都为Post，WebService的Url为“[WebServiceUrl]/[WebMethod]”
               2、contentType声明为Json
               3、data要用Json的字符串格式传入
               4、设置了dataType为json后，result就直接为返回的Json对象。
   
           */
           
           //调用无参数方法
           $("#btnHelloWorld").click(function () {
               $.ajax({
                   type: "POST",
                   contentType: "application/json",
                   url: "webservice/user/UserWebService.asmx/HelloWorld",
                   data: "{}",
                   dataType: 'json',
                   success: function (result) {
                       alert(result.d);},
                   error: function(x, e) {  
                       alert(x.responseText);  
                   },  
                   complete: function(x) {  
                       alert(x.responseText);  
                   }  
               
               });
           });


           //$("#resText").html("");
           $("#name").blur(function () {
               $.ajax({
                   type: "POST",
                   contentType: "application/json",
                   url: "/webservice/user/UserWebService.asmx/GetUsers",
                   data: "{prefixText:'" + $("#name").val().trim() + "',count:10}",
                   dataType: 'json',
                   success: function (result) {


                      $("#resText").html(t.split("|"));
                   }
               });
           });

           $("#send").click(function () {
               $.ajax({
                   type: "POST",
                   contentType: "application/json",
                   url: "/webservice/user/UserWebService.asmx/GetUsers",
                   data: "{prefixText:'" + $("#name").val().trim() + "',count:10}",
                   dataType: 'json',
                   success: function (result) {
                       $("#resText").html(result.d);
                   }
               });
           });
           //传入1个参数
           $("#btnHello").click(function () {
               $.ajax({
                   type: "POST",
                   contentType: "application/json",
                   url: "/webservice/user/test.asmx/Hello",
                   data: "{name:'KiMoGiGi'}",
                   dataType: 'json',
                   success: function (result) {
                       alert(result.d);
                   }
               });
           });

           //返回泛型列表
           $("#btnArray").click(function () {
               $.ajax({
                   type: "POST",
                   contentType: "application/json",
                   url: "/webservice/user/test.asmx/CreateArray",
                   data: "{i:10}",
                   dataType: 'json',
                   success: function (result) {
                       alert(result.d.join(" | "));
                   }
               });
           });

           //返回复杂类型
           $("#btnPerson").click(function () {
               $.ajax({
                   type: "POST",
                   contentType: "application/json",
                   url: "/webservice/user/test.asmx/GetPerson",
                   data: "{name:'KiMoGiGi',age:26}",
                   dataType: 'json',
                   success: function (result) {
                       var person = result.d;
                       var showText = [];
                       for (var p in person) {
                           showText.push(p + ":" + person[p]);
                       }
                       alert(showText.join("\r\n"));
                   }
               });
           });
       });

    </script>
</head>
<body>
    <form id="form1" runat="server">

        
     <object  classid="clsid:004e8a0b-50f4-4906-8c2c-fc9eb6b7d535" codebase="lib/SetupPrintActive.cab"
        width="200" height="60" id="helloBossma">
    </object>
    <div>
        <input id="name" type="text" />
    <input id="send" type="button" value="提交" />

        <p>
                <input type="button" id="btnHelloWorld" value="HelloWorld" />
            </p>
            <p>
                <input type="button" id="btnHello" value="Hello" />
            </p>
            <p>
                <input type="button" id="btnArray" value="CreateArray" />
            </p>
            <p>
                <input type="button" id="btnPerson" value="GetPerson" />
            </p>


        <asp:TextBox ID="tm" runat="server"></asp:TextBox><asp:Button ID="bttm" runat="server" Text="生成条码" OnClick="bttm_Click" />
        <br />
        <asp:Image ID="Image1" runat="server" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
 