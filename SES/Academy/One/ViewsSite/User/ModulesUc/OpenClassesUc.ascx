<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenClassesUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.OpenClassesUc" %>


<%-- class="module-whole"style="height: 200px; overflow-y: auto; vertical-align: top;" --%>
<div class="panel panel-default">
    <div class="panel-heading">
        Open Classses 
    </div>

    <%-- class="list-dark-datalist" modules-body list-item list-unmargined --%>
    <%--<div class="panel-body">--%>
    <asp:Panel ID="pnlListOpenClasses" runat="server"></asp:Panel>

    <asp:DataList ID="DataList1" Height="100%" runat="server" Width="100%"
        CssClass="list-group"
        DataSourceID="objectdatasource1">
        <FooterTemplate>
            <asp:label visible="<%#bool.Parse((DataList1.Items.Count==0).ToString())%>" xmlns:asp="#unknown"
                runat="server" id="lblNoRecord" text="None"></asp:label>
        </FooterTemplate>
        <ItemTemplate>
            <%--<div >--%>
            <%--class="auto-st2" CssClass="link" --%>
            <%-- style="color: #808080; font-size: 0.9em;" --%>
            <asp:HyperLink ID="HyperLink1" runat="server" CssClass="list-group-item"
                NavigateUrl='<%# "~/Views/Class/SelfEnrolment.aspx?ccId="+Eval("ClassId") %>'>
                <asp:Label ID="ClassNameLabel" runat="server" Text='<%# Eval("ClassName") %>' />
                <br />
                <div class="list-item-description">
                    <table>
                        <tr>
                            <td>Starts on : </td>
                            <td>
                                <asp:Label ID="StartDateLabel" runat="server" Text='<%# Eval("StartDate") %>' /></td>
                        </tr>
                        <tr>
                            <td>Last Day to Join :</td>
                            <td>
                                <asp:Label ID="label44" runat="server" Text='<%# Eval("OpenTillDate") %>' /></td>
                        </tr>
                    </table>
                </div>

            </asp:HyperLink>
            <%--</div>--%>
        </ItemTemplate>

    </asp:DataList>

    <asp:ObjectDataSource runat="server" ID="objectdatasource1" SelectMethod="ListOpenClasses" TypeName="Academic.DbHelper.DbHelper+Classes">
        <SelectParameters>
            <asp:ControlParameter ControlID="hidSchoolId" DefaultValue="0" Name="schoolId" PropertyName="Value" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <%--</div>--%>
</div>

<asp:HiddenField ID="hidUserId" runat="server" Value="0" />
<asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
