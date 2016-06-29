<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SectionUc.ascx.cs" Inherits="One.Views.Course.Section.SectionUc" %>

<asp:Panel ID="Panel1" runat="server">
    <div class="item-section">
        <div>
            <div>
                <div class="item-section-heading">
                    <div style="float: left;">
                        <asp:Label ID="lblTitle" runat="server" Text="Heading"></asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp; 
                    </div>

                    <div style="width: 62px; float: right;">

                        <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click">
                            <asp:Image ID="imgEditBtn" runat="server" ImageUrl="~/Content/Icons/Edit/edit_black_and_white.png"
                                Width="16" Height="14" />
                        </asp:LinkButton>
                    </div>
                </div>
                <%-- Heading END --%>
                <div style="float: left; width: 100%; margin-left: 30px; margin-right: 30px;">
                    <div class="item-summary">
                        <asp:Label ID="lblSummary" runat="server" Text="Summary"></asp:Label>
                    </div>
                </div>
                <div class="item-detail" style="margin: 0 20px 5px; padding: 0 20px 0;">
                    <asp:PlaceHolder ID="pnlActAndRes" runat="server"></asp:PlaceHolder>
                    <%--<asp:PlaceHolder ID="pnlResource" runat="server"></asp:PlaceHolder>--%>
                </div>
            </div>
            <asp:Panel ID="Panel2" runat="server">
                <div style="float: right;">
                    <div>
                        <asp:LinkButton ID="lnkAddActOrRes" runat="server" OnClick="lnkAddActOrRes_Click">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                            Add an Activity or Resource
                        </asp:LinkButton>
                    </div>
                </div>
                <%-- <div class="float-right">
                    hello
                </div>--%>
            </asp:Panel>

            <div>
                <div style="float: left; width: 100%;">
                    <hr style="margin-right: 20px; margin-left: 20px;" />
                </div>
            </div>
            <div style="float: right; width: 100%;">
            </div>
            <%--<div class="item-message">
            <asp:PlaceHolder ID="pnlMessages" runat="server"></asp:PlaceHolder>
        </div>--%>

            <asp:HiddenField ID="hid" runat="server" Value="0" />

            <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />

        </div>
        <div style="float: left; width: 100%;">
            <asp:Panel runat="server" ID="panel5"></asp:Panel>
        </div>
    </div>

</asp:Panel>
