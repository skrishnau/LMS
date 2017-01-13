<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.Academy.Session.Create" %>

<%--<%@ Register Src="~/Views/UserControls/DateChooser.ascx" TagPrefix="uc1" TagName="DateChooser" %>--%>
<%--<%@ Register Src="~/Views/Academy/Session/CreateUC.ascx" TagPrefix="uc1" TagName="CreateUC" %>--%>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">

    <%--<div>
        <uc1:CreateUC runat="server" ID="CreateUC" />
    </div>--%>


    <div class="data-entry-body">
        <h3 class="heading-of-create-edit">
            <asp:Label ID="lblHeading" runat="server" Text="Session edit "></asp:Label>
        </h3>
        <hr />

        <div class="data-entry-section">

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
                    </div>

                    <div class="save-div">
                        <%--<asp:Button ID="btnSaveAndAddMore" runat="server" OnClick="btnSave_Click" Text="Save and Add More" Width="143px" />
                        &nbsp;--%>
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
        </div>
        <%--<asp:CheckBox ID="CheckBox1" runat="server" Text="Make this currently Active Session" />--%>

        <br />

        <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />
        <asp:HiddenField ID="hidAcademicYear" runat="server" Value="0" />
    </div>




    <%-- ================================================================================== --%>
    <%--<script>
         $(function () {

             $("#txtStart").unbind();
             $("#txtStart").datepicker();

             $("#txtEnd").unbind();
             $("#txtEnd").datepicker();
         });
                </script>--%>

    <%-- <fieldset>
        
        <legend>Session</legend>
        <asp:HiddenField ID="hidId" runat="server" Value="0"/>
        <table>
            <tr>
                <td>Session Name
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="128px"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtName" ErrorMessage="Name is required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%--<tr>
                <td>School
                </td>
                <td>
                    <asp:DropDownList ID="cmbSchool" runat="server" Height="22px" Width="132px" OnSelectedIndexChanged="cmbSchool_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="cmbSchool" ErrorMessage="School is required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>--%>
    <%--   <tr>
                <td>Academic Year 
                </td>
                <td>
                    <asp:DropDownList ID="cmbAcademicYear" runat="server" Height="22px" Width="134px" AutoPostBack="True" 
                        OnSelectedIndexChanged="cmbAcademicYear_SelectedIndexChanged"></asp:DropDownList>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="cmbAcademicYear" ErrorMessage="Academic year is required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Session Type</td>
                <td>
                    <asp:TextBox ID="txtType" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Panel ID="panelStart" runat="server">
            Session Start Date &nbsp;
            <uc1:DateChooser runat="server" ID="dtStart" />
        </asp:Panel>

        <asp:Panel ID="panelEnd" runat="server">
            Session End Date &nbsp;
            <uc1:DateChooser runat="server" ID="dtEnd" />
        </asp:Panel>
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Active" />
      </fieldset> 
    
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" Width="62px" />
    --%>
</asp:Content>
<asp:Content runat="server" ID="headconetent" ContentPlaceHolderID="head">
    <script type="text/javascript" src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.min.js"></script>
    <script src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="title">
    Session edit
</asp:Content>
