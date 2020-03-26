<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ArmourCyberSecurity.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <p>
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
            </p>
        </div>
</asp:Content>
