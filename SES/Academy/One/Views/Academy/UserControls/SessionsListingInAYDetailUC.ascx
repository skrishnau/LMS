<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SessionsListingInAYDetailUC.ascx.cs" Inherits="One.Views.Academy.UserControls.SessionsListingInAYDetailUC" %>

<div style="margin-left: 20px; background-color: lightblue;">
    <strong>
        <asp:HyperLink ID="lnkSessionName" runat="server" Text="Label"></asp:HyperLink></strong>
    <div style="margin-left: 20px;">
        <table>
            <tr>
                <td>Start Date</td>
                <td>
                    <asp:Label ID="lblStartDate" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td>End Date</td>
                <td>
                    <asp:Label ID="lblEndDate" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>


    <div style="margin: 0 5px 20px 20px; padding-bottom: 15px;">
        <div style="">
            <strong style="display: inline-block; border-bottom: 1px solid black;">Classes:
            </strong>
            &nbsp;
                <asp:HyperLink ID="lnkAddClasses" runat="server">
                    <asp:Image ID="Image3" runat="server"
                        ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                    
                </asp:HyperLink>
        </div>
        <div style="clear: both;"></div>


        <asp:Panel ID="pnlSessionPrograms" runat="server" Visible="False">

            <%--<strong style="display: inline-block; border-bottom: 1px solid black;">Classes:
            </strong>--%>

            <div style="margin-left: 70px; width: 50%;">

                <asp:ListView ID="ListView1" runat="server">
                    <LayoutTemplate>
                        <table runat="server" id="table1" style="border-collapse: collapse; border: 1px solid lightgray;">
                            <thead>
                                <tr style="text-align: left; border: 1px solid lightgray;">
                                    <th style="width: 40%;">Group</th>
                                    <th>Study in (Year , Subyear)</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <AlternatingItemTemplate>
                        <tr id="Tr1" runat="server" style="background-color: lightgoldenrodyellow;">
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%# GetName(Eval("ProgramBatch")) %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%# GetCurrent(Eval("Year"),Eval("SubYear")) %>'></asp:Label>
                            </td>
                        </tr>
                    </AlternatingItemTemplate>
                    <ItemTemplate>
                        <tr id="Tr2" runat="server">
                            <td>
                                <asp:Label ID="Label1" runat="server" Text='<%# GetName(Eval("ProgramBatch")) %>'></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text='<%# GetCurrent(Eval("Year"),Eval("SubYear")) %>'></asp:Label>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </asp:Panel>

    </div>
    <asp:HiddenField ID="hidAcademicYearId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />
</div>
