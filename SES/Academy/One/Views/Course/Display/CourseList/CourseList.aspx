<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="CourseList.aspx.cs" Inherits="One.Views.Course.Display.CourseList.CourseList" %>

<%@ Register Src="~/ViewsSite/DashBoard/Student/CourseOverView/LstUc.ascx" TagPrefix="uc1" TagName="LstUc" %>


<asp:Content runat="server" ID="content2" ContentPlaceHolderID="BodyInnerLeft">
    <ul>
        <li>
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Views/Course/CourseEntryForm.aspx" runat="server">Create Course</asp:HyperLink>
        </li>
        <li>
            <asp:HyperLink ID="HyperLink2" NavigateUrl="~/Views/Course/Category/List.aspx"  runat="server">Category</asp:HyperLink>            
        </li>
        <li>
            <asp:HyperLink ID="HyperLink3" NavigateUrl="#"  runat="server">Group</asp:HyperLink>            
        </li>
    </ul>
</asp:Content>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    
     <div>
        <asp:Panel ID="Panel1" runat="server">
            <strong>Course List</strong>
            <div style="float: right;">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">New Category</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">New Course</asp:LinkButton>
            </div>
            <div style="float: right;">
            </div>
            <div style="float: right; width: 100%">
                <hr />
            </div>
        </asp:Panel>
        

    </div>
    <uc1:LstUc runat="server" ID="LstUc" />
</asp:Content>
