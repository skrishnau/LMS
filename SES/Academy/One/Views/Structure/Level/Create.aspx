<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.Structure.Level.Create" %>

<asp:Content runat="server" ContentPlaceHolderID="Body" ID="content1">
    <fieldset>
        <legend>Level</legend>
        <table>
            <tr>
                <td>Name&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>School&nbsp;</td>
                <td>
                    <asp:DropDownList ID="cmbSchool" runat="server"></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>Description&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="75px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="Save" Width="94px" OnClick="Button1_Click" />
        <br />
    </fieldset>
</asp:Content>
