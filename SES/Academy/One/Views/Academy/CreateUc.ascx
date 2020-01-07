<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreateUc.ascx.cs" Inherits="One.Views.Academy.CreateUc" %>


<div class="data-entry-section">
    <h3 class="heading-of-create-edit">
        <asp:Label ID="lblHeading" runat="server" Text="Academic year edit"></asp:Label>
    </h3>
    <hr />

    <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />


    <div class="data-entry-section-body">
        <table>
            <tr>
                <td class="data-type" style="margin-left: -10px;"><strong>Academic year</strong></td>
                <td></td>
            </tr>
            <tr>
                <td class="data-type">Academic year Name *</td>
                <td class="data-value">
                    <asp:TextBox ID="txtName" runat="server" Width="145px" ToolTip="Usually its year. e.g. 2016"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtName" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>

            </tr>


            <tr>
                <td class="data-type">Start Date *</td>
                <td class="data-value">
                    <asp:TextBox ID="txtStart" runat="server" ClientIDMode="Static"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="valiStartDate" runat="server"
                        ControlToValidate="txtStart" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>

                </td>
            </tr>
            <tr>
                <td class="data-type">End Date *</td>
                <td class="data-value">
                    <asp:TextBox ID="txtEnd" runat="server" ClientIDMode="Static"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="valiEndDate" runat="server"
                        ControlToValidate="txtEnd" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>

                </td>
            </tr>


            <tr>
                <td></td>
            </tr>
            <tr>
                <td class="data-type" style="margin-left: -10px;"><strong>New Batch</strong></td>
            </tr>

            <tr>
                <td class="data-type">Batch Name *</td>
                <td class="data-value">
                    <asp:TextBox ID="txtBatchName" runat="server" Width="145px" ToolTip="new batch that will be admitted in this academic year"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="txtBatchName" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <%--<tr>
                    <td class="data-type">
                        <div class="data-entry-section-body data-entry-section-no-margin"><strong>Programs to include in this batch</strong></div>
                    </td>
                </tr>--%>
            <tr></tr>


            <tr>
                <td>
                    <%--<div class="data-entry-section-heading">--%>
                    <div class="data-entry-section-no-margin"
                        style="margin-bottom: 10px; margin-left: -10px;">
                        <strong>Programs to include in this batch</strong>
                    </div>
                    <div class="data-entry-section-body">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div style="margin-left: -10px;">
                                    <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="True" Text="Select all" OnCheckedChanged="chkSelectAll_CheckedChanged" />
                                </div>
                                <asp:CheckBoxList ID="CheckBoxList1" runat="server"></asp:CheckBoxList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <%--<uc1:TreeViewWithCheckBoxInLeft runat="server" ID="TreeViewWithCheckBoxInLeft" />--%>
                    </div>
                </td>
            </tr>



            <%--  <tr>
                <td colspan="5">
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Make this Current Academic Year." />
                    <em style="font-size: 12px;">Note: Previous Academic year will be disabled.</em>
                </td>
            </tr>--%>
        </table>

    </div>
    <br />
    <div>
        <div class="save-div">
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click"
                Text="Save and return" Width="163px" />
            &nbsp;&nbsp;
                <asp:Button ID="btnSaveAndAddSessions" runat="server"
                    Text="Save and Add Sessions" OnClick="btnSave_Click" Width="168px" />
            &nbsp;
                <asp:Label ID="lblError" runat="server" Text="Error while saving." ForeColor="red"></asp:Label>
        </div>


    </div>

    <asp:HiddenField ID="hidId" runat="server" Value="0" />

    <p>
    </p>

</div>


