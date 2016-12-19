<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="AssignmentCreate.aspx.cs" Inherits="One.Views.ActivityResource.Assignments.AssignmentCreate" %>

<%--<%@ Register Src="~/Views/RestrictionAccess/Main/RestrictionMainUC.ascx" TagPrefix="uc1" TagName="RestrictionMainUC" %>--%>
<%@ Register Src="~/Views/RestrictionAccess/Custom/RestrictionUC.ascx" TagPrefix="uc1" TagName="RestrictionUC" %>



<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Views/ActivityResource/Class/ClassesInActivityChoose.ascx" TagPrefix="uc1" TagName="ClassesInActivityChoose" %>





<asp:Content runat="server" ID="titleContent" ContentPlaceHolderID="title">
    Assignment edit
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">

    <div class="data-entry-body">
        <h3 class="heading-of-create-edit"> Assignment edit
        </h3>
        <hr />
        <br />


        <%-- style="margin: 0 25px 0;" --%>

        <div class="data-entry-section">
            <div class="data-entry-section-heading">
                General
            </div>
            <hr />
            <div class="data-entry-section-body">

                <table>
                    <tr>
                        <td class="data-type">Name</td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Width="210px" ValidationGroup="grpAss"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" ValidationGroup="grpAss" runat="server" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="data-type">Description</td>
                        <td>

                            <%--  BasePath="/ckeditor/" --%>
                            <CKEditor:CKEditorControl ID="CKEditor1" runat="server"></CKEditor:CKEditorControl>


                            <%--<asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="74px" Width="210px"></asp:TextBox>--%>
                        </td>
                    </tr>
                    <tr>
                        <td class="data-type">Display Description</td>
                        <td>
                            <asp:CheckBox ID="chkDisplayDesc" runat="server" />
                        </td>
                    </tr>

                </table>
            </div>

            <div>
                <uc1:ClassesInActivityChoose runat="server" ID="ClassesInActivityChoose1" />
            </div>


            <br />
            <div class="data-entry-section-heading">
                Submission Date
            </div>
            <hr />
            <div class="data-entry-section-body">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="margin: 0 20px 0;">
                            <tr>
                                <td class="data-type">Submission From</td>
                                <td>
                                    <asp:TextBox ID="txtFrom" ClientIDMode="Static" runat="server" Width="210px"></asp:TextBox>
                                    <asp:CheckBox ID="chkFrom" ClientIDMode="Static" runat="server"
                                        AutoPostBack="True" Checked="True"
                                        CausesValidation="False" OnCheckedChanged="chk_CheckedChanged" />
                                     <asp:Label ID="valiFrom" runat="server" Text="Required"
                                        Visible="False"
                                        ForeColor="red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="data-type">Due Date</td>
                                <td>
                                    <asp:TextBox ID="txtDue" ClientIDMode="Static" runat="server" Width="210px"></asp:TextBox>
                                    <asp:CheckBox ID="chkDue" ClientIDMode="Static" runat="server"
                                        AutoPostBack="True" Checked="True"
                                        OnCheckedChanged="chk_CheckedChanged" CausesValidation="False" />
                                     <asp:Label ID="valiDue" runat="server" Text="Required"
                                        Visible="False"
                                        ForeColor="red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="data-type">Cut off Date</td>
                                <td>
                                    <asp:TextBox ID="txtCutOff" ClientIDMode="Static" runat="server" Width="210px"></asp:TextBox>
                                    <asp:CheckBox ID="chkCutOff" ClientIDMode="Static" runat="server"
                                        AutoPostBack="True" Checked="True"
                                        OnCheckedChanged="chk_CheckedChanged" CausesValidation="False" />
                                     <asp:Label ID="valiCutOff" runat="server" Text="Required"
                                        Visible="False"
                                        ForeColor="red"></asp:Label>
                                </td>
                            </tr>

                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <br />

            <div class="data-entry-section-heading">
                Type
            </div>
            <hr />
            <div class="data-entry-section-body">

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <table style="margin: 0 20px 0;">
                            <tr>
                                <td class="data-type">Submission Type</td>
                                <td>
                                    <asp:CheckBox ID="chkOnlineSubmission" runat="server"
                                        OnCheckedChanged="chk_CheckedChanged" Text="Online"
                                        AutoPostBack="True" CausesValidation="False" />
                                    <%--Online--%>
                            &nbsp;&nbsp; &nbsp;
                            <asp:CheckBox ID="chkFileSubmission" runat="server" Text="Files"
                                OnCheckedChanged="chk_CheckedChanged" Checked="True"
                                AutoPostBack="True" CausesValidation="False" />
                                    <%--Files--%>
                                    <%--<asp:DropDownList ID="ddlSubmissionType" runat="server" Height="21px" Width="210px"></asp:DropDownList>--%>
                                    <%--<asp:RequiredFieldValidator ID="submissionListVali"
                                ControlToValidate="ddlSubmissionType"
                                runat="server" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="data-type">Word Limit</td>
                                <td>
                                    <asp:TextBox ID="txtWordLimit" Enabled="False" runat="server"
                                        TextMode="Number"
                                        Width="210px"></asp:TextBox>
                                    <asp:Label ID="lblValiWordLimit" runat="server" Text="Required"
                                        Visible="False"
                                        ForeColor="red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="data-type">Maximum Number of Submitted Files</td>
                                <td>
                                    <asp:TextBox ID="txtMaxFiles" runat="server" Width="210px"
                                        TextMode="Number"></asp:TextBox>
                                    <asp:Label ID="lblValiMaxFile" runat="server" Text="Required"
                                        Visible="False"
                                        ForeColor="red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="data-type">Maximum Submission Size (in KB)</td>
                                <td>
                                    <asp:TextBox ID="txtMaxSize" runat="server" Width="210px"
                                        TextMode="Number"></asp:TextBox>
                                    <asp:Label ID="lblValiSubmissionSize" runat="server" Text="Required"
                                        Visible="False"
                                        ForeColor="red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <br />
            <div class="data-entry-section-heading">
                Grade
            </div>
            <hr />
            <div class="data-entry-section-body">

                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <table style="margin: 0 20px 0;">
                            <tr>
                                <td class="data-type">Grade Type</td>
                                <td>
                                    <asp:DropDownList ID="ddlGradeType" runat="server" Height="21px" Width="210px"
                                         AutoPostBack="True" DataTextField="Name" DataValueField="Id" 
                                        OnSelectedIndexChanged="ddlGradeType_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="gradeListVali"
                                        ControlToValidate="ddlGradeType"
                                        runat="server" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="data-type">Maximum Grade</td>
                                <td>
                                    <asp:TextBox ID="txtMaxGradde" runat="server" Width="210px"></asp:TextBox>
                                    <asp:DropDownList ID="ddlMaximumGrade" runat="server" Width="210px" Visible="False" 
                                        DataTextField="Value" DataValueField="Id"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="data-type">Grade to Pass</td>
                                <td>
                                    <asp:TextBox ID="txtGradeToPass" runat="server" Width="210px"></asp:TextBox>
                                    <asp:DropDownList ID="ddlGradeToPass" runat="server" Width="210px" Visible="False" DataTextField="Value" DataValueField="Id"></asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <br />

            <div class="data-entry-section-heading">
                Restriction
            <hr />
            </div>

            <div class="data-entry-section-body">
                <uc1:RestrictionUC runat="server" ID="RestrictionUC" />
            </div>
            <%--<uc1:RestrictionMainUC runat="server" id="RestrictionMainUC" />--%>



            <br />
            <div class="save-div">
                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <ContentTemplate>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnAssignmentSave" ValidationGroup="grpAss" runat="server" Text="Save" Width="100" OnClick="btnSave_Click" />
                        &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnAssignmentCancel" ValidationGroup="cancelAss" runat="server" Text="Cancel" Width="100" OnClick="btnCancel_Click" CausesValidation="False" />
                        <asp:Label ID="lblError" runat="server" Text="Couldn't Save! Please review this form." ForeColor="#FF3300" Visible="False"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>


        <div>
            <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
        </div>
    </div>
    <script type="text/javascript">
        function pageLoad() {

            $('#txtFrom').unbind();
            $("#txtFrom").datepicker();

            $("#txtCutOff").unbind();
            $("#txtCutOff").datepicker();

            $("#txtDue").unbind();
            $("#txtDue").datepicker();

        }
    </script>
    <%-- <script>
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
        </script>--%>
    <asp:HiddenField ID="hidAssignmentId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
</asp:Content>



<%--  IMPORTANT NOTE *** : tHE BELOW COMMENTED CODE NEED TO BE PLACED IN THE WEBFORM IN WHICH THIS UC IS PLACED --%>
<%-- HEAD CONTENTS --%>
<asp:Content runat="server" ID="contentHead" ContentPlaceHolderID="head">

    <script type="text/javascript" src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.min.js"></script>
    <script src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.css" rel="stylesheet" type="text/css" />

    <link href="../../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />
    <link href="../../RestrictionAccess/Custom/RestrictionStyles.css" rel="stylesheet" />
    <link href="../../../ViewsSite/User/UserStyles.css" rel="stylesheet" />


</asp:Content>
