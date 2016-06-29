<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListUc.ascx.cs" Inherits="One.Views.Exam.Exam.ExamList.ListUc" %>

<div>
    <div>
        <%-- Academic year and session selection --%>
        <table id="tbl" runat="server">
            <tr>
                <td>Academic Year*</td>
                <td>
                    <asp:DropDownList ID="cmbAcademicYear" runat="server"
                        Height="20px" Width="130px" AutoPostBack="True" OnSelectedIndexChanged="cmbAcademicYear_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>Session</td>
                <td>
                    <asp:DropDownList ID="cmbSession" runat="server"
                        Height="20px" Width="130px" AutoPostBack="True" OnSelectedIndexChanged="cmbSession_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>
    <asp:PlaceHolder ID="pnlExamList" runat="server"></asp:PlaceHolder>
    <div>
        <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
        <asp:HiddenField ID="hidAcademicYear" runat="server" Value="0" />
        <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />
    </div>
</div>
