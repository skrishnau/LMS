<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="EventCreate.aspx.cs" Inherits="One.Views.Events.EventCreate" %>

<%@ Register Src="~/Views/RestrictionAccess/DateRestrictionUC.ascx" TagPrefix="uc1" TagName="DateRestrictionUC" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>


<asp:Content runat="server" ID="content" ContentPlaceHolderID="Body">

    <div class="data-entry-body">
        <h3 class="heading-of-create-edit">New Event
        </h3>
        <hr />
        <br />

        <div class="data-entry-section">
            <div class="data-entry-section-heading">
                General
            </div>
            <hr />
            <div class="data-entry-section-body">

                <table>
                    <tr>
                        <td class="data-type">Title</td>
                        <td class="data-value">
                            <asp:TextBox ID="txtName" runat="server" Width="210px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName"
                                runat="server" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>



                    <tr>
                        <td class="data-type">Description</td>
                        <td class="data-value">

                            <%--  BasePath="/ckeditor/" --%>
                            <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server"></CKEditor:CKEditorControl>


                            <%--<asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="74px" Width="210px"></asp:TextBox>--%>
                        </td>
                    </tr>
                    <tr runat="server" id="publishRow" visible="False">
                        <td class="data-type">Publish to</td>
                        <td class="data-value">
                            <asp:DropDownList ID="ddlPublish" runat="server" Width="101px">
                                <Items>
                                    <asp:ListItem Value="0" Text="Self"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Public"></asp:ListItem>
                                </Items>
                            </asp:DropDownList>
                        </td>
                    </tr>

                </table>
            </div>

        </div>
        <br />

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="data-entry-section">
                    <div class="data-entry-section-heading">
                        Time and Venue
                    </div>
                    <hr />

                    <div class="data-entry-section-body">
                        <table>
                            <tr>
                                <td class="data-type">Time
                                </td>
                                <td class="data-value">
                                    <uc1:DateRestrictionUC runat="server" ID="DateRestrictionUC1" ShowRemoveButton="False"
                                        ShowFromUntilOption="False" LoadOnAutoPostback="False" />
                                </td>
                            </tr>
                            <tr>
                                <td class="data-type">Venue
                                </td>
                                <td class="data-value">
                                    <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="save-div">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="70px" />
                    &nbsp;<asp:Label ID="lblError" runat="server" Text="Error while saving." Visible="False" ForeColor="red"></asp:Label>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <asp:HiddenField ID="hidEventId" runat="server" Value="0" />
</asp:Content>

<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    New Event
</asp:Content>
