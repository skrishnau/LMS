<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ckTestInAspx.aspx.cs" Inherits="One.ckEditor_Test.ckTestInAspx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <%--<meta charset="utf-8">--%>
    <title>A simple page with ckeditor</title>
    <script src="../ckeditor/ckeditor.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <textarea id="editor1" name="editor1" rows="10" cols="80">
                This is my text area to be replaced with texteditor
            </textarea>
            <script type="text/javascript">
                CKEDITOR.replace('editor1', {
                    filebrowserBrowseUrl: '/filetasks/Browse.aspx',
                    filebrowserUploadUrl: '/filetasks/Upload.aspx'
                });
            </script>
        </div>
    </form>
</body>
</html>
