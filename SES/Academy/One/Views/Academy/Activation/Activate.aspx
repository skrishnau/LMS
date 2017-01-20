<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="Activate.aspx.cs" Inherits="One.Views.Academy.Activation.Activate" %>
<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="contentbody" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">
        <asp:Label ID="lblHeading" runat="server" Text="Activate"></asp:Label>

    </h3>
    <hr />
    
    <div class="data-entry-body">
        <div>
            <asp:Label ID="lblQue" runat="server" Text="Label"></asp:Label>
        </div>
        <br />
        <asp:Button ID="btnOk" runat="server" Text="Ok" OnClick="btnOk_Click" Width="70px" />
        &nbsp;&nbsp;
        &nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Width="75px" />
         &nbsp; &nbsp;
        <asp:Label ID="lblError" runat="server" Text="Error while saving." ForeColor="red" Visible="False"></asp:Label>
    </div>
    <asp:HiddenField ID="hidAcademicYearId" runat="server" Value ="0"/>
    <asp:HiddenField ID="hidSessionId" runat="server" Value ="0"/>
    <asp:HiddenField ID="hidTask" runat="server" Value =""/>
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="title">
    <asp:Literal ID="lblPageTitle" runat="server"></asp:Literal>
</asp:Content>
