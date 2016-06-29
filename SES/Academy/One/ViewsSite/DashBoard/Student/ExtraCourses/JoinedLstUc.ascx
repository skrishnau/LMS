<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JoinedLstUc.ascx.cs" Inherits="One.ViewsSite.DashBoard.Student.ExtraCourses.JoinedLstUc" %>
<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlOptions" runat="server">
                <div style="text-align: right;">
                    <div>
                        <asp:LinkButton ID="lnkJoin" runat="server" OnClick="lnkJoin_Click">Other Courses</asp:LinkButton>
                    </div>
                </div>
            </asp:Panel>

            <asp:PlaceHolder ID="pnlJoinedCourseList" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="pnlUnJoinedCourseList" runat="server" Visible="false"></asp:PlaceHolder>

            <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
            <asp:HiddenField ID="hidAcademicYear" runat="server" Value="0" />
            <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />
            <asp:HiddenField ID="hidStudentId" runat="server" Value="0" />
            <asp:HiddenField ID="hidUserType" runat="server" Value="0" />
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
