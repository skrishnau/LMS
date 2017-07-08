<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListOfSectionsInCourseUC.ascx.cs" Inherits="One.Views.Course.Section.Master.ListOfSectionsInCourseUC" %>

<%--<%@ Register Src="~/Views/Course/Section/CreateSectionUc.ascx" TagPrefix="uc1" TagName="CreateSectionUc" %>--%>
<%@ Register Src="~/Views/Course/ActivityAndResource/ActResChoose/ActResChooseUc.ascx" TagPrefix="uc1" TagName="ActResChooseUc" %>



<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <%-- Section List --%>
            <%--<asp:Panel ID="pnlContent" runat="server">--%>

            <div class="item-detail">
                <asp:PlaceHolder ID="pnlSections" runat="server"></asp:PlaceHolder>
            </div>
            <asp:HiddenField ID="hidId" runat="server" Value="0" />

            <%--</asp:Panel>--%>
            <%-- <asp:Panel ID="pnlCreateSection" runat="server" Visible="False">
                <uc1:CreateSectionUc runat="server" ID="CreateSectionUc1" />

            </asp:Panel>--%>


            <br />
            <div style="clear: both;"></div>
            <div>
                <%-- CssClass="link-white" --%>
                <asp:HyperLink ID="lnkAddSection1" ClientIDMode="Static" Visible="False" ToolTip="Add Section to this Course"
                    CssClass="auto-st2 link"
                    runat="server">
                    <asp:ImageButton ID="imgAddSection" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon-14px.png" />
                    Add Section
                </asp:HyperLink>
            </div>



            <div id="activitychoosediv" style="display: none">
                <uc1:ActResChooseUc runat="server" ID="ActResChooseUc" ClientIDMode="Static" />
            </div>
            <a id="last"></a>
            <%-- END --%>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:HiddenField ID="hidEditEnabled" runat="server" Value="False" />
    <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />

    <script type="text/javascript">

        $("[class*=link_act_res]").on("click", function () {

            var dlg = $("#activitychoosediv")
                .dialog({
                    width: 450,
                    minHeight: 10,
                    minwidth: 10,
                    modal: true,
                    title: "Activity/Resource in : " + this.name

                });
            dlg.parent().appendTo(jQuery("form:first"));
            __doPostBack('', this.id);

            var parameter = Sys.WebForms.PageRequestManager.getInstance();
            parameter.add_endRequest(function () {
                //jquery code again for working after postback
                $("[class*=link_act_res]").on("click", function () {
                    var dlg = $("#activitychoosediv")
                        .dialog({
                            width: 450,
                            minHeight: 10,
                            minwidth: 10,
                            modal: true,
                            title: "Activity/Resource in : " + this.name

                        });
                    dlg.parent().appendTo(jQuery("form:first"));
                    __doPostBack('', this.id);
                    return false;
                });
            });

            return false;
        });

    </script>

</div>
