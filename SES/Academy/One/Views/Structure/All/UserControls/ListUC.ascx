<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.ListUC" %>

<div runat="server" id="panel" style="margin: 3px 10px 10px 3px; min-height: 30px; padding: 5px 5px 5px 5px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:LinkButton ID="lnkName" runat="server" OnClick="lnkName_OnClick" CssClass="link">
                        <%--<span style="line-height: 30px; padding-top: 5px; vertical-align: central; margin-top: 5px;">--%>
                        <asp:Image ID="imgShowHide" runat="server" ImageUrl="~/Content/Icons/Sort/sort-right-14px.png" />
                        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                        <%--</span>--%>
                    </asp:LinkButton>
                    <%--  class="list-item-option" --%>
                    <span class="span-edit-delete">
                        <asp:HyperLink ID="lnkEdit" runat="server" CssClass="edit-button">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
                        </asp:HyperLink>
                        <asp:HyperLink ID="lnkDelete" Visible="False" CssClass="delete-button" runat="server" OnClick="lnkEdit_Click">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/delete/trash.png" />
                        </asp:HyperLink>
                    </span>
                </div>
                <%--<asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>--%>
                <asp:HiddenField ID="hidStructureId" Value="0" runat="server" />
                <asp:HiddenField ID="hidStructureType" Value="0" runat="server" />
                <%-- aliceblue --%>
                <%--background-color: #e6e6ff;--%>
                <div style="margin-left: 25px; border-left: solid lightgray 1px;">
                    <asp:Panel runat="server" ID="pnlHiddenLayer" Visible="False">
                        <asp:PlaceHolder ID="pnlSubControls" runat="server" Visible="True"></asp:PlaceHolder>
                        <div>
                            <%-- CssClass="link-button" --%>
                            <asp:HyperLink ID="lnkAdd" runat="server" Visible="False" CssClass="btn btn-default">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                                <asp:Literal ID="lblAddText" runat="server" Text=""></asp:Literal>
                            </asp:HyperLink>
                        </div>
                    </asp:Panel>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- <script>
        document.getElementById('pnlSubControls').addEventListener('click', function () {
            toggle(document.querySelectorAll('.target'));
        });
        function toggle(var)
    </script>--%>
</div>
<%-- style=" height: 1px; background-color: lightgray; border: none;" --%>
<%--<hr  />--%>
