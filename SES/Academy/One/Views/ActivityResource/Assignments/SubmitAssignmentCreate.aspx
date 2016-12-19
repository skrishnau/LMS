<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="SubmitAssignmentCreate.aspx.cs" Inherits="One.Views.ActivityResource.Assignments.SubmitAssignmentCreate" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Views/ActivityResource/FileResource/FileResourceItems/FilesDisplay.ascx" TagPrefix="uc1" TagName="FilesDisplay" %>



<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="Body">
    <h3 class="heading-of-display">
        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    </h3>
    <div class="data-entry-section-body">
        <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
    </div>
    <br />
    <br />
    <div class="data-entry-section-heading">
        Submissions
    <hr />
    </div>
    <div class="data-entry-section-body">

        <asp:Panel ID="pnlText" runat="server" Visible="False">
            <div class="data-entry-section-heading">
                Text submission
                &nbsp;<asp:Label ID="lblWordLimit" runat="server" Text="" Font-Italic="True" Font-Size="0.8em"></asp:Label>
                <hr />
            </div>
            <CKEditor:CKEditorControl ID="CKEditor1" ClientIDMode="Static" runat="server"
                OnTextChanged="CKEditor1_TextChanged"></CKEditor:CKEditorControl>
            <br />
        </asp:Panel>

        <br />

        <asp:Panel ID="pnlFileSubmit" runat="server" Visible="False">
            <div class="data-entry-section-heading">
                File Submission
                &nbsp;<asp:Label ID="lblFileLimit" runat="server" Text=""
                    Font-Italic="True" Font-Size="0.8em"></asp:Label>
                <hr />
                <uc1:FilesDisplay runat="server" ID="FilesDisplay1" />
            </div>
            <ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server" />
        </asp:Panel>
    </div>
    <br />
    <div class="data-entry-section-body">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_OnClick" />
        <asp:Label ID="lblError" runat="server"
            Visible="False" ForeColor="red"
            Text="Couldn't submit"></asp:Label>
    </div>
    <br />

    <asp:HiddenField ID="hidSubmissionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidAssignmentId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidWordLimit" runat="server" Value="0" />
    <asp:HiddenField ID="hidFileLimit" runat="server" Value="0" />
    <asp:HiddenField ID="hidUserClassId" runat="server" Value="0" />

    <asp:Literal ID="lblScript" runat="server"></asp:Literal>


</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="head">
    <link href="../../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />
    <%--    <script src="../../../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../../../ckeditor/ckeditor.js"></script>
    <script src="../../../ckeditor/adapters/jquery.js"></script>--%>
</asp:Content>


<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="title">
    Assignment Submit
</asp:Content>




