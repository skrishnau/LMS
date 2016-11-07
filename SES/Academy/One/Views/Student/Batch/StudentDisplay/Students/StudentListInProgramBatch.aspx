<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/ViewsSite/User/UserMaster.Master" CodeBehind="StudentListInProgramBatch.aspx.cs" Inherits="One.Views.Student.Batch.StudentDisplay.Students.StudentListInProgramBatch" %>

<%@ Register Src="~/Views/Student/Batch/StudentDisplay/Students/StudentCreate/StudentCreateUc.ascx" TagPrefix="uc1" TagName="StudentCreateUc" %>
<%--<%@ Register Src="~/Views/Student/Batch/StudentDisplay/Students/StudentCreate/test.ascx" TagPrefix="uc1" TagName="test" %>--%>
<%--<%@ Register TagPrefix="uc1" TagName="studentlistuc" Src="~/Views/Student/Batch/StudentDisplay/Students/StudentListUc.ascx" %>--%>
<%@ Register Src="~/Views/Student/Batch/StudentDisplay/Students/StudentList/StudentListUC.ascx" TagPrefix="uc2" TagName="StudentListUC" %>
<%@ Register Src="~/Views/All_Resusable_Codes/Dialog/CustomDialog.ascx" TagPrefix="uc1" TagName="CustomDialog" %>




<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <%-- Main start
    <asp:FileUpload ID="FileUpload1" runat="server" />

    <asp:Button ID="Button1" runat="server" Text="Button" />
    main end
    <hr />
    <br />--%>
    <%-- test starat
    <uc1:test runat="server" ID="test" />
    <hr />
    test end--%>
    <%--<uc1:StudentCreateUc runat="server" ID="StudentCreateUc" />--%>


    <div style="padding: 5px; margin: 0 5px 5px 5px;">
        <div style="margin-bottom: 20px; font-weight: 700;">
            <span style="font-size: 1.5em; text-align: center; display: block;">
                <asp:Label ID="lblProgramBatchName" runat="server" Text=""></asp:Label>
            </span>
            <hr />
        </div>

        <div style="margin: 0 5px 20px 5px; padding: 0 5px 5px 20px;">
            Currently in: N/A
                <br />
        </div>

        <div style="margin-top: 5px;">
            <strong>Student List</strong>
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                    <span style="float: right; margin: 0 20px 0; position: relative; right: 0; font-weight: 400;">Add Method
                        <asp:DropDownList ID="ddlAddStudent" Width="130px" runat="server"
                            OnSelectedIndexChanged="ddlAddStudent_SelectedIndexChanged" AutoPostBack="True">
                            <Items>
                                <asp:ListItem Text="Choose..." Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Create Student" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Improt From System" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Import From File" Value="2"></asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                    </span>
               <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
            <hr />
            <div>
                <%--<uc1:test runat="server" ID="test1" />--%>
                <div>
                   <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>--%>
                            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                <asp:View ID="View0" runat="server">
                                </asp:View>
                                <asp:View ID="View1" runat="server">
                                    <%--<uc1:StudentCreateUc runat="server" ID="StudentCreateUc" />--%>
                                    <div style="text-align: center;">
                                        <%--<uc1:CustomDialog runat="server" ID="CustomDialog" />--%>
                                        <uc1:StudentCreateUc runat="server" ID="StudentCreateUc1" />
                                        <%--<asp:FileUpload ID="FileUpload3" runat="server" />--%>
                                        <%--<uc2:StudentCreateUc runat="server" ID="StudentCreateUc1" />--%>
                                    </div>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <%--<uc1:StudentImportFromSystem runat="server" ID="StudentImportFromSystem" />--%>
                                </asp:View>
                                <asp:View ID="View3" runat="server">
                                    <%--<uc1:StudentImportFrommFile runat="server" ID="StudentImportFrommFile" />--%>
                                </asp:View>
                            </asp:MultiView>
                        <%--</ContentTemplate>
                    </asp:UpdatePanel>--%>
                </div>
                <br />
                <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
            </div>
            <uc2:StudentListUC runat="server" ID="StudentListUC11" />
            <%--<hr />--%>
            <%--<uc1:studentlistuc runat="server" ID="StudentListUc1" />--%>
        </div>

        <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
        <asp:HiddenField ID="hidProgramBatchId" runat="server" Value="0" />
    </div>
</asp:Content>

<asp:Content runat="server" ID="contenthead" ContentPlaceHolderID="head">
    <link href="../../../../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />
</asp:Content>