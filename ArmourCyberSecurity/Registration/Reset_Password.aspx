<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reset_Password.aspx.cs" Inherits="ArmourCyberSecurity.Registration.Reset_Password" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="passwordreset" runat="server">
        <div>
            <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <th colspan="3">
                Password Reset
            </th>
        </tr>
        <tr>
            <td>
                Email
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" />
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="Required" Display="Dynamic" ForeColor="Red"
                    ControlToValidate="txtEmail" runat="server" />
                <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
            </td>
        </tr>
        <tr>
            <td>
                Password
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
            </td>
            <td>
                <asp:RequiredFieldValidator ErrorMessage="Required" ForeColor="Red" ControlToValidate="txtPassword"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Confirm Password
            </td>
            <td>
                <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" />
            </td>
            <td>
                <asp:CompareValidator ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txtPassword"
                    ControlToValidate="txtConfirmPassword" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="color: Red;">
                <asp:Literal runat="server" ID="FailureText" EnableViewState="False"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button Text="Reset" runat="server" OnClick="ResetClick" />
            </td>
            <td>
            </td>
        </tr>
    </table>
        </div>
    </form>



</body>
</html>
