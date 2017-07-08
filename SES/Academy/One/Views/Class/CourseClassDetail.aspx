<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="CourseClassDetail.aspx.cs" Inherits="One.Views.Class.CourseClassDetail" %>


<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="content" ContentPlaceHolderID="Body">
    <h3 class="heading-of-display">
        <asp:Label ID="lblCourseName" runat="server" Text=""></asp:Label>
    </h3>

    <div class="data-entry-section">
        <div>
            <div style="float: left;">
                <h3 class="heading-of-display">
                    <asp:Label ID="lblClassName" runat="server" Text=""></asp:Label>
                </h3>
            </div>




            <div style="clear: both;"></div>
        </div>
        <%--  class="data-entry-section" --%>
        <div>

            <table class="table-detail">
                <%-- <tr class="row-detail">
                    <td class="data-detail">Class Name</td>
                    <td>
                        <asp:Literal ID="lblFullName" runat="server"></asp:Literal>
                    </td>
                </tr>--%>
                <tr>
                    <td class="data-type">Start Date</td>
                    <td class="data-value">
                        <asp:Literal ID="lblStartDate" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">End Date</td>
                    <td class="data-value">
                        <asp:Literal ID="lblEndDate" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td class="data-type">Enrollment Method</td>
                    <td class="data-value">
                        <asp:Literal ID="lblEnrollmentMethod" runat="server"></asp:Literal>
                    </td>
                </tr>
                <%--<tr>
                    <td class="data-type">Student Grouping
                    </td>
                    <td class="data-value">
                        <asp:Literal ID="lblGrouping" runat="server"></asp:Literal>
                        <div>
                        </div>
                    </td>
                </tr>--%>
            </table>
        </div>
        <br />
        <%-- style="text-align: center; vertical-align: bottom; float: left; padding-top: 8px; padding-left: 20px;" --%>
        <div style="">
            <div style="text-align: center;">
                <asp:HyperLink ID="lnkReport" runat="server" CssClass="auto-st2 link">View Report</asp:HyperLink>
                &nbsp;
                <asp:HyperLink ID="lnkMarkCompletion" runat="server" CssClass="auto-st2 link">Mark Complete</asp:HyperLink>
                &nbsp;
                <asp:HyperLink ID="lnkEnrollTeachers" runat="server" CssClass="auto-st2 link">Enroll Teachers</asp:HyperLink>
                 &nbsp;
                <asp:HyperLink ID="lnkEnrollStudents" runat="server" CssClass="auto-st2 link">Enroll Students</asp:HyperLink>

                <%--<asp:Button ID="btnEnroll" runat="server" Text="Enroll Users" OnClick="btnEnroll_Click" CssClass="auto-st2 link"/>--%>

            </div>
        </div>
        <br />


        <%--  class="data-entry-section-body" --%>
        <div>

            <div style="color: darkslategrey">
                <asp:Label ID="lbldNotice" runat="server"
                    Visible="False">
                    <asp:Image ID="imgNotice" runat="server" ImageUrl="~/Content/Icons/Notice/Warning_Shield_16px.png" />

                    Teacher is not assigned to this class yet. Please assign teacher(s).
                </asp:Label>
            </div>

            <br />

            <div class="data-entry-section-heading">
                Enrolled users

              
                <hr />
            </div>
            <%--  ===================Listing of Enrolled Users ========================= --%>
            <%--<asp:ListView ID="ListView1" runat="server">
                <LayoutTemplate>
                    <table id="Table1" runat="server" style="width: 99%;">
                        <thead>
                            <tr style="background-color: darkslategray; color: white;">
                                <td></td>
                                <td>Name</td>
                                <td>Email</td>
                                <td>Last Access to Course</td>
                                <td>Roles</td>
                                <td>Groups</td>
                            </tr>
                        </thead>
                        <tr runat="server" id="itemPlaceholder">
                        </tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#  GetImageUrl(DataBinder.Eval(Container.DataItem,"UserImageId")) %>'>
                                <asp:Image ID="Image1" runat="server"
                                    Height="20" Width="20"
                                    ImageUrl='<%#  GetImageUrl(DataBinder.Eval(Container.DataItem,"UserImageId")) %>' />
                            </asp:HyperLink>
                        </td>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text='<%# GetName(DataBinder.Eval(Container.DataItem,"FirstName"),Eval("MiddleName"),Eval("LastName"))  %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                        </td>
                        <td>
                            <span style="font-size: 0.8em">
                                <asp:Label ID="Label8" runat="server" Text='<%# GetLastOnline(DataBinder.Eval(Container.DataItem,"LastOnline"))  %>'></asp:Label>
                            </span>
                        </td>
                        <td>
                            <tr></tr>
                        </td>
                        <td>
                            <asp:Label ID="lblGroup" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>--%>
        </div>


        <%-- GridView --%>



        <%-- End grid view --%>
    </div>

    <%
        const int count = 1;
    %>

    <div style="margin-top: 20px">
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="25" CssClass="gridview"
            AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Width="100%"
            CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="No users">

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />

                <asp:TemplateField HeaderText="S.N">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SN") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("SN")  %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="20"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Image">
                    <EditItemTemplate>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#  Bind("ImageUrl") %>'>
                            <asp:Image ID="Image1" runat="server"
                                Height="20" Width="20"
                                ImageUrl='<%#  Bind("ImageUrl") %>' />
                        </asp:HyperLink>
                    </ItemTemplate>
                    <ItemStyle Width="25"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="CRN">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CRN") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("CRN")  %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="70"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Name">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name")  %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="150"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Username" SortExpression="UserName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Email" SortExpression="Email">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="150"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Role" SortExpression="Role">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Role") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Role") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Online on" SortExpression="Online">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("LastOnline") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <span style="font-size: 0.8em">
                            <asp:Label ID="Label8" runat="server"
                                Text='<%# Bind("LastOnline") %>'></asp:Label>
                            <%--Text='<%# GetLastOnline(DataBinder.Eval(Container.DataItem,"LastOnline"))--%>  
                        </span>
                    </ItemTemplate>
                    <ItemStyle Width="65"></ItemStyle>
                </asp:TemplateField>

            </Columns>

            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <%--  BackColor="#557d96" Font-Bold="True" ForeColor="White" --%>
            <HeaderStyle CssClass="data-list-header" />
            <PagerStyle HorizontalAlign="Center" CssClass="data-list-footer" />
            <%--<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />--%>
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>

        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListEnrolledUsers"
            TypeName="Academic.DbHelper.DbHelper+Classes">
            <SelectParameters>
                <asp:ControlParameter ControlID="hidSubjectSessionId" DefaultValue="0" Name="subjectClassId" PropertyName="Value" Type="Int32" />
                <asp:ControlParameter ControlID="hidOrderby" DefaultValue="name" Name="orderBy" PropertyName="Value" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>

    </div>


    <asp:HiddenField ID="hidSubjectSessionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidOrderby" runat="server" Value="crn" />

</asp:Content>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="title">
    <asp:Literal ID="lblTitle" runat="server"></asp:Literal>
</asp:Content>

<asp:Content runat="server" ID="content2" ContentPlaceHolderID="head">
    <link href="../../Content/CSSes/TableStyles.css" rel="stylesheet" />
    <link href="../../Content/CSSes/PanelStyles.css" rel="stylesheet" />
</asp:Content>
