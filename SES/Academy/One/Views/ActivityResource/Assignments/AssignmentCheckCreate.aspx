<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="AssignmentCheckCreate.aspx.cs" Inherits="One.Views.ActivityResource.Assignments.AssignmentCheckCreate" %>


<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Views/ActivityResource/FileResource/FileResourceItems/FilesDisplay.ascx" TagPrefix="uc1" TagName="FilesDisplay" %>



<asp:Content runat="server" ID="bodyid" ContentPlaceHolderID="Body">
    <div>
        <h3 class="heading-of-listing">Submissions
        </h3>
        <hr />
        <br />
        <h3 class="heading-of-display">
            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
        </h3>
        <div class="data-entry-section-body">
            <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <br />


        <div class="data-entry-section">
            <h3 class="heading-of-display">
                <%--&nbsp; 
                > 
                &nbsp; --%>
                <asp:Literal ID="lblStudentName" runat="server"></asp:Literal>
            </h3>
            <h3 class="heading-of-display"></h3>
            <div class="data-entry-section-body" style="text-align: left">
                <table>
                    <tr>
                        <td>Email : </td>
                        <td>
                            <%-- Font-Size="0.7em" Font-Bold="False" --%>
                            <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Roll : </td>
                        <td>
                            <asp:Label ID="lblRoll" runat="server" Text="N/A"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Class : </td>
                        <td>
                            <asp:Label ID="lblClassName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="data-entry-section-body">
                <div class="data-entry-section-heading">
                    Submissions
            <hr />
                </div>
                <div class="data-entry-section-body">
                    <asp:Panel ID="pnlFileSubmit" runat="server" Visible="False">
                        <div class="data-entry-section-heading">
                            Files &nbsp;
                        <asp:Label ID="lblFileLimit" runat="server" Text="" Font-Italic="True" Font-Size="0.8em"></asp:Label>
                        </div>
                        <br />
                        <div class="data-entry-section-body">
                                <uc1:FilesDisplay runat="server" ID="FilesDisplay1" />                                                            
                            <asp:Panel ID="pnlFilesDisplay" runat="server">
                            </asp:Panel>
                        </div>
                        <%--       <uc1:FilesDisplay runat="server" ID="FilesDisplay1" />
                <ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server" />--%>
                    </asp:Panel>
                    <br />
                    <br />
                    <asp:Panel ID="pnlText" runat="server" Visible="False">
                        <div class="data-entry-section-heading">
                            Text Submission &nbsp;
                        <asp:Label ID="lblWordLimit" runat="server" Text="" Font-Italic="True" Font-Size="0.8em"></asp:Label>
                        </div>
                        <br />
                        <div class="data-entry-section-body">
                            <CKEditor:CKEditorControl ID="txtSubmittedText" ClientIDMode="Static" runat="server" ToolbarStartupExpanded="False"
                                Enabled="False"></CKEditor:CKEditorControl>
                        </div>
                        <br />
                    </asp:Panel>
                </div>



                <br />

                <div class="data-entry-section-heading">
                    Grading
            <hr />
                </div>
                <div class="data-entry-section-body">
                    <div class="data-entry-section-heading">
                        Grade
                    </div>
                    <div>
                        <table>
                            <tr>
                                <td class="data-type">Maximum Grade</td>
                                <td class="data-value">
                                    <asp:Label ID="lblMaximumGrade" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="data-type">Minimum Grade to Pass</td>
                                <td class="data-value">
                                    <asp:Label ID="lblMinimumGradeToPass" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td></td>

                            </tr>
                            <tr>
                                <td class="data-type">Your Grade</td>
                                <td class="data-value">
                                    <asp:TextBox ID="txtGrade" runat="server" Visible="False"></asp:TextBox>
                                    <asp:DropDownList ID="ddlGrade" runat="server" Visible="False" DataTextField="Value" DataValueField="Id"></asp:DropDownList>
                                    <asp:Label ID="lblGradeError" runat="server" Text="Value must be less than maximum" Visible="False" ForeColor="red"></asp:Label>

                                </td>
                            </tr>
                        </table>
                        <br />
                    </div>
                    <br />
                    <div class="data-entry-section-heading">
                        Remarks
                    </div>
                    <br />

                    <CKEditor:CKEditorControl ID="txtRemarks" ClientIDMode="Static" runat="server"></CKEditor:CKEditorControl>

                </div>

                <br />

                <div class="data-entry-section-body">
                    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_OnClick" />
                    <asp:Label ID="lblError" runat="server"
                        Visible="False" ForeColor="red"
                        Text="Couldn't save"></asp:Label>
                </div>
                <br />
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hidActivityGradingId" runat="server" Value="0" />
    <asp:HiddenField ID="hidActivityId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidUserClassId" runat="server" Value="0" />
    <asp:HiddenField ID="hidActivityResourceId" runat="server" Value="0" />
</asp:Content>


<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="title">
    Submissions
</asp:Content>

