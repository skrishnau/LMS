<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="ListBatch.aspx.cs" Inherits="One.Views.Student.Batch.ListBatch" %>

<%@ Register Src="~/Views/Student/Batch/List/listUc.ascx" TagPrefix="uc1" TagName="listUc" %>

<asp:Content runat="server" ID="leftContent1" ContentPlaceHolderID="BodyInnerLeft">
    <ul>
        <li>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/Student/Batch/Create/BatchCreate.aspx">
                New Batch
            </asp:HyperLink>

        </li>
    </ul>
</asp:Content>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div>
        <uc1:listUc runat="server" id="listUc" />
    </div>
</asp:Content>
