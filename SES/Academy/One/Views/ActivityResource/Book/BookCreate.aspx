<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="BookCreate.aspx.cs" Inherits="One.Views.ActivityResource.Book.BookCreate" %>



<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Views/RestrictionAccess/Custom/RestrictionUC.ascx" TagPrefix="uc1" TagName="RestrictionUC" %>

<asp:Content runat="server" ID="headcontent1" ContentPlaceHolderID="head">
    <link href="../../RestrictionAccess/Custom/RestrictionStyles.css" rel="stylesheet" />
    <%--<link href="../../RestrictionAccess/Custom/RestrictionStyles.css" rel="stylesheet" />--%>
    <link href="../../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />
    <link href="../../../Content/CSSes/TableStyles.css" rel="stylesheet" />

</asp:Content>


<asp:Content runat="server" ID="contnet1" ContentPlaceHolderID="Body">

    <h3 class="heading-of-create-edit">
        <asp:Label ID="lblHeading" runat="server" Text="Book Edit"></asp:Label>
    </h3>
    <hr />

    <div class="panel panel-default">
        <div class="panel-heading">
            General
        </div>
        <div class="panel-body">
            <table>
                <tr>
                    <td class="data-type">Name</td>
                    <td class="data-value">
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">Description</td>
                    <td class="data-value">
                        <CKEditor:CKEditorControl ID="CKEditor1" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">Display discription on course page</td>
                    <td class="data-value">
                        <asp:CheckBox ID="chkDisplayDescription" runat="server" />
                    </td>
                </tr>

            </table>
        </div>
    </div>


    <div class="panel panel-default">
        <div class="panel-heading">
            Appearance
        </div>
        <div class="panel-body">
            <table>
                <tr>
                    <td class="data-type">Chapter formatting</td>
                    <td class="data-value">
                        <asp:DropDownList ID="ddlChapterFormatting" runat="server">
                            <Items>
                                <asp:ListItem Value="0" Text="None"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Numbers" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Bullets"></asp:ListItem>
                                <asp:ListItem Value="3" Text="indented"></asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">Style of Navigation</td>
                    <td class="data-value">
                        <asp:DropDownList ID="ddlStyleOfNavigation" runat="server">
                            <Items>
                                <asp:ListItem Value="0" Text="TOC only"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Images" Selected="True"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Text"></asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
    </div>

    <div class="panel panel-default">
        <div class="panel-heading">
            Restriction
        </div>
        <div class="panel-body">
            <uc1:RestrictionUC runat="server" ID="RestrictionUC" />
        </div>
    </div>


    <div class="save-div">
        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
        &nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_OnClick" />
        &nbsp; &nbsp;
                <asp:Label ID="lblError" runat="server" Text="Error on input" ForeColor="red"></asp:Label>
    </div>

    <asp:HiddenField ID="hidBookId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />

    <script type="text/javascript">
        CKEDITOR.replace(CKEditor1,
            {
                enterMode: CKEDITOR.ENTER_DIV

            });
        //var d = function () {

        //    CKEDITOR.config. = ;
        //};


    </script>
</asp:Content>

<asp:Content runat="server" ID="titleContnet" ContentPlaceHolderID="title">
    Book edit
</asp:Content>

