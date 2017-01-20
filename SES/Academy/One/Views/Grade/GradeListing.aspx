<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="GradeListing.aspx.cs" Inherits="One.Views.Grade.GradeListing" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="bodyId" ContentPlaceHolderID="Body">
    <div>
        <h3 class="heading-of-listing">Grade List
        </h3>
        <hr />

        <div style="text-align: right;">
            <asp:HyperLink ID="lnkEdit" runat="server">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
                <asp:Label ID="lblEdit" runat="server" Text="Edit"></asp:Label>
            </asp:HyperLink>
        </div>

        <div style="text-align: left;">
            <asp:HyperLink ID="lnkAddGrade" runat="server" Visible="False" CssClass="link_smaller"
                NavigateUrl="~/Views/Grade/GradeCreate.aspx">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                New Grade Type
            </asp:HyperLink>
        </div>
        <br />
        <%--<div class="data-entry-section-body">--%>
        <asp:DataList ID="DataList1" runat="server" Width="98%">
            <ItemTemplate>
                <div class="auto-st2" style="padding: 10px;">
                    ● 
                        <asp:HyperLink ID="Label1" CssClass="link" runat="server" Text='<%#  Eval("Name") %>'
                            Font-Bold="True"
                            NavigateUrl='<%# "~/Views/Grade/GradeDetail.aspx?gId="+Eval("Id") %>'>
                        </asp:HyperLink>
                    &nbsp;
                    <asp:HyperLink ID="lnkEdit" runat="server" Visible='<%# Edit && IsEditable(Eval("SchoolId")) %>'
                        NavigateUrl='<%# Edit?("~/Views/Grade/GradeCreate.aspx?gId="+Eval("Id")):"" %>'>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
                    </asp:HyperLink>
                    &nbsp;
                    
                    <asp:HyperLink ID="lnkDelete" runat="server" Visible='<%# Edit && IsEditable(Eval("SchoolId")) %>'
                        NavigateUrl='<%# Edit?("~/Views/All_Resusable_Codes/Delete/DeleteForm.aspx?task="+hidTask.Value+" &grdId="+Eval("Id")):"" %>'>
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Content/Icons/delete/remove_icon_color.png" />
                    </asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <%--</div>--%>
        <asp:HiddenField ID="hidEdit" runat="server" Value="False" />
        <asp:HiddenField ID="hidTask" runat="server" Value="grd" />

    </div>
</asp:Content>

<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    Grade List
</asp:Content>
