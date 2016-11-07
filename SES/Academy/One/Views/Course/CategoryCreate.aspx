<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="CategoryCreate.aspx.cs" Inherits="One.Views.Course.CategoryCreate" %>

<%@ Register Src="~/Views/Course/Category/Create.ascx" TagPrefix="uc1" TagName="Create" %>


<asp:Content runat="server" ID="bodyocntent" ContentPlaceHolderID="Body">
    <div style="text-align: center">
        <h3 class="heading-of-create-edit">
            <asp:Label ID="lblCategoryName" runat="server" Text="Add Category"></asp:Label>
        </h3>
        <hr />
    </div>
    <uc1:Create runat="server" ID="Create1" />
</asp:Content>

