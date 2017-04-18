<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="DeleteForm.aspx.cs" Inherits="One.Views.All_Resusable_Codes.Delete.DeleteForm" %>

<asp:Content runat="server" ID="bodycontent" ContentPlaceHolderID="Body">
    <div style="border: 2px solid lightgray; margin: 20px; padding: 10px;">
        <table>
            <tr>
                <td style="vertical-align: top;">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Content/Icons/Exclamation/warning.png" />
                </td>
                <td>
                    <h3 class="heading-of-create-edit" style="margin-top: 0px;">
                        <asp:Label ID="lblHeading1" runat="server" Text="Delete"></asp:Label>
                    </h3>
                    <div class="data-entry-section-body">
                        <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Exclamation/warning.png" />--%>
                        <asp:Label ID="lblInfoText" runat="server" Text="Are you sure to delete"></asp:Label>
                        <br />
                        This can't be undone.
                    </div>
                    <br />
                    <div class="save-div">
                        <asp:Button ID="btnOk" runat="server" Text="Ok" Width="80" OnClick="btnOk_OnClick" />
                        &nbsp; &nbsp;
                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80" OnClick="btnCancel_OnClick" />
                    </div>
                    <div>
                        <asp:Label ID="lblError" runat="server" Text="Sorry, couldn't delete." ForeColor="red" Visible="False"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>
    </div>


    <%-- hidden fields --%>

    <asp:HiddenField ID="hidGivenId1" runat="server" Value="0" />
    <asp:HiddenField ID="hidGivenId2" runat="server" Value="0" />
    <asp:HiddenField ID="hidGivenId3" runat="server" Value="0" />
    <asp:HiddenField ID="hidGivenId4" runat="server" Value="0" />

    <asp:HiddenField ID="hidTask" runat="server" Value="" />

</asp:Content>



<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
</asp:Content>


<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="title">
    <asp:Literal ID="lblTitle" runat="server" Text="Delete"></asp:Literal>
</asp:Content>
