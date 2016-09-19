<%@ Page Language="C#" MasterPageFile="~/ViewsSite/User/UserMaster.Master" AutoEventWireup="true" CodeBehind="GradeCreate.aspx.cs" Inherits="One.Views.Grade.GradeCreate" %>


<asp:Content runat="server" ID="contentBodyid" ContentPlaceHolderID="Body">
    <h3 class="heading-of-create-edit">
        <asp:Label ID="lblHeading" runat="server" Text="New Grade Type"></asp:Label>
    </h3>
    <hr />
    <br />
    <div class="data-entry-body">

        <div class="data-entry-section">
            <div class="data-entry-heading">General</div>
            <hr />
            <div class="data-entry-section-body">

                <table>
                    <tr>
                        <td class="data-type">Name</td>
                        <td class="data-entry">
                            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ForeColor="red" ControlToValidate="txtName" ValidationGroup="gradevaligroup"
                                ErrorMessage="Required"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="data-type">Description</td>
                        <td class="data-entry">
                            <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" Height="77px" Width="237px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="data-type">Type
                        </td>
                        <td class="data-entry" style="overflow: hidden; display: inline-block;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:RadioButtonList ID="rdbtnlistType" AutoPostBack="True"
                                        runat="server"
                                        OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                        RepeatColumns="2" Width="150px">
                                        <Items>
                                            <asp:ListItem Value="0" Text="Range" Selected="True"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Values"></asp:ListItem>
                                        </Items>
                                    </asp:RadioButtonList>

                                    <%-- <asp:RadioButton ID="RadioButton1" runat="server" Text="Range" />
                            &nbsp;&nbsp;&nbsp;
                <asp:RadioButton ID="RadioButton2" runat="server" Text="Values" />--%>

                                    <div runat="server" id="divRange" style="margin-left: 30px; padding: 0 10px; border: 1px solid lightgray;">
                                        <table class="table-entry">
                                            <tr class="row-entry">
                                                <td class="data-type">Maximum value
                                                </td>
                                                <td class="data-entry">
                                                    <asp:TextBox ID="txtMaxValue" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr class="row-entry">
                                                <td class="data-type">Minimum value</td>
                                                <td class="data-entry">
                                                    <asp:TextBox ID="txtMinValue" runat="server"></asp:TextBox>

                                                </td>
                                            </tr>
                                            <tr class="row-entry">
                                                <td class="data-type">Minimum value to pass</td>
                                                <td class="data-entry">
                                                    <asp:TextBox ID="txtMinValueToPass" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>

                                        </table>
                                    </div>

                                    <div runat="server" id="divValues" style="padding: 0 5px; margin-left: 25px; border: 1px solid lightgray; overflow: auto;">
                                         <em style="background-color: yellow;">--//-- This part doesn't work as expected. It needs some work.</em>
                                                <br/>
                                         <div>
                                            <div style="float: left">
                                              
                                                Equivalent representation in 
                                            
                                            </div>
                                            <div style="float: left;">
                                                <asp:RadioButtonList ID="rdbtnlistEquivalentRepresentation" runat="server"
                                                    Width="192px" RepeatColumns="2"
                                                    ToolTip="In Percentage: Values are between 0 and 100. In Position: '1' is highest ranked, '2' is ranked lower than '1', and so on." OnSelectedIndexChanged="rdbtnlistEquivalentRepresentation_SelectedIndexChanged" AutoPostBack="True">
                                                    <asp:ListItem Value="0" Text="Percentage" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Position"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                            <div style="clear: both;"></div>
                                        </div>

                                        <div style="margin-left: 20px;">
                                            <asp:Panel ID="pnlGradeValues" runat="server"></asp:Panel>
                                            <asp:LinkButton ID="btnAddValue" runat="server"
                                                CausesValidation="False" OnClick="btnAddValue_Click">Add Value</asp:LinkButton>

                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>

            </div>
        </div>

        <div class="save-div">
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="75px" ValidationGroup="gradevaligroup" OnClick="btnSave_OnClick" />
        </div>
    </div>
    <asp:HiddenField ID="hidPageKey" runat="server" Value="0" />
    <asp:HiddenField ID="hidId" runat="server" Value="0" />
</asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
</asp:Content>


