<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ChoiceCreate.aspx.cs" Inherits="One.Views.ActivityResource.Choice.ChoiceCreate" %>



<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Src="~/Views/RestrictionAccess/Custom/RestrictionUC.ascx" TagPrefix="uc1" TagName="RestrictionUC" %>
<%@ Register Src="~/Views/ActivityResource/Choice/ChoiceOptionsCreate.ascx" TagPrefix="uc1" TagName="ChoiceOptionsCreate" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">


    <link rel="stylesheet" href="../../../DatePickerJquery/jquery-ui-1.9.2.custom.css" />
    <script src="../../../DatePickerJquery/jquery-1.8.3.js"></script>

    <link rel="stylesheet" href="../../../DatePickerJquery/timepicker/jquery.timepicker.css" />
    <script src="../../../DatePickerJquery/timepicker/jquery.timepicker.min.js"></script>
    <%--<script src="../../../DatePickerJquery/timepicker/GruntFile.js"></script>--%>
    <link href="../../../Content/CSSes/TableStyles.css" rel="stylesheet" />

    <script type="text/javascript">
        function pageLoad() {
            $('#txtOpenDate').unbind();
            $('#txtOpenDate').datepicker();

            $('#txtUntilDate').unbind();
            $('#txtUntilDate').datepicker();


            //$('#txtOpenTime').unbind();
            //$('#txtOpenTime').timepicker();

            //$('#txtUntilTime').unbind();
            //$('#txtUntilTime').timepicker();

        }
    </script>
</asp:Content>

