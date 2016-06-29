<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="ListSubjectGroup.aspx.cs" Inherits="One.Views.Course.ListingMain.CourseMain.ListSubjectGroup" %>

<%@ Register Src="~/Views/Course/ListingMain/CourseMain/ListUc.ascx" TagPrefix="uc1" TagName="ListUc" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div>
        <div style="float: right;">
            <%--<asp:HyperLink ID="HyperLink1" NavigateUrl="~/Views/Course/CourseEntryForm.aspx" runat="server">Create Course</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" NavigateUrl="~/Views/Course/Category/List.aspx"  runat="server">Category</asp:HyperLink>
            <asp:HyperLink ID="HyperLink3" NavigateUrl="~/Views/Course/Category/List.aspx"  runat="server">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png"/>
                New Group
            </asp:HyperLink>--%>
            
            <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">New Category</asp:LinkButton>--%>
           <%-- &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" >New Course</asp:LinkButton>--%>
        </div>
    </div>
    <div style="clear: both;"></div>
    <div>
        <uc1:ListUc runat="server" ID="ListUc" />
    </div>
</asp:Content>
