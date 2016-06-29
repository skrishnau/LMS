<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TreeViewUC.ascx.cs" Inherits="One.Views.AcademicPlacement.Master.ListingUserControls.TreeViewUC" %>
<%--<%@ Register Src="../../StudentClass/StudentEntry.ascx" TagName="StudentEntry" TagPrefix="uc1" %>--%>
<%--<%@ Register assembly="One" namespace="One.Views.AcademicPlacement.RunningClass.CheckBoxOnly" tagprefix="uc1" %>--%>
<%--<%@ Register TagPrefix="uc1" Namespace="One.Views.AcademicPlacement.RunningClass.CheckBoxOnly" Assembly="One" %>--%>
<%@ Register Src="~/Views/AcademicPlacement/Master/ListingUserControls/TreeNodeUC.ascx" TagPrefix="uc2" TagName="TreeNodeUC" %>
<%--<%@ Register Src="~/Views/AcademicPlacement/StudentClass/StudentEntry.ascx" TagPrefix="uc2" TagName="StudentEntry" %>--%>
<%@ Register Src="~/Views/AcademicPlacement/StudentClass/BatchSelectUc.ascx" TagPrefix="uc1" TagName="BatchSelectUc" %>


<%--<%@ Register TagPrefix="uc1" Namespace="One.Views.AcademicPlacement.RunningClass.CheckBoxOnly" Assembly="One" %>--%>




<div>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
    <%-- <asp:Panel ID="pnlStudentEntry" runat="server" Visible="False" Style="position: absolute; top: 124px; left: 315px; width: 242px">
                <uc1:StudentEntry ID="StudentEntry1" runat="server" />
            </asp:Panel>--%>

    <%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">PostBack</asp:LinkButton>--%>
    <table>
        <tr>

            <td>Academic Year</td>
            <td>
                <asp:DropDownList ID="cmbAcademicYear" runat="server" Height="20px" Width="120px" AutoPostBack="True" OnSelectedIndexChanged="cmbAcademicYear_SelectedIndexChanged"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="valiAca" runat="server" ErrorMessage="Required"
                    ForeColor="#FF3300" ControlToValidate="cmbAcademicYear"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Session</td>
            <td>
                <asp:DropDownList ID="cmbSession" runat="server" Height="20px" Width="120px" OnSelectedIndexChanged="cmbSession_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="valiSession" runat="server"
                    ErrorMessage="Required" ForeColor="#FF3300" ControlToValidate="cmbSession"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlSwitchSubYear" runat="server" Enabled="False">
        Switch SubYears: &nbsp;
                <asp:DropDownList ID="cmbSubYearSwitch" runat="server" AutoPostBack="True" Height="20px"
                    OnSelectedIndexChanged="cmbSubYearSwitch_SelectedIndexChanged" Width="100px" ToolTip="This uses Position property of Subyear">
                </asp:DropDownList>
    </asp:Panel>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <uc2:TreeNodeUC runat="server" ID="Root" />
            <br />
            <%--<uc2:TreeNodeUC runat="server" id="TreeNodeUC1" />--%>
            &nbsp;
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="74px" OnClick="btnSave_Click" />
            &nbsp;&nbsp;
              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                  ErrorMessage="Required fields not filled." ForeColor="#FF3300" ControlToValidate="cmbSession"></asp:RequiredFieldValidator>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="Update1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlStudentEntry" runat="server" CssClass="popup" Visible="False">
                <div class="popup-background">_</div>
                <asp:Panel ID="innerpanel" runat="server" CssClass="popup whiteBackground">
                    <uc1:BatchSelectUc runat="server" ID="StudentEntry1" />
                </asp:Panel>

            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>


    <br />
    <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
    <asp:HiddenField ID="hidAcademicYear" runat="server" Value="0" />
    <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />
    <%-- <asp:HiddenField ID="hidX" runat="server" Value="0" ClientIDMode="Static" />
        <asp:HiddenField ID="hidY" runat="server" Value="0" ClientIDMode="Static" />--%>

    <%-- CssClass="popup-background" --%>
    <%--<asp:Panel ID="pnlStudentEntry" runat="server"  Visible="False">
               
                <div class="popup grayBackGround">
                    <uc2:StudentEntry runat="server" ID="StudentEntry1" />
                </div>
            </asp:Panel>--%>
    <%--</ContentTemplate>
    </asp:UpdatePanel>--%>


    <%-- <div class="popup">
        <asp:PlaceHolder ID="pnlBatchSelect" runat="server" Visible="False">
            <uc1:BatchSelectUc runat="server" ID="BatchSelectUc1" />
        </asp:PlaceHolder>
    </div>--%>
</div>



