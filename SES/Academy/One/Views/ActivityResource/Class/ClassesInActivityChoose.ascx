<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClassesInActivityChoose.ascx.cs" Inherits="One.Views.ActivityResource.Class.ClassesInActivityChoose" %>

<div class="panel panel-default">
    <div class="panel-heading">
        Classes
    <style type="text/css">
        .panel-with-border {
            min-height: 22px;
            border: 1px dashed grey;
            padding: 8px 8px 2px;
            width: 100%;
            margin-bottom: 4px;
        }

        .removeButton {
            line-height: 22px;
            vertical-align: top;
            /*background-color: pink;*/
            color: red;
        }

            .removeButton:hover {
                /*background-color: yellow;*/
                color: firebrick;
                border: 1px dotted red;
                font-weight: 900;
                font-size: 1.1em;
            }
    </style>
        <link href="../../../Content/CSSes/ToolTip.css" rel="stylesheet" />
    </div>

    <div class="panel-body">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>

                <table style="">
                    <tr>
                        <td class="data-type">Post to class *
                        </td>
                        <td class="data-value" style="text-align: left; width: 81%;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <div style="width: 100%;">
                                        <asp:Panel runat="server" ID="pnlClasses" Width="100%"
                                            CssClass="panel-with-border" Visible="False">
                                        </asp:Panel>
                                    </div>

                                    <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True"
                                        Height="23px" Width="150px"
                                        ToolTip="If not selected any, then, this activity will be visible to you only."
                                        OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"
                                        DataTextField="Name" DataValueField="Id">
                                    </asp:DropDownList>

                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>

            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
        <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
        <asp:HiddenField ID="hidIsManager" runat="server" Value="False" />
    </div>

</div>
