<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="One.Views.Structure.All.Master.List" %>

<%@ Register Src="~/Views/Structure/All/UserControls/CourseLinkage/CourseListUC.ascx" TagPrefix="uc1" TagName="CourseListUC" %>


<%-- ~/ViewsSite/UserSite.Master --%>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">Manage Programs
    </h3>
    <hr />

    <div style="float: right;">
        <asp:HyperLink ID="lnkEdit"  runat="server">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Edit/edit_orange.png" />
            <asp:Label ID="lblEdit" runat="server" Text="Edit"></asp:Label>
        </asp:HyperLink>

    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>

                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="viewProgramList" runat="server">
                        <div id="listStructureDiv" style="width: 100%;">

                           <%-- <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Views/Structure/All/Create.aspx" runat="server">Create</asp:HyperLink>
                            <br />--%>

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



                <%-- <br />
                <div class="float-left">
                    <div>
                        List of structure
                         <asp:TreeView ID="TreeView1" runat="server" ShowLines="True"></asp:TreeView>
                    </div>

                </div>
                <br />--%>
                <%-- ==================Start of Listing --%>


                <%--+Add Level--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hidEdit" runat="server" Value="0"/>

</asp:Content>


<asp:Content runat="server" ID="headcontent" ContentPlaceHolderID="title">
    <asp:Literal ID="lblTabHead" runat="server" Text="Manage programs"></asp:Literal>
</asp:Content>