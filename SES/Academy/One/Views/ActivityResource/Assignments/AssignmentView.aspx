<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="AssignmentView.aspx.cs" Inherits="One.Views.ActivityResource.Assignments.AssignmentView" %>

<%--<%@ Register Src="~/Views/ActivityResource/Assignments/TeacherViewUc.ascx" TagPrefix="uc1" TagName="TeacherViewUc" %>
<%@ Register Src="~/Views/ActivityResource/Grading/GradeUc.ascx" TagPrefix="uc1" TagName="GradeUc" %>--%>


<asp:Content runat="server" ID="bodyid" ContentPlaceHolderID="Body">
    <div>
        <h3 class="heading-of-display">
            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
        </h3>
    </div>
    <div class="data-entry-section-body">
        <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
    </div>
    <br />
    <br />
    <div class="data-entry-section-body">
        <div class="data-entry-section-heading">
            Submission
            <hr />
        </div>
        <div class="data-entry-section-body">

            <table>
               

                <tr>
                    <td class="data-type">Due Date</td>
                    <td class="data-value">
                        <asp:Label ID="lblDueDate" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>

                <tr>
                    <td class="data-type">Time Remaining </td>
                    <td class="data-value">
                        <asp:Label ID="lblTimeRemaining" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                
            </table>




        </div>

        <br />
        <div class="data-entry-section-heading" >
            Grades
         <hr />
        </div>

        <asp:Panel ID="pnlGradeList" runat="server"></asp:Panel>

        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <br />

                <%--<asp:Button ID="btnSubmit" runat="server" Text="Submit" Visible="False" OnClick="btnSubmit_OnClick" />--%>
            </asp:View>

            <asp:View ID="View2" runat="server">
                <%--<uc1:TeacherViewUc runat="server" ID="TeacherViewUc" />--%>

                <%--<uc1:GradeUc runat="server" ID="GradeUc1" />--%>
                <%--<asp:Button ID="btnGrade" runat="server" Text=" Grade " OnClick="btnGrade_OnClick" />--%>
            </asp:View>

        </asp:MultiView>

    </div>

    <asp:HiddenField ID="hidAssignmentId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidUserClassId" runat="server" Value="0" />
</asp:Content>
