<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Enrollment.aspx.cs" Inherits="One.Views.Class.Enrollment.Enrollment" %>

<%@ Register Src="~/Views/Class/Enrollment/UserEnrollUC_ListDisplay.ascx" TagPrefix="uc1" TagName="UserEnrollUC_ListDisplay" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    http://localhost:1240/Views/Class/CourseSessionCreate.aspx?cId=6
     <div>
         <%--<div style="text-align: right;">
             <asp:Button ID="btnEnroll" runat="server" Text="Enroll" />

         </div>--%>
         <div>

             <%--<uc1:UserEnrollUC runat="server" ID="UserEnrollUC" />--%>
             <uc1:UserEnrollUC_ListDisplay runat="server" ID="UserEnrollUC_ListDisplay1" />
         </div>
         <%-- List of users to add; with filter  --%>
     </div>
</asp:Content>
