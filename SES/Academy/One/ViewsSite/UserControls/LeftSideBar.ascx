<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LeftSideBar.ascx.cs" Inherits="One.ViewsSite.UserControls.LeftSideBar" %>
<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

            <asp:TreeView ID="TreeView1" runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged"  ViewStateMode="Enabled">
                <%-- OnTreeNodeExpanded="TreeView1_TreeNodeExpanded" --%>
               
            </asp:TreeView>

        </ContentTemplate>

    </asp:UpdatePanel>
</div>
