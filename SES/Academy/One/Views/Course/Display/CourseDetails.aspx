<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="CourseDetails.aspx.cs" Inherits="One.Views.Course.Display.CourseDetails" %>

<%@ Register Src="~/Views/Course/Display/EachCourse/CourseDetailUc.ascx" TagPrefix="uc1" TagName="CourseDetailUc" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="item-detail">
                <asp:Literal ID="txtSubjectName" runat="server"></asp:Literal>
            </div>
            <uc1:CourseDetailUc runat="server" Id="CourseDetailUc1" />

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
