<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="CourseCreate.aspx.cs" Inherits="One.Views.Course.CourseCreate" %>

<%@ Register Src="~/Views/Course/Course/CreateUC.ascx" TagPrefix="uc1" TagName="CreateUC" %>




<asp:Content runat="server" ID="contentbody" ContentPlaceHolderID="Body">
    <div style="text-align: center">
        <h3 class="heading-of-create-edit">Add Course in category &nbsp;:&nbsp;
                    <asp:Label ID="lblCategoryName" runat="server" Text=""></asp:Label>
        </h3>
    </div>
    <uc1:CreateUC runat="server" ID="CreateUC" />
            <asp:HiddenField ID="hidCategoryId" runat="server" Value="0" />
</asp:Content>
