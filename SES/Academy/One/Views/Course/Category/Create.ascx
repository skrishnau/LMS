<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Create.ascx.cs" Inherits="One.Views.Course.Category.Create" %>

<div class="panel panel-default">


    <div class="panel-heading">
        General
    </div>

    <div class="panel-body">
        <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />

        <asp:HiddenField ID="hidCategoryId" runat="server" Value="0" />
        <asp:HiddenField ID="hidParentCategoryId" runat="server" Value="0" />


        <table>
            <tr>
                <td class="data-type">Parent</td>
                <td class="data-value">
                    <asp:DropDownList ID="cmbCategory" runat="server" Height="21px" Width="125px" Enabled="False"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="data-type">Name</td>
                <td class="data-value">
                    <asp:TextBox ID="txtName" runat="server" Width="115px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtName" ValidationGroup="categoryCreateGroup"
                        ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="data-type">Description</td>
                <td class="data-value">
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="111px" Width="240px"></asp:TextBox>
                </td>
            </tr>
        </table>

    </div>

    <asp:CheckBox ID="chkIsActive" runat="server" Text="Is Active" Visible="false" Checked="True" />
    <asp:CheckBox ID="chkVoid" runat="server" Visible="false" Text="Void" />

</div>

<div class="save-div">
    <asp:Button ID="btnSave" runat="server" Text="Save" Width="73px" OnClick="btnSave_Click"
        ValidationGroup="categoryCreateGroup" />
    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" Width="69px" />
    &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label runat="server" ID="lblError" Text="Save Error!"></asp:Label>
</div>
