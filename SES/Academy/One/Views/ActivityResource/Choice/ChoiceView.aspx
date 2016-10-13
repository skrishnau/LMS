<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ChoiceView.aspx.cs" Inherits="One.Views.ActivityResource.Choice.ChoiceView" %>

<%@ Register Src="~/Views/ActivityResource/Choice/ChoiceResponseView.ascx" TagPrefix="uc1" TagName="ChoiceResponseView" %>



<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div>
        <h3>
            <asp:Label ID="lblTitle" runat="server" Text=""></asp:Label>
        </h3>
        <%--<hr />--%>

        <div>
            <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
        </div>
        <hr/>
        
        <div>
            <asp:Panel ID="pnlOptions" runat="server"></asp:Panel>
        </div>
    </div>
    <div>
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="90px" />
    </div>
    
    
    <div style="margin-left: 15px;">
        <uc1:ChoiceResponseView runat="server" ID="ChoiceResponseView1" />
    </div>
     <div style="text-align: center; color:red">
        <asp:Label ID="lblMessage" runat="server" Text="" ></asp:Label>
    </div>


     <asp:HiddenField ID="hidChoiceId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidPageKey" runat="server" Value="0" />
    <asp:HiddenField ID="hidAllowMoreChoiceToBeSelected" runat="server" Value="False"/>
</asp:Content>

