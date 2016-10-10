<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ForumView.aspx.cs" Inherits="One.Views.ActivityResource.Forum.ForumView" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3>
        <asp:Label ID="lblForumName" runat="server" Text=""></asp:Label>
    </h3>
    <div style="margin-left: 20px;">
        <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
    </div>
    <br />




    <%-- ====================Body==================== --%>
    <div>
        <asp:Button ID="btnAddNewDiscussionTopic" runat="server" Text="Add new discussion topic" OnClick="btnAddNewDiscussionTopic_Click" />
    </div>

    <br/>
    <div>

        <asp:ListView ID="listViewDiscussions" runat="server">
            <LayoutTemplate>
                <table runat="server" id="table1" width="100%">
                    <thead>
                        <tr style="text-align: left;">
                            <th>Discussion topic</th>
                            <th>Started by</th>
                            <th>Replies</th>
                            <th>Last post</th>
                        </tr>
                    </thead>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
            </LayoutTemplate>

            <ItemTemplate>
                <tr>
                    <td>
                        <a id='<%# "section_"+Eval("Id") %>'></a>
                        <asp:HyperLink ID="Label1" runat="server" Text='<%# Eval("Subject") %>'
                            NavigateUrl='<%# "~/Views/ActivityResource/Forum/DiscussionView.aspx?disId="+Eval("Id")
                            +"&SubId="+SubjectId+"&secId="+SectionId
                        %>'></asp:HyperLink>
                    </td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text='<%# GetUser(Eval("PostedBy")) %>'></asp:Label>
                    </td>
                    <td></td>
                    <td></td>
                </tr>
            </ItemTemplate>

            <EmptyDataTemplate>
                <div style="text-align: center; color: crimson;">
                    No discussions in this forum
                </div>
            </EmptyDataTemplate>
        </asp:ListView>

    </div>




    <asp:HiddenField ID="hidForumId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidPageKey" runat="server" Value="0" />

</asp:Content>
