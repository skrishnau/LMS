<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="One.Views.Report.Default" %>

<asp:Content runat="server" ID="bodycontent" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">
        <asp:Label ID="Label1" runat="server" Text="Report"></asp:Label>
    </h3>
    <hr />
    <div>
        <h3 class="heading-of-display">
            <asp:Label ID="lblClassName" runat="server" Text=""></asp:Label>
        </h3>
        <h3 class="heading-of-display">
            <asp:Label ID="lblCourseName" runat="server" Text=""></asp:Label>
        </h3>
    </div>
    <br />

    <div class="data-entry-section">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="border: 1px solid lightgray;  padding: 10px;">
                    <div class="data-entry-section-heading">

                        <asp:LinkButton ID="lnkFilter" runat="server" OnClick="lnkFilter_OnClick" Enabled="False">
                            Filter
                             <asp:Image ID="imgFilter" runat="server" ImageUrl="~/Content/Icons/Arrow/arrow_right.png" />
                        </asp:LinkButton>
                        <hr />
                    </div>
                    <div style="padding-left: 10px;">
                        The grade calculation method needs review... range is not functioning well.
                        <asp:Panel ID="pnlFilter" runat="server" Visible="True">
                            <div>Attributes to include:</div>

                            <div>
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

                            <div style="margin-top: 5px;">
                                <div>Activities to include:</div>

                                <asp:CheckBoxList ID="chkActivities" runat="server"
                                    Enabled="False"
                                    DataTextField="Name" DataValueField="Id" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                                <%--<asp:PlaceHolder ID="pnlActivityCheck" runat="server"></asp:PlaceHolder>--%>
                            </div>

                            <div>
                                <asp:Button ID="btnLoad" runat="server" Text="Load" OnClick="btnLoad_OnClick" />
                            </div>
                        </asp:Panel>
                    </div>
                </div>
                <br />
                <div>
                    <asp:Table ID="tblStudents" runat="server" Width="99%">
                    </asp:Table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <br />

        <asp:HiddenField ID="hidSubjectClassId" runat="server" Value="0" />
    </div>
</asp:Content>



<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="title">
    <asp:Literal ID="lblPageTitle" runat="server" Text="Report"></asp:Literal>
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="head">
    <link href="../../Content/CSSes/ToolTip.css" rel="stylesheet" />
    <style type="text/css">
        .span-padding {
            padding: 0 5px;
        }
    </style>
</asp:Content>
