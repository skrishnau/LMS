<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChooseRestrictionTypeUC.ascx.cs" Inherits="One.Views.RestrictionAccess.ChooseRestrictionTypeUC" %>

<style type="text/css">
    .restriction-type-chhose-item {
        padding: 5px;
    }
    .restriction-type-chhose-item :hover{
        background-color: lightyellow;
    }
</style>

<div style="width: 190px;">
    <asp:DataList ID="dlistRestrictionChoose" runat="server" OnItemCommand="dlistRestrictionChoose_ItemCommand">
        <ItemTemplate>
            <div class="restriction-type-chhose-item">
                <asp:LinkButton ID="LinkButton1" CssClass="inline-block"
                    Font-Underline="False" ForeColor="black" BackColor="lightgrey" 
                    BorderColor="lightgrey"
                    CommandName="Select"
                    CommandArgument='<%#  Eval("Id")+","+Eval("Name") %>'
                     runat="server">
                  <%# Eval("Name")%>
                </asp:LinkButton>
            </div>
        </ItemTemplate>
        <SelectedItemStyle BackColor="lightblue"></SelectedItemStyle>
    </asp:DataList>
    <asp:HiddenField ID="hidRestrictionId" runat="server" Value=""/>
</div>
