<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateUC.ascx.cs" Inherits="One.Views.Academy.Session.CreateUC" %>

<%@ Register Src="~/Views/UserControls/DateChooser.ascx" TagPrefix="uc1" TagName="DateChooser" %>

<style type="text/css">
    .cell-width {
        width: 129px;
    }
</style>

<div class="data-entry-body">
    <h3 class="heading-of-create-edit">
        <asp:Label ID="lblHeading" runat="server" Text="New Session Create in: "></asp:Label>
    </h3>
    <hr />

    <div class="data-entry-section">
        <span style="font-size: 1.1em; font-weight: 700;">
            <asp:Label ID="lblAcademicHeading" runat="server" Text=""></asp:Label>
        </span>
        <br />
        <div class="data-entry-section-body">
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblAcademicStart" runat="server" Text=""></asp:Label>
            <br />
            &nbsp;&nbsp;&nbsp;<asp:Label ID="lblAcademicEnd" runat="server" Text=""></asp:Label>
        </div>
        <hr />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="data-entry-section-body">

                    <table>
                        <tr>
                            <td class="data-type">Session Name
                            </td>
                            <td class="data-value">
                                <asp:TextBox ID="txtName" runat="server" Width="128px"></asp:TextBox>
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtName" ErrorMessage="Name is required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Session Start Date</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtStart" runat="server" ClientIDMode="Static"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valiStartDate" runat="server"
                                    ForeColor="red" ControlToValidate="txtStart"
                                    ErrorMessage="Required"></asp:RequiredFieldValidator>
                                <%--<uc1:DateChooser runat="server" ID="dtStart" />--%>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Session End Date</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtEnd" runat="server" ClientIDMode="Static"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valiEnd" runat="server"
                                    ForeColor="red" ControlToValidate="txtEnd"
                                    ErrorMessage="Required">
                                </asp:RequiredFieldValidator>
                                <%--<uc1:DateChooser runat="server" ID="dtEnd" />--%>
                            </td>
                        </tr>
                    </table>
                </div>

                <div class="save-div">
                    <asp:Button ID="btnSaveAndAddMore" runat="server" OnClick="btnSave_Click" Text="Save and Add More" Width="143px" />
                    &nbsp;<asp:Button ID="btnSaveAndReturn" runat="server" OnClick="btnSave_Click" Text="Save and Return to List" Width="159px" />
                    &nbsp;<asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="102px" Visible="False" />
                    <asp:Label ID="lblError" runat="server" Text="Error while saving" ForeColor="red" Visible="False"></asp:Label>
                </div>
                <script>
                    $(function () {

                    $("#txtStart").unbind();
                    $("#txtStart").datepicker();

                    $("#txtEnd").unbind();
                    $("#txtEnd").datepicker();
                    });
                </script>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%--<asp:CheckBox ID="CheckBox1" runat="server" Text="Make this currently Active Session" />--%>

    <br />

    <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidAcademicYear" runat="server" Value="0" />
</div>
