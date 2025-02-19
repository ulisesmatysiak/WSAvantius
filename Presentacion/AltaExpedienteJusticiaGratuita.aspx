<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AltaExpedienteJusticiaGratuita.aspx.cs" Inherits="WS_Avantius.Presentacion.AltaExpedienteJusticiaGratuita" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label for="dateInput">Seleccione una fecha:</label>
            <input type="date" id="dateInput" name="selectedDate" />
        </div>
        <br />
        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="Enviar" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>
