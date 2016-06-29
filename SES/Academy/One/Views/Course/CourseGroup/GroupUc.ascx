<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupUc.ascx.cs" Inherits="One.Views.Course.CourseGroup.GroupUc" %>

<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="clear: both;"></div>
            <div>
                <asp:HiddenField ID="hidId" runat="server" Value="0" />
                <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
                <asp:HiddenField ID="hidLevelId" runat="server" Value="0" />
                <asp:HiddenField ID="hidFacultyId" runat="server" Value="0" />
                <asp:HiddenField ID="hidProgramId" runat="server" Value="0" />
                <asp:HiddenField ID="hidSubjectGroupId" runat="server" Value="0" />

                <fieldset>
                    <legend>New Course Group</legend>
                    <div style="float: right;">
                        <asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/Content/Icons/Close/dialog_close.png" style="width: 16px" OnClick="btnClose_Click" />
                    </div>
                    <asp:Label ID="lblMessage" runat="server" BackColor="#FFCCFF" ForeColor="#FF3300"></asp:Label>
                    <table>
                        <tr>
                            <td>Level&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="cmbLevel" runat="server" Height="21px" Width="159px" AutoPostBack="True" OnSelectedIndexChanged="cmbLevel_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Faculty&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="cmbFaculty" runat="server" Height="21px" Width="159px" AutoPostBack="True" OnSelectedIndexChanged="cmbFaculty_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Program&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="cmbProgram" runat="server" Height="21px" Width="159px" AutoPostBack="True" OnSelectedIndexChanged="cmbProgram_SelectedIndexChanged"></asp:DropDownList>
                                <%--<asp:Label ID="valiProgram" 
                        runat="server" 
                        Text="Required" ForeColor="#FF3300" Visible="false"></asp:Label>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>Year*&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="cmbYear" runat="server"
                                    Height="21px" Width="159px" AutoPostBack="True" OnSelectedIndexChanged="cmbYear_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="valiCmbYear" ControlToValidate="cmbYear" ForeColor="#FF3300" runat="server" ErrorMessage="Required">
                                </asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <tr>
                            <td>Sub Year&nbsp;</td>
                            <td>
                                <asp:DropDownList ID="cmbSubYear" runat="server"
                                    Height="21px" Width="159px" AutoPostBack="True" OnSelectedIndexChanged="cmbSubYear_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>

                        <tr>
                            <td>Name*&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" Width="195px"></asp:TextBox>
                                <asp:Label ID="valiTxtName"
                                    runat="server" Text="Required" Visible="False" ForeColor="#FF3300"></asp:Label>
                            </td>
                        </tr>
                        <%--<tr>
                    <td>Position*&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txtPosition" runat="server" TextMode="Number" Width="154px"></asp:TextBox>
                        <asp:Label ID="valiPostion"
                            runat="server" Text="Required" Visible="False" ForeColor="#FF3300"></asp:Label>
                    </td>
                </tr>--%>
                        <%-- <tr>
                <td>School&nbsp;*</td>
                <td>
                    <asp:DropDownList ID="cmbSchool" runat="server" Height="20px" OnSelectedIndexChanged="cmbSchool_SelectedIndexChanged" Width="160px"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                       ControlToValidate="cmbSchool" runat="server" 
                        ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>--%>

                        <tr>
                            <td>Description&nbsp;</td>
                            <td>
                                <asp:TextBox ID="txtDescription" runat="server" Width="203px" TextMode="MultiLine" Height="79px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="94px" OnClick="btnSave_Click" />
                    &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="94px" OnClick="btnCancel_Click"  />

                    <br />

                    <br />
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
