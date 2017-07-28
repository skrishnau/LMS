<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="CreateSection.aspx.cs" Inherits="One.Views.Course.Section.CreateSection" %>

<%--<%@ Register Src="~/Views/Course/Section/CreateSectionUc.ascx" TagPrefix="uc1" TagName="CreateSectionUc" %>--%>
<%@ Register Src="~/Views/RestrictionAccess/Custom/RestrictionUC.ascx" TagPrefix="uc1" TagName="RestrictionUC" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>


<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="headContentt1" ContentPlaceHolderID="head">
    <%--<meta http-equiv='cache-control' content='no-cache' />
    <meta http-equiv='expires' content='0' />
    <meta http-equiv='pragma' content='no-cache' />--%>

    <link href="../../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />
    <link href="../../RestrictionAccess/Custom/RestrictionStyles.css" rel="stylesheet" />
    <link href="../../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-create-edit">
        <asp:Label ID="lblHeading" runat="server" Text="Section edit"></asp:Label>
    </h3>
    <hr />
    <br />
    <div class="data-entry-section">
        <div class="data-entry-section-heading">
            General
            <hr />
        </div>
        <div class="data-entry-section-body">
            <%--<uc1:CreateSectionUc runat="server" ID="CreateSectionUc1" />--%>
            <table>
                <tr>
                    <td class="data-type">Name</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                            ForeColor="red" ControlToValidate="txtName"
                            runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">Description</td>
                    <td class="data-value">
                        <CKEditor:CKEditorControl ID="txtDesc" runat="server"></CKEditor:CKEditorControl>

                        <%--<asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="73px" Width="220px"></asp:TextBox>--%>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">Show Description on Page</td>
                    <td class="data-value">
                        <asp:CheckBox ID="chkShow" runat="server" />
                    </td>
                </tr>

            </table>
            <br />
            
            <div class="data-entry-section-heading">
                Restriction
                <hr />
            </div>
            <div class="data-entry-section-body">
                <uc1:RestrictionUC runat="server" ID="RestrictionUC1" />
            </div>
            <br />

            <div class="save-div">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save Section" />
                &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Width="71px" />
                &nbsp; &nbsp;
            <asp:Label ID="lblError" runat="server" Text="Error while saving." ForeColor="red" Visible="False"></asp:Label>
                <%-- &nbsp;&nbsp;
                    <asp:Button ID="btnDelete" runat="server" Text="Delete this Section" OnClick="btnDelete_Click" Visible="false" />--%>
            </div>
        </div>


    </div>
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
</asp:Content>



<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    Section Edit
</asp:Content>



