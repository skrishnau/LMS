<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="One.Views.Student.Batch.Student.Default" %>


<%@ Register Src="~/Views/Student/Batch/StudentDisplay/Students/StudentCreate/StudentCreateUc.ascx" TagPrefix="uc1" TagName="StudentCreateUc" %>
<%--<%@ Register Src="~/Views/Student/Batch/StudentDisplay/Students/StudentCreate/test.ascx" TagPrefix="uc1" TagName="test" %>--%>
<%--<%@ Register TagPrefix="uc1" TagName="studentlistuc" Src="~/Views/Student/Batch/StudentDisplay/Students/StudentListUc.ascx" %>--%>
<%@ Register Src="~/Views/Student/Batch/StudentDisplay/Students/StudentList/StudentListUC.ascx" TagPrefix="uc2" TagName="StudentListUC" %>
<%@ Register Src="~/Views/All_Resusable_Codes/Dialog/CustomDialog.ascx" TagPrefix="uc1" TagName="CustomDialog" %>
<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>


<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="body" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">
        <asp:Label ID="lblProgramBatchName" runat="server" Text=""></asp:Label>
    </h3>
    <div class="data-entry-section-body">
        <div runat="server" id="divYearsSubYears">
            <br />
            <div>
                <strong>Sessions</strong>
            </div>
            <div class="data-entry-section-link-listing">
                <asp:Panel ID="pnlYearsSubYears" runat="server"></asp:Panel>
            </div>
        </div>

    </div>

    <div class="data-entry-section-body">

        <div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="option-div" style="text-align: right;">
                        <asp:LinkButton ID="lnkAddStudent" runat="server" CssClass="link-button" OnClick="lnkAddStudent_OnClick">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                            <asp:Literal ID="lblAddText" runat="server" Text="Add student"></asp:Literal>
                        </asp:LinkButton>
                    </div>
                    <uc1:CustomDialog runat="server" ID="CustomDialog1" />

                    <div style="clear: both;"></div>
                    <br />
                    <uc2:StudentListUC runat="server" ID="StudentListUC11" />


                </ContentTemplate>
            </asp:UpdatePanel>

        </div>


        <%--
                Student create
                <div>
                <div>
                    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                        <asp:View ID="View0" runat="server">
                        </asp:View>
                        <asp:View ID="View1" runat="server">
                            <div style="text-align: center;">
                                <uc1:StudentCreateUc runat="server" ID="StudentCreateUc1" />
                            </div>
                        </asp:View>
                        <asp:View ID="View2" runat="server">
                            <uc1:StudentImportFromSystem runat="server" ID="StudentImportFromSystem" />
                        </asp:View>
                        <asp:View ID="View3" runat="server">
                            <uc1:StudentImportFrommFile runat="server" ID="StudentImportFrommFile" />
                        </asp:View>
                    </asp:MultiView>
                </div>
                <br />
            </div>--%>
        <%--    </ContentTemplate>
            </asp:UpdatePanel>--%>

        <%--<hr />--%>
        <%--<uc1:studentlistuc runat="server" ID="StudentListUc1" />--%>
    </div>

    <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
    <asp:HiddenField ID="hidProgramBatchId" runat="server" Value="0" />

</asp:Content>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link href="../../../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />

</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="title">
    <asp:Literal ID="lblTitle" runat="server">Students list</asp:Literal>
</asp:Content>






<%-- 
--%>





