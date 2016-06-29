<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StructureSelection.ascx.cs" Inherits="One.Views.UserControls.Structure.StructureSelection" %>


<div>
    <fieldset>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>


                <legend>Add Classes to Academic Year</legend>
                <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
                <asp:HiddenField ID="hidAcaId" runat="server" Value="0" />
                <asp:HiddenField ID="hidMaxSubYear" runat="server" Value="0"/>
                &nbsp;
        <asp:Label ID="lblMsg" runat="server" ForeColor="#CC6600" Text="Label" Visible="False"></asp:Label>
                <table>
                    <tr>
                        <td>Level</td>
                        <td>
                            <asp:DropDownList ID="cmbLevel" runat="server" Height="20px" Width="140px"
                                AutoPostBack="True" OnSelectedIndexChanged="cmbLevels_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Faculty</td>
                        <td>
                            <asp:DropDownList ID="cmbFac" runat="server" Height="20px" Width="140px" AutoPostBack="True" OnSelectedIndexChanged="cmbFaculties_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Program </td>
                        <td>
                            <asp:DropDownList ID="cmbProgram" runat="server" Height="20px" Width="140px" AutoPostBack="True" OnSelectedIndexChanged="cmbPrograms_SelectedIndexChanged"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Year</td>
                        <td>
                            <asp:DropDownList ID="cmbYear" runat="server" Height="20px" Width="140px" AutoPostBack="True" OnSelectedIndexChanged="cmbYear_SelectedIndexChanged"></asp:DropDownList>
                        </td>
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
                        <td>Sub-Years</td>
                        <td>
                            <asp:DropDownList ID="cmbSubYear" runat="server" Height="20px" Width="140px" AutoPostBack="True" OnSelectedIndexChanged="cmbSubYear_SelectedIndexChanged1">
                            </asp:DropDownList>
                        </td>

                        <td>Session</td>
                        <td>
                            <asp:DropDownList ID="cmbSession" runat="server" Height="20px" Width="140px" AutoPostBack="True"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="valiSession" runat="server"
                                ErrorMessage="Required" ForeColor="#FF3300" ControlToValidate="cmbSession"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <%--         <tr>

                <td>
                    <asp:Panel ID="pnlPhase" runat="server">
                        Phase &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="cmbPhase" runat="server" Height="20px" Width="140px"></asp:DropDownList>
                    </asp:Panel>
                </td>
                <td>
                    <asp:Panel ID="pnlSubSession" runat="server">
                        Sub-Session&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:DropDownList ID="cmbSubSession" runat="server" Height="2px" Width="140px"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="valiSubSession" runat="server" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </asp:Panel>
                </td>
            </tr>--%>
                </table>
                <asp:Panel ID="pnlSubYearPosition" runat="server">
                    All 
                    <asp:TextBox ID="txtSubYearPosition" runat="server" Width="29px" AutoPostBack="True" OnTextChanged="txtSubYearPosition_TextChanged" CausesValidation="True"></asp:TextBox>
                    <sup>th</sup> SubYear in each Year.
                    <asp:RequiredFieldValidator ID="valiPostion" runat="server" ControlToValidate="txtSubYearPosition" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>

                    <br />
                    <em>Starts from 1 to maximum number of sub-years for a year.</em>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        &nbsp;&nbsp;
             <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="76px" />
        <br />
        <br />

    </fieldset>
</div>
