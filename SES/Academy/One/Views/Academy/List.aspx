<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="One.Views.Academy.List" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div>
        <div style="text-align: center; font-size: 1.3em;">
            <strong>Academic Year List</strong>
            <hr />
        </div>


        <%-- --------------Menu------------- --%>
        <div class="menu" style="clear: both; margin: 20px 5px; padding: 10px;">
            <div style="float: left;">
                <asp:Button ID="Button1"
                    runat="server" Height="27px"
                    Text="Activate Next Academic year/ Session" Width="262px" />

            </div>
            <div style="float: right;">
                <asp:HyperLink ID="LinkButton1" runat="server" NavigateUrl="~/Views/Academy/AcademicYear/AcademyCreate.aspx">
                <asp:Image runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png"/>
                        New Academic Year
                </asp:HyperLink>
                &nbsp;&nbsp;&nbsp;
            <%--<asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">New Session</asp:LinkButton>--%>
            </div>
        </div>
        <br />
        <%-- ------------END of Menu --%>


        <div style="clear: both;">
            <asp:Panel ID="pnlAcademicYearListing" runat="server"></asp:Panel>
        </div>


        <%--<div style="float: right; width: 100%">
            <asp:GridView ID="GridView2" runat="server" Width="100%" 
                AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
                BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="Id"
                 DataSourceID="SqlDataSource1" GridLines="Vertical"
                 OnRowCommand="GridView2_RowCommand">
                <AlternatingRowStyle BackColor="#DCDCDC" />
                <Columns>

                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:TemplateField HeaderText="Start Date" SortExpression="StartDate">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("StartDate") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# GetDatePartOnly(Eval("StartDate")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="End Date" SortExpression="EndDate">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("EndDate") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# GetDatePartOnly(Eval("EndDate")) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CheckBoxField DataField="IsActive" HeaderText="Active" SortExpression="IsActive" />

                </Columns>
                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#0000A9" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#000065" />
            </asp:GridView>
            <hr />
        </div>--%>

        <%--<div id="Panel2" runat="server" style="padding: 5px 10px 5px;">


            <asp:GridView ID="GridView1" runat="server" OnDataBound="GridView1_DataBound" OnRowCreated="GridView1_RowCreated" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <header>Action</header>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:HyperLink ID="LinkButooon1" commandArgument='<%=Eval("Id")%>' commandname="EditRow" ForeColor=""
                                runat="server">edit </asp:HyperLink>
                            <asp:HyperLink ID="HyperLink1" commandArgument='<%=Eval("Id")%>' commandname="DeleteRow" ForeColor=""
                                runat="server">Delete </asp:HyperLink>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:HyperLink ID="LinkButooon1" commandArgument='<%=Eval("Id")%>' commandname="UpdateRow" ForeColor=""
                                runat="server">Update </asp:HyperLink>
                            <asp:HyperLink ID="HyperLink1" commandArgument='<%=Eval("Id")%>' commandname="CancelRow" ForeColor=""
                                runat="server">Cancel </asp:HyperLink>
                        </EditItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <header>Name</header>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label111" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <header>Start Date</header>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("StartDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <header>End Date</header>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label1111" runat="server" Text='<%# Eval("EndDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <header>Active</header>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="Label122" runat="server" Checked='<%# Eval("IsActive") %>'></asp:CheckBox>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <HeaderTemplate>
                            <header>Number of Sessions</header>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Label ID="Label124" runat="server" Text='<%# Eval("SchoolId") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                </Columns>

            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Latest_Academy %>" SelectCommand="SELECT * FROM [AcademicYear]"></asp:SqlDataSource>
        </div>--%>
    </div>
</asp:Content>
