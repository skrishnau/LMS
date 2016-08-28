<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.Academy.AcademicYear.Create" %>

<%-- "" --%>
<%@ Register Src="~/Views/UserControls/DateChooser.ascx" TagPrefix="uc1" TagName="DateChooser" %>


<%@ Register Src="../Session/CreateUC.ascx" TagName="CreateUC" TagPrefix="uc2" %>

<asp:Content runat="server" ID="headContent" ContentPlaceHolderID="head">
    <link rel="stylesheet" href="~/Content/DatePickerResourses/jquery-ui-1.9.2.custom.css" />
    <script src="~/Content/DatePickerResourses/jquery-1.8.3.js"></script>
    <script>
        $(function () {
            $("#datepicker").datepicker();

            $("#txtStart").datepicker();
            $("#txtEnd").datepicker();
        });
    </script>
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--<asp:Panel ID="pnlAcademicYear" runat="server">--%>


                <fieldset>
                    <legend>Academic Year</legend>
                    <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    <table>
                        <tr>
                            <td>Name
                            </td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" Width="128px"></asp:TextBox>
                                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                    ControlToValidate="txtName" ErrorMessage="Name is required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Start Date</td>
                            <td>
                                <div style="position: absolute;">
                                    <asp:TextBox ID="txtStart" runat="server" ClientIDMode="Static"></asp:TextBox>
                                    <%--<uc1:DateChooser runat="server" ID="dtStart" />--%>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td>End Date
                            </td>
                            <td>
                                <div style="position: absolute;">
                                    <%--<uc1:DateChooser runat="server" ID="dtEnd" />--%>
                                    <asp:TextBox ID="txtEnd" runat="server" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </td>
                        </tr>

                        <%-- <tr>
                <td>School
                </td>
                <td>
                    <asp:DropDownList ID="cmbSchool" runat="server" Height="20px" Width="135px"></asp:DropDownList>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="cmbSchool" ErrorMessage="School is required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>--%>
                    </table>

                    <%-- <div style="position: relative;">
                        <asp:Panel ID="panelStart" runat="server">
                            Start Date &nbsp;
                       
                        </asp:Panel>
                    </div>--%>

                    <br />
                    <%-- <div style="position: relative;">

                        <asp:Panel ID="panelEnd" runat="server">
                            End Date &nbsp;
                       
                        </asp:Panel>
                        <br />
                    </div>--%>
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Make this Current Academic Year." />
                    <em style="font-size: 12px;">Note: Previous Academic year will be disabled.</em>
                </fieldset>
            <%--</asp:Panel>--%>
            <br />
            &nbsp;
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="75px" />
            <hr />
            <hr />
            <%--<input id="datepicker" type="text" />--%>


            <%--   </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>--%>
            &nbsp;<%--   </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>--%>&nbsp;<asp:Button ID="btnSaveAndAddClass" runat="server" Text="Save and Add Classes" Width="168px" />
            <br />
            <asp:Panel runat="server" ID="pnlSession">
                <uc2:CreateUC ID="CreateUC1" runat="server" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div>
        <p>
            Date:
                <input id="datepicker" type="text" />
        </p>

    </div>
    <br />
</asp:Content>
