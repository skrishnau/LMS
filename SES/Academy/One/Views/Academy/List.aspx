<%@ Page Language="C#" MasterPageFile="~/ViewsSite/UserSite.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="One.Views.Academy.List" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div>
        
        <asp:Panel ID="Panel1" runat="server">
            <strong>Academic Year List</strong>
        <div style="float: right;">
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">New Academic Year</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">New Session</asp:LinkButton>
        </div>
        <div style="float: right;">
            
        </div>
            <div style="float: right; width:100%">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="Id" DataSourceID="SqlDataSource1" GridLines="Vertical" OnRowCommand="GridView2_RowCommand">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <columns>
                        
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                        <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" />
                        <asp:BoundField DataField="EndDate" HeaderText="EndDate" SortExpression="EndDate" />
                        <asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive" />
                        
                    </columns>
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
                <hr/>
            </div>
        
        </asp:Panel>
        <div id="Panel2" runat="server" style="padding: 5px 10px 5px;">
            

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
                <%--<edititemtemplate>
<asp:linkbutton id="lblupdate" commandargument='<%=Eval("Id")%>' commandname="updaterow"Forecolor =""

runat="server">Update</asp:linkButton>--%>
            </Columns>

        </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Academy_New_Project %>" SelectCommand="SELECT * FROM [AcademicYear]"></asp:SqlDataSource>
            </div>
    </div>
</asp:Content>
