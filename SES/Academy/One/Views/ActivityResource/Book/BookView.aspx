<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="BookView.aspx.cs" Inherits="One.Views.ActivityResource.Book.BookView" %>



<asp:Content runat="server" ID="contnet1" ContentPlaceHolderID="Body">
    <h3 class="heading-of-listing">
        <asp:Label ID="lblBookName" runat="server" Text=""></asp:Label>
    </h3>
    <div class="data-entry-section-body">
        <asp:Label ID="lblBookDescription" runat="server" Text=""></asp:Label>        
    </div>
    <div>
        <table>
            <tr>
                <td id="toc_cell" runat="server" style="max-height: 100%; overflow: auto;" class="data-detail" >
                    <h6 class="heading-of-listing">
                        Table of Content
                    </h6>
                    <asp:PlaceHolder ID="pnlToc" runat="server"></asp:PlaceHolder>
                </td>
                <td style="vertical-align: central;">
                    
                </td>
                <td id="content_cell" runat="server" style="display: inline-block; vertical-align: top; overflow-y: auto;">
                    <asp:Panel ID="pnlContent" runat="server"></asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    <asp:HiddenField ID="hidBookId" runat="server"  Value="0"/>
</asp:Content>