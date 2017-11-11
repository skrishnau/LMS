<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="NoticeCreate.aspx.cs" Inherits="One.Views.NoticeBoard.NoticeCreate" %>



<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>


<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="contentbody" ContentPlaceHolderID="Body">

    <%--<div class="data-entry">--%>
    <h3 class="heading-of-create-edit">
        <asp:Label ID="lblPageitle" runat="server" Text="Notice edit"></asp:Label>
    </h3>
    <hr />
    <br />
    <div class="panel panel-default">
        <div class="panel-heading">
            General
                    <asp:Label ID="lblErrorMsg" runat="server" Text="Sorry! Couldn't Save." BackColor="#FF3300" Visible="False"></asp:Label>

        </div>
        <div class="panel-body">
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="CKEditor1"
                            runat="server" ErrorMessage="Required" ValidationGroup="newValidation"
                            ForeColor="red"></asp:RequiredFieldValidator>
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
        <asp:Button ID="btnCancel" ValidationGroup="nogrp" runat="server"
            Text="Cancel" OnClick="btnCancel_OnClick" />&nbsp;&nbsp;
    </div>
    <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
    <asp:HiddenField ID="hidNoticeId" runat="server" Value="0" />
    <%--</div>--%>
</asp:Content>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="title">
    Notice edit
</asp:Content>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="head">
    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>
