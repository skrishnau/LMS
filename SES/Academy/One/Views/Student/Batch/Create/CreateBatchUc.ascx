<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateBatchUc.ascx.cs" Inherits="One.Views.Student.Batch.Create.CreateBatchUc" %>
<%--<%@ Register Src="~/Views/Student/Batch/Create/AddProgramsUc.ascx" TagPrefix="uc1" TagName="AddProgramsUc" %>--%>
<%@ Register Src="~/Views/Structure/All/UserControls/StructureView/TreeViewWithCheckBoxInLeft.ascx" TagPrefix="uc1" TagName="TreeViewWithCheckBoxInLeft" %>



<div class="data-entry-section">
    <h3 class="heading-of-create-edit">Batch Create
    </h3>
    <hr />
    <br />

    <div class="data-entry-section-heading">
        General
    <hr />
    </div>
    <div class="data-entry-section-body">
        <%--<fieldset>
            <legend>Batch Create</legend>--%>
        <%--<div style="clear: both;"></div>--%>
        <table>
            <tr>
                <td class="data-type">Display Name</td>
                <td class="data-value">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="create" ID="validatorName" ControlToValidate="txtName" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="data-type">Class Commence From</td>
                <td class="data-value">
                    <asp:TextBox ID="txtCommenceDate" runat="server" TextMode="DateTimeLocal"
                        ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="data-type">Description</td>
                <td class="data-value">
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    <%--</fieldset>--%>
    <br />
    <div class="data-entry-section-heading">
        Programs to include in this batch
    <hr />
    </div>
    <div class="data-entry-section-body">
        <uc1:TreeViewWithCheckBoxInLeft runat="server" ID="TreeViewWithCheckBoxInLeft" />
    </div>
    <br />
    <div class="save-div">
        <asp:Button ID="btnSaveAndReturnToList" runat="server"
            Text="Save " OnClick="btnSaveAndReturnToList_Click" Width="87px" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server"
            Text="Cancel" OnClick="btnCancel_Click" Width="87px" />
        &nbsp;&nbsp;
        <asp:Label ID="lblError" runat="server" Text="Error while saving." ForeColor="red" Visible="False"></asp:Label>
    </div>


    <%-- <div style="margin: 5px 20px 20px;">
        <br />
        <asp:Panel ID="pnlProgramsAdd" runat="server" Visible="False">

            <strong>Add Programs to this Batch</strong>
            <hr />
            <%--<uc1:AddProgramsUc runat="server" ID="AddProgramsUc" />
            <br />

            <%--<uc1:AddProgramsUc runat="server" ID="AddProgramsUc" />
        </asp:Panel>
    </div>--%>

    <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
    <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />

    <script type="text/javascript">
        $('#txtCommenceDate').unbind();
        $("#txtCommenceDate").datepicker();

    </script>
</div>
