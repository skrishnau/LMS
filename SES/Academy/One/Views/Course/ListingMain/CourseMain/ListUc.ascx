<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListUc.ascx.cs" Inherits="One.Views.Course.ListingMain.CourseMain.ListUc" %>
<%@ Register Src="~/Views/Course/CourseGroup/GroupUc.ascx" TagPrefix="uc1" TagName="GroupUc" %>


<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <strong>Course Groups in</strong>&nbsp;(choose)
                <div style="margin: 0 20px 0;">
                    <table>
                        <tr>
                            <td>Level</td>
                            <td>&nbsp;
                    <asp:DropDownList ID="cmbLevel" runat="server" OnSelectedIndexChanged="cmbLevel_SelectedIndexChanged" Height="20px" Width="125px" AutoPostBack="True"></asp:DropDownList>
                                &nbsp;&nbsp;
                            </td>
                            <%--</tr>
            <tr>--%>
                            <td>&nbsp;&nbsp;Faculty</td>
                            <td>&nbsp;
                    <asp:DropDownList ID="cmbFaculty" runat="server" OnSelectedIndexChanged="cmbFaculty_SelectedIndexChanged" Height="20px" Width="125px" AutoPostBack="True"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <hr />
                    <table>
                        <tr>
                            <td>Program</td>
                            <td>&nbsp;
                    <asp:DropDownList ID="cmbProgram" runat="server" OnSelectedIndexChanged="cmbProgram_SelectedIndexChanged" Height="20px" Width="125px" AutoPostBack="True"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div style="margin: 0 20px 0; padding: 0 20px 0;">


                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                       <%-- <div style="float: right; clear: both;">
                            <asp:LinkButton ID="btnNewGroup" runat="server" OnClick="btnNewGroup_Click">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />&nbsp;New Group
                            </asp:LinkButton>
                        </div>--%>
                        <div>
                            <asp:PlaceHolder ID="pnlSubjectGroups" runat="server"></asp:PlaceHolder>
                        </div>
                    </asp:View>
                    <%--<asp:View ID="View2" runat="server">
                        <uc1:GroupUc runat="server" ID="GroupUc" />
                    </asp:View>--%>
                </asp:MultiView>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</div>
