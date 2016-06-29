<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentEntr.ascx.cs" Inherits="One.Views.Student.Batch.StudentEntries.StudentEntr" %>
<%@ Register Src="~/Views/Student/Batch/StudentEntries/StudentGroupAssignUC.ascx" TagPrefix="uc1" TagName="StudentGroupAssignUC" %>
<%@ Register Src="~/Views/Student/Create/StudentCreateUc.ascx" TagPrefix="uc1" TagName="StudentCreateUc" %>




<style type="text/css">
    .auto-style1 {
        height: 8px;
        font-size: 1em;
    }
</style>


<div style="margin-left: 30px; margin-bottom: 10px; width: 474px; background-color: lightgray;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="float: left; padding: 2px 10px 10px; background-color: lightgray; width: 700px;">
                <div style="float: right;">
                    <%-- OnClick="btnClose_Click"  class="float-right width-auto"--%>
                    <asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/Content/Icons/Close/dialog_close.png" OnClick="btnClose_Click" Style="width: 16px" CausesValidation="False" />
                    <asp:ImageButton ID="btnCloseDialog" ImageUrl="~/Content/Icons/Close/dialog_close.png" runat="server" OnClick="btnCloseDialog_Click" />
                </div>
                <div style="float: left;">
                    <asp:ImageButton ID="btnGroup" runat="server" ToolTip="Student Group Entry" BorderStyle="Solid" BorderWidth="4px" Height="20px" ImageUrl="~/Content/Icons/Users/40x40/group.png" Width="20px" OnClick="btnGroup_Click" BorderColor="#6600FF" CausesValidation="False" />
                    &nbsp;&nbsp;&nbsp;&nbsp; 
                            <asp:ImageButton ID="btnSingle" runat="server" ToolTip="Single Student Entry" BorderStyle="None" BorderColor="#669900" BorderWidth="1px" Height="20px" ImageUrl="~/Content/Icons/Users/40x40/single.png" Width="20px" OnClick="btnSingle_Click" Enabled="False" CausesValidation="False" />
                </div>
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <uc1:StudentGroupAssignUC runat="server" ID="StudentGroupAssignUC" />
                    </asp:View>

                    <asp:View ID="View2" runat="server">
                        <uc1:StudentCreateUc runat="server" ID="StudentCreateUc" />
                    </asp:View>
                </asp:MultiView>




            </div>
            <div style="clear: both;"></div>
            <div>
                <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
                <asp:HiddenField ID="hidAcademicYear" runat="server" Value="0" />
                <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />

                <asp:HiddenField ID="hidYearId" runat="server" Value="0" />
                <asp:HiddenField ID="hidSubYearId" runat="server" Value="0" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
