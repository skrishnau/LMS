<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserEnrollUC_ListDisplay.ascx.cs" Inherits="One.Views.Class.Enrollment.UserEnrollUC_ListDisplay" %>


<div>
    <div style="margin: 5px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div class="row">
                    <div class="col-md-5">
                        <div class="panel panel-default">
                            <div class="panel-heading">Enrolled Users</div>

                            <div class="panel-body">
                                <div class="user-cell">
                                    <asp:ListBox ID="lstAsg" onscroll="javascript:saveScroll();" runat="server" Width="100%" Height="200px" DataTextField="FirstName" DataValueField="Id"></asp:ListBox>
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
                        </div>
                    </div>

                    <div class="col-md-2 text-center">
                        <br />

                        <asp:Button ID="btnAdd" runat="server" Text="◄ Add" CssClass="btn btn-default" OnClick="btnAsg_Click" />
                        <br />
                        <div id="enroll-option">
                            <%--<p>--%>
                            <asp:Label ID="lblAssignRole" runat="server" Text="Assign Role" Visible="False"></asp:Label>
                            <br />
                            <asp:DropDownList ID="ddlAssignRole" runat="server" Height="22px" Width="120px"
                                Visible="False">
                            </asp:DropDownList>
                            <%--</p>--%>
                            <p>
                                <asp:Label ID="lblEnrollmentDuration" runat="server" Text="Enrollment Duration"></asp:Label>
                                <br />
                                <asp:DropDownList ID="ddlEnrollmentDuration" runat="server" Height="22px" Width="120px" DataTextField="Name" DataValueField="Id"></asp:DropDownList>
                            </p>
                            <br />
                            <p>
                                <asp:Label ID="lblStartingFrom" runat="server" Text="Starting From"></asp:Label>
                                <br />
                                <asp:DropDownList ID="ddlStartingFrom" runat="server" Height="22px" Width="120px" DataTextField="Name" DataValueField="Id">
                                </asp:DropDownList>
                            </p>
                            <br />
                            <p runat="server" id="pnlGroup" visible="False">
                                <asp:Label ID="lblGroup" runat="server" Text="Group"></asp:Label>
                                <br />
                                <asp:DropDownList ID="ddlGroup" runat="server" Height="22px" Width="120px" DataTextField="Name" DataValueField="Id">
                                </asp:DropDownList>
                            </p>
                        </div>
                        <div id="removecoontrols">
                            <asp:Button ID="Button1" runat="server" Text="Remove ►" CssClass="btn btn-default" OnClick="btnRemove_Click" />

                        </div>
                        <br />
                        <br />
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnSave_Click" />


                    </div>

                    <div class="col-md-5">
                        <div class="panel panel-default">
                            <div class="panel-heading">Not Enrolled Users</div>

                            <div class="panel-body">
                                <div class="user-cell">
                                    <asp:ListBox ID="lstUnAsg" runat="server" Width="100%" Height="200px" DataTextField="FirstName" DataValueField="Id"></asp:ListBox>
                                </div>
                                <br />
                                <div id="notenrollsearchId" class="user-enroll-search">
                                    <asp:Label ID="lblSearchNotEnrolled" runat="server" Text="Search"></asp:Label>
                                    <br />
                                    <asp:TextBox ID="txtSearchNotEnroll" runat="server" Text=""></asp:TextBox>
                                    <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1"
                                        ServiceMethod="GetCountries"
                                        MinimumPrefixLength="1"
                                        CompletionInterval="1000"
                                        EnableCaching="false"
                                        CompletionSetCount="1"
                                        TargetControlID="txtSearchNotEnroll"
                                        runat="server">
                                    </ajaxToolkit:AutoCompleteExtender>

                                    <%-- ServiceMethod="GetUnassignedUsersList" --%>
                                            &nbsp;
                                        <asp:Button ID="btnClearNotEnroll" runat="server" Text="Clear" />
                                    <br />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>

                <%--<div class="background-overall" id="maindiv">--%>
                    <%--<asp:Button ID="btnLoad" runat="server" Text="Load" OnClick="btnLoad_Click" Width="82px" />--%>
                    <%-- <table style="margin: auto;">
                        <tbody style="vertical-align: top;">
                            <tr>
                                <td style="width: 32%;">Enrolled Users</td>
                                <td style="width: 18%;"></td>
                                <td style="width: 32%;">Not Enrolled Users</td>
                            </tr>
                            <tr>
                                <td id="existingcell">
                                    <div>
                                    </div>
                                </td>

                                <td>
                                    <div style="text-align: center; margin: 10px 10px 0;">
                                    </div>
                                </td>

                                <td>
                                    <div>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>--%>
                <%--</div>--%>


            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
    <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
    <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectSessionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSessionStartDate" runat="server" Value="" />
    <asp:HiddenField ID="hidTeacherOnly" runat="server" Value="False" />
    <asp:HiddenField ID="hidEnrollType" runat="server" Value="student" />


    <style type="text/css">
        
    </style>
</div>
