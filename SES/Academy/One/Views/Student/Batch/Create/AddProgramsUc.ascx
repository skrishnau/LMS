<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddProgramsUc.ascx.cs" Inherits="One.Views.Student.Batch.Create.AddProgramsUc" %>
<%@ Register Src="~/Views/Student/Batch/AddProgramsTreeNodes/TreeViewUC.ascx" TagPrefix="uc1" TagName="TreeViewUC" %>
<%@ Register Src="~/Views/Student/Batch/StudentEntries/StudentEntr.ascx" TagPrefix="uc1" TagName="StudentEntr" %>



<div>
    <asp:UpdatePanel ID="updatePanelTreeNode" runat="server">
        <ContentTemplate>
            <uc1:TreeViewUC runat="server" ID="TreeViewUC" />
            &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSave" runat="server" Text="Add these Programs" OnClick="btnSave_Click" Width="150px" />
            <strong>
                <asp:Label ID="lblMsg" runat="server" ForeColor="#FF3300"></asp:Label>
            </strong>
            <div>
                <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
                <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlStudentEntry" runat="server" CssClass="popup-batch-student ">
                <%--<div class="popup-background">_</div>--%>
                <%--<asp:Panel ID="innerpanel" runat="server" CssClass="popup whiteBackground">--%>
                <uc1:StudentEntr runat="server" ID="StudentEntr" />
                <%--</asp:Panel>--%>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
