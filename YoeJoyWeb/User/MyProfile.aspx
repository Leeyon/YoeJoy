<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="MyProfile.aspx.cs" Inherits="YoeJoyWeb.User.MyProfile" %>

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
    <table>
        <thead>
            <tr>
                <td>
                    <b>我的账户</b>
                </td>
            </tr>
        </thead>
        <tbody>
        <%=MyProfileHTML %>
        </tbody>
    </table>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ExtenalContent" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="PopupContent" runat="server">
</asp:Content>
