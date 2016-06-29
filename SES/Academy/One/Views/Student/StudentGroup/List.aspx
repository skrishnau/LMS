<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="One.Views.Student.StudentGroup.List" %>

<asp:Content runat="server" ID="leftContent" ContentPlaceHolderID="BodyInnerLeft">
    <ul>
        <li>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Views/Student/Create/Student.aspx">Create Student</asp:HyperLink>
        </li>
         <li>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Views/Student/Create/StudentGroup.aspx">Create Group</asp:HyperLink>
        </li>
         <li>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Views/Student/Create/Student.aspx">Create Student</asp:HyperLink>
        </li>
    </ul>
</asp:Content>

<asp:Content runat="server" id="cntent1" ContentPlaceHolderID="Body">
    <div>
        List of Group
    </div>
</asp:Content>
