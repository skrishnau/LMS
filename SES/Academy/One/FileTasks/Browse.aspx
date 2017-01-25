<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Browse.aspx.cs" Inherits="One.FileTasks.Browse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        /*.list-item {
            padding: 2px;
            margin: 10px;
        }

            .list-item:hover {
                background-color: lightblue;
                border: 2px solid mediumblue;
            }*/
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <asp:DataList ID="DataList1" runat="server">
                <ItemTemplate>
                    <div style="float: left;">
                        <asp:LinkButton runat="server" CommandName="Select" CommandArgument='<%# Eval("Url") %>'>
                            <asp:Image runat="server" ImageUrl='<%# Eval("Url") %>' Width="40" Height="40" />

                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>' Font-Size="0.8em"></asp:Label>
                        </asp:LinkButton>
                    </div>
                </ItemTemplate>
                <SeparatorTemplate></SeparatorTemplate>
                <SelectedItemStyle BackColor="lightblue" ForeColor="white" BorderWidth="2" BorderColor="blue" BorderStyle="Dashed"></SelectedItemStyle>
            </asp:DataList>
        </div>

        <div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <asp:ListView ID="lstImages"
                        runat="server" GroupItemCount="10" OnItemCommand="lstImages_ItemCommand" OnSelectedIndexChanged="lstImages_SelectedIndexChanged" OnSelectedIndexChanging="lstImages_SelectedIndexChanging" DataMember="Url">


                        <EmptyDataTemplate>
                            <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                <tr>
                                    <td>No images was returned.</td>
                                </tr>
                            </table>
                        </EmptyDataTemplate>

                        <EmptyItemTemplate>
                            <td runat="server" />
                        </EmptyItemTemplate>

                        <GroupTemplate>
                            <tr id="itemPlaceholderContainer" runat="server">
                                <td id="itemPlaceholder" runat="server"></td>
                            </tr>
                        </GroupTemplate>

                        <ItemTemplate>
                            <td runat="server" class="list-item"
                                style="background-color: #FFFBD6; padding: 2px; color: #333333; text-align: center; overflow: hidden;">
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select">
                                    <%-- CommandArgument='<%# Eval("Url") %>' --%>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Url") %>' Width="40" Height="40" />
                                    <br />
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>' Font-Size="0.8em"></asp:Label>
                                </asp:LinkButton>
                            </td>
                        </ItemTemplate>

                        <LayoutTemplate>
                            <table runat="server">
                                <tr runat="server">
                                    <td runat="server">
                                        <table id="groupPlaceholderContainer" runat="server" border="1"
                                            style="background-color: #FFFFFF; padding: 2px; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                            <tr id="groupPlaceholder" runat="server">
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server" style="text-align: center; background-color: #FFCC66; font-family: Verdana, Arial, Helvetica, sans-serif; color: #333333;"></td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                        
                        <SelectedItemTemplate>
                            <td runat="server" style="background-color: #FFCC66; font-weight: bold; color: #000080;">
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Select">
                                    <%-- CommandArgument='<%# Eval("Url") %>' --%>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>' Font-Size="0.8em"></asp:Label>
                                    <br />
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Url") %>' Width="40" Height="40" />
                                </asp:LinkButton>
                            </td>
                        </SelectedItemTemplate>

                    </asp:ListView>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Latest_Academy %>" SelectCommand="SELECT [Name], [StartDate], [EndDate], [RemindWhenEndDate], [IsActive], [Completed], [Position] FROM [AcademicYear]"></asp:SqlDataSource>
        </div>
        <asp:Button ID="btnOkay" runat="server" Text="Okay" OnClick="btnOkay_Click" />
    </form>
</body>
</html>
