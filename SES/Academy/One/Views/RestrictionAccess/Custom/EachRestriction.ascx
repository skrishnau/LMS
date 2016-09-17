<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EachRestriction.ascx.cs" Inherits="One.Views.RestrictionAccess.Custom.EachRestriction" %>
<%@ Register Src="~/Views/All_Resusable_Codes/Dialog/CustomDialog.ascx" TagPrefix="uc1" TagName="CustomDialog" %>





<div class="restriction-main">

<asp:HiddenField ID="hidPageKeyForUniqueSession" runat="server" Value="" />
    <asp:MultiView ID="multiViewRestrict" runat="server" ActiveViewIndex="0">
        <asp:View ID="viewNone" runat="server">
            None 
        &nbsp;
    <asp:ImageButton ID="imgCloseRestrictionSet" Visible="False" ImageUrl="~/Content/Icons/Close/cross_8x20_center.png" runat="server" />
        </asp:View>
        <asp:View ID="viewRestriction" runat="server">
            <div>
                <div style="background-color: lightgray;">
                    &nbsp;Student&nbsp;
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

                <div style="padding: 5px 10px 5px 20px; margin-top: 5px;" >

                    <asp:Panel ID="pnlRestrictions" EnableViewState="True" ViewStateMode="Enabled" CssClass="restriction-body" runat="server">
                    </asp:Panel>
                </div>

            </div>
        </asp:View>
    </asp:MultiView>


    <asp:HiddenField ID="hidParentId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRelativeId" runat="server" Value="1" />
    <asp:HiddenField ID="hidAbsoluteId" runat="server" Value="1" />
    <asp:HiddenField ID="hidType" runat="server" Value="" />

    <asp:HiddenField ID="hidNoOfChildRestrictionSets" runat="server" Value="0" />


    <%-- <div id="restrictionchoosedialog">
        
    </div>--%>



    <%-- OnClick="btnAddRestriction_Click" --%>
    <%--<label runat="server" id="label1"></label>--%>

   
    <div>
         <%--<asp:Button ID="btnAddRestriction" ClientIDMode="Static"
        CssClass="btnAdd_Restriction" runat="server" Visible="False" Text="Add restriction" />--%>
        &nbsp;
         <asp:LinkButton ID="lnkAddActOrRes" ClientIDMode="Static" CausesValidation="False"
             CssClass="btnAdd_Restriction"
             runat="server" OnClick="lnkAddActOrRes_Click">
             <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />--%>
             Add restrictions
         </asp:LinkButton>
    </div>
 <div>
     <div>
         <uc1:CustomDialog runat="server" ID="dialog" />
     </div>
 </div>
     

    <%--<asp:Button ID="Button1" runat="server" Text="Add Restriction set" OnClick="Button1_Click" />--%>

    <%-- Working script --%>
</div>
