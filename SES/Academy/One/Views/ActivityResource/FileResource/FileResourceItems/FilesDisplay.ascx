<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilesDisplay.ascx.cs" Inherits="One.Views.ActivityResource.FileResource.FileResourceItems.FilesDisplay" %>
<%@ Register Src="~/Views/All_Resusable_Codes/Dialog/CustomDialog.ascx" TagPrefix="uc1" TagName="CustomDialog" %>
<%@ Register Src="~/Views/ActivityResource/FileResource/FileResourceItems/FilePickerDialog.ascx" TagPrefix="uc1" TagName="FilePickerDialog" %>



<div style="min-height: 90px; border: 1px solid grey;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="background-color: #ffffe1; padding: 0 5px;">

                <asp:LinkButton ID="lnkAddFile" 
                    CausesValidation="False"
                    runat="server" OnClick="lnkAddFile_Click">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/File/file_add.png" />
                </asp:LinkButton>
                <asp:LinkButton ID="lnkAddFolder"
                    CausesValidation="False"
                     runat="server" OnClick="lnkAddFolder_Click">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/File/folder_add.png" />
                </asp:LinkButton>

            </div>
            <div style="background-color: lightgray; min-height: 70px;">
                <%--<uc1:FilePicker runat="server" id="FilePicker" />--%>
                <asp:PlaceHolder ID="pnlFiles" runat="server"></asp:PlaceHolder>
            </div>
            <div>
                <uc1:FilePickerDialog runat="server" ID="FilePickerDialog1" />
                <%--<uc1:CustomDialog runat="server" ID="CustomDialog" Height_Y="100" Width_X="100"/>--%>
            </div>
            <asp:HiddenField ID="hidPageKey" runat="server" Value="0" />
        </ContentTemplate>
    </asp:UpdatePanel>

</div>
