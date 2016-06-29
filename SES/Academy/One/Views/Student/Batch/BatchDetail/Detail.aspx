<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="One.Views.Student.Batch.BatchDetail.Detail" %>

<%@ Register Src="~/Views/Student/Batch/BatchDetail/DetailUc.ascx" TagPrefix="uc1" TagName="DetailUc" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <uc1:DetailUc runat="server" id="DetailUc" />
</asp:Content>
