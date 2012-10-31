<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="YoeJoyWeb.User.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <thead>
            <tr>
                <td>
                    <b>用户注册</b>
                </td>
                <td>
                    <asp:Label ID="lbMsg" runat="server"></asp:Label>
                </td>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    用户名
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    密码
                </td>
                <td>
                    <asp:TextBox ID="txtPwd" TextMode="Password" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    确认密码
                </td>
                <td>
                    <asp:TextBox ID="txtPwd2" TextMode="Password" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    电子邮箱
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnRegister" runat="server" Text="注册" 
                        onclick="btnRegister_Click" style="height: 21px"  />
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
