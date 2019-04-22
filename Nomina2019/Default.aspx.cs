using System;
using System.Web.UI;
using Logica;
using System.Web.UI.WebControls;
using System.Data;

namespace Nomina2019
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.gvEmpleados.DataSource = AccesoLogica.ObtenerEmpleados();
                this.gvEmpleados.DataBind();


                foreach (DataRow row in AccesoLogica.ObtenerDepartamentos().Rows)
                {
                    ListItem depto = new ListItem(row[1].ToString(), row[0].ToString()); 
                    this.ddlDepartamentos.Items.Add(depto);
                }
            }
        }

        private void Page_Init(object sender, EventArgs e)
        {
            txtSueldo.Attributes.Add("onkeypress", "return GetValidatorNumConDecimal(event)");
            
        }

        protected void gvEmpleados_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Quitar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvr = gvEmpleados.Rows[index];
                AccesoLogica.EliminaEmpleado(Convert.ToInt32(gvr.Cells[4].Text));
                RecargaTabla();
            }
            else if (e.CommandName == "Actualizar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvr = gvEmpleados.Rows[index];

                Response.Redirect("ActualizarEmpleado.aspx?Nombre=" +
                    Server.UrlEncode(gvr.Cells[5].Text) +
                    "&Apellidos=" + Server.UrlEncode(gvr.Cells[6].Text) +
                    "&Telefono=" + Server.UrlEncode(gvr.Cells[7].Text) +
                    "&Direccion=" + Server.UrlEncode(gvr.Cells[8].Text) +
                    "&FechaIngreso=" + Server.UrlEncode(gvr.Cells[9].Text) +
                    "&SueldoBase=" + Server.UrlEncode(gvr.Cells[10].Text) +
                    "&idDepartamento=" + Server.UrlEncode(gvr.Cells[11].Text)+
                    "&idEmpleado=" + Server.UrlEncode(gvr.Cells[4].Text));
            }
            else if (e.CommandName == "Tabulador")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvr = gvEmpleados.Rows[index];

                Response.Redirect("Tabulador.aspx?Nombre=" +
                    Server.UrlEncode(gvr.Cells[5].Text) +
                    "&Apellidos=" + Server.UrlEncode(gvr.Cells[6].Text) +
                    "&Telefono=" + Server.UrlEncode(gvr.Cells[7].Text) +
                    "&Direccion=" + Server.UrlEncode(gvr.Cells[8].Text) +
                    "&FechaIngreso=" + Server.UrlEncode(gvr.Cells[9].Text) +
                    "&SueldoBase=" + Server.UrlEncode(gvr.Cells[10].Text) +
                    "&idDepartamento=" + Server.UrlEncode(gvr.Cells[11].Text) +
                    "&idEmpleado=" + Server.UrlEncode(gvr.Cells[4].Text));
            }
            else if (e.CommandName == "Pagar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow gvr = gvEmpleados.Rows[index];

                Response.Redirect("Nomina.aspx?Nombre=" +
                    Server.UrlEncode(gvr.Cells[5].Text) +
                    "&Apellidos=" + Server.UrlEncode(gvr.Cells[6].Text) +
                    "&Telefono=" + Server.UrlEncode(gvr.Cells[7].Text) +
                    "&Direccion=" + Server.UrlEncode(gvr.Cells[8].Text) +
                    "&FechaIngreso=" + Server.UrlEncode(gvr.Cells[9].Text) +
                    "&SueldoBase=" + Server.UrlEncode(gvr.Cells[10].Text) +
                    "&idDepartamento=" + Server.UrlEncode(gvr.Cells[11].Text) +
                    "&idEmpleado=" + Server.UrlEncode(gvr.Cells[4].Text));
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AccesoLogica.InsertaEmpleado(txtNombre.Text, txtApellidos.Text, txtTelefono.Text, txtDireccion.Text,
            clFI.SelectedDate.ToShortDateString(), txtSueldo.Text, ddlDepartamentos.SelectedValue);
            RecargaTabla();
            LimpiarFormulario();
        }

        private void RecargaTabla()
        {
            this.gvEmpleados.DataSource = null;
            this.gvEmpleados.DataBind();
            this.gvEmpleados.DataSource = AccesoLogica.ObtenerEmpleados();
            this.gvEmpleados.DataBind();
        }

        private void LimpiarFormulario()
        {
            this.txtApellidos.Text = "";
            this.txtDireccion.Text = "";
            this.txtNombre.Text = "";
            this.txtSueldo.Text = "";
            this.txtTelefono.Text = "";
            this.clFI.SelectedDate = new DateTime();
            ddlDepartamentos.SelectedIndex = -1;
        }
    }
}