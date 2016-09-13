<%@ Page Language="C#"
    MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="CreateExam.aspx.cs" Inherits="One.Views.Exam.Exam.CreateExam" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Views/Academy/ProgramSelection/OnlyListing/ProgramSelection.ascx" TagPrefix="uc1" TagName="ProgramSelection" %>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">


    <link rel="stylesheet" href="../../../DatePickerJquery/jquery-ui-1.9.2.custom.css" />
    <script src="../../../DatePickerJquery/jquery-1.8.3.js"></script>

    <%--<script src="../../../ckeditor/ckeditor.js"></script>--%>

    <script>
        //$(function () {
        //    $("#txtStartDate").datepicker();
        //    $("#txtResultDate").datepicker();
        //});

        function focusFunction() {
            // Focus = Changes the background color of input to yellow

            document.getElementById("txtCoOrdinator").style.background = "yellow";
            document.getElementById("pnlCoordinator").visibility = "true";
            //__doPostBack('txtCoOrdinator', 'visible');
        }

        function blurFunction() {
            // No focus = Changes the background color of input to red
            document.getElementById("txtCoOrdinator").style.background = "red";
            document.getElementById("pnlCoordinator").visibility = "false";
            //__doPostBack('txtCoOrdinator', 'invisible');
        }

        //test purpose ; delete after viewing


    </script>
    <script type="text/javascript">
        function pageLoad() {
            $('#txtResultDate').unbind();
            $('#txtResultDate').datepicker();

            $('#txtStartDate').unbind();
            $('#txtStartDate').datepicker();
        }
    </script>

    <style type="text/css">
        .auto-style1 {
            width: 140px;
        }
    </style>



