<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="MyPassword.aspx.cs" Inherits="YoeJoyWeb.User.MyPassword" %>

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
    <table width="95%" cellspacing="0" cellpadding="0" align="center">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table border="0" width="100%" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="100%">
                            <table border="0" width="100%">
                                <tr>
                                    <td>
                                        <span class="style3">密码修改</span>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="4" bgcolor="#0066FF">
                                        <img src="images/dot_line.gif" width="1" height="1">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%">
                            <table width="100%">
                                <tr>
                                    <td valign="middle" align="center">
                                        <table border="1" cellpadding="0" cellspacing="6" bordercolor="#eaeaea" style="border-collapse: collapse">
                                            <tr>
                                                <td align="right" class="font9" width="80">
                                                    旧 密 码：
                                                </td>
                                                <td width="160">
                                                    <font face="宋体">
                                                        <asp:TextBox ID="txtOld" runat="server" Width="100%" TextMode="Password"></asp:TextBox></font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="font9" width="80">
                                                    新 密 码：
                                                </td>
                                                <td width="160">
                                                    <font face="宋体">
                                                        <asp:TextBox ID="txtNew0" runat="server" Width="100%" TextMode="Password"></asp:TextBox></font>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right" class="font9" width="80">
                                                    确认密码：
                                                </td>
                                                <td width="160">
                                                    <asp:TextBox ID="txtNew1" runat="server" Width="100%" TextMode="Password"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" class="font9" align="center">
                                                    <asp:Label ID="lblErrMsg" runat="server" ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" align="center">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="修 改" CssClass="button" OnClick="btnSubmit_Click">
                                                    </asp:Button>&nbsp;<asp:Button ID="btnCancel" runat="server" Text="放 弃" CssClass="button">
                                                    </asp:Button><br>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="100%" background="../images/Account/Main_Line.gif">
                            <img border="0" src="../images/Account/Main_Line.gif" align="left" width="4" height="1">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ExtenalContent" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="PopupContent" runat="server">
</asp:Content>
