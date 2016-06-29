<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="GroupAssign.aspx.cs" Inherits="One.Views.Student.StudentGroup.GroupAssign" %>

<%@ Register Src="~/Views/Student/StudentGroupAssignUC.ascx" TagPrefix="uc1" TagName="StudentGroupAssignUC" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div>
        <uc1:StudentGroupAssignUC runat="server" ID="StudentGroupAssignUC" />
    </div>
</asp:Content>
