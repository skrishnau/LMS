<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListItemUc.ascx.cs" Inherits="One.Views.Student.StudentGroup.Listing.ListItemUc" %>
<%@ Import Namespace="Academic.DbEntities.Structure" %>

<div class="item">
    <div class="item-heading">
        <asp:LinkButton ID="lblName" runat="server" OnClick="lblName_Click"></asp:LinkButton>
        <div class="float-right">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Content/Icons/Edit/edit_black_and_white.png" />
        </div>
    </div>

    <div class="item-detail">
        No. of Students:
        <asp:Literal ID="lblNoOfStudents" runat="server"></asp:Literal>
        <div>
            <strong style="font: 0.9em bold serif;">Currently Studying in</strong>
            <div class="sub-item">
                <table>
                    <tr>
                        <td>Program</td>
                        <td>
                            <asp:Literal ID="lblProgram" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>Year</td>
                        <td>
                            <asp:Literal ID="lblYear" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <% if (lblSubYear.Text != "")
                       { %>
                    <tr>
                        <td>Sub Year</td>
                        <td>
                            <asp:Literal ID="lblSubYear" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <% } %>
                </table>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidStudentGroupId" runat="server"  Value="0"/>
</div>
