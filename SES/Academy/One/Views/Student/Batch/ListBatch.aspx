<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ListBatch.aspx.cs" Inherits="One.Views.Student.Batch.ListBatch" %>

<%@ Register Src="~/Views/Student/Batch/List/listUc.ascx" TagPrefix="uc1" TagName="listUc" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div style="font-size: 1.3em; font-weight: 700; text-align: center;">
        Batch List
         <span style="text-align: right; float: right; position: relative; 
                 right: 0; bottom: 0; font-size: 0.6em;">
                <span style="height: 10px; display: block;"></span>
             <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/Student/Batch/Create/BatchCreate.aspx">
                New Batch
             </asp:HyperLink>
         </span>
        <hr />
    </div>


    <div>
        <uc1:listUc runat="server" ID="listUc" />
    </div>
</asp:Content>
