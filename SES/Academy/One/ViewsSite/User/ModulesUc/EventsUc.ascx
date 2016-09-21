<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EventsUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.EventsUc" %>


<div class="module-whole">
    <div class="modules-heading">
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="modules-title">Events</asp:HyperLink>
        <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
        <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />

    </div>
    <div class="modules-body-for-event" style="overflow: auto;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <div style="width: 180px; margin-right: auto; margin-left: auto; text-align: right; padding-top: 3px; padding-bottom: 3px;">

                    <asp:Calendar ID="Calendar1" runat="server" BackColor="#FFFFCC" BorderColor="#FFCC66"
                        BorderWidth="1px" DayNameFormat="Shortest"
                        NextPrevFormat="ShortMonth"
                        Font-Names="Verdana" Font-Size="9pt"
                        ForeColor="#663399" Height="140px"
                        ShowGridLines="True" Width="180px"
                        OnSelectionChanged="Calendar1_SelectionChanged"
                        OnVisibleMonthChanged="Calendar1_VisibleMonthChanged">
                        
                        <DayHeaderStyle BackColor="#FFCC66" Font-Bold="True" Height="1px" />

                        <NextPrevStyle Font-Size="8pt" ForeColor="#FFFFCC" />
                        <OtherMonthDayStyle ForeColor="#CC9966" />
                        <SelectedDayStyle BackColor="#CCCCFF" Font-Bold="True" />
                        <SelectorStyle BackColor="#FFCC66" />
                        <TitleStyle BackColor="#990000" Font-Bold="True" Font-Size="8pt" ForeColor="#FFFFCC" />
                        <TodayDayStyle BackColor="#FFCC66" ForeColor="White" />
                    </asp:Calendar>

                    <%--                    <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="gray"
                        BorderStyle="Solid" CellSpacing="1" 
                        Font-Names="Verdana" Font-Size="9pt"
                        ForeColor="Black" Height="100px"
                         DayNameFormat="Shortest" 
                         Width="140px"
                        NextPrevFormat="ShortMonth"
                         OnSelectionChanged="Calendar1_SelectionChanged" 
                        OnVisibleMonthChanged="Calendar1_VisibleMonthChanged">
                        
                        <DayHeaderStyle Font-Bold="True"  ForeColor="#822503" Height="1px" />
                        <DayStyle BackColor="#ffbda2" Font-Size="10pt" />
                        <NextPrevStyle Font-Bold="True" Font-Size="9pt" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#881c07" ForeColor="White" />
                        <TitleStyle BackColor="#e78a65" BorderStyle="Solid" BorderColor="white" Font-Bold="True" 
                            Font-Size="9pt"
                            ForeColor="White"
                            Height="9pt" />
                        <TodayDayStyle BackColor="#999999" ForeColor="White" />
                    </asp:Calendar>--%>
                </div>
                <div id="divEventDetail" style="width: 100%;"  runat="server" visible="False">
                    <asp:Panel ID="pnlEvents" runat="server"></asp:Panel>
                    <div style="text-align: right; margin-right: 3px;">
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="link" OnClick="LinkButton1_Click">Back to calendar</asp:LinkButton>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>


</div>
