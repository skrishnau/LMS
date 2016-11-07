<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateRestrictionUC.ascx.cs" Inherits="One.Views.RestrictionAccess.DateRestrictionUC" %>

<div class="restriction-uc-whole">
    <%--<asp:ImageButton ID="imgVisibility" ImageUrl="~/Content/Icons/Visibility/eye_16x20_visible.png" runat="server" />    
    --%>&nbsp;
    <span>Date&nbsp; 
    <asp:DropDownList ID="ddlFromUntil" runat="server" Height="20px" Width="70px">
        <Items>
            <asp:ListItem Value="0" Text="from"></asp:ListItem>
            <asp:ListItem Value="1" Text="until"></asp:ListItem>
        </Items>
    </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <%--OnSelectedIndexChanged="ddlYear_SelectedIndexChanged" AutoPostBack="True" --%>
        <asp:DropDownList ID="ddlYear" runat="server" ></asp:DropDownList>
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
     <asp:ImageButton ID="imgClose" CssClass="img-close" CausesValidation="False"
         ImageUrl="~/Content/Icons/Close/cross_8x20_center.png" runat="server" OnClick="imgClose_Click" />
    &nbsp;
    <asp:Label ID="lblError" runat="server" Text="Your selection is invalid" Visible="False" ForeColor="red"></asp:Label>

    <asp:HiddenField ID="hidParentId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRelativeId" runat="server" Value="1" />
    <asp:HiddenField ID="hidAbsoluteId" runat="server" Value="1" />
    <asp:HiddenField ID="hidType" runat="server" Value="" />
    <asp:HiddenField ID="hidInitialDate" runat="server" Value="" />
    <asp:HiddenField ID="hidDateRestrictionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRestrictionId" runat="server" Value="0" />
    
  <%--  <script type="text/javascript">
        $('[class*=date_text_box]').unbind();
        $('[class*=date_text_box]').datepicker();
    </script>--%>
    
    <%--<script type="text/javascript">
        $('txtDate').unbind();
        $('txtDate').datepicker();
    </script>--%>

</div>
