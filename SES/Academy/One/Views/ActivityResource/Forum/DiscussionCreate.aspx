<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="DiscussionCreate.aspx.cs" Inherits="One.Views.ActivityResource.Forum.DiscussionCreate" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div class="create-edit-whole">
        <h3 class="heading-of-create-edit">
            <asp:Label ID="lblNewDiscussionTopic" runat="server" Text="New discussion topic"></asp:Label>
        </h3>
        <hr />

        <div class="data-entry-body">
            <div class="data-entry-section">

                <div class="data-entry-section-body">
                    <table>
                        <tr>
                            <td class="data-type">Subject *</td>
                            <td class="data-field">
                                <a id="section_m"></a>
                                <asp:TextBox ID="txtSubject" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtSubject" ForeColor="red"
                                    ErrorMessage="Required"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">
                                Message *
                            </td>
                            <td class="data-field">
                                <CKEditor:CKEditorControl ID="txtMessage" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtMessage" ForeColor="red"
                                    ErrorMessage="Required"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Subscribe to this discussion *</td>
                            <td class="data-field">
                                <asp:CheckBox ID="chkSubscribeToDiscussion" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <%--Pinned discussions will appear at the top of a forum.--%>
                            <td class="data-type">Pinned *</td>
                            <td class="data-field">
                                <asp:CheckBox ID="chkPinned" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="save-div">
                    <asp:Button ID="btnPost" runat="server" Text="Post to forum" OnClick="btnPost_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                </div>
                <asp:HiddenField ID="hidForumId" runat="server" Value="0" />
                <asp:HiddenField ID="hidParentDiscussionId" runat="server" Value="0" />
                <asp:HiddenField ID="hidMainDiscussionId" runat="server" Value="0" />
                <asp:HiddenField ID="hidDiscussionId" runat="server" Value="0" />
                <asp:HiddenField ID="hidPageKey" runat="server" Value="" />
                
                <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
                <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
            </div>
        </div>
    </div>
</asp:Content>
