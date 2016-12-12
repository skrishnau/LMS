<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="FileResourceCreate.aspx.cs" Inherits="One.Views.ActivityResource.FileResource.FileResourceCreate" %>



<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Views/RestrictionAccess/Custom/RestrictionUC.ascx" TagPrefix="uc1" TagName="RestrictionUC" %>
<%@ Register Src="~/Views/ActivityResource/FileResource/FileResourceItems/FilesDisplay.ascx" TagPrefix="uc1" TagName="FilesDisplay" %>

<%@   Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="ajax"%>

<%--<%@ Register Src="~/Views/All_Resusable_Codes/Dialog/CustomDialog.ascx" TagPrefix="uc1" TagName="CustomDialog" %>--%>


<asp:Content runat="server" ID="headcontent1" ContentPlaceHolderID="head">
    <link href="../../RestrictionAccess/Custom/RestrictionStyles.css" rel="stylesheet" />
    <link href="../../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />
</asp:Content>


<asp:Content runat="server" ID="contnet1" ContentPlaceHolderID="Body">
    <div class="create-edit-whole">
        <h3 class="heading-of-create-edit">
            <asp:Label ID="lblHeading" runat="server" Text="File Edit"></asp:Label>
        </h3>
        <div class="data-entry-body">
            <div class="data-entry-section">
                <div class="data-entry-section-heading">
                    General
                    <hr />
                </div>
                <div class="data-entry-section-body">
                    <table>
                        <tr>
                            <td class="data-type">Name *</td>
                            <td class="data-entry">
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" 
                                    ForeColor="red"
                                    runat="server" 
                                    ControlToValidate="txtName"
                                    ErrorMessage="Required"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Description</td>
                            <td class="data-entry">
                                <CKEditor:CKEditorControl ID="CKEditor1" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Display discription on course page</td>
                            <td class="data-entry">
                                <asp:CheckBox ID="chkDisplayDescription" runat="server" />
                            </td>
                        </tr>
                        <%-- Files upload and view --%>
                        <tr>
                            <td class="data-type" >Select files</td>
                            <td>
                                <ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server" Visible="True" />
                               
                                <uc1:FilesDisplay runat="server" ID="FilesDisplay1" />

                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <%-- section end --%>

            <div class="data-entry-section">
                <div class="data-entry-section-heading">
                    Appearance
                    <hr />
                </div>
                <div class="data-entry-section-body">
                    <table>
                        <tr>
                            <td class="data-type">Display</td>
                            <td class="data-value">
                                <asp:DropDownList ID="ddlDisplay" runat="server">
                                    <Items>
                                        <asp:ListItem Value="0" Text="Automatic" Selected="True"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Embed"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Force download"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Open"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="In pop-up"></asp:ListItem>
                                    </Items>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Show size</td>
                            <td class="data-value">
                                <asp:CheckBox ID="chkShowSize" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Show type</td>
                            <td class="data-value">
                                <asp:CheckBox ID="chkShowType" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Show upload/modified date</td>
                            <td class="data-value">
                                <asp:CheckBox ID="chkShowUploadModifiedDate" runat="server" />
                            </td>
                        </tr>
                    </table>
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
                <asp:Button ID="btnSave" runat="server" Text="Save and return to Course" OnClick="btnSave_Click" />
                &nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_OnClick" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidFileId" runat="server" Value="0" />
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
