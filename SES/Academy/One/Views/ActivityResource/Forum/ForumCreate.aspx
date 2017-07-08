<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ForumCreate.aspx.cs" Inherits="One.Views.ActivityResource.Forum.ForumCreate" %>



<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Views/RestrictionAccess/Custom/RestrictionUC.ascx" TagPrefix="uc1" TagName="RestrictionUC" %>


<asp:Content runat="server" ID="contnet1" ContentPlaceHolderID="Body">
    <div class="create-edit-whole">
        <h3 class="heading-of-create-edit">
            <asp:Label ID="lblHeading" runat="server" Text="Add New Forum"></asp:Label>
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
                        
                        <tr>
                            <td class="data-type">Forum type</td>
                            <td>
                                <asp:DropDownList ID="ddlForumType" runat="server">
                                    <Items>
                                        <asp:ListItem Value="0" Text="A single simple discussion"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Each person posts one discussion"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Q and A forum"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="Standard Forum displayed in a blog like format"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="Standard forum for general use" Selected="True"></asp:ListItem>
                                    </Items>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <%-- section end --%>

            <div class="data-entry-section">
                <div class="data-entry-section-heading">
                    Attachments and word count
                    <hr />
                </div>
                <div class="data-entry-section-body">
                    <table>
                        <tr>
                            <td class="data-type">Maximum attachment size</td>
                            <td class="data-value">
                                <asp:DropDownList ID="ddlMaximumAttachmentSize" runat="server" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Maximum Number of attachments </td>
                            <td class="data-value">
                                <asp:DropDownList ID="ddlMaximumNoOfAttachments" runat="server" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Display word count </td>
                            <td class="data-value">
                                <asp:DropDownList ID="ddlDisplayWordCount" runat="server">
                                    <Items>
                                        <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                    </Items>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>


            <div class="data-entry-section">
                <div class="data-entry-section-heading">
                    Subscription and tracking
                    <hr />
                </div>
                <div class="data-entry-section-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                               <tr>
                                    <td class="data-type">Subscription mode</td>
                                    <td class="data-value">
                                        <asp:DropDownList ID="ddlSubscriptionMode" runat="server">
                                            <Items>
                                                <asp:ListItem Value="0" Text="Optional subscription"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Forced subscription"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Auto subscription"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Subscription disabled"></asp:ListItem>
                                            </Items>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="data-type">Read tracking</td>
                                    <td class="data-value">
                                        <asp:DropDownList ID="ddlReadTracking" runat="server">
                                            <Items>
                                                <asp:ListItem Value="0" Text="Optional"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Off"></asp:ListItem>
                                            </Items>
                                        </asp:DropDownList>
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
                    Post threshold for blocking
                    <hr />
                </div>
                <div class="data-entry-section-body">
                    <table>
                        <tr>
                            <td class="data-type">Time for blocking</td>
                            <td class="data-value">
                                <asp:DropDownList ID="ddlTimeForBlocking" runat="server" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                             <td class="data-type">Post threshold for blocking</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtPostThresholdForBlocking" runat="server" Text="0" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                             <td class="data-type">Post threshold for warning</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtPostThresholdForWarning" runat="server" Text="0" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>


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
                <asp:Button ID="btnSave" runat="server" Text="Save and return to Course" OnClick="btnSave_Click"    />
                &nbsp;&nbsp;
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidForumId" runat="server" Value="0" />
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
<asp:Content runat="server" ID="contentHead" ContentPlaceHolderID="head">

  <%--  <script type="text/javascript" src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.min.js"></script>
    <script src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.css" rel="stylesheet" type="text/css" />--%>

    <link href="../../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />
    <link href="../../RestrictionAccess/Custom/RestrictionStyles.css" rel="stylesheet" />
    <link href="../../../Content/CSSes/TableStyles.css" rel="stylesheet" />


</asp:Content>