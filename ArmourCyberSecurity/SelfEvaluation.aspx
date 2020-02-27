<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelfEvaluation.aspx.cs" Inherits="ArmourCyberSecurity.SelfEvaluation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <style>
        #grow {
            -moz-transition: height .5s;
            -ms-transition: height .5s;
            -o-transition: height .5s;
            -webkit-transition: height .5s;
            transition: height .5s;
            height: 0;
            overflow: hidden;
        }
    </style>
    <script>
        function callFunction(chkbox) {
            alert(chkbox.value);
            if (chkbox.value == 'Canada') {

            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Self Evaluation

            <asp:Table ID="Table1" runat="server">
            </asp:Table>

        </div>
    </form>
</body>
</html>
