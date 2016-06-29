<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="One.Course.List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Level: "></asp:Label>
        <asp:DropDownList ID="cmbLevel" runat="server" AutoPostBack="True" DataMember="Id" DataValueField="Name" OnSelectedIndexChanged="cmbLevel_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:GridView ID="grdView" runat="server">
            <Columns>
                <asp:BoundField DataField="Id" />
                <asp:BoundField DataField="Name" />
            </Columns>
            
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
