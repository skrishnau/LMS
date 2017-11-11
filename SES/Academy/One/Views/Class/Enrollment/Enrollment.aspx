<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Enrollment.aspx.cs" Inherits="One.Views.Class.Enrollment.Enrollment" %>

<%@ Register Src="~/Views/Class/Enrollment/UserEnrollUC_ListDisplay.ascx" TagPrefix="uc1" TagName="UserEnrollUC_ListDisplay" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">

    <h3 class="heading-of-display">
        <asp:Label ID="lblCourseName" runat="server" Text=""></asp:Label>
    </h3>
    <hr />
    
    <table>
        <tr>
            <td class="data-type">Class name : </td>
            <td class="data-value">
                <asp:Label ID="lblClassName" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>
    <br/>
    <div class="panel panel-default">

        <div class="panel-heading">
            <asp:Label ID="lblEnrollHeading" runat="server" Text=""></asp:Label>
        </div>

        <div class="panel-body">

            <%--<uc1:UserEnrollUC runat="server" ID="UserEnrollUC" />--%>
            <uc1:UserEnrollUC_ListDisplay runat="server" ID="UserEnrollUC_ListDisplay1" />
            <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1"
                ServiceMethod=""
                MinimumPrefixLength="1"
                CompletionInterval="10"
                EnableCaching="false"
                CompletionSetCount="1"
                TargetControlID="TextBox1"
                runat="server">
            </ajaxToolkit:AutoCompleteExtender>
            <%--  TargetControlID="txtSearchNotEnroll" --%>
        </div>



    </div>

    <asp:HiddenField ID="hidCourseClassId" Value="0" runat="server" />
</asp:Content>

<asp:Content runat="server" ID="content2" ContentPlaceHolderID="title">
    Users enroll
</asp:Content>

<asp:Content runat="server" ID="content4" ContentPlaceHolderID="head">

    <link href="../../../Content/CSSes/PanelStyles.css" rel="stylesheet" />
    <link href="../../../Content/CSSes/TableStyles.css" rel="stylesheet" />

</asp:Content>
