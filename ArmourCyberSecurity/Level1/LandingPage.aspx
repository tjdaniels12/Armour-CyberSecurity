<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LandingPage.aspx.cs" Inherits="ArmourCyberSecurity.LandingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            LandingPage
            <asp:Button ID="level1" runat="server" Text="Level 1" OnClick="level1_Click"/>
            <asp:Button ID="level2" runat="server" Text="Level 2" OnClick="level2_Click"/>
        </div>
    </form>
</body>
</html>
