<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomRoadMap.aspx.cs" Inherits="ArmourCyberSecurity.CustomRoadMap" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Height="165px" Width="350px">

                <asp:TabPanel runat="server" HeaderText="PrivacyCulture" ID="TabPanel1">
                    <ContentTemplate>
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
                    </ContentTemplate>
                </asp:TabPanel>

                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="RegionalSpecific">
                    <ContentTemplate>
                         <div id="RegionalSpecific">
                        <asp:Label ID="lblQues8" runat="server" Text="" />
                        <asp:DropDownList runat="server" ID="ddlAns8" >
                            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="reqAns8" ControlToValidate="ddlAns8" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                        <br />
                        </div>

                    
                        <asp:Label ID="lblQues9" runat="server" Text="" />
                        <asp:DropDownList runat="server" ID="ddlAns9" >
                            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="reqAns9" ControlToValidate="ddlAns9" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                        <br />



                        <asp:Label ID="lblQues10" runat="server" Text="" />
                        <asp:DropDownList runat="server" ID="ddlAns10" >
                            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="reqAns10" ControlToValidate="ddlAns10" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                        <br />



                        <asp:Label ID="lblQues11" runat="server" Text="" />
                        <asp:DropDownList runat="server" ID="ddlAns11" >
                            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ID="reqAns11" ControlToValidate="ddlAns11" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
                        <br />

                        </div>
                    </ContentTemplate>
                </asp:TabPanel>

            </asp:TabContainer>
        </div>
    </form>
</body>
</html>
