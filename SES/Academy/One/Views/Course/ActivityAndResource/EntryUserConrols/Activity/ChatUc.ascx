<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChatUc.ascx.cs" Inherits="One.Views.Course.ActivityAndResource.EntryUserConrols.Activity.ChatUc" %>

<div>
    <div class="form-title">
        <strong>New Chat</strong>
    </div>
    <div class="form-body">
        <strong>General</strong>
        <hr />
        <table class="form-content">
            <tr>
                <td>Name</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Description</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Display description </td>
                <td>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </td>
            </tr>

        </table>
        <br />
        <strong>Chat Session</strong>
        <hr />
        <table class="form-content">
            <tr>
                <td>Next Chat Time</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Save past sessions</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Everyone can view past sessions</td>
                <td>
                    <asp:DropDownList ID="DropDownList2" runat="server"></asp:DropDownList>
                </td>
            </tr>
        </table>
        <hr/>
        <br/>
        <div class="form-title">
            <asp:Button ID="Button1" runat="server" Text="Save" />
            <asp:Button ID="Button2" runat="server" Text="Cancel" />
        </div>
    </div>
</div>
