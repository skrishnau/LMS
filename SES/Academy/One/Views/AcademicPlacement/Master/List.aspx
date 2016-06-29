<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="One.Views.AcademicPlacement.Master.List" %>

<%@ Register Src="~/Views/AcademicPlacement/Master/ListingUserControls/TreeViewUC.ascx" TagPrefix="uc1" TagName="TreeViewUC" %>


<asp:Content runat="server" ID="content2" ContentPlaceHolderID="BodyInnerLeft">

    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Views/AcademicPlacement/RunningClass/AddClasses/AddClasses.aspx"
        runat="server">Assign Classes</asp:HyperLink>

</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <%-- list --%>
    <h2>List</h2>
    <uc1:TreeViewUC runat="server" id="TreeViewUC1" />
</asp:Content>
