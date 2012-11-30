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
                            ������</div>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <span class="font9"><span id="custnamemsg">* �����������д������ʵ����</span></span>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="35">
                        <div align="right">
                            �ǳƣ�</div>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtNickname" runat="server"></asp:TextBox>
                        <span class="font9"><span id="Span2">* ���ڻ�Ա��������¼��ʾ</span></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <div align="right">
                            �Ա�</div>
                    </td>
                    <td class="font9" align="left">
                        <asp:RadioButtonList ID="rblGeneder" runat="server">
                            <asp:ListItem Text="��" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Ů" Value="0"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right">
                        <div align="right">
                            �ֻ���</div>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCellPhone" runat="server"></asp:TextBox>
                        * ����д׼ȷ���ֻ����룬�Ա���ն�����ص���Ѷ���
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right">
                        <div align="right">
                            �绰��</div>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                        <span class="font9"><span id="phonemsg">* </span>������д������룬�м���","����</span>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="35">
                        <div align="right">
                            ������</div>
                    </td>
                    <td align="left" nowrap>
                        <sc1:Area ID="scArea" runat="server" AutoPostBack="False">
                        </sc1:Area>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right">
                        <div align="right">
                            ��ϵ��ַ��</div>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtDwellAddress" runat="server" Width="430px"></asp:TextBox>
                        &nbsp; <span class="font9"><span id="addressmsg">* </span>�뾡����ϸ��д�õ�ַ��Ϣ��</span>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right">
                        <div align="right">
                            �ʱࣺ</div>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td height="35" align="right">
                        <div align="right">
                            ���棺</div>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="35">
                        <div align="right">
                            Email��</div>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><asp:Label ID="lblEmail"
                            runat="server"></asp:Label><span class="font9"><span id="span1"> * �������д����Ŀ</span></span>
                    </td>
                </tr>
                <tr>
                    <td align="right" height="35">
                        <div align="right">
                            ���գ�</div>
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
                            OnClick="btnSave_Click" AlternateText="ȷ���޸�" />
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
