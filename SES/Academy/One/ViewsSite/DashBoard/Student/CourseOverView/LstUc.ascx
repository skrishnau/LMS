<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LstUc.ascx.cs" Inherits="One.ViewsSite.DashBoard.Student.CourseOverView.LstUc" %>

<style type="text/css">
    .item {
        padding: 2px;
        border: 1.8px solid darkgray;
        overflow: hidden;
        width: 97%;
    }

    .item-heading {
        font: 2em bold;
        color: #0000b3;
        /*background-color: #f0fff0;*/
        /*//font-size: 2em;*/
    }

    .item-message {
        margin-left: 20px;
    }

        .item-message :hover {
            background-color: lightgoldenrodyellow;
        }
</style>

<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%-- <asp:Panel ID="pnlOptions" runat="server">
                <div style="text-align: right;">
                    <div>
                        <asp:LinkButton ID="lnkJoin" runat="server" OnClick="lnkJoin_Click">Other Courses</asp:LinkButton>
                    </div>
                </div>
            </asp:Panel>--%>

            <asp:PlaceHolder ID="pnlCourseList" runat="server"></asp:PlaceHolder>
            <%--<asp:PlaceHolder ID="pnlUnJoinedCourseList" runat="server" Visible="false"></asp:PlaceHolder>--%>

            <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
            <asp:HiddenField ID="hidAcademicYear" runat="server" Value="0" />
            <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />
            <asp:HiddenField ID="hidStudentId" runat="server" Value="0" />
            <asp:HiddenField ID="hidUserType" runat="server" Value="0" />

            <%-- Used :: final --%>
            <asp:HiddenField ID="hidLoadType" runat="server" />
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
