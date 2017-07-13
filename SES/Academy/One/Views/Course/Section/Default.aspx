<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="One.Views.Course.Section.Default" %>

<%@ Register Src="~/Views/Course/Section/Master/ListOfSectionsInCourseUC.ascx" TagPrefix="uc1" TagName="ListOfSectionsInCourseUC" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <%--<div style="font-size: 1.3em; font-weight: 700; text-align: center; color: lightsalmon;">
               
            </div>--%>
            <%-- heading-of-listing --%>
            <div>
                <div style="float: left;">
                    <h3 class="act-res-course-title">
                        <asp:Literal ID="txtSubjectName" runat="server"></asp:Literal>
                    </h3>
                </div>
                <div style="float: left; padding-left: 8px;">
                    <asp:Image ID="imgJoinInfo" runat="server" Width="10" Height="10" Visible="False" />
                </div>
                <%-- line-height: 18px; --%>
                <div style="float: left;margin-top: 10px;">
                    &nbsp;&nbsp;
                    <asp:LinkButton ID="lnkEnroll" runat="server" CssClass="link-button"
                        ToolTip="New class has been opened in this course. Click for detail."
                         Visible="False">
                        Enroll now
                    </asp:LinkButton>
                </div>
                
                <div style="float: right;margin-top: 10px">
                    <asp:LinkButton ID="lnkMyClasses" runat="server" CssClass="link-button"
                        ToolTip="Classes of this course in which you have participated"
                         Visible="False">
                        My Classes
                    </asp:LinkButton>
                </div>

                <div style="clear: both;"></div>
            </div>
            <div style="clear: both;"></div>
           

            <%--<div style="margin: 5px 10px 5px; padding: 5px; border: 1px solid lightgray;">

                <asp:Label ID="lblClassInformation" runat="server" Text="Label" ForeColor="#993366" ></asp:Label>
            </div>--%>
            <br />

            <%--hello--%>
            <%--            <div style="text-align: right; margin-right: 15px;">
                <asp:HyperLink ID="lnkEdit"
                    runat="server">
                    <asp:Image ID="ImageButton1" runat="server"
                        ImageUrl="~/Content/Icons/Edit/edit_orange.png" /><asp:Literal ID="lblEdit" runat="server"></asp:Literal>
                </asp:HyperLink>
            </div>--%>
            <%--<uc1:CourseDetailUc runat="server" ID="CourseDetailUc1" />--%>
            <uc1:ListOfSectionsInCourseUC runat="server" ID="ListOfSectionsInCourseUC1" />
            <%--<asp:Panel ID="Panel1" runat="server" Visible="False">
                <%--<uc1:ActResChooseUc runat="server" ID="ActResChooseUc" />
            </asp:Panel>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:HiddenField ID="hidEdit" runat="server" Value="0" />
</asp:Content>


<asp:Content runat="server" ID="contentHead" ContentPlaceHolderID="head">
    <%--<link href="../../../../Content/themes/base/jquery.ui.dialog.css" rel="stylesheet" />--%>
    <%--<script src="../../../../Scripts/jquery-1.7.1.min.js"></script>--%>

    <%--<link rel="stylesheet" href="../../../../Remodal/dist/remodal.css">
    <link rel="stylesheet" href="../../../../Remodal/dist/remodal-default-theme.css">--%>

    <%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
        rel="stylesheet" type="text/css" />
    --%>

    <script type="text/javascript" src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.min.js"></script>
    <script src="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.js" type="text/javascript"></script>
    <link href="../../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.css" rel="stylesheet" type="text/css" />

    <link href="../../../Content/CSSes/ActResStyles.css" rel="stylesheet" />
</asp:Content>

<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    <asp:Literal ID="lblPageTitle" runat="server"></asp:Literal>
</asp:Content>

