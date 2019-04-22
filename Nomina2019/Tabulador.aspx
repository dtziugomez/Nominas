<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tabulador.aspx.cs" Inherits="Nomina2019.Tabulador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Styles/Estilos.css" rel="stylesheet" />
</head>
<body>
    <h3>Tabulador</h3>
    <form id="frmGeneral" runat="server">
    <div><label>Sueldo base:</label><asp:TextBox runat="server" ID="txtSueldo" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="*" runat="server" 
                ControlToValidate="txtSueldo" />
        </div><br />
        <asp:Button runat="server" ID="btnActualizar" Text="Actualizar" OnClick="btnActualizar_Click"/>
        <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" CausesValidation="false" OnClick="btnCancelar_Click"/>
    </form>
</body>
</html>
