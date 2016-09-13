<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListOfSectionsInCourseUC.ascx.cs" Inherits="One.Views.Course.Section.Master.ListOfSectionsInCourseUC" %>

<%@ Register Src="~/Views/Course/Section/CreateSectionUc.ascx" TagPrefix="uc1" TagName="CreateSectionUc" %>
<%@ Register Src="~/Views/Course/ActivityAndResource/ActResChoose/ActResChooseUc.ascx" TagPrefix="uc1" TagName="ActResChooseUc" %>



<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <%-- Section List --%>
            <asp:Panel ID="pnlContent" runat="server">
                
                <div>
                    <div>
                        <div class="item-detail">
                            <asp:PlaceHolder ID="pnlSections" runat="server"></asp:PlaceHolder>
                        </div>
                        <asp:HiddenField ID="hidId" runat="server" Value="0" />
                    </div>
                </div>
            </asp:Panel>
            <asp:Panel ID="pnlCreateSection" runat="server" Visible="False">
                <uc1:CreateSectionUc runat="server" ID="CreateSectionUc1" />

            </asp:Panel>


            <br />
            <div style="clear: both;"></div>
            <div>
                <asp:LinkButton ID="lnkAddSection" ClientIDMode="Static" Visible="False" runat="server" OnClick="lnkAddSection_Click">
                    <asp:ImageButton ID="imgAddSection" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" Height="20" Width="20" ToolTip="Add Section to this Course" />
                    Add Sections
                </asp:LinkButton>
            </div>

            <asp:HiddenField ID="hidEditEnabled" runat="server" Value="False" />
            <div id="sessioncreatediv" style="display: none">
                <%--This is a simple popup--%>
                <uc1:CreateSectionUc runat="server" ID="CreateSectionUc2" />
            </div>

            <div id="activitychoosediv" style="display: none">
                <uc1:ActResChooseUc runat="server" ID="ActResChooseUc" ClientIDMode="Static" />
            </div>

            <%-- END --%>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">

        $("[class*=link]").on("click",  function () {

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
                $("[class*=link]").on("click", function () {
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
