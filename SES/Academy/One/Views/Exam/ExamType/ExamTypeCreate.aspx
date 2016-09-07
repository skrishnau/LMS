<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ExamTypeCreate.aspx.cs" Inherits="One.Views.Exam.ExamType.ExamTypeCreate" %>

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
    <div>
        <div style="text-align: center;">
            <strong>Exam Type Create</strong>
            <hr />
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="vertical-align: top;">
                    <tr class="this-row">
                        <td class="this-data">Name</td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqVali" ControlToValidate="txtName" runat="server" ForeColor="red" ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr class="this-row">
                        <td class="this-data">Description</td>
                        <td>
                            <asp:TextBox ID="txtDescription" runat="server" Height="65px" TextMode="MultiLine" Width="222px"></asp:TextBox>
                        </td>
                    </tr>
                    <%-- <tr>
                <td>Public Notice</td>
                <td></td>
            </tr>--%>
                    <tr class="this-row">
                        <td class="this-data">Weight</td>

                        <td>
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
                    <tr class="this-row">
                        <td>Marks</td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <%--<asp:DropDownList ID="DropDownList1" runat="server" Height="23px" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="ddlWeight_SelectedIndexChanged">
                                            <Items>
                                                <asp:ListItem Value="1" Text="In Marks" Selected="True"></asp:ListItem>
                                                <asp:ListItem Value="0" Text="In Grade"></asp:ListItem>
                                            </Items>
                                        </asp:DropDownList>--%>
                                        <asp:Panel ID="Panel1" runat="server">
                                            <table>
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
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                </table>
                <asp:HiddenField ID="hidExamTypeId" runat="server" Value="0" />

            </ContentTemplate>
        </asp:UpdatePanel>
        <div>
            <span class="this-data" style="display: inline-block;"></span>
            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="88px" />
        </div>
    </div>
</asp:Content>
