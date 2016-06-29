<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentGroupUc.ascx.cs" Inherits="One.Views.Student.Create.StudentGroupUc" %>

<div>
    <div style=" overflow: hidden; margin: 20px; width: auto;">

        <fieldset>
            <legend>Student Group</legend>
            <div style="overflow: hidden; clear: both;" >
                <div style="float: left;  margin: 0; ">
                    <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    <table>
                       <tr>
                            <td>Parent</td>
                            <td>
                                <asp:DropDownList ID="cmbParent" runat="server" Height="23px" Width="125px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Name of Group &nbsp;</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                    runat="server" ControlToValidate="txtName"
                                    ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Description</td>
                            <td>
                                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="69px" Width="218px"></asp:TextBox>
                            </td>
                        </tr>

                    </table>
                    <asp:CheckBox ID="chkIsActive" Checked="true" Text="Is Active" Visible="False" runat="server" />

                </div>
                <div style="float: left; overflow: auto;">
                    <asp:Button ID="btnImport" runat="server" Text="Import" />
                </div>
            </div>
        </fieldset>


        <div style="clear: both;">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="77px" />

        </div>
        <br />

    </div>

    <hr />
</div>
