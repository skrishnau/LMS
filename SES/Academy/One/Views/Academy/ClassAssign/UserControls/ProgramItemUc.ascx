<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgramItemUc.ascx.cs" Inherits="One.Views.Academy.ClassAssign.UserControls.ProgramItemUc" %>

<div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>

            <asp:CheckBox ID="chkBox" runat="server" OnCheckedChanged="chkBox_CheckedChanged" AutoPostBack="True" />
            <%--<asp:Label ID="lblName" runat="server" Text=""></asp:Label>--%>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table class="pc-table">
                        <asp:Panel ID="pnlYears" runat="server"></asp:Panel>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>

        </ContentTemplate>
    </asp:UpdatePanel>

            <asp:HiddenField ID="hidProgramId" runat="server" Value ="0"/>
    <asp:HiddenField ID="hidAcademicYearId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />

</div>
