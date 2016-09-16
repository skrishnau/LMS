<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RestrictionFourth.ascx.cs" Inherits="One.Views.RestrictionAccess.RestrictionFourth" %>


<div style="border: 2px solid darkgray; margin: 10px 0;">

    <asp:MultiView ID="multiViewRestrict" runat="server" ActiveViewIndex="0">
        <asp:View ID="viewNone" runat="server">
            None 
        &nbsp;
    <asp:ImageButton ID="imgCloseRestrictionSet" Visible="False" ImageUrl="~/Content/Icons/Close/cross_8x20_center.png" runat="server" />
        </asp:View>
        <asp:View ID="viewRestriction" runat="server">
            <div style="padding: 5px 10px; margin-top: 5px;  ">
                <div style="background-color: lightgray;">
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

                <div style="padding-left: 20px;">

                    <asp:Panel ID="pnlRestrictions" EnableViewState="True" ViewStateMode="Enabled" CssClass="restriction-body" runat="server">
                    </asp:Panel>
                </div>

            </div>
        </asp:View>
    </asp:MultiView>


    <asp:HiddenField ID="hidParentId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRelativeId" runat="server" Value="1" />
    <asp:HiddenField ID="hidAbsoluteId" runat="server" Value="1" />

    <asp:HiddenField ID="hidNoOfChildRestrictionSets" runat="server" Value="0" />


    <%-- <div id="restrictionchoosedialog">
        
    </div>--%>



    <%-- OnClick="btnAddRestriction_Click" --%>
    <%--<label runat="server" id="label1"></label>--%>
    <asp:Button ID="btnAddRestriction" ClientIDMode="Static"
        CssClass="btnAdd_Restriction" runat="server" Text="Add restriction" />
    &nbsp;
     <asp:LinkButton ID="lnkAddActOrRes" ClientIDMode="Static"
         CssClass="btnAdd_Restriction"
          runat="server">
         <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
         Add Restrictions
     </asp:LinkButton>
    <%--<asp:Button ID="Button1" runat="server" Text="Add Restriction set" OnClick="Button1_Click" />--%>

    <%-- Working script --%>
</div>
