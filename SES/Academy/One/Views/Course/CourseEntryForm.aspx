<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="CourseEntryForm.aspx.cs" Inherits="One.Views.Course.CourseEntryForm" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">

    <fieldset>
        <legend>Course</legend>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <strong>General</strong>
                <hr/>
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
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4"  runat="server" ControlToValidate="txtCredit" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <tr>
                        <td>Completion Hours</td>
                        <td>
                            <asp:TextBox ID="txtCompletionHours" runat="server" TextMode="Number"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Full Marks</td>
                        <td>
                            <asp:TextBox ID="txtFullMarks" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Pass Percent</td>
                        <td>
                            <asp:TextBox ID="txtPassPercent" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                </table>

                <br/>


 <strong>Optional</strong>
                <hr/>
                <asp:Panel ID="pnlOpt" runat="server">
                   
                  
                    <asp:CheckBoxList ID="chkListHas" runat="server" CellPadding="2" CellSpacing="2" RepeatDirection="Vertical">
                        <asp:ListItem Selected="True">Has Theory</asp:ListItem>
                        <asp:ListItem>Has Lab</asp:ListItem>
                        <asp:ListItem>Has Tutorial</asp:ListItem>
                        <asp:ListItem>Has Project</asp:ListItem>
                    </asp:CheckBoxList>
                    <asp:CheckBoxList ID="chkListIs" runat="server" CellPadding="2" CellSpacing="2" RepeatDirection="Vertical">
                        <asp:ListItem>Is Elective</asp:ListItem>
                        <asp:ListItem>Is Out of Syllabus</asp:ListItem>
                    </asp:CheckBoxList>
                    <hr />
                </asp:Panel>
                <asp:CheckBox ID="ckhIsActive" runat="server" Checked="True" Text="Is Active" Visible="False" />
                <asp:CheckBox ID="chkIsVoid" runat="server" Text="Is Void" Visible="False" />
                <br />
                <hr />
            </ContentTemplate>
        </asp:UpdatePanel>
    </fieldset>
    <div style="text-align: left">
        &nbsp;&nbsp;
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Height="30px" Width="85px" />
    </div>
    <br/>
</asp:Content>
