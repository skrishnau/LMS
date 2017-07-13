<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseSessionCreateUC.ascx.cs" Inherits="One.Views.Class.CourseSessionCreateUC" %>
<%@ Register Src="~/Views/Class/Enrollment/UserEnrollUC.ascx" TagPrefix="uc1" TagName="UserEnrollUC" %>
<%@ Register Src="~/Views/Class/Enrollment/UserEnrollUC_ListDisplay.ascx" TagPrefix="uc1" TagName="UserEnrollUC_ListDisplay" %>



<style type="text/css">
    /*.auto-style1 {
        width: 181px;
    }



    .auto-style2 {
        width: 168px;
    }*/
</style>

<script>
    $(function () {
        $("#txtStart").datepicker();
        $("#txtEnd").datepicker();
        $("#txtLastEnrollDate").datepicker();
    });
</script>

<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <h3 class="heading-of-create-edit">Class edit
            </h3>
            <br />
            <div class="data-entry-section-body">
                <table>
                    <tr>
                        <td class="data-type">Course                    
                        </td>
                        <td class="data-value">
                            <asp:Label ID="lblCourseName" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <%-- auto-style1 form-element-row-height --%>
                        <td class="data-type">Class Name* </td>
                        <td class="data-value">
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valiName" runat="server"
                                ControlToValidate="txtName" ForeColor="red"
                                ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="data-type">Grouping of Students </td>
                        <td class="data-value">
                            <asp:DropDownList ID="ddlGroupingOfStudents" runat="server" Enabled="False">
                                <Items>
                                    <asp:ListItem Value="0" Text="Don't Use any Grouping"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="Custom Grouping For Only This Class"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Use Grouping From Course"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="Use Global Grouping Settings"></asp:ListItem>
                                </Items>
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td class="data-type" style="display: inline-block;">Enrollment Method</td>
                        <td class="data-value">
                            <asp:DropDownList ID="ddlEnrollmentMethod" runat="server" Height="22px" Width="155">
                                <Items>
                                    <%--<asp:ListItem Value="0" Text="Automatic"></asp:ListItem>--%>
                                    <asp:ListItem Value="1" Text="Manual Only"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Self Enrollment" Selected="True"></asp:ListItem>
                                    <%--<asp:ListItem Value="0" Text="Create "></asp:ListItem>--%>
                                </Items>
                            </asp:DropDownList>
                            <br />
                            <%-- the selection will be multiple and dynamic
                   , when one is selected then give to select another 
                   , the list contains  item "New Enrolment Method for this Class"--%>
                        </td>
                    </tr>

                    <tr>
                        <td class="data-type">Start Date *</td>
                        <td class="data-value">
                            <asp:TextBox ID="txtStart" ClientIDMode="Static" runat="server" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valiStartDate" runat="server"
                                ControlToValidate="txtStart"
                                ErrorMessage="Error" ForeColor="red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="data-type">End Date *</td>
                        <td class="data-value">
                            <asp:TextBox ID="txtEnd" ClientIDMode="Static" runat="server" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valiEndDate" runat="server"
                                ControlToValidate="txtEnd"
                                ErrorMessage="Error" ForeColor="red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                     <tr>
                        <td class="data-type">Last Enroll Date *</td>
                        <td class="data-value">
                            <asp:TextBox ID="txtLastEnrollDate" ClientIDMode="Static" runat="server" TextMode="Date"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="valiLastEnrollDate" runat="server"
                                ControlToValidate="txtLastEnrollDate"
                                ErrorMessage="Error" ForeColor="red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <br />
                <div class="save-div">
                    <asp:Button ID="btnSaveAndReturn" runat="server" Width="80px" Text="Save" OnClick="btnSave_Click" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Width="80px" Text="Cancel" OnClick="btnCancel_OnClick" />

                    <asp:Label ID="lblErrorMsg" Visible="False" runat="server" 
                        ForeColor="red"
                        Text=" Error while saving "></asp:Label>
                    <%--<asp:Button ID="btnSaveAndEnrollUsers" runat="server" Text="Save" OnClick="btnSave_Click" />--%>
                </div>
            </div>

            <br />
            <div>
                <%-- List of Groups as per the selected item form dropdown list --%>
            </div>



            <%--    <div>
        User LIst to enroll
        <div>
            //Enroll
            <uc1:UserEnrollUC_ListDisplay runat="server" ID="UserEnrollUC_ListDisplay" />
        </div>
    </div>--%>
            <%--<uc1:UserEnrollUC runat="server" ID="UserEnrollUC" />--%>

            <asp:HiddenField ID="hidCourseId" Value="0" runat="server" />
            <asp:HiddenField ID="hidSubjectSessionId" Value="0" runat="server" />

        </ContentTemplate>
    </asp:UpdatePanel>
</div>
