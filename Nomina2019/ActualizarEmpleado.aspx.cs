using System;
using System.Web.UI;
using Logica;
using System.Data;
using System.Web.UI.WebControls;

namespace Nomina2019
{
    public partial class ActualizarEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                this.txtNombre.Text = Request.QueryString["Nombre"];
                this.txtApellidos.Text = Request.QueryString["Apellidos"];
                this.txtDireccion.Text = Request.QueryString["Direccion"];
                this.txtSueldo.Text = Request.QueryString["SueldoBase"];
                this.txtTelefono.Text = Request.QueryString["Telefono"] ;
                this.clFI.TodaysDate = DateTime.Parse(Request.QueryString["FechaIngreso"]);
                this.clFI.SelectedDate = clFI.TodaysDate;
                foreach (DataRow row in AccesoLogica.ObtenerDepartamentos().Rows)
                {
                    ListItem depto = new ListItem(row[1].ToString(), row[0].ToString());
                    this.ddlDepartamentos.Items.Add(depto);
                }
                ddlDepartamentos.SelectedIndex = Convert.ToInt32(Request.QueryString["idDepartamento"])-1;

            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            AccesoLogica.ActualizaEmpleado(txtNombre.Text, txtApellidos.Text, this.txtTelefono.Text, this.txtDireccion.Text,
            clFI.SelectedDate.ToShortDateString(), txtSueldo.Text, (ddlDepartamentos.SelectedIndex + 1).ToString(), Convert.ToInt32(Request.QueryString["idEmpleado"]));
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}