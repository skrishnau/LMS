<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FacultyCreateUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.FacultyCreateUC" %>

 <fieldset>
        <legend>Faculty</legend>
     <asp:HiddenField ID="hidId" runat="server" Value="0"/>
        <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
     <asp:HiddenField ID="hidLevelId" runat="server" Value="0"/>
        <table>
            <tr>
                <td>Name&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="154px"></asp:TextBox>
                    <asp:Label ID="valiTxtName" runat="server" Text="Required" Visible="false" ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>

           <%-- <tr>
                <td>School&nbsp;</td>
                <td>
                    <asp:DropDownList ID="cmbSchool" runat="server" Height="20px" OnSelectedIndexChanged="cmbSchool_SelectedIndexChanged" Width="160px"></asp:DropDownList>
                </td>
            </tr>--%>

             <tr>
                <td>Level&nbsp;</td>
                <td>
                    <asp:DropDownList ID="cmbLevel" runat="server" Height="20px" Width="160px"></asp:DropDownList>
                    <asp:Label ID="valiCmbLevel" runat="server" Visible="false" Text="Required" ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>

            <tr>
                <td>Description&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="75px" Width="198px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="94px" OnClick="btnSave_Click" />
        <br />
    </fieldset>