<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EarlierUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.EarlierUc" %>

<div class="dashboard-modules">
   <asp:HyperLink ID="HyperLink2" 
       NavigateUrl="~/ViewsSite/User/Dashboard/Dashboard.aspx?type=earlier" runat="server">
                                Earlier
                        <hr />
    </asp:HyperLink>
    
     <div>
        <asp:DataList ID="dListCourses" runat="server" DataSourceID="RegularCourseDS">
            <ItemTemplate>
                <div style="margin: 0 5px 0  10px;">
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("Id") %>' />
                    <asp:HyperLink ID="HyperLink5" runat="server"
                        NavigateUrl='<%# "~/Views/Course/Section/Master/CourseSectionListing.aspx?SubId="+Eval("Id") %>' Font-Underline="False">
                                        ■&nbsp;<%# Eval("Name") %>
                    </asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <asp:ObjectDataSource ID="RegularCourseDS" runat="server" SelectMethod="ListEarlierCoursesOfUser" TypeName="Academic.DbHelper.DbHelper+Subject">
            <SelectParameters>
                <asp:ControlParameter ControlID="hidUserId" DefaultValue="0" Name="userId" PropertyName="Value" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
            <asp:HiddenField ID="HiddenField2" runat="server" Value="0" />
            <asp:HiddenField ID="hidTopLevelRole" runat="server" Value="" />


    </div>
    <hr/>
      <asp:DataList ID="DataList2" runat="server" DataSourceID="EarlierYearsAndSubYearsDS">
                            <ItemTemplate>

                                <asp:HiddenField ID="IdLabel1" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Id") %>' />
                                <%--Name:--%>
                                
                                <div>
                                    <asp:Label ID="Label1" runat="server" Text='<%# GetYearName(Eval("Year")) %>' />
                                </div>
                               <div style="margin-left: 20px;">
                                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                                </div>
                                <asp:HiddenField ID="TypeLabel" runat="server" Value='<%# Eval("Description") %>' />

                            </ItemTemplate>
                        </asp:DataList>

                        <asp:ObjectDataSource ID="EarlierYearsAndSubYearsDS" runat="server" SelectMethod="GetEarlierYearsAndSubYearsOfStudent" TypeName="Academic.DbHelper.DbHelper+Student">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="hidUserId" DefaultValue="0" Name="userId" PropertyName="Value" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
            <asp:HiddenField ID="hidUserId" runat="server" Value="0" />

</div>