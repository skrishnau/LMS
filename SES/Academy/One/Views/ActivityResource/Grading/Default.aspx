<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="One.Views.ActivityResource.Grading.Default" %>

<asp:Content runat="server" ID="contentboody" ContentPlaceHolderID="Body">
    <div>
        Grading 
        <asp:Panel ID="pnlGradeList" runat="server"></asp:Panel>
    </div>
     <asp:HiddenField ID="hidActivityResourceId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
    <%--<asp:HiddenField ID="hidUserClassId" runat="server" Value="0" />--%>
</asp:Content>
