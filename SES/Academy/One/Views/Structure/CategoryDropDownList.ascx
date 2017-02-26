<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryDropDownList.ascx.cs" Inherits="One.Views.Structure.CategoryDropDownList" %>

<div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="dropdownlist">
                <table style="width: 247px; border: 1px solid lightgray;">
                    <tr>
                        <td>
                            <span style="width: 247px;" class="dropdownlist-button">
                                <asp:Label ID="lblSelectedCategoryName" runat="server" Text="Choose..."></asp:Label>
                            </span>
                        </td>
                        <td style="width: 20px; vertical-align: top;">
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Arrow/arrow-down-icon-png-9.png" />
                        </td>
                    </tr>
                </table>
                <div class="dropdownlist-content">
                    <div style="border: 1px solid darkgray; overflow-y: scroll; height: 200px;">
                        <asp:Panel ID="pnlCategories" runat="server"></asp:Panel>
                    </div>
                </div>
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hidSchoolId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSelectedCategoryId" runat="server" Value="0" />
    <%--<asp:HiddenField ID="hidSelectedCategoryName" runat="server" Value="" />--%>
</div>

<style type="text/css">
    /* dropdownlist Button */
    .dropdownlist-button {
        /*background-color: #4CAF50;*/
        color: black;
        /*padding: 16px;*/
        /*font-size: 16px;*/
        border: none;
        cursor: pointer;
    }

    /* The container <div> - needed to position the dropdownlist content */
    .dropdownlist {
        position: relative;
        display: inline-block;
    }

        /* Show the dropdownlist menu on hover */
        .dropdownlist:hover .dropdownlist-content {
            display: block;
        }

        /* Change the background color of the dropdownlist button when the dropdownlist content is shown */
        .dropdownlist:hover .dropbtn {
            /*background-color: #3e8e41;*/
            background-color: #8fbc8f;
        }
        /*test only*/
        .dropdownlist .dropdownlist-content {
            /*position: relative;*/
            /*display: inline-block;*/
            width: 235px;
            /*bottom: 100%;
                            left: 50%;*/
            top: 100%;
            right: 0%;
            margin-left: -60px;
            padding: 5px;
        }

            .dropdownlist .dropdownlist-content::after {
                content: " ";
                position: absolute;
                /*top: 0%; /* At the bottom of the tooltip --100%*/
                /*left: 100%;/*earlier 50%*/
                bottom: 100%;
                right: 0%;
                margin-left: -5px;
                border-width: 5px;
                border-style: solid;
                border-color: darkgray transparent transparent transparent;
            }
    /*end of test only*/

    /* dropdownlist Content (Hidden by Default) */
    .dropdownlist-content {
        display: none;
        position: absolute;
        /*position: relative;*/
        /*background-color: #f9f9f9;*/
        background-color: #557d96;
        border: 1px solid white;
        min-width: 160px;
        box-shadow: 0px 8px 16px 0px rgba(0,0,0,0.2);
    }

        /*.dropdownlist-content a {
                                color: white;
                            }*/
        .dropdownlist-content a {
            color: white;
            /*padding: 12px 16px;*/
            padding: 0 10px;
            text-decoration: none;
            display: block;
        }
            /* Links inside the dropdownlist */

            /* Change color of dropdownlist links on hover */
            .dropdownlist-content a:hover {
                /*background-color: #f1f1f1;*/
                background-color: #f1f1f1;
                color: black;
            }

                .dropdownlist-content a:hover a {
                    color: black;
                }
</style>

