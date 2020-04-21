<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Charge.aspx.cs" Inherits="ArmourCyberSecurity.Payment.Charge" %>

<!DOCTYPE html>
<script src="https://js.stripe.com/v3" type="text/javascript"> </script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form action="/Payment/ChargeSuccess" method="post">
    <script
        src="https://checkout.stripe.com/checkout.js" class="stripe-button"
        data-key="<%= stripePublishableKey %>"
        data-amount="500"
        data-name="Privacy Compliance Group"
        data-description="Level 2 Questionnaire"
        data-locale="auto"
        data-zip-code="true">
    </script>
</form>
</body>
</html>

