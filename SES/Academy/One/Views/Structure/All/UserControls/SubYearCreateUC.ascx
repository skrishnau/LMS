<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SubYearCreateUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.SubYearCreateUC" %>

<div>
     <asp:HiddenField ID="hidId" runat="server" Value="0"/>
    <asp:HiddenField ID="hidSchoolId" runat="server" Value="0"/>
    <asp:HiddenField ID="hidLevelId" runat="server" Value="0"/>
    <asp:HiddenField ID="hidFacultyId" runat="server" Value="0"/>
    <asp:HiddenField ID="hidProgram" runat="server" Value="0"/>
    <asp:HiddenField ID="hidYear" runat="server" Value="0"/>

    <fieldset>
        <legend>Sub Year</legend>
         <table>
              <tr>
                <td>Level&nbsp;</td>
                <td>
                    <asp:DropDownList ID="cmbLevel" runat="server" Height="21px" Width="159px"></asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>Faculty&nbsp;</td>
                <td>
                    <asp:DropDownList ID="cmbFaculty" runat="server" Height="21px" Width="159px"  ></asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>Program&nbsp;</td>
                <td>
                    <asp:DropDownList ID="cmbProgram" runat="server" Height="21px" Width="159px"  ></asp:DropDownList>
                    <%--<asp:Label ID="valiProgram" 
                        runat="server" 
                        Text="Required" ForeColor="#FF3300" Visible="false"></asp:Label>--%>
                </td>
            </tr>
           <tr>
                <td>Year*&nbsp;</td>
                <td>
                    <asp:DropDownList ID="cmbYear" runat="server"
                         Height="21px" Width="159px"  ></asp:DropDownList>
                    <asp:Label ID="valiCmbYear" 
                      runat="server" 
                        Text="Required" ForeColor="#FF3300" Visible="False"></asp:Label>
                </td>
            </tr>
             
             <tr>
                <td>Parent&nbsp;</td>
                <td>
                    <asp:DropDownList ID="cmbParent" runat="server"
                         Height="21px" Width="159px"  ></asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>Name*&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="154px"></asp:TextBox>
                    <asp:Label ID="valiTxtName" 
                      runat="server" Text="Required" Visible = "False" ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
              <tr>
                <td>Position*&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtPosition" runat="server" TextMode="Number" Width="154px"></asp:TextBox>
                    <asp:Label ID="valiPostion" 
                      runat="server" Text="Required" Visible = "False" ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
           <%-- <tr>
                <td>School&nbsp;*</td>
                <td>
                    <asp:DropDownList ID="cmbSchool" runat="server" Height="20px" OnSelectedIndexChanged="cmbSchool_SelectedIndexChanged" Width="160px"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                       ControlToValidate="cmbSchool" runat="server" 
                        ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>--%>
            
              <tr>
                <td>Description&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" Width="203px" TextMode="MultiLine" Height="79px"></asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="94px" OnClick="btnSave_Click" />
        <br />
    </fieldset>
</div>