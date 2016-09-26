<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="BookView.aspx.cs" Inherits="One.Views.ActivityResource.Book.BookView" %>

<asp:Content runat="server" ID="headcontent" ContentPlaceHolderID="head">
    <style type="text/css">
        .mid-back {
            vertical-align: central;
            width: 1px;
            background-color: lightgray;
            /*background-image: url('~/Content/Icons/Hide/hide-menu-left.png');
            background-repeat: repeat;*/
        }
    </style>
</asp:Content>

<asp:Content runat="server" ID="contnet1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">
        <asp:Label ID="lblBookName" runat="server" Text=""></asp:Label>
    </h3>
    <div id="edit-section" style="text-align: right;">
        <asp:HyperLink ID="lnkEdit"
            runat="server">
            <asp:Image ID="ImageButton1" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
            <asp:Literal ID="lblEdit" runat="server"></asp:Literal>
        </asp:HyperLink>

    </div>

    <div class="data-entry-section-body">
        <asp:Label ID="lblBookDescription" runat="server" Text=""></asp:Label>
    </div>
    <br />
    <div style="height: 90%;">
        <div style="text-align: left;">
                        <asp:HyperLink ID="lnkBackToCourse" runat="server">Back to course</asp:HyperLink>
                    </div>
        <table style="width: 100%; position: relative; bottom: 0px;">
            <tr>
                <td id="toc_cell" runat="server"
                    style="vertical-align: top; max-height: 100%; width: 200px; overflow: scroll; border: 2px solid lightgray;">
                    
                    <div style="font-weight: 600; min-height: 30px;">
                        Table of Content
                    </div>
                    <div style="overflow: auto; height: 100%; width: 200px; min-height: 300px; margin-bottom: 20px; resize: horizontal;">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>

                                <asp:PlaceHolder ID="pnlToc" runat="server"></asp:PlaceHolder>

                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>

                </td>
                <td class="mid-back"></td>
                <td id="content_cell" runat="server"
                    style="vertical-align: top; text-align: left; overflow-y: scroll; min-height: 300px;">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <div style="text-align: right;">
                                <asp:ImageButton Enabled="False" ID="imgPrevTop" runat="server" ImageUrl="~/Content/Icons/Arrow/arrow_left.png" />
                                <asp:ImageButton Enabled="False" ID="imgNextTop" runat="server" ImageUrl="~/Content/Icons/Arrow/arrow_right.png" />
                            </div>
                            <div style="min-height: 300px; padding: 0 10px;">
                                <div style="font-weight: 700; font-size: 1.3em; text-align: center;">
                                    <asp:Label ID="lblChapterHeading" runat="server" Text=""></asp:Label>

                                </div>
                                <hr />
                                <div runat="server" id="edit_panel" visible="False" style="text-align: center; margin-top: -10px;" class="heading-menu">
                                    <asp:HyperLink ID="lnkChapterEdit" runat="server">Edit</asp:HyperLink>
                                    &nbsp;|&nbsp;
                                    <asp:HyperLink ID="lnkDelete" runat="server">Delete</asp:HyperLink>
                                </div>
                                <br />
                                <asp:Label ID="lblContent" runat="server" Text=""></asp:Label>
                            </div>
                            <div style="text-align: right;">
                                <asp:ImageButton Enabled="False" ID="imgprevBottom" runat="server" ImageUrl="~/Content/Icons/Arrow/arrow_left.png" />
                                <asp:ImageButton Enabled="False" ID="imgnextBottom" runat="server" ImageUrl="~/Content/Icons/Arrow/arrow_right.png" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hidBookId" runat="server" Value="0" />
    <asp:HiddenField ID="hidPageKey" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidEdit" runat="server" Value="0" />
</asp:Content>
