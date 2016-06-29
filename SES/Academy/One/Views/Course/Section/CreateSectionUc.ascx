<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateSectionUc.ascx.cs" Inherits="One.Views.Course.Section.CreateSectionUc" %>

<div style="margin-left: 30px; margin-bottom: 10px; width: 474px; background-color: lightgray;">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="float: left; border: 2px solid lightgray; padding: 2px 10px 10px; background-color: lightgray;">
                <%-- class="item  width-auto margin-large" up--%>
                <div class="float-right width-auto">
                    <asp:ImageButton ID="btnClose" runat="server" ImageUrl="~/Content/Icons/Close/dialog_close.png" OnClick="btnClose_Click" />
                </div>
                <fieldset style="width: 405px;">
                    <legend><strong>Add Course Section</strong></legend>


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
                </fieldset>
                <div class="float-right" style="padding-top: 10px;">
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save Section" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" Width="71px" />

                </div>
                <div class="float-left" style="padding-top: 10px;">
                    &nbsp;
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
