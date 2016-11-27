<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseSessionCreateUC.ascx.cs" Inherits="One.Views.Class.CourseSessionCreateUC" %>
<%@ Register Src="~/Views/Class/Enrollment/UserEnrollUC.ascx" TagPrefix="uc1" TagName="UserEnrollUC" %>
<%@ Register Src="~/Views/Class/Enrollment/UserEnrollUC_ListDisplay.ascx" TagPrefix="uc1" TagName="UserEnrollUC_ListDisplay" %>



<style type="text/css">
    .auto-style1 {
        width: 181px;
    }



    .auto-style2 {
        width: 168px;
    }
</style>

<script>
    $(function () {
        $("#txtStart").datepicker();
        $("#txtEnd").datepicker();
    });
</script>

<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div style="text-align: center; font-weight: 700; font-size: 1.3em;">
                New Course Session
        <hr />
            </div>

            <div style="margin: 10px;">
                <div>
                    <table style="vertical-align: top; border-collapse: collapse;">
                        <tr style="vertical-align: top;">
                            <td class="auto-style2">Class creation in course: &nbsp;                    
                            </td>
                            <td style="font-weight: 700;">
                                <asp:Label ID="lblCourseName" runat="server"></asp:Label>
                            </td>
                        </tr>

                    </table>
                </div>
                <br />
                <div style="margin-left: 20px;">
                    <table>
                        <tr>
                            <td class="auto-style1 form-element-row-height">Class Name* </td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="valiName" runat="server"
                                    ControlToValidate="txtName" ForeColor="red"
                                    ErrorMessage="Required"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1 form-element-row-height">Grouping of Students </td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <Items>
                                        <asp:ListItem Text="Use Global Grouping Settings"></asp:ListItem>
                                        <asp:ListItem Text="Use Grouping From Course"></asp:ListItem>
                                        <asp:ListItem Text="Custom Grouping For Only This Class"></asp:ListItem>
                                        <asp:ListItem Text="Don't Use any Grouping"></asp:ListItem>
                                    </Items>
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td class="auto-style1 form-element-row-height" style="display: inline-block;">Enrollment Method</td>
                            <td>
                                <asp:DropDownList ID="DropDownList2" runat="server" Height="22px">
                                    <Items>
                                        <asp:ListItem Value="0" Text="Manual Only"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="Self Enrollment"></asp:ListItem>
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
                            <td class="auto-style1 form-element-row-height">Start Date</td>
                            <td>
                                <asp:TextBox ID="txtStart" ClientIDMode="Static" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1 form-element-row-height">End Date</td>
                            <td>
                                <asp:TextBox ID="txtEnd" ClientIDMode="Static" runat="server" TextMode="Date"></asp:TextBox>
                            </td>
                        </tr>


                    </table>
                    <br />
                    <div style="text-align: left;">
                        <span class="auto-style1" style="display: inline-block;"></span>
                        <asp:Button ID="btnSaveAndReturn" runat="server" Width="80px" Text="Save" OnClick="btnSave_Click" />
                        &nbsp;
                <span style="background-color: red; color: white;">
                    <asp:Literal ID="lblErrorMsg" Visible="False" runat="server" Text=" Something went wrong. "></asp:Literal>

                </span>
                        <%--<asp:Button ID="btnSaveAndEnrollUsers" runat="server" Text="Save" OnClick="btnSave_Click" />--%>
                    </div>
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
