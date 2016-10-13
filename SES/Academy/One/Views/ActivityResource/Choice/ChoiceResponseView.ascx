<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChoiceResponseView.ascx.cs" Inherits="One.Views.ActivityResource.Choice.ChoiceResponseView" %>

<div>
    <h3>Responses
    </h3>
    <br/>
    <asp:ListView ID="ListView1" runat="server">
        <LayoutTemplate>
            <table runat="server" id="table1"  style="border-collapse: collapse; width: 98%; ">
                <tr >
                    <th style="padding: 3px; width: 30%; border-bottom: 1px gray solid; text-align: left;">Choice Options</th>
                    <th style="padding: 3px; width: 30%; border-bottom: 1px gray solid; text-align: left;">Number of responses</th>
                    <th style="padding: 3px; width: 30%; border-bottom: 1px gray solid; text-align: left;" >Percentage of responses</th>
                </tr>
                <tr runat="server" id="itemPlaceholder"></tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <tr runat="server" id="trItem1">
                <td style="padding: 3px; border-bottom: 1px lightgray solid;">
                    <asp:Label ID="Label1" runat="server"
                        Text='<%# Eval("ChoiceOption") %>'>
                    </asp:Label>
                </td>
                <td style="padding: 3px; border-bottom: 1px lightgray solid;">
                    <asp:Label ID="Label2" runat="server"
                        Text='<%# Eval("NumberOfResponses") %>'></asp:Label>
                </td>
                <td style="padding: 3px; border-bottom: 1px lightgray solid;">
                    <asp:Label ID="Label3" runat="server"
                        Text='<%# Eval("PercentageOfResponses") %>'></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
    </asp:ListView>

</div>
