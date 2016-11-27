<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="SessionDetail.aspx.cs" Inherits="One.Views.Academy.Session.SessionDetail" %>

<%@ Register Src="~/Views/Academy/UserControls/SessionsListingInAYDetailUC.ascx" TagPrefix="uc1" TagName="SessionsListingInAYDetailUC" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">

    <div>
        <h3 class="heading-of-listing">
            <asp:Label ID="lblHeading" runat="server" Text="Label"></asp:Label>
        </h3>
        <hr />
        <div style="text-align: center;">
            <asp:Button ID="btnActivate" runat="server" Text="Activate this Session" OnClick="btnActivate_Click" />
        </div>
        <br />
        <%--<div>
            <div class="data-entry-section-body">
                Start Date :
                <asp:Label ID="lblStart" runat="server" Text="Label"></asp:Label>
                End Date :
                <asp:Label ID="lblEnd" runat="server" Text="Label"></asp:Label>
            </div>
        </div>--%>

        <uc1:SessionsListingInAYDetailUC runat="server" ID="SessionsListingInAYDetailUC" />

    </div>

    <asp:HiddenField ID="hidAcademicYearId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidEditable" runat="server" Value="False" />
</asp:Content>
