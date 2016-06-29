<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Assign.ascx.cs" Inherits="One.Views.Role.Assign" %>
<asp:Panel runat="server" ID="pnlMain">
    <h3>Roles Assign to users</h3>
    <asp:Panel ID="Panel1" runat="server">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>

                <div style="text-align: center;">
                    <asp:Label ID="Label1" runat="server" Text="Chooose Role"></asp:Label>
                    &nbsp;&nbsp;
        <asp:DropDownList ID="cmbRole" runat="server" Height="24px" Width="130px"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="valiRole" runat="server"
                        ErrorMessage="Required" ForeColor="#FF3300"
                        ControlToValidate="cmbRole"></asp:RequiredFieldValidator>
                    <br />
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlGrpAsg" runat="server">
                <div id="unassignedDiv" style="float: left; width: 38%">
                    <strong>Unassigned Users</strong>
                    <asp:ListBox ID="lstUnAsg" runat="server" Width="100%" Height="100%"></asp:ListBox>
                </div>
                <div style="float: left; width: 23%; text-align: center; height: 100%; padding-top: 5px;">
                    <br />
                    <br />
                    <asp:Button ID="btnAsg" runat="server" Text="Assign to Role →" Width="90%" OnClick="btnAsg_Click" CausesValidation="False" />
                    <br />
                    <br />
                    <asp:Button ID="btnRemove" runat="server" Text="← Remove from Role" Width="90%" OnClick="btnRemove_Click" CausesValidation="False" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="75px" OnClick="btnSave_Click" />
                </div>
                <div id="assignedDiv" style="float: left; width: 38%">
                    <strong>Assigned Users</strong>
                    <asp:RequiredFieldValidator ID="valiAsgCount" runat="server"
                         ErrorMessage="No users to save."
                        ControlToValidate="lstAsg" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    <asp:ListBox ID="lstAsg" runat="server" Width="100%" Height="100%"></asp:ListBox>
                </div>

            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Panel ID="Panel2" runat="server" Width="100%"></asp:Panel>
</asp:Panel>
