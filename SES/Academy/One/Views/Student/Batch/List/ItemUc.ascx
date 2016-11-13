<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemUc.ascx.cs" Inherits="One.Views.Student.Batch.List.ItemUc" %>

<div>
    <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
    <div style="margin: 5px; border: 1px solid darkgray;">
        <%-- class="item-heading" --%>
        <%-- style="font-size: 1.3em; padding: 5px 10px; margin: 10px 20px;" --%>
        <div style="padding: 5px; font-size: 1.2em;" >
            <asp:HyperLink ID="lnkName" runat="server" ></asp:HyperLink>
            
            &nbsp;
                <asp:HyperLink ID="lnkEdit" runat="server" >
                    <asp:Image ID="imgEditBtn" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
                </asp:HyperLink>
        </div>



        <%--<div style="padding: 0 0 5px 15px; margin: 0 0 5px 40px;">
           <asp:Literal ID="lblNumberOfPrograms" runat="server"></asp:Literal>--%>
            <%--  No. of Programs:&nbsp; --%>
           <%-- Start Year: &nbsp;<asp:Literal ID="lblStartYear" runat="server"></asp:Literal>
            Currently In:&nbsp;<asp:Literal ID="lblCurrentlyIn" runat="server"></asp:Literal>--%>
        <%--</div>--%>
       
       <%-- <div class="item-summary">
            
        </div>--%>

    </div>
</div>
