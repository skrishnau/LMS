<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="treeviewWF.aspx.cs" Inherits="TreeViewTest.TreeViewTest.treeviewWF" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="scriptManager1" ></asp:ScriptManager>
        <div>
            <asp:UpdatePanel runat="server" ID="updatepanel1">
                <ContentTemplate>
                        <asp:TreeView ID="TreeView1" runat="server" ShowCheckBoxes="All" OnTreeNodeCheckChanged="TreeView1_TreeNodeCheckChanged" OnTreeNodeCollapsed="TreeView1_TreeNodeCollapsed" ShowLines="True">
                <Nodes>

                    <asp:TreeNode Text="one">
                        <ChildNodes>
                            <asp:TreeNode Text="1">
                                <ChildNodes>
                                    <asp:TreeNode Text="English"></asp:TreeNode>
                                    <asp:TreeNode Text="International"></asp:TreeNode>
                                </ChildNodes>
                            </asp:TreeNode>
                            <asp:TreeNode Text="I"></asp:TreeNode>
                            <asp:TreeNode Text="ek"></asp:TreeNode>
                        </ChildNodes>
                    </asp:TreeNode>
                    <asp:TreeNode Text="two">
                        <ChildNodes>
                            <asp:TreeNode Text="2"></asp:TreeNode>
                            <asp:TreeNode Text="II">
                                <ChildNodes>
                                    <asp:TreeNode Text="Roman"></asp:TreeNode>
                                    <asp:TreeNode Text="International"></asp:TreeNode>
                                </ChildNodes>
                            </asp:TreeNode>
                            <asp:TreeNode Text="dui"></asp:TreeNode>
                        </ChildNodes>
                    </asp:TreeNode>
                    <asp:TreeNode Text="three"></asp:TreeNode>
                    <asp:TreeNode Text="four"></asp:TreeNode>
                    <asp:TreeNode Text="five"></asp:TreeNode>
                    <asp:TreeNode Text="six">
                        <ChildNodes>
                            <asp:TreeNode Text="6"></asp:TreeNode>
                            <asp:TreeNode Text="VI"></asp:TreeNode>
                            <asp:TreeNode Text="xa">
                                <ChildNodes>
                                    <asp:TreeNode Text="Nepali"></asp:TreeNode>
                                    <asp:TreeNode Text="National">
                                        <ChildNodes>
                                            <asp:TreeNode Text="Local"></asp:TreeNode>
                                        </ChildNodes>
                                    </asp:TreeNode>
                                </ChildNodes>
                            </asp:TreeNode>
                        </ChildNodes>
                    </asp:TreeNode>

                    <asp:TreeNode Text="seven"></asp:TreeNode>
                    <asp:TreeNode Text="eight">
                        <ChildNodes>
                            <asp:TreeNode Text="8"></asp:TreeNode>
                            <asp:TreeNode Text="VIII"></asp:TreeNode>
                            <asp:TreeNode Text="aath">
                                <ChildNodes>
                                    <asp:TreeNode Text="Nepali"></asp:TreeNode>
                                    <asp:TreeNode Text="Local"></asp:TreeNode>
                                </ChildNodes>
                            </asp:TreeNode>
                        </ChildNodes>
                    </asp:TreeNode>
                    <asp:TreeNode Text="nine"></asp:TreeNode>

                </Nodes>
            </asp:TreeView>
       
                </ContentTemplate>
            </asp:UpdatePanel>
         </div>
    </form>
</body>
</html>
