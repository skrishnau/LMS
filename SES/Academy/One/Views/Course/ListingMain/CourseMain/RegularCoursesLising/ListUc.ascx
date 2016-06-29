<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListUc.ascx.cs" Inherits="One.Views.Course.ListingMain.CourseMain.RegularCoursesLising.ListUc" %>

<%@ Register Src="~/Views/Course/CourseCreate/CourseCreateUc.ascx" TagPrefix="uc1" TagName="CourseCreateUc" %>
<%@ Register Src="~/Views/Course/Category/Create.ascx" TagPrefix="uc1" TagName="Create" %>



<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="item-section-heading">
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </div>
            <div style="float: right; clear: both;">
               <%-- <asp:LinkButton ID="btnNewGroup" runat="server" OnClick="btnNewGroup_Click">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />&nbsp;New Subject
                </asp:LinkButton>--%>
                <div>
                    Add Subject &nbsp;&nbsp;
        <asp:DropDownList ID="cmbNewSubject" runat="server" AutoPostBack="True"
             OnSelectedIndexChanged="cmbNewSubject_SelectedIndexChanged">
            <Items>
                <asp:ListItem Value="0" Text=""></asp:ListItem>
                <asp:ListItem Value="1" Text="Create New"></asp:ListItem>
                <asp:ListItem Value="2" Text="Choose Existing"></asp:ListItem>
                <asp:ListItem Value="3" Text="Import"></asp:ListItem>
            </Items>
        </asp:DropDownList>
                </div>
            </div>



            <div style="clear: both;"></div>

            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <asp:View ID="View0" runat="server">
                    <div style="width: 100%; margin: 5px 20px 5px;">
                        <asp:PlaceHolder ID="pnlSubjects" runat="server"></asp:PlaceHolder>
                    </div>
                </asp:View>
                <%-- =============View 1 Course create=============== --%>
                <asp:View ID="View1" runat="server">

                    <uc1:CourseCreateUc runat="server" ID="CourseCreateUc" />
                </asp:View>

                <%-- =============View 2 Course Select=============== --%>
                <asp:View ID="View2" runat="server">
                </asp:View>
                
                <asp:View ID="View3" runat="server">
                </asp:View>
                
                <%-- ===============Category Crate================== --%>
                 <asp:View ID="View4" runat="server">
                    <uc1:Create runat="server" ID="CategoryCreate" />
                </asp:View>

            </asp:MultiView>


        </ContentTemplate>
    </asp:UpdatePanel>

    <%--<asp:HiddenField ID="hidSubjectGroupId" runat="server" Value="0" />--%>
    <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
    <asp:HiddenField ID="hidYearId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubYearId" runat="server" Value="0" />
</div>