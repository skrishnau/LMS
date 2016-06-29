<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.CreateUC" %>

<%@ Reference Control="~/Views/Structure/All/UserControls/LevelCreate.ascx" %>
<%@ Register Src="~/Views/Structure/All/UserControls/LevelCreate.ascx" TagPrefix="uc1" TagName="LevelCreate" %>
<%@ Register Src="~/Views/Structure/All/UserControls/FacultyCreateUC.ascx" TagPrefix="uc1" TagName="FacultyCreateUC" %>
<%@ Register Src="~/Views/Structure/All/UserControls/ProgramCreateUC.ascx" TagPrefix="uc1" TagName="ProgramCreateUC" %>
<%@ Register Src="~/Views/Structure/All/UserControls/YearCreateUC.ascx" TagPrefix="uc1" TagName="YearCreateUC" %>
<%@ Register Src="~/Views/Structure/All/UserControls/SubYearCreateUC.ascx" TagPrefix="uc1" TagName="SubYearCreateUC" %>





<style type="text/css">
    .left-list-div {
        float: left;
    }

    .left-create-div {
        float: left;
    }

    .right-div {
        float: right;
        width: 100%;
    }

    .auto-style2 {
        width: 70px;
    }
</style>

<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>



            <asp:Panel ID="pnlMsg" runat="server">
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
            </asp:Panel>

            <div class="left-list-div">
                <asp:Panel ID="pnlLevels" runat="server">
                    <table>
                        <tr>
                            <td class="auto-style2"><strong>Level</strong></td>
                            <td>
                                <asp:DropDownList ID="cmbLevels" runat="server" Height="24px"
                                    OnSelectedIndexChanged="cmbLevels_SelectedIndexChanged" Width="160px" AutoPostBack="True">
                                </asp:DropDownList>

                                &nbsp;

                                <asp:ImageButton ID="imgLevel" runat="server" ImageUrl="~/Content/Icons/plus2.png" OnClick="imgLevel_Click" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>

            <div class="left-create-div">
                <asp:Panel ID="pnlLevelCreate" runat="server" Visible="False">
                    <uc1:LevelCreate runat="server" ID="LevelCreate" />
                </asp:Panel>
            </div>
            <div class="right-div">
                <hr />
            </div>


            <%-- ================Faculty=========================== --%>
            
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlFacultyAll" runat="server" Visible="False">
                    <div class="left-create-div" style="width: 70px;"></div>
                        <div class="left-list-div">
                            <asp:Panel ID="pnlFaculty" runat="server">
                                <table>
                                    <tr>
                                        <td class="auto-style2"><strong>Faculty</strong></td>
                                        <td>
                                            <asp:DropDownList ID="cmbFaculties" runat="server" Height="24px"
                                                OnSelectedIndexChanged="cmbFaculties_SelectedIndexChanged" Width="160px" AutoPostBack="True">
                                            </asp:DropDownList>
                                            &nbsp;&nbsp;<asp:ImageButton ID="imgFac" runat="server" ImageUrl="~/Content/Icons/plus2.png"
                                                OnClick="imgFac_Click" CausesValidation="False" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </div>

                        <div class="left-create-div">
                            <asp:Panel ID="pnlFacultyCreate" runat="server" Visible="False">
                                <uc1:FacultyCreateUC runat="server" ID="FacultyCreateUC" />
                            </asp:Panel>
                        </div>
                        <div class="right-div">
                            <hr />
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>




            <%-- ================Program=========================== --%>
            <asp:Panel ID="pnlProgramAll" runat="server" Visible="False">
                    <div class="left-create-div" style="width: 108px;"></div>
                <div class="left-list-div">
                    <asp:Panel ID="pnlProgram" runat="server">
                        <table>
                            <tr>
                                <td class="auto-style2"><strong>Program </strong></td>
                                <td>
                                    <asp:DropDownList ID="cmbPrograms" runat="server" Height="24px" Width="160px" OnSelectedIndexChanged="cmbPrograms_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;<asp:ImageButton ID="imgProg" runat="server" ImageUrl="~/Content/Icons/plus2.png"
                                        OnClick="imgProg_Click" CausesValidation="False" />
                                </td>
                            </tr>
                        </table>

                    </asp:Panel>
                </div>

                <div class="left-create-div">
                    <asp:Panel ID="pnlProgramCreate" runat="server" Visible="False">
                        <uc1:ProgramCreateUC runat="server" ID="ProgramCreateUC" />
                    </asp:Panel>
                </div>
                <div class="right-div">
                    <hr />
                </div>
            </asp:Panel>


            <%-- ================Year=========================== --%>
            <asp:Panel ID="pnlYearAll" runat="server" Visible="False">
                    <div class="left-create-div" style="width: 193px;"></div>
                <div class="left-list-div">
                    <asp:Panel ID="pnlYear" runat="server" >
                        <table>
                            <tr>
                                <td class="auto-style2"><strong>Year</strong></td>
                                <td>
                                    <asp:DropDownList ID="cmbYear" runat="server" Height="24px" Width="160px" OnSelectedIndexChanged="cmbYear_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;<asp:ImageButton ID="imgYear" runat="server" ImageUrl="~/Content/Icons/plus2.png"
                                        OnClick="imgYear_Click" CausesValidation="False" />
                                </td>
                            </tr>
                        </table>

                    </asp:Panel>
                </div>

                <div class="left-create-div">
                    <asp:Panel ID="pnlYearCreate" runat="server" Visible="False">
                        <uc1:YearCreateUC runat="server" ID="YearCreateUC" />
                    </asp:Panel>
                </div>
                <div class="right-div">
                    <hr />
                </div>
            </asp:Panel>


            <%-- ================Sub Year=========================== --%>
            <asp:Panel ID="pnlSubYearAll" runat="server" Visible="False">
                    <div class="left-create-div" style="width: 255px;"></div>
                <div class="left-list-div">
                    <asp:Panel ID="pnlSubYear" runat="server" >
                        <table>
                            <tr>
                                <td class="auto-style2"><strong>Sub Year</strong></td>
                                <td>
                                    <asp:DropDownList ID="cmbSubYear" runat="server" Height="24px" Width="160px" AutoPostBack="True">
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;<asp:ImageButton ID="imgSubYear" runat="server" ImageUrl="~/Content/Icons/plus2.png"
                                        OnClick="imgSubYear_Click" CausesValidation="False" />
                                </td>
                            </tr>
                        </table>

                    </asp:Panel>
                </div>

                <div class="left-create-div">
                    <asp:Panel ID="pnlSubYearCreate" runat="server" Visible="False">
                        <uc1:SubYearCreateUC runat="server" ID="SubYearCreateUC" />
                    </asp:Panel>
                </div>
                <div class="right-div">
                    <hr />
                </div>
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>
</div>
