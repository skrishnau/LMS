<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="One.Views.Student.Batch.Student.Default" %>


<%@ Register Src="~/Views/Student/Batch/StudentDisplay/Students/StudentCreate/StudentCreateUc.ascx" TagPrefix="uc1" TagName="StudentCreateUc" %>
<%--<%@ Register Src="~/Views/Student/Batch/StudentDisplay/Students/StudentCreate/test.ascx" TagPrefix="uc1" TagName="test" %>--%>
<%--<%@ Register TagPrefix="uc1" TagName="studentlistuc" Src="~/Views/Student/Batch/StudentDisplay/Students/StudentListUc.ascx" %>--%>
<%@ Register Src="~/Views/Student/Batch/StudentDisplay/Students/StudentList/StudentListUC.ascx" TagPrefix="uc2" TagName="StudentListUC" %>
<%@ Register Src="~/Views/All_Resusable_Codes/Dialog/CustomDialog.ascx" TagPrefix="uc1" TagName="CustomDialog" %>



<asp:Content runat="server" ID="body" ContentPlaceHolderID="Body">

    <div >
        <h3 class="heading-of-create-edit">
            <asp:Label ID="lblProgramBatchName" runat="server" Text=""></asp:Label>
        </h3>
        <hr />
        <br />
        <div class="data-entry-section-body">

            <div>
                Currently in:
               <strong>
                   <asp:Label ID="lblCurrentlyIn" runat="server" Text="N/A"></asp:Label></strong>
            </div>
            <br />
        </div>

        <div class="data-entry-section-body">
            <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
            <div style="float: left;">
                <strong>Student List</strong>
            </div>


            <div style="float: right; margin: 0 20px 0; position: relative; right: 0; font-weight: 400;">
                <asp:Label runat="server" ID="lblAddMethod" Text="Add Method"></asp:Label>
                <asp:DropDownList ID="ddlAddStudent" Width="130px" runat="server"
                    OnSelectedIndexChanged="ddlAddStudent_SelectedIndexChanged" AutoPostBack="True">
                    <Items>
                        <asp:ListItem Text="Choose..." Value="-1"></asp:ListItem>
                        <asp:ListItem Text="Create Student" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Improt From System" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Import From File" Value="2"></asp:ListItem>
                    </Items>
                </asp:DropDownList>
            </div>
            <div style="clear: both;"></div>
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
            <%--    </ContentTemplate>
            </asp:UpdatePanel>--%>

            <%--<hr />--%>
            <%--<uc1:studentlistuc runat="server" ID="StudentListUc1" />--%>
        </div>

        <asp:HiddenField ID="hidBatchId" runat="server" Value="0" />
        <asp:HiddenField ID="hidProgramBatchId" runat="server" Value="0" />
    </div>


</asp:Content>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link href="../../../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />

</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="title">
    <asp:Literal ID="lblTitle" runat="server">Students list</asp:Literal>
</asp:Content>






<%-- 
--%>





