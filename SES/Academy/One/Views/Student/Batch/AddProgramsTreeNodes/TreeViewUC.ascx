<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TreeViewUC.ascx.cs" Inherits="One.Views.Student.Batch.AddProgramsTreeNodes.TreeViewUC" %>
<%@ Register Src="~/Views/Student/Batch/AddProgramsTreeNodes/TreeNodeUC.ascx" TagPrefix="uc1" TagName="TreeNodeUC" %>
<%@ Register Src="~/Views/Student/Batch/StudentEntries/StudentEntr.ascx" TagPrefix="uc1" TagName="StudentEntr" %>


<div>

    <div>
       
                <uc1:TreeNodeUC runat="server" ID="Root" />
           
    </div>
    <div>

        <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" Width="74px" />--%>

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
