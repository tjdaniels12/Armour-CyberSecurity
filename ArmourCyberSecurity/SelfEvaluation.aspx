<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelfEvaluation.aspx.cs" Inherits="ArmourCyberSecurity.SelfEvaluation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>

    <script>
        $(document).ready(function () {
            $("#sec2Div").hide();
            $("#sec3Div").hide();
            $("#sec4Div").hide();

        });

        $(document).on('click', '[id*=btn_section1]', function () {
            var v1 = document.getElementById("<%=reqAns1.ClientID%>");
            var v2 = document.getElementById("<%=reqAns2.ClientID%>");
            var v3 = document.getElementById("<%=reqAns3.ClientID%>");
            var v4 = document.getElementById("<%=reqAns4.ClientID%>");
            var v5 = document.getElementById("<%=reqAns5.ClientID%>");
            var v6 = document.getElementById("<%=cvDemoList.ClientID%>");

            ValidatorValidate(v1);
            ValidatorValidate(v2);
            ValidatorValidate(v3);
            ValidatorValidate(v4);
            ValidatorValidate(v5);
            ValidatorValidate(v6);
            if (v1.isvalid && v2.isvalid && v3.isvalid && v4.isvalid && v5.isvalid && v6.isvalid) {
                $("#sec1Div").slideUp(1000);
                $("#sec2Div").slideDown(1000);
            }
            else {
                alert("Fill in all the questions before moving ahead");
            }
        });

        $(document).on('click', '[id*=btn_section2]', function () {
            $("#sec2Div").slideUp(1000);
            $("#sec3Div").slideDown(1000);
        });

        $(document).on('click', '[id*=btn_section3]', function () {
            var v16 = document.getElementById("<%=reqAns16.ClientID%>");
            var v17 = document.getElementById("<%=reqAns17.ClientID%>");
            var v18 = document.getElementById("<%=reqAns18.ClientID%>");
            var v19 = document.getElementById("<%=reqAns19.ClientID%>");
            var v20 = document.getElementById("<%=reqAns20.ClientID%>");
            var v21 = document.getElementById("<%=reqAns21.ClientID%>");
            var v22 = document.getElementById("<%=reqAns22.ClientID%>");
            ValidatorValidate(v16);
            ValidatorValidate(v17);
            ValidatorValidate(v18);
            ValidatorValidate(v19);
            ValidatorValidate(v20);
            ValidatorValidate(v21);
            ValidatorValidate(v22);
            if (v16.isvalid && v17.isvalid && v18.isvalid && v19.isvalid && v20.isvalid && v21.isvalid && v22.isvalid) {
                $("#sec3Div").slideUp(1000);
                $("#sec4Div").slideDown(1000);
            }
            else {
                alert("Fill in all the questions before moving ahead");
            }
        });


        function ValidateDemoList(source, args) {
            var chkListModules = document.getElementById('<%= chkbxAns6.ClientID %>');
            var chkListinputs = chkListModules.getElementsByTagName("input");
            for (var i = 0; i < chkListinputs.length; i++) {
                if (chkListinputs[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }

        function ValidateDemoList2(source, args) {
            var chkListModules = document.getElementById('<%= chkbxAns7.ClientID %>');
            var chkListinputs = chkListModules.getElementsByTagName("input");
            for (var i = 0; i < chkListinputs.length; i++) {
                if (chkListinputs[i].checked) {
                    args.IsValid = true;
                    return;
                }
            }
            args.IsValid = false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div id='sec1Div'>
                <h2>PrivacyCulture</h2>
                <div id="PrivacyCulture">
                    <asp:Label ID="lblQues1" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns1">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns1" ControlToValidate="ddlAns1" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />

                    <asp:Label ID="lblQues2" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns2">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns2" ControlToValidate="ddlAns2" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />

                    <asp:Label ID="lblQues3" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns3">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns3" ControlToValidate="ddlAns3" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />

                    <asp:Label ID="lblQues4" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns4">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns4" ControlToValidate="ddlAns4" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />

                    <asp:Label ID="lblQues5" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns5">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns5" ControlToValidate="ddlAns5" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />
                </div>

                <h2>RegionalSpecific</h2>
                <div id="RegionalSpecific">
                    <asp:Label ID="lblQues6" runat="server" Text="" />
                    <asp:CheckBoxList ID="chkbxAns6" runat="server" ClientIDMode="Static" AutoPostBack="True" OnSelectedIndexChanged="chkbxAns6_SelectedIndexChanged1">
                    </asp:CheckBoxList>
                    <asp:CustomValidator runat="server" ID="cvDemoList" ClientValidationFunction="ValidateDemoList" ErrorMessage="* Required" ForeColor="Red"></asp:CustomValidator>
                    <br />

                    <asp:Label ID="lblQues7" runat="server" Text="" />
                    <asp:CheckBoxList ID="chkbxAns7" runat="server" ClientIDMode="Static" AutoPostBack="True" OnSelectedIndexChanged="chkbxAns7_SelectedIndexChanged">
                    </asp:CheckBoxList>
                    <asp:CustomValidator runat="server" ID="cvDemoList2" ClientValidationFunction="ValidateDemoList2" ErrorMessage="* Required" ForeColor="Red"></asp:CustomValidator>
                    <br />
                </div>

                <asp:Button ID="btn_section1" runat="server" Text="Next" ClientIDMode="Static" OnClientClick="return false; Validate();" />
            </div>



            <div id='sec2Div'>
                <h2>RegionalSpecificReflexive</h2>
                <div id="RegionalSpecificReflexive">

                    <div id="Ques8Div" runat="server">
                        <asp:Label ID="lblQues8" runat="server" Text="" Visible="false" />
                        <asp:DropDownList runat="server" ID="ddlAns8" Visible="false">
                            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="reqAns8" ControlToValidate="ddlAns8" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                        <br />
                    </div>

                    <div id="Ques9Div" runat="server">
                        <asp:Label ID="lblQues9" runat="server" Text="" Visible="false" />
                        <asp:DropDownList runat="server" ID="ddlAns9" Visible="false">
                            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="reqAns9" ControlToValidate="ddlAns9" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                        <br />
                    </div>

                    <div id="Ques10Div" runat="server">
                        <asp:Label ID="lblQues10" runat="server" Text="" Visible="false" />
                        <asp:DropDownList runat="server" ID="ddlAns10" Visible="false">
                            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="reqAns10" ControlToValidate="ddlAns10" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                        <br />
                    </div>

                    <div id="Ques11Div" runat="server">
                        <asp:Label ID="lblQues11" runat="server" Text="" Visible="false" />
                        <asp:DropDownList runat="server" ID="ddlAns11" Visible="false">
                            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="reqAns11" ControlToValidate="ddlAns11" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                        <br />
                    </div>

                </div>


                <h2>RegionalFines</h2>
                <div id="RegionalFines">

                    <div id="Ques12Div" runat="server">
                        <asp:Label ID="lblQues12" runat="server" Text="" Visible="false" />
                        <asp:DropDownList runat="server" ID="ddlAns12" Visible="false">
                            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="reqAns12" ControlToValidate="ddlAns12" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                        <br />
                    </div>

                    <div id="Ques13Div" runat="server">
                        <asp:Label ID="lblQues13" runat="server" Text="" Visible="false" />
                        <asp:DropDownList runat="server" ID="ddlAns13" Visible="false">
                            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="reqAns13" ControlToValidate="ddlAns13" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                        <br />
                    </div>

                    <div id="Ques14Div" runat="server">
                        <asp:Label ID="lblQues14" runat="server" Text="" Visible="false" />
                        <asp:DropDownList runat="server" ID="ddlAns14" Visible="false">
                            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="reqAns14" ControlToValidate="ddlAns14" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                        <br />
                    </div>

                    <div id="Ques15Div" runat="server">
                        <asp:Label ID="lblQues15" runat="server" Text="" Visible="false" />
                        <asp:DropDownList runat="server" ID="ddlAns15" Visible="false">
                            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="reqAns15" ControlToValidate="ddlAns15" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                        <br />
                    </div>
                </div>

                <asp:Button ID="btn_section2" runat="server" Text="Next" ClientIDMode="Static" OnClientClick="return false;" />
            </div>



            <div id='sec3Div'>
                <h2>PrivacyEngg</h2>
                <div id="PrivacyEngg">
                    <asp:Label ID="lblQues16" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns16">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns16" ControlToValidate="ddlAns16" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />

                    <asp:Label ID="lblQues17" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns17">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns17" ControlToValidate="ddlAns17" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />

                    <asp:Label ID="lblQues18" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns18">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns18" ControlToValidate="ddlAns18" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />

                    <asp:Label ID="lblQues19" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns19">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns19" ControlToValidate="ddlAns19" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />

                    <asp:Label ID="lblQues20" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns20">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns20" ControlToValidate="ddlAns20" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />

                    <asp:Label ID="lblQues21" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns21">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns21" ControlToValidate="ddlAns21" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />
                </div>

                <h2>DataControl</h2>
                <div id="DataControl">
                    <asp:Label ID="lblQues22" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns22">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns22" ControlToValidate="ddlAns22" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />

                    <div runat="server" id="Ques23Div">
                        <asp:Label ID="lblQues23" runat="server" Text="" Visible="false" />
                        <asp:DropDownList runat="server" ID="ddlAns23" Visible="false">
                            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="reqAns23" ControlToValidate="ddlAns23" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                        <br />
                    </div>
                </div>

                <asp:Button ID="btn_section3" runat="server" Text="Next" ClientIDMode="Static" OnClientClick="return false;" />
            </div>



            <div id='sec4Div'>
                <h2>Consent</h2>
                <div id="Consent">
                    <asp:Label ID="lblQues24" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns24">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns24" ControlToValidate="ddlAns24" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />

                    <asp:Label ID="lblQues25" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns25">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns25" ControlToValidate="ddlAns25" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />
                </div>

                <h2>IncidentResp</h2>
                <div id="IncidentResp">
                    <asp:Label ID="lblQues26" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns26">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns26" ControlToValidate="ddlAns26" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />

                    <asp:Label ID="lblQues27" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns27">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns27" ControlToValidate="ddlAns27" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />

                    <asp:Label ID="lblQues28" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns28">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns28" ControlToValidate="ddlAns28" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />

                    <asp:Label ID="lblQues29" runat="server" Text="" />
                    <asp:DropDownList runat="server" ID="ddlAns29">
                        <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ID="reqAns29" ControlToValidate="ddlAns29" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                    <br />
                </div>


                <asp:Button ID="btn_Submit" runat="server" Text="Button" OnClick="btn_Submit_Click" />
            </div>


        </div>
    </form>
</body>
</html>
