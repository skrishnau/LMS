<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserEnrollUC_ListDisplay.ascx.cs" Inherits="One.Views.Class.Enrollment.UserEnrollUC_ListDisplay" %>


<div>
    <%@ Register Src="~/Views/UserControls/DateChooser.ascx" TagName="DateChooser" TagPrefix="uc1" %>
    <%-- <script type='text/javascript'>
        var scrollLeft = 0;
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

        function EndRequestHandler(sender, args) {
            document.getElementById('Button2').click();
            setScroll();
        }

        function setScroll() {
            document.getElementById('<%= lstAsg.ClientID %>').scrollLeft = scrollLeft;
        }
        function saveScroll() {
            scrollLeft = document.getElementById('<%= lstAsg.ClientID %>').scrollLeft;
         }
    </script>--%>



    <div style="margin: 5px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="main-div" id="maindiv">
                    <%--<asp:Button ID="btnLoad" runat="server" Text="Load" OnClick="btnLoad_Click" Width="82px" />--%>
                    <table style="margin: auto;">
                        <tbody style="vertical-align: top;">
                            <tr>
                                <td style="width: 32%;">Enrolled Users</td>
                                <td style="width: 18%;"></td>
                                <td style="width: 32%;">Not Enrolled Users</td>
                            </tr>
                            <tr>
                                <%-- =================== Left ===================== --%>


                                <td id="existingcell">
                                    <div>
                                        <div class="user-cell">
                                            <asp:ListBox ID="lstAsg" onscroll="javascript:saveScroll();" runat="server" Width="100%" Height="100%" DataTextField="FirstName" DataValueField="Id"></asp:ListBox>
                                        </div>
                                        <br />
                                        <div id="divUserEnrollId" class="user-enroll-search">
                                            <asp:Label ID="lblSearchEnroll" runat="server" Text="Search"></asp:Label>
                                            <br />
                                            <asp:TextBox ID="txtSearchEnroll" runat="server" Text=""></asp:TextBox>
                                            &nbsp;
                                            <asp:Button ID="btnClearEnroll" runat="server" Text="Clear" />
                                        </div>
                                    </div>
                                </td>

                                <%-- ====================== MId ==================== --%>
                                <td>
                                    <div style="text-align: center; margin: 10px 10px 0;">
                                        <div id="addcontrols" style="padding-bottom: 20px;">
                                            <asp:Button ID="btnAdd" runat="server" Text="◄ Add" Width="100px" OnClick="btnAsg_Click" />
                                            <br />
                                            <div id="enroll-option">
                                                <p>
                                                    <asp:Label ID="lblAssignRole" runat="server" Text="Assign Role"></asp:Label>
                                                    <br />
                                                    <asp:DropDownList ID="ddlAssignRole" runat="server" Height="22px" Width="120px"></asp:DropDownList>
                                                </p>
                                                <p>
                                                    <asp:Label ID="lblEnrollmentDuration" runat="server" Text="Enrollment Duration"></asp:Label>
                                                    <br />
                                                    <asp:DropDownList ID="ddlEnrollmentDuration" runat="server" Height="22px" Width="120px" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                                                </p>
                                                <p>
                                                    <asp:Label ID="lblStartingFrom" runat="server" Text="Starting From"></asp:Label>
                                                    <br />
                                                    <asp:DropDownList ID="ddlStartingFrom" runat="server" Height="22px" Width="120px" DataTextField="Name" DataValueField="Id">
                                                       
                                                    </asp:DropDownList>
                                                </p>
                                            </div>
                                        </div>
                                        <div id="removecoontrols">
                                            <asp:Button ID="Button1" runat="server" Text="Remove ►" Width="100px" OnClick="btnRemove_Click" />

                                        </div>
                                    </div>
                                </td>

                                <%-- ======================== right ==================== --%>
                                <td>
                                    <div>
                                        <div class="user-cell">
                                            <asp:ListBox ID="lstUnAsg" runat="server" Width="100%" Height="100%" DataTextField="FirstName" DataValueField="Id"></asp:ListBox>
                                        </div>
                                        <br />
                                        <div id="notenrollsearchId" class="user-enroll-search">
                                            <asp:Label ID="lblSearchNotEnrolled" runat="server" Text="Search"></asp:Label>
                                            <br />
                                            <asp:TextBox ID="tstSearchNotEnroll" runat="server" Text=""></asp:TextBox>
                                            &nbsp;
                                        <asp:Button ID="btnClearNotEnroll" runat="server" Text="Clear" />
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <br />
                <div style="text-align: center;">
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="98px" OnClick="btnSave_Click" />
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectSessionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSessionStartDate" runat="server" Value="" />

    <%--<hr />
    <hr />
    <hr />
    <asp:Panel ID="Panel3" runat="server" Width="100%">
        <asp:Panel ID="Panel1" runat="server" Width="100%">
            <asp:Panel ID="Panel4" runat="server">

                <div style="float: left;">
                    <table>
                        <tr>
                            <td>Name</td>
                            <td>Class Roll</td>

                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtNameSearch" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="txtRollSearch" runat="server"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td>&nbsp;&nbsp;&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="float: left;">
                    <table>
                        <tr>
                            <td>Created Date (from)</td>

                        </tr>
                        <tr>
                            <td>
                                <uc1:DateChooser ID="DateChooser1" runat="server" />
                            </td>

                        </tr>
                    </table>
                </div>
                <asp:TextBox ID="txtGroupId" runat="server" Visible="False" Width="16px"></asp:TextBox>

            </asp:Panel>
        </asp:Panel>

        <asp:Panel ID="pnlGrpAsg" runat="server">
            <strong>Assign Student to Group
            </strong>
            <div style="text-align: center;">
                Student Group<asp:DropDownList ID="cmbGroup" runat="server" Height="21px" Width="129px"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                    ControlToValidate="cmbGroup"
                    ErrorMessage="Required" ForeColor="#FF3300"></asp:RequiredFieldValidator>
            </div>
            <div id="unassignedDiv" style="float: left; width: 38%">
                Unassigned List
            </div>
            <div style="float: left; width: 23%; text-align: center; height: 100%; padding-top: 5px;">
                <br />
                <br />
                <asp:Button ID="btnAsg" runat="server" Text="Assign to group →" Width="139px" OnClick="btnAsg_Click" />
                <br />
                <br />
                <asp:Button ID="btnRemove" runat="server" Text="← Remove from Group" Width="150px" OnClick="btnRemove_Click" />
                <br />
                <br />
                <br />
            </div>
            <div id="assignedDiv" style="float: left; width: 37%">
                Assigned List&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="cmbGroup" ErrorMessage="No Students to save." ForeColor="#FF3300"></asp:RequiredFieldValidator>
                &nbsp;
            </div>

        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" Width="100%"></asp:Panel>
    </asp:Panel>--%>
    <style type="text/css">
        .hover1:hover {
            /*background-color: azure;*/
            cursor: pointer;
        }

        .user-cell {
            margin: 10px 10px 0;
            /* #e2e2ec*/
            background-color: #FFFBD6;
            max-height: 500px;
            min-height: 200px;
            overflow-y: auto;
            height: 220px;
        }

        .user-enroll-search {
            margin: 2px 10px 5px;
        }

        #maindiv:hover {
            /**/
            background-color: #e2e2ec;
            margin: auto;
        }

        .main-div {
            background-color: #ebecf9;
        }
    </style>
</div>
