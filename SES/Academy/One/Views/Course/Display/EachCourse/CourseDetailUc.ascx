<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CourseDetailUc.ascx.cs" Inherits="One.Views.Course.Display.EachCourse.CourseDetailUc" %>
<%@ Register Src="~/Views/Course/Section/CreateSectionUc.ascx" TagPrefix="uc1" TagName="CreateSectionUc" %>



<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <%-- Section List --%>
            <asp:Panel ID="pnlContent" runat="server">
                <div class="item" style="float: left;">
                    <%--  class="item" up --%>
                    <div>
                        <%-- <div class="item-heading">
                <div class="float-left">
                    <asp:LinkButton ID="lblTitle" runat="server" Text="Heading"></asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp; 
                </div>

                <div class="float-right item-Option">
                    <asp:LinkButton ID="lnkEdit" runat="server">
                        <asp:Image ID="imgEditBtn" runat="server" Height="16" Width="14" ImageUrl="~/Content/Icons/Edit/edit_black_and_white.png" />
                    </asp:LinkButton>
                </div>


            </div>
            <div class="item-summary">
                <asp:Label ID="lblSummary" runat="server" Text="Description"></asp:Label>
            </div>--%>

                        <div class="item-detail">
                            <asp:PlaceHolder ID="pnlSections" runat="server"></asp:PlaceHolder>
                            <%--<asp:PlaceHolder ID="pnlResource" runat="server"></asp:PlaceHolder>--%>
                        </div>

                        <%--<div class="item-message">
            <asp:PlaceHolder ID="pnlMessages" runat="server"></asp:PlaceHolder>
        </div>--%>

                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                       
                    </div>

                </div>
            </asp:Panel>
            <%-- CssClass="popup" --%>
            <asp:Panel ID="pnlCreateSection" runat="server"  Visible="False">
                <%--<div class="popup-background">_</div>--%>
                <%--<asp:Panel ID="innerpanel" runat="server" CssClass="popup">--%>
                <uc1:CreateSectionUc runat="server" ID="CreateSectionUc1" />
                <%--</asp:Panel>--%>
            </asp:Panel>
            <br/>
            <div style="clear: both;"></div>
            <div>
                <asp:LinkButton ID="lnkAddSection" runat="server" OnClick="lnkAddSection_Click">
                    <asp:ImageButton ID="imgAddSection" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" Height="20" Width="20" ToolTip="Add Section to this Course" />
                    Add Sections
                </asp:LinkButton>
            </div>

            <%--<input id="btn" type="submit" name="submit" value="submit" />--%>
            <%-- <div id="dialogCreate">
                <uc1:CreateSectionUc runat="server" ID="CreateSectionUc1" />
            </div>--%>
            <%-- END --%>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script type="text/javascript">
        $(document).ready(function () {
            $(function () {
                $("#dialogCreate").dialog({
                    autoOpen: false
                });
                $("#btn").on("click", function () {
                    $("#dialogCreate").dialog("open");
                });
            });
            // Validating Form Fields.....
            $("#submit").click(function (e) {
                var email = $("#email").val();
                var name = $("#name").val();
                var emailReg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/;
                if (email === '' || name === '') {
                    alert("Please fill all fields...!!!!!!");
                    e.preventDefault();
                } else if (!(email).match(emailReg)) {
                    alert("Invalid Email...!!!!!!");
                    e.preventDefault();
                } else {
                    alert("Form Submitted Successfully......");
                }
            });
        });

    </script>
</div>
