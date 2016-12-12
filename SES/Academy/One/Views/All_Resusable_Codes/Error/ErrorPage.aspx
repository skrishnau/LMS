<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="One.Views.All_Resusable_Codes.Error.ErrorPage" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="Body">

    <div>
        <h3 class="heading-of-listing">
            <asp:Label ID="lblHeading" runat="server" Text="Error"></asp:Label>
        </h3>
        <hr />
        <div class="data-entry-section-body">
            <asp:Label ID="lblError" runat="server" Text="Error on the current page."></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnTryGoingToSamePage" runat="server" Text="Try the same page again"
                OnClick="btnTryGoingToSamePage_OnClick"
                 />
            &nbsp; &nbsp;&nbsp;
            <asp:Button ID="btnGoToDashBoard" runat="server" Text="Go to Dashboard" 
                OnClick="btnGoToDashBoard_OnClick"
                />

        </div>
    </div>
</asp:Content>


<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    Error
</asp:Content>
