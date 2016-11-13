<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="One.Views.Academy.List" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div>
        <div style="text-align: center; font-size: 1.3em;">
            <strong>Academic Year List</strong>
            <hr />
        </div>


        <%-- --------------Menu------------- --%>
        <div class="menu" style="clear: both; margin: 20px 5px; padding: 10px;">
            <div style="float: left;">
                <asp:Button ID="btnAutoUpdate" Enabled="False" Visible="False"
                    runat="server" Height="27px"
                    Text="Auto update to next Academic year/ Session" OnClick="btnAutoUpdate_Click" />

            </div>
            <div style="float: right;">
                <asp:HyperLink ID="lnkAdd" runat="server" Visible="False"
                     NavigateUrl="~/Views/Academy/AcademicYear/AcademyCreate.aspx">
                <asp:Image runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png"/>
                        New Academic Year
                </asp:HyperLink>
                &nbsp;&nbsp;&nbsp;
            <%--<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">New Session</asp:LinkButton>--%>
            </div>
        </div>
        <br />
        <%-- ------------END of Menu --%>


        <div style="clear: both;">
            <asp:Panel ID="pnlAcademicYearListing" runat="server"></asp:Panel>
        </div>


    </div>
</asp:Content>

<asp:Content runat="server" ID="contnettitle" ContentPlaceHolderID="title">
    Academic year list
</asp:Content>
