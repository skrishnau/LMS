<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="One.Views.Structure.All.Master.List" %>

<%@ Register Src="~/Views/Structure/All/UserControls/CourseLinkage/CourseListUC.ascx" TagPrefix="uc1" TagName="CourseListUC" %>


<%-- ~/ViewsSite/UserSite.Master --%>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>

                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="viewProgramList" runat="server">
                        <div id="listStructureDiv" style="width: 100%;">

                            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Views/Structure/All/Create.aspx" runat="server">Create</asp:HyperLink>
                            <br />

                            <asp:PlaceHolder ID="pnlListing" runat="server"></asp:PlaceHolder>
                        </div>
                    </asp:View>

                    <asp:View ID="viewCourseList" runat="server">
                        <div>
                            <uc1:CourseListUC runat="server" ID="CourseListUC" />
                        </div>
                    </asp:View>
                    <asp:View ID="View3" runat="server">
                    </asp:View>
                </asp:MultiView>




                <%--<div class="float-left">
        <div>
            List of structure
            <asp:TreeView ID="TreeView1" runat="server" ShowLines="True"></asp:TreeView>
        </div>

    </div>--%>
                <%-- ==================Start of Listing --%>


                <%--+Add Level--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
