<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="LabelCreate.aspx.cs" Inherits="One.Views.ActivityResource.Label.LabelCreate" %>


<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Views/RestrictionAccess/Custom/RestrictionUC.ascx" TagPrefix="uc1" TagName="RestrictionUC" %>


<asp:Content runat="server" ID="contnet1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-create-edit">
        <asp:Label ID="lblHeading" runat="server" Text="Add New Label"></asp:Label>
    </h3>
    <hr />
    <div class="panel panel-default">
        <div class="panel-heading">
            General
        </div>
        <div class="panel-body">
            <table>
                <tr>
                    <td class="data-type">Label text</td>
                    <td class="data-value">
                        <CKEditor:CKEditorControl ID="txtLabelText" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                       <asp:Label runat="server" ID="lblTextError" ForeColor="red" Visible="False" Text="Required"></asp:Label>
                    </td>
                </tr>

            </table>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-heading">
            Restriction
        </div>
        <div class="panel-body">
            <uc1:RestrictionUC runat="server" ID="RestrictionUC" />
        </div>
    </div>
    <div class="save-div">
        <asp:Button ID="btnSave" runat="server" Text="Save and return to Course" OnClick="btnSave_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" ValidationGroup="cancelgrp" Text="Cancel" OnClick="btnCancel_OnClick" />
    </div>

    <asp:HiddenField ID="hidLabelId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidPageKey" runat="server" Value="0" />

    <script type="text/javascript">
        CKEDITOR.replace(CKEditor1,
            {
                enterMode: CKEDITOR.ENTER_DIV

            });
    </script>
</asp:Content>
<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    Label Edit
</asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link href="../../RestrictionAccess/Custom/RestrictionStyles.css" rel="stylesheet" />
    <link href="../../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />
    <link href="../../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>



