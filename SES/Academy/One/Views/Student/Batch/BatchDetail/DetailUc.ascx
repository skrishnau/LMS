<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetailUc.ascx.cs" Inherits="One.Views.Student.Batch.BatchDetail.DetailUc" %>
<%@ Register Src="~/Views/Student/Batch/Create/AddProgramsUc.ascx" TagPrefix="uc1" TagName="AddProgramsUc" %>

<div style="padding: 5px;">
    <div style="margin: 2px 2px 15px 5px; padding: 0 0 15px 0; background-color: azure;">
        <div style="margin: 2px 2px 10px 0;">
            <span style="font-size: 1.6em; font-weight: bold;">
                <asp:Label runat="server" ID="lblBatchName"></asp:Label>
            </span>
            &nbsp;&nbsp;
         <span style="margin: 15px; font-size: 0.7em;">
             <asp:HyperLink ID="lnkEdit" runat="server" NavigateUrl="~/Views/Student/Batch/Create/BatchCreate.aspx">
                 <asp:Image ID="Image1" Height="13px" Width="13px" runat="server" ImageUrl="~/Content/Icons/Edit/edit_black_and_white.png" />
                 &nbsp; Edit
             </asp:HyperLink>

         </span>
        </div>
        <div style="font-size: 1em; margin-left: 25px;">
            <asp:Label runat="server" ID="lblSummary"></asp:Label>
        </div>

    </div>
    <div style="padding: 5px;">
        <strong>Programs in this batch</strong>
        <hr />
        <div style="margin: 10px; padding-left: 10px;">
            <asp:PlaceHolder ID="pnlProgramsInTheBatch" runat="server"></asp:PlaceHolder>
        </div>
    </div>
    <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
</div>
