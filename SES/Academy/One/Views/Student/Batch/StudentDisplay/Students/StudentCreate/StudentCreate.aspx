<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="StudentCreate.aspx.cs" Inherits="One.Views.Student.Batch.StudentDisplay.Students.StudentCreate.StudentCreate" %>

<%@ Register Src="~/Views/Student/Batch/StudentDisplay/Students/StudentCreate/StudentCreateUc.ascx" TagPrefix="uc1" TagName="StudentCreateUc" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div class="item-section-heading">
        <asp:Label ID="lblProgramBatchName" runat="server" Text=""></asp:Label>
    </div>
    <uc1:StudentCreateUc runat="server" id="StudentCreateUc" />
    <asp:HiddenField ID="hidProgramBatchId" runat="server" Value="0"/>
</asp:Content>
