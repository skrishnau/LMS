<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.Academy.Session.Create" %>

<%--<%@ Register Src="~/Views/UserControls/DateChooser.ascx" TagPrefix="uc1" TagName="DateChooser" %>--%>
<%--<%@ Register Src="~/Views/Academy/Session/CreateUC.ascx" TagPrefix="uc1" TagName="CreateUC" %>--%>
<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">

    <h3 class="heading-of-create-edit">
        <asp:Label ID="lblHeading" runat="server" Text="Session edit "></asp:Label>
    </h3>
    <hr />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="data-entry-section-body">

                <table>
                    <tr>
                        <td><strong>Academic year
                        </strong>
                        </td>
                        <td>
                            <strong>
                                <asp:Label ID="lblAcademicHeading" runat="server" Text=""></asp:Label>
                            </strong>
                            <table>
                                <tr>
                                    <td><strong>Start date</strong></td>
                                    <td>
                                        <asp:Label ID="lblAcademicStart" runat="server" Text=""></asp:Label></td>
                                </tr>
                                <tr>
                                    <td><strong>End date</strong></td>
                                    <td>
                                        <asp:Label ID="lblAcademicEnd" runat="server" Text=""></asp:Label></td>
                                    <br />
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="data-type">Session Name
                        </td>
                        <td class="data-value">
                            <asp:TextBox ID="txtName" runat="server" Width="128px"></asp:TextBox>
                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ValidationGroup="savegrp"
                                ControlToValidate="txtName" ErrorMessage="Name is required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="data-type">Session Start Date</td>
                        <td class="data-value">
                            <asp:TextBox ID="txtStart" runat="server" ClientIDMode="Static"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valiStartDate" runat="server"
                                ForeColor="red" ControlToValidate="txtStart"
                                ValidationGroup="savegrp"
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
                                ValidationGroup="savegrp" ErrorMessage="Required">
                            </asp:RequiredFieldValidator>
                            <%--<uc1:DateChooser runat="server" ID="dtEnd" />--%>
                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />
                <asp:HiddenField ID="hidAcademicYear" runat="server" Value="0" />
                <br />
                <div class="save-div">

                    <asp:Button ID="btnSaveAndReturn" runat="server" OnClick="btnSave_Click"
                        ValidationGroup="savegrp"
                        Text="Save" Width="83px" />
                    &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancel"
                            ValidationGroup="cancelgrp"
                            runat="server" Text="Cancel" Width="102px" OnClick="btnCancel_Click" />
                    &nbsp;
                        <asp:Label ID="lblError" runat="server" Text="Error while saving" ForeColor="red" Visible="False"></asp:Label>
                </div>

            </div>


            <script type="text/javascript">

                function pageLoad() {

                    $("#txtStart").unbind();
                    $("#txtStart").datepicker();

                    $("#txtEnd").unbind();
                    $("#txtEnd").datepicker();

                    //$('#txtFrom').unbind();
                    //$("#txtFrom").datepicker();

                    //$("#txtCutOff").unbind();
                    //$("#txtCutOff").datepicker();

                    //$("#txtDue").unbind();
                    //$("#txtDue").datepicker();

                }

            </script>

        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
<asp:Content runat="server" ID="headconetent" ContentPlaceHolderID="head">
    <script type="text/javascript" src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.min.js"></script>
    <script src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.css" rel="stylesheet" type="text/css" />
    <link href="../../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="title">
    Session edit
</asp:Content>
