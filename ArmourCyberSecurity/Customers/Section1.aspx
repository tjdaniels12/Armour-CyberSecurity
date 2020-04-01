<%@ Page Title="" Language="C#" MasterPageFile="~/CustomRoadmapMenu.Master" AutoEventWireup="true" CodeBehind="Section1.aspx.cs" Inherits="ArmourCyberSecurity.Section1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

        <asp:Button ID="btn_Save1" runat="server" Text="Save" OnClick="btn_Save1_Click"/>
    </div>
</asp:Content>
