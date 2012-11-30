<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Site.Master" AutoEventWireup="true"
    CodeBehind="MyAddress.aspx.cs" Inherits="YoeJoyWeb.User.MyAddress" %>

<%@ Register TagPrefix="sc1" Namespace="YoeJoyWeb.Controls" Assembly="YoeJoyWeb" %>
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
    <div class="content_two">
        <div class="content_two_left_inAccount">
        </div>
        <div class="content_two_right_inAccount">
            <div class="content_two_right_content">
                <div class="content_two_right_Membertitle">
                    <div class="content_two_right_Membertitle_top">
                        <ul>
                            <li><a href="../items/default.aspx">首页 </a>> <a>会员中心 </a>> <font color="#F24A95">收货人资料</font>
                            </li>
                        </ul>
                        <div class="fixed">
                        </div>
                    </div>
                </div>
                <div class="content_two_right_Membertitle_nav">
                    <span>收货人资料</span>
                    <div style="border-bottom: 1px solid #E7E7E7; margin: 0px 10px 0px 10px;">
                    </div>
                </div>
                <div class="content_two_right_content_content">
                    <div class="">
                        <table width="100%" style="text-align: left;">
                            <tr>
                                <td>
                                    <asp:DataList ID="DataList1" runat="server" DataKeyField="SysNo" OnItemCommand="DataList1_ItemCommand"
                                        OnItemDataBound="DataList1_ItemDataBound" RepeatColumns="2" Width="100%" CellSpacing="0"
                                        CellPadding="5">
                                        <ItemTemplate>
                                            <div align="left" class="MemberList_Address">
                                                <table width="340" border="0px" bordercolor="#b1d0ff" style="border-collapse: collapse">
                                                    <tr style="border-bottom: 1px dashed #CDCDCD;">
                                                        <td colspan="2" style="height: 45px; width: 180px">
                                                            <asp:Label ID="lblIsDefault" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem, "IsDefault")%>'></asp:Label>
                                                            <asp:Label ID="lblBrief" Style="color: #FF2991; font-weight: 700; font-size: 20px;
                                                                padding-left: 8px;" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Brief")%>'></asp:Label>&nbsp;&nbsp;
                                                            <asp:LinkButton ID="lnkbtnSetDefault" Style="font-weight: 700;" Font-Underline="false"
                                                                runat="server" Text=" 设为默认 " CommandName="SetDefault" ForeColor="black">
                                                            </asp:LinkButton>
                                                        </td>
                                                        <td style="width: 80px">
                                                        </td>
                                                        <td style="width: 80px">
                                                        </td>
                                                    </tr>
                                                    <tr style="border-bottom: 1px dashed #CDCDCD;">
                                                        <td width="70" height="30" class="tdLeft">
                                                            <div align="right">
                                                                姓名：</div>
                                                        </td>
                                                        <td width="90" class="tdRight">
                                                            <div align="left" class="tdRight">
                                                                <asp:Label ID="lblName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Name")%>'></asp:Label></div>
                                                        </td>
                                                        <td width="70" height="30" class="tdLeft">
                                                            <div align="right">
                                                                联系人：</div>
                                                        </td>
                                                        <td>
                                                            <div align="left" class="tdRight">
                                                                <asp:Label ID="lblContact" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Contact")%>'></asp:Label></div>
                                                        </td>
                                                    </tr>
                                                    <tr style="border-bottom: 1px dashed #CDCDCD;">
                                                        <td width="70" height="30" class="tdLeft">
                                                            <div align="right">
                                                                电话：</div>
                                                        </td>
                                                        <td colspan="3" width="90">
                                                            <div align="left" class="tdRight">
                                                                <asp:Label ID="lblPhone" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Phone")%>'></asp:Label></div>
                                                        </td>
                                                    </tr>
                                                    <tr style="border-bottom: 1px dashed #CDCDCD;">
                                                        <td width="70" height="30">
                                                            <div align="right" class="tdLeft">
                                                                手机：</div>
                                                        </td>
                                                        <td colspan="3">
                                                            <div align="left" class="tdRight">
                                                                <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "CellPhone")%>'></asp:Label></div>
                                                        </td>
                                                    </tr>
                                                    <tr style="border-bottom: 1px dashed #CDCDCD;">
                                                        <td width="70" height="30" class="tdLeft">
                                                            <div align="right">
                                                                地区：</div>
                                                        </td>
                                                        <td colspan="3">
                                                            <div align="left" class="tdRight">
                                                                <asp:Label ID="lblAreaName" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "AreaName")%>'><</asp:Label></div>
                                                        </td>
                                                    </tr>
                                                    <tr style="border-bottom: 1px dashed #CDCDCD;">
                                                        <td width="70" height="30" class="tdLeft">
                                                            <div align="right">
                                                                联系地址：</div>
                                                        </td>
                                                        <td colspan="3">
                                                            <div align="left" class="tdRight">
                                                                <asp:Label ID="lblAddress" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Address")%>'></asp:Label></div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="70" height="30" class="tdLeft">
                                                            <div align="right">
                                                                邮编：</div>
                                                        </td>
                                                        <td width="90">
                                                            <div align="left" class="tdRight">
                                                                <asp:Label ID="lblZip" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Zip")%>'></asp:Label></div>
                                                        </td>
                                                        <td width="70" class="tdLeft">
                                                            <div align="right">
                                                                传真：</div>
                                                        </td>
                                                        <td width="90">
                                                            <div align="left" class="tdRight">
                                                                <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Fax")%>'></asp:Label></div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="lnkbtnUpdate" runat="server" CssClass="ButtonAccount3" CommandName="Update"
                                                                Text=" 编 辑 " />
                                                        </td>
                                                        <td align="right">
                                                            <asp:Button ID="lnkbtnDelte" runat="server" CssClass="ButtonAccount3" CommandName="Delete"
                                                                Text=" 删 除 " />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </td>
                            </tr>
                            <tr>
                                <td style="font: red;">
                                    <asp:LinkButton ID="lntbtnAdd" runat="server" OnClick="lntbtnAdd_Click" Style="font-weight: 700;
                                        color: #FF2991;"> + 添加收货地址</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="AddressInfo" runat="server">
                        <div class="AddressAdd">
                            <div style="padding: 15px 0 10px 25px;">
                                <span class="AddressAdd_title">添加收货地址</span></div>
                            <div class="AddressAdd_content">
                                <table border="1" bordercolor="#b1d0ff" cellpadding="0" cellspacing="0" style="border-collapse: collapse"
                                    width="100%">
                                    <tr>
                                        <td height="30" width="80">
                                            <div align="right">
                                                类型：</div>
                                        </td>
                                        <td style="width: 742px">
                                            &nbsp;&nbsp;<asp:TextBox ID="txtBrief" runat="server"></asp:TextBox>&nbsp; 例如：公司、家庭，便于您选择收货地址
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" width="80">
                                            <div align="right">
                                                <asp:Label ID="lblSysNo" runat="server" Visible="False">0</asp:Label>
                                                <asp:Label ID="lblIsDefault" runat="server" Visible="False">-1</asp:Label>
                                                <asp:Label ID="lblCustomerSysNo" runat="server" Visible="False">0</asp:Label>姓名：
                                            </div>
                                        </td>
                                        <td style="width: 742px">
                                            &nbsp;&nbsp;<asp:TextBox ID="txtName" runat="server"></asp:TextBox><font face="宋体">
                                                <span class="font9"><span id="custnamemsg">* </span>请务必完整填写您的真实姓名 </span></font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" width="80">
                                            <div align="right">
                                                联系人：</div>
                                        </td>
                                        <td style="width: 742px">
                                            &nbsp;&nbsp;<asp:TextBox ID="txtContact" runat="server"></asp:TextBox><font face="宋体">
                                                <span class="font9"><span id="Span1">* </span>请填写准确的联系人信息 </span></font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="30" width="80">
                                            <div align="right">
                                                <font face="宋体">手机：</font></div>
                                        </td>
                                        <td style="width: 742px">
                                            &nbsp;&nbsp;<asp:TextBox ID="txtCellPhone" runat="server"></asp:TextBox>
                                            * 请填写准确的手机号码，以便接收订单相关的免费短信
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="30" width="80">
                                            <div align="right">
                                                电话：</div>
                                        </td>
                                        <td style="width: 742px">
                                            &nbsp;&nbsp;<asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                                            <span class="font9"><span id="phonemsg">* </span>可以填写多个联系电话，中间用","隔开</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" height="30" width="80">
                                            <div align="right">
                                                地区：</div>
                                        </td>
                                        <td style="width: 742px">
                                            &nbsp;&nbsp;<sc1:Area ID="scArea" runat="server" AutoPostBack="False">
                                            </sc1:Area>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" width="80">
                                            <div align="right">
                                                联系地址：</div>
                                        </td>
                                        <td style="width: 742px">
                                            &nbsp;&nbsp;<asp:TextBox ID="txtAddress" runat="server" Width="400px"></asp:TextBox>&nbsp;
                                            <span class="font9"><span id="addressmsg">* </span>请尽量详细填写该地址信息！</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" width="80">
                                            <div align="right">
                                                邮编：</div>
                                        </td>
                                        <td style="width: 742px">
                                            &nbsp;&nbsp;<asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="30" width="80">
                                            <div align="right">
                                                传真：</div>
                                        </td>
                                        <td style="width: 742px">
                                            &nbsp;&nbsp;<asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" height="33">
                                            <div align="left">
                                                &nbsp;&nbsp;<strong>注意：</strong>带 * 的栏目必须填写！</div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" height="36">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="ButtonAccount5" OnClick="btnSubmit_Click"
                                                Text="提交信息" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" height="20" colspan="2">
                                            <asp:Label ID="lblErrMsg" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="fixed" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ExtenalContent" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="PopupContent" runat="server">
</asp:Content>
