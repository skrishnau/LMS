<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupRestrictionUC.ascx.cs" Inherits="One.Views.RestrictionAccess.GroupRestrictionUC" %>




<div class="restriction-uc-whole">
    <%--<asp:ImageButton ID="ImageButton1" ImageUrl="~/Content/Icons/Visibility/eye_16x20_visible.png" runat="server" />--%>
    <%--&nbsp;--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <span>Students in Class 
            <%-- <asp:DropDownList ID="ddlClassGroup" runat="server" Height="20px" Width="100px">
                <Items>
                    <asp:ListItem Value="0" Text="Class"></asp:ListItem>
                   <asp:ListItem Value="1" Text="Group"></asp:ListItem>
                </Items>
            </asp:DropDownList>--%>
                &nbsp;
                 <asp:DropDownList ID="ddlClass" runat="server" Height="20px" Width="140px"
                     DataValueField="Id" DataTextField="Name" DataSourceID="ObjectDataSource1" AutoPostBack="True"
                     OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                 </asp:DropDownList>

                <asp:PlaceHolder ID="pnlGroup" runat="server" Visible="False">&nbsp;
                    and group
                        &nbsp;
                        <asp:DropDownList ID="ddlGroupValue" runat="server" Height="20px" Width="120px">
                        </asp:DropDownList>
                </asp:PlaceHolder>
            </span>
            &nbsp;
            <span class="img-close">
                <asp:ImageButton ID="imgClose" CssClass="link-img-close"  CausesValidation="False"
                    ImageUrl="~/Content/Icons/Close/cross_8x20_center.png" runat="server" OnClick="imgClose_Click" />
            </span>
            &nbsp;
            <asp:Label ID="lblError" runat="server" Text="Your selection is invalid" Visible="False" ForeColor="red"></asp:Label>

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hidParentId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRelativeId" runat="server" Value="1" />
    <asp:HiddenField ID="hidAbsoluteId" runat="server" Value="1" />
    <asp:HiddenField ID="hidType" runat="server" Value="" />


    <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
    <asp:HiddenField ID="hidSubjectId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRoles" runat="server" Value="" />

    <asp:HiddenField ID="hidGroupRestrictionId" runat="server" Value="0" />
    <asp:HiddenField ID="hidRestrictionId" runat="server" Value="0" />

    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="ListCurrentClassesOfTeacherForCombo" TypeName="Academic.DbHelper.DbHelper+Classes">
        <SelectParameters>
            <asp:ControlParameter ControlID="hidSubjectId" DefaultValue="0" Name="subjectId" PropertyName="Value" Type="Int32" />
            <asp:ControlParameter ControlID="hidUserId" DefaultValue="0" Name="userId" PropertyName="Value" Type="Int32" />
            <asp:ControlParameter ControlID="hidRoles" DefaultValue=" " Name="role" PropertyName="Value" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</div>
