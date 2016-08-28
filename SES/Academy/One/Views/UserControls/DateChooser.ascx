<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DateChooser.ascx.cs" Inherits="One.Views.UserControls.DateChooser" %>
<asp:Panel runat="server" ID="pnlDateChooser" Width="404px">

    <asp:UpdatePanel runat="server" ID="UpdatePanelM">
        <ContentTemplate>
            <div style="width: 100%;">
                <div style="float: left;">
                    <asp:TextBox ID="txtDate" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click"
                        Height="18px" ImageUrl="~/Content/Icons/calendar_image.png"
                        CausesValidation="false" />
                    <asp:RequiredFieldValidator ID="validator" runat="server"
                        ControlToValidate="txtDate"
                        ErrorMessage="Date is required." ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </div>
                <div style="float: left;">
                    <asp:Calendar ID="calendar" runat="server" BackColor="White" BorderColor="#3366CC"
                        BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana"
                        Font-Size="8pt" ForeColor="#003399" Height="41px" Width="220px"
                        OnSelectionChanged="Calendar1_SelectionChanged" Visible="False">
                        <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                        <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                        <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                        <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                        <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                        <WeekendDayStyle BackColor="#CCCCFF" />
                    </asp:Calendar>
                </div>
            <div style="clear: both;"></div>
            </div>
            <asp:CheckBox ID="checkDateRangeMin" runat="server" Text=" " Visible="False" />
            <asp:CheckBox ID="checkDateRangeMax" runat="server" Text=" " Visible="False" />
            <asp:TextBox ID="minDate" runat="server" Visible="False" Width="16px"></asp:TextBox>
            <asp:TextBox ID="maxDate" runat="server" Visible="False" Width="16px"></asp:TextBox>
            &nbsp;
            <asp:TextBox ID="txtMinDateValiationMessage" runat="server" Visible="False" Width="16px"></asp:TextBox>
            &nbsp;
            <asp:TextBox ID="txtMaxDateValiationMessage" runat="server" Visible="False" Width="16px"></asp:TextBox>


            &nbsp;&nbsp;&nbsp;

          
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
