<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GradeRestrictionUC.ascx.cs" Inherits="One.Views.RestrictionAccess.GradeRestrictionUC" %>


<div class="restriction-uc-whole">
    <%--<asp:ImageButton ID="imgVisibility" ImageUrl="~/Content/Icons/Visibility/eye_16x20_visible.png" runat="server" />--%>
    <%--&nbsp;--%>
    <span>Grade&nbsp;
    <asp:DropDownList ID="ddlActivityChoose" runat="server" Height="22px" Width="216px"
        ToolTip="Please be sure that target students have access to the selected Activity" 
        DataSourceID="dataSourceActivities"
        DataTextField="Name"
        DataValueField="Id">
    </asp:DropDownList>
        &nbsp;
    <asp:CheckBox ID="chkGreaterThanOrEqualTo" runat="server" Text="must be ≥" AutoPostBack="True" OnCheckedChanged="chkGreaterThanOrEqualTo_CheckedChanged" />
        &nbsp;
    <asp:TextBox ID="txtGreaterThanOrEqualTo" runat="server" Width="63px" Enabled="False"></asp:TextBox>
        %
    &nbsp;&nbsp;
    <asp:CheckBox ID="chkLessThan" runat="server" Text="must be <" AutoPostBack="True" OnCheckedChanged="chkLessThan_CheckedChanged" />
        &nbsp;
    
    <asp:TextBox ID="txtLessThan" runat="server" Width="63px" Enabled="False"></asp:TextBox>
        %
    
    </span>
    &nbsp;
     <span class="img-close">
         <asp:ImageButton ID="imgClose" CssClass="link-img-close" CausesValidation="False"
             ImageUrl="~/Content/Icons/Close/cross_8x20_center.png" runat="server" OnClick="imgClose_Click" />
     </span>
    &nbsp;
    <asp:Label ID="lblError" runat="server" Text="Error in selection" 
        Visible="False"
        ForeColor="red"></asp:Label>
    <asp:ObjectDataSource ID="dataSourceActivities" runat="server" SelectMethod="ListActivitiesOfCourse" TypeName="Academic.DbHelper.DbHelper+ActAndRes"  >
        <SelectParameters>
            <asp:ControlParameter ControlID="hidSubjectId" DefaultValue="0" Name="courseId" PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:HiddenField ID="hidParentId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRelativeId" runat="server" Value="1" />
    <asp:HiddenField ID="hidAbsoluteId" runat="server" Value="1" />
    <asp:HiddenField ID="hidType" runat="server" Value="" />

    <asp:HiddenField ID="hidGradeRestrictionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRestrictionId" runat="server" Value="0" />

    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />

</div>
