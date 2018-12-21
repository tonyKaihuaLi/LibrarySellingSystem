<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookTemplate.aspx.cs" Inherits="Web.Template.BookTemplate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../js/jquery-1.7.1.js"></script>
    <script type="text/javascript">
        $(function() {
            ("#btnAdd").click(function() {
                addComment();
            });
        });

        function addComment() {
            var msg = ("#txtContent").val();
            if (msg != "") {
                $.post("/ashx/BookComment.ashx", { "msg": msg, "bookId":$bookId }, function(data) {
                    if (data == "OK") {
                        $("txtContent").val("");
                        $("#txtContent").focus();

                    } else {
                        $("#txtMsg").text("wrong");
                    }
                });


            } else {
                $("#txtMsg").text("wrong");
                $("#txtContent").focus();
                
            }

        }

    </script>
</head>
<body>
    <table>
        <tr><td>Name</td><td>$title</td></tr>
        <tr><td>Author</td><td>$author</td></tr>
        <tr><td>Price</td><td>$unitprice</td></tr>
        <tr><td>Cover</td><td><img src="/Images/BookCovers/$isbn.jpg"/></td></tr>
        <tr><td>Introduction</td><td>$content</td></tr>
    </table>
<textarea id="txtContent" rows="20" cols="100"></textarea>
<input type="button" value="Send" id="btnAdd"/>

</body>
</html>
