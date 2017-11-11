<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Assign.ascx.cs" Inherits="One.Views.Role.Assign" %>
<asp:Panel runat="server" ID="pnlMain">

    <div>
        <div style="">
            <asp:Label ID="Label1" runat="server"
                Text="Chooose Role"></asp:Label>
            &nbsp;&nbsp;
                    <asp:DropDownList ID="cmbRole" runat="server"
                        ToolTip="Save before changing role" AutoPostBack="True"
                        CausesValidation="False"
                        Height="24px" Width="130px" OnSelectedIndexChanged="cmbRole_SelectedIndexChanged">
                    </asp:DropDownList>
            <asp:RequiredFieldValidator ID="valiRole" runat="server"
                ErrorMessage="Choose..." ForeColor="#FF3300"
                ControlToValidate="cmbRole"></asp:RequiredFieldValidator>
            <br />
        </div>

    </div>
    <br />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>



            <asp:Panel ID="pnlRoleAsg" runat="server" Visible="False">
                <div style="text-align: center; font-weight: 500; font-size: 1.1em;">
                    <asp:Label ID="lblRoleName" runat="server" Text=""></asp:Label>
                </div>

                <div class="row">
                    <div class="col-md-5">
                        <div class="panel panel-default">
                            <div class="panel-heading">Assigned Users</div>
                            <asp:ListBox ID="lstAsg" runat="server" Width="100%" Height="350px"
                                DataTextField="Name" DataValueField="Id"></asp:ListBox>
                        </div>
                    </div>

                    <div class="col-md-2">
                        <div class="align-middle text-center">
                            <br />
                            <br />
                            <br />
                            <br />
                            <asp:Button ID="btnAsg" runat="server" Text="← Assign to Role"
                                OnClick="btnAsg_Click" CausesValidation="False"
                                CssClass="btn btn-default" />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <asp:Button ID="btnRemove" runat="server" Text="Remove →"
                                OnClick="btnRemove_Click" CausesValidation="False"
                                CssClass="btn btn-default" />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <asp:Button ID="btnSave" runat="server" Text="Save" Width="75px"
                                ToolTip="Save before changing role" CssClass="btn btn-default"
                                OnClick="btnSave_Click" />
                        </div>
                    </div>

                    <div class="col-md-5">
                        <div class="panel panel-default">
                            <div class="panel-heading">Unassigned Users</div>
                            <asp:ListBox ID="lstUnAsg" runat="server" Width="100%" Height="350px"
                                DataValueField="Id" DataTextField="Name"></asp:ListBox>
                        </div>
                    </div>

                </div>


                <%--  <table width="99%;">
                    <tr>
                        <td style="width: 38%;">Assigned users</td>
                        <td style="width: 22%;"></td>
                        <td style="width: 38%">Unassigned users</td>
                    </tr>

                    <tr>

                        <td style="vertical-align: top;"></td>


                        <td style="text-align: center;"></td>


                        <td style="vertical-align: top;"></td>
                    </tr>
                </table>--%>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
