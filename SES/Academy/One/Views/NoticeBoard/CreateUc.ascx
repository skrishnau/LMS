<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateUc.ascx.cs" Inherits="One.Views.NoticeBoard.CreateUc" %>


<asp:Panel ID="pnlDataList" runat="server">

    <asp:LinkButton ID="btnNew" runat="server" OnClick="btnNew_Click">New</asp:LinkButton>
    <asp:DataList ID="DataList1" runat="server" Width="100%"
        DataSourceID="ObjectDataSource1" OnCancelCommand="DataList1_CancelCommand"
        OnEditCommand="DataList1_EditCommand"
        OnUpdateCommand="DataList1_UpdateCommand"
        OnDeleteCommand="DataList1_DeleteCommand"
        OnItemCommand="DataList1_ItemCommand" DataKeyField="Id">
        <ItemTemplate>
            <div style="margin: 8px; border: 1px solid lightgray;">
                <asp:HiddenField ID="IdLabel" runat="server" Value='<%# Eval("Id") %>' />
                <strong style="font-size: 1.2em; padding: 2px 5px 3px;">
                    <asp:Label ID="HeadiingLabel" runat="server" Text='<%# Eval("Headiing") %>' />
                </strong>
                <div style="margin-left: 20px">
                    <div style="margin: 0 20px 0 0; font-family: monospace; overflow: auto; width: 100%; border: 1px solid lightgray;">
                        <asp:Literal ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                    </div>
                    <asp:HiddenField ID="CreatedByIdLabel" runat="server" Value='<%# Eval("CreatedById") %>' />

                    <strong style="font-size: 0.9em">Created By:
                    </strong>
                    <asp:Label ID="CreatedByLabel" runat="server" Text='<%# GetUsersName(Eval("CreatedBy")) %>' />
                    <br />
                    <strong style="font-size: 0.9em">Created Date:
                    </strong>
                    <asp:Label ID="CreatedDateLabel" runat="server" Text='<%# Eval("CreatedDate") %>' />
                    &nbsp;&nbsp;
            <strong style="font-size: 0.9em">UpdatedDate:
            </strong>
                    <asp:Label ID="UpdatedDateLabel" runat="server" Text='<%# Eval("UpdatedDate") %>' />
                    <%--<br />
        ViewerLimited:
        <asp:Label ID="ViewerLimitedLabel" runat="server" Text='<%# Eval("ViewerLimited") %>' />--%>
                    <br />
                    <asp:LinkButton ID="lblEdit" runat="server" CommandName="edit">Edit</asp:LinkButton>
                    &nbsp;&nbsp;
            <asp:LinkButton ID="lblDelete" runat="server" CommandName="item">Delete</asp:LinkButton>
                </div>
            </div>
        </ItemTemplate>
        <EditItemTemplate>
            <div style="margin: 10px 25px 10px;">
                <asp:Label ID="lblUpdateErrorMsg" runat="server" Text="Sorry! Couldn't Save." Visible="False"  BackColor="#FF3300"  ></asp:Label>
                <asp:HiddenField ID="hidId" runat="server" Value='<%# Eval("Id") %>' />
                <table>
                    <tr>
                        <td>Heading
                        </td>
                        <td>
                            <asp:TextBox ID="txtHeading" runat="server" Text='<%# Eval("Headiing") %>' />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtHeading"
                                runat="server" ErrorMessage="Can't be empty." ValidationGroup="editValidation"
                                BackColor="#FF3300"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>Description
                        
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description") %>' TextMode="MultiLine" Height="50px" />
                        </td>
                    </tr>
                </table>



                <%--<asp:HiddenField ID="CreatedByIdLabel" runat="server" Value='<%# Eval("CreatedById") %>' />--%>
                <%--CreatedBy:
        <asp:Label ID="CreatedByLabel" runat="server" Text='<%# Eval("CreatedBy") %>' />
        <br />--%>
                <%-- CreatedDate: 
        <asp:Label ID="CreatedDateLabel" runat="server" Text='<%# Eval("CreatedDate") %>' />
        <br />--%>
                <%--UpdatedDate:--%>
                <%--<asp:HiddenField ID="UpdatedDateLabel" runat="server" Value='<%# Eval("UpdatedDate") %>' />--%>

                <asp:Button ID="btnUpdate" ValidationGroup="editValidation" runat="server" Text="Update" CommandName="update" />&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CommandName="cancel" CausesValidation="False" />
                <%-- <br />
        ViewerLimited:
        <asp:Label ID="ViewerLimitedLabel" runat="server" Text='<%# Eval("ViewerLimited") %>' />
        <br />--%>
                <br />
            </div>
        </EditItemTemplate>
        <SelectedItemStyle BackColor="#CCCCFF" BorderColor="#6600FF" BorderStyle="Solid" BorderWidth="1px" />
        <SelectedItemTemplate>

            <div style="margin: 8px; border: 1px solid lightgray;">
                <asp:HiddenField ID="IdLabel" runat="server" Value='<%# Eval("Id") %>' />
                <strong style="font-size: 1.2em; padding: 2px 5px 3px;">
                    <asp:Label ID="HeadiingLabel" runat="server" Text='<%# Eval("Headiing") %>' />
                </strong>
                <div style="margin-left: 20px">
                    <div style="font-family: monospace">
                        <asp:Literal ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                    </div>
                    <asp:HiddenField ID="CreatedByIdLabel" runat="server" Value='<%# Eval("CreatedById") %>' />

                    <strong style="font-size: 0.9em">Created By:
                    </strong>
                    <asp:Label ID="CreatedByLabel" runat="server" Text='<%# GetUsersName(Eval("CreatedBy")) %>' />
                    <br />
                    <strong style="font-size: 0.9em">Created Date:
                    </strong>
                    <asp:Label ID="CreatedDateLabel" runat="server" Text='<%# Eval("CreatedDate") %>' />
                    &nbsp;&nbsp;
            <strong style="font-size: 0.9em">UpdatedDate:
            </strong>
                    <asp:Label ID="UpdatedDateLabel" runat="server" Text='<%# Eval("UpdatedDate") %>' />
                    <%--<br />
                ViewerLimited:
                <asp:Label ID="ViewerLimitedLabel" runat="server" Text='<%# Eval("ViewerLimited") %>' />--%>
                    <br />
                    <%--<asp:LinkButton ID="lblEdit" runat="server" CommandName="edit">Edit</asp:LinkButton>
                    --%>
                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="delete">Delete</asp:LinkButton>
                    &nbsp;&nbsp;
                <asp:LinkButton ID="lblCancel" runat="server" CommandName="cancel">Cancel</asp:LinkButton>
                </div>
            </div>
        </SelectedItemTemplate>
    </asp:DataList>

