<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="ImportStudentFromFile.aspx.cs" Inherits="One.Views.Student.Batch.Student.ImportStudentFromFile" %>

<%@ Register Src="~/Views/All_Resusable_Codes/SiteMaps/SiteMapUc.ascx" TagPrefix="uc1" TagName="SiteMapUc" %>

<%@ Register Src="~/Views/ActivityResource/FileResource/FileResourceItems/FilesDisplay.ascx" TagPrefix="uc1" TagName="FilesDisplay" %>


<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="SiteMapPlace">
    <uc1:SiteMapUc runat="server" ID="SiteMapUc" />
</asp:Content>

<asp:Content runat="server" ID="body" ContentPlaceHolderID="Body">

    <h3 class="heading-of-listing">
        <asp:Label ID="lblProgramBatchName" runat="server" Text=""></asp:Label>
    </h3>

    <h3 class="heading-of-listing">
        <asp:Label ID="lblHeading" runat="server" Text="Import student From file"></asp:Label>
    </h3>


    <div>
        <h4>File format requirements</h4>
        <div style="margin-left: 20px;">
            <table>
                <tr>
                    <td><strong>Required Column Names : </strong></td>
                    <td>"CRN" and "Name" (case sensitive)</td>
                </tr>
                <tr>
                    <td><strong>Format : </strong></td>
                    <td>|... | CRN | Name | ...|</td>
                </tr>
                <tr>
                    <td><strong>Extensions : </strong></td>
                    <td>excel(.xls, xlsx) and .csv</td>
                </tr>
            </table>
        </div>
    </div>
    <br />
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <uc1:FilesDisplay runat="server" ID="FilesDisplay1" />
                <asp:Label ID="lblErrorLoadingMessage" runat="server" Text=""></asp:Label>
                <br />

                <div>
                    <strong>
                        <asp:Label ID="lblGridViewHeader" runat="server" Text="Contents of file" Visible="False"></asp:Label></strong>
                    <br />

                    <asp:GridView ID="GridView1" runat="server"
                        EnableViewState="True" ViewStateMode="Enabled"
                        AutoGenerateColumns="False" Width="98%">
                        <EmptyDataTemplate>
                            <div></div>
                        </EmptyDataTemplate>
                        <Columns>
                            <%--<asp:BoundField DataField="CRN" HeaderText="CRN" SortExpression="CRN" />--%>

                            <asp:TemplateField HeaderText="CRN">
                                <ItemTemplate>
                                    <%-- text-overflow: ellipsis --%>
                                    <div style="overflow: hidden; white-space: nowrap;">
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("CRN") %>' Font-Strikeout='<%# Eval("Void") %>' ForeColor='<%# GetColor(Eval("Void")) %>'></asp:Label>

                                    </div>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    <div style="text-align: left;">CRN</div>
                                </HeaderTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <div style="width: 100px; overflow: hidden; white-space: nowrap;">
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Name") %>' Font-Strikeout='<%# Eval("Void") %>' ForeColor='<%# GetColor(Eval("Void")) %>'></asp:Label>

                                    </div>
                                </ItemTemplate>
                                <HeaderTemplate>
                                    <div style="text-align: left;">Name</div>
                                </HeaderTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>
                </div>
                <%-- <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListStudentBatchesOfProgramBatch" TypeName="Academic.DbHelper.DbHelper+Student">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="0" Name="programBatchId" Type="Int32" />
                    </SelectParameters>
                </asp:ObjectDataSource>--%>
                <br />
                <asp:Panel ID="pnlSave" runat="server" Visible="False">
                    <div>
                        <em>Note: Username and passwords for each students are set to CRN and full-name respectively.
                            <br/>
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            'Striked' and red colored names are already present in the system, so they won't be saved.
                        </em>
                    </div>
                    <br />
                    <%--class="save-div"--%>
                    <div>
                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_OnClick" />
                        &nbsp;&nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_OnClick" />
                        <asp:Label ID="lblSaveError" runat="server" Text="" Visible="False"></asp:Label>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <ajaxToolkit:AsyncFileUpload ID="file_upload" runat="server" Visible="True" />

    </div>

    <asp:HiddenField ID="hidFileSaveDirectory" runat="server" Value="" />
    <asp:HiddenField ID="hidProgramBatchId" runat="server" Value="0" />
    <asp:HiddenField ID="hidPageKey" runat="server" Value="" />

</asp:Content>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link href="../../../../Content/CSSes/TableStyles.css" rel="stylesheet" />
    <link href="../../../All_Resusable_Codes/Dialog/CustomDialogStyles.css" rel="stylesheet" />
</asp:Content>
