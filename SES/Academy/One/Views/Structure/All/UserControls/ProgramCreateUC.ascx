<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgramCreateUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.ProgramCreateUC" %>

<div>
    <asp:HiddenField ID="hidId" runat="server" Value="0"/>
    <asp:HiddenField ID="hidSchoolId" runat="server" Value="0"/>
    <asp:HiddenField ID="hidLevelId" runat="server" Value="0"/>
    <asp:HiddenField ID="hidFacultyId" runat="server" Value="0"/>
    <fieldset>
        <legend>Program</legend>
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
                    <asp:DropDownList ID="cmbSchool" runat="server" Height="20px" 
                    OnSelectedIndexChanged="cmbSchool_SelectedIndexChanged" Width="160px"></asp:DropDownList>
                </td>
            </tr>--%>
           <%--  <tr>
                <td>Level&nbsp;</td>
                <td>
                    <asp:DropDownList ID="cmbLevel" runat="server" Height="21px" Width="159px" OnSelectedIndexChanged="cmbLevel_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>Faculty&nbsp;</td>
                <td>
                    <asp:DropDownList ID="cmbFaculty" runat="server" Height="21px" Width="159px"  ></asp:DropDownList>
                    <asp:Label ID="valiFaculty" runat="server" Text="Required" Visible="false" ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>--%>
            <tr>
                <td>Description&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="75px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnSaveProgram" runat="server" Text="Save" Width="94px" OnClick="btnSaveProgram_Click" />
        <br />
    </fieldset>
</div>