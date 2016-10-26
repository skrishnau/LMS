<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="AssignmentView.aspx.cs" Inherits="One.Views.ActivityResource.Assignments.AssignmentView" %>

<asp:Content runat="server" ID="bodyid" ContentPlaceHolderID="Body">
    
    <div>
        <h3 class="heading-of-listing">
            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
        </h3>
    </div>
    <div>
            <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
    </div>

    <asp:HiddenField ID="hidAssignmentId" runat="server" Value="0"/>
</asp:Content>
