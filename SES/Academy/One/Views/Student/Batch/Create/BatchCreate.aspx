<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="BatchCreate.aspx.cs" Inherits="One.Views.Student.Batch.Create.BatchCreate" %>

<%@ Register Src="~/Views/Student/Batch/Create/CreateBatchUc.ascx" TagPrefix="uc1" TagName="CreateBatchUc" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <uc1:CreateBatchUc runat="server" ID="CreateBatchUc" />
</asp:Content>