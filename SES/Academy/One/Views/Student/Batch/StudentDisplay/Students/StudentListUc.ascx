<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentListUc.ascx.cs" Inherits="One.Views.Student.Batch.StudentDisplay.Students.StudentListUc" %>

<div>



    <asp:DataList ID="DataList1" runat="server" DataSourceID="StudentsOfProgramBatch_DataSource">
        <ItemTemplate>
            <%-- Id:
            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />

            <br />--%>
            <div class="item" style="margin: 0 25px 0;">
                <div style="float: left;">
                    <asp:ImageButton ID="ImageButton1" runat="server" Height="36px" Width="36px" AlternateText="Lost" />
                </div>
                <div style="float: left; clear: right; margin-left: 20px;">
                    <asp:HiddenField ID="IdLabel" runat="server" Value='<%# Eval("Id") %>' />
                    <strong>
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                        <br />
                    </strong>
                    CRN:
            <asp:Label ID="CRNLabel" runat="server" Text='<%# Eval("CRN") %>' />
                    <br />
                </div>
                <div style="clear: both;"></div>

                <div style="float: left; margin-left: 20px;">
                    Email:
            <%--<asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "User.Email") %>' />--%>

                    <asp:Label ID="UserLabel" runat="server" Text='<%# GetEmail(Eval("User")) %>' />
                    <br />
                    Phone:
            <asp:Label ID="Label1" runat="server" Text='<%# GetPhone(Eval("User"))  %>' />
                    <br />
                </div>
                <asp:HiddenField ID="UserIdLabel" runat="server" Value='<%# Eval("Id") %>' />
                <asp:HiddenField ID="BatchAssignedLabel" runat="server" Value='<%# Eval("BatchAssigned") %>' />
                <%-- ExamRollNoGlobal:
            <asp:Label ID="ExamRollNoGlobalLabel" runat="server" Text='<%# Eval("ExamRollNoGlobal") %>' />
            <br />--%>
                <%-- UserId:
            <asp:Label ID="UserIdLabel" runat="server" Text='<%# Eval("UserId") %>' />
            <br />--%>

                <%--  GuardianName:
            <asp:Label ID="GuardianNameLabel" runat="server" Text='<%# Eval("GuardianName") %>' />
            <br />
            GuardianEmail:
            <asp:Label ID="GuardianEmailLabel" runat="server" Text='<%# Eval("GuardianEmail") %>' />
            <br />
            GuardianContactNo:
            <asp:Label ID="GuardianContactNoLabel" runat="server" Text='<%# Eval("GuardianContactNo") %>' />
            <br />--%>

                <%-- StudentGroupStudents:
            <asp:Label ID="StudentGroupStudentsLabel" runat="server" Text='<%# Eval("StudentGroupStudents") %>' />
            <br />
            Void:
            <asp:Label ID="VoidLabel" runat="server" Text='<%# Eval("Void") %>' />
            <br />
            AssignedDate:
            <asp:Label ID="AssignedDateLabel" runat="server" Text='<%# Eval("AssignedDate") %>' />
            <br />--%>

                <%--BatchAssigned:
            <asp:Label ID="BatchAssignedLabel" runat="server" Text='<%# Eval("BatchAssigned") %>' />
            <br />--%>
                <%--<br />--%>
            </div>
        </ItemTemplate>

    </asp:DataList>
    <asp:ObjectDataSource ID="StudentsOfProgramBatch_DataSource" runat="server" SelectMethod="GetStudentsOfProgramBatch" TypeName="Academic.DbHelper.DbHelper+Batch">
        <SelectParameters>
            <asp:ControlParameter ControlID="hidProgramBatchId" DefaultValue="0" Name="programBatchId" PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="hidProgramBatchId" runat="server" Value="0" />
</div>

