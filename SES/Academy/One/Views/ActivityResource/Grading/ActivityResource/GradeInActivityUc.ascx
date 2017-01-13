<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GradeInActivityUc.ascx.cs" Inherits="One.Views.ActivityResource.Grading.ActivityResource.GradeInActivityUc" %>

<div class="data-entry-section-body">

    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
        <ContentTemplate>
            <table style="margin: 0 20px 0;">
                <tr>
                    <td class="data-type">Grade Type</td>
                    <td>
                        <asp:DropDownList ID="ddlGradeType" runat="server" Height="21px" Width="210px"
                            AutoPostBack="True" DataTextField="Name" DataValueField="Id"
                            OnSelectedIndexChanged="ddlGradeType_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="gradeListVali"
                            ControlToValidate="ddlGradeType"
                            runat="server" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">Maximum Grade</td>
                    <td>
                        <asp:TextBox ID="txtMaxGradde" runat="server" Width="210px"></asp:TextBox>
                        <asp:DropDownList ID="ddlMaximumGrade" runat="server" Width="210px" Visible="False"
                            DataTextField="Value" DataValueField="Id">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">Grade to Pass</td>
                    <td>
                        <asp:TextBox ID="txtGradeToPass" runat="server" Width="210px"></asp:TextBox>
                        <asp:DropDownList ID="ddlGradeToPass" runat="server" Width="210px" Visible="False" DataTextField="Value" DataValueField="Id"></asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td class="data-type">Weight in grade sheet (in %)</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtWeightInGradeSheet" runat="server" Text="0"></asp:TextBox>
                        <asp:Label ID="valiWeightInGradeSheet" runat="server" Text="Wrong format, Values 0-100 only"
                            ForeColor="red" Visible="False"></asp:Label>
                    </td>
                </tr>
                
                <tr>
                    <td class="datat-type">Show grade to students</td>
                    <td >
                        <asp:DropDownList ID="ddlShowGradeToStudents" runat="server">
                            <Items>
                                <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hidAssignmentId" runat="server" Value="0" />
</div>
