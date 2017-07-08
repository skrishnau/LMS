<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="PageCreate.aspx.cs" Inherits="One.Views.ActivityResource.Page.PageCreate" %>


<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Views/RestrictionAccess/Custom/RestrictionUC.ascx" TagPrefix="uc1" TagName="RestrictionUC" %>


<asp:Content runat="server" ID="contnet1" ContentPlaceHolderID="Body">
    <div class="create-edit-whole">
        <h3 class="heading-of-create-edit">
            <asp:Label ID="lblHeading" runat="server" Text="Add New Page"></asp:Label>
        </h3>
        <br />
        <div class="data-entry-body">
            <div class="data-entry-section">
                <div class="data-entry-section-heading">
                    General
                    <hr />
                </div>
                <div class="data-entry-section-body">
                    <table>
                        <tr>
                            <td class="data-type">Name</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtName" runat="server" Width="170"></asp:TextBox>
                            </td>
                        </tr>
                       
                        <tr>
                            <td class="data-type">Description</td>
                            <td class="data-value">
                                <CKEditor:CKEditorControl ID="txtDescription" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Display discription on course page</td>
                            <td class="data-value">
                                <asp:CheckBox ID="chkDisplayDescription" runat="server" />
                            </td>
                        </tr>

                    </table>
                </div>
            </div>
            <%-- section end --%>

            <div class="data-entry-section">
                <div class="data-entry-section-heading">
                    Content
                    <hr />
                </div>
                <div class="data-entry-section-body">
                    <table>
                        <tr>
                            <td class="data-type">Page Content</td>
                            <td class="data-value">
                                <CKEditor:CKEditorControl ID="txtContent" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>


            <div class="data-entry-section">
                <div class="data-entry-section-heading">
                    Appearance
                    <hr />
                </div>
                <div class="data-entry-section-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                               <tr>
                                    <td class="data-type">Display page name</td>
                                    <td class="data-value">
                                        <asp:CheckBox ID="chkDisplayPageName" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="data-type">Display page description</td>
                                    <td class="data-value">
                                        <asp:CheckBox ID="chkDisplayPageDescription" runat="server" />
                                        
                                    </td>
                                </tr>

                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <%-- SEction end --%>


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
                <asp:Button ID="btnSave" runat="server" Text="Save and return to Course"  OnClick="btnSave_Click"  />
                &nbsp;&nbsp;
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidUrlId" runat="server" Value="0" />
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

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link href="../../RestrictionAccess/Custom/RestrictionStyles.css" rel="stylesheet" />
    <link href="../../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />
    <link href="../../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>