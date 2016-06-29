<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="One.Course.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:FormView ID="subjectFV" 
            AllowPaging="true"
           DataKeyNames ="Id"
           
            runat="server" 
            OnModeChanging="subjectFV_ModeChanging"
            OnPageIndexChanging="subjectFV_PageIndexChanging" 
            OnItemDeleting="subjectFV_ItemDeleting" OnItemUpdating="subjectFV_ItemUpdating">
            
            <ItemTemplate>
                <table>
                    <tr>
                        <td> <%# Eval("Name") %></td>
                    </tr>
                    <tr>
                        <td>Level</td>
                        <td><%#Eval("LevelId") %></td>
                    </tr>
                    <tr>
                        <td>Program</td>
                        <td><%#Eval("ProgramId") %></td>
                    </tr>
                    <tr>
                        <td colspan="2">

                        <asp:LinkButton ID="EditButton"
                                        Text="Edit"
                                        CommandName="Edit"
                                        RunAt="server"/>
                          &nbsp;
                        <asp:LinkButton ID="NewButton"
                                        Text="New"
                                        CommandName="New"
                                        RunAt="server"/>
                          &nbsp;
                        <asp:LinkButton ID="DeleteButton"
                                        Text="Delete"
                                        CommandName="Delete"
                                        RunAt="server"/>
                      </td>
                    </tr>
                </table>    
            </ItemTemplate>
            
            <EditItemTemplate>
                <table>
                    <tr>
                        <td>Name</td>
                        <td>
                            <asp:TextBox runat="server" ID="txtName" Text="texthere"/>
                            <%--<asp:TextBox  runat="server" ID="txtName" Text="<%#Bind("Name") %>"/>--%>
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:FormView>
    </form>
</body>
</html>
