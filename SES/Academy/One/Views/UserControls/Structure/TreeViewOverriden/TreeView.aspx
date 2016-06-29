<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="TreeView.aspx.cs" Inherits="One.Views.UserControls.Structure.TreeViewOverriden.TreeView" %>

<%@ Register Src="~/Views/UserControls/Structure/TreeViewOverriden/TreeViewUc.ascx" TagPrefix="uc1" TagName="TreeViewUc" %>


<asp:Content runat="server" ID="headContent" ContentPlaceHolderID="head">
    <script type="text/javascript">
        function fireCheckChanged(e) {
            var evnt = ((window.event) ? (event) : (e));
            var element = evnt.srcElement || evnt.target;

            if (element.tagName == "INPUT" && element.type == "checkbox") {
                __doPostBack("", "");
            }
        }
</script>
</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <uc1:TreeViewUc runat="server" id="TreeViewUc" />
</asp:Content>
