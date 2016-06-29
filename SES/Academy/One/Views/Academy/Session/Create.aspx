<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="One.Views.Academy.Session.Create" %>

<%@ Register Src="~/Views/UserControls/DateChooser.ascx" TagPrefix="uc1" TagName="DateChooser" %>
<%@ Register Src="~/Views/Academy/Session/CreateUC.ascx" TagPrefix="uc1" TagName="CreateUC" %>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    
    <div>
        <uc1:CreateUC runat="server" ID="CreateUC" />
    </div>
    

   <%-- <fieldset>
        
        <legend>Session</legend>
        <asp:HiddenField ID="hidId" runat="server" Value="0"/>
        <table>
            <tr>
                <td>Session Name
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" Width="128px"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtName" ErrorMessage="Name is required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%--<tr>
                <td>School
                </td>
                <td>
                    <asp:DropDownList ID="cmbSchool" runat="server" Height="22px" Width="132px" OnSelectedIndexChanged="cmbSchool_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="cmbSchool" ErrorMessage="School is required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>--%>
         <%--   <tr>
                <td>Academic Year 
                </td>
                <td>
                    <asp:DropDownList ID="cmbAcademicYear" runat="server" Height="22px" Width="134px" AutoPostBack="True" 
                        OnSelectedIndexChanged="cmbAcademicYear_SelectedIndexChanged"></asp:DropDownList>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                        ControlToValidate="cmbAcademicYear" ErrorMessage="Academic year is required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Session Type</td>
                <td>
                    <asp:TextBox ID="txtType" runat="server"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Panel ID="panelStart" runat="server">
            Session Start Date &nbsp;
            <uc1:DateChooser runat="server" ID="dtStart" />
        </asp:Panel>

        <asp:Panel ID="panelEnd" runat="server">
            Session End Date &nbsp;
            <uc1:DateChooser runat="server" ID="dtEnd" />
        </asp:Panel>
        <asp:CheckBox ID="CheckBox1" runat="server" Text="Active" />
      </fieldset> 
    
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" Width="62px" />
    --%>
</asp:Content>