<asp:Content runat="server" ID="contnet1" ContentPlaceHolderID="Body">
    <div class="create-edit-whole">
        <h3 class="heading-of-create-edit">
            <asp:Label ID="lblHeading" runat="server" Text="Add New Choice"></asp:Label>
        </h3>
        <div class="data-entry-body">
            <div class="data-entry-section">
                <div class="data-entry-section-heading">
                    General
                    <hr />
                </div>
                <div class="data-entry-section-body">
                    <table>
                        <tr>
                            <td class="data-type">Name</td>
                            <td class="data-value">
                                <asp:TextBox ID="txtName" runat="server" Width="170"></asp:TextBox>
                            </td>
                        </tr>

                        <tr>
                            <td class="data-type">Description</td>
                            <td class="data-value">
                                <CKEditor:CKEditorControl ID="txtDescription" BasePath="/ckeditor/" runat="server"></CKEditor:CKEditorControl>
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Display discription on course page</td>
                            <td class="data-value">
                                <asp:CheckBox ID="chkDisplayDescription" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="data-type">Options display mode</td>
                            <td class="data-value">
                                <asp:DropDownList ID="ddlDisplayModeForOptions" runat="server">
                                    <Items>
                                        <asp:ListItem Value="0" Text="Horizontal"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="Vertical"></asp:ListItem>
                                    </Items>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <%-- section end --%>

            <div class="data-entry-section">
                <div class="data-entry-section-heading">
                    Options
                    <hr />
                </div>
                <div class="data-entry-section-body">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td class="data-type">Aloow choice to be updated</td>
                                    <td class="data-value">
                                        <asp:DropDownList ID="ddlAllowChoiceToBeUpdated" runat="server">
                                            <Items>
                                                <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                            </Items>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="data-type">Allow more than one choice to be selected</td>
                                    <td class="data-value">
                                        <asp:DropDownList ID="ddlAllowMoreChoiceToBeSelected" runat="server">
                                            <Items>
                                                <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                            </Items>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="data-type">Limit the number of responses</td>
                                    <td class="data-value">
                                        <asp:DropDownList ID="ddlLimitTheNumberOfResponses" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLimitTheNumberOfResponses_SelectedIndexChanged">
                                            <Items>
                                                <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                            </Items>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div>
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>

                                <asp:Panel ID="pnlOptions" runat="server">
                                   <%-- <uc1:ChoiceOptionsCreate runat="server" id="ChoiceOptionsCreate" OptionName="Option1"
                                         OnRemoveClicked="uc_RemoveClicked" />
                                    <uc1:ChoiceOptionsCreate runat="server" id="ChoiceOptionsCreate1" OptionName="Option2"
                                        OnRemoveClicked="uc_RemoveClicked" 
                                        />--%>

                                </asp:Panel>
                                
                                <div>
                                    <asp:LinkButton ID="lnkAddMoreOptions" runat="server" OnClick="lnkAddMoreOptions_Click" >
                                Add more options
                                    </asp:LinkButton>
                                </div>
                                <asp:HiddenField ID="hidCountOfOptions" runat="server" Value="2"/>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>
            <br />


            <div class="data-entry-section">
                <div class="data-entry-section-heading">
                    Appearance
                    <hr />
                </div>
                <div class="data-entry-section-body">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td class="data-type">Restrict answering time</td>
                                    <td class="data-value">
                                        <asp:CheckBox ID="chkRestrictAnsweringTime" runat="server" AutoPostBack="True"
                                            OnCheckedChanged="chkRestrictAnsweringTime_CheckedChanged" />
                                    </td>
                                </tr>

                                <tr>
                                    <td class="data-type">Open date</td>
                                    <td class="data-value">
                                        <asp:TextBox ID="txtOpenDate" ClientIDMode="Static" runat="server" Enabled="False"></asp:TextBox>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="txtOpenTime" ClientIDMode="Static" runat="server" Width="30" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="data-type">Until</td>
                                    <td class="data-value">
                                        <asp:TextBox ID="txtUntilDate" ClientIDMode="Static" runat="server" Enabled="False"></asp:TextBox>
                                        &nbsp;&nbsp;
                                        <asp:TextBox ID="txtUntilTime" ClientIDMode="Static" runat="server" Width="30" Enabled="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="data-type">Show preview</td>
                                    <td class="data-value">
                                        <asp:CheckBox ID="chkShowPreview" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <%-- SEction end --%>


            <div class="data-entry-section">
                <div class="data-entry-section-heading">
                    Results
                    <hr />
                </div>
                <div class="data-entry-section-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td class="data-type">Publish results</td>
                                    <td class="data-value">
                                        <asp:DropDownList ID="ddlPublishResults" runat="server"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddlPublishResults_SelectedIndexChanged">
                                            <Items>
                                                <asp:ListItem Value="0" Text="Do not publish results to students"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Show results to students after they answer"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Show results to students only after the choice is closed"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Always show results to students"></asp:ListItem>
                                            </Items>
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="data-type">Privacy of results</td>
                                    <td class="data-value">
                                        <asp:DropDownList ID="ddlPrivacyOfResults"  runat="server" Enabled="False">
                                            <Items>
                                                <asp:ListItem Value="0" Text="Publish anonymous results, do not show student names "></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Publish full result, showing names and their choices"></asp:ListItem>
                                            </Items>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="data-type">Show columns for unanswered</td>
                                    <td class="data-value">
                                        <asp:DropDownList ID="ddlShowColumnsForUnanswered" runat="server" Enabled="False">
                                            <Items>
                                                <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                            </Items>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="data-type">Include responses fron inactive users</td>
                                    <td class="data-value">
                                        <asp:DropDownList ID="ddlIncludeResponsesFromInactiveUsers" runat="server" Enabled="False">
                                            <Items>
                                                <asp:ListItem Value="0" Text="No"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Yes"></asp:ListItem>
                                            </Items>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>

                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>




            <div class="data-entry-section">
                <div class="data-entry-section-heading">
                    Restriction
                    <hr />
                </div>
                <div class="data-entry-section-body">
                    <uc1:RestrictionUC runat="server" ID="RestrictionUC" />
                </div>
            </div>
            <%-- section end --%>

            <div class="save-div">
                <asp:Button ID="btnSave" runat="server" Text="Save and return to Course" OnClick="btnSave_Click" />
                &nbsp;&nbsp;
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hidChoiceId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSectionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidPageKey" runat="server" Value="0" />

    <script type="text/javascript">
        CKEDITOR.replace(CKEditor1,
            {
                enterMode: CKEDITOR.ENTER_DIV

            });
    </script>
</asp:Content>
