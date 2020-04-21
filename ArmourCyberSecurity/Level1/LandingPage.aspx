<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="ArmourCyberSecurity.LandingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function ShowMsg() {
            alert('Your Have Logged Out Successfully');
            return true
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            LandingPage
            <asp:Button ID="level1" runat="server" Text="Level 1" OnClick="level1_Click"/>
            <asp:Button ID="level2" runat="server" Text="Level 2" OnClick="level2_Click"/>
            <asp:Button ID="logoutBtn" runat="server" Text="Logout" onClientClick="return ShowMsg();" OnClick="logout_Click"/>
        </div>
    </form>
</body>
</html>
