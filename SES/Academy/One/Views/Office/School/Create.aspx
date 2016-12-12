<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.Office.School.Create" %>

<%-- ~/ViewsSite/UserSite.Master --%>
<%@ Register Src="~/Views/Office/School/SchoolTypeUC.ascx" TagPrefix="uc1" TagName="SchoolTypeUC" %>
<%@ Register Src="~/Views/ActivityResource/FileResource/FileResourceItems/FilesDisplay.ascx" TagPrefix="uc1" TagName="FilesDisplay" %>

<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    College Edit
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="Body" ID="content">
    <div style="text-align: center">
        <strong style="font-size: 1.5em;">College Edit</strong>

    </div>
    <%-- style="margin: 10px 20px 0; padding: 10px; border: 2px solid lightgray;" --%>
    <div class="data-entry-body">
        <div class="data-entry-section-heading">
            General
        </div>
        <hr />
        <div class="data-entry-section-body">

            <table>
                <tr>
                    <td class="data-type">College Name*</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ErrorMessage="Required"
                            ControlToValidate="txtName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr runat="server" ID="one1" Visible="False" >
                    <td class="data-type">College Type*</td>
                    <td class="data-value">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbSchoolType" runat="server" Height="22px" Width="145px">
                                </asp:DropDownList>
                                <%--  <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" Height="20px"
                                     ImageUrl="~/Content/Icons/plus.png" OnClick="ImageButton2_Click" Width="20px" Enabled="False" />--%>
                                &nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="valiSchType" runat="server"
                            ControlToValidate="cmbSchoolType"
                            ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>
                </tr>


                <tr runat="server" ID="two2" Visible="False">
                    <td class="data-type">School location *</td>
                    <td class="data-value">
                        <asp:DropDownList ID="ddlCountry" runat="server"></asp:DropDownList>

                        <asp:RequiredFieldValidator ID="valiCountry" runat="server"
                            ControlToValidate="cmbSchoolType"
                            ErrorMessage="Required" ForeColor="red"></asp:RequiredFieldValidator>
                        <%--<asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>--%>
                    </td>
                </tr>

                <tr>
                    <td class="data-type">Phone*</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valiPhone" runat="server"
                            ControlToValidate="cmbSchoolType"
                            ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>


                <tr>
                    <td class="data-type">Email*</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ErrorMessage="Required" ControlToValidate="txtEmail" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>


            </table>


            <%--  <div>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div id="pnlSchTypeUc" style="background-color: lightyellow;" runat="server">

                            <uc1:SchoolTypeUC runat="server" ID="SchoolTypeUC" />

                            <asp:Button ID="btnSave1" runat="server" Text="Save" OnClick="btnSave1_Click" />
                            &nbsp;&nbsp;&nbsp;
                                 <asp:Button ID="btnCancel1" runat="server" Text="Cancel" OnClick="btnCancel_Click" />

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>--%>
        </div>
        <br />



        <div class="data-entry-section-heading">
            Logo
        </div>
        <hr />
        <div class="data-entry-section-body">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <%-- <asp:Panel ID="pnlSchTyp" runat="server" Width="40%">  style="float: left;"--%>
                    <div>
                        <div style="width: 300px; text-align: center;">
                            <asp:Image ID="Image1" Height="60px" Width="61px" runat="server" />
                            <br />

                        </div>
                        <uc1:FilesDisplay runat="server" ID="FilesDisplay1" />
                        <ajaxToolkit:AsyncFileUpload ID="file_upload" runat="server" Visible="True" />
                        <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
                        <%--<div style="float: left;">
                       <asp:Button ID="Button1" runat="server" Text="Close" OnClick="Button1_Click" />
                    </div>--%>
                    </div>
                    <%--</asp:Panel>--%>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <br />

        <div class="data-entry-section-heading">
            Other
        </div>
        <hr />

        <div class="data-entry-section-body">
            <table>
                <tr>
                    <td class="data-type">Earlier Website</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtWeb" runat="server"></asp:TextBox>
                    </td>
                </tr>


                <tr>
                    <td class="data-type">City</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <%-- <tr>
                <td>Street</td>
                <td>
                    <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
                </td>
            </tr>--%>
                <tr>
                    <td class="data-type">Code</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                        <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ErrorMessage="Required" ControlToValidate="txtCode"
                        ForeColor="#FF3300"></asp:RequiredFieldValidator>--%>
                    </td>
                </tr>

                <tr>
                    <td class="data-type">Registration No.</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtRegNo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">Fax</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                    </td>
                </tr>

            </table>
        </div>
        <br />

        <div class="save-div">
            &nbsp;
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="73px" />
            &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblMsg" runat="server" ForeColor="#3333FF" Text="Label" Visible="False"></asp:Label>
        </div>

    </div>
    <%-- style="float: left;" --%>
    <div>



        <asp:HiddenField ID="hidImageId" runat="server" Value="0" />
        <asp:HiddenField ID="hidPageKey" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
        <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
        <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
        <asp:CheckBox ID="chkActive" runat="server" Text="Active" Checked="True" Visible="False" />

    </div>




</asp:Content>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link href="../../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />
</asp:Content>
