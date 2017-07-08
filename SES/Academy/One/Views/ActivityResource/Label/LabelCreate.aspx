<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="LabelCreate.aspx.cs" Inherits="One.Views.ActivityResource.Label.LabelCreate" %>


<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Views/RestrictionAccess/Custom/RestrictionUC.ascx" TagPrefix="uc1" TagName="RestrictionUC" %>


<asp:Content runat="server" ID="contnet1" ContentPlaceHolderID="Body">
    <div class="create-edit-whole">
        <h3 class="heading-of-create-edit">
            <asp:Label ID="lblHeading" runat="server" Text="Add New Label"></asp:Label>
        </h3>
        <hr/>
        <div class="data-entry-body">
            <div class="data-entry-section">
                <div class="data-entry-section-heading">
                    General
                    <hr />
                </div>
                <div class="data-entry-section-body">
                    <table>
                        <tr>
                            <td class="data-type">Label text</td>
                            <td class="data-value">
                                <CKEditor:CKEditorControl ID="txtLabelText" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                            </td>
                        </tr>

                    </table>
                </div>
            </div>
            <%-- section end --%>


            <div class="data-entry-section">
                <div class="data-entry-section-heading">
                    Restriction
                    <hr />
                </div>
                <div class="data-entry-section-body">
                    <uc1:RestrictionUC runat="server" ID="RestrictionUC" />
                </div>
            </div>
            <%-- section end --%>

            <div class="save-div">
                <asp:Button ID="btnSave" runat="server" Text="Save and return to Course" OnClick="btnSave_Click" />
                &nbsp;&nbsp;
            </div>
        </div>
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



