<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="One.Views.Report.Default" %>


<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>

<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="bodycontent" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">
        <asp:Label ID="Label1" runat="server" Text="Report"></asp:Label>
    </h3>
    <hr />

    <table>
        <tr>
            <td class="data-type">Course</td>
            <td class="data-value">
                <asp:HyperLink ID="lnkCourseName" CssClass="link" runat="server" Text=""></asp:HyperLink>
            </td>
        </tr>

        <tr>
            <td class="data-type">Class</td>
            <td class="data-value">
                <asp:Label ID="lblClassName" runat="server" Text=""></asp:Label>
            </td>
        </tr>
    </table>

    <br />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <asp:LinkButton ID="lnkFilter" runat="server" OnClick="lnkFilter_OnClick" Enabled="False">
                        <asp:Image ID="imgFilter" runat="server" ImageUrl="~/Content/Icons/Sort/sort-down-14px.png" />
                        Filter
                    </asp:LinkButton>
                </div>
                <div class="panel-body">
                    <asp:Panel ID="pnlFilter" runat="server" Visible="True">

                        <%-- style="margin: 10px 0;" --%>
                        <div class="row">
                            <div class="col-md-3">
                                Attributes to include:
                            </div>
                            <%-- style="margin: 10px 0;" --%>
                            <div class="col-md-9">
                                <span class="span-padding">
                                    <asp:CheckBox ID="chkImage" runat="server" Text="Image" Checked="True" />
                                </span>
                                <span class="span-padding">
                                    <asp:CheckBox ID="chkRoll" runat="server" Text="Roll No." Checked="True" />
                                </span>
                                <span class="span-padding">
                                    <asp:CheckBox ID="chkName" runat="server" Text="Name" Checked="True" />
                                </span>
                                <span class="span-padding">
                                    <asp:CheckBox ID="chkTotal" runat="server" Text="Total" Checked="True" />
                                </span>
                                <span class="span-padding"></span>
                                <span class="span-padding"></span>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <%-- style="margin: 10px 0 5px; --%>
                            <div class="col-md-3">Activities to include:</div>

                            <%--  --%>
                            <div class="col-md-9">
                                <asp:CheckBoxList ID="chkActivities" runat="server"
                                    Enabled="True"
                                    CssClass="checkbox-horizontal"
                                    DataTextField="Name" DataValueField="Id" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                                <span class="span-padding">
                                    <asp:Label ID="lblNoneActRes" runat="server" Text="None" Visible="False">
                                    </asp:Label>
                                </span>
                            </div>
                        </div>
                        <%--<asp:PlaceHolder ID="pnlActivityCheck" runat="server"></asp:PlaceHolder>--%>
                        <br />
                        <div class="row" style="margin-left: 5px;">
                            <%-- link-button --%>
                            <asp:LinkButton ID="btnSave" ToolTip="Save the report setting for future view"
                                runat="server" CssClass="btn btn-default" Text="Save"
                                OnClick="btnSave_OnClick">
                            </asp:LinkButton>

                            &nbsp; &nbsp; &nbsp;

                                <asp:LinkButton ID="btnLoad" runat="server" CssClass="btn btn-default" Text="Load"
                                    OnClick="btnLoad_OnClick">
                                </asp:LinkButton>

                        </div>
                    </asp:Panel>
                </div>
            </div>
            <%-- gridview --%>
            <div class="panel panel-default">
                <div class="panel-heading">Report</div>
                <asp:Table ID="tblStudents"
                    CssClass="table table-hover table-responsive"
                    Style="border-collapse: collapse; width: 100%;"
                    runat="server" Width="100%">
                </asp:Table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <br />

    <asp:HiddenField ID="hidSubjectClassId" runat="server" Value="0" />
</asp:Content>



<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="title">
    <asp:Literal ID="lblPageTitle" runat="server" Text="Report"></asp:Literal>
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="head">
    <link href="../../Content/CSSes/ToolTip.css" rel="stylesheet" />
    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />
    <style type="text/css">
        .span-padding {
            padding: 0 5px;
        }
    </style>
</asp:Content>
