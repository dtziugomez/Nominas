<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Nomina.aspx.cs" Inherits="Nomina2019.Nomina" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="Styles/Estilos.css" rel="stylesheet" />
    
    <script src="Scripts/validaciones.js"></script>
    <script type="text/javascript">
        ValidatorEnable(document.getElementById('<%=rfvdiasTrabajados.ClientID%>'),false);
    </script>
    <style>
        .hidden{
            display:none;
        }
    </style>
</head>
<body>    
    <h3>Nomina</h3>
    <form id="frmGeneral" runat="server">
        <div>
    
        <div><label>Empleado:</label><asp:Label runat="server" ID="lblNombre" />
            
        </div><br />
        <div>
            <label>Dias trabajados:</label><asp:TextBox runat="server" ID="txtdiasTrabajados" 
                  />
            <asp:RequiredFieldValidator ID="rfvdiasTrabajados" ErrorMessage="*" runat="server" 
                ControlToValidate="txtdiasTrabajados"/>
            
        </div>
        <div><label>Horas extras:</label><asp:TextBox runat="server" ID="txtHorasExtra" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="*" runat="server" 
                ControlToValidate="txtHorasExtra" />
        </div>
        
        <div><label>Periodo desde:</label><asp:Calendar runat="server" ID="clPeriodoDesde" /></div>
        <div><label>Periodo Hasta:</label><asp:Calendar runat="server" ID="clPeridodHasta" /></div><br />
        
        <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button runat="server" ID="btnCancelar" Text="Cancelar" OnClick="btnCancelar_Click" CausesValidation="false"/>
    </div>
        <asp:panel ID="pnlBuscar" style="LEFT: 350px; POSITION: absolute; TOP: 16px" runat="server" 
			Height="507px" Width="339px" HorizontalAlign="Center"><br />
    <h3>Busquedas</h3>
    <div>
        <div><label>Clave Empleado:</label><asp:TextBox runat="server" ID="txtBuscar" /><br />
        <div><label>Departamento:</label>
            <asp:DropDownList runat="server" ID="ddlDepartamentos" 
                OnSelectedIndexChanged="ddlDepartamentos_SelectedIndexChanged" AutoPostBack="true"/>    
        </div>
        <asp:Button runat="server" ID="btnBuscar" Text="Buscar" OnClick="btnBuscar_Click" CausesValidation="false"/>
        </div>
    </div><br />
        <div>
            <asp:GridView runat="server" ID="gvNominas" OnRowCommand="gvNominas_RowCommand1">

            </asp:GridView>
        </div>
    </asp:panel>
        
    </form>
</body>
</html>
