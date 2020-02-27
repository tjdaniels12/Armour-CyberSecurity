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
            //alert(chkbox.value);
            debugger
            var growDiv = document.getElementById('grow');
            if (growDiv.clientHeight && (chkbox.value == 'Europe' || chkbox.value == 'Canada' || chkbox.value == 'Brazil')) {
                growDiv.style.height = 0;
                //alert(chkbox.value + "inside grow");
            } else {
                var wrapper = document.querySelector('.measuringWrapper');
                growDiv.style.height = wrapper.clientHeight + "px";
                //alert(chkbox.value + "inside measure");
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

            <asp:Table ID="tbl_PrivacyCulture" runat="server">
            </asp:Table>

            <asp:Table ID="tbl_RegionalSpecific" runat="server">
            </asp:Table>

            <asp:Table ID="tbl_RegionalSpecific_reflex" runat="server">
            </asp:Table>


            <div id='grow' style="background-color: aqua;">
                <div class='measuringWrapper' style="background-color: aqua;">
                    <asp:Table ID="tbl_RegionalFines" runat="server">
                    </asp:Table>
                </div>
            </div>

            <asp:Table ID="tbl_PrivacyEngg" runat="server">
            </asp:Table>

            <asp:Table ID="tbl_DataControl" runat="server">
            </asp:Table>

            <asp:Table ID="tbl_Consent" runat="server">
            </asp:Table>

            <asp:Table ID="tbl_IncidentResp" runat="server">
            </asp:Table>

            <asp:Table ID="tbl_EmpTraining" runat="server">
            </asp:Table>

        </div>
    </form>
</body>
</html>
