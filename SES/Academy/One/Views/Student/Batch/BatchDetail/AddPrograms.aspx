<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="AddPrograms.aspx.cs" Inherits="One.Views.Student.Batch.BatchDetail.AddPrograms" %>

<%@ Register Src="~/Views/Student/Batch/BatchDetail/ProgramsAddTreeView/TreeViewUc.ascx" TagPrefix="uc1" TagName="TreeViewUc" %>
<%@ Register Src="~/Views/Student/Batch/Create/AddProgramsUc.ascx" TagPrefix="uc1" TagName="AddProgramsUc" %>



<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div class="item-section-heading">
        <asp:Label ID="lblBatchName" runat="server" Text="Label"></asp:Label>
    </div>
    <div style="margin: 20px; padding: 20px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <uc1:TreeViewUc runat="server" ID="TreeViewUc" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <%--<uc1:AddProgramsUc runat="server" ID="AddProgramsUc" />--%>
</asp:Content>
