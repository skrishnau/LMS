<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="MyClasses.aspx.cs" Inherits="One.Views.Class.MyClasses" %>


<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="content" ContentPlaceHolderID="Body">
    <%-- data-entry-section-heading --%>
    <h3 class="heading-of-create-edit">My Classes
        <hr />
    </h3>

    <h3 class="heading-of-create-edit">

        <asp:Label ID="lblSubjectName" runat="server" Text=""></asp:Label>
    </h3>

    <br />


    <asp:DataList ID="DataList1" runat="server" Width="100%" CssClass="list-group">
        <ItemTemplate>

            <%--<div class="list-item-datalist">--%>
            <asp:HyperLink runat="server" ID="hlink1" CssClass="list-group-item"
                NavigateUrl='<%# "~/Views/Class/CourseClassDetail.aspx?ccId="+Eval("ClassId")+"&from=myClasses" %>'>
                <asp:Label ID="Label1" runat="server"
                    Text='<%# Eval("ClassName") %>'></asp:Label>
                <%-- style="margin: 1px 5px 2px 20px;" --%>
                <div class="list-item-description" >
                    Start Date:
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("StartDate") %>'></asp:Label>
                    &nbsp;&nbsp;|&nbsp;&nbsp;
                    End Date :
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("EndDate") %>'></asp:Label>
                </div>

            </asp:HyperLink>

            <%--</div>--%>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="head">
    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />

</asp:Content>
