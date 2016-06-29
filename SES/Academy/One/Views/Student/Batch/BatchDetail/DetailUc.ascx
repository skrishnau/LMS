<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailUc.ascx.cs" Inherits="One.Views.Student.Batch.BatchDetail.DetailUc" %>
<%@ Register Src="~/Views/Student/Batch/Create/AddProgramsUc.ascx" TagPrefix="uc1" TagName="AddProgramsUc" %>

<div>
    <div class="item-section-heading">
        <asp:Label runat="server" ID="lblBatchName"></asp:Label>
        <div class="item-summary">
            <asp:Label runat="server" ID="lblSummary"></asp:Label>
        </div>

    </div>
    <div style="margin: 20px; padding-left: 20px;">
        <asp:PlaceHolder ID="pnlProgramsInTheBatch" runat="server"></asp:PlaceHolder>
    </div>
    <div> 
         <div style="margin: 20px;">
            <asp:LinkButton ID="lnkAddPrograms" runat="server" OnClick="lnkAddPrograms_Click" >
                <asp:Image ID="Image1" runat="server"  ImageUrl="~/Content/Icons/Add/Add-icon.png"/>
               &nbsp; Add Programs
            </asp:LinkButton>

        </div>
        <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
    </div>
</div>
