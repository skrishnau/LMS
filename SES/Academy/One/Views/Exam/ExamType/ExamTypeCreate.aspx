<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ExamTypeCreate.aspx.cs" Inherits="One.Views.Exam.ExamType.ExamTypeCreate" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content runat="server" ID="headcontent1" ContentPlaceHolderID="head">
    <style type="text/css">
        .this-row {
            vertical-align: top;
        }

        .this-data {
            width: 126px;
        }
    </style>
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <%-- Form to enter exam Type --%>
    <div class="data-entry-body">
        <h3 class="heading-of-create-edit">
            <strong>Exam Type Create</strong>
        </h3>
        <hr />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="data-entry-section">
                    <div class="data-entry-section-heading">
                        General
                        <hr />
                    </div>
                    <div class="data-entry-section-body">

                        <table >
                            <tr >
                                <td class="data-type">Name</td>
                                <td class="data-value">
                                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="reqVali" ControlToValidate="txtName" runat="server" ForeColor="red" ErrorMessage="Required"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr class="data-type">
                                <td class="data-value">Description</td>
                                <td>
                                    <asp:TextBox ID="txtDescription" runat="server" Height="65px" TextMode="MultiLine" Width="222px"></asp:TextBox>
                                </td>
                            </tr>

                            <tr>
                                <td class="data-type">Weight</td>
                                <td class="data-value">
                                    <asp:DropDownList ID="ddlWeight" runat="server" Height="23px" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlWeight_SelectedIndexChanged">
                                        <Items>
                                            <asp:ListItem Value="0" Text="In Percent" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="In Marks"></asp:ListItem>
                                        </Items>
                                    </asp:DropDownList>
                                    &nbsp;
                                    <asp:TextBox ID="txtWeight" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="valiWeight" runat="server" ErrorMessage="Not a number. " ControlToValidate="txtWeight" ForeColor="red"></asp:RequiredFieldValidator>
                                    <%--<asp:RequiredFieldValidator ID="rangeVali" ForeColor="red" runat="server" ErrorMessage="0 to 100 Only." ControlToValidate="txtWeight" MaximumValue="100" MinimumValue="0"></asp:RequiredFieldValidator>--%>
                                </td>

                            </tr>
                            <tr>
                                <td class="data-type">Marks</td>
                                <td class="data-value">
                                    <%--<table>
                                        <tr>--%>
                                    <%--<td>--%>
                                    <%--<asp:DropDownList ID="DropDownList1" runat="server" Height="23px" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlWeight_SelectedIndexChanged">
                                            <Items>
                                                <asp:ListItem Value="1" Text="In Marks" Selected="True"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="In Grade"></asp:ListItem>
                                            </Items>
                                        </asp:DropDownList>--%>
                                    <asp:Panel ID="Panel1" runat="server">
                                        <table style="margin-left: -3px;">
                                            <tr>
                                                <td>FullMarks</td>
                                                <td>
                                                    <asp:TextBox ID="txtFullmarks" runat="server" TextMode="Number"></asp:TextBox>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Pass Marks</td>
                                                <td>
                                                    <asp:TextBox ID="txtPassmarks" runat="server" TextMode="Number"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <%--</td>
                                        </tr>
                                    </table>--%>
                                </td>
                            </tr>
                        </table>
                    </div>

                </div>
                <div class="data-entry-section-body">
                    <div class="data-entry-section-heading">
                        Notice
                        <hr />
                    </div>

                    <div style="float: right; visibility: hidden;">
                        <div style="position: absolute; float: right; width: auto;">
                            <asp:Panel ID="pnlHelp" runat="server" Visible="False" BackColor="white">
                                <asp:LinkButton ID="btnCloseHelp" CausesValidation="False"
                                    runat="server" OnClick="btnCloseHelp_Click">
                                    <asp:Image ID="imgcross" ImageUrl="~/Content/Icons/Close/dialog_close.png"></asp:Image>
                                </asp:LinkButton>
                                You can add properties by using '@' in fornt of Property name and replacing space with
                                underscore(_).
                                <br />
                                For e.g., "Start Date" can be written as "@Start_Date",
                                "Result Date" can be written as "Result_Date", etc.
                            </asp:Panel>
                        </div>
                        <asp:LinkButton ID="btnHelp" runat="server" Visible="False"
                            CausesValidation="False" OnClick="btnHelp_Click">
                            <asp:Image runat="server" ImageUrl="~/Content/Icons/Help/help_blu.png"/>
                        </asp:LinkButton>
                    </div>
                    <div style="margin: 20px;">

                        <CKEditor:CKEditorControl ID="CKEditor1" runat="server">
                        </CKEditor:CKEditorControl>
                    </div>
                </div>

                <asp:HiddenField ID="hidExamTypeId" runat="server" Value="0" />
                <hr />
            </ContentTemplate>
        </asp:UpdatePanel>

        <div class="save-div">
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="88px" />
        </div>
    </div>
</asp:Content>
