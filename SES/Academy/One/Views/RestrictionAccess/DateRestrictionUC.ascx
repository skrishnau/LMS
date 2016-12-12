<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateRestrictionUC.ascx.cs" Inherits="One.Views.RestrictionAccess.DateRestrictionUC" %>

<%--<style type="text/css">
    input[type="checkbox"] {
        display: none;
    }

        input[type="checkbox"] + label span {
            display: inline-block;
            width: 19px;
            height: 19px;
            margin: -1px 4px 0 0;
            vertical-align: middle;
            background: url("~/Content/Icons/Visibility/eye_Visible.png") left top no-repeat;
            cursor: pointer;
        }

        input[type="checkbox"]:checked + label span {
            background: url("~/Content/Icons/Visibility/eye_hidden.png") -19px top no-repeat;
        }
</style>--%>

<div class="restriction-uc-whole">

    <%--<asp:CheckBox ID="chkVisibility" ClientIDMode="Static" runat="server" CssClass="visi-checkbox" />--%>
    <%--    <input type="checkbox" id="c1" name="cc" />
    <label for="c1"><span></span></label>--%>
    <%--<asp:ImageButton ID="imgVisibility" ImageUrl="~/Content/Icons/Visibility/eye_16x20_visible.png" runat="server" />--%>

    <span>
        <asp:PlaceHolder ID="pnlFromUntilOption" runat="server">Date&nbsp;
            &nbsp;
            <asp:DropDownList ID="ddlFromUntil" runat="server" Height="20px" Width="70px">
                <Items>
                    <asp:ListItem Value="0" Text="from"></asp:ListItem>
                    <asp:ListItem Value="1" Text="until"></asp:ListItem>
                </Items>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </asp:PlaceHolder>


        <%--OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True" --%>
        <asp:DropDownList ID="ddlYear" runat="server"></asp:DropDownList>
        &nbsp;&nbsp;
        <%-- OnSelectedIndexChanged="ddlMonth_SelectedIndexChanged"  --%>
        <asp:DropDownList ID="ddlMonth" runat="server" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
        &nbsp;&nbsp;
        <%--<asp:DropDownList ID="ddlDay" runat="server" DataTextField="Name" DataValueField="IdInString" Height="22px" Width="67px"></asp:DropDownList>--%>
        <asp:DropDownList ID="ddlDays" runat="server" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
        &nbsp; &nbsp;&nbsp;&nbsp; Time&nbsp;
        <asp:DropDownList ID="ddlHour" runat="server" ToolTip="24-hour format"></asp:DropDownList>
        &nbsp;<strong>:</strong>
        <asp:DropDownList ID="ddlMinute" runat="server"></asp:DropDownList>


        <%--<asp:TextBox ID="txtDate" runat="server" CssClass="date_text_box" ClientIDMode="Static"></asp:TextBox>--%>

    </span>
    &nbsp;
    <span class="img-close">
        <asp:ImageButton ID="imgClose" CssClass="link-img-close" CausesValidation="False"
            ImageUrl="~/Content/Icons/Close/cross_8x20_center.png" runat="server" OnClick="imgClose_Click" />
    </span>
    &nbsp;
    <asp:Label ID="lblError" runat="server" Text="Your selection is invalid" Visible="False" ForeColor="red"></asp:Label>

    <asp:HiddenField ID="hidParentId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRelativeId" runat="server" Value="1" />
    <asp:HiddenField ID="hidAbsoluteId" runat="server" Value="1" />
    <asp:HiddenField ID="hidType" runat="server" Value="" />
    <asp:HiddenField ID="hidInitialDate" runat="server" Value="" />
    <asp:HiddenField ID="hidDateRestrictionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRestrictionId" runat="server" Value="0" />


    <asp:HiddenField ID="hidLoadOnAutoPostBack" runat="server" Value="True" />
    <asp:HiddenField ID="hidShowFromUntilOption" runat="server" Value="True" />
    <asp:HiddenField ID="hidShowRemoveButton" runat="server" Value="True" />

    <asp:HiddenField ID="hidPastYear" runat="server" Value="-10" />
    <asp:HiddenField ID="hidComingYear" runat="server" Value="5" />

    <asp:HiddenField runat="server" ID="hidMonthDisplayMode" Value="short" />
    <%--  <script type="text/javascript">
        $('[class*=date_text_box]').unbind();
        $('[class*=date_text_box]').datepicker();
    </script>--%>

    <%--<script type="text/javascript">
        $('txtDate').unbind();
        $('txtDate').datepicker();
    </script>--%>
</div>
