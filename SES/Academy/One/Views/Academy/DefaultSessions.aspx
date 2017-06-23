<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="DefaultSessions.aspx.cs" Inherits="One.Views.Academy.DefaultSessions" %>


<asp:Content runat="server" ID="bodyContent" ContentPlaceHolderID="Body">
    <h3 class="heading-of-create-edit">Default Sessions
    </h3>

    <div>
        <div style="float: right;">
            <asp:HyperLink ID="lnkEdit" runat="server"
                NavigateUrl="~/Views/Academy/DefaultSessions.aspx?edit=1">Edit</asp:HyperLink>
        </div>
    </div>



    <div>
        <table>
            <%-- <tr>
                <td class="data-type" style="margin-left: -10px;"><strong>Academic year</strong></td>
                <td></td>
            </tr>--%>
            <tr>
                <td class="data-type">Session-1 Name *</td>
                <td class="data-value">
                    <asp:TextBox ID="txtNameSession1" runat="server" Width="145px" ToolTip="e.g. 'Fall' , 'Spring'"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ValidationGroup="save"
                        ControlToValidate="txtNameSession1" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <%-- <tr>
                <td class="data-type" style="margin-left: -10px;"><strong>Academic year</strong></td>
                <td></td>
            </tr>--%>
            <tr>
                <td class="data-type">Session-2 Name *</td>
                <td class="data-value">
                    <asp:TextBox ID="txtNameSession2" runat="server" Width="145px" ToolTip="e.g. 'Fall' , 'Spring'"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ValidationGroup="save"
                        ControlToValidate="txtNameSession2" ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>

            </tr>
        </table>
    </div>
    <div>
        <div runat="server" id="pnlSaveDiv" class="save-div">
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_OnClick"
                ValidationGroup="save"
                Text="Save" Width="163px" />
            &nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server"
                    Text="Cancel" OnClick="btnCancel_OnClick" Width="168px" />
            &nbsp;
                <asp:Label ID="lblError" runat="server" Text="Error while saving." ForeColor="red"></asp:Label>
        </div>


    </div>

    <asp:HiddenField ID="hidSession1Id" Value="0" runat="server" />
    <asp:HiddenField ID="hidSession2Id" Value="0" runat="server" />
</asp:Content>


<asp:Content runat="server" ID="headContent" ContentPlaceHolderID="head">
    <%--<link rel="stylesheet" href="../../../DatePickerJquery/jquery-ui-1.9.2.custom.css" />
    <script src="../../../DatePickerJquery/jquery-1.8.3.js"></script>--%>
    <%-- <script type="text/javascript" src="../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.min.js"></script>
    <script src="../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.js" type="text/javascript"></script>
    <link href="../../AjaxAspNetJquery/jquery-ui-1.12.0.custom/jquery-ui.css" rel="stylesheet" type="text/css" />--%>

    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />


</asp:Content>
