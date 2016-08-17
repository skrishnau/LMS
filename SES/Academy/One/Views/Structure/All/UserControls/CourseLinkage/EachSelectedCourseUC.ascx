<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EachSelectedCourseUC.ascx.cs" Inherits="One.Views.Structure.All.UserControls.CourseLinkage.EachSelectedCourseUC" %>


<div runat="server" id="divEachSelectedCourse" clientidmode="Static" style="margin: 1px 3px 2px; padding: 1px;">

    <div style="float: left; width: 100%; display: block; border: 1px solid darkgray; width: 88%;">
        <div style="position: absolute;   right:0">
            <asp:ImageButton CssClass="undo-delete-transparancy" ID="imgbtn" runat="server" Visible="False"
                Height="20px" ImageUrl="~/Content/Icons/delete/undo_delete.png"
                OnClick="imgbtn_Click" />
        </div>
        <asp:Label ID="lblSubjectName" runat="server" Text=""></asp:Label>

    </div>
    <div style="float: left; width: 16px;">
        <asp:ImageButton ID="btnRemove" runat="server"
            ImageUrl="~/Content/Icons/Close/dialog_close.png"
            OnClick="btnRemove_Click" />
    </div>
    <div style="clear: both;"></div>
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectStructureId" runat="server" Value="0" />

</div>
