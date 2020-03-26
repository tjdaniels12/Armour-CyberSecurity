<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forgot_Password.aspx.cs" Inherits="ArmourCyberSecurity.Forgot_Password" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <th colspan="3">
                Forgot Password
            </th>
        </tr>
        <tr>
            <td>
                Email Address
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
            </td>
            <td>
                <asp:Button Text="Send Email" runat="server" OnClick="RegisterUser" />
            </td>
            <td>
            </td>
        </tr>
    </table>

</asp:Content>
