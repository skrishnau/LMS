<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ActivityAndResourceUc.ascx.cs" Inherits="One.Views.Course.Section.ActivityAndResourceUc" %>

<div>
    <div class="item">
        <div class="act-res-heading">
            <div style="float: left;">
                <asp:Image ID="imgIcon" runat="server" ImageUrl="~/Content/Icons/Action/assign.png" />
                    &nbsp;&nbsp;
                 <asp:LinkButton ID="lblTitle" runat="server" Text="Heading">
                   
                </asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp; 
            </div>
            <div style="float: right;">
                <asp:ImageButton ID="imgEditBtn" runat="server" Height="16px" ImageUrl="~/Content/Icons/AddEditDelete/edit_3.png" OnClick="imgEditBtn_Click" Width="16px" />
            </div>
            <%--  <div class="float-right " style="width: 62px;">
                
           <font size="1em">
           <asp:LinkButton ID="lnkWithdraw" runat="server" OnClick="lnkWithdraw_Click">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Participation/out.png" 
                Width="16" Height="16" />
            Withdraw from course
        </asp:LinkButton>
       </font>
            </div>--%>
        </div>
        <div class="item-summary">
            <asp:Label ID="lblSummary" runat="server" Text=""></asp:Label>
        </div>

        <div class="item-detail">
            <asp:PlaceHolder ID="pnlActAndRes" runat="server"></asp:PlaceHolder>
            <%--<asp:PlaceHolder ID="pnlResource" runat="server"></asp:PlaceHolder>--%>
        </div>

        <%--<div class="item-message">
            <asp:PlaceHolder ID="pnlMessages" runat="server"></asp:PlaceHolder>
        </div>--%>

        <asp:HiddenField ID="hid" runat="server" Value="0" />
        <asp:HiddenField ID="hidActOrResId" runat="server" Value="0" />
        <asp:HiddenField ID="hidType" runat="server" Value="0" />
    </div>

</div>
