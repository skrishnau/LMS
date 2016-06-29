<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentCreateUc.ascx.cs" Inherits="One.Views.Student.Batch.StudentDisplay.Students.StudentCreate.StudentCreateUc" %>


<div>
    <asp:Label ID="lblSaveStatus" runat="server" Text="Label" BackColor="#6666FF" Visible="False"></asp:Label>
    <asp:HiddenField ID="hidId" runat="server" Value="0" />
    <strong>General</strong>
    <hr />
    <table>
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
    <strong>Image</strong>
    <hr />

    <div>
        <%--style="float: left; border: solid 1px darkgreen; text-align: center;"--%>

        <a href="#">
            <img src="~/Images/user.png" /><br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </a>
    </div>
    <div>
        <br />
        &nbsp;&nbsp;
        <asp:Button ID="btnSaveNAddMore" runat="server" Text="Save and Add More" OnClick="btnSave_Click" Width="140px" />
        &nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Button ID="btnSaveNReturn" runat="server" Text="Save and Return" OnClick="btnSave_Click" Width="140px" />

    </div>
    <asp:HiddenField ID="hidProgramBatchId" runat="server" Value="0"/>
    <asp:HiddenField ID="hidSchoolId" runat="server" Value="0"/>
</div>
