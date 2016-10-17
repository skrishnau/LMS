<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="One.Views.Office.Default" %>


<%--<%@ MasterType virtualpath="~/ViewsSite/User/UserMaster.Master" %>--%>

<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    School Info
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">
        School Info
        <%--<asp:Label ID="lblSchoolName" runat="server" Text="School Profile"></asp:Label>--%>
    </h3>
    <hr />
    <asp:Panel CssClass="heading-menu" runat="server" ID="divMenu">
    </asp:Panel>
    <br />
    <div class="detail-view">
        <table>
            <tr>
                <td class="data-type">School Name</td>
                <td class="data-place">
                    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="data-type">School type</td>
                <td class="data-place">
                    <asp:Label ID="lblSchoolType" runat="server" Text="Label"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td class="data-type">Phone No.</td>
                <td class="data-place">
                    <asp:Label ID="lblPhoneNo" runat="server" Text="Label"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td class="data-type">School mail Id</td>
                <td class="data-place">
                    <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td class="data-type">Current Website</td>
                <td class="data-place">
                    <asp:Label ID="lblWebsite" runat="server" Text="Label"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td class="data-type">Country</td>
                <td class="data-place">
                    <asp:Label ID="lblCountry" runat="server" Text="Label"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td class="data-type">City</td>
                <td class="data-place">
                    <asp:Label ID="lblCity" runat="server" Text="Label"></asp:Label>
                    
                </td>
            </tr>
           <%-- <tr>
                <td class="data-type">Street</td>
                <td class="data-place">
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                    
                </td>
            </tr>--%>
           
        </table>
    </div>
   
    <div class=""></div>
</asp:Content>



