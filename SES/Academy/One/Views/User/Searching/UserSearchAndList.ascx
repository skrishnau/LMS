<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserSearchAndList.ascx.cs" Inherits="One.Views.User.Searching.UserSearchAndList" %>

<style type="text/css">
    .table-cell {
        width: 120px;
    }
</style>

<div style="margin: 10px; padding: 10px;">
    <strong style="font-size: 1.3em">Users</strong>

    <div style="margin: 10px;">
        <asp:LinkButton ID="btnFilterShow" runat="server" Font-Size="1.1em"
            Font-Underline="False" OnClick="btnFilterShow_Click">
            <asp:ImageButton ID="ImageButton1" runat="server" />
            Filter
        </asp:LinkButton>
        <hr />

        <div class="filter">
            <asp:Panel ID="pnlFilter" runat="server">
                <table>
                    <tr>
                        <td class="table-cell">User Full Name </td>
                        <td>
                            <asp:DropDownList ID="ddlFullName" runat="server" Height="22px" Width="145px">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Height="22px" Width="140px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="pnlMoreFilter" runat="server" Visible="True">
                </asp:Panel>
                <div>
                    <asp:LinkButton ID="btnShow" runat="server" OnClick="btnShow_Click">Show More</asp:LinkButton>
                </div>
                <br />
                <span style="margin: 10px;">
                    <asp:Button ID="btnSearch" runat="server" Text="Search" Width="78px" OnClick="btnSearch_Click" Style="height: 26px" />
                </span>

            </asp:Panel>

        </div>

        <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />


        <%-- =========================================================================== --%>
        <div class="listing" style="margin: 10px;">
            <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id">

                <AlternatingItemTemplate>
                    <tr style="background-color: #FFFFFF; color: #284775;">

                        <td>
                            <%--<asp:Label ID="UserImageIdLabel" runat="server" Text='<%# Eval("UserImageId") %>' />--%>
                            <asp:HyperLink ID="HyperLink1" runat="server">
                                <asp:Image ID="Image1" runat="server"
                                    Height="20" Width="20"
                                    ImageUrl='<%#  GetImageUrl(DataBinder.Eval(Container.DataItem,"UserImageId")) %>' />
                            </asp:HyperLink>
                        </td>

                        <td>
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("Id") %>' />
                            <asp:Label ID="NameLabel" runat="server" Text='<%# GetName(Eval("FirstName"),Eval("MiddleName"),Eval("LastName")) %>' />
                        </td>


                        <%-- <td>
                        <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />
                    </td>--%>
                        <td>
                            <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                        </td>

                        <td>
                            <asp:Label ID="LastOnlieLabel" runat="server" Text='<%# GetLastOnline(DataBinder.Eval(Container.DataItem,"LastOnline"))  %>'></asp:Label>
                            <%--<asp:Label ID="LastOnlineLabel" runat="server" Text='<%# Eval("LastOnline") %>' />--%>
                        </td>
                    </tr>
                </AlternatingItemTemplate>

                <EmptyDataTemplate>
                    <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>

                <ItemTemplate>
                    <tr style="background-color: #E0FFFF; color: #333333;">
                        <td>
                            <%--<asp:Label ID="UserImageIdLabel" runat="server" Text='<%# Eval("UserImageId") %>' />--%>
                            <asp:HyperLink ID="HyperLink1" runat="server">
                                <asp:Image ID="Image1" runat="server"
                                    Height="20" Width="20"
                                    ImageUrl='<%#  GetImageUrl(DataBinder.Eval(Container.DataItem,"UserImageId")) %>' />
                            </asp:HyperLink>
                        </td>
                        <td>
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("Id") %>' />
                            <asp:Label ID="NameLabel" runat="server" Text='<%# GetName(Eval("FirstName"),Eval("MiddleName"),Eval("LastName")) %>' />
                        </td>

                        <td>
                            <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                        </td>

                        <td>
                            <asp:Label ID="LastOnlieLabel" runat="server" Text='<%# GetLastOnline(DataBinder.Eval(Container.DataItem,"LastOnline"))  %>'></asp:Label>
                            <%--<asp:Label ID="LastOnlineLabel" runat="server" Text='<%# Eval("LastOnline") %>' />--%>
                        </td>
                    </tr>
                </ItemTemplate>

                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table id="itemPlaceholderContainer" runat="server" style="background-color: #FFFFFF; border: none; border-collapse: collapse; border-width: 0px;">
                                    <%-- font-family: Arial, Helvetica, sans-serif, Verdana; --%>
                                    <tr runat="server" style="background-color: #E0FFFF; color: #333333;">
                                        <th runat="server"></th>
                                        <th runat="server">Name</th>
                                        <th runat="server">Email</th>
                                        <th runat="server">Last Online</th>
                                    </tr>
                                    <tr id="itemPlaceholder" runat="server">
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF"></td>
                        </tr>
                    </table>
                </LayoutTemplate>

                <SelectedItemTemplate>
                    <tr style="background-color: #E2DED6; font-weight: bold; color: #333333;">
                        <td>
                            <%--<asp:Label ID="UserImageIdLabel" runat="server" Text='<%# Eval("UserImageId") %>' />--%>
                            <asp:HyperLink ID="HyperLink1" runat="server">
                                <asp:Image ID="Image1" runat="server"
                                    Height="20" Width="20"
                                    ImageUrl='<%#  GetImageUrl(DataBinder.Eval(Container.DataItem,"UserImageId")) %>' />
                            </asp:HyperLink>
                        </td>
                        <td>
                            <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("Id") %>' />
                            <asp:Label ID="NameLabel" runat="server" Text='<%# GetName(Eval("FirstName"),Eval("MiddleName"),Eval("LastName")) %>' />
                        </td>

                        <td>
                            <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                        </td>

                        <td>
                            <asp:Label ID="LastOnlieLabel" runat="server" Text='<%# GetLastOnline(DataBinder.Eval(Container.DataItem,"LastOnline"))  %>'></asp:Label>
                            <%--<asp:Label ID="LastOnlineLabel" runat="server" Text='<%# Eval("LastOnline") %>' />--%>
                        </td>
                    </tr>
                </SelectedItemTemplate>

            </asp:ListView>

            <%-- =========================================================================== --%>


            <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Latest_Academy %>" SelectCommand="SELECT [Id], [FirstName], [LastName], [MiddleName], [UserImageId], [UserName], [Email], [Phone], [LastOnline] FROM [Users]"></asp:SqlDataSource>--%>
            <hr />
           
            <%--  --%>
        </div>
</div>
<script type="text/javascript">
    function() {
        var row = document.getElementsByClassName('selected-tr');
        row.document.getElementsByClassName('selected-tr')
             .onclick(function() {
                 //__doPostBack()
                 row.backgroundColor = Color.pink;
             });
        //.style.height="500px;"
    }
</script>
</div>
