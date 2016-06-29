<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ResourceCreate.ascx.cs" Inherits="One.Views.Resource.ResourceCreate" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<%--<h4>Create Resource</h4>--%><%--<asp:Panel ID="pnlDropDown" runat="server" Visible="False">
    <asp:DropDownList ID="ddResSelected" runat="server" Height="17px" Width="136px"></asp:DropDownList>
    <asp:Button ID="btnCreateNew" runat="server" Text="Create New" OnClick="btnCreateNew_Click" />
</asp:Panel>--%>
<asp:Panel ID="uploadMsg" runat="server">
    <%=uploadMessage %>
</asp:Panel>


<asp:Panel ID="pnlForm" runat="server">
    <fieldset>
        <legend>Create Resource &nbsp; (<asp:Label ID="lblParentBtnName" runat="server" Text="_"></asp:Label>)</legend>
        <div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:HiddenField ID="clkdByDDLName" runat="server" />

                    <div>
                        <fieldset>
                            <legend>Resource</legend>
                            <table>
                                <tr>
                                    <td>Title</td>
                                    <td>
                                        <asp:TextBox ID="txtName" runat="server" Width="188px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="txtNameValidator" runat="server"
                                            ErrorMessage="Name is required."
                                            ControlToValidate="txtName" ForeColor="#FF6600"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Ca</td>
                                </tr>
                            </table>
                        </fieldset>
                    </div>

                    <asp:Label ID="lbl1" runat="server" Text="Name"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    
                    <br />
                    <asp:Label ID="Label3" runat="server" Text="Subject"></asp:Label>
                    &nbsp;&nbsp;
                <asp:DropDownList ID="cmbSubject" runat="server" Height="20px" Width="194px" AutoPostBack="True">
                </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Category"></asp:Label>
                    &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtCategory" runat="server" Width="166px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Access Permission"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:DropDownList ID="cmbAccessPermission" runat="server" Height="16px" Width="194px">
                    </asp:DropDownList>
                    <asp:Label ID="Label6" runat="server" Font-Size="Smaller" Text="Please see FAQ for the description of each permission type"></asp:Label>
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div style="width: 49%;">
                        <fieldset>
                            <legend>Files</legend>
                            &nbsp;Multiple files can be uploaded in each.&nbsp;
                            <br />
                            <asp:FileUpload ID="fileUp1" runat="server" AllowMultiple="True" />
                            <br />
                            <asp:FileUpload ID="fileUp2" runat="server" AllowMultiple="True" />
                            <br />
                            <asp:FileUpload ID="fileUp3" runat="server" AllowMultiple="True" />
                            <br />
                        </fieldset>
                    </div>

                    <br />
                    <div style="width: 49%;">
                        <fieldset>
                            <legend>Links Useful for this Resource</legend>
                            <asp:Label ID="Label2" runat="server" Text="Separate the links with comma (,) or return key&nbsp;&nbsp;"></asp:Label>
                            <asp:TextBox ID="txtLink" runat="server" Height="85px" Width="381px" TextMode="MultiLine"></asp:TextBox>

                        </fieldset>
                    </div>
                    <br />
                    <div style="width: 100%;">
                        Notes<br />
                        <asp:TextBox ID="txtNote" runat="server" Height="94px" Width="378px" TextMode="MultiLine"></asp:TextBox>
                        <%--<br />--%>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </fieldset>
</asp:Panel>
<asp:Panel ID="pnlSave" runat="server">
    <br />
    &nbsp;&nbsp;
    <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" />
    &nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" CausesValidation="false" />
    <br />
</asp:Panel>