</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">


    <%-- ------------------------------------------- --%>
    <div style="text-align: center; font-size: 1.3em; font-weight: 700;">
        Exam Create
        <hr />
    </div>

    <div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div style="border-bottom: 2px solid lightgray; padding-bottom: 10px;">
                    <table>
                        <tr>
                            <td class="auto-style1">Exam Type*</td>
                            <td>
                                <asp:DropDownList ID="cmbExamType" runat="server"
                                    Height="20px" Width="130px" DataTextField="Name" DataValueField="Id"
                                    AutoPostBack="True" OnSelectedIndexChanged="cmbExamType_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="valiType" runat="server" ControlToValidate="cmbExamType" ErrorMessage="Required" ForeColor="#FF3300" ValidationGroup="ExamValiGroup"></asp:RequiredFieldValidator>
                                <asp:HyperLink ID="HyperLink1" runat="server"
                                    NavigateUrl="~/Views/Exam/ExamType/ExamTypeCreate.aspx"
                                    ImageUrl="~/Content/Icons/Add/Add-icon.png">
                                </asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <%-- test of nicEdit--%>
                <%-- <textarea></textarea>
                <script src="http://js.nicedit.com/nicEdit-latest.js" type="text/javascript"></script>
                <script type="text/javascript">bkLib.onDomLoaded(nicEditors.allTextAreas);</script>--%>
                <%-- end of test --%>
                <div style="background-color: lightgoldenrodyellow; margin: 0 20px 10px;">
                    <asp:Panel ID="pnlEntry" runat="server">
                        <div style="margin-left: 20px; padding-left: 20px; padding-top: 10px;">
                            <table id="tbl">
                                <tr>
                                    <td class="auto-style1">Name*</td>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" ToolTip="Any indicative name. eg. year+Terminal"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                            ErrorMessage="Required" ControlToValidate="txtName" ValidationGroup="ExamValiGroup" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>

                                <%--  <tr>
                    <td class="auto-style1">Co-ordinator*</td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="txtCoOrdinator" runat="server" ClientIDMode="Static"
                                    AutoPostBack="True" onblur="blurFunction()" onfocus="focusFunction()"
                                    OnTextChanged="txtUser_TextChanged"></asp:TextBox>
                                <asp:Panel ID="pnlCoordinator" runat="server" ClientIDMode="Static">
                                     
                                    <div style="position: absolute;  height: 100px; overflow: auto; background-color: lightblue;">
                                        <asp:DataList ID="dlistCorinator" runat="server">
                                            <ItemTemplate>
                                                <div runat="server" id="div1">
                                                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("Id") %>' />
                                                    <asp:LinkButton CssClass="block" CausesValidation="False" CommandName="Select" ID="Label1" runat="server" Text='<%# Eval("FirstName") %>'></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>

                                            <SelectedItemStyle BackColor="lightgrey"></SelectedItemStyle>

                                        </asp:DataList>
                                    </div>
                            </asp:Panel>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>--%>

                                <tr style="vertical-align: top;">
                                    <td class="auto-style1">Weight</td>

                                    <td>
                                        <asp:DropDownList ID="ddlWeight" runat="server" Height="23px" Width="100px"
                                            AutoPostBack="True">
                                            <Items>
                                                <asp:ListItem Value="0" Text="In Percent" Selected="True"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="In Marks"></asp:ListItem>
                                            </Items>
                                        </asp:DropDownList>
                                        &nbsp;
                            <asp:TextBox ID="txtWeight" runat="server"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="valiWeight" runat="server"
                                            ErrorMessage="Required " ControlToValidate="txtWeight"
                                            ForeColor="red"></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                            ValidationExpression="^[0-9]{1,11}(?:\.[0-9]{1,3})?$"
                                            ControlToValidate="txtWeight"
                                            ErrorMessage="RegularExpressionValidator"></asp:RegularExpressionValidator>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                                            ControlToValidate="txtWeight" ValidationExpression="/^\d*\.?\d*$/"
                                            runat="server" ErrorMessage="Not a decimal Number"></asp:RegularExpressionValidator>--%>

                                        <%--<asp:RequiredFieldValidator ID="rangeVali" ForeColor="red" runat="server" ErrorMessage="0 to 100 Only." ControlToValidate="txtWeight" MaximumValue="100" MinimumValue="0"></asp:RequiredFieldValidator>--%>
                                    </td>

                                    <%-- <td>
                                <asp:TextBox ID="txtWeight" runat="server" TextMode="Number"></asp:TextBox>
                                <asp:CustomValidator ID="CompareValidator1" runat="server"
                                    ControlToValidate="txtWeight" ValidationGroup="ExamValiGroup"
                                    ErrorMessage="Must be between 0 and 100"
                                    ForeColor="#FF3300"></asp:CustomValidator>
                            </td>--%>
                                </tr>


                            </table>

                        </div>
                        <%-- <br />--%>


                        <%--<asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />--%>

                        <asp:HiddenField ID="subjectCountHF" runat="server" Value="0" />
                    </asp:Panel>
                    <div style="margin-left: 20px; padding-left: 20px; padding-bottom: 10px;">
                        <table>
                            <tr style="text-align: start left;">
                                <td class="auto-style1">Start Date*</td>
                                <td>
                                    <asp:TextBox ID="txtStartDate" ClientIDMode="Static"
                                        runat="server" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                        ControlToValidate="txtStartDate" ForeColor="Red"
                                        runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr style="text-align: start left;">
                                <td class="auto-style1">Result Date</td>
                                <td>
                                    <asp:TextBox ID="txtResultDate" ClientIDMode="Static"
                                        runat="server" TextMode="Date"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <%-- end --%>
                <div>
                    <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
                    <asp:HiddenField ID="hidAcademicYearId" runat="server" Value="0" />
                    <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />

                    <asp:HiddenField ID="hidExamId" runat="server" Value="0" />
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
                <br />
                <div>
                    <strong>Program Selections</strong>
                    <hr />
                    <div style="background-color: #ddddff; margin-left: 20px; padding-left: 20px;">
                        <div style="margin: 0 40% 20px 0; background-color: #ddddff">
                            <uc1:ProgramSelection runat="server" ID="ProgramSelection1" />
                        </div>
                    </div>
                </div>

                <br />
                <div>
                    <strong>Notice</strong>

                    <hr />
                    <div>
                        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>--%>
                        <div style="margin-left: 20px;">
                            <asp:CheckBox ID="chkPublish"  AutoPostBack="True" runat="server" Text="Publish notice to Notice Board " OnCheckedChanged="chkPublish_CheckedChanged" />
                            <div style="margin-left: 23px;">
                                <asp:Panel ID="pnlNoticeTitle" runat="server" Visible="False">
                                   <strong>Title of Notice : &nbsp;&nbsp;</strong> 
                                <asp:TextBox ID="txtTitleOfNotice" runat="server"></asp:TextBox>
                                </asp:Panel>
                            </div>
                        </div>
                        <%-- </ContentTemplate>
                        </asp:UpdatePanel>--%>
                        <div style="margin: 20px;">
                            <CKEditor:CKEditorControl ID="CKEditor1" runat="server">
                            </CKEditor:CKEditorControl>
                        </div>

                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <hr />
    </div>
    <div style="margin-top: 15px;">
        <span style="display: inline-block;" class="auto-style1"></span>
        <asp:Button ID="btnReset" runat="server" ValidationGroup="ExamValiGroup" Text="Reset All" Width="69px" />
        &nbsp;&nbsp;       
        <asp:Button ID="btnSaveExam" runat="server" ValidationGroup="ExamValiGroup" Text="Save Exam" Width="103px" OnClick="btnSaveExam_Click" />
        <br />
    </div>
    <%-- -------------------------------------------- --%>
</asp:Content>

<%-- 
      <tr style="vertical-align: top;">
            <td>
                 <textarea id="editor1" name="editor1">this should be replaced</textarea>

                 <asp:TextBox ID="txtNotice" runat="server"
                    TextMode="MultiLine" ClientIDMode="Static"
                    Height="76px" Width="216px"></asp:TextBox>
                <script type="text/javascript">
                //CKEDITOR.replace('editor1');
                CKEDITOR.replace('txtNotice', {
                    filebrowserBrowseUrl: '/filetasks/Browse.aspx',
                    filebrowserUploadUrl: '/filetasks/Upload.aspx'
                });

            </script>
        </td>
    </tr>
--%>


