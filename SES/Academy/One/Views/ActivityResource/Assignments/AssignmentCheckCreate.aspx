<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="AssignmentCheckCreate.aspx.cs" Inherits="One.Views.ActivityResource.Assignments.AssignmentCheckCreate" %>


<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Views/ActivityResource/FileResource/FileResourceItems/FilesDisplay.ascx" TagPrefix="uc1" TagName="FilesDisplay" %>



<asp:Content runat="server" ID="bodyid" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">
        <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
    </h3>
    <hr />
    <div class="list-item-description">
        <asp:Label ID="lblDescription" runat="server" Text="" Visible="False"></asp:Label>
    </div>

    <table>
        <tr>
            <td class="data-type">Student name</td>
            <td class="data-value">
                <strong>
                    <asp:Literal ID="lblStudentName" runat="server"></asp:Literal>
                </strong>
            </td>
        </tr>
        <tr>
            <td class="data-type">Email </td>
            <td class="data-value">
                <%-- Font-Size="0.7em" Font-Bold="False" --%>
                <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="data-type">Roll </td>
            <td class="data-value">
                <asp:Label ID="lblRoll" runat="server" Text="N/A"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="data-type">Class </td>
            <td class="data-value">
                <asp:Label ID="lblClassName" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>

    <div class="panel-body" style="text-align: left">
    </div>

    <div class="panel panel-default">
        <div class="panel-heading">
            Submissions
        </div>
        <asp:Panel ID="pnlFileSubmit" runat="server" Visible="False" CssClass="panel panel-default">
            <div class="well-sm">
                <asp:Label ID="lblFileLimit" runat="server" Text=""></asp:Label>
            </div>
            <div style="margin-top: 10px;">
                <uc1:FilesDisplay runat="server" ID="FilesDisplay1" />
            </div>
            <%--  <asp:Panel ID="pnlFilesDisplay" runat="server">
                    </asp:Panel>--%>
            <%--       <uc1:FilesDisplay runat="server" ID="FilesDisplay1" />
                <ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server" />--%>
        </asp:Panel>

        <asp:Panel ID="pnlText" runat="server" Visible="False" CssClass="panel panel-default">
            <div class="well-sm">
                <%--Text Submission &nbsp;--%>
                <asp:Label ID="lblWordLimit" runat="server" Text="" Font-Italic="True" Font-Size="0.8em"></asp:Label>
            </div>
            <CKEditor:CKEditorControl ID="txtSubmittedText" ClientIDMode="Static" runat="server" ToolbarStartupExpanded="False"
                Enabled="False"></CKEditor:CKEditorControl>
        </asp:Panel>
    </div>








    <div class="panel panel-default">

        <div class="panel-heading">
            Grading
                   
        </div>
        <div class="panel-body">
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
                        <asp:DropDownList ID="ddlGrade" runat="server"
                            Width="120"
                            Visible="False" DataTextField="Value" DataValueField="Id">
                        </asp:DropDownList>
                        <asp:Label ID="lblGradeError" runat="server" Text="Value must be less than maximum" Visible="False" ForeColor="red"></asp:Label>

                    </td>
                </tr>
            </table>
        </div>

    </div>


    <div class="panel panel-default">
        <div class="panel-heading">
            Remarks
        </div>

        <CKEditor:CKEditorControl ID="txtRemarks" ClientIDMode="Static" runat="server"></CKEditor:CKEditorControl>
    </div>

    <div class="save-div">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_OnClick" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_OnClick" />
        <asp:Label ID="lblError" runat="server"
            Visible="False" ForeColor="red"
            Text="Couldn't save"></asp:Label>
    </div>

    <asp:HiddenField ID="hidActivityGradingId" runat="server" Value="0" />
    <asp:HiddenField ID="hidActivityId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidUserClassId" runat="server" Value="0" />
    <asp:HiddenField ID="hidActivityResourceId" runat="server" Value="0" />
</asp:Content>


<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link href="../../../Content/CSSes/TableStyles.css" rel="stylesheet" />
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="title">
    Submissions
</asp:Content>

