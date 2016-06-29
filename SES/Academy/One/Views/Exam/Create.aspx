<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.Exam.Create" %>

<asp:Content runat="server" ID="content" ContentPlaceHolderID="Body">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <fieldset>
                <legend>Examination setting</legend>
                <div style="float: left;">
                    <asp:Panel ID="pnlExam" runat="server">
                        <table id="tbl" runat="server">
                            <tr>
                                <td>Name*</td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" ToolTip="Any indicative name. eg. year+Terminal"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ErrorMessage="Name is required." ControlToValidate="txtName"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>School*</td>
                                <td>
                                    <asp:DropDownList ID="cmbSchool" runat="server"
                                        Height="20px" Width="130px" AutoPostBack="True" OnSelectedIndexChanged="cmbSchool_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:Label ID="valiSchool" runat="server" Text="Label" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Co-ordinator*</td>
                                <td>
                                    <asp:DropDownList ID="cmbCoordinator" runat="server"
                                        Height="20px" Width="130px">
                                    </asp:DropDownList>
                                    <asp:Label ID="valiCoor" runat="server" Text="Label" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Exam Type*</td>
                                <td>
                                    <asp:DropDownList ID="cmbExamType" runat="server"
                                        Height="20px" Width="130px">
                                    </asp:DropDownList>
                                    <asp:Label ID="valiType" runat="server" Text="Label" Visible="False"></asp:Label>
                                </td>
                            </tr>
                            <tr style="text-align: start left;">
                                <td>Date of Exam*</td>
                                <td>

                                    <asp:TextBox ID="txtDate1" runat="server" ReadOnly="True"></asp:TextBox>
                                    <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click"
                                        Height="18px" ImageUrl="~/Content/Icons/calendar_image.png"
                                        CausesValidation="false" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                        ControlToValidate="txtDate1" ErrorMessage="Date is required."></asp:RequiredFieldValidator>
                                    <br />


                                </td>
                            </tr>
                            <tr>
                                <td>Weight %</td>
                                <td>
                                    <asp:TextBox ID="txtWeight" runat="server" TextMode="Number"></asp:TextBox></td>
                            </tr>
                        </table>
                        <div>
                            <asp:Button ID="btnSaveExam" runat="server" OnClick="btnSaveExam_Click" Text="Save Exam" />
                        </div>
                    </asp:Panel>
                    <fieldset>
                        <legend>Exam of:</legend>
                        <table>
                            <tr>
                                <td>Level</td>
                                <td>
                                    <asp:DropDownList ID="cmbLevel" runat="server" AutoPostBack="True" Height="20px" OnSelectedIndexChanged="cmbLevel_SelectedIndexChanged" Width="130px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Faculty</td>
                                <td>
                                    <asp:DropDownList ID="cmbFaculty" runat="server" AutoPostBack="True" Height="20px" OnSelectedIndexChanged="cmbFaculty_SelectedIndexChanged" Width="130px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Program</td>
                                <td>
                                    <asp:DropDownList ID="cmbProgram" runat="server" AutoPostBack="True" Height="20px" OnSelectedIndexChanged="cmbProgram_SelectedIndexChanged" Width="130px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="text-align: start left;">
                                <td>Year</td>
                                <td>
                                    <asp:DropDownList ID="cmbYear" runat="server" AutoPostBack="True" Height="20px" OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" Width="130px">
                                        <%--<asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>--%>
                                    </asp:DropDownList>
                                </td>
                            </tr>

                        </table>
                    </fieldset>



                    <br />
                    <br />

                    <asp:UpdatePanel runat="server" ID="updSub">
                        <ContentTemplate>
                            <asp:Panel ID="pnlChkLst" runat="server" Visible="False">
                                <fieldset>
                                    <legend>Choose Subjects</legend>
                                    <asp:CheckBox ID="chkSelectAll" runat="server" Text="Select All" Font-Italic="True" BackColor="#99CCFF" Width="220px" OnCheckedChanged="chkSelectAll_CheckedChanged" AutoPostBack="True" />
                                    <asp:Panel ID="Panel1" runat="server" BorderStyle="Ridge" BorderWidth="2px">
                                        <asp:CheckBoxList ID="chkList" runat="server"></asp:CheckBoxList>
                                    </asp:Panel>
                                </fieldset>
                            </asp:Panel>
                            <asp:Button ID="btnAddToList" runat="server" OnClick="btnAddToList_Click" Text="Add to List" />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Visible="False">
                                <Columns>
                                    <asp:BoundField HeaderText="Level" />
                                    <asp:BoundField HeaderText="Faculty" />
                                    <asp:BoundField HeaderText="Program" />
                                    <asp:BoundField HeaderText="Year" />
                                    <asp:BoundField HeaderText="Subject" />
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                    <asp:Table ID="tblExam" runat="server">
                    </asp:Table>
                    <asp:HiddenField ID="subjectCountHF" runat="server" Value="0" />
                </div>
                <div style="float: left;">
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
            <script type="text/javascript">
                var picker = new Pickaday({
                    field: document.getElementById('txtDate1'),
                    firstDay: 1,
                    minDate: new Date('1900-01-01'),
                    maxDate: new Date('2050-01-01'),
                    yearRange: [1900, 2050],
                    numberOfMonths: 1
                });
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

