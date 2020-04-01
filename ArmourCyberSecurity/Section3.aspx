<%@ Page Title="" Language="C#" MasterPageFile="~/CustomRoadmapMenu.Master" AutoEventWireup="true" CodeBehind="Section3.aspx.cs" Inherits="ArmourCyberSecurity.Section3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="lblQues10" runat="server" Text="" />
        <asp:DropDownList runat="server" ID="ddlAns10">
            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="reqAns10" ControlToValidate="ddlAns10" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
        <br />

        <asp:Label ID="lblQues11" runat="server" Text="" />
        <asp:DropDownList runat="server" ID="ddlAns11">
            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="reqAns11" ControlToValidate="ddlAns11" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
        <br />

        <asp:Label ID="lblQues12" runat="server" Text="" />
        <asp:DropDownList runat="server" ID="ddlAns12">
            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="reqAns12" ControlToValidate="ddlAns12" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
        <br />

        <asp:Label ID="lblQues13" runat="server" Text="" />
        <asp:DropDownList runat="server" ID="ddlAns13">
            <asp:ListItem Text="--SELECT--" Value="-1" Selected="True"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ID="reqAns13" ControlToValidate="ddlAns13" ErrorMessage="* Required" ForeColor="Red" InitialValue="-1" />
        <br />


        <asp:Label ID="lbl_warning" runat="server" Text="" ForeColor="Red"/>

        <asp:Button ID="btn_Save" runat="server" Text="Save" OnClick="btn_Save_Click"/>
       <%-- <asp:Button ID="btn_Submit" runat="server" Text="Finish" OnClick="btn_Submit_Click"/>--%>

    </div>
</asp:Content>
