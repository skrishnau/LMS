<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BatchSelectUc.ascx.cs" Inherits="One.Views.AcademicPlacement.StudentClass.BatchSelectUc" %>


<div style="margin-left: 30px; margin-bottom: 10px; width: 474px; background-color: lightgray;">
  

    <div style="float: right;">
        <%-- OnClick="btnClose_Click"  class="float-right width-auto"--%>
        <asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/Content/Icons/Close/dialog_close.png" OnClick="btnClose_Click" />
    </div>
    <div>
        <asp:Panel ID="Panel1" runat="server">
            Selected:&nbsp;
            <asp:Label ID="lblProgramBatch" runat="server" Text=""></asp:Label>
        </asp:Panel>
    </div>

    <div>
        <br />
        <asp:Panel ID="pnlPrevious" runat="server">
            Previous Groups
            <hr />
            <asp:ListBox ID="lstEarlier" runat="server" Width="330px" AutoPostBack="True" OnSelectedIndexChanged="lstEarlier_SelectedIndexChanged"></asp:ListBox>
        </asp:Panel>
    </div>

    <div>
        <br />
        <asp:Panel ID="pnlNewGroup" runat="server">
            New Groups
            <hr />
            <asp:ListBox ID="lstNewGroups" runat="server" Width="330px" AutoPostBack="True" OnSelectedIndexChanged="lstNewGroups_SelectedIndexChanged"></asp:ListBox>
        </asp:Panel>
    </div>
    <div>
        <br />
        <asp:Panel ID="pnlOtherGroup" runat="server">
            Other Groups
            <hr />
            <asp:ListBox ID="lstOthergroups" runat="server" Width="330px" AutoPostBack="True" OnSelectedIndexChanged="lstOthergroups_SelectedIndexChanged"></asp:ListBox>
        </asp:Panel>
    </div>
    <div>
        <asp:HiddenField ID="hidProgramBatchId" runat="server" Value="0" />
        <br />
    </div>
    &nbsp;&nbsp;
                <asp:Button ID="btnSave" runat="server" Text="Done" Width="68px" OnClick="btnSave_Click" />
    <br />
   
</div>
