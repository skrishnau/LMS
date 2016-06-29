<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemUc.ascx.cs" Inherits="One.Views.Student.Batch.List.ItemUc" %>

<div>
    <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
    <div class="item">
        <div class="item-heading">
            <asp:LinkButton ID="lblName" runat="server" OnClick="lblName_Click">LinkButton</asp:LinkButton>
            <div style="width: 62px; float: right;">

                <asp:LinkButton ID="lnkEdit" runat="server" OnClick="lnkEdit_Click">
                    <asp:Image ID="imgEditBtn" runat="server" ImageUrl="~/Content/Icons/Edit/edit_black_and_white.png"
                        Width="16" Height="14" />
                </asp:LinkButton>
            </div>
        </div>



        <div class="item-Option">
            No. of Programs:&nbsp;<asp:Literal ID="lblNumberOfPrograms" runat="server"></asp:Literal>
            Start Year: &nbsp;<asp:Literal ID="lblStartYear" runat="server"></asp:Literal>
            Currently In:&nbsp;<asp:Literal ID="lblCurrentlyIn" runat="server"></asp:Literal>
        </div>
        <div class="item-summary">
            
        </div>

    </div>
</div>
