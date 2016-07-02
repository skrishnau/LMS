<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.Office.School.Create" %>
<%-- ~/ViewsSite/UserSite.Master --%>
<%@ Register Src="~/Views/Office/School/SchoolTypeUC.ascx" TagPrefix="uc1" TagName="SchoolTypeUC" %>


<asp:Content runat="server" ContentPlaceHolderID="Body" ID="content">
    <div style="text-align: center">
        <strong style="font-size: 1.5em;">School setup</strong>

    </div>
    <div style="margin: 10px 20px 0; padding: 10px; border: 2px solid lightgray;">
        <strong>General</strong>
        <hr />
        <table>
            <tr>
                <td>School Name*</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ErrorMessage="Required"
                        ControlToValidate="txtName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>School Type*</td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cmbSchoolType" runat="server"
                                Height="22px" Width="145px" OnSelectedIndexChanged="cmbSchoolType_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" Height="20px" ImageUrl="~/Content/Icons/plus.png" OnClick="ImageButton2_Click" Width="20px" Enabled="False" />
                            &nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="valiSchType" runat="server"
                            ControlToValidate="cmbSchoolType"
                            ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </td>
            </tr>




            <tr>
                <td>Phone*</td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" TextMode="Phone"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valiPhone" runat="server"
                            ControlToValidate="cmbSchoolType"
                            ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>


               <tr>
                <td>School Email*</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                        ErrorMessage="Required" ControlToValidate="txtEmail" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>


        </table>
        <div>
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
        </div>
        <br />
        <strong>School Logo</strong>
        <hr />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%-- <asp:Panel ID="pnlSchTyp" runat="server" Width="40%">  style="float: left;"--%>
                <div>
                    <div style="width: 300px; text-align: center;">
                        <asp:Image ID="Image1" Height="60px" Width="61px" runat="server" />
                        <br />

                    </div>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <%--<div style="float: left;">
                       <asp:Button ID="Button1" runat="server" Text="Close" OnClick="Button1_Click" />
                    </div>--%>
                </div>
                <%--</asp:Panel>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br/>
        <strong>Other</strong>
        <hr />
        <table>
         


            <tr>
                <td>Earlier Website</td>
                <td>
                    <asp:TextBox ID="txtWeb" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Country</td>
                <td>
                    <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>City</td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Street</td>
                <td>
                    <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Code</td>
                <td>
                    <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                  <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ErrorMessage="Required" ControlToValidate="txtCode"
                        ForeColor="#FF3300"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>

            <tr>
                <td>Registration No.</td>
                <td>
                    <asp:TextBox ID="txtRegNo" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Fax</td>
                <td>
                    <asp:TextBox ID="txtFax" runat="server"></asp:TextBox>
                </td>
            </tr>

        </table>
          <br />
        &nbsp;
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="73px" />
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="lblMsg" runat="server" ForeColor="#3333FF" Text="Label" Visible="False"></asp:Label>

    </div>
    <%-- style="float: left;" --%>
    <div>


      
        <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
        <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
        <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
        <asp:CheckBox ID="chkActive" runat="server" Text="Active" Checked="True" Visible="False" />

    </div>




</asp:Content>
