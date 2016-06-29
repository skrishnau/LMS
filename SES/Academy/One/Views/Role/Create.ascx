<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Create.ascx.cs" Inherits="One.Views.Role.Create" %>
<div>
    <fieldset>
        <legend>Role
        </legend>

        <table>
            <tr>
                <td>Name</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Description</td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="82px" Width="213px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <%-- ****** next version ******* --%>
        <%--<asp:CheckBox ID="chkActive" runat="server" Checked="True" Text="Active" Visible="False"></asp:CheckBox>--%>
        <asp:TextBox ID="txtSchoolId" runat="server" Width="16px" Visible="false"></asp:TextBox>

    </fieldset>
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" style="height: 26px" Width="66px" />
</div>
