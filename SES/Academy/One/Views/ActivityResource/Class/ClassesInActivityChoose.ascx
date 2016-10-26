<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassesInActivityChoose.ascx.cs" Inherits="One.Views.ActivityResource.Class.ClassesInActivityChoose" %>

<%--<div class="data-entry-section">--%>
<br />
<div class="data-entry-section-heading">
    Classes
</div>
<hr />
<div class="data-entry-section-body">
    <table>
        <tr>
            <td class="data-type">Post to class *
            </td>
            <td class="data-value">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel runat="server" ID="pnlClasses" CssClass="panel-with-border"></asp:Panel>
                        <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True"
                            Height="23px" Width="150px"
                            OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"
                            DataTextField="Name" DataValueField="Id">
                        </asp:DropDownList>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
</div>

<%-- </div> --%>