</asp:Panel>

<asp:Panel ID="pblNew" runat="server" Visible="False">
    <div style="margin: 5px 20px 5px;">
        <strong>New Notice</strong>
        <asp:Label ID="lblErrorMsg" runat="server" Text="Sorry! Couldn't Save." BackColor="#FF3300" Visible="False"></asp:Label>
        <hr />
        <table>
            <tr>
                <td>Heading:
                </td>
                <td>
                    <asp:TextBox ID="txtHeading" runat="server" Text='<%# Eval("Headiing") %>' Width="336px" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtHeading"
                        runat="server" ErrorMessage="Can't be empty." ValidationGroup="newValidation"
                        BackColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>Description:
                </td>
                <td>
                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# Eval("Description") %>' TextMode="MultiLine" Height="50px" Width="344px" />
                </td>
            </tr>
        </table>
        <asp:Button ID="btnAddSave" ValidationGroup="newValidation" runat="server"
            Text="Save" OnClick="btnAddSave_Click" />&nbsp;&nbsp;
        <asp:Button ID="btnAddCancel" runat="server" Text="Cancel" CommandName="cancel" CausesValidation="False" OnClick="btnAddCancel_Click" />
    </div>
</asp:Panel>

<%--  InsertMethod="AddOrUpdateNotices"  UpdateMethod="AddOrUpdateNotices"--%>
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Academic.DbEntities.Notices.Notice"
    SelectMethod="GetNotices" TypeName="Academic.DbHelper.DbHelper+Notice">
    <SelectParameters>
        <asp:ControlParameter ControlID="hidUserId" DefaultValue="0" Name="userId" PropertyName="Value" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField ID="hidUserId" runat="server" Value="0" />
