<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="AcademicYearDetail.aspx.cs" Inherits="One.Views.Academy.AcademicYear.AcademicYearDetail" %>


<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content4" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">
        <asp:Label ID="lblAcademicYearName" runat="server" Text=""></asp:Label>
    </h3>
    <%--    <div style="text-align: right;">
        <asp:HyperLink ID="lnkEdit" runat="server" CssClass="link">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
            <asp:Label ID="lblEdit" runat="server" Text="Edit"></asp:Label>
        </asp:HyperLink>
    </div>--%>
    <%--<div style="text-align: center;">--%>


    <%--<asp:Button ID="Button2" runat="server" Text="Update Academic year/ Session " />--%>
    <%-- <asp:Button ID="btnActivate" runat="server" Text="Activate this Academic Year"
            OnClick="btnActivate_Click" Visible="False" />
        &nbsp;--%>
    <%--   <asp:Button ID="btnMarkComplete" runat="server" Text="Mark this as completed"
                Visible="False"
                OnClick="btnMarkComplete_Click" />--%>
    <%--</div>--%>
  <%--  <div>
        <asp:Label ID="lblError" runat="server" Text="Error while saving" ForeColor="red" Visible="False"></asp:Label>
    </div>--%>
    <div class="">
        <table>
            <tr>
                <td class="auto-style1">Start Date  :</td>
                <td>
                    <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">End Date  :</td>
                <td>
                    <asp:Label ID="lblEndDate" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>

    <div class="data-entry-body">


        <%-- Programs listing --%>
        <br />
        <%--    <div class="data-entry-section">
            <div runat="server" visible="False" id="classesOfAY" class="data-entry-section-heading" style="visibility: hidden;">
                Classes:
                   <div style="float: right; font-weight: 400;">
                       <asp:HyperLink ID="lnkAddClasses" runat="server" CssClass="link_smaller"
                           Visible="False">
                           <asp:Image ID="Image3" runat="server"
                               ImageUrl="~/Content/Icons/Edit/edit_orange.png"
                               ToolTip="Edit classes for this academic year." />
                           Edit Classes
                       </asp:HyperLink>
                   </div>
                <div style="clear: both;"></div>
                <hr />
            </div>

            <div class="data-entry-section-body">
                <asp:Panel ID="pnlSessionPrograms" runat="server" Visible="False">
                    <div style="width: 50%;">
                        <asp:ListView ID="ListView1" runat="server">
                            <LayoutTemplate>
                                <table runat="server" id="table1" style="border-collapse: collapse; border: 1px solid lightgray;">
                                    <thead>
                                        <tr style="text-align: left; border: 1px solid lightgray;">
                                            <th style="width: 50%;">Group</th>
                                            <th>Study in (Year)</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr runat="server" id="itemPlaceholder"></tr>
                                    </tbody>
                                </table>
                            </LayoutTemplate>
                            <AlternatingItemTemplate>
                                <tr id="Tr1" runat="server" style="background-color: lightgoldenrodyellow;">
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# GetName(Eval("ProgramBatch")) %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# GetCurrent(Eval("Year"),Eval("SubYear")) %>'></asp:Label>
                                    </td>
                                </tr>
                            </AlternatingItemTemplate>
                            <ItemTemplate>
                                <tr id="Tr2" runat="server">
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# GetName(Eval("ProgramBatch")) %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# GetCurrent(Eval("Year"),Eval("SubYear")) %>'></asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:ListView>
                    </div>
                </asp:Panel>

            </div>

            <asp:Panel ID="pnlAcademicPrograms" runat="server">
            </asp:Panel>
        </div>--%>
        <br />



        <%-- Session List --%>

        <div class="data-entry-section">
            <div class="data-entry-section-heading">
                <div style="clear: both;">
                    <div style="float: left;">
                        <strong>Sessions</strong>
                    </div>
                    <div style="float: right;">
                        <asp:HyperLink ID="lnknewSession" runat="server" CssClass="link-dark"
                            Visible="False">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                            Add Session
                        </asp:HyperLink>
                    </div>
                </div>
                <div style="clear: both"></div>
                <hr />
            </div>

            <div class="data-entry-section-body">
                <asp:Panel ID="pnlSessions" runat="server"></asp:Panel>
            </div>
        </div>

        <asp:HiddenField ID="hidAcademicYear" runat="server" Value="0" />
        <asp:HiddenField ID="hidEditable" runat="server" Value="False" />
    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            width: 94px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="title">
    <asp:Literal ID="lblPageTitle" runat="server"></asp:Literal>
</asp:Content>

