<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="One.ViewsSite.Account.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .reg-data {
            text-align: right;
        }
        .reg-field {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <div style="text-align: center;">
                                <table>
                                    <tr>
                                        <td class="reg-data">User Name: </td>
                                        <td class="reg-field">
                                            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                                            *
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ErrorMessage="Required" ForeColor="red"
                                                ControlToValidate="txtUserName"
                                                ></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="reg-data">Password: </td>
                                        <td class="reg-field">
                                            <asp:TextBox ID="txtPassword" runat="server"
                                                TextMode="Password"
                                                ></asp:TextBox>
                                            *
                                            <ajaxToolkit:PasswordStrength ID="PasswordStrength1" runat="server" PreferredPasswordLength="6"/>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                  
                                                ErrorMessage="Required" ForeColor="red"
                                                ControlToValidate="txtPassword"
                                                ></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td  class="reg-data">Confirm Password: </td>
                                        <td class="reg-field">
                                            <asp:TextBox ID="txtConfirmPassword" runat="server"
                                                TextMode="Password"                                                
                                                ></asp:TextBox>
                                            *
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                ErrorMessage="Required" ForeColor="red"
                                                ControlToValidate="txtConfirmPassword"
                                                ></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="reg-data">Email </td>
                                        <td class="reg-field">
                                            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                                            *
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                ErrorMessage="Required" ForeColor="red"
                                                ControlToValidate="txtEmail"
                                                ></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="reg-data">Security Question: </td>
                                        <td class="reg-field">
                                            <asp:DropDownList ID="ddlSecurityQuestion" runat="server" Height="20px">
                                            </asp:DropDownList>
                                            *
                                             
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="reg-data">Security Answer: </td>
                                        <td class="reg-field">
                                            <asp:TextBox ID="txtSecurityAnswer" runat="server"></asp:TextBox>
                                            *
                                              
                                        </td>
                                    </tr>

                                </table>
                                <div style="width: 180px;">
                                    <asp:Label ID="lblPasswordError" runat="server" ForeColor="red" Visible="false" ClientIDMode="Static"
                                        Text="The password and confirm password must match."></asp:Label>
                                </div>
                                <div style="text-align: left;">
                                    <asp:Button ID="btnCreate" runat="server" Text="Create User" OnClick="btnCreate_Clicked" />
                                </div>
                            </div>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                </asp:View>

                <asp:View ID="View2" runat="server">
                    You are already logged in. You can't create another user.
                                        <br />
                    <asp:HyperLink ID="HyperLink1" CssClass="link_button" runat="server"
                        NavigateUrl="~/Views/">
                            Ok
                    </asp:HyperLink>
                </asp:View>

                <asp:View ID="View3" runat="server">
                    <div>
                        Your account has been successfully created.
                                        <br />
                        <asp:HyperLink ID="HyperLink2" runat="server"
                            CssClass="link_button"
                            NavigateUrl="~/Views/">
                                             Continue
                        </asp:HyperLink>
                    </div>
                </asp:View>

            </asp:MultiView>

        </div>
    </form>
</body>
</html>
