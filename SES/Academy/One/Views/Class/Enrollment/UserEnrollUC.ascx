<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserEnrollUC.ascx.cs" Inherits="One.Views.Class.Enrollment.UserEnrollUC" %>

<div style="margin: 5px;">

    <div class="main-div" id="maindiv">
        <table style="margin: auto;">
            <tbody style="vertical-align: top;">
                <tr>
                    <td style="width: 32%;">Enrolled Users</td>
                    <td style="width: 18%;"></td>
                    <td style="width: 32%;">Not Enrolled Users</td>
                </tr>
                <tr>
                    <%-- ===================== Left Panel ==================== --%>
                    <td id="existingcell">
                        <div class="user-cell">

                            <asp:GridView ID="grdEnrolled" runat="server" ShowHeader="False"
                                AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand1"
                                OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                CellPadding="4" ForeColor="#333333"
                                Width="100%"
                                Height="100%"
                                GridLines="None">

                                <AlternatingRowStyle BackColor="White" />

                                <Columns>
                                    <asp:TemplateField HeaderText="First Name" SortExpression="FirstName">
                                        <%--<EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                                        </EditItemTemplate>--%>
                                        <ItemTemplate>
                                            <div class="hover1">
                                                <asp:Label ID="Label1" runat="server" Text='<%#
                                                GetName(Eval("FirstName"),Eval("MiddleName"),Eval("LastName"),Eval("Email"))
                                                 %>'></asp:Label>
                                            </div>

                                        </ItemTemplate>

                                        <ItemStyle Width="100"></ItemStyle>

                                    </asp:TemplateField>

                                </Columns>


                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />


                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />


                                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                <SortedDescendingHeaderStyle BackColor="#820000" />


                            </asp:GridView>

                        </div>
                        <br />
                        <div id="divUserEnrollId" class="user-enroll-search">
                            <asp:Label ID="lblSearchEnroll" runat="server" Text="Search"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtSearchEnroll" runat="server" Text=""></asp:TextBox>
                            &nbsp;
                            <asp:Button ID="btnClearEnroll" runat="server" Text="Clear" />
                        </div>

                        <div>



                            <%--<asp:ListView ID="ListView1" runat="server" OnSelectedIndexChanged="ListView1_SelectedIndexChanged"
                                OnSelectedIndexChanging="ListView1_SelectedIndexChanging">
                                <LayoutTemplate>--%>
                            <%--<select runat="server" id="select1">
                                        <optgroup id="optgroup1" label="enrolled-users" runat="server">
                                            <option runat="server" id="itemPlaceholder"></option>
                                        </optgroup>
                                    </select>--%>

                            <%--  <table runat="server" id="table1">
                                        <tr runat="server" id="itemPlaceholder1"></tr>
                                    </table>--%>
                            <%--   </LayoutTemplate>
                                <ItemTemplate>--%>

                            <%-- <option runat="server" id="opt1" style="padding-left: 5px;">
                                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%#Eval("Id") %>' />
                                        <asp:LinkButton ID="LinkButton2" Width="100%" CommandName="Select" runat="server" Font-Underline="False"
                                            OnClick="ItemClick">
                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                                        </asp:LinkButton>
                                    </option>--%>

                            <%-- <tr id="Tr1" runat="server">
                                        <td id="Td1" runat="server">
                                            <asp:HiddenField ID="UserIdLabel" runat="server" Value='<%#Eval("Id") %>' />
                                            <asp:LinkButton ID="LinkButton1" Width="100%" CommandName="Select" runat="server" Font-Underline="False"
                                                OnClick="ItemClick">
                                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("FirstName") %>'></asp:Label>
                                            </asp:LinkButton>

                                        </td>
                                    </tr>--%>
                            <%-- </ItemTemplate>
                                <SelectedItemTemplate>
                                    <tr id="Tr1" runat="server">
                                        <td id="Td1" runat="server" style="background-color: lightblue;">--%>
                            <%-- Data-bound content. --%>
                            <%-- <asp:HiddenField ID="UserIdLabel" runat="server" Value='<%#Eval("Id") %>' />
                                            <asp:Label ID="NameLabel" runat="server"
                                                Text='<%#Eval("FirstName") %>' />
                                        </td>
                                    </tr>
                                </SelectedItemTemplate>
                            </asp:ListView>--%>
                        </div>
                        <div style="font-size: 1.2em; font-weight: 700;">
                        </div>

                    </td>
                    <%-- ===================== Mid Panel ================== --%>


                    <td id="buttonscell">

                        <div style="text-align: center; margin: 10px 10px 0;">
                            <div id="addcontrols" style="padding-bottom: 20px;">
                                <asp:Button ID="btnAdd" runat="server" Text="◄ Add" Width="100px" OnClick="btnAdd_Click" />
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
                                        <asp:DropDownList ID="ddlEnrollmentDuration" runat="server" Height="22px" Width="120px"></asp:DropDownList>
                                    </p>
                                    <p>
                                        <asp:Label ID="lblStartingFrom" runat="server" Text="Starting From"></asp:Label>
                                        <br />
                                        <asp:DropDownList ID="ddlStartingFrom" runat="server" Height="22px" Width="120px"></asp:DropDownList>
                                    </p>
                                </div>
                            </div>
                            <div id="removecoontrols">
                                <asp:Button ID="btnRemove" runat="server" Text="Remove ►" Width="100px" OnClick="btnRemove_Click" />

                            </div>
                        </div>
                    </td>


                    <%-- =======================Right Panel ======================= --%>
                    <td id="potentialcell">
                        <div class="user-cell">
                            <asp:GridView ID="grdNotEnrolled" runat="server" ShowHeader="False"
                                AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand1"
                                OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                CellPadding="4" ForeColor="#333333"
                                Width="100%"
                                GridLines="None">

                                <AlternatingRowStyle BackColor="White" />

                                <Columns>
                                    <asp:TemplateField HeaderText="First Name" SortExpression="FirstName">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <div class="hover1">
                                                <asp:Label ID="Label2" runat="server" Text='<%# 
                                                        GetName(Eval("FirstName"),Eval("MiddleName")
                                                        ,Eval("LastName"),Eval("Email"))
                                                         %>'></asp:Label>
                                                <%--<asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>--%>
                                                <%--<asp:Button ID="Button1" runat="server" Text="Button" CommandName="Select" />--%>
                                            </div>

                                        </ItemTemplate>

                                        <ItemStyle Width="100"></ItemStyle>

                                    </asp:TemplateField>

                                </Columns>


                                <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />


                                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />


                                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                <SortedDescendingHeaderStyle BackColor="#820000" />


                            </asp:GridView>
                        </div>
                        <br />
                        <div id="notenrollsearchId" class="user-enroll-search">
                            <asp:Label ID="lblSearchNotEnrolled" runat="server" Text="Search"></asp:Label>
                            <br />
                            <asp:TextBox ID="tstSearchNotEnroll" runat="server" Text=""></asp:TextBox>
                            &nbsp;
                            <asp:Button ID="btnClearNotEnroll" runat="server" Text="Clear" />
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

    <div style="margin: 5px; padding: 5px;">
        <%--  --%>
        <div style="float: left;">
        </div>
        <%--  --%>
        <div>
        </div>
        <%--  --%>
        <div>
        </div>
        <%--  --%>
    </div>
    <style type="text/css">
        .hover1:hover {
            /*background-color: azure;*/
            cursor: pointer;
        }

        .user-cell {
            margin: 10px 10px 0;
            border: 1px solid grey;
            /* #e2e2ec*/
            background-color: #FFFBD6;
            max-height: 500px;
            min-height: 200px;
            overflow-y: auto;
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
