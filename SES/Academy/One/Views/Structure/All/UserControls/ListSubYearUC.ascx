<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListSubYearUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.ListSubYearUC" %>

<div runat="server" id="panel" style="margin: 3px 10px 10px 0; width: 100%; padding: 3px 3px 5px 10px; background-color: lightgray">

    <div class="block">
        <span style="font-weight: 600">
            <asp:HyperLink ID="lblName" runat="server">
                Name
            </asp:HyperLink>
        </span>

        <br />
        <div style="margin-left: 25px">
            <table>
                <tr>
                    <td>
                        <asp:HyperLink ID="HyperLink1" runat="server">
                            <span style="font-weight: 500; font-style: italic;">Current Batch: </span>&nbsp;
                            <asp:Label ID="lblCurrentBatch" runat="server" Text="Not set"></asp:Label>
                        </asp:HyperLink>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:LinkButton ID="lnkCoursesList" runat="server" OnClick="lnkCoursesList_Click">
                            <span style="font-weight: 500; font-style: italic;">No. Of Courses: &nbsp;</span>
                            <asp:Label ID="lblNoOfCourses" runat="server" Text="0"></asp:Label>
                        </asp:LinkButton>
                       <%-- <div style="float: right; position: absolute; background-color: red; min-height: 900px; min-width: 100px;">
                            <asp:Panel ID="pnlcourseList" runat="server"></asp:Panel>
                        </div>--%>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;
                        <asp:HyperLink ID="HyperLink3" runat="server">
                            <span style="font-weight: 500; font-style: italic;">NO. Of Students: &nbsp;</span>
                            <asp:Label ID="lblNoOfStudents" runat="server" Text="0"></asp:Label>
                        </asp:HyperLink>

                    </td>
                </tr>
            </table>

        </div>

    </div>

    <%--<asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>--%>
    <%--<asp:HiddenField ID="hidStructureId" Value="0" runat="server" />--%>
    <asp:HiddenField ID="hidStructureType" Value="0" runat="server" />
    <asp:HiddenField ID="hidYearId" runat="server" />
    <asp:HiddenField ID="hidSubYearId" runat="server" />

    <div style="margin-left: 25px; border-left: solid lightgray 1px; background-color: aliceblue">
        <asp:PlaceHolder ID="pnlSubControls" runat="server"></asp:PlaceHolder>
    </div>
</div>
