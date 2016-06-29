<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.Structure.Year.Create" %>

<asp:Content runat="server" ID="content" ContentPlaceHolderID="Body">
     <fieldset>
        <legend>Year</legend>
         <table>
            <tr>
                <td>Name*&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="154px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                       ControlToValidate="txtName" runat="server" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td>School&nbsp;*</td>
                <td>
                    <asp:DropDownList ID="cmbSchool" runat="server" Height="20px" OnSelectedIndexChanged="cmbSchool_SelectedIndexChanged" Width="160px"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                       ControlToValidate="cmbSchool" runat="server" 
                        ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td>Level&nbsp;</td>
                <td>
                    <asp:DropDownList ID="cmbLevel" runat="server" Height="21px" Width="159px" OnSelectedIndexChanged="cmbLevel_SelectedIndexChanged"></asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>Faculty&nbsp;</td>
                <td>
                    <asp:DropDownList ID="cmbFaculty" runat="server" Height="21px" Width="159px" OnSelectedIndexChanged="cmbFaculty_SelectedIndexChanged"  ></asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>Program*&nbsp;</td>
                <td>
                    <asp:DropDownList ID="cmbProgram" runat="server" Height="21px" Width="159px"  ></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="valiProg" 
                       ControlToValidate="cmbSchool" runat="server" 
                        ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
           
        </table>
        <asp:Button ID="Button1" runat="server" Text="Save" Width="94px" OnClick="Button1_Click" />
        <br />
    </fieldset>
</asp:Content>
