<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="CourseCreate.aspx.cs" Inherits="One.Views.Course.CourseCreate" %>

<%--<%@ Register Src="~/Views/Course/Course/CreateUC.ascx" TagPrefix="uc1" TagName="CreateUC" %>--%>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>




<asp:Content runat="server" ID="contentbody" ContentPlaceHolderID="Body">

    <%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

    <div>

        <h3 class="heading-of-create-edit">
            <asp:Label ID="lblHeading" runat="server" Text=""></asp:Label>
        </h3>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="data-entry-section">
                    <div class="data-entry-section-heading">
                        General
                        <hr />
                    </div>
                    <div class="data-entry-section-body">
                        <table>
                            <tr>
                                <td class="data-type">Name*</td>
                                <td class="data-value">
                                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                                        ValidationGroup="courseCreateGroup"
                                        ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="data-type">Short Name*</td>
                                <td class="data-value">
                                    <asp:TextBox ID="txtShortName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ControlToValidate="txtShortName"
                                        ValidationGroup="courseCreateGroup"
                                        ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="data-type">Code</td>
                                <td class="data-value">
                                    <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCode"
                                        ValidationGroup="courseCreateGroup"
                                        ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="data-type">Credit</td>
                                <td class="data-value">
                                    <asp:TextBox ID="txtCredit" runat="server" TextMode="Number" ToolTip="General. It can be changed as per class."></asp:TextBox>
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCredit"
                                        ValidationGroup="courseCreateGroup"
                                        ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>

                            <tr>
                                <td class="data-type">Summary</td>
                                <td class="data-value">
                                    <CKEditor:CKEditorControl ID="CKEditor1" runat="server"></CKEditor:CKEditorControl>
                                </td>
                            </tr>

                        </table>
                    </div>
                </div>

                <div style="text-align: left" class="save-div">
                    &nbsp;&nbsp;
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"
                        ValidationGroup="courseCreateGroup"
                        Height="30px" Width="85px" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Height="30px" Width="85px" />
                    &nbsp;
                    <asp:Label ID="lblError" runat="server" Text="Error while saving." Visible="False" ForeColor="red"></asp:Label>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    </div>

    <%--<uc1:CreateUC runat="server" ID="CreateUC" />--%>
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidCategoryId" runat="server" Value="0" />
    <asp:HiddenField ID="hidCourseId" runat="server" Value="0" />
</asp:Content>


<asp:Content runat="server" ID="contenttitle" ContentPlaceHolderID="title">
    <asp:Literal ID="lblPageTitle" runat="server"></asp:Literal>
</asp:Content>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="head">
    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>
