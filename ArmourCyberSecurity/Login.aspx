<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ArmourCyberSecurity.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbl_Username" runat="server" Text="UserName"></asp:Label>
            <asp:TextBox ID="txt_Username" runat="server"></asp:TextBox>

            <asp:Label ID="lbl_Password" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="txt_Password" runat="server"></asp:TextBox>
            
            <asp:Button ID="btn_Submit" runat="server" Text="Button" OnClick="btn_Submit_Click"/>
            <asp:Label ID="lbl_Error" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
