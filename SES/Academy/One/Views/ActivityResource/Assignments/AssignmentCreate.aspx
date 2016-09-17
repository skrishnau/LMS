<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="AssignmentCreate.aspx.cs" Inherits="One.Views.ActivityResource.Assignments.AssignmentCreate" %>

<%@ Register Src="~/Views/RestrictionAccess/Main/RestrictionMainUC.ascx" TagPrefix="uc1" TagName="RestrictionMainUC" %>



<asp:Content runat="server" ID="headContent" ContentPlaceHolderID="title">
    Assignment create
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">

    <div>
        <style type="text/css">
            .auto-style1 {
                width: 250px;
            }
        </style>

        <script>
            $(function () {
                //$("#dialog-1").dialog({
                //    autoOpen: false,
                //});
                //$("#opener").click(function () {
                //    $("#dialog-1").dialog("open");
                //});
                $("#txtFrom").datepicker();
                $("#txtCutOff").datepicker();
                $("#txtDue").datepicker();
            });
        </script>
        <div>
            <div class="form-title">
                <strong>New Assignment</strong>
            </div>
            <br />
            <asp:HiddenField ID="hidAssignmentId" runat="server" Value="0" />
            <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
            <br />
            <%-- style="margin: 0 25px 0;" --%>
            <div class="form-body">
                <strong>General</strong>
                <hr />
                <table style="margin: 0 20px 0;">
                    <tr>
                        <td class="auto-style1">Name</td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Width="210px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" runat="server" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Description</td>
                        <td>
                            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="74px" Width="210px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Display Description</td>
                        <td>
                            <asp:CheckBox ID="chkDisplayDesc" runat="server" />
                        </td>
                    </tr>

                </table>
                <br />
                <strong>Submission Date</strong>
                <hr />
                <table style="margin: 0 20px 0;">
                    <tr>
                        <td class="auto-style1">Submission From</td>
                        <td>
                            <asp:TextBox ID="txtFrom" runat="server" Width="210px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Due Date</td>
                        <td>
                            <asp:TextBox ID="txtDue" runat="server" Width="210px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Cut off Date</td>
                        <td>
                            <asp:TextBox ID="txtCutOff" runat="server" Width="210px"></asp:TextBox>
                        </td>
                    </tr>

                </table>
                <br />
                <strong>Type</strong>
                <hr />
                <table style="margin: 0 20px 0;">
                    <tr>
                        <td class="auto-style1">Submission Type</td>
                        <td>
                            <asp:DropDownList ID="ddlSubmissionType" runat="server" Height="21px" Width="210px"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="submissionListVali"
                                ControlToValidate="ddlSubmissionType"
                                runat="server" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Word Limit</td>
                        <td>
                            <asp:TextBox ID="txtWordLimit" runat="server" Width="210px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Maximum Number of Submitted Files</td>
                        <td>
                            <asp:TextBox ID="txtMaxFiles" runat="server" Width="210px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Maximum Submission Size</td>
                        <td>
                            <asp:TextBox ID="txtMaxSize" runat="server" Width="210px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <strong>Grade</strong>
                <hr />
                <table style="margin: 0 20px 0;">
                    <tr>
                        <td class="auto-style1">Grade Type</td>
                        <td>
                            <asp:DropDownList ID="ddlGradeType" runat="server" Height="21px" Width="210px"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="gradeListVali"
                                ControlToValidate="ddlGradeType"
                                runat="server" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Maximum Grade</td>
                        <td>
                            <asp:TextBox ID="txtMaxGradde" runat="server" Width="210px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Grade to Pass</td>
                        <td>
                            <asp:TextBox ID="txtGradeToPass" runat="server" Width="210px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <div>
                    <strong>Restriction</strong>
                    <hr />
                    <uc1:RestrictionMainUC runat="server" id="RestrictionMainUC" />
                </div>
                <br />
                <hr />
                <br />
                <div style="text-align: left; padding: 5px 20px 5px">
                    <asp:Label ID="txtErrorMsg" runat="server" Text="Sorry, Couldn't Save !" ForeColor="#FF3300" Visible="False"></asp:Label>
                    &nbsp;&nbsp;
                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="100" OnClick="btnSave_Click" />
                    &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100" OnClick="btnCancel_Click" CausesValidation="False" />
                </div>
            </div>
            <div>
                <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
            </div>
        </div>
    </div>

</asp:Content>



<%--  IMPORTANT NOTE *** : tHE BELOW COMMENTED CODE NEED TO BE PLACED IN THE WEBFORM IN WHICH THIS UC IS PLACED --%>
<%-- HEAD CONTENTS --%>
<asp:Content runat="server" ID="contentHead" ContentPlaceHolderID="head">

    <script type="text/javascript" src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.min.js"></script>
    <script src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.css" rel="stylesheet" type="text/css" />
    
    <link href="../../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />

    <style type="text/css">
        .img-close:hover {
            background-color: orangered;
        }

        .img-close {
        }

        .btnAdd_Restriction {
            width: 80px;
        }

        .restriction-main {
            border: 2px solid darkgray;
            margin: 10px 0;
        }

        .restriction-uc-whole {
            border: 1px solid lightgrey;
            padding: 2px 2px 2px 5px;
            margin: 5px 0;
            vertical-align: central;
            background-color: lightgoldenrodyellow;
        }

        .restriction-body {
            vertical-align: central;
        }

        .display-none {
            display: none;
        }
    </style>

</asp:Content>
