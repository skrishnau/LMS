<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.Structure.Level.Create" %>

<asp:Content runat="server" ContentPlaceHolderID="body" ID="content1">
    <h3 class="heading-of-create-edit">
        <asp:Label ID="lblHeading" runat="server" Text="Level edit"></asp:Label>
    </h3>
    <hr />
    <asp:HiddenField ID="hidId" runat="server" Value="0" />
    <%--<asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />--%>
    <div class="data-entry-section-body">
        <table>
            <tr>
                <td class="data-type">Name &nbsp;</td>
                <td class="data-value">
                    <asp:TextBox ID="txtName" runat="server" Width="139px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="txtNameVali" ValidationGroup="save" runat="server" ControlToValidate="txtName"
                        Text="Required" ForeColor="red"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="data-type">Description&nbsp;</td>
                <td class="data-value">
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="89px" Width="205px"></asp:TextBox>
                </td>
            </tr>
        </table>

    </div>
    <div class="save-div">
        <asp:Button ID="Save" runat="server" Text="Save" ValidationGroup="save" Width="94px" OnClick="btnSave_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="94px" OnClick="btnCancel_Click" />
        &nbsp;
        <asp:Label ID="lblError" runat="server" Text="Error while saving." ForeColor="red"></asp:Label>
    </div>

    <br />

</asp:Content>
