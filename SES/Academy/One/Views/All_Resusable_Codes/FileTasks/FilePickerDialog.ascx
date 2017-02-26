﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FilePickerDialog.ascx.cs" Inherits="One.Views.All_Resusable_Codes.FileTasks.FilePickerDialog" %>


<%@ Register Src="~/Views/All_Resusable_Codes/FileTasks/FilePicker.ascx" TagPrefix="uc1" TagName="FilePicker" %>




<div class="whole-body">
    <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">open dialog</asp:LinkButton>--%>
    <%-- whole body --%>
    <%--<ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server" />--%>
    <%-- <asp:UpdatePanel ID="updatePanelDialog" runat="server">
        <ContentTemplate>--%>
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
                    <%--<asp:DataList ID="dataList" runat="server" OnItemCommand="dataList_ItemCommand">
                                <ItemTemplate>
                                    <div class="dialog-item-div">
                                        <asp:LinkButton ID="lnkRestrictChoose"
                                            
                                            CssClass="dialog-item" CausesValidation="False"
                                            Font-Underline="False"
                                            BorderColor="lightgrey"
                                            CommandName='<<%# GetClickMode() %>'
                                            CommandArgument='<%#  Eval("Id")+","+Eval("Name") %>'
                                            runat="server">
                                                    <%# Eval("Name")%>
                                        </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                                <SelectedItemStyle BackColor="lightblue"></SelectedItemStyle>
                            </asp:DataList>--%>

                    <uc1:FilePicker runat="server" ID="FilePicker1" />

                    <asp:Panel ID="pnlItemsControl" runat="server"></asp:Panel>

                </div>
                <%-- <div>hello this is custom ..</div>
                        <div class="button-div" runat="server" id="buttonsDiv">
                            <span class="button-span">&nbsp;
                                <asp:Button ID="btnDialogSave" runat="server" Text="Save" Width="70px" Visible="False" 
                                  CausesValidation="False"  OnClick="btnDialogSave_Click" />
                                &nbsp;
                                <asp:Button ID="btnDialogOk" runat="server" Text="Ok" Width="70px" Visible="False" 
                                  CausesValidation="False"  OnClick="btnDialogOk_Click" />
                                &nbsp;
                                <asp:Button ID="btnDialogCancel" runat="server" Text="Cancel" Width="70px" Visible="False" 
                                  CausesValidation="False"  OnClick="btnDialogCancel_Click" />
                                &nbsp;
                            </span>
                        </div>--%>
            </div>
        </div>
        <asp:HiddenField ID="hidItemClickMode" runat="server" Value="" />
        <asp:HiddenField ID="hidPageKey" runat="server" Value="" />
        <asp:HiddenField ID="hidFileSaveDirectory" runat="server" Value="" />
        <asp:HiddenField ID="hidFileAcquireMode" runat="server" Value="Multiple" />
        <asp:HiddenField ID="hidFolderId" runat="server" Value="0" />
    </div>
    <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
</div>

