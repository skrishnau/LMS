<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentCreateUc.ascx.cs" Inherits="One.Views.Student.Create.StudentCreateUc" %>

<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <fieldset>
                <legend>Student</legend>
                <strong>General</strong>
                <hr />
                <div>
                    <asp:Label ID="lblSaveStatus" runat="server" Text="Label" BackColor="#6666FF" Visible="False"></asp:Label>
                    <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    <asp:HiddenField ID="hidRoleId" runat="server" Value="0" />
                    <asp:DropDownList ID="cmbRole" runat="server" Visible="false" Height="16px" Width="32px"></asp:DropDownList>
                </div>
                <div style="float: none">
                    <div style="float: none;">
                        <table>

                            <%--                        <tr>
                            <td>School</td>
                            <td>
                                <asp:DropDownList ID="cmbSchool" runat="server" Height="20px" Width="126px" AutoPostBack="True" OnSelectedIndexChanged="cmbSchool_SelectedIndexChanged"></asp:DropDownList>
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtFirstName" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>--%>

                            <tr>
                                <td>First Name*</td>
                                <td>
                                    <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                        ErrorMessage="Required"
                                        ControlToValidate="txtFirstName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
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
                                <td>Gender*</td>
                                <td>
                                    <asp:DropDownList ID="cmbGender" runat="server" Height="22px" Width="125px"></asp:DropDownList>

                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                                        ErrorMessage="Required"
                                        ControlToValidate="cmbGender" ForeColor="#FF3300"></asp:RequiredFieldValidator>

                                </td>
                            </tr>
                            <tr>
                                <td>Class Roll No. * </td>
                                <td>
                                    <asp:TextBox ID="txtCRN" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Exam Roll No. </td>
                                <td>
                                    <asp:TextBox ID="txtExamRoll" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <%--   <tr>
                            <td>Type</td>
                            <td>
                                <asp:DropDownList ID="cmbRole" runat="server" Height="20px" Width="126px" Enabled="False"></asp:DropDownList>
                            </td>
                        </tr>--%>
                            <tr>
                                <td>Username*</td>
                                <td>
                                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                        ErrorMessage="Required"
                                        ControlToValidate="txtUserName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Password*</td>
                                <td>
                                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                        ErrorMessage="Required"
                                        ControlToValidate="txtPassword" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>Email</td>
                                <td>
                                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Phone </td>
                                <td>
                                    <asp:TextBox ID="txtPhone1" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <strong>Image</strong>
                        <hr />

                        <div>
                            <%--style="float: left; border: solid 1px darkgreen; text-align: center;"--%>
                            
                            <a href="#">
                                <img src="~/Images/user.png" /><br />
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </a>
                        </div>
                        <br/>
                        <strong>Interest</strong>
                        <hr/>
                        <br />
                        <strong>Optional</strong>
                        <hr />
                        <table>

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

                            <%--<tr>
                                <td>Phone 2</td>
                                <td>
                                    <asp:TextBox ID="txtPhone2" runat="server"></asp:TextBox>
                                </td>
                            </tr>--%>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                            <%-- <tr>
                            <td>Citizenship</td>
                            <td>
                                <asp:TextBox ID="txtCitizenship" runat="server"></asp:TextBox>
                            </td>
                        </tr>--%>
                            <tr>
                                <td>Religion</td>
                                <td>
                                    <asp:TextBox ID="txtReligion" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Nationality</td>
                                <td>
                                    <asp:TextBox ID="txtNationality" runat="server"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td>Guardian Name</td>
                                <td>
                                    <asp:TextBox ID="txtGuarName" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Gueardian Email</td>
                                <td>
                                    <asp:TextBox ID="txtGuarEmail" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Guardian Contact</td>
                                <td>
                                    <asp:TextBox ID="txtGuarContact" runat="server" TextMode="Number"></asp:TextBox>
                                </td>
                            </tr>


                        </table>
                    </div>




                </div>
            </fieldset>

        </ContentTemplate>
    </asp:UpdatePanel>
    <div>
        <br/>
        &nbsp;&nbsp;
        <asp:Button ID="btnSaveNAddMore" runat="server" Text="Save and Add More" OnClick="btnSave_Click" Width="140px" />
        &nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Button ID="btnSaveNReturn" runat="server" Text="Save and Return" OnClick="btnSave_Click" Width="140px" />

    </div>
 <br/>
</div>