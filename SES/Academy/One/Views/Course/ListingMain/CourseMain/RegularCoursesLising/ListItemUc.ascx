<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListItemUc.ascx.cs" Inherits="One.Views.Course.ListingMain.CourseMain.RegularCoursesLising.ListItemUc" %>


<div class="item">
    <div class="item-heading">
        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
        <div style="font-size: 0.6px; margin: 2px 20px 2px;">
            <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
        </div>
    </div>
    <div class="item-summary">
        Number of Sections: &nbsp;<asp:Literal ID="lblSectionCount" runat="server"></asp:Literal>
    </div>
</div>