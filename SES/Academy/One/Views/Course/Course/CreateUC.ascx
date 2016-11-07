<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateUC.ascx.cs" Inherits="One.Views.Course.Course.CreateUC" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           

            <div class="data-entry-section">
                <div class="data-entry-section-heading">General</div>
                <hr />
                <div class="data-entry-section-body">
                    <table>
                        <%-- <tr>
                    <td>Subject Category</td>
                    <td>
                        <asp:DropDownList ID="cmbCategory" runat="server" Height="24px" Width="104px"></asp:DropDownList>
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Content/Icons/plus2.png" 
                            
                            OnClick="ImageButton2_Click" />

                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="cmbCategory" ValidationGroup="courseCreateGroup"
                            ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>--%>
                        <tr>
                            <td class="data-type">Name*</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtName"
                                    ValidationGroup="courseCreateGroup"
                                    ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Short Name*</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtShortName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtShortName"
                                    ValidationGroup="courseCreateGroup"
                                    ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Code*</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtCode" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCode"
                                    ValidationGroup="courseCreateGroup"
                                    ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Credit*</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtCredit" runat="server" TextMode="Number" ToolTip="General. It can be changed as per class."></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCredit"
                                    ValidationGroup="courseCreateGroup"
                                    ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td class="data-type">Summary</td>
                            <td class="data-value">
                                <CKEditor:CKEditorControl ID="CKEditor1" runat="server"></CKEditor:CKEditorControl>
                            </td>
                        </tr>


                        <%-- <tr>
                            <td class="data-type">Completion Hours</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtCompletionHours" runat="server" TextMode="Number"></asp:TextBox>
                            </td>
                        </tr>--%>

                        <%-- <tr>
                            <td class="data-type">Completion Hours</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtCompletionHours" runat="server" TextMode="Number"></asp:TextBox>
                            </td>
                        </tr>--%>
                        <%-- <tr>
                            <td class="data-type">Full Marks</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtFullMarks" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Pass Percent</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtPassPercent" runat="server"></asp:TextBox>
                            </td>
                        </tr>--%>
                    </table>


                </div>
            </div>
            <br />


            <%-- <strong>Optional</strong>
            <hr />--%>

            <%-- <asp:Panel ID="pnlOpt" runat="server">
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
            </asp:Panel>--%>
            <%--<asp:CheckBox ID="ckhIsActive" runat="server" Checked="True" Text="Is Active" Visible="False" />--%>
            <%--<asp:CheckBox ID="chkIsVoid" runat="server" Text="Is Void" Visible="False" />--%>
            <br />
            <asp:HiddenField ID="hidCategoryId" runat="server" Value="0" />
            <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />


            <div style="text-align: left" class="save-div">
                &nbsp;&nbsp;
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"
                    ValidationGroup="courseCreateGroup"
                    Height="30px" Width="85px" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Height="30px" Width="85px" />
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
</div>
