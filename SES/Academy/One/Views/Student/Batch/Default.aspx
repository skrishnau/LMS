<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="One.Views.Student.Batch.Default" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>


<%--<%@ Register Src="~/ViewsSite/User/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>--%>



<%--<%@ Register Src="~/Views/Student/Batch/BatchDetail/DetailUc.ascx" TagPrefix="uc1" TagName="DetailUc" %>--%>
<asp:Content runat="server" ID="content2" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <%--<uc1:DetailUc runat="server" id="DetailUc" />--%>
    <h3 class="heading-of-display">
        <asp:Label runat="server" ID="lblBatchName"></asp:Label>
    </h3>
    <div style="font-size: 1em; margin-left: 25px;">
        <asp:Label runat="server" ID="lblSummary"></asp:Label>
    </div>
    <br />
    <%--<div style="margin: 5px;">--%>
    <%--<div style="margin: 2px 2px 10px 0;">--%>

    <%-- <span style="margin: 15px; font-size: 0.7em;">
             <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl="~/Views/Student/Batch/Create/BatchCreate.aspx">
                 <asp:Image ID="Image1" Height="13px" Width="13px" runat="server" ImageUrl="~/Content/Icons/Edit/edit_black_and_white.png" />
                 &nbsp; Edit
             </asp:HyperLink>
         </span>--%>
    <%--</div>--%>
    <%--</div>--%>
    <div style="color: darkslategrey; font: 20px bold darkslategray; margin: 3px 3px 8px;">Programs in the Batch</div>
    <div class="list">
        <asp:PlaceHolder ID="pnlProgramsInTheBatch" runat="server"></asp:PlaceHolder>
    </div>
    <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />

</asp:Content>

<asp:Content runat="server" ID="titlecontent" ContentPlaceHolderID="title">
    <asp:Literal ID="lblTitle" runat="server" Text="Batch Detail"></asp:Literal>
</asp:Content>
