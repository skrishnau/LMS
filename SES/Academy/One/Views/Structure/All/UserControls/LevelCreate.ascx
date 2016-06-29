<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LevelCreate.ascx.cs" Inherits="One.Views.Structure.All.UserControls.LevelCreate" %>

<fieldset>
                <legend>Level</legend>
                <asp:HiddenField ID="hidId" runat="server" Value="0" />
                <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
                <table>
                    <tr>
                        <td>Name&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Width="139px"></asp:TextBox>
                            <asp:Label ID="txtNameVali" runat="server" Text="Required" ForeColor="#FF3300" Visible="False"></asp:Label>
                        </td>
                    </tr>

                    <%-- <tr>
                <td>School&nbsp;</td>
                <td>
                    <asp:DropDownList ID="cmbSchool" runat="server"></asp:DropDownList>
                </td>
            </tr>--%>

                    <tr>
                        <td>Description&nbsp;</td>
                        <td>
                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="89px" Width="205px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                &nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Save" Width="94px" OnClick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="94px" OnClick="btnCancel_Click" />
                <br />
            </fieldset>