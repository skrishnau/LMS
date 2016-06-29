<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.CreatedUser.Create" %>

<%@ Register src="../UserControls/ReqImageUC.ascx" tagname="ReqImageUC" tagprefix="uc1" %>

<asp:Content runat="server" ContentPlaceHolderID="Body">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <asp:Label ID="lblSaveStatus" runat="server" Text="Label" BackColor="#6666FF" Visible="False"></asp:Label>
            </div>
            <div style="float: none">
                <div style="float: none;">
                    <table>

                        <tr>
                            <td>School<uc1:ReqImageUC ID="ReqImageUC1" runat="server" />
                            </td>
                            <td>
                                <asp:DropDownList ID="cmbSchool" runat="server" Height="20px" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="cmbSchool_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                       
                        <tr>
                            <td>First Name*</td>
                            <td>
                                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                     ErrorMessage="Required"
                                    ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Middle Name</td>
                            <td>
                                <asp:TextBox ID="txtMidName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Last Name</td>
                            <td>
                                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Type*</td>
                            <td>
                                <asp:DropDownList ID="cmbRole" runat="server" Height="20px" Width="126px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Username*</td>
                            <td>
                                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ErrorMessage="Required"
                                    ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Password*</td>
                            <td>
                                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                    ErrorMessage="Required"
                                    ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Email</td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Phone 1</td>
                            <td>
                                <asp:TextBox ID="txtPhone1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td>Gender*</td>
                            <td>
                                <asp:DropDownList ID="cmbGender" runat="server" Height="20px" Width="120px"></asp:DropDownList>

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                     ErrorMessage="Required"
                                    ControlToValidate="cmbGender"></asp:RequiredFieldValidator>

                            </td>
                        </tr>
                        <tr>
                            <td>DOB</td>
                            <td>
                                <asp:TextBox ID="txtDOB" runat="server"></asp:TextBox>
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
                            <td>Phone 2</td>
                            <td>
                                <asp:TextBox ID="txtPhone2" runat="server"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>Citizenship</td>
                            <td>
                                <asp:TextBox ID="txtCitizenship" runat="server"></asp:TextBox>
                            </td>
                        </tr>



                    </table>
                </div>

                <fieldset>
                    <legend>Assign Division to this user</legend>
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
                    </asp:Panel>
                </fieldset>

                <div>
                    <%--style="float: left; border: solid 1px darkgreen; text-align: center;"--%>
            Upload Image<br />
                    <a href="#">
                        <img src="~/Images/user.png" /><br />
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </a>
                </div>
            </div>
             </ContentTemplate>
    </asp:UpdatePanel>
            <div>
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                <%--<div>
            <asp:Panel runat="server" ID="pnlQualification">

                <fieldset>
                    <legend>Qualification</legend>
                    <table>
                        <tr>
                            <td>Degree</td>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Field Of Study</td>
                            <td>
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>University</td>
                            <td>
                                <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Country</td>
                            <td>
                                <asp:TextBox ID="TextBox15" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Completion Year</td>
                            <td>
                                <asp:TextBox ID="TextBox16" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Degree</td>
                            <td>
                                <asp:TextBox ID="TextBox17" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <div>
        <asp:Panel ID="Panel1" runat="server">
            <table>
                <tr>
                    <td>Research Interest</td>
                    <td>
                        <asp:TextBox ID="TextBox19" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td>Hobbies</td>
                    <td>
                        <asp:TextBox ID="TextBox20" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>

            </asp:Panel>
        </div>--%>
            </div>
       
</asp:Content>
