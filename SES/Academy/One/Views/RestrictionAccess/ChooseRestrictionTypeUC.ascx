<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChooseRestrictionTypeUC.ascx.cs" Inherits="One.Views.RestrictionAccess.ChooseRestrictionTypeUC" %>

<style type="text/css">
    .restriction-type-chhose-item {
        padding: 5px;
    }

        .restriction-type-chhose-item :hover {
            background-color: lightyellow;
        }

    .res_type_item {
        display: inline-block;
    }
</style>

<div style="width: 190px;">
    <asp:DataList ID="dlistRestrictionChoose" runat="server" OnItemCommand="dlistRestrictionChoose_ItemCommand">
        <ItemTemplate>
            <div class="restriction-type-chhose-item">
                <div class="res_type_item">
                    <asp:LinkButton ID="lnkRestrictChoose"
                        CssClass="res_type_item" CausesValidation="False"
                        Font-Underline="False" ForeColor="black" BackColor="lightgrey"
                        BorderColor="lightgrey"
                        CommandName="Select"
                        CommandArgument='<%#  Eval("Id")+","+Eval("Name") %>'
                        runat="server">
                  <%# Eval("Name")%>
                    </asp:LinkButton>
                </div>
            </div>
        </ItemTemplate>
        <SelectedItemStyle BackColor="lightblue"></SelectedItemStyle>
    </asp:DataList>
    <%-- ClientIDMode="Static" CssClass="res__type_item" --%>
    <a href="#" id="close">Close dialog</a>

    <%--<asp:LinkButton ID="lnkC8798lose__ResC6876876876hoose" ClientIDMode="Static"  CssClass="res_type_item"   runat="server">Close</asp:LinkButton>--%>

    <asp:HiddenField ID="hidRestrictionId" runat="server" Value="" />


    <script type="text/javascript">
        //$("#lnkCloseResChoose")
        //      .on("click",
        //              function () {
        //                  $("#restrictionchoosedialog").dialog("close");
        //              });
       
            //.on("click",
            //        function () {
            //            $("#restrictionchoosedialog").dialog("close");
            //        });
    </script>
</div>
