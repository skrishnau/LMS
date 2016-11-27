<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="GradeListing.aspx.cs" Inherits="One.Views.Grade.GradeListing" %>



<asp:Content runat="server" ID="bodyId" ContentPlaceHolderID="Body">
    <div>
        <h3 class="heading-of-listing">Grade List
        </h3>
        <hr />
        <div style="text-align: right;">
            <asp:HyperLink ID="lnkAddGrade" runat="server" CssClass="link_smaller"
                NavigateUrl="~/Views/Grade/GradeCreate.aspx">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                New Grade Type
            </asp:HyperLink>
        </div>
        <div class="data-entry-section-body">
            <asp:DataList ID="DataList1" runat="server">
                <ItemTemplate>
                    <div>
                        ● 
                        <asp:HyperLink ID="Label1" CssClass="link" runat="server" Text='<%#  Eval("Name") %>'
                            Font-Bold="True"
                            NavigateUrl='<%# "~/Views/Grade/GradeDetail.aspx?gId="+Eval("Id") %>'>
                        </asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
