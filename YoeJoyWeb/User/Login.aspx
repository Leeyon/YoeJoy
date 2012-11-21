<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="YoeJoyWeb.User.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="NavigationModuleContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PanicBuyingMdouleContent" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="TopLeftModuleContent" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="TopRightMdouleContent" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="BodyContent" runat="server">
    <table id="loginTab">
        <thead>
            <tr>
                <td>
                    <b>登录</b>
                </td>
                <td id="loginMsg">
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    用户名
                </td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="txtLoginName" />
                </td>
            </tr>
            <tr>
                <td>
                    密码
                </td>
            </tr>
            <tr>
                <td>
                    <input type="password" id="txtLoginPass" />
                </td>
            </tr>
            <tr>
                <td>
                    <input type="button" id="btnLogin" value="登录" />
                </td>
            </tr>
        </tbody>
    </table>
    <table id="RegisterTable">
        <thead>
            <tr>
                <td>
                    <b>注册</b>
                </td>
                <td id="RegisterMsg">
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    用户名
                </td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="txtRegisterName" />
                </td>
            </tr>
            <tr>
                <td>
                    密码
                </td>
            </tr>
            <tr>
                <td>
                    <input type="password" id="txtRegisterPass1" />
                </td>
            </tr>
            <tr>
                <td>
                    确认密码
                </td>
            </tr>
            <tr>
                <td>
                    <input type="password" id="txtRegisterPass2" />
                </td>
            </tr>
            <tr>
                <td>
                    邮箱
                </td>
            </tr>
            <tr>
                <td>
                    <input type="text" id="txtEmail" />
                </td>
            </tr>
            <tr>
                <td>
                    <input type="button" id="btnRegister" value="注册" />
                </td>
            </tr>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ExtenalContent" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ScriptContent" runat="server">
    <script type="text/javascript">

        function strToJson(str) {
            var json = eval('(' + str + ')');
            return json;
        };

        $(function () {


            //用户登录
            $("#loginTab #btnLogin").click(function () {
                var registerHandlerURL = "../Service/UserLogin.aspx";
                var name = $("#txtLoginName").val();
                var password = $("#txtLoginPass").val();

                $.post(registerHandlerURL, { "name": name, "pass": password }, function (data) {
                    var result = strToJson(data);
                    if (result.IsSuccess) {
                        window.location.href = "../Default.aspx";
                    }
                    else {
                        $("#loginMsg").empty().html(result.Msg);
                    }
                });

            });

            //用户注册
            $("#RegisterTable #btnRegister").click(function () {
                var registerHandlerURL = "../Service/UserRegister.aspx";
                var name = $("#txtRegisterName").val();
                var pass1 = $("#txtRegisterPass1").val();
                var pass2 = $("#txtRegisterPass2").val();
                var email = $("#txtEmail").val();

                $.post(registerHandlerURL, { "name": name, "pass1": pass1, "pass2": pass2, "email": email }, function (data) {
                    var result = strToJson(data);
                    if (result.IsSuccess) {
                        window.location.href = "../Default.aspx";
                    }
                    else {
                        $("#RegisterMsg").empty().html(result.Msg);
                    }
                });

            });

        });

    </script>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="PopupContent" runat="server">
</asp:Content>
