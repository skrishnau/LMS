<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Create.ascx.cs" Inherits="One.Views.Activity.Teach.Create" %>
<%@ Register Src="~/Views/UserControls/DateChooser.ascx" TagPrefix="uc1" TagName="DateChooser" %>

<style type="text/css">
    .auto-style1 {
        width: 139px;
    }
</style>

<div>
    <fieldset>
    <asp:HiddenField ID="hidId" runat="server" Value="0" />
        <legend>Teacher Assign
            To Course
        </legend>
        <table>
            <tr>
                <td class="auto-style1">Session*&nbsp;&nbsp;&nbsp; </td>
                <td>
                    <asp:DropDownList ID="cmbSession" runat="server" Height="22px" Width="130px"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="cmbSession"
                        ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Teacher*</td>
                <td>
                    <asp:DropDownList ID="cmbTeacher" runat="server" Height="22px" Width="130px"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="cmbTeacher"
                        ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Course*</td>
                <td>
                    <asp:DropDownList ID="cmbSubject" runat="server" Height="22px" Width="130px"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="cmbSubject"
                        ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>

        </table>

        <table>
            <tr>
                <td class="auto-style1">StartDate*</td>
                <td>
                    <uc1:DateChooser runat="server" ID="DateChooser" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Estimated completion<br />
                    Hours</td>
                <td>
                    <asp:TextBox ID="txtEstimated" runat="server" TextMode="Number"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">Remarks</td>
                <td>
                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Height="61px" Width="241px"></asp:TextBox>                    
                </td>
            </tr>
        </table>
    </fieldset>
    <br/>
    <div>
        <br />
&nbsp;<asp:Button ID="btnSave" runat="server" Text="Save" Width="67px" OnClick="btnSave_Click" />
        <br />
        <br />
    </div>
</div>
