<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YearCreateUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.YearCreateUC" %>

<div>
    <asp:HiddenField ID="hidId" runat="server" Value="0"/>
    <asp:HiddenField ID="hidSchoolId" runat="server" Value="0"/>
    <asp:HiddenField ID="hidLevelId" runat="server" Value="0"/>
    <asp:HiddenField ID="hidFacultyId" runat="server" Value="0"/>
    <asp:HiddenField ID="hidProgram" runat="server" Value="0"/>

     <fieldset>
        <legend>Year</legend>
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
                <td>Program*&nbsp;</td>
                <td>
                    <asp:DropDownList ID="cmbProgram" runat="server" Height="21px" Width="159px"  ></asp:DropDownList>
                    <asp:Label ID="valiProgram" 
                        runat="server" 
                        Text="Required" ForeColor="#FF3300" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Name*&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="149px"></asp:TextBox>
                    <asp:Label ID="valiTxtName" 
                        runat="server" Text="Required" Visible="False" ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
             <tr>
                 <td>Position*</td>
                 <td>
                      <asp:TextBox ID="txtPosition" runat="server" Width="148px" TextMode="Number"></asp:TextBox>
                    <asp:Label ID="valitxtPosition" 
                        runat="server" Text="Required" Visible="False" ForeColor="#FF3300"></asp:Label>
                 </td>
             </tr>
               <tr>
                 <td>Description &nbsp;</td>
                 <td>
                      <asp:TextBox ID="txtDescription" runat="server" Width="195px" TextMode="MultiLine" Height="39px"></asp:TextBox>
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
            
           
        </table>
        &nbsp;
        <asp:Button ID="btnSaveYear" runat="server" Text="Save" Width="94px" OnClick="btnSaveYear_Click" />
        <br />
    </fieldset>

</div>