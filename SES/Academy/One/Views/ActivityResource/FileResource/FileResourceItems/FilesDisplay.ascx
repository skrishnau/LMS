<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilesDisplay.ascx.cs" Inherits="One.Views.ActivityResource.FileResource.FileResourceItems.FilesDisplay" %>
<%@ Register Src="~/Views/All_Resusable_Codes/FileTasks/FilePickerDialog.ascx" TagPrefix="uc1" TagName="FilePickerDialog" %>

<%--<%@ Register Src="~/Views/All_Resusable_Codes/Dialog/CustomDialog.ascx" TagPrefix="uc1" TagName="CustomDialog" %>--%>
<%--<%@ Register Src="~/Views/ActivityResource/FileResource/FileResourceItems/FilePickerDialog.ascx" TagPrefix="uc1" TagName="FilePickerDialog" %>--%>


<div style="border: 1px solid grey;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <asp:Label ID="lblFileNumberError" runat="server" Text="" Visible="False" ForeColor="red"></asp:Label>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <div class="file-display">
                        <asp:LinkButton ID="lnkAddFile"
                            CausesValidation="False" Font-Underline="False"
                            BorderStyle="None" ForeColor="white"
                            runat="server" OnClick="lnkAddFile_Click">
                            <asp:Image ID="Image1" runat="server" Width="22" Height="22"
                                ImageUrl="~/Content/Icons/Add/add-new-document.png"
                                ToolTip="File add" />
                        </asp:LinkButton>
                        &nbsp;
                        <asp:LinkButton ID="lnkAddFolder"
                            CausesValidation="False" Font-Underline="False" ForeColor="white"
                            runat="server" OnClick="lnkAddFolder_Click">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Add/folder-black-shape-with-a-plus-sign.png"
                                Width="22" Height="22"
                                ToolTip="Folder add" />
                        </asp:LinkButton>
                        <div style="float: right; color: white;">
                            <asp:Literal ID="lblNoOfFiles" runat="server" ></asp:Literal>
                        </div>
                        <div style="clear: both;"></div>
                    </div>
                </asp:View>
                <%-- ========================================================================== --%>
                <asp:View ID="View2" runat="server">
                    <asp:LinkButton ID="lnkSingleFileAdd"
                        CssClass="link"
                        CausesValidation="False" Font-Underline="False"
                        BorderStyle="None"
                        runat="server" OnClick="lnkAddFile_Click">
                        <asp:Image ID="Image3" runat="server" Width="22" Height="22"
                            ImageUrl="~/Content/Icons/File/file_replace.png"
                            ToolTip="File add" />
                        Choose
                    </asp:LinkButton>
                </asp:View>
            </asp:MultiView>
            <%-- style="background-color: #cebffd; " --%>

            <%--<div style="border: 1px solid lightgray; border-left: none; border-right: none; height: 20px;">
                <asp:PlaceHolder ID="pnlDirecotry" runat="server"></asp:PlaceHolder>
            </div>--%>
            
            <div style="clear: both; margin: 2px; border: 2px dashed lightgray; min-height: 65px; font-weight: 400;">
                <%--<uc1:FilePicker runat="server" id="FilePicker" />--%>
                <asp:Panel ID="pnlFiles" runat="server"></asp:Panel>
                <div style="clear: both;"></div>
            </div>
            <div style="clear: both;"></div>
            <div>
                <div>
                    <%--<uc1:FilePickerDialog runat="server" ID="FilePickerDialog1" />--%>
                    <uc1:FilePickerDialog runat="server" ID="FilePickerDialog1" />
                    <%--<uc1:CustomDialog runat="server" ID="CustomDialog" Height_Y="100" Width_X="100"/>--%>
                </div>
            </div>
            <asp:HiddenField ID="hidPageKey" runat="server" Value="" />
            <asp:HiddenField ID="hidNumberOfFilesToUpload" runat="server" Value="5" />
            <asp:HiddenField ID="hidFileSaveDirectory" runat="server" Value="" />
            <asp:HiddenField ID="hidFileAcquireMode" runat="server" Value="Multiple" />
        </ContentTemplate>
    </asp:UpdatePanel>

</div>
