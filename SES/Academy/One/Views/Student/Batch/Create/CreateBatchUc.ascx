<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateBatchUc.ascx.cs" Inherits="One.Views.Student.Batch.Create.CreateBatchUc" %>
<%@ Register Src="~/Views/Student/Batch/Create/AddProgramsUc.ascx" TagPrefix="uc1" TagName="AddProgramsUc" %>
<%@ Register Src="~/Views/Structure/All/UserControls/StructureView/TreeViewWithCheckBoxInLeft.ascx" TagPrefix="uc1" TagName="TreeViewWithCheckBoxInLeft" %>



<div>
    <div style="text-align: center">
        <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
        <strong>Batch Create</strong>
    </div>
    <strong style="clear: left;">General</strong>
    <hr />
    <div style="overflow: hidden;">
        <%--<fieldset>
            <legend>Batch Create</legend>--%>
        <%--<div style="clear: both;"></div>--%>
        <table>
            <tr>
                <td>Display Name</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="create" ID="validatorName" ControlToValidate="txtName" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Class Commence From</td>
                <td>
                    <asp:TextBox ID="txtCommenceDate" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Description</td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <%--</fieldset>--%>
        <br />
        <strong>
            Programs in which this Batch students are admitted
        </strong>
        <hr />
        <br />
        <%-- style="background-color: azure;" --%>
        <div >
            <br />
            <uc1:TreeViewWithCheckBoxInLeft runat="server" ID="TreeViewWithCheckBoxInLeft" />
            <br />
        </div>
        <br />
        <hr />
        <div style="clear: both;">
            <br />
            &nbsp;
        <asp:Button ID="btnSaveAndReturnToList" runat="server"
            Text="Save " OnClick="btnSaveAndReturnToList_Click" Width="87px" />
            &nbsp;
            &nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server"
            Text="Cancel" OnClick="btnCancel_Click" Width="87px" />
        </div>
    </div>


    <div style="margin: 5px 20px 20px;">
        <br />
        <asp:Panel ID="pnlProgramsAdd" runat="server" Visible="False">

            <strong>Add Programs to this Batch</strong>
            <hr />
            <uc1:AddProgramsUc runat="server" ID="AddProgramsUc" />
            <br />

            <%--<uc1:AddProgramsUc runat="server" ID="AddProgramsUc" />--%>
        </asp:Panel>
    </div>

    <div>
        <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
        <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />

    </div>
</div>
