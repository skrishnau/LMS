<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AssignmentUc.ascx.cs" Inherits="One.Views.Course.ActivityAndResource.EntryUserConrols.AssignmentUc" %>




<style type="text/css">
    .auto-style1 {
        width: 250px;
    }
</style>

 <script>
     $(function () {
         //$("#dialog-1").dialog({
         //    autoOpen: false,
         //});
         //$("#opener").click(function () {
         //    $("#dialog-1").dialog("open");
         //});
         $("#txtFrom").datepicker();
         $("#txtCutOff").datepicker();
         $("#txtDue").datepicker();
     });
    </script>
<div>
    <strong>New Assignment</strong>
    <br />
    <asp:HiddenField ID="hidAssignmentId" runat="server" Value="0"/>
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0"/>
    <br />
    <div style="margin: 0 25px 0;">
        <strong>General</strong>
        <hr />
        <table style="margin: 0 20px 0;">
            <tr>
                <td class="auto-style1">Name</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="210px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtName" runat="server" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Description</td>
                <td>
                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="74px" Width="210px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Display Description</td>
                <td>
                    <asp:CheckBox ID="chkDisplayDesc" runat="server" />
                </td>
            </tr>

        </table>
        <br />
        <strong>Submission Date</strong>
        <hr />
        <table style="margin: 0 20px 0;">
            <tr>
                <td class="auto-style1">Submission From</td>
                <td>
                    <asp:TextBox ID="txtFrom" runat="server" Width="210px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Due Date</td>
                <td>
                    <asp:TextBox ID="txtDue" runat="server" Width="210px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Cut off Date</td>
                <td>
                    <asp:TextBox ID="txtCutOff" runat="server" Width="210px"></asp:TextBox>
                </td>
            </tr>

        </table>
        <br />
        <strong>Type</strong>
        <hr />
        <table style="margin: 0 20px 0;">
            <tr>
                <td class="auto-style1">Submission Type</td>
                <td>
                    <asp:DropDownList ID="ddlSubmissionType" runat="server" Height="21px" Width="210px"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="submissionListVali"
                        ControlToValidate="ddlSubmissionType"
                         runat="server" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Word Limit</td>
                <td>
                    <asp:TextBox ID="txtWordLimit" runat="server" Width="210px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Maximum Number of Submitted Files</td>
                <td>
                    <asp:TextBox ID="txtMaxFiles" runat="server" Width="210px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Maximum Submission Size</td>
                <td>
                    <asp:TextBox ID="txtMaxSize" runat="server" Width="210px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <strong>Grade</strong>
        <hr/>
        <table style="margin: 0 20px 0;">
            <tr>
                <td class="auto-style1">Grade Type</td>
                <td>
                    <asp:DropDownList ID="ddlGradeType" runat="server" Height="21px" Width="210px"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="gradeListVali"
                        ControlToValidate="ddlGradeType"
                         runat="server" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Maximum Grade</td>
                <td>
                    <asp:TextBox ID="txtMaxGradde" runat="server" Width="210px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Grade to Pass</td>
                <td>
                    <asp:TextBox ID="txtGradeToPass" runat="server" Width="210px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <div  style="text-align: left; padding:5px 20px 5px">
            <asp:Label ID="txtErrorMsg" runat="server" Text="Sorry, Couldn't Save !" ForeColor="#FF3300" Visible="False"></asp:Label>
            &nbsp;&nbsp;
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="100" OnClick="btnSave_Click"/>
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="100" OnClick="btnCancel_Click" CausesValidation="False"/>
        </div>
    </div>
    <div>
        <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
    </div>
</div>
