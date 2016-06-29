<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="Section.aspx.cs" Inherits="One.Views.Course.Section.Master.Section" %>

<%@ Register Src="~/Views/Course/Section/SectionUc.ascx" TagPrefix="uc1" TagName="SectionUc" %>
<%@ Register Src="~/Views/Course/Section/Master/test_uc_delete_on_unused.ascx" TagPrefix="uc1" TagName="test_uc_delete_on_unused" %>
<%@ Register Src="~/Views/Course/Section/CreateSectionUc.ascx" TagPrefix="uc1" TagName="CreateSectionUc" %>





<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <%--<uc1:SectionUc runat="server" ID="SectionUc" />--%>
    <%--<uc1:test_uc_delete_on_unused runat="server" id="test_uc_delete_on_unused" />--%>
    <uc1:CreateSectionUc runat="server" ID="CreateSectionUc" />
    <%--<uc1:SectionUc runat="server" ID="SectionUc" />--%>
</asp:Content>