<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="One.Views.Student.Default" %>


<%@ Register Src="~/Views/Student/Batch/List/listUc.ascx" TagPrefix="uc1" TagName="listUc" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">Batch List
    </h3>
    <hr />
    <div style="text-align: right;">
        <asp:HyperLink ID="lnkEdit" runat="server" >
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
            <asp:Label ID="lblEdit" runat="server" Text="Edit"></asp:Label>
        </asp:HyperLink>
    </div>
    
    <div>
        <asp:HyperLink ID="lnkAdd" runat="server" NavigateUrl="~/Views/Student/Batch/Create/BatchCreate.aspx" Visible="False">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
            New Batch
        </asp:HyperLink>
    </div>
    <div>
        <uc1:listUc runat="server" ID="listUc" />
    </div>
</asp:Content>

<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    Batch List
</asp:Content>
