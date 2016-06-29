<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TreeViewUC.ascx.cs" Inherits="One.Views.Exam.Exam.Create.EachNodeOfAssign.TreeViewUC" %>
<%--<%@ Register Src="../../StudentClass/StudentEntry.ascx" TagName="StudentEntry" TagPrefix="uc1" %>--%>
<%--<%@ Register assembly="One" namespace="One.Views.AcademicPlacement.RunningClass.CheckBoxOnly" tagprefix="uc1" %>--%>
<%--<%@ Register TagPrefix="uc1" Namespace="One.Views.AcademicPlacement.RunningClass.CheckBoxOnly" Assembly="One" %>--%>
<%@ Register Src="~/Views/Exam/Exam/Create/EachNodeOfAssign/TreeNodeUC.ascx" TagPrefix="uc2" TagName="TreeNodeUC" %>
<%--<%@ Register TagPrefix="uc1" Namespace="One.Views.AcademicPlacement.RunningClass.CheckBoxOnly" Assembly="One" %>--%>


<div>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlStudentEntry" runat="server" Visible="False" Style="position: absolute; top: 124px; left: 315px; width: 242px">
                <%--<uc1:StudentEntry ID="StudentEntry1" runat="server" />--%>
            </asp:Panel>

            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">PostBack</asp:LinkButton>
            <table>
                <%--<tr>
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
                        <asp:DropDownList ID="cmbSession" runat="server" Height="20px" Width="120px" OnSelectedIndexChanged="cmbSession_SelectedIndexChanged"></asp:DropDownList>
                         <asp:RequiredFieldValidator ID="valiSession" runat="server"
                                ErrorMessage="Required" ForeColor="#FF3300" ControlToValidate="cmbSession"></asp:RequiredFieldValidator>
                       </td>
                </tr>--%>
            </table>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <uc2:TreeNodeUC runat="server" ID="Root" />
                </ContentTemplate>
            </asp:UpdatePanel>

            <br />
            <%--<uc2:TreeNodeUC runat="server" id="TreeNodeUC1" />--%>
            &nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" Width="74px" />
             &nbsp;&nbsp;
              <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ErrorMessage="Required fields not filled." ForeColor="#FF3300" ControlToValidate="cmbSession"></asp:RequiredFieldValidator>
                  --%>    
            <br />

            <br />
            <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
            <asp:HiddenField ID="hidAcademicYear" runat="server" Value="0" />
            <asp:HiddenField ID="hidSessionId" runat="server" Value="0" />
            <asp:HiddenField ID="hidX" runat="server" Value="0" ClientIDMode="Static" />
            <asp:HiddenField ID="hidY" runat="server" Value="0" ClientIDMode="Static"/>
            <asp:HiddenField ID="hidExamId" runat="server" Value="0"/>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
