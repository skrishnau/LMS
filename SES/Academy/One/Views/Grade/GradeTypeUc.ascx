<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GradeTypeUc.ascx.cs" Inherits="One.Views.Grade.GradeTypeUc" %>

<style type="text/css">
    .st-1 {
        /*margin-left: 15px;*/
        padding: 0 5px;
    }

    .st-2 {
        /*margin-left: 15px;*/
        padding: 0 5px;
        overflow: auto;
    }
    .row-entry {
        vertical-align: top;
    }
</style>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div style="margin-left: -15px; ">
             <asp:RadioButtonList ID="rdbtnlistType" AutoPostBack="True"
                    runat="server" Font-Bold="True" Enabled="True"
                    OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" CellSpacing="2"
                    RepeatDirection="Horizontal">
                    <Items>
                        <asp:ListItem Value="0" Text="Range" ></asp:ListItem>
                        <asp:ListItem Value="1" Text="Values" Selected="True"></asp:ListItem>
                    </Items>
        </asp:RadioButtonList>
        </div>
       

        <asp:Panel runat="server" ID="pnlRange" CssClass="st-1">
            <div style="border: 1px dashed darkgray;">
                <table class="table-entry">
                    <tr class="row-entry">
                        <td class="data-type">Maximum value
                        </td>
                        <td class="data-entry">
                            <asp:TextBox ID="txtMaxValue" runat="server" Text="0.00"></asp:TextBox>
                            <asp:Label ID="lblErrorMaxVal" runat="server" Text="Input error" ForeColor="red" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr class="row-entry">
                        <td class="data-type">Minimum value</td>
                        <td class="data-entry">
                            <asp:TextBox ID="txtMinValue" runat="server" Text="0.00"></asp:TextBox>
                            <asp:Label ID="lblErrorMinVal" runat="server" Text="Input error" ForeColor="red" Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr class="row-entry">
                        <td class="data-type">Minimum value to pass</td>
                        <td class="data-entry">
                            <asp:TextBox ID="txtMinValueToPass" runat="server"  Text="0.00"></asp:TextBox>
                            <asp:Label ID="lblErrorMinValToPass" runat="server" Text="Input error" ForeColor="red" Visible="False"></asp:Label>
                        </td>
                    </tr>

                </table>
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="pnlValues" CssClass="st-2">
            <%--<em style="background-color: yellow;">--//-- This part doesn't work as expected. It needs some work.</em>--%>
            <%--<br />--%>
            <div style="padding:10px 10px 10px 20px;border: 1px dashed darkgray;">
                <div style="float: left;">
                    Equivalent representation in 
                </div>
                <div style="float: left;">
                    <asp:RadioButtonList ID="rdbtnlistEquivalentRepresentation" runat="server"
                        Width="192px" RepeatColumns="2"
                        ToolTip="In Percentage: Values are between 0 and 100. In Position: '1' is low ranked, '2' is ranked higher than '1', and so on." OnSelectedIndexChanged="rdbtnlistEquivalentRepresentation_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value="0" Text="Percentage" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="1" Text="Position"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <div style="clear: both;"></div>

                <div style="margin-left: 20px;">
                    <div style="min-height: 25px; padding-bottom: 4px; background-color: lightblue;">
                        <asp:Panel ID="pnlGradeValues" runat="server"></asp:Panel>
                    </div>
                    <asp:LinkButton ID="btnAddValue" runat="server"
                        CausesValidation="False" OnClick="btnAddValue_Click">Add Value</asp:LinkButton>
                </div>
            </div>


        </asp:Panel>
        <asp:HiddenField ID="hidId" runat="server" Value="0" />
    </ContentTemplate>
</asp:UpdatePanel>
