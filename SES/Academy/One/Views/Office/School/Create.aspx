<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.Office.School.Create" %>

<%-- ~/ViewsSite/UserSite.Master --%>
<%--<%@ Register Src="~/Views/Office/School/SchoolTypeUC.ascx" TagPrefix="uc1" TagName="SchoolTypeUC" %>--%>
<%@ Register Src="~/Views/ActivityResource/FileResource/FileResourceItems/FilesDisplay.ascx" TagPrefix="uc1" TagName="FilesDisplay" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>


<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    College Edit
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="Body" ID="content">
    <%-- style="text-align: center" --%>
    <h3 class="heading-of-create-edit">College Edit
    </h3>
    <hr />
    <%-- style="margin: 10px 20px 0; padding: 10px; border: 2px solid lightgray;" --%>
    <div class="panel panel-default">
        <div class="panel-heading">
            General
        </div>

        <div class="panel-body">

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

                <tr>
                    <td class="data-type">Description</td>
                    <td class="data-value">
                        <CKEditor:CKEditorControl ID="CKEditor1" runat="server"></CKEditor:CKEditorControl>
                    </td>
                </tr>


                <%-- <tr runat="server" id="one1" visible="False">
                    <td class="data-type">College Type*</td>
                    <td class="data-value">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="cmbSchoolType" runat="server" Height="22px" Width="145px">
                                </asp:DropDownList>
                                &nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="valiSchType" runat="server"
                            ControlToValidate="cmbSchoolType"
                            ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </td>
                </tr>--%>


                <%--<tr runat="server" id="two2" visible="False">
                    <td class="data-type">School location *</td>
                    <td class="data-value">
                        <asp:DropDownList ID="ddlCountry" runat="server"></asp:DropDownList>

                        <asp:RequiredFieldValidator ID="valiCountry" runat="server"
                            ControlToValidate="cmbSchoolType"
                            ErrorMessage="Required" ForeColor="red"></asp:RequiredFieldValidator>
                    </td>
                </tr>--%>

                <tr>
                    <td class="data-type">Phone Main*</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtPhoneMain" runat="server" TextMode="Phone"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="valiPhone" runat="server"
                            ControlToValidate="txtPhoneMain"
                            ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ForeColor="red" ControlToValidate="txtPhone"
                            ValidationExpression="^(?:(?:\+?1\s*(?:[.-]\s*)?)?(?:\(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*\)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?)?([2-9]1[02-9]|[2-9][02-9]1|[2-9][02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})(?:\s*(?:#|x\.?|ext\.?|extension)\s*(\d+))?$"
                            ErrorMessage="Not a phone number"></asp:RegularExpressionValidator>--%>
                    </td>
                </tr>

                <tr>
                    <td class="data-type">Phone After Hours*</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtPhoneAfterHours" runat="server" TextMode="Phone"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                            ControlToValidate="txtPhoneAfterHours"
                            ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                            ForeColor="red" ControlToValidate="txtPhone"
                            ValidationExpression="^(?:(?:\+?1\s*(?:[.-]\s*)?)?(?:\(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*\)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?)?([2-9]1[02-9]|[2-9][02-9]1|[2-9][02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})(?:\s*(?:#|x\.?|ext\.?|extension)\s*(\d+))?$"
                            ErrorMessage="Not a phone number"></asp:RegularExpressionValidator>--%>
                    </td>
                </tr>


                <tr>
                    <td class="data-type">Email General*</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtEmailGeneral" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ErrorMessage="Required" ControlToValidate="txtEmailGeneral" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ForeColor="red"
                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="txtEmailGeneral" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>

                    </td>
                </tr>

                <tr>
                    <td class="data-type">Email Support*</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtEmailSupport" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ErrorMessage="Required" ControlToValidate="txtEmailSupport" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="red"
                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="txtEmailSupport" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>

                    </td>
                </tr>

                <tr>
                    <td class="data-type">Email Marketing*</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtEmailMarketing" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ErrorMessage="Required" ControlToValidate="txtEmailMarketing" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ForeColor="red"
                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ControlToValidate="txtEmailMarketing" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>

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
    </div>


    <div class="panel panel-default">

        <div class="panel-heading">
            Logo
        </div>

        <div class="panel-body">

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <%-- <asp:Panel ID="pnlSchTyp" runat="server" Width="40%">  style="float: left;"--%>
                    <div>
                        <div style="width: 300px; text-align: center;">
                            <asp:Image ID="Image1" Height="60px" Width="61px" runat="server" />
                            <br />

                        </div>
                        <uc1:FilesDisplay runat="server" ID="FilesDisplay1" />
                        <script>
                            //function AssemblyFileUpload_Started(sender, args) {
                            //    var filename = args.get_fileName();
                            //    var ext = filename.substring(filename.lastIndexOf(".") + 1);
                            //    if (ext != 'png') {
                            //        throw {
                            //            name: "Invalid File Type",
                            //            level: "Error",
                            //            message: "Invalid File Type (Only .png)",
                            //            htmlMessage: "Invalid File Type (Only .png)"
                            //        }
                            //        return false;
                            //    }
                            //    return true;
                            //}
                        </script>
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

    </div>


    <div class="panel panel-default">
        <div class="panel-heading">
            Other
        </div>

        <div class="panel-body">
            <table>
                <tr>
                    <td class="data-type">College Website</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtWeb" runat="server"></asp:TextBox>
                    </td>
                </tr>


                <tr>
                    <td class="data-type">Address</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                            ErrorMessage="Required" ControlToValidate="txtAddress"
                            ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <%-- <tr>
                <td>Street</td>
                <td>
                    <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
                </td>
            </tr>--%>
                <%-- <tr>
                    <td class="data-type">Code</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ErrorMessage="Required" ControlToValidate="txtCode"
                        ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>--%>

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

    </div>

    <div class="save-div">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        &nbsp; &nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_OnClick" />

        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblMsg" runat="server" ForeColor="#3333FF" Text="Label" Visible="False"></asp:Label>
    </div>

    <%-- style="float: left;" --%>

    <asp:HiddenField ID="hidImageId" runat="server" Value="0" />
    <asp:HiddenField ID="hidPageKey" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
    <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
    <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
    <asp:CheckBox ID="chkActive" runat="server" Text="Active" Checked="True" Visible="False" />

</asp:Content>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link href="../../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />
    <%--<link href="../../../Content/CSSes/ListingStyles.css" rel="stylesheet" />--%>
    <link href="../../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>
