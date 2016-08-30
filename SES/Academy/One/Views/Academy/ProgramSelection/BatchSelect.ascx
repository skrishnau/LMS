<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BatchSelect.ascx.cs" Inherits="One.Views.Academy.ProgramSelection.BatchSelect" %>
<style type="text/css">
    .batch-items:hover {
        background-color: cornsilk;
        /*color: white;*/
    }
</style>

<div style="margin: 20px 2px 10px 10px; padding-left: 5px; overflow: auto;">
    
    <asp:HiddenField ID="hidProgramId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSelectedProgramBatchId" runat="server" Value="0" />

    <asp:DataList ID="DataList1" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" OnSelectedIndexChanged="DataList1_SelectedIndexChanged" OnItemCommand="DataList1_ItemCommand">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <ItemTemplate>
            <div class="batch-items" style="padding: 3px; border: 2px lightblue solid;">
                <%--<asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("BatchId") %>' />--%>
                <%--<asp:Label ID="Label1" runat="server" Text='<%# Eval("BatchId")+" "+Eval("ProgramId") %>'></asp:Label>--%>
                <asp:LinkButton ID="Label1" runat="server" Text='<%# Eval("ProgramBatchName") %>'
                    CssClass="block" CommandName="Select" Font-Underline="False"
                    CommandArgument='<%# Eval("ProgramBatchId")+","+Eval("ProgramBatchName") %>' CausesValidation="False"></asp:LinkButton>
            </div>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:DataList>
    <hr />
    <div style="text-align: center;">
        <asp:Button ID="btnDone" runat="server" CausesValidation="False" Text="Done" Width="66px" OnClick="btnDone_Click" />
    </div>
</div>
