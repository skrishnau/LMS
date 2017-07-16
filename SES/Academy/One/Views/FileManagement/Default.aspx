<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="Default.aspx.cs" Inherits="One.Views.FileManagement.Default" %>


<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<%@ Register Src="~/Views/FileManagement/FileListingUc.ascx" TagPrefix="uc1" TagName="FileListingUc" %>
<%@ Register Src="~/Views/All_Resusable_Codes/Dialog/CustomDialog.ascx" TagPrefix="uc1" TagName="CustomDialog" %>
<%@ Register Src="~/Views/FileManagement/FolderAddDialogUc.ascx" TagPrefix="uc1" TagName="FolderAddDialogUc" %>
<%@ Register Src="~/Views/FileManagement/FileDeleteDialogUc.ascx" TagPrefix="uc1" TagName="FileDeleteDialogUc" %>
<%@ Register Src="~/Views/All_Resusable_Codes/FileTasks/FilePickerDialog.ascx" TagPrefix="uc1" TagName="FilePickerDialog" %>





<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">File Management
    </h3>

    <div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%-- class="list-item-option" --%>
                <div class="option-div">
                    <asp:LinkButton ID="lnkAddFile" runat="server"
                        OnClick="lnkAddFile_OnClick">
                        <asp:Image ID="Image1" runat="server" Height="14" Width="14" ImageUrl="~/Content/Icons/Add/add-file-20px.png" />
                        Add File
                    </asp:LinkButton>
                    <asp:LinkButton ID="lnkAddFolder" runat="server"
                        OnClick="lnkAddFolder_OnClick">
                        <asp:Image ID="Image2" runat="server" Height="14" Width=14 ImageUrl="~/Content/Icons/Add/add-folder-20px.png" />
                        Add Folder
                    </asp:LinkButton>
                </div>


                <br />
                <div>
                    <uc1:FileListingUc runat="server" ID="FileListingUc1" />
                </div>

                <asp:HiddenField ID="hidFolderId" runat="server" Value="0" />
                <%--<asp:HiddenField ID="hidRenamingFolderId" runat="server" Value="0" />
                <asp:HiddenField ID="hidRenamingText" runat="server" Value="" />--%>

                <div style="">
                    <%--<uc1:CustomDialog runat="server" ID="CustomDialog1" />--%>
                    <uc1:FolderAddDialogUc runat="server" ID="FolderAddDialogUc1" />
                </div>
                <div>
                    <uc1:FileDeleteDialogUc runat="server" ID="FileDeleteDialogUc1" />
                </div>

                <div>
                    <uc1:FilePickerDialog runat="server" ID="FilePickerDialog1" />
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
        <ajaxToolkit:AsyncFileUpload ID="file_upload" runat="server" />
        <%--  OnUploadedComplete="file_upload_UploadedComplete" --%>
        <asp:HiddenField ID="hidIsServerFile" runat="server" Value="False" />

    </div>


</asp:Content>


<asp:Content runat="server" ID="content2" ContentPlaceHolderID="head">
    <link href="../../Content/CSSes/ToolTip.css" rel="stylesheet" />
    <link href="../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />
</asp:Content>

<asp:Content runat="server" ID="content4" ContentPlaceHolderID="title">
    File Management
</asp:Content>
