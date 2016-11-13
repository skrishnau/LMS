<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YearItemUc.ascx.cs" Inherits="One.Views.Academy.ClassAssign.UserControls.YearItemUc" %>


<%--<div class="data-entry-section-body">--%>
<tr class="pc-table-row">
    <td class="pc-year-name">
        <asp:CheckBox ID="chkBox" runat="server" />
        <%--<asp:Label ID="lblName" runat="server" Text=""></asp:Label>--%>
    </td>

    <td class="pc-subyear-option">
        <asp:PlaceHolder ID="pnlStructure" runat="server" Visible="False">
            <span style="min-height: 20px; border: 1px solid darkgray; margin-left: 15px;">
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Class/class.png" Height="14" Width="14" />
                <asp:DropDownList ID="ddlStructure" runat="server" Height="20"
                    DataValueField="Id" DataTextField="Name">
                    <Items>
                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                    </Items>
                </asp:DropDownList>
            </span>
        </asp:PlaceHolder>
    </td>

    <td class="pc-programbatch-option">
        <span style="border: 1px solid darkgray; min-height: 20px; margin-left: 15px;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Users/group.png" Height="14" Width="14" />
            <asp:DropDownList ID="ddlStudentGrps" runat="server" Height="20"
                DataValueField="Id" DataTextField="Name" AutoPostBack="True"
                OnSelectedIndexChanged="ddlStudentGrps_SelectedIndexChanged">
                <Items>
                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                </Items>
            </asp:DropDownList>
        </span>
        <asp:Label ID="lblError" runat="server" Text="Already selected" Visible="False" ForeColor="red"></asp:Label>
    </td>

</tr>
<asp:HiddenField ID="hidYearId" runat="server" Value="0" />
<asp:HiddenField ID="hidAcademicYearId" runat="server" Value="0" />
<asp:HiddenField ID="hidSessionId" runat="server" Value="0" />
<asp:HiddenField ID="hidRunningClassId" runat="server" Value="0" />
<%--</div>--%>
