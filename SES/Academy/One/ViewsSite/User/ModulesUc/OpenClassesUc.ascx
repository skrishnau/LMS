<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenClassesUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.OpenClassesUc" %>


<div class="module-whole" style="height: 200px; overflow-y: auto; vertical-align: top;">
    <div class="modules-title">
        Open Classses 
    </div>

    <%-- modules-body list-item list-unmargined --%>
    <div class="list-dark-datalist" >
        <asp:Panel ID="pnlListOpenClasses" runat="server"></asp:Panel>

        <asp:DataList ID="DataList1" Height="100%" runat="server" Width="100%" DataSourceID="objectdatasource1">
            <ItemTemplate>
                <div>
                    <%--class="auto-st2" CssClass="link" --%>
                    <asp:HyperLink ID="HyperLink1" runat="server"
                        NavigateUrl='<%# "~/Views/Class/SelfEnrolment.aspx?ccId="+Eval("ClassId") %>'>
                        <asp:Label ID="ClassNameLabel" runat="server"  Text='<%# Eval("ClassName") %>' />
                        <br />
                        <span style="color: #808080; font-size: 0.9em;">Starts on:
                            <asp:Label ID="StartDateLabel" runat="server" Text='<%# Eval("StartDate") %>' />
                        </span>
                    </asp:HyperLink>
                </div>
            </ItemTemplate>

        </asp:DataList>

        <asp:ObjectDataSource runat="server" ID="objectdatasource1" SelectMethod="ListOpenClasses" TypeName="Academic.DbHelper.DbHelper+Classes">
            <SelectParameters>
                <asp:ControlParameter ControlID="hidSchoolId" DefaultValue="0" Name="schoolId" PropertyName="Value" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>

    </div>

</div>

<asp:HiddenField ID="hidUserId" runat="server" Value="0" />
<asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
