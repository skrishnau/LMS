<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseDetailUc.ascx.cs" Inherits="One.Views.Course.Display.EachCourse.CourseDetailUc" %>
<%--<%@ Register Src="~/Views/Course/Section/CreateSectionUc.ascx" TagPrefix="uc1" TagName="CreateSectionUc" %>--%>

<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <%-- Section List --%>
            <asp:Panel ID="pnlContent" runat="server">
                <div class="item" style="float: left;">
                    <%--  class="item" up --%>
                    <div>
                        <div class="item-detail">
                            <asp:PlaceHolder ID="pnlSections" runat="server"></asp:PlaceHolder>
                            <%--<asp:PlaceHolder ID="pnlResource" runat="server"></asp:PlaceHolder>--%>
                        </div>
                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </div>
                </div>
            </asp:Panel>
            <%-- CssClass="popup" --%>
            <%--<asp:Panel ID="pnlCreateSection" runat="server" Visible="False">
                <uc1:CreateSectionUc runat="server" ID="CreateSectionUc1" />
                <%--<asp:Panel ID="innerpanel" runat="server" CssClass="popup">
                <%--</asp:Panel>
            </asp:Panel>--%>
            <br />
            <div style="clear: both;"></div>
            <div>
                <asp:LinkButton ID="lnkAddSection" runat="server" OnClick="lnkAddSection_Click">
                    <asp:ImageButton ID="imgAddSection" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" Height="20" Width="20" ToolTip="Add Section to this Course" />
                    Add Sections
                </asp:LinkButton>
            </div>
            <%-- END --%>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- <script>
        $("#dialog-section-create").dialog({ autoOpen: false });
        $("#opener1").click(function () {
            $("##dialog-section-create").dialog("open");
        });
    </script>--%>
    <script type="text/javascript">
        //$(document).ready(function () {
        //    $(function () {
        //        $("#dialogCreate").dialog({
        //            autoOpen: false
        //        });
        //        $("#btn").on("click", function () {
        //            $("#dialogCreate").dialog("open");
        //        });
        //    });
        //    //// Validating Form Fields.....
        //    //$("#submit").click(function (e) {
        //    //    var email = $("#email").val();
        //    //    var name = $("#name").val();
        //    //    var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
        //    //    if (email === '' || name === '') {
        //    //        alert("Please fill all fields...!!!!!!");
        //    //        e.preventDefault();
        //    //    } else if (!(email).match(emailReg)) {
        //    //        alert("Invalid Email...!!!!!!");
        //    //        e.preventDefault();
        //    //    } else {
        //    //        alert("Form Submitted Successfully......");
        //    //    }
        //    //});
        //});
    </script>
</div>
