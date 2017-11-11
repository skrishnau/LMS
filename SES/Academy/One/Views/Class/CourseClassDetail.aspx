<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="CourseClassDetail.aspx.cs" Inherits="One.Views.Class.CourseClassDetail" %>


<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>
<%@ Register Src="~/Views/All_Resusable_Codes/Dialog/CustomDialog.ascx" TagPrefix="uc1" TagName="CustomDialog" %>

<asp:Content runat="server" ID="content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>


<asp:Content runat="server" ID="content" ContentPlaceHolderID="Body">
    <h3 class="heading-of-display">
        <asp:Label ID="lblCourseName" runat="server" Text=""></asp:Label>
    </h3>
    <h3 class="heading-of-display">
        <asp:Label ID="lblClassName" runat="server" Text=""></asp:Label>
        <span style="line-height: 12px; vertical-align: top;">
            <asp:Image ID="imgIndicate" runat="server" ImageUrl="~/Content/Icons/Stop/Stop_10px.png" />
        </span>
    </h3>
    <hr />

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
            <tr>
                <td class="data-type"></td>
                <td class="data-value">
                    <div style="color: darkslategrey">
                        <asp:Label ID="lbldNotice" runat="server"
                            Visible="False">
                            <asp:Image ID="imgNotice" runat="server" ImageUrl="~/Content/Icons/Notice/Warning_Shield_16px.png" />
                            Teacher is not assigned to this class yet. Please assign teacher(s).
                        </asp:Label>
                    </div>
                </td>
            </tr>
        </table>
    </div>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%-- option-div --%>
            <div class="text-right" style="padding: 15px;">
                <asp:HyperLink ID="lnkReport" runat="server" CssClass="btn btn-default">View Report</asp:HyperLink>
                &nbsp;
                <asp:LinkButton ID="lnkMarkCompletion" runat="server" CssClass="btn btn-default"
                    OnClick="lnkMarkCompletion_OnClick"
                    Visible="False">Mark Complete</asp:LinkButton>
                &nbsp;
                <asp:HyperLink ID="lnkEnrollTeachers" runat="server" Visible="False" CssClass="btn btn-default">
                    Enroll Teachers
                </asp:HyperLink>
                &nbsp;
                <asp:HyperLink ID="lnkEnrollStudents" runat="server" Visible="False" CssClass="btn btn-default">
                    Enroll Students
                </asp:HyperLink>

                <%--<asp:Button ID="btnEnroll" runat="server" Text="Enroll Users" OnClick="btnEnroll_Click" CssClass="auto-st2 link"/>--%>
            </div>
            <uc1:CustomDialog runat="server" ID="CustomDialog" />
        </ContentTemplate>
    </asp:UpdatePanel>


    <div class="panel panel-default">
        <div class="panel-heading">Enrolled users</div>
        <br />
        <%-- CssClass="gridview" --%>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="25" CssClass="table table-responsive table-hover"
            OnRowDataBound="GridView1_OnRowDataBound"
            OnSelectedIndexChanged="GridView1_OnSelectedIndexChanged"
            AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" Width="100%"
            CellPadding="4" ForeColor="#333333" GridLines="None" EmptyDataText="No users">

            <%--<AlternatingRowStyle BackColor="White" ForeColor="#284775" />--%>

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
                        <asp:HyperLink ID="Label1" runat="server"
                            CssClass="link"
                            NavigateUrl='<%# "~/Views/User/Detail.aspx?uId="+Eval("Id") %>'
                            Text='<%# Eval("Name")  %>'></asp:HyperLink>

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
            <%--<RowStyle BackColor="#F7F6F3" ForeColor="#333333" />--%>
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
    <link href="../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />
</asp:Content>
