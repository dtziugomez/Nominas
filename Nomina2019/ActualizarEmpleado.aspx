<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActualizarEmpleado.aspx.cs" Inherits="Nomina2019.ActualizarEmpleado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Styles/Estilos.css" rel="stylesheet" />
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
        </div><br />
        <asp:Button runat="server" ID="btnActualizar" Text="Actualizar" OnClick="btnActualizar_Click"/>
        <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click"/>
        
    </div>
    </form>
</body>
</html>
