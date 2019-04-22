<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Nomina2019.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Nomina IMASD</title>
    <link href="Styles/Estilos.css" rel="stylesheet" />
    
    <script src="Scripts/validaciones.js"></script>
</head>
<body>
    <h3>Empleado</h3>
    <form id="frmGeneral" runat="server">
    <div>
    
        <div><label>Nombre:</label><asp:TextBox runat="server" ID="txtNombre" />
            <asp:RequiredFieldValidator ID="rfvNombre" ErrorMessage="*" runat="server" 
                ControlToValidate="txtNombre" />
        </div>
        <div>
            <label>Apellidos:</label><asp:TextBox runat="server" ID="txtApellidos" />
            <asp:RequiredFieldValidator ID="rfvApellidos" ErrorMessage="*" runat="server" 
                ControlToValidate="txtApellidos" />
            
        </div>
        <div><label>Telefono:</label><asp:TextBox runat="server" ID="txtTelefono" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="*" runat="server" 
                ControlToValidate="txtTelefono" />
        </div>
        <div><label>Direccion:</label><asp:TextBox runat="server" ID="txtDireccion" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="*" runat="server" 
                ControlToValidate="txtDireccion" />
        </div>
        <div><label>FechaIngreso:</label><asp:Calendar runat="server" ID="clFI" />
            
        </div><br />
        <div><label>Sueldo base:</label><asp:TextBox runat="server" ID="txtSueldo" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="*" runat="server" 
                ControlToValidate="txtSueldo" />
        </div>
        <div><label>Departamento:</label><asp:DropDownList runat="server" ID="ddlDepartamentos" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="*" runat="server" 
                ControlToValidate="ddlDepartamentos" />
        </div>
        <asp:Button runat="server" ID="btnAgregar" Text="Agregar" OnClick="btnAgregar_Click"/>
        <asp:panel ID="pnlBuscar" style="LEFT: 350px; POSITION: absolute; TOP: 16px" runat="server" 
			Height="507px" Width="339px" HorizontalAlign="Center">
            <h2>Sistema de nomina</h2>

            <asp:GridView runat="server" ID="gvEmpleados" OnRowCommand="gvEmpleados_RowCommand">
            <Columns>
                <asp:ButtonField ButtonType="Link" commandName="Pagar" Text="Pagar" />
                <asp:ButtonField ButtonType="Link" commandName="Quitar" Text="Quitar" />
                <asp:ButtonField ButtonType="Link" commandName="Actualizar" Text="Actualizar" />
                <asp:ButtonField ButtonType="Link" commandName="Tabulador" Text="Tabulador" />
            </Columns>
        </asp:GridView>
        </asp:panel>
        
    </div>
    </form>
</body>
</html>
