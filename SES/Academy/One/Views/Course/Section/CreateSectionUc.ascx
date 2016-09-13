<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateSectionUc.ascx.cs" Inherits="One.Views.Course.Section.CreateSectionUc" %>

<div style="width: 500px;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <%-- class="item  width-auto margin-large" up--%>
               <%-- <div >
                    <asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/Content/Icons/Close/dialog_close.png" OnClick="btnClose_Click" />
                </div>--%>


                <table>
                    <tr>
                        <td>Name</td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Description</td>
                        <td>
                            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="73px" Width="220px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>Show Description on Page</td>
                        <td>
                            <asp:CheckBox ID="chkShow" runat="server" />
                        </td>
                    </tr>

                </table>

                <strong>
                    <asp:LinkButton ID="lnkAccessPermission" runat="server" CausesValidation="False" OnClick="lnkAccessPermission_Click">Access Permission</asp:LinkButton>
                </strong>

                <asp:Panel ID="pnlAccessPermission" runat="server" Visible="False">
                    &nbsp;&nbsp;

            <asp:Button ID="btnAddPermission" runat="server" Text="Add" />
                </asp:Panel>
                <br />

                <br />
                <div style="padding-top: 10px;">
                </div>
                <div style="padding-top: 10px;">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save Section" />
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Width="71px" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnDelete" runat="server" Text="Delete this Section" OnClick="btnDelete_Click" Visible="false" />

                </div>
                <br />
                <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
            </div>
            <div>
                <%-- Section Listing --%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
