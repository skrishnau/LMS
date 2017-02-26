<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileDeleteDialogUc.ascx.cs" Inherits="One.Views.FileManagement.FileDeleteDialogUc" %>



<div class="whole-body">
    <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">open dialog</asp:LinkButton>--%>
    <%-- whole body --%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div runat="server" id="dialogdiv" visible="False" class="whole-body">
                <%-- background --%>
                <div class="dialog-body">
                </div>
                <%-- Dialog part --%>
                <div>
                    <div style=""
                        class="popup dialog-content">
                        <div id="dialog-heading" class="dialog-heading">
                            <asp:Label ID="lblHeading" runat="server"
                                ForeColor="white" Font-Size="1.2em"
                                Text="Heading here"></asp:Label>
                            <div style="float: right;">
                                <asp:LinkButton ID="btnDialogClose" runat="server"
                                    OnClick="btnDialogClose_Click" CausesValidation="False">
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Close/white_cross.png" />
                                </asp:LinkButton>
                            </div>
                            <div style="clear: both;"></div>
                        </div>
                        <div class="item-div">
                            Are you sure to delete
                            “<asp:Label ID="lblFileName" runat="server" Text="Label"></asp:Label>”
                            ?
                            <%--<br />--%>
                            <%-- <asp:Button ID="btnOkay" runat="server" Text="Ok" />
                            &nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" />--%>

                            <%--<uc1:FolderAddUc runat="server" ID="FolderAddUc1" />--%>

                            <asp:Panel ID="pnlItemsControl" runat="server"></asp:Panel>

                        </div>
                        <div class="button-div" runat="server" id="buttonsDiv">
                            <span class="button-span">&nbsp;
                               <%-- <asp:Button ID="btnDialogSave" runat="server" Text="Save" Width="70px" Visible="False" 
                                  CausesValidation="False"  OnClick="btnDialogSave_Click" />
                                &nbsp;--%>
                                <asp:Button ID="btnDialogOk" runat="server" Text="Ok" Width="70px" 
                                    CausesValidation="False" OnClick="btnDialogOk_Click" />
                                &nbsp;
                                <asp:Button ID="btnDialogCancel" runat="server" Text="Cancel" Width="70px"
                                    CausesValidation="False" OnClick="btnDialogCancel_Click" />
                                &nbsp;
                            </span>
                        </div>

                    </div>
                </div>
                <asp:HiddenField ID="hidItemClickMode" runat="server" Value="" />
                <asp:HiddenField ID="hidParentFolderId" runat="server" Value="0" />
                <asp:HiddenField ID="hidFileId" runat="server" Value="0" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>



