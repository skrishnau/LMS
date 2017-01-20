<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="One.Views.Office.School.View" %>

<%--<%@ MasterType virtualpath="~/ViewsSite/User/UserMaster.Master" %>--%>



<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">
        <asp:Label ID="lblSchoolName" runat="server" Text="School Profile"></asp:Label>
    </h3>
    <hr />
    <div class="heading-menu">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="Create.aspx">Edit</asp:HyperLink>

    </div>
    <br />
    <div class="detail-view">
        <table>
            <tr>
                <td class="data-type">Name</td>
                <td class="data-place">
                    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="data-type">School type</td>
                <td class="data-place">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td class="data-type">Phone No.</td>
                <td class="data-place">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td class="data-type">Email</td>
                <td class="data-place">
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td class="data-type">Website</td>
                <td class="data-place">
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td class="data-type">Country</td>
                <td class="data-place">
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td class="data-type">City</td>
                <td class="data-place">
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td class="data-type">Street</td>
                <td class="data-place">
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    
                </td>
            </tr>
           
        </table>
    </div>
   
    <div class=""></div>
</asp:Content>


