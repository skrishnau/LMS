<%@ Page Language="C#"
    MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true"
    CodeBehind="CreateExam.aspx.cs" Inherits="One.Views.Exam.Exam.CreateExam" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Views/Academy/ProgramSelection/OnlyListing/ProgramSelection.ascx" TagPrefix="uc1" TagName="ProgramSelection" %>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">


    <script type="text/javascript" src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.min.js"></script>
    <script src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.css" rel="stylesheet" type="text/css" />

    <%--<link rel="stylesheet" href="../../../DatePickerJquery/jquery-ui-1.9.2.custom.css" />--%>
    <%--<script src="../../../DatePickerJquery/jquery-1.8.3.js"></script>--%>

    <script src="../../../ckeditor/ckeditor.js"></script>

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
    <h3 class="heading-of-create-edit">Exam Create
    </h3>
    <hr />
    <br />
    <div class="data-entry-body">


        <div style="padding-bottom: 10px;">
            <div class="data-entry-section-heading">
                General
                        <hr />
            </div>

            <div class="data-entry-section-body">

                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>

                        <table>
                            <tr>
                                <td class="data-type">Exam Type*</td>
                                <td class="data-value">
                                    <asp:DropDownList ID="cmbExamType" runat="server"
                                        Height="20px" Width="130px" DataTextField="Name" DataValueField="Id"
                                        AutoPostBack="True" OnSelectedIndexChanged="cmbExamType_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    &nbsp;
                                     <asp:HyperLink ID="HyperLink1" runat="server"
                                         NavigateUrl="~/Views/Exam/ExamType/ExamTypeCreate.aspx"
                                         ImageUrl="~/Content/Icons/Add/Add-icon.png">
                                     </asp:HyperLink>
                                    <asp:RequiredFieldValidator ID="valiType" runat="server"
                                        ControlToValidate="cmbExamType" ErrorMessage="Required"
                                        ForeColor="#FF3300" ValidationGroup="ExamValiGroup">
                                    </asp:RequiredFieldValidator>

                                </td>
                            </tr>
                        </table>

                        <asp:Panel ID="pnlEntry" runat="server">
                            <table id="tbl">
                                <tr>
                                    <td class="data-type">Name*</td>
                                    <td class="data-value">
                                        <asp:TextBox ID="txtName" runat="server" ToolTip="Any indicative name. eg. year+Terminal"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                            ErrorMessage="Required" ControlToValidate="txtName" ValidationGroup="ExamValiGroup" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>

                                <tr style="vertical-align: top;">
                                    <td class="data-type">Weight</td>

                                    <td class="data-value">
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
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField ID="subjectCountHF" runat="server" Value="0" />
                        </asp:Panel>

                        <table>
                            <tr>
                                <td class="data-type">Start Date*</td>
                                <td class="data-value">
                                    <asp:TextBox ID="txtStartDate" ClientIDMode="Static"
                                        runat="server" TextMode="Date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                                        ControlToValidate="txtStartDate" ForeColor="Red"
                                        runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <tr>
                                <td class="data-type">Result Date</td>
                                <td class="data-value">
                                    <asp:TextBox ID="txtResultDate" ClientIDMode="Static"
                                        runat="server" TextMode="Date"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <br />
        <%-- background-color: lightgoldenrodyellow;  --%>
        <%-- <div style="margin: 0 20px 10px;">
                   
                    <div style="margin-left: 20px; padding-left: 20px; padding-bottom: 10px;">
                       
                    </div>
                </div>--%>
        <%-- end --%>
        <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
        <asp:HiddenField ID="hidAcademicYearId" runat="server" Value="0" />
        <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />

        <asp:HiddenField ID="hidExamId" runat="server" Value="0" />

        <br />
        <div>
            <div class="data-entry-section-heading">
                Program Selection
                        <hr />
            </div>
            <%-- background-color: #ddddff;  --%>
            <div class="data-entry-section-body">
                <%-- style="margin: 0 40% 20px 0;" --%>
                <uc1:ProgramSelection runat="server" ID="ProgramSelection1" />
            </div>
        </div>

        <br />
        <div>
            <div class="data-entry-section-heading">
                Notice
                        <hr />
            </div>
            <div class="data-entry-section-body">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div style="margin-left: 20px;">
                            <asp:CheckBox ID="chkPublish" AutoPostBack="True" runat="server" Text="Publish notice to Notice Board " OnCheckedChanged="chkPublish_CheckedChanged" />
                            <div style="margin-left: 23px;">
                                <asp:Panel ID="pnlNoticeTitle" runat="server" Visible="False">
                                    <strong>Title of Notice : &nbsp;&nbsp;</strong>
                                    <asp:TextBox ID="txtTitleOfNotice" runat="server"></asp:TextBox>
                                </asp:Panel>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div style="margin: 20px;">
                    <CKEditor:CKEditorControl ID="CKEditor1" runat="server">
                    </CKEditor:CKEditorControl>
                </div>

            </div>
        </div>
        <div class="save-div">
            <asp:Button ID="btnReset" runat="server" ValidationGroup="ExamValiGroup" Text="Reset All" Width="69px" />
            &nbsp;&nbsp;       
                    <asp:Button ID="btnSaveExam" runat="server" ValidationGroup="ExamValiGroup" Text="Save Exam" Width="103px" OnClick="btnSaveExam_Click" />
            &nbsp;&nbsp;
                    <asp:Label ID="lblError" runat="server" Text="Error while saving."
                        Visible="False" ForeColor="red"></asp:Label>
            <br />
        </div>

        <hr />
    </div>

    <%-- -------------------------------------------- --%>
</asp:Content>


<asp:Content runat="server" ID="cnt1" ContentPlaceHolderID="title">
    New Exam 
</asp:Content>
