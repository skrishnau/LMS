<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActivityAndResourceUc.ascx.cs" Inherits="One.Views.Course.Section.ActivityAndResourceUc" %>

<div class="course-act-res-whole">
    <div class="course-act-res-heading">
        <asp:Image ID="imgIcon" runat="server" ImageUrl="" AlternateText="" />
        
                 <asp:HyperLink ID="lblTitle" CssClass="course-act-res-title" runat="server" Text="Heading">
                 </asp:HyperLink>
        &nbsp;&nbsp;&nbsp;
        <asp:ImageButton ID="imgEditBtn" runat="server" Visible="False"
                    ImageUrl="~/Content/Icons/Edit/edit_orange.png" OnClick="imgEditBtn_Click"  />
       
    </div>

    <div class="course-act-res-body">
        <asp:Label ID="lblSummary" runat="server" Text=""></asp:Label>
    </div>

    <%--<div class="item-message">
            <asp:PlaceHolder ID="pnlMessages" runat="server"></asp:PlaceHolder>
        </div>--%>
    <%-- True- activity, False- resource --%>
    <asp:HiddenField ID="hidActOrRes" runat="server" Value="True" />

    <asp:HiddenField ID="hid" runat="server" Value="0" />
    <asp:HiddenField ID="hidActOrResId" runat="server" Value="0" />
    <asp:HiddenField ID="hidType" runat="server" Value="0" />

</div>
