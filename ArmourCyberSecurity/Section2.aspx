<%@ Page Title="" Language="C#" MasterPageFile="~/CustomRoadmapMenu.Master" AutoEventWireup="true" CodeBehind="Section2.aspx.cs" Inherits="ArmourCyberSecurity.Section2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="lblQues6" runat="server" Text="" />
        <asp:DropDownList runat="server" ID="ddlAns6">
            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="reqAns6" ControlToValidate="ddlAns6" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
        <br />

        <asp:Label ID="lblQues7" runat="server" Text="" />
        <asp:DropDownList runat="server" ID="ddlAns7">
            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="reqAns7" ControlToValidate="ddlAns7" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
        <br />

        <asp:Label ID="lblQues8" runat="server" Text="" />
        <asp:DropDownList runat="server" ID="ddlAns8">
            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="reqAns8" ControlToValidate="ddlAns8" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
        <br />

        <asp:Label ID="lblQues9" runat="server" Text="" />
        <asp:DropDownList runat="server" ID="ddlAns9">
            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="reqAns9" ControlToValidate="ddlAns9" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
        <br />


        <asp:Label ID="lbl_warning" runat="server" Text="" ForeColor="Red"/>

        <asp:Button ID="btn_Save2" runat="server" Text="Save" OnClick="btn_Save2_Click"/>
       <%-- <asp:Button ID="btn_Submit" runat="server" Text="Finish" OnClick="btn_Submit_Click"/>--%>

    </div>
</asp:Content>
