<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EachDiscussionUc.ascx.cs" Inherits="One.Views.ActivityResource.Forum.EachDiscussionUc" %>

<div style="border: 1px solid lightgray; border-left: 3px solid lightblue; margin: 6px 0;">
    <table>
        <tr>
            <td>
                <asp:Image ID="imgImage" runat="server" Width="40" Height="40" ImageUrl="~/Content/Icons/Users/40x40/single.png" />
            </td>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="lblSubject" runat="server" Text="" Font-Bold="True"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="font-size: 0.9em; color: darkgray; ">
                                by 
                                <asp:Label ID="lblPostedBy" runat="server" Text=""></asp:Label>
                                -
                                <asp:Label ID="lblDateTime" runat="server" Text="" Font-Italic="True" Font-Size="0.9em"></asp:Label>
                            </div>
                        </td>

                    </tr>
                    <tr></tr>

                </table>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <div style="padding-bottom: 5px;">
                    <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                </div>
            </td>
        </tr>
    </table>
    <div style="text-align: right; font-family: tahoma, serif, sans-serif, arial; font-size: 0.8em; margin: 0 6px 6px 0;">
        <asp:HyperLink ID="lnkEdit" runat="server">Edit</asp:HyperLink>
        <asp:Literal ID="lblEditAfter" runat="server">
             &nbsp;| &nbsp;
        </asp:Literal>

        <asp:HyperLink ID="lnkDelete" runat="server">Delete</asp:HyperLink>
        <asp:Literal ID="lblDeleteAfter" runat="server">
             &nbsp;| &nbsp;
        </asp:Literal>
        <asp:HyperLink ID="lnkReply" runat="server">Reply</asp:HyperLink>
       

    </div>
</div>

<div style="margin-left: 20px;">
    <asp:Panel ID="pnlReplies" runat="server"></asp:Panel>
</div>
