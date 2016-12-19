<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="BatchCreate.aspx.cs" Inherits="One.Views.Student.Batch.Create.BatchCreate" %>

<%@ Register Src="~/Views/Student/Batch/Create/CreateBatchUc.ascx" TagPrefix="uc1" TagName="CreateBatchUc" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <%--<uc1:CreateBatchUc runat="server" ID="CreateBatchUc" />--%>

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
                        <asp:RequiredFieldValidator runat="server" ValidationGroup="create" ID="validatorName" 
                            ControlToValidate="txtName" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">Class Commence From</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtCommenceDate" runat="server" TextMode="DateTimeLocal"
                            ClientIDMode="Static"></asp:TextBox>
                         <asp:Label runat="server"  ID="lblCommenceDateError" 
                             Text="Required and should be in date format" ForeColor="#FF3300" Visible="False"></asp:Label>
                  
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
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div style="margin-left: -10px;">
                        <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="True" Text="Select all" OnCheckedChanged="chkSelectAll_CheckedChanged" />
                    </div>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--<uc1:TreeViewWithCheckBoxInLeft runat="server" ID="TreeViewWithCheckBoxInLeft" />--%>
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

        <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />

        <script type="text/javascript">
            $('#txtCommenceDate').unbind();
            $("#txtCommenceDate").datepicker();

        </script>
    </div>


</asp:Content>



<asp:Content runat="server" ID="content2" ContentPlaceHolderID="head">
    <script type="text/javascript" src="../../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.min.js"></script>
    <script src="../../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    Batch Create
</asp:Content>
