<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="StudentCreate.aspx.cs" Inherits="One.Views.Student.Batch.Student.StudentCreate" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<%--<%@ Register Src="~/Views/Student/Batch/StudentDisplay/Students/StudentCreate/StudentCreateUc.ascx" TagPrefix="uc1" TagName="StudentCreateUc" %>--%>

<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-create-edit">Student edit
    </h3>
    <hr />
    <br/>
    <div class="data-entry-section">
        <div class="data-entry-section-heading">
            General
             <hr />
        </div>
        
        <%--<div class="data-entry-section-body">--%>
        <table>
            <tr>
                <td class="data-type">First Name*</td>
                <td class="data-value">
                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ErrorMessage="Required"
                        ControlToValidate="txtFirstName" ValidationGroup="studentCreateGrp" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="data-type">Middle Name</td>
                <td class="data-value">
                    <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="data-type">Last Name</td>
                <td class="data-value">
                    <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="data-type">Class Roll No. * </td>
                <td class="data-value">
                    <asp:TextBox ID="txtCRN" runat="server"></asp:TextBox>

                </td>
            </tr>

            <tr>
                <td class="data-type">Username*</td>
                <td class="data-value">
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>


                    <asp:RequiredFieldValidator ID="valiUserName" runat="server"
                        ErrorMessage="Required"
                        ControlToValidate="txtUserName" ValidationGroup="studentCreateGrp" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="data-type">Password*</td>
                <td class="data-value">
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                        ErrorMessage="Required"
                        ControlToValidate="txtPassword" ValidationGroup="studentCreateGrp" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="data-type">Email</td>
                <td class="data-value">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                     <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ForeColor="red"
                            ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                         ValidationGroup="studentCreateGrp"
                            ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>

                </td>
            </tr>
            <tr>
                <td class="data-type">Phone </td>
                <td class="data-value">
                    <asp:TextBox ID="txtPhone1" runat="server"></asp:TextBox>
                </td>
            </tr>


        </table>
        <br />
        <%--</div>--%>
        <div class="data-entry-section-heading">
            Image
            <hr />
        </div>

        <div class="data-entry-section-body">
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
        </div>
        <br />

        <div class="save-div">
            <asp:Button ID="btnSaveNAddMore" runat="server" ValidationGroup="studentCreateGrp" Text="Save and add more" OnClick="btnSave_Click" Width="140px" />
            &nbsp;&nbsp; &nbsp;
                    <asp:Button ID="btnSaveNReturn" runat="server" ValidationGroup="studentCreateGrp" Text="Save and return" OnClick="btnSave_Click" Width="140px" />
            &nbsp;&nbsp; &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="130px" OnClick="btnCancel_Click" />
            &nbsp;&nbsp; &nbsp;
            <asp:Label ID="lblSaveError" runat="server" Text="Couldn't save" Visible="False" ForeColor="red"></asp:Label>
        </div>
        <%--<uc1:StudentCreateUc runat="server" ID="StudentCreateUc1" />--%>
    </div>
    <asp:HiddenField ID="hidId" runat="server" Value="0" />
    <asp:HiddenField ID="hidProgramBatchId" runat="server" Value="0" />
    <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
</asp:Content>


<asp:Content runat="server" ID="content2" ContentPlaceHolderID="head">
    <link href="../../../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>


<asp:Content runat="server" ID="content4" ContentPlaceHolderID="title">
    Student edit
</asp:Content>


