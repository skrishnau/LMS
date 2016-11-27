<%@ Page Language="C#" MasterPageFile="~/ViewsSite/DashBoard/StudentMaster.Master" AutoEventWireup="true" CodeBehind="CourseSectionListing.aspx.cs" Inherits="One.ViewsSite.DashBoard.Student.CourseSection.CourseSectionListing" %>

<%--<%@ Register Src="~/Views/Course/Display/EachCourse/CourseDetailUc.ascx" TagPrefix="uc1" TagName="CourseDetailUc" %>--%>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="item-detail">
                <asp:Literal ID="txtSubjectName" runat="server"></asp:Literal>
            </div>
            <%--<uc1:CourseDetailUc runat="server" Id="CourseDetailUc1" />--%>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
