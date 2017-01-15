<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="One.Views.Profile" %>


<asp:Content runat="server" ID="contnet1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">Profile
    </h3>
    <hr />
    <div class="data-entry-section">
        <div>
            <asp:MultiView ID="MultiView1" ActiveViewIndex="0" runat="server">
                <%-- ---------------------view 0 ------------------------- --%>
                <asp:View ID="View1" runat="server">
                    <table>
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td class="data-type">Name</td>
                                        <td class="data-value">
                                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="data-type">Username</td>
                                        <td class="data-value">

                                            <asp:Label ID="lblUsername" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="data-type">Password</td>
                                        <td class="data-value">
                                            <asp:LinkButton ID="lnkPassword" runat="server" OnClick="lnkPassword_OnClick">Change password</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="data-type">Email</td>
                                        <td class="data-value">
                                            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="data-type">Security question</td>
                                        <td class="data-value">
                                            <asp:LinkButton ID="lnkSecurityQuestion" runat="server" OnClick="lnkSecurityQuestion_OnClick">Change security question</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>

                            </td>
                            <td>
                                <%-- image --%>
                                <asp:Image ID="img" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:View>

                <%-- --------------------------view 1 ------------------ --%>
                <asp:View ID="View2" runat="server">
                    <div class="data-entry-section">
                        <div class="data-entry-section-heading">
                            Change Password
                            <hr />
                        </div>
                        <div class="data-entry-section-body">
                            <table>
                                <tr>
                                    <td class="data-type">Earlier password</td>
                                    <td class="data-value">
                                        <asp:TextBox ID="txtearlierPassword" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                            ControlToValidate="txtearlierPassword" ValidationGroup="password"
                                            ErrorMessage="Required" ForeColor="red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="data-type">New password</td>
                                    <td class="data-value">
                                        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                            ControlToValidate="txtNewPassword" ValidationGroup="password"
                                            ErrorMessage="Required" ForeColor="red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="data-type">Confirm new password</td>
                                    <td class="data-value">
                                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                            ControlToValidate="txtConfirmPassword" ValidationGroup="password"
                                            ErrorMessage="Required" ForeColor="red"></asp:RequiredFieldValidator>
                                        <asp:Label ID="lblConfirmCheck" runat="server"
                                            Visible="False" ForeColor="red"
                                            Text="New password and confirm password must match"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="save-div">
                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSavePassword_OnClick" ValidationGroup="password" />
                            &nbsp; &nbsp; &nbsp;
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_OnClick" ValidationGroup="cancel" />
                            &nbsp;&nbsp;
                            <asp:Label ID="lblPasswordError" runat="server"
                                Visible="False"
                                Text="Couldn't save." ForeColor="red"></asp:Label>
                        </div>
                    </div>
                </asp:View>

                <%-- ----------------------view 0 -------------------------- --%>
                <asp:View ID="View3" runat="server">
                    <div class="data-entry-section">
                        <div class="data-entry-section-heading">
                            Change Security Question
                            <hr />
                        </div>
                        <div class="data-entry-section-body">
                            <table>
                                <tr>
                                    <td class="data-type">Your password</td>
                                    <td class="data-value">
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="question"
                                            ControlToValidate="txtPassword"
                                            ErrorMessage="Required" ForeColor="red"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="data-type">Question</td>
                                    <td class="data-value">
                                        <asp:DropDownList ID="ddlQuestion" runat="server"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="question"
                                            ControlToValidate="ddlQuestion"
                                            ErrorMessage="Required" ForeColor="red"></asp:RequiredFieldValidator>
                                        <asp:Label ID="lblQuestionError" runat="server"
                                            Visible="False" ForeColor="red"
                                            Text="Required"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="data-type">Answer</td>
                                    <td class="data-value">
                                        <asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                            ValidationGroup="question"
                                            ControlToValidate="txtAnswer"
                                            ErrorMessage="Required" ForeColor="red"></asp:RequiredFieldValidator>

                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="save-div">
                            <asp:Button ID="btnSaveQuestion" runat="server" Text="Save" OnClick="btnSaveQuestion_OnClick"
                                ValidationGroup="question" />
                            &nbsp; &nbsp; &nbsp;
                            <asp:Button ID="btnCancel1" runat="server" Text="Cancel" OnClick="btnCancel_OnClick" ValidationGroup="cancel" />
                            &nbsp;&nbsp;
                            <asp:Label ID="lblQuestionSaveError" runat="server"
                                Visible="False"
                                Text="Couldn't save." ForeColor="red"></asp:Label>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="title">
    Profile edit
</asp:Content>
