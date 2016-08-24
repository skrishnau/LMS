<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserEnrollUC_ListDisplay.ascx.cs" Inherits="One.Views.Class.Enrollment.UserEnrollUC_ListDisplay" %>


<div>
    <%@ Register Src="~/Views/UserControls/DateChooser.ascx" TagName="DateChooser" TagPrefix="uc1" %>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div style="margin: 5px;">

                <div class="main-div" id="maindiv">
                    <table style="margin: auto;">
                        <tbody style="vertical-align: top;">
                            <tr>
                                <td style="width: 32%;">Enrolled Users</td>
                                <td style="width: 18%;"></td>
                                <td style="width: 32%;">Not Enrolled Users</td>
                            </tr>
                            <tr>
                                <%-- =================== Left ===================== --%>
                                <td id="existingcell">
                                    <div class="user-cell">
                                        <div>
                                            <asp:ListBox ID="lstAsg" runat="server" Width="99%" Height="100%"></asp:ListBox>
                                        </div>
                                        <br />
                                        <div id="divUserEnrollId" class="user-enroll-search">
                                            <asp:Label ID="lblSearchEnroll" runat="server" Text="Search"></asp:Label>
                                            <br />
                                            <asp:TextBox ID="txtSearchEnroll" runat="server" Text=""></asp:TextBox>
                                            &nbsp;
                                            <asp:Button ID="btnClearEnroll" runat="server" Text="Clear" />
                                        </div>
                                    </div>
                                </td>

                                <%-- ====================== MId ==================== --%>
                                <td>
                                    <div style="text-align: center; margin: 10px 10px 0;">
                                        <div id="addcontrols" style="padding-bottom: 20px;">
                                            <asp:Button ID="btnAdd" runat="server" Text="◄ Add" Width="100px" OnClick="btnAsg_Click" />
                                            <br />
                                            <div id="enroll-option">
                                                <p>
                                                    <asp:Label ID="lblAssignRole" runat="server" Text="Assign Role"></asp:Label>
                                                    <br />
                                                    <asp:DropDownList ID="ddlAssignRole" runat="server" Height="22px" Width="120px"></asp:DropDownList>
                                                </p>
                                                <p>
                                                    <asp:Label ID="lblEnrollmentDuration" runat="server" Text="Enrollment Duration"></asp:Label>
                                                    <br />
                                                    <asp:DropDownList ID="ddlEnrollmentDuration" runat="server" Height="22px" Width="120px"></asp:DropDownList>
                                                </p>
                                                <p>
                                                    <asp:Label ID="lblStartingFrom" runat="server" Text="Starting From"></asp:Label>
                                                    <br />
                                                    <asp:DropDownList ID="ddlStartingFrom" runat="server" Height="22px" Width="120px"></asp:DropDownList>
                                                </p>
                                            </div>
                                        </div>
                                        <div id="removecoontrols">
                                            <asp:Button ID="Button1" runat="server" Text="Remove ►" Width="100px" OnClick="btnRemove_Click" />

                                        </div>
                                    </div>
                                </td>

                                <%-- ======================== right ==================== --%>
                                <td>
                                    <div class="user-cell">
                                            <asp:ListBox ID="lstUnAsg" runat="server" Width="99%" Height="100%"></asp:ListBox>                                        
                                    </div>
                                    <br />
                                    <div id="notenrollsearchId" class="user-enroll-search">
                                        <asp:Label ID="lblSearchNotEnrolled" runat="server" Text="Search"></asp:Label>
                                        <br />
                                        <asp:TextBox ID="tstSearchNotEnroll" runat="server" Text=""></asp:TextBox>
                                        &nbsp;
                                        <asp:Button ID="btnClearNotEnroll" runat="server" Text="Clear" />
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>

            <hr />
            <hr />
            <hr />
            <asp:Panel ID="Panel3" runat="server" Width="100%">
                <asp:Panel ID="Panel1" runat="server" Width="100%">
                    <asp:Panel ID="Panel4" runat="server">

                        <div style="float: left;">
                            <table>
                                <tr>
                                    <td>Name</td>
                                    <td>Class Roll</td>

                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="txtNameSearch" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtRollSearch" runat="server"></asp:TextBox>
                                    </td>

                                </tr>
                                <tr>
                                    <td>&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnLoad" runat="server" Text="Load" OnClick="btnLoad_Click" Width="82px" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="float: left;">
                            <table>
                                <tr>
                                    <td>Created Date (from)</td>

                                </tr>
                                <tr>
                                    <td>

                                        <uc1:DateChooser ID="DateChooser1" runat="server" />

                                    </td>

                                </tr>
                            </table>
                        </div>
                        <asp:TextBox ID="txtGroupId" runat="server" Visible="False" Width="16px"></asp:TextBox>

                    </asp:Panel>
                </asp:Panel>

                <asp:Panel ID="pnlGrpAsg" runat="server">
                    <strong>Assign Student to Group
                    </strong>
                    <div style="text-align: center;">
                        Student Group<asp:DropDownList ID="cmbGroup" runat="server" Height="21px" Width="129px"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                            ControlToValidate="cmbGroup"
                            ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </div>
                    <div id="unassignedDiv" style="float: left; width: 38%">
                        Unassigned List
                    </div>
                    <div style="float: left; width: 23%; text-align: center; height: 100%; padding-top: 5px;">
                        <br />
                        <br />
                        <asp:Button ID="btnAsg" runat="server" Text="Assign to group →" Width="139px" OnClick="btnAsg_Click" />
                        <br />
                        <br />
                        <asp:Button ID="btnRemove" runat="server" Text="← Remove from Group" Width="150px" OnClick="btnRemove_Click" />
                        <br />
                        <br />
                        <br />
                        <asp:Button ID="btnSave" runat="server" Text="Save" Width="75px" OnClick="btnSave_Click" />
                    </div>
                    <div id="assignedDiv" style="float: left; width: 37%">
                        Assigned List&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cmbGroup" ErrorMessage="No Students to save." ForeColor="#FF3300"></asp:RequiredFieldValidator>
                        &nbsp;
                    </div>

                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" Width="100%"></asp:Panel>
            </asp:Panel>
            <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
        </ContentTemplate>
    </asp:UpdatePanel>

</div>
