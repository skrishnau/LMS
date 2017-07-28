<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="SelfEnrolment.aspx.cs" Inherits="One.Views.Class.SelfEnrolment" %>


<%@ Register Src="~/Views/All_Resusable_Codes/Dialog/CustomDialog.ascx" TagPrefix="uc1" TagName="CustomDialog" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<%@ Register Src="~/Views/Course/Section/Master/ListOfSectionsInCourseUC.ascx" TagPrefix="uc1" TagName="ListOfSectionsInCourseUC" %>

<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="content" ContentPlaceHolderID="Body">
    <h3 class="heading-of-display">
        <asp:Label ID="lblCourseName" runat="server" Text=""></asp:Label>
    </h3>

    <div class="data-entry-section">
        <div>
            <div style="float: left;">
                <h3 class="heading-of-display">
                    <asp:Label ID="lblClassName" runat="server" Text=""></asp:Label>
                </h3>
            </div>

            <div style="clear: both;"></div>
        </div>
        <%--  class="data-entry-section" --%>
        <div>

            <table class="table-detail">
                <%-- <tr class="row-detail">
                    <td class="data-detail">Class Name</td>
                    <td>
                        <asp:Literal ID="lblFullName" runat="server"></asp:Literal>
                    </td>
                </tr>--%>
                <tr>
                    <td class="data-type">Start Date</td>
                    <td class="data-value">
                        <asp:Literal ID="lblStartDate" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">End Date</td>
                    <td class="data-value">
                        <asp:Literal ID="lblEndDate" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">
                        <asp:Label ID="lblJoinLstDateTitle" runat="server" Text="Last date to join"></asp:Label></td>
                    <td class="data-value">
                        <asp:Literal ID="lblJoinLastDate" runat="server"></asp:Literal>
                    </td>
                </tr>
                <%-- <tr>
                    <td class="data-type">Enrollment Method</td>
                    <td class="data-value">
                        <asp:Literal ID="lblEnrollmentMethod" runat="server"></asp:Literal>
                    </td>
                </tr>--%>

                <%--<tr>
                    <td class="data-type">Student Grouping
                    </td>
                    <td class="data-value">
                        <asp:Literal ID="lblGrouping" runat="server"></asp:Literal>
                        <div>
                        </div>
                    </td>
                </tr>--%>
            </table>
        </div>
        <br />
        <%-- style="text-align: center; vertical-align: bottom; float: left; padding-top: 8px; padding-left: 20px;" --%>
        <%-- style="text-align: center;"  CssClass="auto-st2 link"  --%>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="option-div">
                    <%--<asp:HyperLink ID="lnkReport" runat="server">View Report</asp:HyperLink>--%>
                    <asp:HyperLink ID="lnkViewCourse" runat="server" Visible="False">View Course</asp:HyperLink>
                    <asp:LinkButton ID="btnEnroll" runat="server" 
                        OnClick="btnEnroll_Click"
                        Visible="False">Enroll Now</asp:LinkButton>
                </div>
                <uc1:CustomDialog runat="server" ID="CustomDialog" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
    </div>

    <div class="data-entry-section-heading">
        Teachers
        <hr />
    </div>

    <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" Width="100%">
        <ItemTemplate>
            <div class="list-item-datalist">
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#  Bind("ImageUrl") %>'>
                    <asp:Image ID="Image1" runat="server" Height="40" Width="40" ImageUrl='<%#  Bind("ImageUrl") %>' />
                    <span style="line-height: 20px;">
                        <asp:Label ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                    </span>
                </asp:HyperLink>
            </div>
        </ItemTemplate>
    </asp:DataList>


    <div>
        <asp:Label ID="lbldNotice" runat="server"
            Visible="False">
            <asp:Image ID="imgNotice" runat="server" ImageUrl="~/Content/Icons/Notice/Warning_Shield_16px.png" />
            Teacher is not assigned to this class yet.
        </asp:Label>
    </div>
    <br />
    <div class="data-entry-section-heading">
        Course View
        <hr />
    </div>
    <div style="background-color: #f1f1f1; padding: 3px;">
        <div style="border: 1px solid lightgrey; background-color: white;">
            <uc1:ListOfSectionsInCourseUC runat="server" ID="ListOfSectionsInCourseUC" />
        </div>
    </div>

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListEnrolledTeachers"
        TypeName="Academic.DbHelper.DbHelper+Classes">
        <SelectParameters>
            <asp:ControlParameter ControlID="hidSubjectSessionId" DefaultValue="0" Name="subjectClassId" PropertyName="Value" Type="Int32" />
            <asp:ControlParameter ControlID="hidOrderby" DefaultValue="name" Name="orderBy" PropertyName="Value" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:HiddenField ID="hidSubjectSessionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidOrderby" runat="server" Value="crn" />

</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="title">
    <asp:Literal ID="lblTitle" runat="server"></asp:Literal>
</asp:Content>

<asp:Content runat="server" ID="content2" ContentPlaceHolderID="head">
    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />
    <link href="../../Content/CSSes/PanelStyles.css" rel="stylesheet" />
    <link href="../../Views/All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />

    <link href="../../Content/CSSes/ActResStyles.css" rel="stylesheet" />
</asp:Content>
