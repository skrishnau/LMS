<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="UrlView.aspx.cs" Inherits="One.Views.ActivityResource.Url.UrlView" %>



<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <%-- src="https://www.w3schools.com" --%>
    <h3 class="heading-of-create-edit">
        <asp:Label runat="server" ID="lblHeading"></asp:Label>
    </h3>
    <hr />



    <div class="">
        <div>
            URI : &nbsp;&nbsp;
        <asp:HyperLink runat="server" ID="lnkUrl"></asp:HyperLink>
        </div>
        <br />
        <iframe runat="server" id="iframe" class="well well-sm panel panel-default" style="width: 100%; height: 100%; min-height: 400px;">
            <p>Your browser does not support iframes.</p>
        </iframe>
    </div>
</asp:Content>
