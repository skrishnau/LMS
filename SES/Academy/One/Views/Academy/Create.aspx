<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.Academy.Create" %>



<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-create-edit">
        <asp:Label ID="lblHeading" runat="server" Text="Academic year edit"></asp:Label>
    </h3>
    <hr />


    <div class="panel panel-default">
        <div class="panel-heading">
            General
            <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
            <small class="text-muted">
                <asp:Label ID="lblFromSessionNotice" runat="server"
                    Visible="False">
                    <br />
                    <asp:Image ID="imgNotice" runat="server" ImageUrl="~/Content/Icons/Notice/Warning_Shield_16px.png" />
                    You have to create session before starting it.
                </asp:Label>
            </small>
        </div>

        <div class="panel-body">
            <table>
                <%-- Academic year Info --%>
                <tr>
                    <td class="data-type"><strong>Academic year</strong></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="data-type" style="margin-left: 10px;">Academic year Name *</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtName" runat="server" Width="145px" ToolTip="Usually its year. e.g. 2017"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="txtName" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                <tr>
                    <td class="data-type" style="margin-left: 10px;">&nbsp;&nbsp;&nbsp;&nbsp;Start Date *</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtAcademicStart" runat="server" ClientIDMode="Static"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="valiAcademicStart" runat="server"
                            ControlToValidate="txtAcademicStart" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td class="data-type" style="margin-left: 10px;">&nbsp;&nbsp;&nbsp;&nbsp;End Date *</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtAcademicEnd" runat="server" ClientIDMode="Static"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="valiAcademicEnd" runat="server"
                            ControlToValidate="txtAcademicEnd" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>

                    </td>
                </tr>


                <%-- Session 1 Info --%>
                <tr>
                    <td class="data-type"><strong>Session-1</strong></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="data-type" style="margin-left: 10px;">Session-1 Name *</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtSession1Name" runat="server" Width="145px" ToolTip="e.g. FALL, SPRING"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtSession1Name" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                <tr>
                    <td class="data-type" style="margin-left: 10px;">&nbsp;&nbsp;&nbsp;&nbsp;Start Date *</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtSession1Start" runat="server" ClientIDMode="Static"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="valiSession1Start" runat="server"
                            ControlToValidate="txtSession1Start" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td class="data-type" style="margin-left: 10px;">&nbsp;&nbsp;&nbsp;&nbsp;End Date *</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtSession1End" runat="server" ClientIDMode="Static"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="valiSession1End" runat="server"
                            ControlToValidate="txtSession1End" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <%-- Session-2 Info --%>
                <tr>
                    <td class="data-type"><strong>Session-2</strong></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="data-type" style="margin-left: 10px;">Session-2 Name *</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtSession2Name" runat="server" Width="145px" ToolTip="e.g. FALL, SPRING"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                            ControlToValidate="txtSession2Name" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                <tr>
                    <td class="data-type" style="margin-left: 10px;">&nbsp;&nbsp;&nbsp;&nbsp;Start Date *</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtSession2Start" runat="server" ClientIDMode="Static"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="valiSession2Start" runat="server"
                            ControlToValidate="txtSession2Start" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td class="data-type" style="margin-left: 10px;">&nbsp;&nbsp;&nbsp;&nbsp;End Date *</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtSession2End" runat="server" ClientIDMode="Static"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="valiSession2End" runat="server"
                            ControlToValidate="txtSession2End" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>

                    </td>
                </tr>



                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td class="data-type"><strong>New Batch</strong></td>
                </tr>

                <tr>
                    <td class="data-type" style="margin-left: 10px;">Batch Name *</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtBatchName" runat="server" Width="145px" ToolTip="new batch that will be admitted in this academic year"></asp:TextBox>
                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtBatchName" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>

            </table>
        </div>
    </div>



    <div class="panel panel-default">

        <div class="panel-heading">
            Programs to include in this batch
        </div>

        <div class="panel-body">
            <table>
                <tr>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <%--<asp:CheckBox ID="chkSelectAll" runat="server"
                                    AutoPostBack="True" Text="Select all"
                                    OnCheckedChanged="chkSelectAll_CheckedChanged" />--%>
                                <div style="margin-left: 10px;">
                                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" Font-Bold="False"></asp:CheckBoxList>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <asp:HiddenField ID="hidAcademicYearId" runat="server" Value="0" />
            <asp:HiddenField ID="hidSession1Id" runat="server" Value="0" />
            <asp:HiddenField ID="hidSession2Id" runat="server" Value="0" />
        </div>
    </div>

    <div class="save-div">
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click"
            Text="Save" />
        &nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" ValidationGroup="none"
                    Text="Cancel" OnClick="btnCancel_OnClick" />
        &nbsp;
                <asp:Label ID="lblError" runat="server" Text="Error while saving." ForeColor="red"></asp:Label>
    </div>
</asp:Content>

<asp:Content runat="server" ID="headContent" ContentPlaceHolderID="head">
    <%--<link rel="stylesheet" href="../../../DatePickerJquery/jquery-ui-1.9.2.custom.css" />
    <script src="../../../DatePickerJquery/jquery-1.8.3.js"></script>--%>
    <script type="text/javascript" src="../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.min.js"></script>
    <script src="../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.js" type="text/javascript"></script>
    <link href="../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.css" rel="stylesheet" type="text/css" />

    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />

    <script>
        function pageLoad() {

            $("#txtAcademicStart").unbind();
            $("#txtAcademicStart").datepicker();
            $("#txtAcademicEnd").unbind();
            $("#txtAcademicEnd").datepicker();

            $("#txtSession1Start").unbind();
            $("#txtSession1Start").datepicker();
            $("#txtSession1End").unbind();
            $("#txtSession1End").datepicker();

            $("#txtSession2Start").unbind();
            $("#txtSession2Start").datepicker();
            $("#txtSession2End").unbind();
            $("#txtSession2End").datepicker();
        }


    </script>

    <style type="text/css">
        .cell-width {
            width: 75px;
        }

        .auto-style1 {
            width: 104px;
        }
    </style>
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="title">
    Academic Year edit
</asp:Content>

