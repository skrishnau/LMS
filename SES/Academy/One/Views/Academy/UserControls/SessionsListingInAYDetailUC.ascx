<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SessionsListingInAYDetailUC.ascx.cs" Inherits="One.Views.Academy.UserControls.SessionsListingInAYDetailUC" %>

<%-- style="border: 1px solid lightgrey; "class="data-entry-section" style="border: 1px solid darkgray; padding: 5px; margin: 8px 0;" --%>
<div class="auto-st2" runat="server" id="divBody">
    <%--<asp:Panel ID="pnlbody" runat="server" CssClass="auto-st1">--%>
    <strong>
        <asp:HyperLink ID="lnkSessionName" runat="server" Text="Label" CssClass="link"></asp:HyperLink></strong>
    &nbsp;         
    <asp:HyperLink ID="lnkEdit" runat="server" CssClass="link">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
    </asp:HyperLink>
    &nbsp;
    <asp:HyperLink ID="lnkDelete" runat="server" CssClass="link">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/delete/remove_icon_color.png" />
    </asp:HyperLink>
    <asp:Label ID="lblActiveIndicator" runat="server" Text=""></asp:Label>
    <div class="data-entry-section">
        <table>
            <tr>
                <td>Start Date :</td>
                <td>
                    <asp:Label ID="lblStartDate" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td>End Date &nbsp;:</td>
                <td>
                    <asp:Label ID="lblEndDate" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>

    <asp:Panel ID="pnlClasses" runat="server">

        <div class="data-entry-section">
            <div class="data-entry-section-heading">
                <div style="margin-left: 12px;">
                    Classes:
                    <div style="float: right; font-weight: 400;">
                        <asp:HyperLink ID="lnkEditClasses" runat="server" Visible="False" CssClass="link_smaller">
                            <asp:Image ID="Image3" runat="server"
                                ImageUrl="~/Content/Icons/Edit/edit_orange.png"
                                ToolTip="Edit Classes for this Session." />
                            Edit Classes
                        </asp:HyperLink>
                    </div>
                    <div style="clear: both;"></div>
                </div>
                <hr />

            </div>
            <div class="data-entry-section-body">

                <asp:Panel ID="pnlSessionPrograms" runat="server" Visible="False">

                    <div class="data-entry-section-body">

                        <asp:ListView ID="ListView1" runat="server">
                            <LayoutTemplate>
                                <table runat="server" id="table1" style="border-collapse: collapse; border: 1px solid lightgray;">
                                    <thead>
                                        <tr style="text-align: left; border: 1px solid lightgray;">
                                            <th style="width: 40%;">Group</th>
                                            <th>Study in (Year , Subyear)</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr runat="server" id="itemPlaceholder"></tr>
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <AlternatingItemTemplate>
                                <tr id="Tr1" runat="server" style="background-color: lightgoldenrodyellow;" class="auto-st2-white">
                                    <td>
                                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-st2-inline-block"
                                            NavigateUrl='<%# GetUrl(Eval("ProgramBatchId")) %>'
                                            Text='<%# GetName(Eval("ProgramBatch")) %>'></asp:HyperLink>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# GetCurrent(Eval("Year"),Eval("SubYear")) %>'></asp:Label>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                            <ItemTemplate>
                                <tr id="Tr2" runat="server" class="auto-st2-white">
                                    <td>
                                        <asp:HyperLink ID="HLabel1" runat="server" CssClass="auto-st2-inline-block"
                                            NavigateUrl='<%# GetUrl(Eval("ProgramBatchId")) %>'
                                            Text='<%# GetName(Eval("ProgramBatch")) %>'></asp:HyperLink>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# GetCurrent(Eval("Year"),Eval("SubYear")) %>'></asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </asp:Panel>

            </div>

        </div>
    </asp:Panel>


    <%--</asp:Panel>--%>
    <asp:HiddenField ID="hidAcademicYearId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />
</div>
