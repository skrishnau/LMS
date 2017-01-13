<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagerCourseUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.Course.ManagerCourseUc" %>

<div style="margin: 5px;">
    
    <asp:HyperLink ID="lnkCourseName" runat="server" CssClass="link">
        
    </asp:HyperLink>
    <hr runat="server" ID="hrBar"/>
    <div style=" margin-left: 10px;">
        <asp:DataList ID="dListClasses" runat="server" Width="98%">
            <ItemTemplate>
                <div class="auto-st2">
                    <em>
                        <asp:HyperLink ID="HyperLink5" runat="server" CssClass="link"
                            NavigateUrl='<%# Eval("Value") %>'
                            ToolTip='<%# Eval("IdInString") %>'
                            Text='<%# Eval("Name") %>'>
                        </asp:HyperLink>
                    </em>
                </div>
            </ItemTemplate>
        </asp:DataList>

        <asp:HyperLink ID="lnkClass" runat="server" Enabled="False">
        </asp:HyperLink>
    </div>
</div>
<%-- ■ --%>
