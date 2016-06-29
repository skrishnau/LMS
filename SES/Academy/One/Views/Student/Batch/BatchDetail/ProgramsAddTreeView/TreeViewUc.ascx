<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TreeViewUc.ascx.cs" Inherits="One.Views.Student.Batch.BatchDetail.ProgramsAndTreeView.TreeViewUc" %>
<%@ Register Src="~/Views/Student/Batch/BatchDetail/ProgramsAddTreeView/TreeNodeUc.ascx" TagPrefix="uc1" TagName="TreeNodeUc" %>



<div>

    <div>
        <uc1:TreeNodeUc runat="server" id="Root" />
        <%--<uc1:TreeNodeUC runat="server" ID="Root" />--%>
    </div>
    <div>

        &nbsp;&nbsp;

        <asp:Button ID="btnSave" runat="server" Text="Save" Width="74px" OnClick="btnSave_Click" />
         <strong>
                <asp:Label ID="lblMsg" runat="server" ForeColor="#FF3300"></asp:Label>
            <br />
            </strong>
        <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
               <ContentTemplate>--%>

        <%-- <asp:Panel ID="pnlStudentEntry" runat="server" CssClass="popup" Visible="False">
            <div class="popup-background">_</div>
            <asp:Panel ID="innerpanel" runat="server" CssClass="popup whiteBackground">
                <uc1:StudentEntr runat="server" ID="StudentEntr" />
            </asp:Panel>
        </asp:Panel>--%>

        <%-- </ContentTemplate>
           </asp:UpdatePanel>--%>
    </div>
    <div>
        <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
        <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
    </div>
</div>
