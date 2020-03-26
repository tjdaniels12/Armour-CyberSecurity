<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="ArmourCyberSecurity.Login" %>



<script runat="server">
bool IsValidEmail(string strIn)
{
    // Return true if strIn is in valid email format.
    return Regex.IsMatch(strIn, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"); 
}

void OnLoggingIn(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
{
    if (!IsValidEmail(Login1.UserName))
    {
        Login1.InstructionText = "Enter a valid email address.";
        Login1.InstructionTextStyle.ForeColor = System.Drawing.Color.RosyBrown;
        e.Cancel = true;
    }
    else
    {
        Login1.InstructionText = String.Empty;

    }
}

void OnLoginError(object sender, EventArgs e)
{
    Login1.HelpPageText = "Help with logging in...";
}
</script>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <%--<p>
              <strong>Email:</strong>
              <br />
              <asp:TextBox ID="txtUserName" runat="server" Columns="50"></asp:TextBox>
            </p>

            <p>
              <strong>Password:</strong>
              <br />
              <asp:TextBox ID="txtUserPass" runat="server" Columns="50" TextMode="Password"></asp:TextBox>
            </p>

            <p>
              <asp:Button ID="btnLogin" runat="server" Text="Log In" OnClick="btnLogin_Click" />
              <br />
              <asp:Label id="lblMsg" ForeColor="red" runat="server" />
            </p>--%>

            <asp:Login id="Login1" runat="server" 
                BorderStyle="Solid" 
                BackColor="#F7F7DE" 
                BorderWidth="1px"
                BorderColor="#CCCC99" 
                Font-Size="10pt" 
                Font-Names="Verdana" 
                CreateUserText="Create a new user..."
                CreateUserUrl="newUser.aspx" 
                HelpPageUrl="help.aspx"
                PasswordRecoveryUrl="getPass.aspx" 
                UserNameLabelText="Email address:" 
                OnLoggingIn="OnLoggingIn"
                OnLoginError="OnLoginError" 
                PasswordRecoveryText = "Forgot your password?">

                <LayoutTemplate>
                    <table cellspacing="0" cellpadding="1" style="border-collapse: collapse;">
                        <tr>
                            <td>
                                <table cellpadding="0">
                                    <tr>
                                        <td align="center" colspan="2" style="color: White; background-color: #6B696B; font-weight: bold;">Log In</td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label runat="server" AssociatedControlID="UserName" ID="UserNameLabel">Email address:</asp:Label></td>
                                        <td>
                                            <asp:TextBox runat="server" ID="UserName"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ValidationGroup="Login1" ToolTip="User Name is required." ID="UserNameRequired">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label runat="server" AssociatedControlID="Password" ID="PasswordLabel">Password:</asp:Label></td>
                                        <td>
                                            <asp:TextBox runat="server" TextMode="Password" ID="Password"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ValidationGroup="Login1" ToolTip="Password is required." ID="PasswordRequired">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CheckBox runat="server" Text="Remember me next time." ID="RememberMe"></asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2" style="color: Red;">
                                            <asp:Literal runat="server" ID="FailureText" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            <asp:Button runat="server" CommandName="Login" Text="Log In" ValidationGroup="Login1" ID="LoginButton" OnClick="btnLogin_Click"></asp:Button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:HyperLink runat="server" NavigateUrl="newUser.aspx" ID="CreateUserLink">Create a new user...</asp:HyperLink>
                                            <br />
                                            <asp:HyperLink runat="server" NavigateUrl="getPass.aspx" ID="PasswordRecoveryLink">Forgot your password?</asp:HyperLink>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>

                <TitleTextStyle Font-Bold="True" 
                    ForeColor="#FFFFFF" 
                    BackColor="#6B696B">
                </TitleTextStyle>
            </asp:Login>
            
        </div>
</asp:Content>



