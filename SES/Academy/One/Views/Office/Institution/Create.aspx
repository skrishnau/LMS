<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.Office.Institution.Create" %>

<asp:Content runat="server" ContentPlaceHolderID="Body" ID="content1">


    <fieldset>
        <legend>Institution</legend>
        <div style="float: left;">
            <asp:HiddenField ID="txtId" runat="server" Value="0" />
            <table>
                <tr>
                    <td>Name *</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="nameValidator" runat="server"
                            ControlToValidate="txtName"
                            ErrorMessage="Required!" ForeColor="#FF3300"></asp:RequiredFieldValidator>

                    </td>
                </tr>
                <tr>
                    <td>Country
                        *</td>
                    <td>
                        <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="countryValidator"
                            runat="server" ErrorMessage="Required!"
                            ControlToValidate="txtCountry" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>City
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Street
                    </td>
                    <td>
                        <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Postal Code
                    </td>
                    <td>
                        <asp:TextBox ID="txtPostal" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Email
                        *</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="emailValidator" runat="server"
                            ErrorMessage="Required!!"
                            ControlToValidate="txtEmail" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Website
                    </td>
                    <td>
                        <asp:TextBox ID="txtWebsite" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Pan Number
                    </td>
                    <td>
                        <asp:TextBox ID="txtPanNo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Category
                    </td>
                    <td>
                        <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Moto
                    </td>
                    <td>
                        <asp:TextBox ID="txtMoto" runat="server" TextMode="MultiLine" Height="80px"></asp:TextBox>
                    </td>
                </tr>
            </table>

        </div>
        <div style="float: left; text-align: center; height: 150px; width: 229px; border: solid 1px black;">
            Choose Logo<br />
            <asp:Image ID="Image1" runat="server" Height="60px" Width="60px" BorderStyle="Groove" ImageUrl="~/Content/Images/company-logo.jpg" />
            <br />
            <br />

            <asp:FileUpload ID="FileUpload1" runat="server" />
        </div>
        <div style="float: right; width: 100%;">
            <asp:Button ID="btnSave" runat="server" Text="Save"  />
            <%-- OnClick="btnSave_Click" --%>

        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMsg" runat="server" ForeColor="#000066" Text="Label" Visible="False"></asp:Label>

        </div>
    </fieldset>
</asp:Content>

