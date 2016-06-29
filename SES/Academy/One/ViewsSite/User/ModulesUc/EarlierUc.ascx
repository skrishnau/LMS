<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EarlierUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.EarlierUc" %>

<div class="dashboard-modules">
    <strong>Earlier</strong>
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