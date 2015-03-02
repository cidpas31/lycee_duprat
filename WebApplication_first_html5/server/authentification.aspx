<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="authentification.aspx.cs" Inherits="WebApplication_first_html5.server.authentification" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="/script/authentification.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../styles/formulaire.css"/>
    <title>authentification impossible</title>
</head>
<body>
    <form id="authentification_gestion_etudiant" runat="server">
        <div class="image_forbidden">
            <img src="../image/ucmt83cp.jpeg" />
            <div>
                <asp:Label ID="lbl" runat="server" />
            </div>
            <div>
                <input type="button" name="button_redirection" value="ok" onclick="redirection_authentification()" />
            </div>
        </div>
    </form>
</body>
</html>
