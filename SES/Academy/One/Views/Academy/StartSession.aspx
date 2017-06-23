<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="StartSession.aspx.cs" Inherits="One.Views.Academy.StartSession" %>

<%@ Register TagPrefix="uc1" TagName="sitemapuc" Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" %>
<%--<%@ Register Src="~/Views/Academy/CreateUc.ascx" TagPrefix="uc1" TagName="CreateUc" %>--%>



<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:sitemapuc runat="server" ID="SiteMapUc" />
</asp:Content>



<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-create-edit">Start new session
    </h3>
    <br />

    <div class="data-entry-section">
        <table>
            
             <tr>
                <td class="data-type">Current Session
                </td>
                <td class="data-value">
                    <asp:Label ID="lblCurrentSession" runat="server" Text="  -  "></asp:Label>
                    <%--<asp:TextBox ID="txtSemester1" runat="server" Width="160"></asp:TextBox>--%>
                    &nbsp;
                    <asp:Image ID="imgCurrentSession" runat="server"
                        Width="10" Height="10"
                        ImageUrl="~/Content/Icons/Start/active_icon_10px.png"
                        Visible="False" />

                  <%--  <asp:RequiredFieldValidator ID="reqValiSem1" runat="server" ErrorMessage="Required"
                        ControlToValidate="txtSemester1" ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            
            <tr>
                <td><strong>Next Session</strong></td>
            </tr>

            <tr>
                <td class="data-type">&nbsp;&nbsp;&nbsp;Academic year
                </td>
                <td class="data-value">
                    <asp:Label ID="lblAcademicYear" runat="server" Text=""></asp:Label>
                   <%-- <asp:TextBox ID="txtAcademicyear" runat="server" Width="160"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqValiAcademicyear" runat="server" ErrorMessage="Required"
                        ControlToValidate="txtAcademicyear" ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="data-type">&nbsp;&nbsp;&nbsp;Session-1
                </td>
                <td class="data-value">
                    <asp:Label ID="lblSemester1" runat="server" Text=""></asp:Label>
                    <%--<asp:TextBox ID="txtSemester1" runat="server" Width="160"></asp:TextBox>--%>
                    &nbsp;
                    <asp:Image ID="imgSem1" runat="server"
                        Width="16" Height="16"
                        ImageUrl="~/Content/Icons/Tick/Double Tick_16px.png"
                        Visible="False" />

                  <%--  <asp:RequiredFieldValidator ID="reqValiSem1" runat="server" ErrorMessage="Required"
                        ControlToValidate="txtSemester1" ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>
            <tr>
                <td class="data-type">&nbsp;&nbsp;&nbsp;Session-2
                </td>
                <td class="data-value">
                    <asp:Label ID="lblSemester2" runat="server" Text=""></asp:Label>
                    <%--<asp:TextBox ID="txtSemester2" runat="server" Width="160"></asp:TextBox>--%>
                    &nbsp;
                    <asp:Image ID="imgSem2" runat="server"
                        Width="16" Height="16"
                        ImageUrl="~/Content/Icons/Tick/Double Tick_16px.png"
                        Visible="False" />

                   <%-- <asp:RequiredFieldValidator ID="reqValiSem2" runat="server" ErrorMessage="Required"
                        ControlToValidate="txtSemester2" ValidationGroup="save"></asp:RequiredFieldValidator>--%>
                </td>
            </tr>


        </table>
    </div>
    <br />
    <div>
        <%--<uc1:CreateUc runat="server" id="CreateUc" />--%>
    </div>
    <br />
    <div class="data-entry-section">

        <div>
            <strong style="font-size: 16px;">Upcoming Classes</strong>
            &nbsp;&nbsp;
            
            <asp:Label ID="lblUpcomingSessionName" runat="server" Text=""></asp:Label>

        </div>
        <br />
        <div class="data-entry-section">

            <asp:Panel ID="pnlListing" runat="server"></asp:Panel>

        </div>
    </div>
    <br/>
    <div class="save-div">
        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_OnClick"
            ValidationGroup="save"
            Text="Save and Start session" Width="163px" />
        &nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server"
            Text="Cancel" OnClick="btnCancel_OnClick" Width="168px" />
        &nbsp;
        <asp:Label ID="lblError" runat="server" Text="Error while saving." ForeColor="red"></asp:Label>

    </div>


    <asp:HiddenField ID="hidAcademicYearId" Value="0" runat="server" />
    <asp:HiddenField ID="hidCurrentlyActiveSessionId" Value="0" runat="server" />
    <asp:HiddenField ID="hidNextActivatingSessionId" Value="0" runat="server" />



</asp:Content>

<asp:Content runat="server" ID="content4" ContentPlaceHolderID="title">
    Start new Session
</asp:Content>

<asp:Content runat="server" ID="content2" ContentPlaceHolderID="head">
    

    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />


    <script type="text/javascript" src="../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.min.js"></script>
    <script src="../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.js" type="text/javascript"></script>
    <link href="../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.css" rel="stylesheet" type="text/css" />


    <script>
        function pageLoad() {

            $("#txtStart").unbind();
            $("#txtStart").datepicker();
            $("#txtEnd").unbind();
            $("#txtEnd").datepicker();
        }


    </script>

    <%-- <style type="text/css">
        .cell-width {
            width: 75px;
        }

        .auto-style1 {
            width: 104px;
        }
    </style>--%>
</asp:Content>
