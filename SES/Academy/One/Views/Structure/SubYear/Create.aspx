<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="Create.aspx.cs" Inherits="One.Views.Structure.SubYear.Create" %>



<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
     <fieldset>
        <legend>Section</legend>
         <table>
            <tr>
                <td>Name*&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="154px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                       ControlToValidate="txtName" runat="server" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>

           
        </table>
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="94px" OnClick="Button1_Click" />
        <br />
    </fieldset>
</asp:Content>

