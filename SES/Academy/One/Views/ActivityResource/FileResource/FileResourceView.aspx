<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="FileResourceView.aspx.cs" Inherits="One.Views.ActivityResource.FileResource.FileResourceView" %>


<asp:Content runat="server" ID="bodycontent" ContentPlaceHolderID="Body">
    <div>
        <iframe runat="server" ClientIDMode="Static" ID="frame" 
            sandbox="allow-scripts,allow-same-origin"></iframe>
    </div>

    <asp:HiddenField ID="hidFileResourceId" runat="server" Value="0"/>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        #frame {
            width: 442px;
            height: 264px;
        }
    </style>
</asp:Content>

