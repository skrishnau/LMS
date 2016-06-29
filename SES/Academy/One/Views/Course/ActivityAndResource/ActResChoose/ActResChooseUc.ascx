<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActResChooseUc.ascx.cs" Inherits="One.Views.Course.ActivityAndResource.ActResChoose.ActResChooseUc" %>

<div>
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0"/>
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0"/>
    <strong>Activities</strong>
    <div style="margin: 0 25px 0;">
          <asp:DataList ID="dlistActivities" runat="server" >
        <ItemTemplate>
            <%--<asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />--%>
            <asp:HyperLink ID="ImagePathLabel" runat="server" NavigateUrl='<%# GetUrl(Eval("Url")) %>' >
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ImagePath") %>' Width="22px" Height="22px"/>
                <%# Eval("Name") %>
            </asp:HyperLink>

            <br />
        </ItemTemplate>

    </asp:DataList>

        <%--<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/Course/ActivityAndResource/EntryUserConrols/AssignWF.aspx">Assignment</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server">Chat</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server">Forum</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink4" runat="server">Lession</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink5" runat="server">Wiki</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink6" runat="server">Workshop</asp:HyperLink>--%>
    </div>
    <%--<asp:ObjectDataSource ID="ActivitiesDs" runat="server" SelectMethod="GetActivities" TypeName="One.Values.Enums"></asp:ObjectDataSource>--%>

    <strong>Resources</strong>
    <div style="margin: 0 25px 0;">
        
        <asp:DataList ID="dlistResources" runat="server">
            <ItemTemplate>
                <asp:Label runat="server" ID="NameL" Text='<%# Eval("Name") %>' />
                <asp:Label ID="ImagePathLabel" runat="server" Text='<%# Eval("ImagePath") %>' />
                <br />
            </ItemTemplate>
        </asp:DataList>

    </div>
    <asp:ObjectDataSource ID="ResourcesDs" runat="server" SelectMethod="GetResources" TypeName="One.Values.Enums"></asp:ObjectDataSource>
</div>
