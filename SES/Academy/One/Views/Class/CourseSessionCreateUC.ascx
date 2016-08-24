<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseSessionCreateUC.ascx.cs" Inherits="One.Views.Class.CourseSessionCreateUC" %>
<%@ Register Src="~/Views/Class/Enrollment/UserEnrollUC.ascx" TagPrefix="uc1" TagName="UserEnrollUC" %>


<div>
    <div>Course Name</div>

    <div>
        <table>
            <tr>
                <td>Name of the Class * </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Grouping of Students </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <Items>
                            <asp:ListItem Value="Use Default Grouping From Settings"></asp:ListItem>
                            <asp:ListItem Value="Use Grouping From Subject"></asp:ListItem>
                            <asp:ListItem Value="Custom Grouping For Only This Session"></asp:ListItem>
                            <asp:ListItem Value="Don't Use any Grouping"></asp:ListItem>
                        </Items>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Enrollment Method</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                    <br />
                    the selection will be multiple and dynamic
                   , when one is selected then give to select another 
                   , the list contains  item "New Enrolment Method for this Class"
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>Start Date</td>
                <td>Choose Date </td>
            </tr>
            <tr>
                <td>End Date</td>
                <td>Choose Date</td>
            </tr>
            <tr>
                <td></td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <%-- List of Groups as per the selected item form dropdown list --%>
    </div>

    <div>
        User LIst to enroll
        <div>
            //Enroll
            <uc1:UserEnrollUC runat="server" ID="UserEnrollUC" />
        </div>
        <%-- List of users to add; with filter  --%>
    </div>
    <div>
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </div>
    <asp:HiddenField ID="hidCourseId" Value="0" runat="server" />
</div>
