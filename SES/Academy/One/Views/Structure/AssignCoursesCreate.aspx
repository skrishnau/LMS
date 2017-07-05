<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="AssignCoursesCreate.aspx.cs" Inherits="One.Views.Structure.AssignCoursesCreate" %>


<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<%@ Register Src="~/Views/Structure/CategoryDropDownList.ascx" TagPrefix="uc1" TagName="CategoryDropDownList" %>

<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>



<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="body">

    <h3 class="heading-of-listing">
        <asp:Label ID="lblHeading" runat="server" Text="Course Assign"></asp:Label>
    </h3>
    <br />
    <div>

        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div style="width: 99%;">

                    <table style="width: 100%; border-collapse: collapse;">
                        <tr>
                            <td style="background-color: #557d96; border: 1px solid #557d96; color: white; text-align: center; font-size: 1.1em;">Selected Courses
                            </td>
                            <td style="width: 70px;"></td>
                            <td style="background-color: #557d96; border: 1px solid #557d96; color: white; text-align: center; font-size: 1.1em;">Unassigned Courses
                            </td>
                        </tr>

                        <tr>
                            <%-- --------------border: 1px solid #557d96;--------Left panel --%>
                            <td style="width: 39%;  vertical-align: top;">
                                <div style="padding: 2px;">
                                    <%--<div style="height: 50%; min-height: 100px; margin-bottom: 5px;">--%>
                                        <%--<span style="font-weight: 600;">Selected Courses</span>
                                        <hr />--%>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>

                                                <asp:ListBox ID="lstAssignedCourses" runat="server"
                                                    Width="253px" Height="326px" 
                                                    DataValueField="Id" DataTextField="FullName"></asp:ListBox>

                                                <%-- <asp:Panel ID="pnlSelectedCourses" runat="server">
                                                </asp:Panel>--%>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    <%--</div>--%>

                                </div>
                            </td>

                            <%-- -------------------------Mid section --%>

                            <td style="width: 20px; vertical-align: top; text-align: center;">

                                <br/>
                                <br/>
                                <br/>

                                <asp:CheckBox ID="chkElective" runat="server" Text="Elective" />
                                <br />
                                <br/>
                                <br/>
                                Credit:
                                <asp:TextBox ID="txtCredit" runat="server" Width="50px"></asp:TextBox>
                                
                                <br/>
                                <br/>
                                <br/>
                                <asp:Button ID="btnAssign" runat="server" Text="← Assign" OnClick="btnAssign_OnClick" />
                                <br/>
                                <br/>                                
                                <br/>
                                <asp:Button ID="btnRemove" runat="server" Text="Remove →" OnClick="btnRemove_OnClick"/>

                            </td>



                            <%-- ---------------------Left panel --%>
                            <td style="width: 39%; vertical-align: top; ">
                                <div>

                                    <div style="border: 1px solid #557d96; margin-bottom: 5px;">
                                        <table>
                                            <tr>
                                                <td><strong>Category: </strong>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <uc1:CategoryDropDownList runat="server" ID="CategoryDropDownList1" />
                                                </td>
                                            </tr>
                                        </table>
                                        <%--  OnDataBound="ddlCategories_OnDataBound" --%>
                                        <%--                                        <asp:DropDownList ID="ddlCategories" runat="server">
                                        </asp:DropDownList>--%>
                                    </div>
                                    <%--<hr style="border: none; height: 1px; background-color: darkgray;" />--%>

                                    <div id="courseDiv">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:HiddenField ID="hidSelectedCategoryId" Value="0" runat="server" />
                                                <asp:HiddenField ID="hidSelectedCategoryName" Value="" runat="server" />

                                                <asp:ListBox ID="lstUnAssignedCourses" runat="server" AutoPostBack="True"
                                                    Width="256px" Height="250px" OnSelectedIndexChanged="lstUnAssignedCourses_OnSelectedIndexChanged"
                                                    DataValueField="Id" DataTextField="FullName"></asp:ListBox>


                                                <asp:HiddenField ID="hidSchoolId" Value="0" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>

                                </div>
                            </td>
                        </tr>
                    </table>

                </div>
                <div style="clear: both;"></div>
                <br />
                <div style="text-align: left;">
                    <asp:Button runat="server" ID="btnSaveAndContinueAdding" Text="Save and Continue adding" Width="215px"
                        CausesValidation="False"
                        OnClick="btnSaveAndContinueAdding_Click" />
                    &nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnSaveAndReturn" Text="Save and return" Width="176px"
                    CausesValidation="False"
                    OnClick="btnSaveAndReturn_Click" />
                    &nbsp;&nbsp;&nbsp;
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" Width="142px"
                    CausesValidation="False"
                    OnClick="btnCancel_Click" />
                    <br />
                    <br />

                </div>

                <asp:HiddenField ID="hidYearId" Value="0" runat="server" />
                <asp:HiddenField ID="hidSubYearId" Value="0" runat="server" />
                <asp:HiddenField ID="hidProgramId" Value="0" runat="server" />

            </ContentTemplate>
        </asp:UpdatePanel>

        <%--</asp:View>--%>
    </div>

</asp:Content>





<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    Assign Courses
</asp:Content>
