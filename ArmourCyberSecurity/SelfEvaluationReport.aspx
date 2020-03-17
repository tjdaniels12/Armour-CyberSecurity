<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelfEvaluationReport.aspx.cs" Inherits="ArmourCyberSecurity.SelfEvaluationReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <style>
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=40);
            opacity: 0.7;
        }

        .modalPopup {
            background-color: #FFFFFF;
            width: 300px;
            border: 3px solid #0DA9D0;
        }

            .modalPopup .header {
                background-color: #2FBDF1;
                height: 30px;
                color: White;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

            .modalPopup .body {
                min-height: 50px;
                line-height: 30px;
                text-align: center;
                font-weight: bold;
            }

        #backdrop {
            width: initial;
            height: 400px;
            color: #FFFFFF;
            background-color: #1E4886;
            border-radius: 25px;
            padding: 20px;
            display: block;
            margin-left: auto;
            margin-right: auto;
        }

        .Logo {
            border-radius: 25px;
            display: block;
            margin-left: auto;
            margin-right: auto;
        }

        #reportTitle {
            text-align: center;
            display: block;
            margin-left: auto;
            margin-right: auto;
        }

        #scoreCircle {
            height: 105px;
            width: 105px;
            background-color: #ffbd17;
            border-radius: 50%;
            display: inline-block;
            color: #FFFFFF;
            font-size: 25px;
            font-weight: bold;
            text-align: center;
            padding: 5px;
            vertical-align: middle;
        }

        #scoreValue {
            margin-left: auto;
            margin-right: auto;
            position: relative;
            top: 50%;
            transform: translateY(-50%);
        }

        #scoreTable {
            display: block;
            margin-left: auto;
            margin-right: auto;
            align-content: center;
            table-layout: auto;
            width: 475px;
            padding-top: 10px;
            padding-bottom: 10px;
        }

        #reportdetail {
            display: block;
            margin-left: auto;
            margin-right: auto;
            align-content: center;
            padding-top: 10px;
            padding-bottom: 10px;
            text-align: center;
        }

        #exportButton {
            display: block;
            margin-left: auto;
            margin-right: auto;
            align-content: center;
            padding-top: 10px;
            padding-bottom: 10px;
            text-align: center;
        }

        .scoreAlignment {
            font-size: 22px;
            text-align: center;
            font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            font-weight: bold;
        }

        .boxshadow {
            display: block;
            margin-left: auto;
            margin-right: auto;
            align-content: center;
            margin-bottom: 20px;
            padding: 20px;
            width: 1100px;
            min-height: 300px;
            overflow-y: hidden;
            /*box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);*/
            box-shadow: 10px 10px 5px rgba(0, 0, 0, 0.50);
        }

        .divBullet {
            width: 5%;
            float: left;
            /*display: block;*/
            display: table-cell;
        }

        .divLabel {
            width: 95%;
            float: right;
            /*display: block;*/
            display: table-cell;
        }

        .statemenRow {
            /*display:flex;*/
            display: table;
        }

        @media print {
            .no-print, .no-print * {
                display: none !important;
                visibility: hidden;
            }
        }
    </style>
    <script>
        $(function () {
            $('#<%=txt_EmalId.ClientID%>').change(function () {

                var submit = document.getElementById('#<%=btnHide.ClientID%>');
                var btnSubmit = $('#<%=btnHide.ClientID%>');
                btnSubmit.attr("disabled", false);
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
            <cc1:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" runat="server"
                PopupControlID="pnlPopup" TargetControlID="lnkDummy" BackgroundCssClass="modalBackground" CancelControlID="lnkDummyCancel">
            </cc1:ModalPopupExtender>

            <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">
                <div class="header">
                    Modal Popup
                </div>
                <div class="body">
                    <asp:TextBox ID="txt_EmalId" runat="server" placeholder="Email Address" ClientIDMode="Static"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regEmailId" runat="server" ControlToValidate="txt_EmalId" ErrorMessage="Please enter valid email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">  </asp:RegularExpressionValidator>
                    <br />
                    <asp:LinkButton ID="lnkDummyCancel" runat="server"></asp:LinkButton>
                    <asp:Button ID="btnHide" runat="server" Text="Submit" ClientIDMode="Static" Enabled="false" OnClick="btnHide_Click"/>
                </div>
            </asp:Panel>


        </div>
        <div>
            <div class="boxshadow" style="background-color: #1E4886; height: 350px;">
                <table style="margin: 0 auto; text-align: center">
                    <tr>
                        <td style="text-align: center;">
                            <asp:Image CssClass="Logo" ID="Logo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: center; color: white;">
                            <h2>Global Data Privacy Regulation Compliance 
                                Self-Assessment - Report
                            </h2>
                        </td>
                    </tr>
                </table>


                <p style="text-align: center; color: white;">
                    Companies are legally required to fulfill the privacy regulations determined by the geographical location of both the company and their customers/clients. 
Compliance is a large task, but when done properly the first time, it becomes simple to maintain. Doing due diligence helps mitigate risk to customers, protects a company’s reputation, and drastically reduces fines.

                </p>

            </div>

            <%--Privacy Culture Questions--%>
            <div class="boxshadow">
                <table>
                    <tr style="background-color: #1E4886;">
                        <th colspan="2" style="text-align: center;">
                            <h3 style="color: white;">Privacy Culture Questions</h3>
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="text-align: center;">
                                        <asp:Image ID="img_networkAndInfoSec" runat="server" ImageAlign="Middle" Width="300" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="scoreAlignment" style="text-align: center;">
                                        <%--<asp:Label ID="lblnetworkAndInfoSec" runat="server" Text="" />--%>
                                    </td>
                                </tr>

                            </table>
                        </td>
                        <td style="width: 100%; text-align: justify;">
                            <div class="statemenRow">
                                <div class="divBullet">
                                    <asp:Label ID="bullet1" runat="server" Text="" />
                                </div>
                                <div class="divLabel">
                                    <asp:Label ID="comment1" runat="server" Text="" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>

            <%--Regional Specific Questions--%>
            <div class="boxshadow">
                <table>
                    <tr style="background-color: #1E4886;">
                        <th colspan="2" style="text-align: center;">
                            <h3 style="color: white;">Regional Specific Questions</h3>
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="text-align: center;">
                                        <asp:Image ID="Image1" runat="server" ImageAlign="Middle" Width="300" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="scoreAlignment" style="text-align: center;">
                                        <%--<asp:Label ID="lblnetworkAndInfoSec" runat="server" Text="" />--%>
                                    </td>
                                </tr>

                            </table>
                        </td>
                        <td style="width: 100%; text-align: justify;">
                            <div class="statemenRow">
                                <div class="divBullet">
                                    <asp:Label ID="bullet2" runat="server" Text="" />
                                </div>
                                <div class="divLabel">
                                    <asp:Label ID="comment2" runat="server" Text="" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>

            <%--Regional Fines--%>
            <div class="boxshadow">
                <table>
                    <tr style="background-color: #1E4886;">
                        <th colspan="2" style="text-align: center;">
                            <h3 style="color: white;">Regional Fines</h3>
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="text-align: center;">
                                        <asp:Image ID="Image2" runat="server" ImageAlign="Middle" Width="300" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="scoreAlignment" style="text-align: center;">
                                        <%--<asp:Label ID="lblnetworkAndInfoSec" runat="server" Text="" />--%>
                                    </td>
                                </tr>

                            </table>
                        </td>
                        <td style="width: 100%; text-align: justify;">
                            <div class="statemenRow">
                                <div class="divBullet">
                                    <asp:Label ID="bullet3" runat="server" Text="" />
                                </div>
                                <div class="divLabel">
                                    <asp:Label ID="comment3" runat="server" Text="" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>

            <%--Privacy Engineering--%>
            <div class="boxshadow">
                <table>
                    <tr style="background-color: #1E4886;">
                        <th colspan="2" style="text-align: center;">
                            <h3 style="color: white;">Privacy Engineering</h3>
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="text-align: center;">
                                        <asp:Image ID="Image3" runat="server" ImageAlign="Middle" Width="300" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="scoreAlignment" style="text-align: center;">
                                        <%--<asp:Label ID="lblnetworkAndInfoSec" runat="server" Text="" />--%>
                                    </td>
                                </tr>

                            </table>
                        </td>
                        <td style="width: 100%; text-align: justify;">
                            <div class="statemenRow">
                                <div class="divBullet">
                                    <asp:Label ID="bullet4" runat="server" Text="" />
                                </div>
                                <div class="divLabel">
                                    <asp:Label ID="comment4" runat="server" Text="" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>

            <%--Data Control--%>
            <div class="boxshadow">
                <table>
                    <tr style="background-color: #1E4886;">
                        <th colspan="2" style="text-align: center;">
                            <h3 style="color: white;">Data Control</h3>
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="text-align: center;">
                                        <asp:Image ID="Image4" runat="server" ImageAlign="Middle" Width="300" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="scoreAlignment" style="text-align: center;">
                                        <%--<asp:Label ID="lblnetworkAndInfoSec" runat="server" Text="" />--%>
                                    </td>
                                </tr>

                            </table>
                        </td>
                        <td style="width: 100%; text-align: justify;">
                            <div class="statemenRow">
                                <div class="divBullet">
                                    <asp:Label ID="bullet5" runat="server" Text="" />
                                </div>
                                <div class="divLabel">
                                    <asp:Label ID="comment5" runat="server" Text="" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>

            <%--Consent--%>
            <div class="boxshadow">
                <table>
                    <tr style="background-color: #1E4886;">
                        <th colspan="2" style="text-align: center;">
                            <h3 style="color: white;">Consent</h3>
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="text-align: center;">
                                        <asp:Image ID="Image5" runat="server" ImageAlign="Middle" Width="300" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="scoreAlignment" style="text-align: center;">
                                        <%--<asp:Label ID="lblnetworkAndInfoSec" runat="server" Text="" />--%>
                                    </td>
                                </tr>

                            </table>
                        </td>
                        <td style="width: 100%; text-align: justify;">
                            <div class="statemenRow">
                                <div class="divBullet">
                                    <asp:Label ID="bullet6" runat="server" Text="" />
                                </div>
                                <div class="divLabel">
                                    <asp:Label ID="comment6" runat="server" Text="" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>

            <%--Incident Response--%>
            <div class="boxshadow">
                <table>
                    <tr style="background-color: #1E4886;">
                        <th colspan="2" style="text-align: center;">
                            <h3 style="color: white;">Privacy Culture Questions</h3>
                        </th>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="text-align: center;">
                                        <asp:Image ID="Image6" runat="server" ImageAlign="Middle" Width="300" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="scoreAlignment" style="text-align: center;">
                                        <%--<asp:Label ID="lblnetworkAndInfoSec" runat="server" Text="" />--%>
                                    </td>
                                </tr>

                            </table>
                        </td>
                        <td style="width: 100%; text-align: justify;">
                            <div class="statemenRow">
                                <div class="divBullet">
                                    <asp:Label ID="bullet7" runat="server" Text="" />
                                </div>
                                <div class="divLabel">
                                    <asp:Label ID="comment7" runat="server" Text="" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
