<%--<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelfEvaluation.aspx.cs" Inherits="ArmourCyberSecurity.SelfEvaluation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
    <style>
        #grow7 {
            -moz-transition: height .5s;
            -ms-transition: height .5s;
            -o-transition: height .5s;
            -webkit-transition: height .5s;
            transition: height .5s;
            height: 0;
            overflow: hidden;
        }

        #grow8 {
            -moz-transition: height .5s;
            -ms-transition: height .5s;
            -o-transition: height .5s;
            -webkit-transition: height .5s;
            transition: height .5s;
            height: 0;
            overflow: hidden;
        }

        #grow9 {
            -moz-transition: height .5s;
            -ms-transition: height .5s;
            -o-transition: height .5s;
            -webkit-transition: height .5s;
            transition: height .5s;
            height: 0;
            overflow: hidden;
        }

        #grow10 {
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
        $(function () {
            var checkboxes = $("[id*=chkbxAns5] input[type=checkbox]");
            checkboxes.change(function () {
                checkboxes.each(function () {
                    var growDiv7 = document.getElementById('grow7');
                    var growDiv8 = document.getElementById('grow8');
                    var growDiv9 = document.getElementById('grow9');
                    var growDiv10 = document.getElementById('grow10');
                    if ($(this).is(":checked")) {
                        var label = $(this).closest("td").find("label").html();
                        //alert(label);
                        if (label == 'Canada') {
                            if (!growDiv7.clientHeight) {
                                //alert("canada shrink");
                                var wrapper = document.querySelector('#measuringWrapper7');
                                growDiv7.style.height = wrapper.clientHeight + "px";
                            }
                        }
                        else
                            if (label == 'Europe') {
                                if (!growDiv8.clientHeight) {
                                    //alert("europe shrink");
                                    var wrapper = document.querySelector('#measuringWrapper8');
                                    growDiv8.style.height = wrapper.clientHeight + "px";
                                }
                            }
                            else
                                if (label == 'California') {
                                    if (!growDiv9.clientHeight) {
                                        //alert("California shrink");
                                        var wrapper = document.querySelector('#measuringWrapper9');
                                        growDiv9.style.height = wrapper.clientHeight + "px";
                                    }
                                }
                                else
                                    if (label == 'Brazil') {
                                        if (!growDiv10.clientHeight) {
                                            //alert("Brazil shrink");
                                            var wrapper = document.querySelector('#measuringWrapper10');
                                            growDiv10.style.height = wrapper.clientHeight + "px";
                                        }
                                    }
                    }
                    else if (!$(this).is(":checked")) {
                        var label = $(this).closest("td").find("label").html();
                        //alert(label);
                        if (label == 'Canada') {
                            if (growDiv7.clientHeight) {
                                //alert("canada uncheck shrink");
                                growDiv7.style.height = 0;
                            }
                        }
                        else
                            if (label == 'Europe') {
                                if (growDiv8.clientHeight) {
                                    //alert("europe uncheck shrink");
                                    growDiv8.style.height = 0;
                                }
                            }
                            else
                                if (label == 'California') {
                                    if (growDiv9.clientHeight) {
                                        //alert("California uncheck shrink");
                                        growDiv9.style.height = 0;
                                    }
                                }
                                else
                                    if (label == 'Brazil') {
                                        if (growDiv10.clientHeight) {
                                            //alert("Brazil uncheck shrink");
                                            growDiv10.style.height = 0;
                                        }
                                    }
                    }
                });
            });
        });
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <%--            <asp:Table ID="tbl_PrivacyCulture" runat="server">
            </asp:Table>

            <asp:Table ID="tbl_RegionalSpecific" runat="server">
            </asp:Table>

            <asp:Table ID="tbl_RegionalSpecific_reflex" runat="server" ClientIDMode="Static">
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

            <div id="PrivacyCulture">
                <asp:Label ID="lblQues1" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns1">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="lblQues2" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns2">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="lblQues3" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns3">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="lblQues4" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns4">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />
            </div>

            <div id="RegionalSpecific">
                <asp:Label ID="lblQues5" runat="server" Text="" ClientIDMode="Static" />
                <asp:CheckBoxList ID="chkbxAns5" runat="server">
                </asp:CheckBoxList><br />

                <asp:Label ID="lblQues6" runat="server" Text="" ClientIDMode="Static" />
                <asp:CheckBoxList ID="chkbxAns6" runat="server">
                </asp:CheckBoxList><br />

                <div id='grow7'>
                    <div id='measuringWrapper7'>
                        <asp:Label ID="lblQues7" runat="server" Text="" />
                        <asp:DropDownList runat="server" ID="ddlAns7">
                            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList><br />
                    </div>
                </div>

                <div id='grow8'>
                    <div id='measuringWrapper8'>
                        <asp:Label ID="lblQues8" runat="server" Text="" />
                        <asp:DropDownList runat="server" ID="ddlAns8">
                            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList><br />
                    </div>
                </div>

                <div id='grow9'>
                    <div id='measuringWrapper9'>
                        <asp:Label ID="lblQues9" runat="server" Text="" />
                        <asp:DropDownList runat="server" ID="ddlAns9">
                            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList><br />
                    </div>
                </div>

                <div id='grow10'>
                    <div id='measuringWrapper10'>
                        <asp:Label ID="lblQues10" runat="server" Text="" />
                        <asp:DropDownList runat="server" ID="ddlAns10">
                            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList><br />
                    </div>
                </div>
            </div>

            <div id="RegionalFines">
                <asp:Label ID="lblQues11" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns11">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="lblQues12" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns12">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="lblQues13" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns13">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />
            </div>

            <div id="PrivacyEngg">
                <asp:Label ID="lblQues14" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns14">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="lblQues15" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns15">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="lblQues16" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns16">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="lblQues17" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns17">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="lblQues18" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns18">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />
            </div>

            <div id="DataControl">
                <asp:Label ID="lblQues19" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns19">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="lblQues20" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns20">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />
            </div>

            <div id="Consent">
                <asp:Label ID="lblQues21" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns21">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="lblQues22" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns22">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />
            </div>

            <div id="IncidentResp">
                <asp:Label ID="lblQues23" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns23">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="lblQues24" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns24">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="lblQues25" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns25">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />

                <asp:Label ID="lblQues26" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns26">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />
            </div>

            <div id="EmpTraining">
                <asp:Label ID="lblQues27" runat="server" Text="" />
                <asp:DropDownList runat="server" ID="ddlAns27">
                    <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                </asp:DropDownList><br />
            </div>

            <asp:Button ID="btn_Submit" runat="server" Text="Button" OnClick="btn_Submit_Click" />
        </div>
    </form>
</body>
</html>--%>
