<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="CourseSectionListing.aspx.cs" Inherits="One.Views.Course.Section.Master.CourseSectionListing" %>

<%@ Register Src="~/Views/Course/Display/EachCourse/CourseDetailUc.ascx" TagPrefix="uc1" TagName="CourseDetailUc" %>
<%@ Register Src="~/Views/Course/ActivityAndResource/ActResChoose/ActResChooseUc.ascx" TagPrefix="uc1" TagName="ActResChooseUc" %>

<asp:Content runat="server" ID="contentHead" ContentPlaceHolderID="head">
    <link href="../../../../Content/themes/base/jquery.ui.dialog.css" rel="stylesheet" />
    <script src="../../../../Scripts/jquery-1.7.1.min.js"></script>

</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="item-detail">
                <asp:Literal ID="txtSubjectName" runat="server"></asp:Literal>
            </div>
            <uc1:CourseDetailUc runat="server" ID="CourseDetailUc1" />
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <uc1:ActResChooseUc runat="server" ID="ActResChooseUc" />
    </asp:Panel>

</asp:Content>
