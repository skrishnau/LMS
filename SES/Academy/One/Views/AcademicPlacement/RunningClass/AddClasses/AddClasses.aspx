<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="AddClasses.aspx.cs" Inherits="One.Views.AcademicPlacement.RunningClass.AddClasses.AddClasses" %>

<%@ Register Src="~/Views/AcademicPlacement/RunningClass/CheckBoxOnly/TreeViewUC.ascx" TagPrefix="uc1" TagName="TreeViewUC" %>



<asp:Content runat="server" ID="script1" ContentPlaceHolderID="Body">
    <uc1:TreeViewUC runat="server" ID="TreeViewUC1" />
</asp:Content>
