<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="AutoCompleteTest.aspx.cs" Inherits="One.TestingOnly.AutoCompleteTest" %>


<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="body">
    <%--<div>--%>
        <%--<asp:TextBox ID="txtContactsSearch" runat="server"></asp:TextBox>--%>
        <asp:TextBox runat="server" ID="txtContactsSearch"></asp:TextBox>

        <ajaxToolkit:AutoCompleteExtender ID="txtContactsSearch_AutoCompleteExtender" 
            runat="server" BehaviorID="txtContactsSearch_AutoCompleteExtender" ServiceMethod="SearchCustomers"
            DelimiterCharacters="" MinimumPrefixLength="2"  
            CompletionInterval="2000"
            TargetControlID="txtContactsSearch">
    </ajaxToolkit:AutoCompleteExtender>



    <%--<ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server" />--%>
        <%--<ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender2" runat="server"
             
            MinimumPrefixLength="2"
            CompletionInterval="100" EnableCaching="false" CompletionSetCount="10"
            FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>--%>

            
    <%--</div>TargetControlID="txtContactsSearch"--%>
</asp:Content>
