<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListSubYearUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.ListSubYearUC" %>

<%-- style="margin: 3px; padding: 8px " --%>
<div runat="server" id="panel" style="padding: 3px;">
    <asp:Panel ID="pnlBody" runat="server">
        <div class="block">
            <span style="font-weight: 600">
                <asp:HyperLink ID="lblName" runat="server">
                Name
                </asp:HyperLink>
                &nbsp;
        <asp:HyperLink ID="lnkEdit" runat="server">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
        </asp:HyperLink>
            </span>

            <br />
            <div style="margin-left: 25px">
                <table>
                    <tr runat="server" id="row_currentBatch">
                        <td>
                            <asp:HyperLink ID="lnkCurrentBatch" runat="server">
                                <span style="font-weight: 500; font-style: italic;">Current Batch: </span>&nbsp;
                            <asp:Label ID="lblCurrentBatch" runat="server" Text=" N/A "></asp:Label>
                            </asp:HyperLink>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:HyperLink ID="lnkCoursesList" runat="server">
                                <span style="font-weight: 500; font-style: italic;">No. Of Courses: &nbsp;</span>
                                <asp:Label ID="lblNoOfCourses" runat="server" Text="0"></asp:Label>
                            </asp:HyperLink>
                            <%-- <div style="float: right; position: absolute; background-color: red; min-height: 900px; min-width: 100px;">
                            <asp:Panel ID="pnlcourseList" runat="server"></asp:Panel>
                        </div>--%>
                        </td>
                        <%--<td>&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="HyperLink3" runat="server">
                            <span style="font-weight: 500; font-style: italic;">No. Of Students: &nbsp;</span>
                            <asp:Label ID="lblNoOfStudents" runat="server" Text="0"></asp:Label>
                        </asp:HyperLink>

                    </td>--%>
                    </tr>
                </table>

            </div>
            <div>
                <asp:HyperLink ID="lnkAdd" runat="server" Visible="False" CssClass="link">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                    <asp:Literal ID="lblAddText" runat="server" Text=""></asp:Literal>
                </asp:HyperLink>
            </div>
        </div>

        <%--<asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>--%>
        <%--<asp:HiddenField ID="hidStructureId" Value="0" runat="server" />--%>
        <asp:HiddenField ID="hidStructureType" Value="0" runat="server" />
        <asp:HiddenField ID="hidYearId" runat="server" />
        <asp:HiddenField ID="hidSubYearId" runat="server" />

    </asp:Panel>
</div>
