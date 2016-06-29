<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="NewGroup.aspx.cs" Inherits="One.Views.Course.ListingMain.CourseMain.NewGroup" %>

<%@ Register Src="~/Views/Course/CourseGroup/GroupUc.ascx" TagPrefix="uc1" TagName="GroupUc" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <uc1:GroupUc runat="server" id="GroupUc" />
    <div>
        <asp:HiddenField ID="hidProgramId" runat="server" Value="0"/>
    </div>
</asp:Content>