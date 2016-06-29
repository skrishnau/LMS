<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="StudentGroup.aspx.cs" Inherits="One.Views.Student.Create.StudentGroup" %>

<%@ Register Src="../StudentGroupAssignUC.ascx" TagName="StudentGroupAssignUC" TagPrefix="uc1" %>
<%@ Register Src="~/Views/User/UserCreateUC.ascx" TagPrefix="uc1" TagName="UserCreateUC" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



            <asp:Panel ID="pnlGroup" runat="server">
                <fieldset>
                    <legend>Student Group</legend>
                    <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    <table>
                        <%--  <tr>
                            <td>School</td>
                            <td class="auto-style1">
                                <asp:DropDownList ID="cmbSchool" runat="server" Height="20px" Width="126px"></asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="cmbSchool" ErrorMessage="Required"
                                    ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>--%>

                        <tr>
                            <td>Parent</td>
                            <td>
                                <asp:DropDownList ID="cmbParent" runat="server" Height="23px" Width="125px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Name of Group &nbsp;</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                    runat="server" ControlToValidate="txtName"
                                    ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Description</td>
                            <td>
                                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="69px" Width="218px"></asp:TextBox>
                            </td>
                        </tr>

                    </table>
                    <asp:CheckBox ID="chkIsActive" Checked="true" Text="Is Active" Visible="False" runat="server" />
                </fieldset>


            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="77px" />
    <hr/>
    <div style="border: 3px solid lightgray">
        <asp:Panel ID="pnlStds" runat="server" Visible="False">
            <div style="text-align: center;">
                <div>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" CellSpacing="5" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="0">Add From Existing</asp:ListItem>
                        <asp:ListItem Value="1">Create new student</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View1" runat="server">
                    <div>
                        <br />
                        <asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>
                        <br />
                        <strong>Add Students to this group</strong>
                        <br />
                    </div>
                    <uc1:StudentGroupAssignUC ID="stdGrpAsgUc" runat="server" />

                </asp:View>
                <asp:View ID="View2" runat="server">
                    <uc1:UserCreateUC runat="server" ID="UserCreateUC" />
                </asp:View>
            </asp:MultiView>
        </asp:Panel>

    </div>
</asp:Content>
<%--<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            width: 183px;
        }
    </style>
   
</asp:Content>--%>

