<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.Structure.Faculty.Create" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <fieldset>
        <legend>Faculty</legend>
        <table>
            <tr>
                <td>Name&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="154px"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>School&nbsp;</td>
                <td>
                    <asp:DropDownList ID="cmbSchool" runat="server" Height="20px" OnSelectedIndexChanged="cmbSchool_SelectedIndexChanged" Width="160px"></asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>Level&nbsp;</td>
                <td>
                    <asp:DropDownList ID="cmbLevel" runat="server" Height="21px" Width="159px"></asp:DropDownList>
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

