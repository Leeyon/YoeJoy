<%@ Control Language="c#" Inherits="YoeJoyWeb.Controls.CustomerDetailInfo" CodeBehind="CustomerDetailInfo.ascx.cs" %>
<%@ Register TagPrefix="sc1" Namespace="YoeJoyWeb.Controls" Assembly="YoeJoyWeb" %>
<script type="text/javascript" src="../Controls/My97DatePicker/WdatePicker.js"></script>
<table border="0" bordercolor="#b1d0ff" width="100%" cellspacing="0" cellpadding="0"
    style="border-collapse: collapse; text-align: center;">
    <tr>
        <td valign="top">
            <table style="border-collapse: collapse; height: 1px; padding: 0 5px 0 5px;" bordercolor="#b1d0ff"
                cellspacing="0" cellpadding="0" border="1" align="center" width="100%">
                <tr>
                    <td align="right" height="35" width="15%">
                        <div align="right">
                            姓名：</div>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <span class="font9"><span id="custnamemsg">* 请务必完整填写您的真实姓名</span></span>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="35">
                        <div align="right">
                            昵称：</div>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtNickname" runat="server"></asp:TextBox>
                        <span class="font9"><span id="Span2">* 用于会员交流，登录显示</span></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <div align="right">
                            性别：</div>
                    </td>
                    <td class="font9" align="left">
                        <asp:RadioButtonList ID="rblGeneder" runat="server">
                            <asp:ListItem Text="男" Value="1"></asp:ListItem>
                            <asp:ListItem Text="女" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right">
                        <div align="right">
                            手机：</div>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCellPhone" runat="server"></asp:TextBox>
                        * 请填写准确的手机号码，以便接收订单相关的免费短信
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right">
                        <div align="right">
                            电话：</div>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                        <span class="font9"><span id="phonemsg">* </span>可以填写多个号码，中间用","隔开</span>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="35">
                        <div align="right">
                            地区：</div>
                    </td>
                    <td align="left" nowrap>
                        <sc1:Area ID="scArea" runat="server" AutoPostBack="False">
                        </sc1:Area>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right">
                        <div align="right">
                            联系地址：</div>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDwellAddress" runat="server" Width="430px"></asp:TextBox>
                        &nbsp; <span class="font9"><span id="addressmsg">* </span>请尽量详细填写该地址信息！</span>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right">
                        <div align="right">
                            邮编：</div>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right">
                        <div align="right">
                            传真：</div>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="35">
                        <div align="right">
                            Email：</div>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:Label ID="lblEmail"
                            runat="server"></asp:Label><span class="font9"><span id="span1"> * 请务必填写该项目</span></span>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="35">
                        <div align="right">
                            生日：</div>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtBirthDay" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left" height="20">
                        <asp:ImageButton ID="btnSave" ImageUrl="../images/Member/btn_Save.gif" runat="server"
                            OnClick="btnSave_Click" AlternateText="确认修改" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" height="10">
                        <asp:Label ID="lblErrMsg" runat="server" ForeColor="Red" EnableViewState="False"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
