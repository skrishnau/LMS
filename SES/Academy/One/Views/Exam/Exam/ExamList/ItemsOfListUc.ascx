<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ItemsOfListUc.ascx.cs" Inherits="One.Views.Exam.Exam.ExamList.ItemsOfListUc" %>

<div class="item-exam">
    <div class="item-heading-exam">
        <span class="head-text">
            <asp:LinkButton ID="lblHeading" runat="server" OnClick="lblHeading_Click">LinkButton</asp:LinkButton>
        </span>
        <span class="item-Option">
            <asp:Literal ID="lblType" runat="server"></asp:Literal>
        </span>

        <div class="item-Option float-right">
            <asp:ImageButton ID="imgBtnEdit" runat="server" ImageUrl="~/Content/Icons/Edit/edit_black_and_white.png" OnClick="imgBtnEdit_Click" CausesValidation="False" />

        </div>

    </div>


    <div class="item-summary-exam">
        <div class="width-100">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                <div style="width: 50%; float: left;">
                    Weight:
                        <asp:Literal ID="lblWeight" runat="server"></asp:Literal>
                    <br />

                </div>
                <div style="width: 50%; float: left;">
                    Start Date:
                    <span class="width-100px">
                        <asp:Literal ID="lblStartDate" runat="server"></asp:Literal>
                    </span>
                    <br />
                    Result Date:
                    <span class="width-100px">
                        <asp:Literal ID="lblResultDate" runat="server"></asp:Literal>
                    </span>
                    <br />
                </div>
            </asp:PlaceHolder>
        </div>
        <div style="float: none; width: 100%;">
            <asp:PlaceHolder ID="PlaceHolder2" runat="server">
                <div class="width-100" style="background-color: #fffff0;">
                    <strong>Notice:</strong>
                    <asp:Label ID="lblNotice" runat="server" Text="Label"></asp:Label>
                </div>
            </asp:PlaceHolder>
        </div>
        <hr />
        <div>
            <asp:HiddenField ID="hidExamId" runat="server" />
        </div>
        <%--<div ">
         Created: 
            <asp:Literal ID="lblCreatedDate" runat="server"></asp:Literal>
            &nbsp;&nbsp;&nbsp;
            Updated:  
            <asp:Literal ID="lblUpdatedDate" runat="server"></asp:Literal>
    </div>--%>
    </div>
</div>
