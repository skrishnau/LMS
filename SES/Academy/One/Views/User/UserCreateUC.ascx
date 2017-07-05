<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserCreateUC.ascx.cs" Inherits="One.Views.User.UserCreateUC" %>
<%@ Register TagPrefix="uc1" TagName="ReqImageUC" Src="~/Views/UserControls/ReqImageUC.ascx" %>
<%@ Register Src="../UserControls/DateChooser.ascx" TagName="DateChooser" TagPrefix="uc2" %>
<%@ Register Src="~/Views/ActivityResource/FileResource/FileResourceItems/FilesDisplay.ascx" TagPrefix="uc1" TagName="FilesDisplay" %>

<div class="data-entry-body">

    <div>
        <asp:Label ID="lblSaveStatus" runat="server" Text="Couldn't save" BackColor="#6666FF" Visible="False"></asp:Label>
        <asp:HiddenField ID="hidEditMode" runat="server" Value="New" />
        <%--<asp:DropDownList ID="cmbRole" runat="server" Height="20px" Width="126px" Visible="false"></asp:DropDownList>--%>
        <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
        <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
        <asp:HiddenField ID="hidPageKey" runat="server" Value="" />
    </div>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>

            <div class="data-entry-section">
                <div style="float: none;">
                    <div class="data-entry-section-heading">
                        General
                        <hr />
                    </div>

                    <table>
                        <tr>
                            <td class="data-type">First Name *</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                    ErrorMessage="Required" ValidationGroup="required"
                                    ControlToValidate="txtFirstName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Middle Name</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtMidName" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Last Name</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="data-type">Username *
                            </td>
                            <td class="data-value">
                                <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valiUserName" runat="server"
                                    ErrorMessage="Required" ValidationGroup="required"
                                    ControlToValidate="txtUserName" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Password *
                            </td>
                            <td class="data-value">
                                <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                    ErrorMessage="Required" ValidationGroup="required"
                                    ControlToValidate="txtPassword" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Email *
                            </td>
                            <td class="data-value">
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ErrorMessage="Required" ValidationGroup="required"
                                    ControlToValidate="txtEmail" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ForeColor="red"
                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ValidationGroup="required"
                                    ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format"></asp:RegularExpressionValidator>

                            </td>



                        </tr>

                        <tr>
                            <td class="data-type">Role *</td>
                            <td>
                                <asp:DropDownList ID="ddlRole" runat="server" Width="150"></asp:DropDownList>
                            </td>
                        </tr>


                        <%--   <tr>
                            <td class="data-type">Email Display</td>
                            <td class="data-value">
                                <asp:DropDownList ID="cmbEmailDisplay" runat="server" Height="20px" Width="132px"></asp:DropDownList>
                            </td>
                        </tr>--%>
                        <tr>
                            <td class="data-type">Phone</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtPhone1" runat="server"></asp:TextBox>
                            </td>
                        </tr>

                        <%--  <tr>
                    <td class="data-type">Description</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="98px"></asp:TextBox>
                    </td>
                </tr>--%>
                    </table>
                    <br />
                </div>
                <div>
                    <strong>Image</strong>
                    <hr />

                    <%-- <a href="#">--%>
                    <%--<img src="~/Images/user.png" style="width: 57px" />--%><br />
                    <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>

                    <uc1:FilesDisplay runat="server" ID="FilesDisplay" />
                    <%--</a>--%>
                </div>
                <br />
                <%--<div class="user-optional">
                    <strong>Interest</strong>
                    <hr />
                    <div style="margin: 0 5px 0 20px;">
                        <div>
                            <div style="float: left">
                                List of Interest
                            </div>
                            <div style="float: left">
                                <asp:Panel ID="pnlInterest" runat="server"></asp:Panel>
                            </div>
                            <div style="clear: both"></div>
                        </div>
                        <asp:TextBox ID="txtInterest" runat="server" OnTextChanged="txtInterest_TextChanged"></asp:TextBox>
                    </div>
                </div>--%>
                <br />

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="data-entry-section-heading">
                            <asp:LinkButton ID="lnkShowOptional" runat="server" OnClick="lnkShowOptional_Click"
                                CausesValidation="False" Font-Underline="False">►</asp:LinkButton>
                            Optional
                    <hr />
                        </div>
                        <div class="data-entry-section-body">

                            <table runat="server" id="tableOpt" visible="False">

                                <tr>
                                    <td>Gender</td>
                                    <td>
                                        <asp:DropDownList ID="cmbGender" runat="server" Height="20px" Width="120px"></asp:DropDownList>

                                    </td>
                                </tr>
                                <tr>
                                    <td>DOB</td>
                                    <td>
                                        <asp:TextBox ID="txtDOB" ClientIDMode="Static" runat="server"></asp:TextBox>
                                        <script type="text/javascript">
                                            function pageLoad() {
                                                $('#txtDOB').unbind();
                                                $("#txtDOB").datepicker();
                                            }
                                        </script>
                                        <%--<uc2:DateChooser ID="DateChooser1" runat="server" />--%>
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
                            </table>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <br />



        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="save-div">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" ValidationGroup="required" />
    </div>
</div>
