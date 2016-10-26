<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TeacherViewUc.ascx.cs" Inherits="One.Views.ActivityResource.Assignments.TeacherViewUc" %>

<div>
    <asp:ListView ID="ListView1" runat="server">
        <LayoutTemplate>
            <table runat="server" id="table1">
                <tr style="font-weight: 700;">
                    <td>Name</td>
                    <td>Email</td>
                    <td>Status</td>
                    <td>Grade</td>
                    <td>Submissions</td>
                </tr>
                <tr runat="server" id="itemPlaceholder">
                    <td>
                        <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("Image") %>' />
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Status") %>'></asp:Label>
                        <asp:TextBox ID="Label4" runat="server" Text='<%# Eval("Grade") %>'></asp:TextBox>
                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("Submission") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>

        <ItemTemplate>
            <tr>
                <td></td>
            </tr>

        </ItemTemplate>
    </asp:ListView>


    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />

    <asp:HiddenField ID="hidARId" runat="server" Value="0" />
    <asp:HiddenField ID="hidARType" runat="server" Value="" />
    
</div>
