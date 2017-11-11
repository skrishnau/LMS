<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActResChooseUc.ascx.cs" Inherits="One.Views.Course.ActivityAndResource.ActResChoose.ActResChooseUc" %>

<div class="panel panel-default">
    <div class="panel-heading">
        Activities
    </div>
    <%--<div class="panel-body">--%>
    <asp:DataList ID="dlistActivities" ClientIDMode="Static" runat="server" Width="100%"
        OnItemCommand="dlistActivities_ItemCommand"
        CssClass="list-group">
        <ItemTemplate>
            <%-- block --%>
            <%--  NavigateUrl='<%# GetUrl(Eval("Url")) %>' --%>
            <%--  block link --%>
            <asp:LinkButton ID="activityLink" CssClass="list-group-item" runat="server" 
                style="border: 1px solid lightgray; margin-top: -1px;"
                CommandName="Click" CommandArgument='<%# Eval("CreateUrl") %>'>

                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("IconPath") %>' Width="26px" Height="26px" />
                &nbsp;
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>'></asp:Label>

            </asp:LinkButton>


        </ItemTemplate>
    </asp:DataList>

    <%--</div>--%>
</div>

<div class="panel panel-default">
    <div class="panel-heading">
        Resources
    </div>
    <%--<div class="panel-body">--%>
    <asp:DataList ID="dlistResources" runat="server"
        Width="100%"
        OnItemCommand="dlistResources_ItemCommand" CssClass="list-group">
        <ItemTemplate>
            <%-- <asp:Label runat="server" ID="NameL" Text='<%# Eval("Name") %>' />
            <asp:Label ID="ImagePathLabel" runat="server" Text='<%# Eval("ImagePath") %>' />
            <br />--%>
            <%-- CssClass="block link" --%>
            <asp:LinkButton ID="activityLink" CssClass="list-group-item" runat="server" 
                style="border: 1px solid lightgray; margin-top: -1px;"
                CommandName="Click" CommandArgument='<%# Eval("CreateUrl") %>'>
                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("IconPath") %>' Width="26px" Height="26px" />
                &nbsp;
                <asp:Label ID="Label11" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
            </asp:LinkButton>
        </ItemTemplate>
    </asp:DataList>
    <%--</div>--%>
</div>
<%--<strong>Activities</strong>
<div style="margin: 0 25px 0;" id="outer-mid-div">
</div>

<strong>Resources</strong>
<div style="margin: 0 25px 0;">
</div>--%>


<%--<asp:ObjectDataSource ID="ActivitiesDs" runat="server" SelectMethod="GetActivities" TypeName="One.Values.Enums"></asp:ObjectDataSource>--%>
<%--<asp:ObjectDataSource ID="ResourcesDs" runat="server" SelectMethod="GetResources" TypeName="One.Values.Enums"></asp:ObjectDataSource>--%>


<asp:HiddenField ID="hidSubId" runat="server" Value="0" />
<asp:HiddenField ID="hidSecId" runat="server" Value="0" />
