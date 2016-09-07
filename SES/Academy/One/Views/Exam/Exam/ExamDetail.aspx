<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ExamDetail.aspx.cs" Inherits="One.Views.Exam.Exam.ExamDetail" %>

<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div>
        Exam Detail
        <div style="text-align: center;">
            <strong >
                <asp:Label ID="lblName" Font-Size="1.3em" runat="server" Text="Label"></asp:Label>
            </strong>
            <hr />
        </div>
        <div style="margin-left: 20px;">
           
            <div>
                <table>
                    <tr>
                        <td class="auto-style1">Weight</td>
                        <td>
                            <asp:Label ID="lblWeight" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Start Date</td>
                        <td>
                            <asp:Label ID="lblStartDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">Result Date</td>
                        <td>
                            <asp:Label ID="lblResultDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>

                </table>
            </div>
            <br />
             <div>
                <strong>Exams of each Program</strong>
                <hr/>
                 list all the year/subyear included in this exam
            </div>
            <br/>
            <strong>Notice</strong>
            <hr />
            <div style="clear: both;"></div>
            <div style="width: 100%; padding: 4px; border: 2px solid lightblue;" runat="server" id="noticeDiv">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
               
                <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
            </div> 
            <div style="text-align: right;">
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True">View Full Size</asp:HyperLink>
            </div>
            <br />
            <div style="clear: both;"></div>
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 140px;
        }
    </style>
</asp:Content>

