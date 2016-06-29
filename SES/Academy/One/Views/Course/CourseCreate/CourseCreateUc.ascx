<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseCreateUc.ascx.cs" Inherits="One.Views.Course.CourseCreate.CourseCreateUc" %>

<div>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <strong>New Course</strong>
            <hr />
            <asp:Label ID="lblMessage" runat="server" Text="Couldn't Save." BackColor="#FFCCFF" ForeColor="#FF3300" Visible="False"></asp:Label>
            <table>
                <tr>
                    <td>Subject Category</td>
                    <td>
                        <asp:DropDownList ID="cmbCategory" runat="server" Height="24px" Width="104px"></asp:DropDownList>
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Content/Icons/plus2.png" OnClick="ImageButton2_Click" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="cmbCategory"
                            ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Name*</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Code*</td>
                    <td>
                        <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCode" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Credit*</td>
                    <td>
                        <asp:TextBox ID="txtCredit" runat="server" TextMode="Number"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCredit" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
            <br />


            <div style="text-align: left">
                &nbsp;&nbsp;
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Height="30px" Width="85px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Height="30px" Width="85px" OnClick="btnCancel_Click" Visible="False" />
            </div>
            <br />

            <asp:HiddenField ID="hidSubjectGroupId" runat="server" Value="0" />
            <asp:HiddenField ID="hidYearId" runat="server" Value="0" />
            <asp:HiddenField ID="hidSubYearId" runat="server" Value="0" />

        </ContentTemplate>
    </asp:UpdatePanel>
</div>
