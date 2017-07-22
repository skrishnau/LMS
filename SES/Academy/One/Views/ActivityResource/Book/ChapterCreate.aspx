<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ChapterCreate.aspx.cs" Inherits="One.Views.ActivityResource.Book.ChapterCreate" %>



<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%--<%@ Register Src="~/Views/RestrictionAccess/Custom/RestrictionUC.ascx" TagPrefix="uc1" TagName="RestrictionUC" %>--%>


<asp:Content runat="server" ID="contentbody1" ContentPlaceHolderID="Body">
    <div class="create-edit-whole">
        <h3 class="heading-of-create-edit">
            <asp:Label ID="lblHeading" runat="server" Text="Add new chapter "></asp:Label>
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
                            <td class="data-type">Chapter title *</td>
                            <td class="data-entry">
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="reqName" runat="server" 
                                    ControlToValidate="txtName"
                                    ErrorMessage="Required" ForeColor="red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td class="data-type">Subchapter</td>
                            <td class="data-entry">
                                <asp:CheckBox ID="chkSubChapter" runat="server" Enabled="False" />
                            </td>
                        </tr>

                        <tr>
                            <td class="data-type">Content *</td>
                            <td class="data-entry">
                                <CKEditor:CKEditorControl ID="CKEditor1" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                            </td>
                        </tr>
                       <%-- <tr>
                            <td class="data-type">Display discription on course page</td>
                            <td class="data-entry">
                                <asp:CheckBox ID="chkDisplayDescription" runat="server" />
                            </td>
                        </tr>--%>

                    </table>
                </div>
            </div>
            <%-- section end --%>

            <div class="save-div">
                <asp:Button ID="btnSave" runat="server" Text="Save " Width="90px" OnClick="btnSave_Click" />
                &nbsp;&nbsp;
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidBookId" runat="server" Value="0" />
    <asp:HiddenField ID="hidParentChapterId" runat="server" Value="0" />
    <asp:HiddenField ID="hidChapterId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />

</asp:Content>