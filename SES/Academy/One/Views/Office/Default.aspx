<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="One.Views.Office.Default" %>


<%--<%@ MasterType virtualpath="~/ViewsSite/User/UserMaster.Master" %>--%>

<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    School Info
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">College Info
        <%--<asp:Label ID="lblSchoolName" runat="server" Text="School Profile"></asp:Label>--%>
    </h3>
    <hr />
    <br />
    <asp:Panel CssClass="heading-menu" runat="server" ID="divMenu">
    </asp:Panel>
    <h3 class="heading-of-display">
        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>

    </h3>
    <div class="data-entry-section-body">
        <table>
            <%--<tr>
                <td class="data-type">College Name</td>
                <td class="data-place">
                </td>
            </tr>--%>
            <tr runat="server" id="one1" visible="False">
                <td class="data-type">College type</td>
                <td class="data-place">
                    <asp:Label ID="lblSchoolType" runat="server" Text="Label"></asp:Label>

                </td>
            </tr>
            <tr>
                <td class="data-type">Phone No.</td>
                <td class="data-place">
                    <asp:Label ID="lblPhoneNo" runat="server" Text="N/A"></asp:Label>

                </td>
            </tr>
            <tr>
                <td class="data-type">Mail Id</td>
                <td class="data-place">
                    <asp:Label ID="lblEmail" runat="server" Text="N/A"></asp:Label>

                </td>
            </tr>
            <tr>
                <td class="data-type">Current Website</td>
                <td class="data-place">
                    <asp:Label ID="lblWebsite" runat="server" Text="N/A"></asp:Label>

                </td>
            </tr>
            <tr runat="server" id="two3" visible="False">
                <td class="data-type">Country</td>
                <td class="data-place">
                    <asp:Label ID="lblCountry" runat="server" Text="N/A"></asp:Label>

                </td>
            </tr>
            <tr>
                <td class="data-type">City</td>
                <td class="data-place">
                    <asp:Label ID="lblCity" runat="server" Text="N/A"></asp:Label>

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



