<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="One.Views.User.List" %>

<%--<asp:Content runat="server" ID="contentLeft" ContentPlaceHolderID="BodyInnerLeft">

    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Views/User/Create.aspx" runat="server">Create User</asp:HyperLink>
    <asp:HyperLink ID="HyperLink2" NavigateUrl="~/Views/Student/StudentList.aspx" runat="server">Students</asp:HyperLink>

</asp:Content>--%>


<asp:Content runat="server" ID="content" ContentPlaceHolderID="Body">
    <div style="text-align: center">
        <strong>Users List</strong>

        <hr />
    </div>

    <div>
        <div style="float: right;">
            <asp:HyperLink runat="server" NavigateUrl="~/Views/User/Create.aspx">
                Add New User
            </asp:HyperLink>
            &nbsp;&nbsp;&nbsp;
            <asp:HyperLink runat="server" NavigateUrl="~/Views/Role/Assign.aspx">
                Assign Role
            </asp:HyperLink>
        </div>
        search filter criterias:::
       
    </div>
    <br />
    <div>
        <%-- <table>
            <tr>
                <td class="auto-style1">FirstName</td>
                <td class="auto-style1">LastName</td>
                <td class="auto-style1">FirstName</td>
                <td class="auto-style1">FirstName</td>
                <td class="auto-style1">FirstName</td>
                <td class="auto-style1">FirstName</td>
            </tr>
        </table>--%>

        <%-- <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical">
            <AlternatingItemStyle BackColor="#DCDCDC" />
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="#EEEEEE" ForeColor="Black" />
            <ItemTemplate>
                <asp:HiddenField ID="IdLabel" runat="server" Value='<%# Eval("Id") %>' />
                <table>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="FirstNameLabel" runat="server" Text='<%# Eval("FirstName") %>' />
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="LastNameLabel" runat="server" Text='<%# Eval("LastName") %>' />
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="UserNameLabel" runat="server" Text='<%# Eval("UserName") %>' />

                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="PasswordLabel" runat="server" Text='<%# Eval("Password") %>' />
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="EmailLabel" runat="server" Text='<%# Eval("Email") %>' />
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>' />
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                        </td>
                        <td class="auto-style1">
                            <asp:Label ID="LastOnlineLabel" runat="server" Text='<%# Eval("LastOnline") %>' />
                        </td>
                    </tr>
                </table>
                <%-- below code must be commented all in this datalist  --%>
        <%--  <br />
                <br />
                UserName:
                <br />
                Password:
                <br />
                Email:
                <br />
                EmailDisplay:
                <asp:Label ID="EmailDisplayLabel" runat="server" Text='<%# Eval("EmailDisplay") %>' />
                <br />
                Phone:
                <br />
                City:
                <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
                <br />
                Country:
                <br />
                Description:
                <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                <br />
                DOB:
                <asp:Label ID="DOBLabel" runat="server" Text='<%# Eval("DOB") %>' />
                <br />
                IsActive:
                <asp:Label ID="IsActiveLabel" runat="server" Text='<%# Eval("IsActive") %>' />
                <br />
                IsDeleted:
                <asp:Label ID="IsDeletedLabel" runat="server" Text='<%# Eval("IsDeleted") %>' />
                <br />
                GenderId:
                <asp:Label ID="GenderIdLabel" runat="server" Text='<%# Eval("GenderId") %>' />
                <br />
                Gender:
                <asp:Label ID="GenderLabel" runat="server" Text='<%# Eval("Gender") %>' />
                <br />
                SchoolId:
                <asp:Label ID="SchoolIdLabel" runat="server" Text='<%# Eval("SchoolId") %>' />
                <br />
                School:
                <asp:Label ID="SchoolLabel" runat="server" Text='<%# Eval("School") %>' />
                <br />
                Image:
                <asp:Label ID="ImageLabel" runat="server" Text='<%# Eval("Image") %>' />
                <br />
                ImageType:
                <asp:Label ID="ImageTypeLabel" runat="server" Text='<%# Eval("ImageType") %>' />
                <br />
                CreatedDate:
                <asp:Label ID="CreatedDateLabel" runat="server" Text='<%# Eval("CreatedDate") %>' />
                <br />
                LastOnline:
                <br />
                UserDivisions:
                <asp:Label ID="UserDivisionsLabel" runat="server" Text='<%# Eval("UserDivisions") %>' />
                <br />
                UserRoles:
                <asp:Label ID="UserRolesLabel" runat="server" Text='<%# Eval("UserRoles") %>' />
                <br />
                FullName:
                <asp:Label ID="FullNameLabel" runat="server" Text='<%# Eval("FullName") %>' />
                <br />
                SecurityQuestion:
                <asp:Label ID="SecurityQuestionLabel" runat="server" Text='<%# Eval("SecurityQuestion") %>' />
                <br />
                SecurityAnswer:
                <asp:Label ID="SecurityAnswerLabel" runat="server" Text='<%# Eval("SecurityAnswer") %>' />
                <br />
                <br />
            </ItemTemplate>

            <SelectedItemStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />

        </asp:DataList>--%>

        <asp:GridView ID="GridView1"  runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None">

            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            
            <Columns>
                <%--<asp:BoundField DataField="EmailDisplay" HeaderText="EmailDisplay" SortExpression="EmailDisplay" Visible="False" />--%>
                <%--<asp:BoundField DataField="City" HeaderText="City" SortExpression="City" Visible="False" />--%>
                <%--<asp:BoundField DataField="EmailDisplay" HeaderText="EmailDisplay" SortExpression="EmailDisplay" />--%>
                <%--<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" Visible="False" />--%>
                <%--<asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" Visible="False" />--%>
                <%--<asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive" Visible="False" />--%>
                <%--<asp:CheckBoxField DataField="IsDeleted" HeaderText="IsDeleted" SortExpression="IsDeleted" Visible="False" />--%>
                <%--<asp:BoundField DataField="GenderId" HeaderText="GenderId" SortExpression="GenderId" Visible="False" />--%>
                <%--<asp:BoundField DataField="SchoolId" HeaderText="SchoolId" SortExpression="SchoolId" />--%>
                <%--<asp:BoundField DataField="ImageType" HeaderText="ImageType" SortExpression="ImageType" />--%>
                <%--<asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" />--%>
                <%--<asp:BoundField DataField="FullName" HeaderText="FullName" ReadOnly="True" SortExpression="FullName" />--%>
                <%--<asp:BoundField DataField="SecurityQuestion" HeaderText="SecurityQuestion" SortExpression="SecurityQuestion" />--%>
                <%--<asp:BoundField DataField="SecurityAnswer" HeaderText="SecurityAnswer" SortExpression="SecurityAnswer" />--%>
                <%--<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />--%>
                <%--<asp:BoundField DataField="DOB" HeaderText="DOB" SortExpression="DOB" />--%>
                <%--<asp:CheckBoxField DataField="IsActive" HeaderText="IsActive" SortExpression="IsActive" />--%>
                <%--<asp:CheckBoxField DataField="IsDeleted" HeaderText="IsDeleted" SortExpression="IsDeleted" />--%>
                <%--<asp:BoundField DataField="GenderId" HeaderText="GenderId" SortExpression="GenderId" />--%>
                <%--<asp:BoundField DataField="SchoolId" HeaderText="SchoolId" SortExpression="SchoolId" />--%>
                <%--<asp:BoundField DataField="ImageType" HeaderText="ImageType" SortExpression="ImageType" />--%>
                <%--<asp:BoundField DataField="CreatedDate" HeaderText="CreatedDate" SortExpression="CreatedDate" />--%>
                <%--<asp:BoundField DataField="FullName" HeaderText="FullName" ReadOnly="True" SortExpression="FullName" />--%>
                <%--<asp:BoundField DataField="SecurityQuestion" HeaderText="SecurityQuestion" SortExpression="SecurityQuestion" />--%>
                <%--<asp:BoundField DataField="SecurityAnswer" HeaderText="SecurityAnswer" SortExpression="SecurityAnswer" />--%>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False" />

                <asp:TemplateField HeaderText="Image" >
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
                </asp:TemplateField>

                <asp:TemplateField HeaderText="First Name" SortExpression="FirstName" >
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FirstName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("FirstName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name" SortExpression="LastName">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("LastName") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("LastName") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100"></ItemStyle>
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
                <asp:TemplateField HeaderText="Password" SortExpression="Password">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Password") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("Password") %>'></asp:Label>
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
                    <ItemStyle Width="100"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone" SortExpression="Phone">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Phone") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label6" runat="server" Text='<%# Bind("Phone") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle Width="100"></ItemStyle>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />--%>
                <asp:TemplateField HeaderText="Country" SortExpression="Country">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox7" runat="server" Text='<%# Bind("Country") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label7" runat="server" Text='<%# Bind("Country") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle></ItemStyle>
                    <ItemStyle Width="100"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Online" SortExpression="LastOnline">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox8" runat="server" Text='<%# Bind("LastOnline") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <span style="font-size: 0.8em">
                            <asp:Label ID="Label8" runat="server" Text='<%# GetLastOnline(DataBinder.Eval(Container.DataItem,"LastOnline"))  %>'></asp:Label>
                        </span>
                    </ItemTemplate>
                    <ItemStyle Width="50"></ItemStyle>
                </asp:TemplateField>

            </Columns>

            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

        </asp:GridView>

        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListAllUsers" TypeName="Academic.DbHelper.DbHelper+User">
            <SelectParameters>
                <asp:ControlParameter ControlID="hidSchoolId" DefaultValue="0" Name="schoolId" PropertyName="Value" Type="Int32" />
                <asp:ControlParameter ControlID="hidPerPage" DefaultValue="0" Name="perPage" PropertyName="Value" Type="Int32" />
                <asp:ControlParameter ControlID="hidPageNo" DefaultValue="0" Name="pageNo" PropertyName="Value" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

    </div>

    <asp:HiddenField ID="hidPageNo" runat="server" Value="1" />
    <asp:HiddenField ID="hidPerPage" runat="server" Value="100" />
    <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />

    <br />
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            width: 99px;
        }

        .auto-style2 {
            width: 65px;
        }
    </style>
</asp:Content>

