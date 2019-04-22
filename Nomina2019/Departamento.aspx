<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Departamento.aspx.cs" Inherits="Nomina2019.Departamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h3>Departamento</h3>
    <form id="frmGeneral" runat="server">
        <div>
            <label>Nombre:</label><asp:TextBox runat="server" ID="txtNombreDepto" />
            <asp:Label ID="lblMensaje" runat="server" Visible="false"/>
        </div><br />
        <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click"/>
        <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click"/>
    </form>
</body>
</html>
