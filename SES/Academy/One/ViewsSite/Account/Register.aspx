<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="One.ViewsSite.Account.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server"
                        OnCreatedUser="CreateUserWizard1_CreatedUser">
                        <WizardSteps>
                            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                            </asp:CreateUserWizardStep>
                            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server"
                                Title="ha ha" AllowReturn="False">
                                <ContentTemplate>
                                    <div>
                                        Your account has been successfully created.
                                        <br/>
                                         <asp:HyperLink ID="HyperLink1" runat="server"
                                             CssClass="link_button"
                                             NavigateUrl="~/Views/">
                                             Continue
                                         </asp:HyperLink> 
                                    </div>
                                </ContentTemplate>

                            </asp:CompleteWizardStep>
                        </WizardSteps>
                    </asp:CreateUserWizard>
                </asp:View>

                <asp:View ID="View2" runat="server">
                    You are already logged in. You can't create another user.
                                        <br/>
                    <asp:HyperLink ID="HyperLink1" CssClass="link_button" runat="server"
                        NavigateUrl="~/Views/">
                            Ok
                    </asp:HyperLink>
                </asp:View>

            </asp:MultiView>

        </div>
    </form>
</body>
</html>
