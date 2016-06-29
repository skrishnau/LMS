<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TreeViewUc.ascx.cs" Inherits="One.Views.UserControls.Structure.TreeViewOverriden.TreeViewUc" %>



<%@ Register tagPrefix="MyTV" namespace="Academic.ViewModel.AcademicPlacement" assembly="Academic.ViewModel" %>
<div>
    

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
                <asp:HiddenField ID="hidAcaId" runat="server" Value="0" />
                <asp:HiddenField ID="hidMaxSubYear" runat="server" Value="0"/>
            <table>
                <tr>
                     <td>Current Academic Year</td>
                        <td>
                            <asp:DropDownList ID="cmbAcademicYear" runat="server" Height="20px" Width="140px"
                                OnSelectedIndexChanged="cmbAcademicYear_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="valiAca" runat="server" ErrorMessage="Required"
                                ForeColor="#FF3300" ControlToValidate="cmbAcademicYear"></asp:RequiredFieldValidator>
                        </td>
                </tr>
                <tr>
                     <td>Session</td>
                        <td>
                            <asp:DropDownList ID="cmbSession" runat="server" Height="20px" Width="140px" AutoPostBack="True" OnSelectedIndexChanged="cmbSession_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="valiSession" runat="server"
                                ErrorMessage="Required" ForeColor="#FF3300" ControlToValidate="cmbSession"></asp:RequiredFieldValidator>
                        </td>
                </tr>
            </table>

            <h3>Classes for Academic Year&nbsp;
                <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" ImageUrl="~/Content/Icons/Refresh/refresh.png" OnClick="ImageButton1_Click" />
            </h3>
            <asp:Label ID="txtAcaYear" runat="server" Text="Label"></asp:Label>
            <%--<asp:TreeView ID="TreeView1" runat="server" ShowCheckBoxes="All" ShowLines="True" OnTreeNodeCheckChanged="TreeView1_TreeNodeCheckChanged" OnTreeNodeCollapsed="TreeView1_TreeNodeCollapsed" ShowExpandCollapse="False">
            </asp:TreeView>--%>
            <MyTV:MyTreeView ID="TreeView1" runat="server" ShowCheckBoxes="All" ShowLines="True" OnTreeNodeCheckChanged="TreeView1_TreeNodeCheckChanged" OnTreeNodeCollapsed="TreeView1_TreeNodeCollapsed">
            </MyTV:MyTreeView>

        </ContentTemplate>
    </asp:UpdatePanel>
    &nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Save" Width="76px" OnClick="Button1_Click" />
</div>

