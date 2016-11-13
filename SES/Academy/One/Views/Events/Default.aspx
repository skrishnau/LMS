<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="One.Views.Events.Default" %>

<asp:Content runat="server" ID="content" ContentPlaceHolderID="Body">

    <div>
        <h3 class="heading-of-listing">Event list</h3>
        <hr />
        <div style="text-align: right;">
            <asp:HyperLink ID="lnkAddEvent" runat="server"
                NavigateUrl="~/Views/Events/EventCreate.aspx"
                CssClass="link_smaller" Visible="False">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                New event
            </asp:HyperLink>
        </div>
        <div class="data-entry-section-body">
            <asp:DataList ID="DataList1" runat="server" Width="99%">
                <ItemTemplate>
                    <div style="font-weight: 700;" class="auto-st2">
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="link"
                            NavigateUrl='<%# "~/Views/Events/EventDetail.aspx?eId="+Eval("Id") %>'>
                            <asp:Image runat="server" ID="imgPrivate" ImageUrl='<%# GetImageUrl(Eval("PostToPublic")) %>' />
                            &nbsp;
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Title") %>'></asp:Label>
                        </asp:HyperLink>

                        <div style="font-style: italic; margin-left: 20px; font-weight: 400;">
                            <table>
                                <tr>
                                    <td>Location </td>
                                    <td>:&nbsp;&nbsp;
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Location") %>'></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Last Update</td>
                                    <td>:&nbsp;&nbsp;
                                        <asp:Label ID="Label2" runat="server" Text='<%# GetDate(Eval("Date")) %>'></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    Event List
</asp:Content>
