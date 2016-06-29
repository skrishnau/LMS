<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentAssignToAStructure.ascx.cs" Inherits="One.Views.Student.StudentStructure.StudentAssignToAStructure" %>
<%@ Register Src="~/Views/Student/StudentStructure/SingleStudentAssignUC.ascx" TagPrefix="uc1" TagName="SingleStudentAssignUC" %>


<div>
    <fieldset>
        <legend>Student Group Assign to a Structure</legend>

        <table>
            <tr>
                <td>Level
                    <asp:DropDownList ID="cmbLevel" runat="server"></asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>Faculty
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>Program
                    <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlYear" runat="server">
                        Year&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                     <asp:DropDownList ID="cmbYear" runat="server"></asp:DropDownList>
                    </asp:Panel>
                </td>
                <td>
                    <asp:Panel ID="pnlAcademicYear" runat="server">
                        Current Academic Year&nbsp;&nbsp;
                    <asp:DropDownList ID="cmbAcademicYear" runat="server"></asp:DropDownList>
                    </asp:Panel>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Panel ID="pnlSubYear" runat="server">
                        Sub-Year &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="cmbSubYear" runat="server"></asp:DropDownList>
                    </asp:Panel>
                </td>

                <td>
                    <asp:Panel ID="pnlSession" runat="server">
                        Session&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="cmbSession" runat="server" Height="20px" Width="150px"></asp:DropDownList>
                    </asp:Panel>
                </td>
            </tr>
            <tr>

                <td>
                    <asp:Panel ID="pnlPhase" runat="server">
                        Phase &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="cmbPhase" runat="server"></asp:DropDownList>
                    </asp:Panel>
                </td>
                <td>
                    <asp:Panel ID="pnlSubSession" runat="server">
                        Sub-Session&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                    <asp:DropDownList ID="cmbSubSession" runat="server" Height="21px" Width="150px"></asp:DropDownList>
                    </asp:Panel>
                </td>
            </tr>
        </table>








        <br />
        <%-- ===================================== --%>







        <asp:Panel ID="Panel1" runat="server" BackColor="#CCCCFF">
            <asp:RadioButton ID="RadioButton1" runat="server" Text="Single Student " />
            &nbsp;&nbsp;
            <asp:RadioButton ID="RadioButton2" runat="server" Text="Student Group" />
            <br />
            <asp:Panel ID="Panel2" runat="server">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server" >
                        <uc1:SingleStudentAssignUC runat="server" id="SingleStudentAssignUC" />
                    </asp:View>

                    <asp:View ID="View2" runat="server">
                        
                    </asp:View>
                </asp:MultiView>
            </asp:Panel>
        </asp:Panel>







        <asp:Panel ID="pnlOthers" runat="server">
            Remarks &nbsp;&nbsp;
            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Height="67px" Width="219px"></asp:TextBox>
        </asp:Panel>

        <%-- ==================================== --%>
        <table>

            <tr>
                <td>Current Academic Year&nbsp;</td>
                <td></td>
            </tr>

            <tr>
                <td></td>
            </tr>
        </table>


    </fieldset>
</div>
