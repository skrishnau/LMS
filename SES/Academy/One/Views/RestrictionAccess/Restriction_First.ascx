<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Restriction_First.ascx.cs" Inherits="One.Views.RestrictionAccess.Restriction_First" %>

<style type="text/css">
    .restriction-uc-whole {
        border: 2px solid lightgrey;
        padding: 2px 2px 2px 5px;
        vertical-align: central;
    }

    .restriction-body {
        border: 2px solid darkgray;
       
        vertical-align: central;
    }
</style>


<asp:MultiView ID="multiViewRestrict" runat="server" ActiveViewIndex="0">
    <asp:View ID="viewNone" runat="server">
        None 
        &nbsp;
    <asp:ImageButton ID="imgCloseRestrictionSet" ImageUrl="~/Content/Icons/Close/cross_8x20_center.png" runat="server" />
    </asp:View>
    <asp:View ID="viewRestriction" runat="server">
        <div>
            <div>
                Student&nbsp;
                <asp:DropDownList ID="ddlMustMatch" runat="server">
                    <Items>
                        <asp:ListItem Value="0" Text="must"></asp:ListItem>
                        <asp:ListItem Value="1" Text="must not"></asp:ListItem>
                    </Items>
                </asp:DropDownList>
                &nbsp;match
                <asp:DropDownList ID="ddlAllAny" runat="server">
                    <Items>
                        <asp:ListItem Value="0" Text="all"></asp:ListItem>
                        <asp:ListItem Value="1" Text="any"></asp:ListItem>
                    </Items>
                </asp:DropDownList>
                &nbsp;of the following
            </div>

            <asp:Panel ID="pnlRestrictions" CssClass="restriction-body" runat="server">
            </asp:Panel>

        </div>
    </asp:View>
</asp:MultiView>

<div id="restriction-choose-dialog"></div>
<%-- OnClick="btnAddRestriction_Click" --%>
<asp:Button ID="btnAddRestriction" ClientIDMode="Static" runat="server" Text="Add restriction"  />

<script type="text/javascript">
    
</script>