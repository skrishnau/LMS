<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="TeacherNotAssignedClasses.aspx.cs" Inherits="One.Views.Class.TeacherNotAssignedClasses" %>


<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="content" ContentPlaceHolderID="Body">
    <h3 class="heading-of-create-edit">Classes without Teachers
    </h3>
    <br />

    <div class="data-entry-section-body">
        <div>
            <asp:DataList ID="DataList1" Width="100%" runat="server" CssClass="list-group">
                <ItemTemplate>
                    <%--<div class="list-item-datalist">--%>
                        <%-- CssClass="list-item-heading" --%>
                        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="list-group-item"
                            NavigateUrl='<%# "~/Views/Class/CourseClassDetail.aspx?ccId="+Eval("ClassId") %>'>

                            <asp:Label runat="server" ID="label11"
                                Text='<%# Eval("SubjectName")+" &nbsp; "+Eval("ClassName") %>'></asp:Label>
                            <div class="list-item-description">
                                Start Date : 
                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("StartDate") %>'></asp:Label>
                                &nbsp;&nbsp;|&nbsp;&nbsp;
                                End Date &nbsp; :
                                <asp:Label ID="Label2" runat="server" Text='<%# Eval("EndDate") %>'></asp:Label>
                            </div>

                        </asp:HyperLink>


                    <%--</div>--%>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="title">
    Classes without Teachers
</asp:Content>
