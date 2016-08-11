<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Create.ascx.cs" Inherits="One.Views.Course.Category.Create" %>

<div>
    <fieldset>
        <legend>Course Category</legend>

        <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />

        <asp:HiddenField ID="hidRetUrl" runat="server" />
        <asp:HiddenField ID="hidId" runat="server" Value="0"/>

        <table>
            <tr>
                <td>Parent</td>
                <td>
                    <asp:DropDownList ID="cmbCategory" runat="server" Height="21px" Width="125px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Name</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="115px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtName" ValidationGroup="categoryCreateGroup"
                        ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>Description</td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="111px" Width="240px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:CheckBox ID="chkIsActive" runat="server" Text="Is Active" Visible="false" Checked="True" />
        <asp:CheckBox ID="chkVoid" runat="server" Visible="false" Text="Void" />
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="73px" OnClick="btnSave_Click" 
            ValidationGroup="categoryCreateGroup" />
        &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" Visible="False" Width="69px" />

    </fieldset>
</div>
