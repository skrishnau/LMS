<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="AcademyCreate.aspx.cs" Inherits="One.Views.Academy.AcademicYear.AcademyCreate" %>


<asp:Content runat="server" ID="headContent" ContentPlaceHolderID="head">
    <link rel="stylesheet" href="../../../DatePickerJquery/jquery-ui-1.9.2.custom.css" />
    <script src="../../../DatePickerJquery/jquery-1.8.3.js"></script>
    <script>
        $(function () {
            $("#txtStart").datepicker();
            $("#txtEnd").datepicker();
        });
    </script>
    <style type="text/css">
        .cell-width {
            width: 75px;
        }
       
        .auto-style1 {
            width: 104px;
        }
       
    </style>
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div style="padding: 5px; margin-left: 2px;">
        <div style="font-size: 1.3em; text-align: center;">
            <asp:Label ID="lblHeading" runat="server" Text="New Academic Year"></asp:Label>
            <hr />
        </div>
        <table>
            <tr>
                <td class="auto-style1">Name</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="128px" ToolTip="Usually its year. e.g. 2016"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtName" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">Start Date</td>
                <td>
                    <asp:TextBox ID="txtStart" runat="server" ClientIDMode="Static"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="valiStartDate" runat="server"
                        ControlToValidate="txtStart" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="auto-style1">End Date</td>
                <td>
                    <asp:TextBox ID="txtEnd" runat="server" ClientIDMode="Static"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="valiEndDate" runat="server"
                        ControlToValidate="txtEnd" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>

                </td>
            </tr>

          <%--  <tr>
                <td colspan="5">
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Make this Current Academic Year." />
                    <em style="font-size: 12px;">Note: Previous Academic year will be disabled.</em>
                </td>
            </tr>--%>
        </table>
        <br />
        <div>
            <span class="auto-style1" style="display: inline-block;"></span>
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click"
                Text="Save and return" Width="163px" />
            &nbsp;&nbsp;

            <asp:Button ID="btnSaveAndAddSessions" runat="server"
                Text="Save and Add Sessions" OnClick="btnSave_Click" Width="168px" />

        </div>

        <asp:HiddenField ID="hidId" runat="server" Value="0" />

        <p>
        </p>

    </div>
</asp:Content>
