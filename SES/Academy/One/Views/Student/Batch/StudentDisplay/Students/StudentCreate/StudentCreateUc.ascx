<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentCreateUc.ascx.cs" Inherits="One.Views.Student.Batch.StudentDisplay.Students.StudentCreate.StudentCreateUc" %>


<div style="margin: 5px; margin-left: auto; margin-right: auto; padding-bottom: 5px; border: 3px solid #557d96; text-align: center; width: 70%;">
    <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <div style="text-align: center; font-size: 1.2em; font-weight: 700; color: white; background-color: #557d96;">
        Student Create
                <hr />
    </div>
    <div style="padding: 0 20px 0 20px; text-align: left;">
        <div>
            <%--<asp:Label ID="lblSaveStatus" runat="server" Text="Label" BackColor="#6666FF" Visible="False"></asp:Label>--%>
            <strong>General</strong>
            <hr />
            <table>
                <tr>
                    <td>First Name*</td>
                    <td>
                        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                            ErrorMessage="Required"
                            ControlToValidate="txtFirstName" ValidationGroup="studentCreateGrp" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Middle Name</td>
                    <td>
                        <asp:TextBox ID="txtMiddleName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Last Name</td>
                    <td>
                        <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <%-- <tr>
            <td>Gender*</td>
            <td>
                <asp:DropDownList ID="cmbGender" runat="server" Height="22px" Width="125px"></asp:DropDownList>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server"
                    ErrorMessage="Required"
                    ControlToValidate="cmbGender" ForeColor="#FF3300"></asp:RequiredFieldValidator>

            </td>
        </tr>--%>
                <tr>
                    <td>Class Roll No. * </td>
                    <td>
                        <asp:TextBox ID="txtCRN" runat="server"></asp:TextBox>

                    </td>
                </tr>

                <tr>
                    <td>Username*</td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>


                        <asp:RequiredFieldValidator ID="valiUserName" runat="server"
                            ErrorMessage="Required"
                            ControlToValidate="txtUserName" ValidationGroup="studentCreateGrp" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password*</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                            ErrorMessage="Required"
                            ControlToValidate="txtPassword" ValidationGroup="studentCreateGrp" ForeColor="#FF3300"></asp:RequiredFieldValidator>
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
        </div>
        <div>

            <%--style="float: left; border: solid 1px darkgreen; text-align: center;"--%>
            <strong>Image</strong>
            <hr />

            <%--<img src="~/Content/Icons/Users/users-icon.png" />--%><br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <%--<asp:FileUpload ID="FileUpload2" runat="server" />--%>
            <%--<br />--%>
            <hr />
        </div>

        <br />

        <%--<asp:Button ID="Button1" runat="server" Text="Button" />--%>

        <asp:HiddenField ID="hidProgramBatchId" runat="server" Value="0" />
        <%--<asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />--%>
        <asp:HiddenField ID="hidId" runat="server" Value="0" />
    </div>
    <%--  </ContentTemplate>
    </asp:UpdatePanel>--%>
    <%--<asp:Button ID="Button2" runat="server" Text="Button" />--%>
    <div style="clear: both; text-align: center; padding-bottom: 10px;">
        <asp:Button ID="btnSaveNAddMore" runat="server" ValidationGroup="studentCreateGrp" Text="Save and Add More" OnClick="btnSave_Click" Width="140px" />
        &nbsp;&nbsp; &nbsp;
                    <asp:Button ID="btnSaveNReturn" runat="server" ValidationGroup="studentCreateGrp" Text="Save and Close" OnClick="btnSave_Click" Width="140px" />
        &nbsp;&nbsp; &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="130px" OnClick="btnCancel_Click" />
    </div>
</div>
