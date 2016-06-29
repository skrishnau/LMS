<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateExamUc.ascx.cs" Inherits="One.Views.Exam.Exam.Create.CreateExamUc" %>
<%@ Register Src="~/Views/Exam/Exam/Create/EachNodeOfAssign/TreeViewUC.ascx" TagPrefix="uc1" TagName="TreeViewUC" %>

<%--<%@ Register Src="~/Views/Exam/Exam/Create/Tree/TreeViewUC.ascx" TagPrefix="uc1" TagName="TreeViewUC" %>--%>

<div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <fieldset>
                <legend>Examination setting</legend>

                <div style="float: left;">
                    <asp:Panel ID="pnlExam" runat="server">
                        <table id="tbl" runat="server">
                            <tr>

                                <td>Academic Year*</td>
                                <td>
                                    <asp:DropDownList ID="cmbAcademicYear" runat="server"
                                        Height="20px" Width="130px" AutoPostBack="True" OnSelectedIndexChanged="cmbAcademicYear_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="valiAcademicYear" runat="server" ControlToValidate="cmbAcademicYear" ErrorMessage="Required" ForeColor="#FF3300" ValidationGroup="ExamValiGroup"></asp:RequiredFieldValidator>
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
                            <tr>
                                <td>Name*</td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" ToolTip="Any indicative name. eg. year+Terminal"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ErrorMessage="Required" ControlToValidate="txtName" ValidationGroup="ExamValiGroup" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td>Exam Type*</td>
                                <td>
                                    <asp:DropDownList ID="cmbExamType" runat="server"
                                        Height="20px" Width="130px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="valiType" runat="server" ControlToValidate="cmbExamType" ErrorMessage="Required" ForeColor="#FF3300" ValidationGroup="ExamValiGroup"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <%--   <tr>
                        <td>School*</td>
                        <td>
                            <asp:DropDownList ID="cmbSchool" runat="server"
                                Height="20px" Width="130px" AutoPostBack="True" OnSelectedIndexChanged="cmbSchool_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="valiSchool" runat="server" Text="Label" Visible="False"></asp:Label>
                        </td>
                    </tr>--%>
                            <tr>
                                <td>Notice</td>
                                <td>
                                    <asp:TextBox ID="txtNotice" runat="server" TextMode="MultiLine" Height="76px" Width="216px"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td>Co-ordinator*</td>
                                <td>
                                    <asp:DropDownList ID="cmbCoordinator" runat="server"
                                        Height="20px" Width="130px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="valiCoor" runat="server" ControlToValidate="cmbCoordinator" ErrorMessage="Required" ForeColor="#FF3300" ValidationGroup="ExamValiGroup"></asp:RequiredFieldValidator>
                                </td>
                            </tr>


                            <tr>
                                <td>Weight %</td>
                                <td>
                                    <asp:TextBox ID="txtWeight" runat="server" TextMode="Number"></asp:TextBox>
                                    <asp:CustomValidator ID="CompareValidator1" runat="server" ControlToValidate="txtWeight" ValidationGroup="ExamValiGroup" ErrorMessage="Must be between 0 and 100" OnServerValidate="CompareValidator1_ServerValidate" ForeColor="#FF3300"></asp:CustomValidator>
                                </td>
                            </tr>

                            <tr style="text-align: start left;">
                                <td>Start Date*</td>
                                <td>

                                    <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date" ReadOnly="True"></asp:TextBox>
                                    <asp:ImageButton ID="imgBtnStartDate" runat="server"
                                        Height="18px" ImageUrl="~/Content/Icons/calendar_image.png"
                                        CausesValidation="false" OnClick="imgBtnStartDate_Click" />
                                    <br />
                                </td>
                            </tr>

                            <tr style="text-align: start left;">
                                <td>Result Date</td>
                                <td>

                                    <asp:TextBox ID="txtResultDate" runat="server" TextMode="Date" ReadOnly="True"></asp:TextBox>
                                    <asp:ImageButton ID="imgBtnResultDate" runat="server"
                                        Height="18px" ImageUrl="~/Content/Icons/calendar_image.png"
                                        CausesValidation="false" OnClick="imgBtnResultDate_Click" />
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <div>
                            &nbsp;&nbsp;
                    <asp:Button ID="btnSaveExam" runat="server" OnClick="btnSaveExam_Click" ValidationGroup="ExamValiGroup" Text="Save Exam" />
                            <br />
                        </div>
                    </asp:Panel>

                    <%--<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />--%>

                    <asp:HiddenField ID="subjectCountHF" runat="server" Value="0" />
                </div>
                <div style="float: left;">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
                        <ContentTemplate>

                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC"
                                BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
                                Font-Size="8pt" ForeColor="#003399" Height="41px" Width="220px"
                                OnSelectionChanged="Calendar1_SelectionChanged" Visible="False">
                                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                                <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                                <WeekendDayStyle BackColor="#CCCCFF" />
                            </asp:Calendar>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

            </fieldset>

            <div>
                <asp:Panel ID="pnlExamDetails" runat="server">
                    <%--<uc1:TreeViewUC runat="server" id="TreeViewUC1" />--%>
                    <uc1:TreeViewUC runat="server" id="TreeViewUC1" />
                </asp:Panel>
            </div>

            <div>
                <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
                <asp:HiddenField ID="hidAcademicYear" runat="server" Value="0" />
                <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />
                <asp:HiddenField ID="hid100" runat="server" Value="100" />
                <asp:HiddenField ID="hidExamId" runat="server" Value="0" />
                <asp:HiddenField ID="hidExamTypeId" runat="server" Value="0" />
                <asp:HiddenField ID="hidCoordinatorId" runat="server" Value="0" />


            </div>
           <%-- <script type="text/javascript">
                var picker = new Pickaday({
                    field: document.getElementById('txtDate1'),
                    firstDay: 1,
                    minDate: new Date('1900-01-01'),
                    maxDate: new Date('2050-01-01'),
                    yearRange: [1900, 2050],
                    numberOfMonths: 1
                });
            </script>--%>

        </ContentTemplate>
    </asp:UpdatePanel>

</div>
