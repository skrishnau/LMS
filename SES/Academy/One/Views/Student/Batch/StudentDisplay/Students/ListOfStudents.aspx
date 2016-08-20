<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ListOfStudents.aspx.cs" Inherits="One.Views.Student.Batch.StudentDisplay.Students.ListOfStudents" %>

<%@ Register Src="~/Views/Student/Batch/StudentDisplay/Students/StudentListUc.ascx" TagPrefix="uc1" TagName="StudentListUc" %>
<%@ Register Src="~/Views/Student/Create/StudentCreateUc.ascx" TagPrefix="uc1" TagName="StudentCreateUc" %>
<%@ Register Src="~/Views/Student/Batch/StudentDisplay/Students/StudentCreate/StudentCreateUc.ascx" TagPrefix="uc2" TagName="StudentCreateUc" %>
<%@ Register Src="~/Views/Student/Batch/StudentDisplay/Students/StudentImport/StudentImportFromSystem.ascx" TagPrefix="uc1" TagName="StudentImportFromSystem" %>
<%@ Register Src="~/Views/Student/Batch/StudentDisplay/Students/StudentImport/StudentImportFrommFile.ascx" TagPrefix="uc1" TagName="StudentImportFrommFile" %>
<%@ Register Src="~/Views/Student/Batch/StudentDisplay/Students/StudentCreate/test.ascx" TagPrefix="uc1" TagName="test" %>







<asp:Content runat="server" ID="content1" ContentPlaceHolderID="Body">
    <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--<asp:FileUpload ID="FileUpload2" runat="server" />--%>
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
                    <span style="float: right; margin: 0 20px 0; position: relative; right: 0; font-weight: 400;">Add Method
                        <asp:DropDownList ID="ddlAddStudent" Width="130px" runat="server" OnSelectedIndexChanged="ddlAddStudent_SelectedIndexChanged" AutoPostBack="True">
                            <Items>
                                <asp:ListItem Text="Choose..." Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Create Student" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Improt From System" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Import From File" Value="2"></asp:ListItem>
                            </Items>
                        </asp:DropDownList>
                    </span>
                    <hr />
                    <div>
                        <%--<uc1:test runat="server" ID="test" />--%>
                        <div>
                            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                                <asp:View ID="View0" runat="server"></asp:View>
                                <asp:View ID="View1" runat="server">
                                    <%--<uc1:StudentCreateUc runat="server" ID="StudentCreateUc" />--%>
                                    <div style="text-align: center;">
                                        <uc2:StudentCreateUc runat="server" ID="StudentCreateUc1" />
                                        <%--<asp:FileUpload ID="FileUpload3" runat="server" />--%>
                                        <%--<uc2:StudentCreateUc runat="server" ID="StudentCreateUc1" />--%>
                                    </div>
                                </asp:View>
                                <asp:View ID="View2" runat="server">
                                    <uc1:StudentImportFromSystem runat="server" ID="StudentImportFromSystem" />
                                </asp:View>
                                <asp:View ID="View3" runat="server">
                                    <uc1:StudentImportFrommFile runat="server" ID="StudentImportFrommFile" />
                                </asp:View>
                            </asp:MultiView>
                        </div>
                        <br />
                        <%--<asp:FileUpload ID="FileUpload1" runat="server" />--%>
                        <uc1:StudentListUc runat="server" ID="StudentListUc" />
                    </div>
                </div>

                <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
                <asp:HiddenField ID="hidProgramBatchId" runat="server" Value="0" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--<asp:FileUpload ID="FileUpload2" runat="server" />--%>
</asp:Content>
