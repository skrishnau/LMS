<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="NoticeCreate.aspx.cs" Inherits="One.Views.NoticeBoard.NoticeCreate" %>



<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>



<asp:Content runat="server" ID="contentbody" ContentPlaceHolderID="Body">

    <%--<div class="data-entry">--%>
        <h3 class="heading-of-create-edit">
            <asp:Label ID="lblPageitle" runat="server" Text="New Notice Create"></asp:Label>
        </h3>
        <hr />
        <br/>
        <div class="data-entry-body">
            <div class="data-entry-section">
                <strong>General
                    <asp:Label ID="lblErrorMsg" runat="server" Text="Sorry! Couldn't Save." BackColor="#FF3300" Visible="False"></asp:Label>
                </strong>
                <hr />
                <div class="data-entry-section-body">
                    <table>
                        <tr>
                            <td class="data-type">Title:
                            </td>
                            <td class="data-place">
                                <asp:TextBox ID="txtHeading" runat="server" Width="336px" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtHeading"
                                    runat="server" ErrorMessage="Required" ValidationGroup="newValidation"
                                    ForeColor="red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td class="data-type">Publish this notice
                            </td>
                            <td class="data-place">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="chkPublish" runat="server" Checked="True" AutoPostBack="True" OnCheckedChanged="chkPublish_CheckedChanged" />
                                        &nbsp;&nbsp;&nbsp;
                                        <span>
                                            <asp:DropDownList ID="ddlPublishTo" runat="server" Height="20px" Width="160px">
                                                <Items>
                                                    <asp:ListItem Value="0" Text="Publish to everyone"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Publish to users only"></asp:ListItem>
                                                </Items>
                                            </asp:DropDownList>
                                        </span>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>

                        <tr>
                            <td class="data-type">Description:
                            </td>
                            <td class="data-place">
                                <CKEditor:CKEditorControl ID="CKEditor1" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                                <%--<asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="50px" Width="344px" />--%>
                            </td>
                        </tr>
                    </table>


                    <%--<asp:HyperLink ID="btnAddCancel" runat="server" Text="Cancel" CommandName="cancel" 
                            CausesValidation="False" ></asp:HyperLink>--%>
                </div>

            </div>
            <div class="save-div">
                <asp:Button ID="btnAddSave" ValidationGroup="newValidation" runat="server"
                    Text="Save" OnClick="btnAddSave_Click" />&nbsp;&nbsp;
            </div>
        </div>
        <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
        <asp:HiddenField ID="hidNoticeId" runat="server" Value="0" />
    <%--</div>--%>
</asp:Content>
