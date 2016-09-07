<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ExamTypeList.aspx.cs" Inherits="One.Views.Exam.ExamType.ExamTypeList" %>

<asp:Content runat="server" ID="headcontent1" ContentPlaceHolderID="head">
    <style type="text/css">
        .item1 {
            margin: 10px;
            padding: 5px;
            background-color: azure;
            border: 2px lightgray solid;
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <div>
        <div style="text-align: center; font-size: 1.3em;">
            <strong>Exam Types</strong>
            <hr />
        </div>
        <div style="text-align: right;">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Views/Exam/ExamType/ExamTypeCreate.aspx">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Content/Icons/Add/Add-icon.png" />
                New Type
            </asp:HyperLink>
        </div>
        <div>
            <asp:DataList ID="DataList1" runat="server" Width="100%">
                <ItemTemplate>
                    <asp:HiddenField ID="hidExamTypeId" runat="server" Value='<%# Eval("Id") %>' />
                    <div class="item1">
                        <asp:HyperLink ID="HyperLink1" Font-Size="1.1em" Font-Bold="True"
                            runat="server" Text='<%#Eval("Name") %>' ToolTip="Click to Edit"
                            NavigateUrl='<%# "~/Views/Exam/ExamType/ExamTypeCreate.aspx?etId="+Eval("Id") %>'></asp:HyperLink>
                        <div style="margin: 5px 5px 5px 20px">
                            <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Description") %>'></asp:Literal>
                            <br />

                        </div>
                        <div style="margin: 15px; padding: 5px;">
                            <strong>Weight: &nbsp;</strong>
                            <asp:Label ID="Label1" runat="server"
                                Text='<%# GetWeight(Eval("IsPercent"),Eval("Weight")) %>'></asp:Label>
                        </div>
                    </div>

                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
</asp:Content>
