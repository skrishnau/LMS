<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateUC.ascx.cs" Inherits="One.Views.Academy.Session.CreateUC" %>

<%@ Register Src="~/Views/UserControls/DateChooser.ascx" TagPrefix="uc1" TagName="DateChooser" %>

<style type="text/css">
    .cell-width {
        width: 129px;
    }
</style>

<div>
    <div style="font-size: 1.3em; font-weight: 700; text-align: center;">
        <asp:Label ID="lblHeading" runat="server" Text="New Session Create in: "></asp:Label>
        <hr />
    </div>

    <div>
        <span style="font-size: 1.1em; font-weight: 700;">
            <asp:Label ID="lblAcademicHeading" runat="server" Text=""></asp:Label>
        </span>
        <br />
        <span style="margin-left: 20px; display: inline-block">
            <asp:Label ID="lblAcademicStart" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="lblAcademicEnd" runat="server" Text=""></asp:Label>
        </span>
    </div>
    <hr />
    <br />
    <div style="margin: 5px;">
        <table>
            <tr style="vertical-align: top;">
                <td class="cell-width">Session Name
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="128px"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtName" ErrorMessage="Name is required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr style="vertical-align: top;">
                <td>Session Start Date</td>
                <td>
                    <uc1:DateChooser runat="server" ID="dtStart" />
                </td>
            </tr>
            <tr style="vertical-align: top;">
                <td>Session End Date</td>
                <td>
                    <uc1:DateChooser runat="server" ID="dtEnd" />
                </td>
            </tr>
        </table>

        <br />
        <div>
            <span class="cell-width" style="display: inline-block;"></span>
            <span>
                <asp:Button ID="btnSaveAndAddMore" runat="server" OnClick="btnSave_Click" Text="Save and Add More" Width="143px" />
                &nbsp;<asp:Button ID="btnSaveAndReturn" runat="server" OnClick="btnSave_Click" Text="Save and Return to List" Width="159px" />
                &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="102px" Visible="False" />

            </span>

        </div>
    </div>
    <%--<asp:CheckBox ID="CheckBox1" runat="server" Text="Make this currently Active Session" />--%>


    <br />
    <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidAcademicYear" runat="server" Value="0" />
</div>
