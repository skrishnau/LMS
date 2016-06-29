<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SingleStudentAssignUC.ascx.cs" Inherits="One.Views.Student.StudentStructure.SingleStudentAssignUC" %>


<%@ Register Src="~/Views/UserControls/DateChooser.ascx" TagName="DateChooser" TagPrefix="uc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Panel ID="Panel3" runat="server" Width="100%">
            <asp:Panel ID="Panel1" runat="server" Width="100%">
                <asp:Panel ID="Panel4" runat="server">
                    <fieldset>
                        <legend>Filter</legend>
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
                                     <td>
                                         &nbsp;&nbsp;&nbsp;&nbsp;
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
                    </fieldset>
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
            <asp:ListBox ID="lstUnAsg" runat="server" Width="100%" Height="100%"></asp:ListBox>
                </div>
                <div style="float: left; width: 23%; text-align: center; height: 100%; padding-top: 5px;">
                   <br/><br/>
                     <asp:Button ID="btnAsg" runat="server" Text="Assign to group →" Width="90%" OnClick="btnAsg_Click" />
                    <br />
                    <br />
                    <asp:Button ID="btnRemove" runat="server" Text="← Remove from Group" Width="90%" OnClick="btnRemove_Click" />
                    <br />
                    <br />
                    <br />
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="75px" OnClick="btnSave_Click" />
                </div>
                <div id="assignedDiv" style="float: left; width: 38%">
                    Assigned List&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cmbGroup" ErrorMessage="No Students to save." ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    &nbsp;<asp:ListBox ID="lstAsg" runat="server" Width="100%" Height="100%"></asp:ListBox>
                </div>

            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" Width="100%"></asp:Panel>
        </asp:Panel>

    </ContentTemplate>
</asp:UpdatePanel>
