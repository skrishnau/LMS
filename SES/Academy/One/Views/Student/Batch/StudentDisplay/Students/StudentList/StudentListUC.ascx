<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentListUC.ascx.cs" Inherits="One.Views.Student.Batch.StudentDisplay.Students.StudentList.StudentListUC" %>


<%-- DataSourceID="ObjectDataSource1"  --%>
<asp:GridView ID="GridView2" runat="server" AllowPaging="True" Width="100%"
    OnPageIndexChanging="GridView2_OnPageIndexChanging" CssClass="table table-hover table-responsive"
    PageSize="30"
    AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" DataSourceID="ObjectDataSource1">

    <AlternatingRowStyle BackColor="#F7F6F3" ForeColor="#393939" />

    <Columns>
        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />

        <asp:TemplateField HeaderText="Image">
            <EditItemTemplate>
                <%--<asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("LastOnline") %>'></asp:TextBox>--%>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#  GetImageUrl(DataBinder.Eval(Container.DataItem,"UserImageId")) %>'>
                    <asp:Image ID="Image1" runat="server"
                        Height="20" Width="20"
                        ImageUrl='<%#  GetImageUrl(DataBinder.Eval(Container.DataItem,"UserImageId")) %>' />
                </asp:HyperLink>
                <%--<asp:Label ID="Label8" runat="server" Text='<%# Bind("LastOnline") %>'></asp:Label>--%>
            </ItemTemplate>
            <ItemStyle Width="30"></ItemStyle>
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Name" SortExpression="FirstName">
            <%-- <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                </EditItemTemplate>--%>
            <ItemTemplate>
                <asp:HyperLink ID="Label2" runat="server"
                    NavigateUrl='<%# "~/Views/User/Detail.aspx?uId="+Eval("Id") %>'
                    CssClass="link"
                    Text='<%# GetName(DataBinder.Eval(Container.DataItem,"FirstName"),Eval("MiddleName"),Eval("LastName"))  %>'>
                        
                </asp:HyperLink>
                <%--<asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>--%>
            </ItemTemplate>
            <ItemStyle Width="200" HorizontalAlign="Left"></ItemStyle>
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Username" SortExpression="UserName">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("UserName") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label3" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100"></ItemStyle>
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Email" SortExpression="Email">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100"></ItemStyle>
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Phone" SortExpression="Phone">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Phone") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
            </ItemTemplate>
            <ItemStyle Width="100"></ItemStyle>
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Online" SortExpression="LastOnline">
            <EditItemTemplate>
                <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("LastOnline") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <span style="font-size: 0.8em">
                    <asp:Label ID="Label8" runat="server" Text='<%# GetLastOnline(DataBinder.Eval(Container.DataItem,"LastOnline"))  %>'></asp:Label>
                </span>
            </ItemTemplate>
            <ItemStyle Width="70"></ItemStyle>
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
        </asp:TemplateField>

    </Columns>

    <%--<EditRowStyle BackColor="#999999" />--%>
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <%--<HeaderStyle BackColor="#557d96" Font-Bold="True" ForeColor="White" />--%>
    <HeaderStyle CssClass="data-list-header" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="white" ForeColor="#393939" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

</asp:GridView>


<%-- <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetStudentsOfProgramBatch_AsUser" TypeName="Academic.DbHelper.DbHelper+Batch">
        <SelectParameters>
            <asp:ControlParameter ControlID="hidProgramBatchId" DefaultValue="0" Name="programBatchId" PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>--%>



<asp:HiddenField ID="hidPageNo" runat="server" Value="1" />
<asp:HiddenField ID="hidPerPage" runat="server" Value="100" />
<asp:HiddenField ID="hidProgramBatchId" runat="server" Value="0" />
<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetStudentsOfProgramBatch_AsUser" TypeName="Academic.DbHelper.DbHelper+Batch">
    <SelectParameters>
        <asp:ControlParameter ControlID="hidProgramBatchId" DefaultValue="0" Name="programBatchId" PropertyName="Value" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>

