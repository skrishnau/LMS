<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsUc.ascx.cs" Inherits="One.ViewsSite.User.ModulesUc.NewsUc" %>

<div class="module-whole">
    <div class="modules-heading">
        <asp:HyperLink ID="HyperLink1" runat="server" CssClass="modules-title">News</asp:HyperLink>
        <asp:HiddenField ID="hidUserId" runat="server" Value="0" />
    </div>
    <div class="modules-body" onload="startTimer()">

        <asp:FormView ID="FormView1" runat="server"
            AllowPaging="True"
            >
            
            <ItemTemplate>
                  <table>
                    <tr>
                      <td align="right"><b>Product ID:</b></td>
                      <td><asp:Label id="ProductIDLabel" runat="server" Text='<%# Eval("ProductID") %>' /></td>
                    </tr>
                    <tr>
                      <td align="right"><b>Product Name:</b></td>
                      <td><asp:Label id="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>' /></td>
                    </tr>
                    <tr>
                      <td align="right"><b>Category ID:</b></td>
                      <td><asp:Label id="CategoryIDLabel" runat="server" Text='<%# Eval("CategoryID") %>' /></td>
                    </tr>
                    <tr>
                      <td align="right"><b>Quantity Per Unit:</b></td>
                      <td><asp:Label id="QuantityPerUnitLabel" runat="server" Text='<%# Eval("QuantityPerUnit") %>' /></td>
                    </tr>
                    <tr>
                      <td align="right"><b>Unit Price:</b></td>
                      <td><asp:Label id="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice") %>' /></td>
                    </tr>
                  </table>                 
                </ItemTemplate>

            <PagerTemplate>
                  <table>
                    <tr>
                      <td><asp:LinkButton ID="FirstButton" CommandName="Page" CommandArgument="First" Text="<<" RunAt="server"/></td>
                      <td><asp:LinkButton ID="PrevButton"  CommandName="Page" CommandArgument="Prev"  Text="<"  RunAt="server"/></td>
                      <td><asp:LinkButton ID="NextButton"  CommandName="Page" CommandArgument="Next"  Text=">"  RunAt="server"/></td>
                      <td><asp:LinkButton ID="LastButton"  CommandName="Page" CommandArgument="Last"  Text=">>" RunAt="server"/></td>
                    </tr>
                  </table>
                </PagerTemplate>

        </asp:FormView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>

    </div>
    <%--<script type="text/javascript">
        function displayNextImage() {
            x = (x === images.length - 1) ? 0 : x + 1;
            document.getElementById("img1").src = images[x];
        }

        function displayPreviousImage() {
            x = (x <= 0) ? images.length - 1 : x - 1;
            document.getElementById("img1").src = images[x];
        }

        function startTimer() {
            setInterval(displayNextImage, 3000);
        }

        var images = [], x = -1;
        images[0] = "/Content/Images/NewsImage/image1.png";
        images[1] = "/Content/Images/NewsImage/image2.png";
        images[2] = "/Content/Images/NewsImage/image3.png";
    </script>--%>
</div>

